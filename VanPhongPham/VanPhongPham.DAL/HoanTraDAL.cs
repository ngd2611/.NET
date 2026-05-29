using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
// ✅ [FIX #2] Đã xóa: using System.Windows.Forms — DAL không được import namespace UI

namespace VanPhongPham.DAL
{
    public class HoanTraDAL
    {
        // ✅ [FIX #12] Đảm bảo kết nối luôn mở trước mọi thao tác
        private void KiemTraKetNoi()
        {
            if (Functions.Conn == null || Functions.Conn.State != ConnectionState.Open)
                Functions.Connect();
        }

        // ==================== LẤY DANH SÁCH PHIẾU TRẢ HÀNG ====================
        public DataTable LayDanhSach()
        {
            KiemTraKetNoi();
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
            KiemTraKetNoi();
            string sql = @"
                SELECT 
                    rd.ReturnDetailID,
                    p.ProductCode,
                    p.ProductName,
                    rd.Quantity,
                    rd.RefundAmount,
                    p.Unit
                FROM ReturnDetail rd
                INNER JOIN Product p ON rd.ProductID = p.ProductID
                WHERE rd.ReturnID = @returnID";
            return Functions.GetDataToTable(sql, new SqlParameter("@returnID", returnID));
        }

        // ==================== LẤY SẢN PHẨM TRONG ĐƠN HÀNG GỐC ====================
        public DataTable LaySanPhamTrongDon(int orderID)
        {
            KiemTraKetNoi();
            string sql = @"
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
                        WHERE ro.OrderID = @orderID 
                          AND rd.ProductID = od.ProductID
                          AND ro.Status <> N'Từ chối'
                    ), 0) AS DaTraLai
                FROM OrderDetail od
                INNER JOIN Product p ON od.ProductID = p.ProductID
                WHERE od.OrderID = @orderID";
            return Functions.GetDataToTable(sql, new SqlParameter("@orderID", orderID));
        }

        // ==================== LẤY DANH SÁCH ĐƠN CHO PHÉP TRẢ ====================
        public DataTable LayDonChoPhepTra()
        {
            KiemTraKetNoi();
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
        // ✅ [FIX #2] Xóa MessageBox — throw exception để BLL/GUI xử lý
        // ✅ [FIX #7] Parameterize toàn bộ SQL chống SQL Injection
        public bool TaoPhieuTra(string returnCode, int orderID, int userID,
                                string reason, decimal totalRefund,
                                DataTable chiTiet)
        {
            KiemTraKetNoi();
            SqlTransaction transaction = null;
            try
            {
                transaction = Functions.Conn.BeginTransaction();

                // Bước 1: INSERT vào ReturnOrder — ✅ Dùng SqlParameter
                string sqlReturn = @"
                    INSERT INTO ReturnOrder (ReturnCode, OrderID, UserID, ReturnDate, Reason, TotalRefund, Status)
                    VALUES (@returnCode, @orderID, @userID, GETDATE(), @reason, @totalRefund, N'Đã hoàn tiền');
                    SELECT SCOPE_IDENTITY();";

                SqlCommand cmdReturn = new SqlCommand(sqlReturn, Functions.Conn, transaction);
                cmdReturn.Parameters.AddWithValue("@returnCode",  returnCode);
                cmdReturn.Parameters.AddWithValue("@orderID",     orderID);
                cmdReturn.Parameters.AddWithValue("@userID",      userID);
                cmdReturn.Parameters.AddWithValue("@reason",      reason);
                cmdReturn.Parameters.AddWithValue("@totalRefund", totalRefund);

                int returnID = Convert.ToInt32(cmdReturn.ExecuteScalar());

                // Bước 2: INSERT từng dòng chi tiết — ✅ Dùng SqlParameter
                string sqlDetail = @"
                    INSERT INTO ReturnDetail (ReturnID, ProductID, Quantity, RefundAmount)
                    VALUES (@returnID, @productID, @qty, @refund)";

                foreach (DataRow row in chiTiet.Rows)
                {
                    int qty = Convert.ToInt32(row["SoLuongTra"]);
                    if (qty <= 0) continue; // Bỏ qua dòng không trả

                    SqlCommand cmdDetail = new SqlCommand(sqlDetail, Functions.Conn, transaction);
                    cmdDetail.Parameters.AddWithValue("@returnID",  returnID);
                    cmdDetail.Parameters.AddWithValue("@productID", Convert.ToInt32(row["ProductID"]));
                    cmdDetail.Parameters.AddWithValue("@qty",       qty);
                    cmdDetail.Parameters.AddWithValue("@refund",    Convert.ToDecimal(row["TienHoan"]));
                    cmdDetail.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (transaction != null) transaction.Rollback();
                // ✅ [FIX #2] Throw thay vì MessageBox — để BLL/GUI xử lý đúng tầng
                throw new Exception("Lỗi khi tạo phiếu trả hàng: " + ex.Message);
            }
        }

        // ==================== CẬP NHẬT TRẠNG THÁI PHIẾU TRẢ ====================
        public void CapNhatTrangThai(int returnID, string status)
        {
            KiemTraKetNoi();
            Functions.RunSql(
                "UPDATE ReturnOrder SET Status = @status WHERE ReturnID = @id",
                new SqlParameter("@status", status),
                new SqlParameter("@id",     returnID)
            );
        }

        // ==================== TÌM KIẾM PHIẾU TRẢ ====================
        // ✅ [FIX #7] Dùng SqlParameter chống SQL Injection
        public DataTable TimKiem(string tuKhoa)
        {
            KiemTraKetNoi();
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
                WHERE r.ReturnCode    LIKE @tuKhoa 
                   OR o.OrderCode     LIKE @tuKhoa
                   OR o.CustomerName  LIKE @tuKhoa
                ORDER BY r.ReturnDate DESC";
            return Functions.GetDataToTable(sql,
                new SqlParameter("@tuKhoa", "%" + tuKhoa + "%"));
        }
    }
}
