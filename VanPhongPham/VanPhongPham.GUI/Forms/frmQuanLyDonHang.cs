using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using VanPhongPham.BLL;

namespace VanPhongPham.GUI.Forms
{
    public partial class frmQuanLyDonHang : Form
    {
        private DonHangBLL donHangBLL = new DonHangBLL();
        private DataTable tblDonHang;

        public frmQuanLyDonHang()
        {
            InitializeComponent();
        }

        // ==================== FORM LOAD ====================
        private void frmQuanLyDonHang_Load(object sender, EventArgs e)
        {
            // Nạp ComboBox trạng thái cho bộ lọc
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[] { "Tất cả", "Chờ xử lý", "Đang giao", "Đã giao", "Hoàn thành", "Hủy" });
            cboTrangThai.SelectedIndex = 0;

            // Nạp ComboBox chuyển trạng thái
            cboChuyenTrangThai.Items.Clear();
            cboChuyenTrangThai.Items.AddRange(new object[] { "Đang giao", "Đã giao", "Hoàn thành" });
            cboChuyenTrangThai.SelectedIndex = 0;

            // Đặt ngày mặc định (30 ngày trước → hôm nay)
            dtpTuNgay.Value = DateTime.Now.AddDays(-30);
            dtpDenNgay.Value = DateTime.Now;

            // Load dữ liệu
            LoadDanhSachDonHang();
        }

        // ==================== LOAD DANH SÁCH ĐƠN HÀNG ====================
        private void LoadDanhSachDonHang()
        {
            tblDonHang = donHangBLL.LayDanhSachDonHang();
            dgvDonHang.DataSource = tblDonHang;

            // Ẩn cột ID
            if (dgvDonHang.Columns.Contains("OrderID"))
                dgvDonHang.Columns["OrderID"].Visible = false;

            // Đặt tên cột tiếng Việt
            if (dgvDonHang.Columns.Contains("OrderCode"))
                dgvDonHang.Columns["OrderCode"].HeaderText = "Mã đơn";
            if (dgvDonHang.Columns.Contains("CustomerName"))
                dgvDonHang.Columns["CustomerName"].HeaderText = "Khách hàng";
            if (dgvDonHang.Columns.Contains("CustomerPhone"))
                dgvDonHang.Columns["CustomerPhone"].HeaderText = "SĐT";
            if (dgvDonHang.Columns.Contains("OrderDate"))
                dgvDonHang.Columns["OrderDate"].HeaderText = "Ngày đặt";
            if (dgvDonHang.Columns.Contains("NhanVien"))
                dgvDonHang.Columns["NhanVien"].HeaderText = "Nhân viên";
            if (dgvDonHang.Columns.Contains("Status"))
                dgvDonHang.Columns["Status"].HeaderText = "Trạng thái";
            if (dgvDonHang.Columns.Contains("TotalAmount"))
                dgvDonHang.Columns["TotalAmount"].HeaderText = "Tổng tiền";
            if (dgvDonHang.Columns.Contains("Discount"))
                dgvDonHang.Columns["Discount"].HeaderText = "Giảm giá";
            if (dgvDonHang.Columns.Contains("FinalAmount"))
                dgvDonHang.Columns["FinalAmount"].HeaderText = "Thành tiền";
            if (dgvDonHang.Columns.Contains("Note"))
                dgvDonHang.Columns["Note"].HeaderText = "Ghi chú";

            // Format tiền
            if (dgvDonHang.Columns.Contains("TotalAmount"))
                dgvDonHang.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";
            if (dgvDonHang.Columns.Contains("Discount"))
                dgvDonHang.Columns["Discount"].DefaultCellStyle.Format = "N0";
            if (dgvDonHang.Columns.Contains("FinalAmount"))
                dgvDonHang.Columns["FinalAmount"].DefaultCellStyle.Format = "N0";

            // Xóa chi tiết cũ
            dgvChiTiet.DataSource = null;
        }

        // ==================== CLICK DÒNG ĐƠN HÀNG ====================
        private void dgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int orderID = Convert.ToInt32(dgvDonHang.Rows[e.RowIndex].Cells["OrderID"].Value);
            LoadChiTietDonHang(orderID);
        }

        // ==================== LOAD CHI TIẾT ĐƠN HÀNG ====================
        private void LoadChiTietDonHang(int orderID)
        {
            DataTable tblChiTiet = donHangBLL.LayChiTietDonHang(orderID);
            dgvChiTiet.DataSource = tblChiTiet;

            // Ẩn cột ID
            if (dgvChiTiet.Columns.Contains("OrderDetailID"))
                dgvChiTiet.Columns["OrderDetailID"].Visible = false;

            // Đặt tên cột
            if (dgvChiTiet.Columns.Contains("ProductCode"))
                dgvChiTiet.Columns["ProductCode"].HeaderText = "Mã SP";
            if (dgvChiTiet.Columns.Contains("ProductName"))
                dgvChiTiet.Columns["ProductName"].HeaderText = "Tên sản phẩm";
            if (dgvChiTiet.Columns.Contains("Quantity"))
                dgvChiTiet.Columns["Quantity"].HeaderText = "Số lượng";
            if (dgvChiTiet.Columns.Contains("UnitPrice"))
            {
                dgvChiTiet.Columns["UnitPrice"].HeaderText = "Đơn giá";
                dgvChiTiet.Columns["UnitPrice"].DefaultCellStyle.Format = "N0";
            }
            if (dgvChiTiet.Columns.Contains("Discount"))
            {
                dgvChiTiet.Columns["Discount"].HeaderText = "Giảm giá";
                dgvChiTiet.Columns["Discount"].DefaultCellStyle.Format = "N0";
            }
            if (dgvChiTiet.Columns.Contains("TotalPrice"))
            {
                dgvChiTiet.Columns["TotalPrice"].HeaderText = "Thành tiền";
                dgvChiTiet.Columns["TotalPrice"].DefaultCellStyle.Format = "N0";
            }
            if (dgvChiTiet.Columns.Contains("Unit"))
                dgvChiTiet.Columns["Unit"].HeaderText = "ĐVT";
        }

        // ==================== TÌM KIẾM ====================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            string trangThai = cboTrangThai.SelectedItem?.ToString() ?? "Tất cả";
            DateTime? tuNgay = dtpTuNgay.Value.Date;
            DateTime? denNgay = dtpDenNgay.Value.Date;

            tblDonHang = donHangBLL.TimKiemDonHang(tuKhoa, trangThai, tuNgay, denNgay);
            dgvDonHang.DataSource = tblDonHang;
            dgvChiTiet.DataSource = null;

            // Ẩn cột ID
            if (dgvDonHang.Columns.Contains("OrderID"))
                dgvDonHang.Columns["OrderID"].Visible = false;
        }

        // ==================== LÀM MỚI ====================
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            cboTrangThai.SelectedIndex = 0;
            dtpTuNgay.Value = DateTime.Now.AddDays(-30);
            dtpDenNgay.Value = DateTime.Now;
            LoadDanhSachDonHang();
        }

        // ==================== CẬP NHẬT TRẠNG THÁI ====================
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần cập nhật!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboChuyenTrangThai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn trạng thái mới!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderID = Convert.ToInt32(dgvDonHang.CurrentRow.Cells["OrderID"].Value);
            string trangThaiMoi = cboChuyenTrangThai.SelectedItem.ToString();
            string trangThaiCu = dgvDonHang.CurrentRow.Cells["Status"].Value.ToString();

            if (MessageBox.Show(
                $"Bạn có muốn chuyển trạng thái đơn hàng từ \"{trangThaiCu}\" sang \"{trangThaiMoi}\"?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    donHangBLL.CapNhatTrangThai(orderID, trangThaiMoi);
                    MessageBox.Show("Cập nhật trạng thái thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachDonHang();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==================== HỦY ĐƠN HÀNG ====================
        private void btnHuyDon_Click(object sender, EventArgs e)
        {
            if (dgvDonHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần hủy!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderID = Convert.ToInt32(dgvDonHang.CurrentRow.Cells["OrderID"].Value);
            string orderCode = dgvDonHang.CurrentRow.Cells["OrderCode"].Value.ToString();

            if (MessageBox.Show(
                $"Bạn có chắc chắn muốn HỦY đơn hàng \"{orderCode}\"?\nThao tác này không thể hoàn tác!",
                "Xác nhận hủy đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    donHangBLL.HuyDon(orderID);
                    MessageBox.Show("Đã hủy đơn hàng thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachDonHang();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
