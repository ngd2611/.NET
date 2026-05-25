using System;
using System.Data;

namespace VanPhongPham.DAL
{
    public class ThongKeDAL
    {
        // ==================== DOANH THU HÔM NAY ====================
        public decimal LayDoanhThuHomNay()
        {
            string sql = @"
                SELECT ISNULL(SUM(FinalAmount), 0) 
                FROM [Order] 
                WHERE Status = N'Hoàn thành' 
                  AND CAST(OrderDate AS DATE) = CAST(GETDATE() AS DATE)";
            string result = Functions.GetFieldValues(sql);
            return string.IsNullOrEmpty(result) ? 0 : decimal.Parse(result);
        }

        // ==================== SỐ ĐƠN HÀNG HÔM NAY ====================
        public int LaySoDonHomNay()
        {
            string sql = @"
                SELECT COUNT(*) 
                FROM [Order] 
                WHERE CAST(OrderDate AS DATE) = CAST(GETDATE() AS DATE)";
            string result = Functions.GetFieldValues(sql);
            return string.IsNullOrEmpty(result) ? 0 : int.Parse(result);
        }

        // ==================== SỐ SP SẮP HẾT HÀNG ====================
        public int LaySoSPSapHet()
        {
            string sql = @"
                SELECT COUNT(*) 
                FROM Product 
                WHERE StockQuantity <= MinStockLevel 
                  AND IsActive = 1";
            string result = Functions.GetFieldValues(sql);
            return string.IsNullOrEmpty(result) ? 0 : int.Parse(result);
        }

        // ==================== TỔNG KHÁCH HÀNG ====================
        public int LayTongKhachHang()
        {
            string sql = @"
                SELECT COUNT(DISTINCT CustomerPhone) 
                FROM [Order] 
                WHERE CustomerPhone IS NOT NULL AND CustomerPhone <> ''";
            string result = Functions.GetFieldValues(sql);
            return string.IsNullOrEmpty(result) ? 0 : int.Parse(result);
        }

        // ==================== DOANH THU THEO NGÀY (cho biểu đồ) ====================
        public DataTable LayDoanhThuTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            string sql = $@"
                SELECT 
                    CAST(OrderDate AS DATE) AS Ngay,
                    COUNT(OrderID) AS SoDon,
                    ISNULL(SUM(FinalAmount), 0) AS DoanhThu
                FROM [Order]
                WHERE Status = N'Hoàn thành'
                  AND CAST(OrderDate AS DATE) >= '{tuNgay:yyyy-MM-dd}'
                  AND CAST(OrderDate AS DATE) <= '{denNgay:yyyy-MM-dd}'
                GROUP BY CAST(OrderDate AS DATE)
                ORDER BY Ngay";
            return Functions.GetDataToTable(sql);
        }

        // ==================== DOANH THU THEO THÁNG TRONG NĂM ====================
        public DataTable LayDoanhThuTheoThang(int nam)
        {
            string sql = $@"
                SELECT 
                    MONTH(OrderDate) AS Thang,
                    COUNT(OrderID) AS SoDon,
                    ISNULL(SUM(FinalAmount), 0) AS DoanhThu
                FROM [Order]
                WHERE Status = N'Hoàn thành'
                  AND YEAR(OrderDate) = {nam}
                GROUP BY MONTH(OrderDate)
                ORDER BY Thang";
            return Functions.GetDataToTable(sql);
        }

        // ==================== TOP SẢN PHẨM BÁN CHẠY ====================
        public DataTable LayTopBanChay(int top = 10)
        {
            string sql = $@"
                SELECT TOP {top}
                    p.ProductCode AS MaSP,
                    p.ProductName AS TenSP,
                    SUM(od.Quantity) AS SoLuongBan,
                    SUM(od.TotalPrice) AS DoanhThu
                FROM OrderDetail od
                INNER JOIN Product p ON od.ProductID = p.ProductID
                INNER JOIN [Order] o ON od.OrderID = o.OrderID
                WHERE o.Status = N'Hoàn thành'
                GROUP BY p.ProductCode, p.ProductName
                ORDER BY SoLuongBan DESC";
            return Functions.GetDataToTable(sql);
        }

        // ==================== TỒN KHO CẢNH BÁO ====================
        public DataTable LayTonKhoCanhBao()
        {
            string sql = @"
                SELECT 
                    p.ProductCode AS MaSP,
                    p.ProductName AS TenSP,
                    p.StockQuantity AS TonKho,
                    p.MinStockLevel AS MucToiThieu,
                    c.CategoryName AS DanhMuc,
                    b.BrandName AS ThuongHieu
                FROM Product p
                LEFT JOIN Category c ON p.CategoryID = c.CategoryID
                LEFT JOIN Brand b ON p.BrandID = b.BrandID
                WHERE p.StockQuantity <= p.MinStockLevel 
                  AND p.IsActive = 1
                ORDER BY p.StockQuantity ASC";
            return Functions.GetDataToTable(sql);
        }

        // ==================== THỐNG KÊ ĐƠN HÀNG THEO TRẠNG THÁI ====================
        public DataTable LayThongKeTrangThai()
        {
            string sql = @"
                SELECT 
                    Status AS TrangThai,
                    COUNT(*) AS SoLuong
                FROM [Order]
                GROUP BY Status";
            return Functions.GetDataToTable(sql);
        }

        // ==================== TỔNG DOANH THU THÁNG NÀY ====================
        public decimal LayDoanhThuThangNay()
        {
            string sql = @"
                SELECT ISNULL(SUM(FinalAmount), 0) 
                FROM [Order] 
                WHERE Status = N'Hoàn thành' 
                  AND MONTH(OrderDate) = MONTH(GETDATE())
                  AND YEAR(OrderDate) = YEAR(GETDATE())";
            string result = Functions.GetFieldValues(sql);
            return string.IsNullOrEmpty(result) ? 0 : decimal.Parse(result);
        }
    }
}
