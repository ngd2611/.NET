using System;
using System.Data;
using System.Data.SqlClient;

namespace VanPhongPham.DAL
{
    public class TaiKhoanDAL
    {
        // Nhớ đổi TEN_MAY thành tên Server của bạn nhé
        private string strConn = @"Data Source=LAPTOP-IOHJRBK6;Initial Catalog=QuanLyVanPhongPham;Integrated Security=True;TrustServerCertificate=True;";

        public DataTable GetAllTaiKhoan()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                string query = "SELECT UserID, Username, FullName, Email, Phone, Role, IsActive, CreatedAt FROM Users";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // Bỏ hard-code mặc định, truyền thẳng passwordHash vào
        public bool InsertTaiKhoan(string username, string passwordHash, string fullName, string email, string phone, string role)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    string query = @"INSERT INTO Users (Username, PasswordHash, FullName, Email, Phone, Role) 
                             VALUES (@Username, @PasswordHash, @FullName, @Email, @Phone, @Role)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@Role", role);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch { return false; }
        }

        public bool DeleteTaiKhoan(int userId)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                string query = "DELETE FROM Users WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool ResetPassword(int userId)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                string defaultHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92";
                string query = "UPDATE Users SET PasswordHash = @Hash WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Hash", defaultHash);
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // Cập nhật hàm Update, có mật khẩu thì Update luôn mật khẩu, không thì giữ nguyên
        public bool CapNhatTaiKhoan(int userId, string user, string passwordHash, string name, string email, string phone, string role)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    string query;
                    if (!string.IsNullOrEmpty(passwordHash)) // Nếu có mật khẩu mới thì update cả mật khẩu
                    {
                        query = "UPDATE Users SET Username=@user, PasswordHash=@pass, FullName=@name, Email=@email, Phone=@phone, Role=@role, UpdatedAt=GETDATE() WHERE UserID=@id";
                    }
                    else
                    {
                        query = "UPDATE Users SET Username=@user, FullName=@name, Email=@email, Phone=@phone, Role=@role, UpdatedAt=GETDATE() WHERE UserID=@id";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", user);
                        if (!string.IsNullOrEmpty(passwordHash)) cmd.Parameters.AddWithValue("@pass", passwordHash);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@role", role);
                        cmd.Parameters.AddWithValue("@id", userId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch { return false; }
        }
    }
}