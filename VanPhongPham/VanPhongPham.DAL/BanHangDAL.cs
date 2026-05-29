using System;
using System.Data;
using System.Data.SqlClient;

namespace VanPhongPham.DAL
{
    public class BanHangDAL
    {
        // ==================== LẤY SẢN PHẨM CÒN HÀNG ĐỂ BÁN ====================
        public DataTable LaySanPhamConHang()
        {
            string sql = @"SELECT ProductID, ProductCode, ProductName, Unit, UnitPrice, StockQuantity
                           FROM Product 
                           WHERE IsActive = 1 AND StockQuantity > 0
                           ORDER BY ProductName";
            return Functions.GetDataToTable(sql);
        }

        // ==================== TÌM SẢN PHẨM ====================
        public DataTable TimSanPham(string tuKhoa)
        {
            string sql = $@"SELECT ProductID, ProductCode, ProductName, Unit, UnitPrice, StockQuantity
                            FROM Product 
                            WHERE IsActive = 1 AND StockQuantity > 0
                              AND (ProductCode LIKE N'%{tuKhoa}%' OR ProductName LIKE N'%{tuKhoa}%')
                            ORDER BY ProductName";
            return Functions.GetDataToTable(sql);
        }

        // ==================== LẤY TỒN KHO HIỆN TẠI ====================
        public int LayTonKho(int productID)
        {
            string sql = $"SELECT StockQuantity FROM Product WHERE ProductID = {productID}";
            string val = Functions.GetFieldValues(sql);
            return string.IsNullOrEmpty(val) ? 0 : int.Parse(val);
        }

        // ==================== TẠO ĐƠN BÁN HÀNG (Transaction) ====================
        public bool TaoDonBan(string orderCode, string customerName, string customerPhone,
                              int userID, decimal totalAmount, decimal discount, decimal finalAmount,
                              string note, DataTable gioHang)
        {
            SqlTransaction trans = null;
            try
            {
                if (Functions.Conn.State != ConnectionState.Open)
                    Functions.Connect();

                trans = Functions.Conn.BeginTransaction();

                // INSERT [Order] với Status = 'Hoàn thành' (bán tại quầy = hoàn thành ngay)
                string sqlOrder = @"INSERT INTO [Order] (OrderCode, CustomerName, CustomerPhone, OrderDate, UserID, 
                                                         Status, TotalAmount, Discount, FinalAmount, Note)
                                    VALUES (@Code, @CustName, @CustPhone, GETDATE(), @UserID,
                                            N'Hoàn thành', @Total, @Discount, @Final, @Note);
                                    SELECT SCOPE_IDENTITY();";

                int orderID;
                using (SqlCommand cmd = new SqlCommand(sqlOrder, Functions.Conn, trans))
                {
                    cmd.Parameters.AddWithValue("@Code", orderCode);
                    cmd.Parameters.AddWithValue("@CustName", string.IsNullOrEmpty(customerName) ? "Khách lẻ" : customerName);
                    cmd.Parameters.AddWithValue("@CustPhone", string.IsNullOrEmpty(customerPhone) ? (object)DBNull.Value : customerPhone);
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@Total", totalAmount);
                    cmd.Parameters.AddWithValue("@Discount", discount);
                    cmd.Parameters.AddWithValue("@Final", finalAmount);
                    cmd.Parameters.AddWithValue("@Note", string.IsNullOrEmpty(note) ? (object)DBNull.Value : note);
                    orderID = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // INSERT OrderDetail
                foreach (DataRow row in gioHang.Rows)
                {
                    int soLuong = Convert.ToInt32(row["SoLuong"]);
                    if (soLuong <= 0) continue;

                    string sqlDetail = @"INSERT INTO OrderDetail (OrderID, ProductID, Quantity, UnitPrice, Discount)
                                         VALUES (@OrderID, @ProductID, @Qty, @Price, 0)";
                    using (SqlCommand cmd = new SqlCommand(sqlDetail, Functions.Conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderID);
                        cmd.Parameters.AddWithValue("@ProductID", Convert.ToInt32(row["ProductID"]));
                        cmd.Parameters.AddWithValue("@Qty", soLuong);
                        cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(row["DonGia"]));
                        cmd.ExecuteNonQuery();
                    }
                }

                // Trigger trg_Order_DeductStock sẽ TỰ ĐỘNG TRỪ tồn kho 
                // vì Status = 'Hoàn thành'
                // Nhưng trigger chỉ fire khi UPDATE status, không fire khi INSERT
                // => Cần trừ thủ công tồn kho ở đây
                foreach (DataRow row in gioHang.Rows)
                {
                    int soLuong = Convert.ToInt32(row["SoLuong"]);
                    if (soLuong <= 0) continue;

                    string sqlStock = @"UPDATE Product SET StockQuantity = StockQuantity - @Qty 
                                        WHERE ProductID = @ProductID";
                    using (SqlCommand cmd = new SqlCommand(sqlStock, Functions.Conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@Qty", soLuong);
                        cmd.Parameters.AddWithValue("@ProductID", Convert.ToInt32(row["ProductID"]));
                        cmd.ExecuteNonQuery();
                    }
                }

                trans.Commit();
                return true;
            }
            catch
            {
                if (trans != null) trans.Rollback();
                throw;
            }
        }

        // ==================== LẤY LỊCH SỬ BÁN HÀNG HÔM NAY ====================
        public DataTable LayDonBanHomNay()
        {
            string sql = @"SELECT o.OrderID, o.OrderCode, o.CustomerName, o.CustomerPhone,
                                  o.OrderDate, o.FinalAmount, o.Status, u.FullName AS NhanVien
                           FROM [Order] o
                           INNER JOIN Users u ON o.UserID = u.UserID
                           WHERE CAST(o.OrderDate AS DATE) = CAST(GETDATE() AS DATE)
                           ORDER BY o.OrderDate DESC";
            return Functions.GetDataToTable(sql);
        }
    }
}
