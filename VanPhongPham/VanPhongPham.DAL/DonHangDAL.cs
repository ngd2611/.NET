using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace VanPhongPham.DAL
{
    public class DonHangDAL
    {
        // ✅ [FIX #12] Đảm bảo kết nối luôn mở trước mọi thao tác
        private void KiemTraKetNoi()
        {
            if (Functions.Conn == null || Functions.Conn.State != ConnectionState.Open)
                Functions.Connect();
        }
        // ==================== LẤY DANH SÁCH ĐƠN HÀNG ====================
        public DataTable LayDanhSach()
        {
            KiemTraKetNoi();
            string sql = @"
                SELECT 
                    o.OrderID,
                    o.OrderCode,
                    o.CustomerName,
                    o.CustomerPhone,
                    o.OrderDate,
                    u.FullName AS NhanVien,
                    o.Status,
                    o.TotalAmount,
                    o.Discount,
                    o.FinalAmount,
                    o.Note
                FROM [Order] o
                LEFT JOIN Users u ON o.UserID = u.UserID
                ORDER BY o.OrderDate DESC";
            return Functions.GetDataToTable(sql);
        }

        // ==================== LẤY CHI TIẾT ĐƠN HÀNG ====================
        public DataTable LayChiTiet(int orderID)
        {
            KiemTraKetNoi();
            string sql = @"
                SELECT 
                    od.OrderDetailID,
                    p.ProductCode,
                    p.ProductName,
                    od.Quantity,
                    od.UnitPrice,
                    od.Discount,
                    od.TotalPrice,
                    p.Unit
                FROM OrderDetail od
                INNER JOIN Product p ON od.ProductID = p.ProductID
                WHERE od.OrderID = @orderID";
            return Functions.GetDataToTable(sql, new SqlParameter("@orderID", orderID));
        }

        // ==================== CẬP NHẬT TRẠNG THÁI ====================
        public void CapNhatTrangThai(int orderID, string status)
        {
            KiemTraKetNoi();
            // ✅ [FIX #7] Dùng SqlParameter
            Functions.RunSql(
                "UPDATE [Order] SET Status = @status, UpdatedAt = GETDATE() WHERE OrderID = @id",
                new SqlParameter("@status", status),
                new SqlParameter("@id",     orderID)
            );
        }

        // ==================== HỦY ĐƠN HÀNG ====================
        public void HuyDon(int orderID)
        {
            KiemTraKetNoi();
            Functions.RunSql(
                "UPDATE [Order] SET Status = N'Hủy', UpdatedAt = GETDATE() WHERE OrderID = @id",
                new SqlParameter("@id", orderID)
            );
        }

        // ==================== LẤY TRẠNG THÁI HIỆN TẠI ====================
        public string LayTrangThai(int orderID)
        {
            KiemTraKetNoi();
            // ID là integer, an toàn; GetFieldValues xử lý kết nối
            return Functions.GetFieldValues($"SELECT Status FROM [Order] WHERE OrderID = {orderID}");
        }

        // ==================== TÌM KIẾM / LỌC ĐƠN HÀNG ====================
        // ✅ [FIX #7] TimKiem dùng SqlParameter chống SQL Injection
        public DataTable TimKiem(string tuKhoa, string trangThai, DateTime? tuNgay, DateTime? denNgay)
        {
            KiemTraKetNoi();
            string sql = @"
                SELECT 
                    o.OrderID,
                    o.OrderCode,
                    o.CustomerName,
                    o.CustomerPhone,
                    o.OrderDate,
                    u.FullName AS NhanVien,
                    o.Status,
                    o.TotalAmount,
                    o.Discount,
                    o.FinalAmount,
                    o.Note
                FROM [Order] o
                LEFT JOIN Users u ON o.UserID = u.UserID
                WHERE 1=1";

            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                sql += " AND (o.OrderCode LIKE @tuKhoa OR o.CustomerName LIKE @tuKhoa)";
                parameters.Add(new SqlParameter("@tuKhoa", "%" + tuKhoa + "%"));
            }
            if (!string.IsNullOrEmpty(trangThai) && trangThai != "Tất cả")
            {
                sql += " AND o.Status = @trangThai";
                parameters.Add(new SqlParameter("@trangThai", trangThai));
            }
            if (tuNgay.HasValue)
            {
                sql += " AND o.OrderDate >= @tuNgay";
                parameters.Add(new SqlParameter("@tuNgay", tuNgay.Value.Date));
            }
            if (denNgay.HasValue)
            {
                sql += " AND o.OrderDate <= @denNgay";
                parameters.Add(new SqlParameter("@denNgay", denNgay.Value.Date.AddDays(1).AddSeconds(-1)));
            }

            sql += " ORDER BY o.OrderDate DESC";
            return Functions.GetDataToTable(sql, parameters.ToArray());
        }

        // ==================== ĐẾM ĐƠN HÀNG THEO TRẠNG THÁI ====================
        public int DemDonTheoTrangThai(string status)
        {
            KiemTraKetNoi();
            // ✅ [FIX #7] Dùng SqlParameter
            string sql = "SELECT COUNT(*) FROM [Order] WHERE Status = @status";
            DataTable dt = Functions.GetDataToTable(sql, new SqlParameter("@status", status));
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
                return Convert.ToInt32(dt.Rows[0][0]);
            return 0;
        }
    }
}
