using System;
using System.Data;
using VanPhongPham.DAL;

namespace VanPhongPham.BLL
{
    public class ThongKeBLL
    {
        private ThongKeDAL thongKeDAL = new ThongKeDAL();

        // ==================== SUMMARY CARDS ====================
        public decimal LayDoanhThuHomNay()
        {
            return thongKeDAL.LayDoanhThuHomNay();
        }

        public int LaySoDonHomNay()
        {
            return thongKeDAL.LaySoDonHomNay();
        }

        public int LaySoSPSapHet()
        {
            return thongKeDAL.LaySoSPSapHet();
        }

        public int LayTongKhachHang()
        {
            return thongKeDAL.LayTongKhachHang();
        }

        public decimal LayDoanhThuThangNay()
        {
            return thongKeDAL.LayDoanhThuThangNay();
        }

        // ==================== BIỂU ĐỒ ====================
        public DataTable LayDoanhThuTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            if (tuNgay > denNgay)
                throw new Exception("Ngày bắt đầu phải nhỏ hơn ngày kết thúc!");
            return thongKeDAL.LayDoanhThuTheoNgay(tuNgay, denNgay);
        }

        public DataTable LayDoanhThuTheoThang(int nam)
        {
            if (nam < 2000 || nam > 2100)
                throw new Exception("Năm không hợp lệ!");
            return thongKeDAL.LayDoanhThuTheoThang(nam);
        }

        public DataTable LayTopBanChay(int top = 10)
        {
            return thongKeDAL.LayTopBanChay(top);
        }

        public DataTable LayTonKhoCanhBao()
        {
            return thongKeDAL.LayTonKhoCanhBao();
        }

        public DataTable LayThongKeTrangThai()
        {
            return thongKeDAL.LayThongKeTrangThai();
        }
    }
}
