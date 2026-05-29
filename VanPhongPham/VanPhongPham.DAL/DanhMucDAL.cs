using System;
using System.Data;
using System.Data.SqlClient;
// ✅ [FIX #5] Đã xóa: using System.Data.Entity — không dùng Entity Framework ở đây

namespace VanPhongPham.DAL
{
    public class DanhMucDAL
    {
        // ✅ [FIX #12] Đảm bảo kết nối luôn mở trước mọi thao tác
        private void KiemTraKetNoi()
        {
            if (Functions.Conn == null || Functions.Conn.State != ConnectionState.Open)
                Functions.Connect();
        }

        // 1. Lấy toàn bộ danh mục
        public DataTable LayDanhSach()
        {
            KiemTraKetNoi();
            return Functions.GetDataToTable(
                "SELECT CategoryID, CategoryName, Description, ParentID, IsActive FROM Category");
        }

        // ✅ [FIX #9/#11] Lấy danh mục đang active — để BLL đổ ComboBox đúng luồng
        public DataTable LayDanhSachActive()
        {
            KiemTraKetNoi();
            return Functions.GetDataToTable(
                "SELECT CategoryID, CategoryName FROM Category WHERE IsActive = 1 ORDER BY CategoryName");
        }

        // 2. Thêm danh mục — ✅ [FIX #7] Dùng SqlParameter chống SQL Injection
        public void Them(string categoryName, string description, string parentID, bool isActive)
        {
            KiemTraKetNoi();
            string sql = @"
                INSERT INTO Category (CategoryName, Description, ParentID, IsActive)
                VALUES (@name, @desc, @parent, @active)";

            Functions.RunSql(sql,
                new SqlParameter("@name",   categoryName),
                new SqlParameter("@desc",   description ?? ""),
                new SqlParameter("@parent", string.IsNullOrEmpty(parentID) ? (object)DBNull.Value : int.Parse(parentID)),
                new SqlParameter("@active", isActive ? 1 : 0)
            );
        }

        // 3. Sửa danh mục — ✅ [FIX #7] Dùng SqlParameter chống SQL Injection
        public void Sua(int categoryID, string categoryName, string description, string parentID, bool isActive)
        {
            KiemTraKetNoi();
            string sql = @"
                UPDATE Category 
                SET CategoryName = @name,
                    Description  = @desc,
                    ParentID     = @parent,
                    IsActive     = @active
                WHERE CategoryID = @id";

            Functions.RunSql(sql,
                new SqlParameter("@name",   categoryName),
                new SqlParameter("@desc",   description ?? ""),
                new SqlParameter("@parent", string.IsNullOrEmpty(parentID) ? (object)DBNull.Value : int.Parse(parentID)),
                new SqlParameter("@active", isActive ? 1 : 0),
                new SqlParameter("@id",     categoryID)
            );
        }

        // 4. Xóa danh mục — ✅ [FIX #7] Dùng SqlParameter
        public void Xoa(int categoryID)
        {
            KiemTraKetNoi();
            Functions.RunSqlDel(
                "DELETE FROM Category WHERE CategoryID = @id",
                new SqlParameter("@id", categoryID)
            );
        }

        // 5. Tìm kiếm — ✅ [FIX #7] Dùng SqlParameter chống SQL Injection
        public DataTable TimKiem(string tuKhoa)
        {
            KiemTraKetNoi();
            string sql = @"
                SELECT CategoryID, CategoryName, Description, ParentID, IsActive 
                FROM Category 
                WHERE CategoryName LIKE @tuKhoa OR Description LIKE @tuKhoa";
            return Functions.GetDataToTable(sql,
                new SqlParameter("@tuKhoa", "%" + tuKhoa + "%"));
        }
    }
}