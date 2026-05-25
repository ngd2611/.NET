using System;
using System.Data;
using VanPhongPham.DAL;

namespace VanPhongPham.BLL
{
    public class SanPhamBLL
    {
        private SanPhamDAL sanPhamDAL = new SanPhamDAL();

        // 1. Lấy danh sách
        public DataTable LayDanhSachSanPham()
        {
            return sanPhamDAL.LayDanhSach();
        }

        // 2. Thêm sản phẩm (Có kiểm tra lỗi)
        public void ThemSanPham(string maSP, string tenSP, string danhMucID, string thuongHieuID, string donVi, string giaNhap, string giaBan, string tonKho, string moTa, bool isActive)
        {
            // Kiểm tra nghiệp vụ (BA) cơ bản: Bắt buộc nhập Mã và Tên
            if (string.IsNullOrWhiteSpace(maSP))
            {
                throw new Exception("Mã sản phẩm không được để trống!");
            }
            if (string.IsNullOrWhiteSpace(tenSP))
            {
                throw new Exception("Tên sản phẩm không được để trống!");
            }

            // Đẩy xuống DAL xử lý
            sanPhamDAL.Them(maSP, tenSP, danhMucID, thuongHieuID, donVi, giaNhap, giaBan, tonKho, moTa, isActive);
        }

        // 3. Sửa sản phẩm
        public void SuaSanPham(string maSP, string tenSP, string danhMucID, string thuongHieuID, string donVi, string giaNhap, string giaBan, string tonKho, string moTa, bool isActive)
        {
            if (string.IsNullOrWhiteSpace(maSP) || string.IsNullOrWhiteSpace(tenSP))
            {
                throw new Exception("Mã và Tên sản phẩm không được để trống!");
            }

            sanPhamDAL.Sua(maSP, tenSP, danhMucID, thuongHieuID, donVi, giaNhap, giaBan, tonKho, moTa, isActive);
        }

        // 4. Xóa sản phẩm
        public void XoaSanPham(string maSP)
        {
            if (string.IsNullOrWhiteSpace(maSP))
            {
                throw new Exception("Lỗi: Không xác định được mã sản phẩm cần xóa!");
            }

            sanPhamDAL.Xoa(maSP);
        }

        public DataTable TimKiemSanPham(string tuKhoa, string danhMucID, string giaMax, string tonKho)
        {
            return sanPhamDAL.TimKiem(tuKhoa, danhMucID, giaMax, tonKho);
        }
    }
}