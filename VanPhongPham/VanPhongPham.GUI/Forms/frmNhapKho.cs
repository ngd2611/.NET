using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using VanPhongPham.BLL;

namespace VanPhongPham.GUI.Forms
{
    public partial class frmNhapKho : Form
    {
        private NhapKhoBLL bll = new NhapKhoBLL();
        private DataTable dtChiTiet;

        public frmNhapKho()
        {
            InitializeComponent();
        }

        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            // Tạo bảng chi tiết nhập - cột khớp BLL: ProductID, TenSP, DonGia, SoLuong
            dtChiTiet = new DataTable();
            dtChiTiet.Columns.Add("ProductID", typeof(int));
            dtChiTiet.Columns.Add("MaSP", typeof(string));
            dtChiTiet.Columns.Add("TenSP", typeof(string));
            dtChiTiet.Columns.Add("DonViTinh", typeof(string));
            dtChiTiet.Columns.Add("SoLuong", typeof(int));
            dtChiTiet.Columns.Add("DonGia", typeof(decimal));
            dtChiTiet.Columns.Add("ThanhTien", typeof(decimal));
            dgvChiTietNhap.DataSource = dtChiTiet;

            TaoMaPhieu();
            LoadNhaCungCap();
            LoadSanPham();
            LoadLichSu();
        }

        private void TaoMaPhieu()
        {
            txtMaPhieu.Text = "PNK" + DateTime.Now.ToString("ddMMyyyyHHmmss");
        }

        private void LoadNhaCungCap()
        {
            try
            {
                DataTable dt = bll.LayDanhSachNCC();
                cboNCC.DataSource = dt;
                cboNCC.DisplayMember = "SupplierName";
                cboNCC.ValueMember = "SupplierID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải NCC: " + ex.Message);
            }
        }

        private void LoadSanPham()
        {
            try
            {
                DataTable dt = bll.LayDanhSachSanPham();
                cboSanPham.DataSource = dt;
                cboSanPham.DisplayMember = "ProductName";
                cboSanPham.ValueMember = "ProductCode";
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
                dgvLichSu.DataSource = bll.LayDanhSachPhieuNhap();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử: " + ex.Message);
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedValue == null)
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

            decimal giaNhap;
            if (!decimal.TryParse(txtGiaNhap.Text, out giaNhap) || giaNhap < 0)
            {
                MessageBox.Show("Giá nhập không hợp lệ!");
                return;
            }

            // Lấy thông tin SP từ ComboBox DataSource
            DataRowView drv = cboSanPham.SelectedItem as DataRowView;
            if (drv == null) return;

            int productID = Convert.ToInt32(drv["ProductID"]);
            string maSP = drv["ProductCode"].ToString();
            string tenSP = drv["ProductName"].ToString();
            string dvt = drv["Unit"]?.ToString() ?? "";

            // Kiểm tra trùng
            foreach (DataRow dr in dtChiTiet.Rows)
            {
                if (Convert.ToInt32(dr["ProductID"]) == productID)
                {
                    MessageBox.Show("Sản phẩm đã có trong danh sách!");
                    return;
                }
            }

            DataRow newRow = dtChiTiet.NewRow();
            newRow["ProductID"] = productID;
            newRow["MaSP"] = maSP;
            newRow["TenSP"] = tenSP;
            newRow["DonViTinh"] = dvt;
            newRow["SoLuong"] = sl;
            newRow["DonGia"] = giaNhap;
            newRow["ThanhTien"] = giaNhap * sl;
            dtChiTiet.Rows.Add(newRow);
            TinhTong();
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (dgvChiTietNhap.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
                return;
            }
            dtChiTiet.Rows.RemoveAt(dgvChiTietNhap.CurrentRow.Index);
            TinhTong();
        }

        private void TinhTong()
        {
            decimal tong = 0;
            foreach (DataRow dr in dtChiTiet.Rows)
            {
                tong += Convert.ToDecimal(dr["ThanhTien"]);
            }
            txtTongTien.Text = tong.ToString("N0");
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (dtChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm nào!");
                return;
            }
            if (cboNCC.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!");
                return;
            }

            try
            {
                string maPhieu = txtMaPhieu.Text;
                int nccID = Convert.ToInt32(cboNCC.SelectedValue);
                string ghiChu = txtGhiChu.Text.Trim();
                // userID = 1 mặc định (có thể lấy từ session sau)
                bool result = bll.TaoPhieuNhap(maPhieu, nccID, 1, ghiChu, dtChiTiet);
                if (result)
                {
                    MessageBox.Show("Lưu phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLamMoi_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dtChiTiet.Clear();
            TaoMaPhieu();
            txtGhiChu.Clear();
            txtSoLuong.Text = "1";
            txtGiaNhap.Text = "0";
            TinhTong();
            LoadLichSu();
        }

        private void btnTimPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimPhieu.Text.Trim();
                if (string.IsNullOrEmpty(keyword))
                    LoadLichSu();
                else
                    dgvLichSu.DataSource = bll.TimKiemPhieuNhap(keyword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }
    }
}
