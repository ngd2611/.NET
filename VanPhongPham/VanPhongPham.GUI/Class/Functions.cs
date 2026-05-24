using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace VanPhongPham.GUI.Class
{
    public static class Functions
    {
        // ==================== KẾT NỐI CSDL ====================
        public static SqlConnection Conn;  // Đối tượng kết nối
        public static string connString;   // Chuỗi kết nối

        // Hàm kết nối - đọc từ App.config (giáo trình mục 4.3)
        public static void Connect()
        {
            connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Conn = new SqlConnection(connString);
            if (Conn.State != ConnectionState.Open)
                Conn.Open();
        }

        // Hàm ngắt kết nối
        public static void Disconnect()
        {
            if (Conn != null && Conn.State == ConnectionState.Open)
            {
                Conn.Close();
                Conn.Dispose();
                Conn = null;
            }
        }

        // ==================== CÁC HÀM XỬ LÝ DỮ LIỆU ====================

        // Lấy DataTable từ câu lệnh SELECT (giáo trình)
        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, Conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Thực thi câu lệnh INSERT, UPDATE, DELETE (giáo trình)
        public static void RunSql(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, Conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cmd.Dispose();
        }

        // Thực thi DELETE có kiểm tra ràng buộc (giáo trình)
        public static void RunSqlDel(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, Conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Dữ liệu đang được dùng, không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            cmd.Dispose();
        }

        // Kiểm tra khóa trùng (giáo trình)
        public static bool CheckKey(string sql)
        {
            DataTable dt = GetDataToTable(sql);
            return dt.Rows.Count > 0;
        }

        // Lấy giá trị trường đầu tiên của câu lệnh SELECT (giáo trình GetFieldValues)
        public static string GetFieldValues(string sql)
        {
            string result = "";
            SqlCommand cmd = new SqlCommand(sql, Conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                result = reader.GetValue(0).ToString();
            reader.Close();
            return result;
        }

        // Đổ dữ liệu vào ComboBox (giáo trình FillCombo)
        public static void FillCombo(string sql, ComboBox cbo, string valueMember, string displayMember)
        {
            DataTable dt = GetDataToTable(sql);
            cbo.DataSource = dt;
            cbo.ValueMember = valueMember;
            cbo.DisplayMember = displayMember;
            cbo.SelectedIndex = -1;
        }

        // ==================== XỬ LÝ NGÀY THÁNG ====================
        // Chuyển dd/MM/yyyy sang MM/dd/yyyy (lưu vào CSDL)
        public static string ConvertDateTime(string date)
        {
            string[] parts = date.Split('/');
            if (parts.Length == 3)
                return $"{parts[1]}/{parts[0]}/{parts[2]}";
            return date;
        }

        // Kiểm tra chuỗi có đúng định dạng dd/MM/yyyy không
        public static bool IsDate(string date)
        {
            try
            {
                DateTime.ParseExact(date, "dd/MM/yyyy", null);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // ==================== TẠO KHÓA TỰ ĐỘNG ====================
        // Tạo khóa dạng: prefix + DDMMYYYY + HHMMSS (giáo trình)
        public static string CreateKey(string prefix)
        {
            string key = prefix;
            string[] partsDay = DateTime.Now.ToShortDateString().Split('/');
            string d = $"{partsDay[0]}{partsDay[1]}{partsDay[2]}";
            key += d;

            string[] partsTime = DateTime.Now.ToLongTimeString().Split(':');
            if (partsTime[2].Substring(3, 2) == "PM")
                partsTime[0] = ConvertTimeTo24(partsTime[0]);
            if (partsTime[2].Substring(3, 2) == "AM" && partsTime[0].Length == 1)
                partsTime[0] = "0" + partsTime[0];

            partsTime[2] = partsTime[2].Remove(2, 3);
            string t = $"{partsTime[0]}{partsTime[1]}{partsTime[2]}";
            key += t;
            return key;
        }

        private static string ConvertTimeTo24(string hour)
        {
            switch (hour)
            {
                case "1": return "13";
                case "2": return "14";
                case "3": return "15";
                case "4": return "16";
                case "5": return "17";
                case "6": return "18";
                case "7": return "19";
                case "8": return "20";
                case "9": return "21";
                case "10": return "22";
                case "11": return "23";
                case "12": return "0";
                default: return hour;
            }
        }

        // ==================== CHUYỂN SỐ THÀNH CHỮ (cho hóa đơn) ====================
        public static string ChuyenSoSangChu(string sNumber)
        {
            sNumber = sNumber.Replace(",", "");
            string[] mNumText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');
            int mLen = sNumber.Length - 1;
            string mTemp = "";
            for (int i = 0; i <= mLen; i++)
            {
                int mDigit = Convert.ToInt32(sNumber.Substring(i, 1));
                mTemp += " " + mNumText[mDigit];
                if (mLen == i) break;
                switch ((mLen - i) % 9)
                {
                    case 0: mTemp += " tỷ"; break;
                    case 6: mTemp += " triệu"; break;
                    case 3: mTemp += " nghìn"; break;
                    default:
                        switch ((mLen - i) % 3)
                        {
                            case 2: mTemp += " trăm"; break;
                            case 1: mTemp += " mươi"; break;
                        }
                        break;
                }
            }
            // Xử lý các trường hợp đặc biệt
            mTemp = mTemp.Replace("không mươi không ", "");
            mTemp = mTemp.Replace("không mươi không", "");
            mTemp = mTemp.Replace("không mươi ", "linh ");
            mTemp = mTemp.Replace("mươi không", "mươi");
            mTemp = mTemp.Replace("một mươi", "mười");
            mTemp = mTemp.Replace("mươi bốn", "mươi tư");
            mTemp = mTemp.Replace("linh bốn", "linh tư");
            mTemp = mTemp.Replace("mươi năm", "mươi lăm");
            mTemp = mTemp.Replace("mươi một", "mươi mốt");
            mTemp = mTemp.Replace("mười năm", "mười lăm");
            mTemp = mTemp.Trim();
            mTemp = mTemp.Substring(0, 1).ToUpper() + mTemp.Substring(1) + " đồng";
            return mTemp;
        }

        // ==================== MÃ HÓA MẬT KHẨU (theo yêu cầu đề bài) ====================
        // Dùng BCrypt (đã cài qua NuGet) hoặc dùng SHA256 (nếu chưa cài BCrypt)
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            string hashOfInput = HashPassword(password);
            return hashOfInput == hashedPassword;
        }
    }
}