using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using VanPhongPham.BLL;

namespace VanPhongPham.GUI.Forms
{
    public partial class frmBanHang : Form
    {
        private BanHangBLL bll = new BanHangBLL();
        private DataTable dtGioHang;

        public frmBanHang()
        {
            InitializeComponent();
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            // Tạo bảng giỏ hàng - cột phải khớp BLL: ProductID, TenSP, DonGia, SoLuong
            dtGioHang = new DataTable();
            dtGioHang.Columns.Add("ProductID", typeof(int));
            dtGioHang.Columns.Add("MaSP", typeof(string));
            dtGioHang.Columns.Add("TenSP", typeof(string));
            dtGioHang.Columns.Add("DonViTinh", typeof(string));
            dtGioHang.Columns.Add("DonGia", typeof(decimal));
            dtGioHang.Columns.Add("SoLuong", typeof(int));
            dtGioHang.Columns.Add("ThanhTien", typeof(decimal));
            dgvGioHang.DataSource = dtGioHang;

            LoadSanPham();
            LoadLichSu();
        }

        private void LoadSanPham()
        {
            try
            {
                dgvSanPham.DataSource = bll.LaySanPhamConHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message);
            }
        }

        private void LoadLichSu()
        {
            try
            {
                dgvLichSu.DataSource = bll.LayDonBanHomNay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử: " + ex.Message);
            }
        }

        private void btnTimSP_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimSP.Text.Trim();
                if (string.IsNullOrEmpty(keyword))
                    LoadSanPham();
                else
                    dgvSanPham.DataSource = bll.TimSanPham(keyword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                txtSoLuong.Text = "1";
                ThemVaoGio();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnThemGio_Click(object sender, EventArgs e)
        {
            ThemVaoGio();
        }

        private void ThemVaoGio()
        {
            if (dgvSanPham.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!");
                return;
            }

            int sl;
            if (!int.TryParse(txtSoLuong.Text, out sl) || sl <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!");
                return;
            }

            DataGridViewRow row = dgvSanPham.CurrentRow;
            int productID = Convert.ToInt32(row.Cells["ProductID"].Value);
            string maSP = row.Cells["ProductCode"].Value?.ToString() ?? "";
            string tenSP = row.Cells["ProductName"].Value?.ToString() ?? "";
            string dvt = row.Cells["Unit"].Value?.ToString() ?? "";
            decimal donGia = Convert.ToDecimal(row.Cells["UnitPrice"].Value);

            // Kiểm tra đã có trong giỏ chưa
            foreach (DataRow dr in dtGioHang.Rows)
            {
                if (Convert.ToInt32(dr["ProductID"]) == productID)
                {
                    dr["SoLuong"] = Convert.ToInt32(dr["SoLuong"]) + sl;
                    dr["ThanhTien"] = Convert.ToDecimal(dr["DonGia"]) * Convert.ToInt32(dr["SoLuong"]);
                    TinhTong();
                    return;
                }
            }

            DataRow newRow = dtGioHang.NewRow();
            newRow["ProductID"] = productID;
            newRow["MaSP"] = maSP;
            newRow["TenSP"] = tenSP;
            newRow["DonViTinh"] = dvt;
            newRow["DonGia"] = donGia;
            newRow["SoLuong"] = sl;
            newRow["ThanhTien"] = donGia * sl;
            dtGioHang.Rows.Add(newRow);
            TinhTong();
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
                return;
            }
            dtGioHang.Rows.RemoveAt(dgvGioHang.CurrentRow.Index);
            TinhTong();
        }

        private void dgvGioHang_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                if (dgvGioHang.Columns[e.ColumnIndex].Name == "SoLuong")
                {
                    DataRow dr = dtGioHang.Rows[e.RowIndex];
                    dr["ThanhTien"] = Convert.ToDecimal(dr["DonGia"]) * Convert.ToInt32(dr["SoLuong"]);
                    TinhTong();
                }
            }
            catch { }
        }

        private void TinhTong()
        {
            decimal tongCong = 0;
            foreach (DataRow dr in dtGioHang.Rows)
            {
                tongCong += Convert.ToDecimal(dr["ThanhTien"]);
            }
            txtTongCong.Text = tongCong.ToString("N0");

            decimal giamGia = 0;
            decimal.TryParse(txtGiamGia.Text, out giamGia);
            decimal thanhTien = tongCong - giamGia;
            if (thanhTien < 0) thanhTien = 0;
            txtThanhTien.Text = thanhTien.ToString("N0");
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            TinhTong();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dtGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống!");
                return;
            }

            try
            {
                string tenKH = txtTenKH.Text.Trim();
                if (string.IsNullOrEmpty(tenKH)) tenKH = "Khách lẻ";
                string sdt = txtSDT.Text.Trim();
                decimal giamGia = 0;
                decimal.TryParse(txtGiamGia.Text, out giamGia);

                string orderCode = "DH" + DateTime.Now.ToString("ddMMyyyyHHmmss");
                // userID = 1 mặc định (có thể lấy từ session sau)
                bool result = bll.TaoDonBan(orderCode, tenKH, sdt, 1, giamGia, "", dtGioHang);
                if (result)
                {
                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtGioHang.Clear();
                    TinhTong();
                    LoadSanPham();
                    LoadLichSu();
                    txtTenKH.Clear();
                    txtSDT.Clear();
                    txtGiamGia.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyGio_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn hủy giỏ hàng?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dtGioHang.Clear();
                TinhTong();
                txtTenKH.Clear();
                txtSDT.Clear();
                txtGiamGia.Text = "0";
            }
        }
    }
}
