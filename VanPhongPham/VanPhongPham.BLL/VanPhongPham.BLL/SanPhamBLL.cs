using System;
using System.Data;
using VanPhongPham.DAL;

namespace VanPhongPham.BLL
{
    public class SanPhamBLL
    {
        private SanPhamDAL sanPhamDAL = new SanPhamDAL();

        // 1. Lấy danh sách sản phẩm
        public DataTable LayDanhSachSanPham()
        {
            return sanPhamDAL.LayDanhSach();
        }

        // ✅ [FIX #10] Cung cấp danh mục active để GUI đổ ComboBox — đúng luồng GUI→BLL→DAL
        public DataTable LayDanhSachDanhMucActive()
        {
            return sanPhamDAL.LayDanhSachDanhMucActive();
        }

        // ✅ [FIX #10] Cung cấp thương hiệu active để GUI đổ ComboBox — đúng luồng GUI→BLL→DAL
        public DataTable LayDanhSachThuongHieuActive()
        {
            return sanPhamDAL.LayDanhSachThuongHieuActive();
        }

        // 2. Thêm sản phẩm — ✅ [FIX #13] Validate đầy đủ kiểu dữ liệu số
        public void ThemSanPham(string maSP, string tenSP, string danhMucID, string thuongHieuID,
                                 string donVi, string giaNhap, string giaBan, string tonKho,
                                 string moTa, bool isActive)
        {
            if (string.IsNullOrWhiteSpace(maSP))
                throw new Exception("Mã sản phẩm không được để trống!");
            if (string.IsNullOrWhiteSpace(tenSP))
                throw new Exception("Tên sản phẩm không được để trống!");
            // ✅ [FIX #13] Kiểm tra kiểu dữ liệu số trước khi đẩy xuống DAL
            if (!decimal.TryParse(giaNhap, out decimal gn) || gn < 0)
                throw new Exception("Giá nhập phải là số không âm hợp lệ!");
            if (!decimal.TryParse(giaBan, out decimal gb) || gb < 0)
                throw new Exception("Giá bán phải là số không âm hợp lệ!");
            if (!int.TryParse(tonKho, out int tk) || tk < 0)
                throw new Exception("Tồn kho phải là số nguyên không âm!");

            sanPhamDAL.Them(maSP, tenSP, danhMucID, thuongHieuID, donVi, giaNhap, giaBan, tonKho, moTa, isActive);
        }

        // 3. Sửa sản phẩm — ✅ [FIX #13] Validate đầy đủ kiểu dữ liệu số
        public void SuaSanPham(string maSP, string tenSP, string danhMucID, string thuongHieuID,
                                string donVi, string giaNhap, string giaBan, string tonKho,
                                string moTa, bool isActive)
        {
            if (string.IsNullOrWhiteSpace(maSP) || string.IsNullOrWhiteSpace(tenSP))
                throw new Exception("Mã và Tên sản phẩm không được để trống!");
            // ✅ [FIX #13] Kiểm tra kiểu dữ liệu số trước khi đẩy xuống DAL
            if (!decimal.TryParse(giaNhap, out decimal gn) || gn < 0)
                throw new Exception("Giá nhập phải là số không âm hợp lệ!");
            if (!decimal.TryParse(giaBan, out decimal gb) || gb < 0)
                throw new Exception("Giá bán phải là số không âm hợp lệ!");
            if (!int.TryParse(tonKho, out int tk) || tk < 0)
                throw new Exception("Tồn kho phải là số nguyên không âm!");

            sanPhamDAL.Sua(maSP, tenSP, danhMucID, thuongHieuID, donVi, giaNhap, giaBan, tonKho, moTa, isActive);
        }

        // 4. Xóa sản phẩm
        public void XoaSanPham(string maSP)
        {
            if (string.IsNullOrWhiteSpace(maSP))
                throw new Exception("Lỗi: Không xác định được mã sản phẩm cần xóa!");
            sanPhamDAL.Xoa(maSP);
        }

        // 5. Tìm kiếm sản phẩm
        public DataTable TimKiemSanPham(string tuKhoa, string danhMucID, string giaMax, string tonKho)
        {
            return sanPhamDAL.TimKiem(tuKhoa, danhMucID, giaMax, tonKho);
        }
    }
}