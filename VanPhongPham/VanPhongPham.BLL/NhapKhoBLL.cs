using System;
using System.Data;
using VanPhongPham.DAL;

namespace VanPhongPham.BLL
{
    public class NhapKhoBLL
    {
        private NhapKhoDAL dal = new NhapKhoDAL();

        public DataTable LayDanhSachNCC() => dal.LayDanhSachNCC();
        public DataTable LayDanhSachSanPham() => dal.LayDanhSachSanPham();
        public DataTable LayDanhSachPhieuNhap() => dal.LayDanhSachPhieuNhap();
        public DataTable LayChiTietPhieuNhap(int purchaseID) => dal.LayChiTietPhieuNhap(purchaseID);
        public DataTable TimKiemPhieuNhap(string tuKhoa) => dal.TimKiemPhieuNhap(tuKhoa);

        // ==================== TẠO PHIẾU NHẬP (có validate) ====================
        public bool TaoPhieuNhap(string purchaseCode, int supplierID, int userID, string note, DataTable chiTiet)
        {
            if (supplierID <= 0)
                throw new Exception("Vui lòng chọn nhà cung cấp!");

            if (chiTiet == null || chiTiet.Rows.Count == 0)
                throw new Exception("Phiếu nhập phải có ít nhất 1 sản phẩm!");

            decimal tongTien = 0;
            foreach (DataRow row in chiTiet.Rows)
            {
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                decimal donGia = Convert.ToDecimal(row["DonGia"]);

                if (soLuong <= 0)
                    throw new Exception($"Số lượng sản phẩm '{row["TenSP"]}' phải > 0!");
                if (donGia <= 0)
                    throw new Exception($"Đơn giá sản phẩm '{row["TenSP"]}' phải > 0!");

                tongTien += soLuong * donGia;
            }

            return dal.TaoPhieuNhap(purchaseCode, supplierID, userID, note, tongTien, chiTiet);
        }
    }
}
