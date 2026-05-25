using System;
using System.Data;
using VanPhongPham.DAL;

namespace VanPhongPham.BLL
{
    public class DanhMucBLL
    {
        private DanhMucDAL categoryDAL = new DanhMucDAL();

        public DataTable LayDanhSachDanhMuc()
        {
            return categoryDAL.LayDanhSach();
        }

        public void ThemDanhMuc(string categoryName, string description, string parentID, bool isActive)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                throw new Exception("Tên danh mục không được để trống!");
            }
            categoryDAL.Them(categoryName, description, parentID, isActive);
        }

        public void SuaDanhMuc(int categoryID, string categoryName, string description, string parentID, bool isActive)
        {
            categoryDAL.Sua(categoryID, categoryName, description, parentID, isActive);
        }

        public void XoaDanhMuc(int categoryID)
        {
            categoryDAL.Xoa(categoryID);
        }

        public DataTable TimKiemDanhMuc(string tuKhoa)
        {
            return categoryDAL.TimKiem(tuKhoa);
        }
    }
}