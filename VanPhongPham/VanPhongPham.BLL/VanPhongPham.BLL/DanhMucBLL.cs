using System;
using System.Data;
using VanPhongPham.DAL;

namespace VanPhongPham.BLL
{
    public class DanhMucBLL
    {
        private DanhMucDAL categoryDAL = new DanhMucDAL();

        // 1. Lấy toàn bộ danh mục
        public DataTable LayDanhSachDanhMuc()
        {
            return categoryDAL.LayDanhSach();
        }

        // ✅ [FIX #9/#11] Cung cấp danh mục active để GUI đổ ComboBox — đúng luồng GUI→BLL→DAL
        public DataTable LayDanhSachDanhMucActive()
        {
            return categoryDAL.LayDanhSachActive();
        }

        // 2. Thêm danh mục
        public void ThemDanhMuc(string categoryName, string description, string parentID, bool isActive)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
                throw new Exception("Tên danh mục không được để trống!");
            categoryDAL.Them(categoryName, description, parentID, isActive);
        }

        // 3. Sửa danh mục — ✅ [FIX #8] Bổ sung validate đầy đủ
        public void SuaDanhMuc(int categoryID, string categoryName, string description, string parentID, bool isActive)
        {
            if (categoryID <= 0)
                throw new Exception("Mã danh mục không hợp lệ!");
            if (string.IsNullOrWhiteSpace(categoryName))
                throw new Exception("Tên danh mục không được để trống!");
            // ✅ [FIX #8] Chặn self-reference: danh mục không thể là cha của chính nó
            if (!string.IsNullOrEmpty(parentID) && parentID == categoryID.ToString())
                throw new Exception("Danh mục không thể là danh mục cha của chính nó!");

            categoryDAL.Sua(categoryID, categoryName, description, parentID, isActive);
        }

        // 4. Xóa danh mục
        public void XoaDanhMuc(int categoryID)
        {
            if (categoryID <= 0)
                throw new Exception("Mã danh mục không hợp lệ!");
            categoryDAL.Xoa(categoryID);
        }

        // 5. Tìm kiếm danh mục
        public DataTable TimKiemDanhMuc(string tuKhoa)
        {
            return categoryDAL.TimKiem(tuKhoa);
        }
    }
}