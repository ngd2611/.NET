using System;
using System.Data;
using System.Data.SqlClient;

namespace VanPhongPham.DAL
{
    public class NhapKhoDAL
    {
        // ==================== LẤY DANH SÁCH NHÀ CUNG CẤP ====================
        public DataTable LayDanhSachNCC()
        {
            string sql = "SELECT SupplierID, SupplierName FROM Supplier WHERE IsActive = 1 ORDER BY SupplierName";
            return Functions.GetDataToTable(sql);
        }

        // ==================== LẤY DANH SÁCH SẢN PHẨM ĐỂ CHỌN ====================
        public DataTable LayDanhSachSanPham()
        {
            string sql = @"SELECT ProductID, ProductCode, ProductName, Unit, CostPrice, UnitPrice, StockQuantity 
                           FROM Product WHERE IsActive = 1 ORDER BY ProductName";
            return Functions.GetDataToTable(sql);
        }

        // ==================== TẠO PHIẾU NHẬP KHO (Transaction) ====================
        public bool TaoPhieuNhap(string purchaseCode, int supplierID, int userID, string note, decimal totalAmount, DataTable chiTiet)
        {
            SqlTransaction trans = null;
            try
            {
                if (Functions.Conn.State != ConnectionState.Open)
                    Functions.Connect();

                trans = Functions.Conn.BeginTransaction();

                // INSERT PurchaseOrder
                string sqlOrder = @"INSERT INTO PurchaseOrder (PurchaseCode, SupplierID, UserID, PurchaseDate, TotalAmount, Note, Status)
                                    VALUES (@Code, @SupplierID, @UserID, GETDATE(), @Total, @Note, N'Đã nhập');
                                    SELECT SCOPE_IDENTITY();";

                int purchaseID;
                using (SqlCommand cmd = new SqlCommand(sqlOrder, Functions.Conn, trans))
                {
                    cmd.Parameters.AddWithValue("@Code", purchaseCode);
                    cmd.Parameters.AddWithValue("@SupplierID", supplierID);
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@Total", totalAmount);
                    cmd.Parameters.AddWithValue("@Note", string.IsNullOrEmpty(note) ? (object)DBNull.Value : note);
                    purchaseID = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // INSERT PurchaseDetail (trigger sẽ tự CỘNG tồn kho)
                foreach (DataRow row in chiTiet.Rows)
                {
                    int soLuong = Convert.ToInt32(row["SoLuong"]);
                    if (soLuong <= 0) continue;

                    string sqlDetail = @"INSERT INTO PurchaseDetail (PurchaseID, ProductID, Quantity, UnitPrice)
                                         VALUES (@PurchaseID, @ProductID, @Qty, @Price)";
                    using (SqlCommand cmd = new SqlCommand(sqlDetail, Functions.Conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@PurchaseID", purchaseID);
                        cmd.Parameters.AddWithValue("@ProductID", Convert.ToInt32(row["ProductID"]));
                        cmd.Parameters.AddWithValue("@Qty", soLuong);
                        cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(row["DonGia"]));
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

        // ==================== LẤY DANH SÁCH PHIẾU NHẬP ====================
        public DataTable LayDanhSachPhieuNhap()
        {
            string sql = @"SELECT po.PurchaseID, po.PurchaseCode, s.SupplierName, u.FullName AS NhanVien,
                                  po.PurchaseDate, po.TotalAmount, po.Status, po.Note
                           FROM PurchaseOrder po
                           INNER JOIN Supplier s ON po.SupplierID = s.SupplierID
                           INNER JOIN Users u ON po.UserID = u.UserID
                           ORDER BY po.PurchaseDate DESC";
            return Functions.GetDataToTable(sql);
        }

        // ==================== LẤY CHI TIẾT PHIẾU NHẬP ====================
        public DataTable LayChiTietPhieuNhap(int purchaseID)
        {
            string sql = $@"SELECT pd.PurchaseDetailID, p.ProductCode, p.ProductName, p.Unit,
                                   pd.Quantity, pd.UnitPrice, pd.TotalPrice
                            FROM PurchaseDetail pd
                            INNER JOIN Product p ON pd.ProductID = p.ProductID
                            WHERE pd.PurchaseID = {purchaseID}";
            return Functions.GetDataToTable(sql);
        }

        // ==================== TÌM KIẾM PHIẾU NHẬP ====================
        public DataTable TimKiemPhieuNhap(string tuKhoa)
        {
            string sql = $@"SELECT po.PurchaseID, po.PurchaseCode, s.SupplierName, u.FullName AS NhanVien,
                                   po.PurchaseDate, po.TotalAmount, po.Status, po.Note
                            FROM PurchaseOrder po
                            INNER JOIN Supplier s ON po.SupplierID = s.SupplierID
                            INNER JOIN Users u ON po.UserID = u.UserID
                            WHERE po.PurchaseCode LIKE N'%{tuKhoa}%' 
                               OR s.SupplierName LIKE N'%{tuKhoa}%'
                            ORDER BY po.PurchaseDate DESC";
            return Functions.GetDataToTable(sql);
        }
    }
}
