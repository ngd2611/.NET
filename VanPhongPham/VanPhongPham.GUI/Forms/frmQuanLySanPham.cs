using System;
using System.Collections.Generic; 
using System.Data;
using System.Windows.Forms;
using VanPhongPham.BLL;
using VanPhongPham.DAL;

namespace VanPhongPham.GUI.Forms
{
    public partial class frmQuanLySanPham : Form
    {
        
        private SanPhamBLL sanPhamBLL = new SanPhamBLL();
        DataTable tblSP;
        private bool isThem = false;

        public frmQuanLySanPham()
        {
            InitializeComponent();
        }

        
        private void frmQuanLySanPham_Load(object sender, EventArgs e)
        {
            DongDieuKhien();
            Load_ComboBoxDanhMuc();
            Load_ComboBoxThuongHieu();
            Load_ComboBoxLocDanhMuc();
            Load_DataGridView();
            cboDanhMuc.SelectedIndex = -1;
            cboThuongHieu.SelectedIndex = -1;

            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;

            // Cứ mỗi khi người dùng gõ hoặc chọn vào 4 ô này, nó tự chạy hàm ThucHienLoc
            txtTimKiem.TextChanged += (s, args) => ThucHienLoc();
            txtLocGia.TextChanged += (s, args) => ThucHienLoc();
            txtLocTonKho.TextChanged += (s, args) => ThucHienLoc();
            cboLocDanhMuc.SelectedIndexChanged += (s, args) => ThucHienLoc();
        }

        private void Load_ComboBoxDanhMuc()
        {
            string sql = "SELECT CategoryID, CategoryName FROM Category WHERE IsActive = 1";
            Functions.FillCombo(sql, cboDanhMuc, "CategoryID", "CategoryName");
        }

        private void Load_ComboBoxThuongHieu()
        {
            string sql = "SELECT BrandID, BrandName FROM Brand WHERE IsActive = 1";
            Functions.FillCombo(sql, cboThuongHieu, "BrandID", "BrandName");
        }

        // HÀM MỚI BỔ SUNG: Nạp riêng cho ô Lọc Danh Mục
        private void Load_ComboBoxLocDanhMuc()
        {
            string sql = "SELECT CategoryID, CategoryName FROM Category WHERE IsActive = 1";
            Functions.FillCombo(sql, cboLocDanhMuc, "CategoryID", "CategoryName");
            cboLocDanhMuc.SelectedIndex = -1; // Mặc định để trống
        }

        private void Load_DataGridView()
        {
            try
            {
                tblSP = sanPhamBLL.LayDanhSachSanPham();
                dgvSanPham.DataSource = tblSP;

                dgvSanPham.Columns["ProductCode"].HeaderText = "Mã SP";
                dgvSanPham.Columns["ProductName"].HeaderText = "Tên sản phẩm";
                dgvSanPham.Columns["Description"].HeaderText = "Mô tả";
                dgvSanPham.Columns["CategoryName"].HeaderText = "Danh mục";
                dgvSanPham.Columns["BrandName"].HeaderText = "Thương hiệu";
                dgvSanPham.Columns["Unit"].HeaderText = "Đơn vị";
                dgvSanPham.Columns["CostPrice"].HeaderText = "Giá nhập";
                dgvSanPham.Columns["UnitPrice"].HeaderText = "Giá bán";
                dgvSanPham.Columns["StockQuantity"].HeaderText = "Tồn kho";
                dgvSanPham.Columns["IsActive"].HeaderText = "Trạng thái";

                dgvSanPham.Columns["CategoryID"].Visible = false;
                dgvSanPham.Columns["BrandID"].Visible = false;

                dgvSanPham.AllowUserToAddRows = false;
                dgvSanPham.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp dữ liệu: " + ex.Message);
            }
        }

        // ------------------ HÀM TIỆN ÍCH TRẠNG THÁI ------------------
        private void DongDieuKhien()
        {
            txtMaSP.Enabled = false; txtTenSP.Enabled = false;
            cboDanhMuc.Enabled = false; cboThuongHieu.Enabled = false;
            txtDonViTinh.Enabled = false; txtGiaNhap.Enabled = false;
            txtGiaBan.Enabled = false; txtMoTa.Enabled = false; cboTrangThai.Enabled = false;
            txtTonKho.Enabled = false;

            btnThemMoi.Enabled = true; btnCapNhat.Enabled = false;
            btnXoaBo.Enabled = false; btnLuu.Enabled = false; btnBoQua.Enabled = false;
        }

        private void MoDieuKhien()
        {
            txtMaSP.Enabled = true; txtTenSP.Enabled = true;
            cboDanhMuc.Enabled = true; cboThuongHieu.Enabled = true;
            txtDonViTinh.Enabled = true; txtGiaNhap.Enabled = true;
            txtGiaBan.Enabled = true; txtMoTa.Enabled = true; cboTrangThai.Enabled = true;
        }

        private void XoaTrangCacO()
        {
            txtMaSP.Text = ""; txtTenSP.Text = ""; txtDonViTinh.Text = "";
            txtGiaNhap.Text = "0"; txtGiaBan.Text = "0"; txtTonKho.Text = "0"; txtMoTa.Text = "";
            cboDanhMuc.SelectedIndex = -1; cboThuongHieu.SelectedIndex = -1;
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;
        }

        // ------------------ SỰ KIỆN CLICK LƯỚI VÀ NÚT BẤM (GIỮ NGUYÊN 100%) ------------------
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvSanPham.Rows.Count == 0) return;

            DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];

            txtMaSP.Text = row.Cells["ProductCode"].Value.ToString();
            txtTenSP.Text = row.Cells["ProductName"].Value.ToString();
            txtDonViTinh.Text = row.Cells["Unit"].Value?.ToString();
            txtGiaBan.Text = row.Cells["UnitPrice"].Value?.ToString();
            txtTonKho.Text = row.Cells["StockQuantity"].Value?.ToString();

            txtGiaNhap.Text = row.Cells["CostPrice"].Value?.ToString();
            txtMoTa.Text = row.Cells["Description"].Value?.ToString();

            if (row.Cells["CategoryID"].Value != DBNull.Value)
                cboDanhMuc.SelectedValue = row.Cells["CategoryID"].Value;
            else
                cboDanhMuc.SelectedIndex = -1;

            if (row.Cells["BrandID"].Value != DBNull.Value)
                cboThuongHieu.SelectedValue = row.Cells["BrandID"].Value;
            else
                cboThuongHieu.SelectedIndex = -1;

            string trangThai = row.Cells["IsActive"].Value.ToString();
            if (trangThai == "True" || trangThai == "1")
                cboTrangThai.Text = "Đang kinh doanh";
            else
                cboTrangThai.Text = "Ngừng kinh doanh";

            btnCapNhat.Enabled = true;
            btnXoaBo.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            isThem = true;
            XoaTrangCacO();
            MoDieuKhien();

            btnThemMoi.Enabled = false; btnCapNhat.Enabled = false; btnXoaBo.Enabled = false;
            btnLuu.Enabled = true; btnBoQua.Enabled = true;
            txtMaSP.Focus();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa trên lưới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            isThem = false;
            MoDieuKhien();
            txtMaSP.Enabled = false;

            btnThemMoi.Enabled = false; btnCapNhat.Enabled = false; btnXoaBo.Enabled = false;
            btnLuu.Enabled = true; btnBoQua.Enabled = true;
            txtTenSP.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text.Trim() == "" || txtTenSP.Text.Trim() == "")
            {
                MessageBox.Show("Mã và Tên sản phẩm không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string danhMucID = cboDanhMuc.SelectedValue?.ToString();
            string thuongHieuID = cboThuongHieu.SelectedValue?.ToString();
            bool trangThai = (cboTrangThai.Text == "Đang kinh doanh");

            string giaNhap = string.IsNullOrEmpty(txtGiaNhap.Text) ? "0" : txtGiaNhap.Text;
            string giaBan = string.IsNullOrEmpty(txtGiaBan.Text) ? "0" : txtGiaBan.Text;
            string tonKho = string.IsNullOrEmpty(txtTonKho.Text) ? "0" : txtTonKho.Text;

            try
            {
                if (isThem)
                {
                    sanPhamBLL.ThemSanPham(txtMaSP.Text.Trim(), txtTenSP.Text.Trim(), danhMucID, thuongHieuID, txtDonViTinh.Text.Trim(), giaNhap, giaBan, tonKho, txtMoTa.Text.Trim(), trangThai);
                    MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    sanPhamBLL.SuaSanPham(txtMaSP.Text.Trim(), txtTenSP.Text.Trim(), danhMucID, thuongHieuID, txtDonViTinh.Text.Trim(), giaNhap, giaBan, tonKho, txtMoTa.Text.Trim(), trangThai);
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Load_DataGridView();
                DongDieuKhien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaBo_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text == "") return;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    sanPhamBLL.XoaSanPham(txtMaSP.Text.Trim());
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    XoaTrangCacO();
                    Load_DataGridView();
                    DongDieuKhien();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            XoaTrangCacO();
            DongDieuKhien();
        }

     
        private void ThucHienLoc()
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            string danhMuc = (cboLocDanhMuc.SelectedIndex > -1) ? cboLocDanhMuc.Text : "";
            string gia = txtLocGia.Text.Trim();
            string ton = txtLocTonKho.Text.Trim();

            DataTable dt = sanPhamBLL.TimKiemSanPham(tuKhoa, danhMuc, gia, ton);
            dgvSanPham.DataSource = dt;
        }

       

        // Bổ sung code cho nút Làm Mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = ""; txtLocGia.Text = ""; txtLocTonKho.Text = ""; cboLocDanhMuc.SelectedIndex = -1;
            Load_DataGridView(); // Load lại toàn bộ từ Database
            txtTimKiem.Focus();
        }

        // Giữ nguyên hàm rỗng này để Form không bị văng lỗi
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}