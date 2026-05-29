using System;
using System.Data;
using System.Windows.Forms;
using VanPhongPham.BLL;

namespace VanPhongPham.GUI.Forms
{
    public partial class frmQuanLyDonHang : Form
    {
        private DonHangBLL donHangBLL;

        public frmQuanLyDonHang()
        {
            InitializeComponent();

            /* STREAMING_CHUNK:Khởi tạo sự kiện né lỗi designer */
            // Tự gán các sự kiện click nút để né lỗi Designer
            btnTimKiem.Click += BtnTimKiem_Click;
            btnLamMoi.Click += BtnLamMoi_Click;
            btnCapNhat.Click += BtnCapNhat_Click;
            btnHuyDon.Click += BtnHuyDon_Click;
            dgvDonHang.CellClick += DgvDonHang_CellClick;
        }

        private void frmQuanLyDonHang_Load(object sender, EventArgs e)
        {
            /* STREAMING_CHUNK:Load dữ liệu và thiết lập bộ lọc mặc định */
            if (this.DesignMode) return;

            donHangBLL = new DonHangBLL();
            cboTrangThai.SelectedIndex = 0; // Tất cả
            dtpTuNgay.Value = DateTime.Now.AddDays(-30); // Xem đơn 1 tháng qua
            LoadDanhSachDonHang();
        }

        private void LoadDanhSachDonHang()
        {
            try
            {
                dgvDonHang.DataSource = donHangBLL.LayDanhSachDonHang();

                /* STREAMING_CHUNK:Việt hóa và định dạng bảng Đơn hàng */
                // BẮT ĐẦU VIỆT HÓA TIÊU ĐỀ CỘT CHO BẢNG ĐƠN HÀNG
                if (dgvDonHang.Columns.Count > 0)
                {
                    // 1. Ẩn cột khóa chính cho gọn bảng
                    if (dgvDonHang.Columns.Contains("OrderID")) dgvDonHang.Columns["OrderID"].Visible = false;

                    // 2. Đổi tên các cột hiển thị sang tiếng Việt
                    if (dgvDonHang.Columns.Contains("OrderCode")) dgvDonHang.Columns["OrderCode"].HeaderText = "Mã Đơn";
                    if (dgvDonHang.Columns.Contains("CustomerName")) dgvDonHang.Columns["CustomerName"].HeaderText = "Tên Khách Hàng";
                    if (dgvDonHang.Columns.Contains("CustomerPhone")) dgvDonHang.Columns["CustomerPhone"].HeaderText = "SĐT Khách";
                    if (dgvDonHang.Columns.Contains("OrderDate")) dgvDonHang.Columns["OrderDate"].HeaderText = "Ngày Đặt";
                    if (dgvDonHang.Columns.Contains("NhanVien")) dgvDonHang.Columns["NhanVien"].HeaderText = "Nhân Viên Chốt Đơn";
                    if (dgvDonHang.Columns.Contains("Status")) dgvDonHang.Columns["Status"].HeaderText = "Trạng Thái";
                    if (dgvDonHang.Columns.Contains("TotalAmount")) dgvDonHang.Columns["TotalAmount"].HeaderText = "Tổng Tiền Hàng";
                    if (dgvDonHang.Columns.Contains("Discount")) dgvDonHang.Columns["Discount"].HeaderText = "Chiết Khấu";
                    if (dgvDonHang.Columns.Contains("FinalAmount")) dgvDonHang.Columns["FinalAmount"].HeaderText = "Thực Thu";
                    if (dgvDonHang.Columns.Contains("Note")) dgvDonHang.Columns["Note"].HeaderText = "Ghi Chú";

                    // 3. Format tiền tệ và ngày tháng
                    if (dgvDonHang.Columns.Contains("TotalAmount")) dgvDonHang.Columns["TotalAmount"].DefaultCellStyle.Format = "#,##0 đ";
                    if (dgvDonHang.Columns.Contains("Discount")) dgvDonHang.Columns["Discount"].DefaultCellStyle.Format = "#,##0 đ";
                    if (dgvDonHang.Columns.Contains("FinalAmount")) dgvDonHang.Columns["FinalAmount"].DefaultCellStyle.Format = "#,##0 đ";
                    if (dgvDonHang.Columns.Contains("OrderDate")) dgvDonHang.Columns["OrderDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message);
            }
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            /* STREAMING_CHUNK:Thực hiện lọc tìm kiếm */
            string tuKhoa = txtTimKiem.Text.Trim();
            string trangThai = cboTrangThai.SelectedItem?.ToString();
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            dgvDonHang.DataSource = donHangBLL.TimKiemDonHang(tuKhoa, trangThai, tuNgay, denNgay);
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            /* STREAMING_CHUNK:Reset form và load lại lưới */
            txtTimKiem.Clear();
            cboTrangThai.SelectedIndex = 0;
            dtpTuNgay.Value = DateTime.Now.AddDays(-30);
            dtpDenNgay.Value = DateTime.Now;
            LoadDanhSachDonHang();
            dgvChiTiet.DataSource = null;
        }

        private void DgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int orderID = Convert.ToInt32(dgvDonHang.Rows[e.RowIndex].Cells["OrderID"].Value);
                try
                {
                    dgvChiTiet.DataSource = donHangBLL.LayChiTietDonHang(orderID);

                    /* STREAMING_CHUNK:Việt hóa bảng Chi tiết đơn hàng */
                    // BẮT ĐẦU VIỆT HÓA BẢNG CHI TIẾT
                    if (dgvChiTiet.Columns.Count > 0)
                    {
                        // 1. Ẩn cột khóa chính 
                        if (dgvChiTiet.Columns.Contains("OrderDetailID")) dgvChiTiet.Columns["OrderDetailID"].Visible = false;

                        // 2. Đổi tên cột hiển thị
                        if (dgvChiTiet.Columns.Contains("ProductCode")) dgvChiTiet.Columns["ProductCode"].HeaderText = "Mã SP";
                        if (dgvChiTiet.Columns.Contains("ProductName")) dgvChiTiet.Columns["ProductName"].HeaderText = "Tên Sản Phẩm";
                        if (dgvChiTiet.Columns.Contains("Quantity")) dgvChiTiet.Columns["Quantity"].HeaderText = "Số Lượng";
                        if (dgvChiTiet.Columns.Contains("UnitPrice")) dgvChiTiet.Columns["UnitPrice"].HeaderText = "Đơn Giá";
                        if (dgvChiTiet.Columns.Contains("Discount")) dgvChiTiet.Columns["Discount"].HeaderText = "Giảm Giá (SP)";
                        if (dgvChiTiet.Columns.Contains("TotalPrice")) dgvChiTiet.Columns["TotalPrice"].HeaderText = "Thành Tiền";
                        if (dgvChiTiet.Columns.Contains("Unit")) dgvChiTiet.Columns["Unit"].HeaderText = "ĐVT";

                        // 3. Format tiền tệ
                        if (dgvChiTiet.Columns.Contains("UnitPrice")) dgvChiTiet.Columns["UnitPrice"].DefaultCellStyle.Format = "#,##0 đ";
                        if (dgvChiTiet.Columns.Contains("Discount")) dgvChiTiet.Columns["Discount"].DefaultCellStyle.Format = "#,##0 đ";
                        if (dgvChiTiet.Columns.Contains("TotalPrice")) dgvChiTiet.Columns["TotalPrice"].DefaultCellStyle.Format = "#,##0 đ";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            /* STREAMING_CHUNK:Thực hiện chức năng cập nhật trạng thái đơn */
            if (dgvDonHang.CurrentRow == null) return;

            int orderID = Convert.ToInt32(dgvDonHang.CurrentRow.Cells["OrderID"].Value);
            string trangThaiMoi = cboChuyenTrangThai.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(trangThaiMoi))
            {
                MessageBox.Show("Vui lòng chọn trạng thái mới cần chuyển!", "Thông báo");
                return;
            }

            try
            {
                donHangBLL.CapNhatTrangThai(orderID, trangThaiMoi);
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
                BtnTimKiem_Click(null, null); // Refresh bảng
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Nghiệp Vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnHuyDon_Click(object sender, EventArgs e)
        {
            /* STREAMING_CHUNK:Thực hiện luồng hủy đơn hàng và hoàn kho */
            if (dgvDonHang.CurrentRow == null) return;

            int orderID = Convert.ToInt32(dgvDonHang.CurrentRow.Cells["OrderID"].Value);

            if (MessageBox.Show("Bạn có chắc chắn muốn hủy đơn hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    donHangBLL.HuyDon(orderID);
                    MessageBox.Show("Đã hủy đơn và hoàn lại kho thành công!", "Thông báo");
                    BtnTimKiem_Click(null, null); // Refresh bảng
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi Nghiệp Vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}