using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;   // Giữ lại vì FillCombo cần kiểu ComboBox
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace VanPhongPham.DAL
{
    public static class Functions
    {
        // ==================== KẾT NỐI CSDL ====================
        public static SqlConnection Conn;
        public static string connString;

        public static void Connect()
        {
            connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Conn = new SqlConnection(connString);
            if (Conn.State != ConnectionState.Open)
                Conn.Open();
        }


        // ✅ [FIX #1] Hàm kiểm tra và tự động mở kết nối trước mỗi thao tác
        private static void KiemTraKetNoi()
        {
            if (Conn == null || Conn.State != ConnectionState.Open)
                Connect();
        }

        // ==================== CÁC HÀM XỬ LÝ DỮ LIỆU ====================

        // Lấy DataTable từ câu lệnh SELECT (không tham số)
        public static DataTable GetDataToTable(string sql)
        {
            KiemTraKetNoi(); // ✅ [FIX #1] Đảm bảo kết nối luôn mở
            using (SqlCommand cmd = new SqlCommand(sql, Conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))  // ✅ [FIX] Đóng đúng với using
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ✅ [FIX #7 SQL INJECTION] Overload: GetDataToTable có tham số hóa
        public static DataTable GetDataToTable(string sql, params SqlParameter[] parameters)
        {
            KiemTraKetNoi();
            using (SqlCommand cmd = new SqlCommand(sql, Conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        // ✅ [FIX #7 SQL INJECTION] Overload: RunSql có tham số hóa (dùng cho INSERT/UPDATE an toàn)
        public static void RunSql(string sql, params SqlParameter[] parameters)
        {
            KiemTraKetNoi();
            using (SqlCommand cmd = new SqlCommand(sql, Conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);
                cmd.ExecuteNonQuery();
            }
        }



        // ✅ [FIX #7 SQL INJECTION] Overload: RunSqlDel có tham số hóa
        public static void RunSqlDel(string sql, params SqlParameter[] parameters)
        {
            KiemTraKetNoi();
            using (SqlCommand cmd = new SqlCommand(sql, Conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);
                cmd.ExecuteNonQuery();
            }
        }


        // ✅ [FIX] Lấy giá trị trường đầu tiên — đóng reader đúng cách bằng using
        public static string GetFieldValues(string sql)
        {
            KiemTraKetNoi();
            string result = "";
            using (SqlCommand cmd = new SqlCommand(sql, Conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                    result = reader.GetValue(0).ToString();
            }
            return result;
        }

        // Điền dữ liệu vào ComboBox
        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            KiemTraKetNoi();
            using (SqlCommand cmd = new SqlCommand(sql, Conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbo.DataSource = dt;
                cbo.ValueMember = ma;
                cbo.DisplayMember = ten;
            }
        }



        // ==================== TẠO KHÓA TỰ ĐỘNG ====================
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
                case "1":  return "13";
                case "2":  return "14";
                case "3":  return "15";
                case "4":  return "16";
                case "5":  return "17";
                case "6":  return "18";
                case "7":  return "19";
                case "8":  return "20";
                case "9":  return "21";
                case "10": return "22";
                case "11": return "23";
                case "12": return "0";
                default:   return hour;
            }
        }


        // ==================== MÃ HÓA MẬT KHẨU ====================
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