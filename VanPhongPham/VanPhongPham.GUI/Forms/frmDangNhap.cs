using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace VanPhongPham.GUI
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        // Khai báo một biến tĩnh để lưu trữ tên tài khoản đang đăng nhập
        public static string TenTaiKhoanDangNhap = "";

        private string HashPasswordSHA256(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++) builder.Append(bytes[i].ToString("x2"));
                return builder.ToString();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtTaiKhoan.Text.Trim();
            string pass = txtMatKhau.Text.Trim();

            if (user == "" || pass == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!"); return;
            }

            string hashedPass = HashPasswordSHA256(pass);
            string strConn = @"Data Source=localhost;Initial Catalog=QuanLyVanPhongPham;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                string query = "SELECT FullName, Role FROM Users WHERE Username = @User AND PasswordHash = @Pass AND IsActive = 1";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@User", user);
                    cmd.Parameters.AddWithValue("@Pass", hashedPass);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            string role = dt.Rows[0]["Role"].ToString();
                            string fullName = dt.Rows[0]["FullName"].ToString();

                            // TRƯỚC KHI MỞ FORM MAIN, LƯU TÊN TÀI KHOẢN VÀO BIẾN TĨNH
                            TenTaiKhoanDangNhap = user;

                            // Gọi Form Main và truyền quyền sang
                            frmMain frm = new frmMain(user, role, fullName);
                            this.Hide();
                            frm.ShowDialog();
                            this.Close();
                        }
                        else MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                    }
                }
            }
        }
    }
}