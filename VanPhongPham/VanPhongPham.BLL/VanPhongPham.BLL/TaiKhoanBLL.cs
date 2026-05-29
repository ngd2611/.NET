using System;
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

        // --- Đăng nhập ---
        public DataTable KiemTraDangNhap(string username, string rawPassword)
        {
            string passwordHash = HashPasswordSHA256(rawPassword);
            return dal.KiemTraDangNhap(username, passwordHash);
        }

        // --- Lấy danh sách ---
        public DataTable LayDanhSach()
        {
            return dal.GetAllTaiKhoan();
        }

        // --- Thêm tài khoản ---
        // ✅ [FIX #9] Bọc try-catch: vì DAL không còn nuốt lỗi, BLL cần bắt và trả string lỗi
        public string ThemTaiKhoan(string username, string rawPassword, string fullName, string email, string phone, string role)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(fullName) ||
                string.IsNullOrEmpty(role)     || string.IsNullOrEmpty(rawPassword))
                return "Tên đăng nhập, Mật khẩu, Họ tên và Quyền không được để trống!";

            try
            {
                string passwordHash = HashPasswordSHA256(rawPassword);
                if (dal.InsertTaiKhoan(username, passwordHash, fullName, email, phone, role))
                    return "Thêm tài khoản thành công!";
                return "Lỗi! Không thể thêm tài khoản.";
            }
            catch (Exception ex)
            {
                // Exception từ DAL (vd: trùng username) được bắt và trả về dạng string cho GUI
                return "Lỗi: " + ex.Message;
            }
        }

        // --- Xóa tài khoản ---
        // ✅ [FIX #9] Bọc try-catch
        public string XoaTaiKhoan(int userId)
        {
            try
            {
                if (dal.DeleteTaiKhoan(userId)) return "Xóa thành công!";
                return "Xóa thất bại!";
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        // --- Cập nhật tài khoản ---
        // ✅ [FIX #9] Bọc try-catch
        public string CapNhatTaiKhoan(int userId, string user, string rawPassword, string name, string email, string phone, string role)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(role))
                return "Tài khoản, họ tên và quyền không được để trống!";

            try
            {
                string passwordHash = string.IsNullOrEmpty(rawPassword) ? "" : HashPasswordSHA256(rawPassword);
                return dal.CapNhatTaiKhoan(userId, user, passwordHash, name, email, phone, role)
                    ? "Cập nhật tài khoản thành công!"
                    : "Cập nhật thất bại!";
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        // --- Khôi phục mật khẩu ---
        // ✅ [FIX #9] Bọc try-catch
        public string KhoiPhucMatKhau(int userId)
        {
            try
            {
                if (dal.ResetPassword(userId)) return "Đã reset mật khẩu về: 123456";
                return "Reset thất bại!";
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
    }
}