using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VanPhongPham.DAL
{
    public class HoanTraDAL
    {
        // ==================== LẤY DANH SÁCH PHIẾU TRẢ HÀNG ====================
        public DataTable LayDanhSach()
        {
            string sql = @"
                SELECT 
                    r.ReturnID,
                    r.ReturnCode,
                    o.OrderCode,
                    o.CustomerName,
                    r.ReturnDate,
                    u.FullName AS NhanVienXuLy,
                    r.Reason,
                    r.TotalRefund,
                    r.Status
                FROM ReturnOrder r
                INNER JOIN [Order] o ON r.OrderID = o.OrderID
                LEFT JOIN Users u ON r.UserID = u.UserID
                ORDER BY r.ReturnDate DESC";
            return Functions.GetDataToTable(sql);
        }

        // ==================== LẤY CHI TIẾT PHIẾU TRẢ ====================
        public DataTable LayChiTiet(int returnID)
        {
            string sql = $@"
                SELECT 
                    rd.ReturnDetailID,
                    p.ProductCode,
                    p.ProductName,
                    rd.Quantity,
                    rd.RefundAmount,
                    p.Unit
                FROM ReturnDetail rd
                INNER JOIN Product p ON rd.ProductID = p.ProductID
                WHERE rd.ReturnID = {returnID}";
            return Functions.GetDataToTable(sql);
        }

        // ==================== LẤY SẢN PHẨM TRONG ĐƠN HÀNG GỐC ====================
        // Dùng khi người dùng chọn đơn hàng để trả
        public DataTable LaySanPhamTrongDon(int orderID)
        {
            string sql = $@"
                SELECT 
                    od.OrderDetailID,
                    od.ProductID,
                    p.ProductCode,
                    p.ProductName,
                    od.Quantity AS SoLuongMua,
                    od.UnitPrice,
                    od.TotalPrice,
                    p.Unit,
                    ISNULL((
                        SELECT SUM(rd.Quantity) 
                        FROM ReturnDetail rd 
                        INNER JOIN ReturnOrder ro ON rd.ReturnID = ro.ReturnID 
                        WHERE ro.OrderID = {orderID} 
                          AND rd.ProductID = od.ProductID
                          AND ro.Status <> N'Từ chối'
                    ), 0) AS DaTraLai
                FROM OrderDetail od
                INNER JOIN Product p ON od.ProductID = p.ProductID
                WHERE od.OrderID = {orderID}";
            return Functions.GetDataToTable(sql);
        }

        // ==================== LẤY DANH SÁCH ĐƠN CHO PHÉP TRẢ ====================
        // Chỉ lấy đơn Hoàn thành hoặc Đã giao
        public DataTable LayDonChoPhepTra()
        {
            string sql = @"
                SELECT 
                    o.OrderID,
                    o.OrderCode + ' - ' + ISNULL(o.CustomerName, N'Khách lẻ') AS HienThi,
                    o.OrderCode,
                    o.CustomerName,
                    o.FinalAmount,
                    o.OrderDate
                FROM [Order] o
                WHERE o.Status IN (N'Hoàn thành', N'Đã giao')
                ORDER BY o.OrderDate DESC";
            return Functions.GetDataToTable(sql);
        }

        // ==================== TẠO PHIẾU TRẢ HÀNG (TRANSACTION) ====================
        // Dùng Transaction để đảm bảo tính toàn vẹn:
        // 1. INSERT ReturnOrder
        // 2. INSERT ReturnDetail (từng dòng) → Trigger tự cộng stock
        // Nếu lỗi → ROLLBACK
        public bool TaoPhieuTra(string returnCode, int orderID, int userID,
                                string reason, decimal totalRefund,
                                DataTable chiTiet)
        {
            SqlTransaction transaction = null;
            try
            {
                // Đảm bảo connection đang mở
                if (Functions.Conn.State != ConnectionState.Open)
                    Functions.Conn.Open();

                transaction = Functions.Conn.BeginTransaction();

                // Bước 1: INSERT vào ReturnOrder
                string sqlReturn = $@"
                    INSERT INTO ReturnOrder (ReturnCode, OrderID, UserID, ReturnDate, Reason, TotalRefund, Status)
                    VALUES (N'{returnCode}', {orderID}, {userID}, GETDATE(), N'{reason}', {totalRefund}, N'Đã hoàn tiền');
                    SELECT SCOPE_IDENTITY();";

                SqlCommand cmdReturn = new SqlCommand(sqlReturn, Functions.Conn, transaction);
                int returnID = Convert.ToInt32(cmdReturn.ExecuteScalar());

                // Bước 2: INSERT từng dòng chi tiết
                foreach (DataRow row in chiTiet.Rows)
                {
                    int productID = Convert.ToInt32(row["ProductID"]);
                    int quantity = Convert.ToInt32(row["SoLuongTra"]);
                    decimal refundAmount = Convert.ToDecimal(row["TienHoan"]);

                    if (quantity <= 0) continue; // Bỏ qua dòng không trả

                    string sqlDetail = $@"
                        INSERT INTO ReturnDetail (ReturnID, ProductID, Quantity, RefundAmount)
                        VALUES ({returnID}, {productID}, {quantity}, {refundAmount})";

                    SqlCommand cmdDetail = new SqlCommand(sqlDetail, Functions.Conn, transaction);
                    cmdDetail.ExecuteNonQuery();
                }

                // Thành công → COMMIT
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                // Lỗi → ROLLBACK
                if (transaction != null)
                    transaction.Rollback();

                MessageBox.Show("Lỗi khi tạo phiếu trả hàng: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ==================== CẬP NHẬT TRẠNG THÁI PHIẾU TRẢ ====================
        public void CapNhatTrangThai(int returnID, string status)
        {
            string sql = $"UPDATE ReturnOrder SET Status = N'{status}' WHERE ReturnID = {returnID}";
            Functions.RunSql(sql);
        }

        // ==================== TÌM KIẾM PHIẾU TRẢ ====================
        public DataTable TimKiem(string tuKhoa)
        {
            string sql = $@"
                SELECT 
                    r.ReturnID,
                    r.ReturnCode,
                    o.OrderCode,
                    o.CustomerName,
                    r.ReturnDate,
                    u.FullName AS NhanVienXuLy,
                    r.Reason,
                    r.TotalRefund,
                    r.Status
                FROM ReturnOrder r
                INNER JOIN [Order] o ON r.OrderID = o.OrderID
                LEFT JOIN Users u ON r.UserID = u.UserID
                WHERE r.ReturnCode LIKE N'%{tuKhoa}%' 
                   OR o.OrderCode LIKE N'%{tuKhoa}%'
                   OR o.CustomerName LIKE N'%{tuKhoa}%'
                ORDER BY r.ReturnDate DESC";
            return Functions.GetDataToTable(sql);
        }
    }
}
