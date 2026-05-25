using System;
using System.Data;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using VanPhongPham.BLL;
using VanPhongPham.DAL;

namespace VanPhongPham.GUI.Forms
{
    public partial class frmQuanLyDanhMuc : Form
    {
        private DanhMucBLL categoryBLL = new DanhMucBLL();
        DataTable tblDM; // Đây là "cái kho" dữ liệu chính
        private bool isThem = false;

        public frmQuanLyDanhMuc()
        {
            InitializeComponent();
        }

        private void frmQuanLyDanhMuc_Load(object sender, EventArgs e)
        {
            DongDieuKhien();
            Load_DataGridView();
            Load_ComboBoxCha();
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;
        }

        private void Load_DataGridView()
        {
            try
            {
                tblDM = categoryBLL.LayDanhSachDanhMuc(); // Nạp vào kho tblDM
                dgvDanhMuc.DataSource = tblDM;            // Đẩy kho lên lưới

                dgvDanhMuc.Columns["CategoryID"].HeaderText = "Mã danh mục";
                dgvDanhMuc.Columns["CategoryName"].HeaderText = "Tên danh mục";
                dgvDanhMuc.Columns["Description"].HeaderText = "Mô tả";
                dgvDanhMuc.Columns["ParentID"].HeaderText = "Mã danh mục cha";
                dgvDanhMuc.Columns["IsActive"].HeaderText = "Kích hoạt";

                dgvDanhMuc.AllowUserToAddRows = false;
                dgvDanhMuc.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Load_ComboBoxCha()
        {
            string sql = "SELECT CategoryID, CategoryName FROM Category WHERE IsActive = 1";
            Functions.FillCombo(sql, cboDanhMucCha, "CategoryID", "CategoryName");
        }

        // ================== CÁC NÚT BẤM (GIỮ NGUYÊN) ==================
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            isThem = true; XoaTrangCacO(); MoDieuKhien();
            btnThemMoi.Enabled = false; btnCapNhat.Enabled = false; btnXoaBo.Enabled = false;
            btnLuu.Enabled = true; btnBoQua.Enabled = true;
            txtTenDanhMuc.Focus();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtTenDanhMuc.Text == "") { MessageBox.Show("Vui lòng chọn dòng để sửa!"); return; }
            isThem = false; MoDieuKhien();
            btnThemMoi.Enabled = false; btnCapNhat.Enabled = false; btnXoaBo.Enabled = false;
            btnLuu.Enabled = true; btnBoQua.Enabled = true;
            txtTenDanhMuc.Focus();
            txtTenDanhMuc.SelectionStart = 0;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenDanhMuc.Text.Trim().Length == 0) { MessageBox.Show("Nhập tên danh mục!"); return; }
            bool status = (cboTrangThai.Text == "Đang hoạt động");
            string parentID = cboDanhMucCha.SelectedValue != null ? cboDanhMucCha.SelectedValue.ToString() : "";
            try
            {
                if (isThem) categoryBLL.ThemDanhMuc(txtTenDanhMuc.Text.Trim(), txtMoTa.Text.Trim(), parentID, status);
                else categoryBLL.SuaDanhMuc(Convert.ToInt32(dgvDanhMuc.CurrentRow.Cells["CategoryID"].Value), txtTenDanhMuc.Text.Trim(), txtMoTa.Text.Trim(), parentID, status);

                Load_DataGridView(); Load_ComboBoxCha(); DongDieuKhien();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu: " + ex.Message); }
        }

        private void btnXoaBo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa danh mục?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                categoryBLL.XoaDanhMuc(Convert.ToInt32(dgvDanhMuc.CurrentRow.Cells["CategoryID"].Value));
                Load_DataGridView(); Load_ComboBoxCha(); DongDieuKhien();
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e) { XoaTrangCacO(); DongDieuKhien(); }

        // ================== CÁC HÀM XỬ LÝ GIAO DIỆN ==================
        private void DongDieuKhien() { txtTenDanhMuc.Enabled = false; txtMoTa.Enabled = false; cboDanhMucCha.Enabled = false; cboTrangThai.Enabled = false; btnThemMoi.Enabled = true; btnCapNhat.Enabled = false; btnXoaBo.Enabled = false; btnLuu.Enabled = false; btnBoQua.Enabled = false; }
        private void MoDieuKhien() { txtTenDanhMuc.Enabled = true; txtMoTa.Enabled = true; cboDanhMucCha.Enabled = true; cboTrangThai.Enabled = true; }
        private void XoaTrangCacO() { txtTenDanhMuc.Text = ""; txtMoTa.Text = ""; cboDanhMucCha.SelectedIndex = -1; if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0; }

        private void dgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvDanhMuc.Rows.Count == 0) return;
            DataGridViewRow row = dgvDanhMuc.Rows[e.RowIndex];
            txtTenDanhMuc.Text = row.Cells["CategoryName"].Value.ToString();
            txtMoTa.Text = row.Cells["Description"].Value?.ToString();
            if (row.Cells["ParentID"].Value != DBNull.Value) cboDanhMucCha.SelectedValue = row.Cells["ParentID"].Value;
            else cboDanhMucCha.SelectedIndex = -1;
            cboTrangThai.Text = (row.Cells["IsActive"].Value.ToString() == "True") ? "Đang hoạt động" : "Tạm khóa";
            btnCapNhat.Enabled = true; btnXoaBo.Enabled = true; btnBoQua.Enabled = true;
        }

        // ================== TÌM KIẾM & LÀM MỚI (ĐÃ SỬA CHUẨN) ==================
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            // Gọi qua BLL để lấy dữ liệu từ SQL về
            tblDM = categoryBLL.TimKiemDanhMuc(tuKhoa);

            // Đổ dữ liệu mới vào lưới
            dgvDanhMuc.DataSource = tblDM;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            if (tblDM != null) tblDM.DefaultView.RowFilter = ""; // Reset trên tblDM
            txtTimKiem.Focus();
        }
        private void label1_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void dgvDanhMuc_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvDanhMuc_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }
    }
}