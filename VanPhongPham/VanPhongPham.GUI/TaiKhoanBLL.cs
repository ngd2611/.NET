using System.Security.Cryptography;
using System.Text;
// ... (Các using khác)

public class TaiKhoanBLL
{
    // ... Khai báo DAL

    // Hàm mã hóa dùng chung
    public string HashPasswordSHA256(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++) builder.Append(bytes[i].ToString("x2"));
            return builder.ToString();
        }
    }

    // C?p nh?t hàm thêm có thêm tham s? password
    public string ThemTaiKhoan(string username, string password, string fullName, string email, string phone, string role)
    {
        // ... Các validate hi?n t?i ...

        string hashPass = HashPasswordSHA256(password); // B?m m?t kh?u ng??i dùng ch?n

        // B?n c?n vào file TaiKhoanDAL s?a hàm InsertTaiKhoan ?? ti?p nh?n bi?n hashPass này
        if (dal.InsertTaiKhoan(username, hashPass, fullName, email, phone, role))
            return "Thêm tài kho?n thành công!";
            
        return "L?i! Không th? thêm tài kho?n.";
    }

    public string CapNhatTaiKhoan(int userId, string user, string password, string name, string email, string phone, string role)
    {
        // N?u password r?ng (không nh?p vào), có th? coi nh? là không ??i m?t kh?u
        string hashPass = null;
        if (!string.IsNullOrEmpty(password)) 
        {
             hashPass = HashPasswordSHA256(password);
        }

        // T??ng t?, vào file TaiKhoanDAL s?a CapNhatTaiKhoan ?? nh?n thêm tham s? hashPass 
        // Trong câu l?nh SQL UPDATE c?a DAL, hãy vi?t ?i?u ki?n ch? Update `PasswordHash = @Pass` N?U hashPass != null.
        return dal.CapNhatTaiKhoan(userId, user, hashPass, name, email, phone, role) ? "C?p nh?t thành công!" : "C?p nh?t th?t b?i!";
    }
}

//...
string kq = bll.ThemTaiKhoan(txtTaiKhoan.Text, txtMatKhau.Text, txtHoTen.Text, txtEmail.Text, txtDienThoai.Text, cboQuyen.Text);
//...
string kq = bll.CapNhatTaiKhoan(dangChonUserId, txtTaiKhoan.Text, txtMatKhau.Text, txtHoTen.Text, txtEmail.Text, txtDienThoai.Text, cboQuyen.Text);