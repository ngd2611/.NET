using System;
using System.Data;
using VanPhongPham.DAL;

namespace VanPhongPham.BLL
{
    public class DonHangBLL
    {
        private DonHangDAL donHangDAL = new DonHangDAL();

        // ==================== LẤY DANH SÁCH ĐƠN HÀNG ====================
        public DataTable LayDanhSachDonHang()
        {
            return donHangDAL.LayDanhSach();
        }

        // ==================== LẤY CHI TIẾT ĐƠN HÀNG ====================
        public DataTable LayChiTietDonHang(int orderID)
        {
            if (orderID <= 0)
                throw new Exception("Mã đơn hàng không hợp lệ!");
            return donHangDAL.LayChiTiet(orderID);
        }

        // ==================== CẬP NHẬT TRẠNG THÁI ====================
        // Validate luồng chuyển trạng thái:
        // Chờ xử lý → Đang giao → Đã giao → Hoàn thành
        // Hủy chỉ từ: Chờ xử lý, Đang giao
        public void CapNhatTrangThai(int orderID, string trangThaiMoi)
        {
            string trangThaiHienTai = donHangDAL.LayTrangThai(orderID);

            if (string.IsNullOrEmpty(trangThaiHienTai))
                throw new Exception("Không tìm thấy đơn hàng!");

            if (trangThaiHienTai == "Hủy")
                throw new Exception("Đơn hàng đã bị hủy, không thể cập nhật trạng thái!");

            if (trangThaiHienTai == "Hoàn thành")
                throw new Exception("Đơn hàng đã hoàn thành, không thể thay đổi trạng thái!");

            // Validate luồng hợp lệ
            bool hopLe = false;
            switch (trangThaiHienTai)
            {
                case "Chờ xử lý":
                    hopLe = (trangThaiMoi == "Đang giao" || trangThaiMoi == "Hủy");
                    break;
                case "Đang giao":
                    hopLe = (trangThaiMoi == "Đã giao" || trangThaiMoi == "Hủy");
                    break;
                case "Đã giao":
                    hopLe = (trangThaiMoi == "Hoàn thành");
                    break;
            }

            if (!hopLe)
                throw new Exception($"Không thể chuyển từ \"{trangThaiHienTai}\" sang \"{trangThaiMoi}\"!");

            donHangDAL.CapNhatTrangThai(orderID, trangThaiMoi);
        }

        // ==================== HỦY ĐƠN HÀNG ====================
        public void HuyDon(int orderID)
        {
            string trangThai = donHangDAL.LayTrangThai(orderID);

            if (trangThai == "Hoàn thành")
                throw new Exception("Đơn đã hoàn thành, không thể hủy! Vui lòng sử dụng chức năng Trả hàng.");

            if (trangThai == "Hủy")
                throw new Exception("Đơn hàng đã bị hủy trước đó!");

            if (trangThai != "Chờ xử lý" && trangThai != "Đang giao")
                throw new Exception($"Chỉ có thể hủy đơn ở trạng thái \"Chờ xử lý\" hoặc \"Đang giao\"! Trạng thái hiện tại: \"{trangThai}\"");

            donHangDAL.HuyDon(orderID);
        }

        // ==================== TÌM KIẾM ====================
        public DataTable TimKiemDonHang(string tuKhoa, string trangThai, DateTime? tuNgay, DateTime? denNgay)
        {
            return donHangDAL.TimKiem(tuKhoa, trangThai, tuNgay, denNgay);
        }
    }
}
