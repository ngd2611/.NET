using System;
using System.Data;
using VanPhongPham.DAL;

namespace VanPhongPham.BLL
{
    public class BanHangBLL
    {
        private BanHangDAL dal = new BanHangDAL();

        public DataTable LaySanPhamConHang() => dal.LaySanPhamConHang();
        public DataTable TimSanPham(string tuKhoa) => dal.TimSanPham(tuKhoa);
        public DataTable LayDonBanHomNay() => dal.LayDonBanHomNay();

        // ==================== TẠO ĐƠN BÁN (có validate) ====================
        public bool TaoDonBan(string orderCode, string customerName, string customerPhone,
                              int userID, decimal discount, string note, DataTable gioHang)
        {
            if (gioHang == null || gioHang.Rows.Count == 0)
                throw new Exception("Giỏ hàng trống! Vui lòng thêm sản phẩm.");

            decimal tongTien = 0;
            foreach (DataRow row in gioHang.Rows)
            {
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                decimal donGia = Convert.ToDecimal(row["DonGia"]);
                int productID = Convert.ToInt32(row["ProductID"]);

                if (soLuong <= 0)
                    throw new Exception($"Số lượng '{row["TenSP"]}' phải > 0!");

                // Kiểm tra tồn kho
                int tonKho = dal.LayTonKho(productID);
                if (soLuong > tonKho)
                    throw new Exception($"'{row["TenSP"]}' chỉ còn {tonKho} trong kho, không đủ {soLuong}!");

                tongTien += soLuong * donGia;
            }

            if (discount < 0) discount = 0;
            decimal thanhTien = tongTien - discount;
            if (thanhTien < 0) thanhTien = 0;

            return dal.TaoDonBan(orderCode, customerName, customerPhone, userID,
                                 tongTien, discount, thanhTien, note, gioHang);
        }
    }
}
