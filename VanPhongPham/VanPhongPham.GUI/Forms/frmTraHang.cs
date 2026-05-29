using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using VanPhongPham.BLL;
using VanPhongPham.DAL;

namespace VanPhongPham.GUI.Forms
{
    public partial class frmTraHang : Form
    {
        private HoanTraBLL hoanTraBLL = new HoanTraBLL();
        private DataTable tblSanPham; // Sản phẩm trong đơn hàng gốc

        public frmTraHang()
        {
            InitializeComponent();
        }

        // ==================== FORM LOAD ====================
        private void frmTraHang_Load(object sender, EventArgs e)
        {
            LoadDonHangChoPhepTra();
            LoadDanhSachPhieuTra();
        }

        // ==================== LOAD COMBOBOX ĐƠN HÀNG ====================
        private void LoadDonHangChoPhepTra()
        {
            DataTable dtDon = hoanTraBLL.LayDonChoPhepTra();
            cboDonHang.DataSource = dtDon;
            cboDonHang.DisplayMember = "HienThi";
            cboDonHang.ValueMember = "OrderID";
            cboDonHang.SelectedIndex = -1;

            // Reset thông tin
            lblKhachHang.Text = "Khách hàng: ---";
            lblNgayDat.Text = "Ngày đặt: ---";
            lblTongTien.Text = "Tổng tiền: ---";
        }

        // ==================== CHỌN ĐƠN HÀNG ====================
        private void cboDonHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDonHang.SelectedIndex < 0 || cboDonHang.SelectedValue == null)
            {
                dgvSanPham.DataSource = null;
                return;
            }

            int orderID;
            if (!int.TryParse(cboDonHang.SelectedValue.ToString(), out orderID))
                return;

            // Hiển thị thông tin đơn hàng
            DataRowView drv = cboDonHang.SelectedItem as DataRowView;
            if (drv != null)
            {
                lblKhachHang.Text = "Khách hàng: " + drv["CustomerName"].ToString();
                lblNgayDat.Text = "Ngày đặt: " + Convert.ToDateTime(drv["OrderDate"]).ToString("dd/MM/yyyy");
                lblTongTien.Text = "Tổng tiền: " + Convert.ToDecimal(drv["FinalAmount"]).ToString("N0") + " đ";
            }

            // Load sản phẩm trong đơn
            tblSanPham = hoanTraBLL.LaySanPhamTrongDon(orderID);

            // Thêm cột SoLuongTra và TienHoan nếu chưa có
            if (!tblSanPham.Columns.Contains("SoLuongTra"))
                tblSanPham.Columns.Add("SoLuongTra", typeof(int));
            if (!tblSanPham.Columns.Contains("TienHoan"))
                tblSanPham.Columns.Add("TienHoan", typeof(decimal));
            if (!tblSanPham.Columns.Contains("ConLai"))
                tblSanPham.Columns.Add("ConLai", typeof(int));

            // Tính số lượng còn lại cho phép trả
            foreach (DataRow row in tblSanPham.Rows)
            {
                int soLuongMua = Convert.ToInt32(row["SoLuongMua"]);
                int daTraLai = Convert.ToInt32(row["DaTraLai"]);
                row["ConLai"] = soLuongMua - daTraLai;
                row["SoLuongTra"] = 0;
                row["TienHoan"] = 0;
            }

            dgvSanPham.DataSource = tblSanPham;

            // Cấu hình cột
            if (dgvSanPham.Columns.Contains("OrderDetailID"))
                dgvSanPham.Columns["OrderDetailID"].Visible = false;
            if (dgvSanPham.Columns.Contains("ProductID"))
                dgvSanPham.Columns["ProductID"].Visible = false;

            if (dgvSanPham.Columns.Contains("ProductCode"))
                dgvSanPham.Columns["ProductCode"].HeaderText = "Mã SP";
            if (dgvSanPham.Columns.Contains("ProductName"))
                dgvSanPham.Columns["ProductName"].HeaderText = "Tên sản phẩm";
            if (dgvSanPham.Columns.Contains("SoLuongMua"))
            {
                dgvSanPham.Columns["SoLuongMua"].HeaderText = "SL Mua";
                dgvSanPham.Columns["SoLuongMua"].ReadOnly = true;
            }
            if (dgvSanPham.Columns.Contains("DaTraLai"))
            {
                dgvSanPham.Columns["DaTraLai"].HeaderText = "Đã trả";
                dgvSanPham.Columns["DaTraLai"].ReadOnly = true;
            }
            if (dgvSanPham.Columns.Contains("ConLai"))
            {
                dgvSanPham.Columns["ConLai"].HeaderText = "Còn lại";
                dgvSanPham.Columns["ConLai"].ReadOnly = true;
            }
            if (dgvSanPham.Columns.Contains("UnitPrice"))
            {
                dgvSanPham.Columns["UnitPrice"].HeaderText = "Đơn giá";
                dgvSanPham.Columns["UnitPrice"].ReadOnly = true;
                dgvSanPham.Columns["UnitPrice"].DefaultCellStyle.Format = "N0";
            }
            if (dgvSanPham.Columns.Contains("TotalPrice"))
            {
                dgvSanPham.Columns["TotalPrice"].Visible = false;
            }
            if (dgvSanPham.Columns.Contains("Unit"))
            {
                dgvSanPham.Columns["Unit"].HeaderText = "ĐVT";
                dgvSanPham.Columns["Unit"].ReadOnly = true;
            }
            if (dgvSanPham.Columns.Contains("SoLuongTra"))
            {
                dgvSanPham.Columns["SoLuongTra"].HeaderText = "SL Trả";
                dgvSanPham.Columns["SoLuongTra"].ReadOnly = false; // Cho phép sửa
                dgvSanPham.Columns["SoLuongTra"].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 230);
            }
            if (dgvSanPham.Columns.Contains("TienHoan"))
            {
                dgvSanPham.Columns["TienHoan"].HeaderText = "Tiền hoàn";
                dgvSanPham.Columns["TienHoan"].ReadOnly = true;
                dgvSanPham.Columns["TienHoan"].DefaultCellStyle.Format = "N0";
            }

            txtTongHoan.Text = "0";
        }

        // ==================== CELL VALUE CHANGED - Tính tiền hoàn ====================
        private void dgvSanPham_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvSanPham.Columns[e.ColumnIndex].Name != "SoLuongTra") return;

            DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
            int soLuongTra = 0;
            int.TryParse(row.Cells["SoLuongTra"].Value?.ToString(), out soLuongTra);

            if (soLuongTra < 0) soLuongTra = 0;

            decimal donGia = Convert.ToDecimal(row.Cells["UnitPrice"].Value);
            row.Cells["TienHoan"].Value = soLuongTra * donGia;

            // Tính tổng tiền hoàn
            TinhTongTienHoan();
        }

        // ==================== TÍNH TỔNG TIỀN HOÀN ====================
        private void TinhTongTienHoan()
        {
            decimal tongHoan = 0;
            if (tblSanPham != null)
            {
                foreach (DataRow row in tblSanPham.Rows)
                {
                    decimal tienHoan = 0;
                    decimal.TryParse(row["TienHoan"].ToString(), out tienHoan);
                    tongHoan += tienHoan;
                }
            }
            txtTongHoan.Text = tongHoan.ToString("N0");
        }

        // ==================== TẠO PHIẾU TRẢ ====================
        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            if (cboDonHang.SelectedIndex < 0 || cboDonHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần trả!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderID = Convert.ToInt32(cboDonHang.SelectedValue);
            string reason = txtLyDo.Text.Trim();
            decimal totalRefund = 0;
            decimal.TryParse(txtTongHoan.Text.Replace(",", "").Replace(".", ""), out totalRefund);

            // Tạo mã phiếu trả tự động
            string returnCode = Functions.CreateKey("TH");

            // UserID = 1 (tạm hardcode, thực tế lấy từ session đăng nhập)
            int userID = 1;

            try
            {
                if (MessageBox.Show(
                    $"Xác nhận tạo phiếu trả hàng?\nTổng tiền hoàn: {totalRefund:N0} đ",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool success = hoanTraBLL.TaoPhieuTra(returnCode, orderID, userID, reason, totalRefund, tblSanPham);

                    if (success)
                    {
                        MessageBox.Show("Tạo phiếu trả hàng thành công!\nMã phiếu: " + returnCode,
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh
                        LoadDonHangChoPhepTra();
                        LoadDanhSachPhieuTra();
                        dgvSanPham.DataSource = null;
                        txtLyDo.Text = "";
                        txtTongHoan.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== LOAD DANH SÁCH PHIẾU TRẢ ====================
        private void LoadDanhSachPhieuTra()
        {
            DataTable dt = hoanTraBLL.LayDanhSachPhieuTra();
            dgvPhieuTra.DataSource = dt;

            if (dgvPhieuTra.Columns.Contains("ReturnID"))
                dgvPhieuTra.Columns["ReturnID"].Visible = false;

            if (dgvPhieuTra.Columns.Contains("ReturnCode"))
                dgvPhieuTra.Columns["ReturnCode"].HeaderText = "Mã phiếu";
            if (dgvPhieuTra.Columns.Contains("OrderCode"))
                dgvPhieuTra.Columns["OrderCode"].HeaderText = "Mã đơn gốc";
            if (dgvPhieuTra.Columns.Contains("CustomerName"))
                dgvPhieuTra.Columns["CustomerName"].HeaderText = "Khách hàng";
            if (dgvPhieuTra.Columns.Contains("ReturnDate"))
                dgvPhieuTra.Columns["ReturnDate"].HeaderText = "Ngày trả";
            if (dgvPhieuTra.Columns.Contains("NhanVienXuLy"))
                dgvPhieuTra.Columns["NhanVienXuLy"].HeaderText = "NV xử lý";
            if (dgvPhieuTra.Columns.Contains("Reason"))
                dgvPhieuTra.Columns["Reason"].HeaderText = "Lý do";
            if (dgvPhieuTra.Columns.Contains("TotalRefund"))
            {
                dgvPhieuTra.Columns["TotalRefund"].HeaderText = "Tiền hoàn";
                dgvPhieuTra.Columns["TotalRefund"].DefaultCellStyle.Format = "N0";
            }
            if (dgvPhieuTra.Columns.Contains("Status"))
                dgvPhieuTra.Columns["Status"].HeaderText = "Trạng thái";
        }

        // ==================== TÌM PHIẾU TRẢ ====================
        private void btnTimPhieu_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimPhieu.Text.Trim();
            if (string.IsNullOrEmpty(tuKhoa))
            {
                LoadDanhSachPhieuTra();
                return;
            }
            DataTable dt = hoanTraBLL.TimKiemPhieuTra(tuKhoa);
            dgvPhieuTra.DataSource = dt;
        }
    }
}
