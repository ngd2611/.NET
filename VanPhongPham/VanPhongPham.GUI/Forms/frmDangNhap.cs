using System;
using System.Data;
using System.Windows.Forms;
using VanPhongPham.BLL;

namespace VanPhongPham.GUI
{
    public partial class frmDangNhap : Form
    {
        private TaiKhoanBLL tkBLL = new TaiKhoanBLL();
        public static string TenTaiKhoanDangNhap = "";

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtTaiKhoan.Text.Trim();
            string pass = txtMatKhau.Text.Trim();

            if (user == "" || pass == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!"); 
                return;
            }

            // Đẩy logic kiểm tra tài khoản xuống BLL theo chuẩn 3 lớp
            DataTable dt = tkBLL.KiemTraDangNhap(user, pass);

            if (dt.Rows.Count > 0)
            {
                string role = dt.Rows[0]["Role"].ToString();
                string fullName = dt.Rows[0]["FullName"].ToString();
                TenTaiKhoanDangNhap = user;

                // Gọi Form Main và truyền quyền sang
                frmMain frm = new frmMain(user, role, fullName);
                this.Hide();
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tài khoản, mật khẩu hoặc tài khoản đã bị khóa!");
            }
        }
    }
}