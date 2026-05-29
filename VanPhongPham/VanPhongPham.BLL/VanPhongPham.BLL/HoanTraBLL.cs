using System;
using System.Data;
using VanPhongPham.DAL;

namespace VanPhongPham.BLL
{
    public class HoanTraBLL
    {
        private HoanTraDAL hoanTraDAL = new HoanTraDAL();

        // ==================== LẤY DANH SÁCH PHIẾU TRẢ ====================
        public DataTable LayDanhSachPhieuTra()
        {
            return hoanTraDAL.LayDanhSach();
        }

        // ==================== LẤY CHI TIẾT PHIẾU TRẢ ====================
        public DataTable LayChiTietPhieuTra(int returnID)
        {
            if (returnID <= 0)
                throw new Exception("Mã phiếu trả không hợp lệ!");
            return hoanTraDAL.LayChiTiet(returnID);
        }

        // ==================== LẤY DANH SÁCH ĐƠN CHO PHÉP TRẢ ====================
        public DataTable LayDonChoPhepTra()
        {
            return hoanTraDAL.LayDonChoPhepTra();
        }

        // ==================== LẤY SẢN PHẨM TRONG ĐƠN ====================
        public DataTable LaySanPhamTrongDon(int orderID)
        {
            return hoanTraDAL.LaySanPhamTrongDon(orderID);
        }

        // ==================== TẠO PHIẾU TRẢ (có validate) ====================
        public bool TaoPhieuTra(string returnCode, int orderID, int userID,
                                string reason, decimal totalRefund, DataTable chiTiet)
        {
            // Validate: mã phiếu trả không được trống
            if (string.IsNullOrWhiteSpace(returnCode))
                throw new Exception("Mã phiếu trả không được để trống!");

            // Validate: phải chọn đơn hàng
            if (orderID <= 0)
                throw new Exception("Vui lòng chọn đơn hàng cần trả!");

            // Validate: phải có lý do
            if (string.IsNullOrWhiteSpace(reason))
                throw new Exception("Vui lòng nhập lý do trả hàng!");

            // Validate: phải có ít nhất 1 sản phẩm trả
            bool coSanPhamTra = false;
            foreach (DataRow row in chiTiet.Rows)
            {
                int soLuongTra = Convert.ToInt32(row["SoLuongTra"]);
                if (soLuongTra > 0)
                {
                    coSanPhamTra = true;

                    // Validate: số lượng trả không vượt quá số lượng còn lại (đã mua - đã trả)
                    int soLuongMua = Convert.ToInt32(row["SoLuongMua"]);
                    int daTraLai = Convert.ToInt32(row["DaTraLai"]);
                    int conLai = soLuongMua - daTraLai;

                    if (soLuongTra > conLai)
                        throw new Exception($"Sản phẩm \"{row["ProductName"]}\": Số lượng trả ({soLuongTra}) vượt quá số lượng còn lại ({conLai})!");
                }
            }

            if (!coSanPhamTra)
                throw new Exception("Vui lòng nhập số lượng trả cho ít nhất 1 sản phẩm!");

            // Validate: tổng tiền hoàn phải > 0
            if (totalRefund <= 0)
                throw new Exception("Tổng tiền hoàn phải lớn hơn 0!");

            // Gọi DAL để tạo phiếu (dùng Transaction)
            return hoanTraDAL.TaoPhieuTra(returnCode, orderID, userID, reason, totalRefund, chiTiet);
        }

        // ==================== TÌM KIẾM ====================
        public DataTable TimKiemPhieuTra(string tuKhoa)
        {
            return hoanTraDAL.TimKiem(tuKhoa);
        }
    }
}
