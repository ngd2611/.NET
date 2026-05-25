using System;
using System.Data;
using System.Data.SqlClient;

namespace VanPhongPham.DAL
{
    public class DonHangDAL
    {
        // ==================== LẤY DANH SÁCH ĐƠN HÀNG ====================
        public DataTable LayDanhSach()
        {
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
            string sql = $@"
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
                WHERE od.OrderID = {orderID}";
            return Functions.GetDataToTable(sql);
        }

        // ==================== CẬP NHẬT TRẠNG THÁI ====================
        public void CapNhatTrangThai(int orderID, string status)
        {
            string sql = $"UPDATE [Order] SET Status = N'{status}', UpdatedAt = GETDATE() WHERE OrderID = {orderID}";
            Functions.RunSql(sql);
        }

        // ==================== HỦY ĐƠN HÀNG ====================
        public void HuyDon(int orderID)
        {
            string sql = $"UPDATE [Order] SET Status = N'Hủy', UpdatedAt = GETDATE() WHERE OrderID = {orderID}";
            Functions.RunSql(sql);
        }

        // ==================== LẤY TRẠNG THÁI HIỆN TẠI ====================
        public string LayTrangThai(int orderID)
        {
            string sql = $"SELECT Status FROM [Order] WHERE OrderID = {orderID}";
            return Functions.GetFieldValues(sql);
        }

        // ==================== TÌM KIẾM / LỌC ĐƠN HÀNG ====================
        public DataTable TimKiem(string tuKhoa, string trangThai, DateTime? tuNgay, DateTime? denNgay)
        {
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

            // Lọc theo từ khóa (mã đơn hoặc tên khách)
            if (!string.IsNullOrEmpty(tuKhoa))
                sql += $" AND (o.OrderCode LIKE N'%{tuKhoa}%' OR o.CustomerName LIKE N'%{tuKhoa}%')";

            // Lọc theo trạng thái
            if (!string.IsNullOrEmpty(trangThai) && trangThai != "Tất cả")
                sql += $" AND o.Status = N'{trangThai}'";

            // Lọc theo khoảng ngày
            if (tuNgay.HasValue)
                sql += $" AND o.OrderDate >= '{tuNgay.Value:yyyy-MM-dd}'";

            if (denNgay.HasValue)
                sql += $" AND o.OrderDate <= '{denNgay.Value:yyyy-MM-dd} 23:59:59'";

            sql += " ORDER BY o.OrderDate DESC";

            return Functions.GetDataToTable(sql);
        }

        // ==================== ĐẾM ĐƠN HÀNG THEO TRẠNG THÁI ====================
        public int DemDonTheoTrangThai(string status)
        {
            string sql = $"SELECT COUNT(*) FROM [Order] WHERE Status = N'{status}'";
            string result = Functions.GetFieldValues(sql);
            return string.IsNullOrEmpty(result) ? 0 : int.Parse(result);
        }
    }
}
