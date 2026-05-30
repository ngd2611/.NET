using System;
using System.Data;
using System.Data.SqlClient;


namespace VanPhongPham.DAL
{
    public class DanhMucDAL
    {
      
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

        public DataTable LayDanhSachActive()
        {
            KiemTraKetNoi();
            return Functions.GetDataToTable(
                "SELECT CategoryID, CategoryName FROM Category WHERE IsActive = 1 ORDER BY CategoryName");
        }

       
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

      
        public void Xoa(int categoryID)
        {
            KiemTraKetNoi();
            Functions.RunSqlDel(
                "DELETE FROM Category WHERE CategoryID = @id",
                new SqlParameter("@id", categoryID)
            );
        }

     
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