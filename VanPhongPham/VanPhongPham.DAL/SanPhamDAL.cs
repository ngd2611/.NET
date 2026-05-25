using System;
using System.Data;


namespace VanPhongPham.DAL
{
    public class SanPhamDAL
    {
        // 1. Hàm lấy danh sách
        public DataTable LayDanhSach()
        {
            // Lấy dữ liệu và nối bảng để lấy CategoryName, BrandName luôn
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
                LEFT JOIN Brand b ON p.BrandID = b.BrandID";
            return Functions.GetDataToTable(sql);
        }

        // 2. Hàm Thêm
        public void Them(string maSP, string tenSP, string danhMucID, string thuongHieuID, string donVi, string giaNhap, string giaBan, string tonKho, string moTa, bool isActive)
        {
            // Xử lý nếu người dùng không chọn Danh mục hoặc Thương hiệu thì gán thành NULL trong SQL
            string strDanhMuc = string.IsNullOrEmpty(danhMucID) ? "NULL" : danhMucID;
            string strThuongHieu = string.IsNullOrEmpty(thuongHieuID) ? "NULL" : thuongHieuID;
            int intActive = isActive ? 1 : 0;

            string sql = $@"INSERT INTO Product(ProductCode, ProductName, CategoryID, BrandID, Unit, CostPrice, UnitPrice, StockQuantity, Description, IsActive) 
                            VALUES(N'{maSP}', N'{tenSP}', {strDanhMuc}, {strThuongHieu}, N'{donVi}', {giaNhap}, {giaBan}, {tonKho}, N'{moTa}', {intActive})";
            Functions.RunSql(sql);
        }

        // 3. Hàm Sửa
        public void Sua(string maSP, string tenSP, string danhMucID, string thuongHieuID, string donVi, string giaNhap, string giaBan, string tonKho, string moTa, bool isActive)
        {
            // Tương tự, xử lý NULL cho khóa ngoại
            string strDanhMuc = string.IsNullOrEmpty(danhMucID) ? "NULL" : danhMucID;
            string strThuongHieu = string.IsNullOrEmpty(thuongHieuID) ? "NULL" : thuongHieuID;
            int intActive = isActive ? 1 : 0;

            string sql = $@"UPDATE Product 
                            SET ProductName=N'{tenSP}', CategoryID={strDanhMuc}, BrandID={strThuongHieu}, Unit=N'{donVi}', 
                                CostPrice={giaNhap}, UnitPrice={giaBan}, StockQuantity={tonKho}, Description=N'{moTa}', IsActive={intActive} 
                            WHERE ProductCode=N'{maSP}'";
            Functions.RunSql(sql);
        }

        // 4. Hàm Xóa
        public void Xoa(string maSP)
        {
            string sql = $"DELETE FROM Product WHERE ProductCode=N'{maSP}'";
            Functions.RunSqlDel(sql);
        }

        public DataTable TimKiem(string tuKhoa, string danhMucID, string giaMax, string tonKho)
        {
            // Câu SQL gốc
            string sql = @"SELECT p.ProductCode, p.ProductName, p.Description, c.CategoryName, b.BrandName, 
                   p.Unit, p.CostPrice, p.UnitPrice, p.StockQuantity, p.IsActive, p.CategoryID, p.BrandID
                   FROM Product p 
                   LEFT JOIN Category c ON p.CategoryID = c.CategoryID 
                   LEFT JOIN Brand b ON p.BrandID = b.BrandID WHERE 1=1 ";

            // Xây dựng điều kiện động
            if (!string.IsNullOrEmpty(tuKhoa))
                sql += $" AND (p.ProductCode LIKE N'%{tuKhoa}%' OR p.ProductName LIKE N'%{tuKhoa}%')";
            if (!string.IsNullOrEmpty(danhMucID))
                sql += $" AND c.CategoryName = N'{danhMucID}'";
            if (!string.IsNullOrEmpty(giaMax))
                sql += $" AND p.UnitPrice <= {giaMax}";
            if (!string.IsNullOrEmpty(tonKho))
                sql += $" AND p.StockQuantity <= {tonKho}";

            return Functions.GetDataToTable(sql);
        }
    }
}