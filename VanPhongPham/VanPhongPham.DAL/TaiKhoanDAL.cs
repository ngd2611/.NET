using System;
using System.Data;
using System.Data.SqlClient;

namespace VanPhongPham.DAL
{
    public class TaiKhoanDAL
    {
        // Hàm kiểm tra đảm bảo Connection được mở trước khi thực thi
        private void KiemTraKetNoi()
        {
            if (Functions.Conn == null || Functions.Conn.State == ConnectionState.Closed)
            {
                Functions.Connect();
            }
        }

        public DataTable KiemTraDangNhap(string username, string passwordHash)
        {
            KiemTraKetNoi();
            string query = "SELECT FullName, Role FROM Users WHERE Username = @User AND PasswordHash = @Pass AND IsActive = 1";
            using (SqlCommand cmd = new SqlCommand(query, Functions.Conn))
            {
                cmd.Parameters.AddWithValue("@User", username);
                cmd.Parameters.AddWithValue("@Pass", passwordHash);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetAllTaiKhoan()
        {
            KiemTraKetNoi(); // ✅ [FIX #3] Đảm bảo kết nối mở trước khi truy vấn
            return Functions.GetDataToTable("SELECT UserID, Username, FullName, Email, Phone, Role, IsActive, CreatedAt FROM Users");
        }

        public bool InsertTaiKhoan(string username, string passwordHash, string fullName, string email, string phone, string role)
        {
            // ✅ [FIX #3] Xóa catch{} rỗng — exception sẽ nổi lên để BLL bắt và trả thông báo cụ thể
            KiemTraKetNoi();
            string query = @"INSERT INTO Users (Username, PasswordHash, FullName, Email, Phone, Role) 
                             VALUES (@Username, @PasswordHash, @FullName, @Email, @Phone, @Role)";
            using (SqlCommand cmd = new SqlCommand(query, Functions.Conn))
            {
                cmd.Parameters.AddWithValue("@Username",     username);
                cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                cmd.Parameters.AddWithValue("@FullName",     fullName);
                cmd.Parameters.AddWithValue("@Email",        string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                cmd.Parameters.AddWithValue("@Phone",        string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone);
                cmd.Parameters.AddWithValue("@Role",         role);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteTaiKhoan(int userId)
        {
            KiemTraKetNoi();
            string query = "DELETE FROM Users WHERE UserID = @UserID";
            using (SqlCommand cmd = new SqlCommand(query, Functions.Conn))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ResetPassword(int userId)
        {
            KiemTraKetNoi();
            string defaultHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92";
            string query = "UPDATE Users SET PasswordHash = @Hash WHERE UserID = @UserID";
            using (SqlCommand cmd = new SqlCommand(query, Functions.Conn))
            {
                cmd.Parameters.AddWithValue("@Hash", defaultHash);
                cmd.Parameters.AddWithValue("@UserID", userId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool CapNhatTaiKhoan(int userId, string user, string passwordHash, string name, string email, string phone, string role)
        {
            // ✅ [FIX #3] Xóa catch{} rỗng — exception sẽ nổi lên để BLL bắt và trả thông báo cụ thể
            KiemTraKetNoi();
            string query;
            if (!string.IsNullOrEmpty(passwordHash))
                query = "UPDATE Users SET Username=@user, PasswordHash=@pass, FullName=@name, Email=@email, Phone=@phone, Role=@role, UpdatedAt=GETDATE() WHERE UserID=@id";
            else
                query = "UPDATE Users SET Username=@user, FullName=@name, Email=@email, Phone=@phone, Role=@role, UpdatedAt=GETDATE() WHERE UserID=@id";

            using (SqlCommand cmd = new SqlCommand(query, Functions.Conn))
            {
                cmd.Parameters.AddWithValue("@user",  user);
                if (!string.IsNullOrEmpty(passwordHash))
                    cmd.Parameters.AddWithValue("@pass", passwordHash);
                cmd.Parameters.AddWithValue("@name",  name);
                cmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                cmd.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone);
                cmd.Parameters.AddWithValue("@role",  role);
                cmd.Parameters.AddWithValue("@id",    userId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}