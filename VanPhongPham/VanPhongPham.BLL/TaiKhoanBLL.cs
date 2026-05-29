using System.Data;
using System.Security.Cryptography; 
using System.Text;
using VanPhongPham.DAL;

namespace VanPhongPham.BLL
{
    public class TaiKhoanBLL
    {
        private TaiKhoanDAL dal = new TaiKhoanDAL();

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

        // --- Hàm Đăng nhập Mới ---
        public DataTable KiemTraDangNhap(string username, string rawPassword)
        {
            string passwordHash = HashPasswordSHA256(rawPassword);
            return dal.KiemTraDangNhap(username, passwordHash);
        }

        public DataTable LayDanhSach()
        {
            return dal.GetAllTaiKhoan();
        }

        public string ThemTaiKhoan(string username, string rawPassword, string fullName, string email, string phone, string role)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(role) || string.IsNullOrEmpty(rawPassword))
                return "Tên đăng nhập, Mật khẩu, Họ tên và Quyền không được để trống!";

            string passwordHash = HashPasswordSHA256(rawPassword);

            if (dal.InsertTaiKhoan(username, passwordHash, fullName, email, phone, role))
                return "Thêm tài khoản thành công!";

            return "Lỗi! Không thể thêm tài khoản.";
        }

        public string XoaTaiKhoan(int userId)
        {
            if (dal.DeleteTaiKhoan(userId)) return "Xóa thành công!";
            return "Xóa thất bại!";
        }

        public string CapNhatTaiKhoan(int userId, string user, string rawPassword, string name, string email, string phone, string role)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(role))
                return "Tài khoản, họ tên và quyền không được để trống!";

            string passwordHash = string.IsNullOrEmpty(rawPassword) ? "" : HashPasswordSHA256(rawPassword);

            return dal.CapNhatTaiKhoan(userId, user, passwordHash, name, email, phone, role) ? "Cập nhật tài khoản thành công!" : "Cập nhật thất bại!";
        }
        
        public string KhoiPhucMatKhau(int userId)
        {
            if (dal.ResetPassword(userId)) return "Đã reset mật khẩu về: 123456";
            return "Reset thất bại!";
        }
    }
}