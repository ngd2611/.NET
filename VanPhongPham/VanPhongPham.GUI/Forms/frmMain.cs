using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VanPhongPham.DAL;
using VanPhongPham.GUI.Forms;

namespace VanPhongPham.GUI
{
    public partial class frmMain : Form
    {
        internal string CurrentUser; // Thêm biến lưu tài khoản đang đăng nhập
        internal string UserRole;
        internal string FullName;

        // Cập nhật nhận thêm username từ frmDangNhap
        public frmMain(string username, string role, string name) : this()
        {
            CurrentUser = username;
            UserRole = role;
            FullName = name;
        }
        private Form currentChildForm = null;
        public frmMain()
        {
            InitializeComponent();
        }

        // Hàm mở form con bên trong pnlMain
        private void OpenChildForm(Form childForm)
        {
            // Đóng form con cũ nếu có
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;

            // Khóa layout để child form không resize parent
            this.SuspendLayout();
            pnlMain.SuspendLayout();

            // Cấu hình form con để nhúng vào panel
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.AutoScaleMode = AutoScaleMode.None;
            childForm.Dock = DockStyle.Fill;

            // Xóa control cũ trong panel và thêm form mới
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(childForm);
            childForm.Show();

            // Resume layout trên panel, nhưng KHÔNG trigger layout trên frmMain
            pnlMain.ResumeLayout(true);
            this.ResumeLayout(false);

            // Ép maximize ngay
            this.WindowState = FormWindowState.Maximized;

            // Ép maximize LẦN NỮA sau khi TẤT CẢ event (LiveCharts/Guna2) xử lý xong
            this.BeginInvoke(new Action(() =>
            {
                if (this.WindowState != FormWindowState.Maximized)
                    this.WindowState = FormWindowState.Maximized;
            }));
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            frmQuanLySanPham frm = new frmQuanLySanPham();
            OpenChildForm(frm);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Khóa kích thước tối thiểu = kích thước maximize hiện tại
            this.MinimumSize = this.Size;

            MessageBox.Show("Quyền hiện tại nhận được là: " + UserRole);
            try
            {
                Functions.Connect();
                MessageBox.Show("Kết nối CSDL thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (UserRole == "Admin")
            {
                // Admin thì hiện hết
                btnTaiKhoan.Visible = true;
                // btnBaoCao.Visible = true;
            }
            else if (UserRole == "NhanVienBanHang")
            {
                btnDashboard.Visible = false; // Ẩn tổng quan
                btnNhapKho.Visible = false;   // Ẩn nhập kho
                btnBaoCao.Visible = false;    // Ẩn báo cáo doanh thu
                btnTaiKhoan.Visible = false;  // Ẩn quản lý nhân sự
            }
            else if (UserRole == "NhanVienKho")
            {
                btnDashboard.Visible = false; // Ẩn tổng quan
                btnBanHang.Visible = false;   // Ẩn bán hàng
                btnDonHang.Visible = false;   // Ẩn đơn hàng
                btnTraHang.Visible = false;   // Ẩn trả hàng
                btnBaoCao.Visible = false;    // Ẩn báo cáo
                btnTaiKhoan.Visible = false;  // Ẩn quản lý nhân sự
            }
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            // Truyền CurrentUser cho frmQuanLyTaiKhoan để check quyền xóa
            frmQuanLyTaiKhoan frm = new frmQuanLyTaiKhoan(CurrentUser);
            OpenChildForm(frm);
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            frmQuanLyDanhMuc frm = new frmQuanLyDanhMuc();
            OpenChildForm(frm);
        }

        // ==================== PHẦN CỦA LƯƠNG ====================

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            frmBanHang frm = new frmBanHang();
            OpenChildForm(frm);
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            frmNhapKho frm = new frmNhapKho();
            OpenChildForm(frm);
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            frmQuanLyDonHang frm = new frmQuanLyDonHang();
            OpenChildForm(frm);
        }

        private void btnTraHang_Click(object sender, EventArgs e)
        {
            frmTraHang frm = new frmTraHang();
            OpenChildForm(frm);
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            frmBaoCaoThongKe frm = new frmBaoCaoThongKe();
            OpenChildForm(frm);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            frmBaoCaoThongKe frm = new frmBaoCaoThongKe();
            OpenChildForm(frm);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();

                frmDangNhap frm = new frmDangNhap();
                frm.ShowDialog();

                this.Close();
            }
         }

    }
}
