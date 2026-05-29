using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace VanPhongPham.DAL
{
    public class SanPhamDAL
    {
        // ✅ [FIX #12] Đảm bảo kết nối luôn mở trước mọi thao tác
        private void KiemTraKetNoi()
        {
            if (Functions.Conn == null || Functions.Conn.State != ConnectionState.Open)
                Functions.Connect();
        }

        // ==================== LẤY DANH SÁCH ====================

        // 1. Lấy danh sách sản phẩm đầy đủ (kết hợp Category và Brand)
        public DataTable LayDanhSach()
        {
            KiemTraKetNoi();
            string sql = @"
                SELECT 
                    p.ProductCode, 
                    p.ProductName, 
                    p.Description,    
                    c.CategoryName,    
                    b.BrandName,       
                    p.Unit,            
                    p.CostPrice,       
                    p.UnitPrice,       
                    p.StockQuantity,   
                    p.IsActive,        
                    p.CategoryID, 
                    p.BrandID
                FROM Product p
                LEFT JOIN Category c ON p.CategoryID = c.CategoryID
                LEFT JOIN Brand b    ON p.BrandID    = b.BrandID";
            return Functions.GetDataToTable(sql);
        }

        // ✅ [FIX #3/#10] Lấy danh mục đang active — để GUI/BLL đổ ComboBox đúng luồng
        public DataTable LayDanhSachDanhMucActive()
        {
            KiemTraKetNoi();
            return Functions.GetDataToTable(
                "SELECT CategoryID, CategoryName FROM Category WHERE IsActive = 1 ORDER BY CategoryName");
        }

        // ✅ [FIX #3/#10] Lấy thương hiệu đang active — để GUI/BLL đổ ComboBox đúng luồng
        public DataTable LayDanhSachThuongHieuActive()
        {
            KiemTraKetNoi();
            return Functions.GetDataToTable(
                "SELECT BrandID, BrandName FROM Brand WHERE IsActive = 1 ORDER BY BrandName");
        }

        // ==================== THÊM ====================

        // 2. Thêm sản phẩm — ✅ [FIX #7] Dùng SqlParameter chống SQL Injection
        public void Them(string maSP, string tenSP, string danhMucID, string thuongHieuID,
                         string donVi, string giaNhap, string giaBan, string tonKho,
                         string moTa, bool isActive)
        {
            KiemTraKetNoi();
            string sql = @"
                INSERT INTO Product
                    (ProductCode, ProductName, CategoryID, BrandID, Unit,
                     CostPrice, UnitPrice, StockQuantity, Description, IsActive) 
                VALUES
                    (@maSP, @tenSP, @danhMuc, @thuongHieu, @donVi,
                     @giaNhap, @giaBan, @tonKho, @moTa, @isActive)";

            Functions.RunSql(sql,
                new SqlParameter("@maSP",       maSP),
                new SqlParameter("@tenSP",      tenSP),
                new SqlParameter("@danhMuc",    string.IsNullOrEmpty(danhMucID)    ? (object)DBNull.Value : int.Parse(danhMucID)),
                new SqlParameter("@thuongHieu", string.IsNullOrEmpty(thuongHieuID) ? (object)DBNull.Value : int.Parse(thuongHieuID)),
                new SqlParameter("@donVi",      donVi),
                new SqlParameter("@giaNhap",    decimal.Parse(giaNhap)),
                new SqlParameter("@giaBan",     decimal.Parse(giaBan)),
                new SqlParameter("@tonKho",     int.Parse(tonKho)),
                new SqlParameter("@moTa",       moTa),
                new SqlParameter("@isActive",   isActive ? 1 : 0)
            );
        }

        // ==================== SỬA ====================

        // 3. Sửa sản phẩm — ✅ [FIX #7] Dùng SqlParameter chống SQL Injection
        public void Sua(string maSP, string tenSP, string danhMucID, string thuongHieuID,
                        string donVi, string giaNhap, string giaBan, string tonKho,
                        string moTa, bool isActive)
        {
            KiemTraKetNoi();
            string sql = @"
                UPDATE Product 
                SET ProductName    = @tenSP,
                    CategoryID     = @danhMuc,
                    BrandID        = @thuongHieu,
                    Unit           = @donVi,
                    CostPrice      = @giaNhap,
                    UnitPrice      = @giaBan,
                    StockQuantity  = @tonKho,
                    Description    = @moTa,
                    IsActive       = @isActive
                WHERE ProductCode  = @maSP";

            Functions.RunSql(sql,
                new SqlParameter("@tenSP",      tenSP),
                new SqlParameter("@danhMuc",    string.IsNullOrEmpty(danhMucID)    ? (object)DBNull.Value : int.Parse(danhMucID)),
                new SqlParameter("@thuongHieu", string.IsNullOrEmpty(thuongHieuID) ? (object)DBNull.Value : int.Parse(thuongHieuID)),
                new SqlParameter("@donVi",      donVi),
                new SqlParameter("@giaNhap",    decimal.Parse(giaNhap)),
                new SqlParameter("@giaBan",     decimal.Parse(giaBan)),
                new SqlParameter("@tonKho",     int.Parse(tonKho)),
                new SqlParameter("@moTa",       moTa),
                new SqlParameter("@isActive",   isActive ? 1 : 0),
                new SqlParameter("@maSP",       maSP)
            );
        }

        // ==================== XÓA ====================

        // 4. Xóa sản phẩm — ✅ [FIX #7] Dùng SqlParameter
        public void Xoa(string maSP)
        {
            KiemTraKetNoi();
            Functions.RunSqlDel(
                "DELETE FROM Product WHERE ProductCode = @maSP",
                new SqlParameter("@maSP", maSP)
            );
        }

        // ==================== TÌM KIẾM ====================

        // 5. Tìm kiếm đa điều kiện — ✅ [FIX #7] Dùng SqlParameter chống SQL Injection
        public DataTable TimKiem(string tuKhoa, string tenDanhMuc, string giaMax, string tonKho)
        {
            KiemTraKetNoi();
            string sql = @"
                SELECT p.ProductCode, p.ProductName, p.Description, 
                       c.CategoryName, b.BrandName, 
                       p.Unit, p.CostPrice, p.UnitPrice, p.StockQuantity, p.IsActive,
                       p.CategoryID, p.BrandID
                FROM Product p 
                LEFT JOIN Category c ON p.CategoryID = c.CategoryID 
                LEFT JOIN Brand b    ON p.BrandID    = b.BrandID 
                WHERE 1=1";

            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                sql += " AND (p.ProductCode LIKE @tuKhoa OR p.ProductName LIKE @tuKhoa)";
                parameters.Add(new SqlParameter("@tuKhoa", "%" + tuKhoa + "%"));
            }
            if (!string.IsNullOrEmpty(tenDanhMuc))
            {
                sql += " AND c.CategoryName = @tenDanhMuc";
                parameters.Add(new SqlParameter("@tenDanhMuc", tenDanhMuc));
            }
            if (!string.IsNullOrEmpty(giaMax) && decimal.TryParse(giaMax, out decimal gMax))
            {
                sql += " AND p.UnitPrice <= @giaMax";
                parameters.Add(new SqlParameter("@giaMax", gMax));
            }
            if (!string.IsNullOrEmpty(tonKho) && int.TryParse(tonKho, out int tk))
            {
                sql += " AND p.StockQuantity <= @tonKho";
                parameters.Add(new SqlParameter("@tonKho", tk));
            }

            return Functions.GetDataToTable(sql, parameters.ToArray());
        }
    }
}