using System;
using System.Data;
using System.Data.Entity;


namespace VanPhongPham.DAL
{
    public class DanhMucDAL
    {
        public DataTable LayDanhSach()
        {
            string sql = "SELECT CategoryID, CategoryName, Description, ParentID, IsActive FROM Category";
            return Functions.GetDataToTable(sql); // Dùng hàm rút gọn của Functions
        }

        public void Them(string categoryName, string description, string parentID, bool isActive)
        {
            string strParent = string.IsNullOrEmpty(parentID) ? "NULL" : parentID;
            int intActive = isActive ? 1 : 0;
            string sql = $"INSERT INTO Category(CategoryName, Description, ParentID, IsActive) VALUES(N'{categoryName}', N'{description}', {strParent}, {intActive})";
            Functions.RunSql(sql);
        }

        public void Sua(int categoryID, string categoryName, string description, string parentID, bool isActive)
        {
            string strParent = string.IsNullOrEmpty(parentID) ? "NULL" : parentID;
            int intActive = isActive ? 1 : 0;
            string sql = $"UPDATE Category SET CategoryName=N'{categoryName}', Description=N'{description}', ParentID={strParent}, IsActive={intActive} WHERE CategoryID={categoryID}";
            Functions.RunSql(sql);
        }

        public void Xoa(int categoryID)
        {
            string sql = $"DELETE FROM Category WHERE CategoryID={categoryID}";
            Functions.RunSqlDel(sql);
        }

        public DataTable TimKiem(string tuKhoa)
        {
            // Tìm kiếm cả tên danh mục và mô tả
            string sql = $"SELECT CategoryID, CategoryName, Description, ParentID, IsActive FROM Category WHERE CategoryName LIKE N'%{tuKhoa}%' OR Description LIKE N'%{tuKhoa}%'";
            return Functions.GetDataToTable(sql);
        }
    }
}