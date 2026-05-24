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
using VanPhongPham.BLL;

namespace VanPhongPham.GUI.Forms
{
    public partial class frmQuanLyTaiKhoan : Form
    {
        TaiKhoanBLL bll = new TaiKhoanBLL();
        private int dangChonUserId = -1;

        private string taiKhoanDangDangNhap;

        // Khai báo thêm biến currentUser
        private string currentUser;

        // Thêm trường này để nhận Tài khoản đăng nhập từ frmMain truyền qua
        public string CurrentLoginUsername { get; set; } = "";

        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        // Các phương thức khởi tạo đối tượng có tham số để nhận dữ liệu từ frmMain
        public frmQuanLyTaiKhoan(string loggedInUser)
        {
            InitializeComponent();
            currentUser = loggedInUser;
        }

        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            cboQuyen.Items.Clear();
            cboQuyen.Items.AddRange(new string[] { "Admin", "NhanVienBanHang", "NhanVienKho" });
            LoadDanhSach();
    
            // Gọi hàm Reset để thiết lập trạng thái các nút ở lần đầu tiên mở Form
            btnReset_Click(sender, e);
        }
        private void LoadDanhSach()
        {
            dgvDanhSachTaiKhoan.DataSource = bll.LayDanhSach();
            // 1. Tự động giãn đều các cột lấp đầy khoảng trống
            dgvDanhSachTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 2. Ẩn đi các cột không cần thiết cho gọn bảng
            if (dgvDanhSachTaiKhoan.Columns.Contains("UserID"))
                dgvDanhSachTaiKhoan.Columns["UserID"].Visible = false;
            if (dgvDanhSachTaiKhoan.Columns.Contains("IsActive"))
                dgvDanhSachTaiKhoan.Columns["IsActive"].Visible = false;
            if (dgvDanhSachTaiKhoan.Columns.Contains("CreatedAt"))
                dgvDanhSachTaiKhoan.Columns["CreatedAt"].Visible = false;
            if (dgvDanhSachTaiKhoan.Columns.Contains("UpdatedAt"))
                dgvDanhSachTaiKhoan.Columns["UpdatedAt"].Visible = false;

            // 3. (Tùy chọn) Đổi tên tiêu đề tiếng Anh sang tiếng Việt cho chuyên nghiệp
            if (dgvDanhSachTaiKhoan.Columns.Contains("Username"))
                dgvDanhSachTaiKhoan.Columns["Username"].HeaderText = "Tài khoản";
            if (dgvDanhSachTaiKhoan.Columns.Contains("FullName"))
                dgvDanhSachTaiKhoan.Columns["FullName"].HeaderText = "Họ và tên";
            if (dgvDanhSachTaiKhoan.Columns.Contains("Phone"))
                dgvDanhSachTaiKhoan.Columns["Phone"].HeaderText = "Số điện thoại";
            if (dgvDanhSachTaiKhoan.Columns.Contains("Role"))
                dgvDanhSachTaiKhoan.Columns["Role"].HeaderText = "Phân quyền";

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra sơ bộ giao diện (UI Validation)
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Tài khoản và Họ tên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text)) // Kiểm tra cả mật khẩu
            {
                MessageBox.Show("Mật khẩu mới không được để trống khi Thêm tài khoản!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(cboQuyen.Text))
            {
                MessageBox.Show("Vui lòng chọn quyền cho tài khoản!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Gọi BLL để thêm tài khoản
            string kq = bll.ThemTaiKhoan(txtTaiKhoan.Text, txtMatKhau.Text, txtHoTen.Text, txtEmail.Text, txtDienThoai.Text, cboQuyen.Text);
            MessageBox.Show(kq, "Thông báo");

            // 3. Tải lại danh sách và làm trắng form
            LoadDanhSach();
            btnReset_Click(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem đã click chọn dòng nào chưa
            if (dangChonUserId == -1)
            {
                MessageBox.Show("Vui lòng click chọn một tài khoản dưới bảng trước khi xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ---- CHẶN XÓA CHÍNH MÌNH -----
            if (txtTaiKhoan.Text.Equals(currentUser, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Lỗi: Không thể xóa tài khoản hệ thống mà bạn đang đăng nhập!", "Lỗi bảo mật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // -------------------------------

            // 3. Tiến hành xóa bình thường
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Gọi BLL xóa dữ liệu
                MessageBox.Show(bll.XoaTaiKhoan(dangChonUserId), "Thông báo");

                LoadDanhSach();
                btnReset_Click(sender, e); // Reset để làm trắng TextBox sau khi xóa
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // 1. Xóa trắng toàn bộ TextBox
            txtTaiKhoan.Clear();
            txtHoTen.Clear();
            txtEmail.Clear();
            txtDienThoai.Clear();
            txtMatKhau.Clear(); // <-- Xóa trắng mật khẩu

            // 2. Trả Droplist Quyền về trạng thái trắng tinh (không chọn gì)
            cboQuyen.SelectedIndex = -1;

            // 3. Reset lại cái biến đang chọn và bỏ bôi xanh trên bảng
            dangChonUserId = -1;
            dgvDanhSachTaiKhoan.ClearSelection();

            // --- TỐI ƯU UX: BẬT/TẮT NÚT ---
            btnThem.Enabled = true;       // Mở nút Thêm
            btnSua.Enabled = false;       // Khóa nút Sửa
            btnXoa.Enabled = false;       // Khóa nút Xóa
            txtTaiKhoan.Enabled = true;  // Mở lại ô nhập liệu Tài khoản cho phép nhập mới
            // ------------------------------

            // 4. Nháy nháy con trỏ chuột ở ô Tài khoản để gõ luôn cho tiện
            txtTaiKhoan.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dangChonUserId == -1)
            {
                MessageBox.Show("Vui lòng click chọn một tài khoản dưới bảng trước khi sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra sơ bộ giao diện (UI Validation)
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Tài khoản và Họ tên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi xuống tầng BLL để cập nhật thông tin mới
            string kq = bll.CapNhatTaiKhoan(dangChonUserId, txtTaiKhoan.Text, txtMatKhau.Text, txtHoTen.Text, txtEmail.Text, txtDienThoai.Text, cboQuyen.Text);

            MessageBox.Show(kq, "Thông báo");

            if (kq.Contains("thành công")) // Giả sử BLL trả về chuỗi có chữ "thành công"
            {
                LoadDanhSach(); // Tải lại bảng sau khi sửa thành công
                // Gọi tới hàm Reset để xóa trắng các ô nhập liệu, đưa form về trạng thái ban đầu
                btnReset_Click(sender, e);
            }
        }

        private void dgvDanhSachTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDanhSachTaiKhoan.CurrentRow != null)
            {
                // Lấy ra mã UserID của dòng đang chọn
                dangChonUserId = Convert.ToInt32(dgvDanhSachTaiKhoan.CurrentRow.Cells["UserID"].Value);

                // Đẩy dữ liệu vào các ô TextBox tương ứng
                txtTaiKhoan.Text = dgvDanhSachTaiKhoan.CurrentRow.Cells["Username"].Value.ToString();
                txtHoTen.Text = dgvDanhSachTaiKhoan.CurrentRow.Cells["FullName"].Value.ToString();
                txtEmail.Text = dgvDanhSachTaiKhoan.CurrentRow.Cells["Email"].Value?.ToString();
                txtDienThoai.Text = dgvDanhSachTaiKhoan.CurrentRow.Cells["Phone"].Value?.ToString();
                cboQuyen.Text = dgvDanhSachTaiKhoan.CurrentRow.Cells["Role"].Value.ToString();

                // --- TỐI ƯU UX: BẬT/TẮT NÚT ---
                btnThem.Enabled = false;      // Khóa nút Thêm để tránh thêm trùng lặp dư thừa
                btnSua.Enabled = true;        // Mở nút Sửa
                btnXoa.Enabled = true;        // Mở nút Xóa
                txtTaiKhoan.Enabled = false; // Khóa ô tài khoản: Nguyên tắc là tên đăng nhập không được đổi (chỉ đổi Tên, mật khẩu...)
                // ------------------------------
            }
        }


    }
}
