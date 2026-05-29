using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using VanPhongPham.BLL;

namespace VanPhongPham.GUI.Forms
{
    public partial class frmBaoCaoThongKe : Form
    {
        private ThongKeBLL thongKeBLL = new ThongKeBLL();
        private bool isLoading = false;

        public frmBaoCaoThongKe()
        {
            InitializeComponent();
        }

        // ==================== FORM LOAD ====================
        private void frmBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            isLoading = true;

            // Nạp ComboBox năm (5 năm gần đây)
            cboNam.Items.Clear();
            int currentYear = DateTime.Now.Year;
            for (int y = currentYear; y >= currentYear - 4; y--)
            {
                cboNam.Items.Add(y.ToString());
            }
            cboNam.SelectedIndex = 0;

            isLoading = false;

            // Load tất cả dữ liệu
            LoadAllData();
        }

        // ==================== LOAD TẤT CẢ DỮ LIỆU ====================
        private void LoadAllData()
        {
            try
            {
                LoadSummaryCards();
                LoadChartDoanhThu();
                LoadChartTrangThai();
                LoadTopBanChay();
                LoadTonKhoCanhBao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu Dashboard: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== LOAD SUMMARY CARDS ====================
        private void LoadSummaryCards()
        {
            decimal doanhThuThang = thongKeBLL.LayDoanhThuThangNay();
            int soDon = thongKeBLL.LaySoDonHomNay();
            int spHet = thongKeBLL.LaySoSPSapHet();
            int tongKH = thongKeBLL.LayTongKhachHang();

            lblDoanhThuValue.Text = doanhThuThang.ToString("N0") + " đ";
            lblSoDonValue.Text = soDon.ToString();
            lblSPHetValue.Text = spHet.ToString();
            lblKhachHangValue.Text = tongKH.ToString();
        }

        // ==================== BIỂU ĐỒ CỘT: DOANH THU THEO THÁNG ====================
        private void LoadChartDoanhThu()
        {
            int nam = DateTime.Now.Year;
            if (cboNam.SelectedItem != null)
                int.TryParse(cboNam.SelectedItem.ToString(), out nam);

            DataTable dt = thongKeBLL.LayDoanhThuTheoThang(nam);

            // Reset hoàn toàn chart
            chartDoanhThu.Series.Clear();
            chartDoanhThu.Legends.Clear();
            chartDoanhThu.Titles.Clear();

            // Title
            chartDoanhThu.Titles.Add("Doanh thu năm " + nam);
            chartDoanhThu.Titles[0].Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);

            // Legend
            var legend = new Legend("Legend1");
            legend.Docking = Docking.Bottom;
            chartDoanhThu.Legends.Add(legend);

            // Series cột
            Series series = new Series("Doanh thu (VNĐ)");
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.FromArgb(41, 128, 185);
            series.Font = new Font("Microsoft Sans Serif", 7F);

            double maxValue = 0;
            for (int i = 1; i <= 12; i++)
            {
                double revenue = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToInt32(row["Thang"]) == i)
                    {
                        revenue = Convert.ToDouble(row["DoanhThu"]);
                        break;
                    }
                }
                int idx = series.Points.AddXY("T" + i, revenue);
                if (revenue > 0)
                {
                    series.Points[idx].IsValueShownAsLabel = true;
                    series.Points[idx].LabelFormat = "N0";
                    if (revenue > maxValue) maxValue = revenue;
                }
            }

            chartDoanhThu.Series.Add(series);

            // Cấu hình trục
            var area = chartDoanhThu.ChartAreas[0];
            area.AxisX.Title = "Tháng";
            area.AxisX.Interval = 1;
            area.AxisY.Title = "Doanh thu (VNĐ)";
            area.AxisY.LabelStyle.Format = "N0";
            area.AxisY.Minimum = 0;
            if (maxValue > 0)
                area.AxisY.Maximum = maxValue * 1.2; // Thêm 20% cho dễ nhìn
            else
                area.AxisY.Maximum = double.NaN; // Auto
            area.AxisX.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.RecalculateAxesScale();

            // Ép vẽ lại
            chartDoanhThu.Invalidate();
            chartDoanhThu.Update();
        }

        // ==================== BIỂU ĐỒ TRÒN: TRẠNG THÁI ĐƠN HÀNG ====================
        private void LoadChartTrangThai()
        {
            DataTable dt = thongKeBLL.LayThongKeTrangThai();

            chartTrangThai.Series.Clear();
            chartTrangThai.Legends.Clear();

            // Legend
            var legend = new Legend("Legend1");
            legend.Docking = Docking.Right;
            chartTrangThai.Legends.Add(legend);

            Series series = new Series("TrangThai");
            series.ChartType = SeriesChartType.Pie;
            series.IsValueShownAsLabel = true;
            series.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            series["PieLabelStyle"] = "Outside";
            series.Label = "#PERCENT{P0}";

            // Màu cho từng trạng thái
            Color[] colors = new Color[]
            {
                Color.FromArgb(243, 156, 18),  // Chờ xử lý - Vàng cam
                Color.FromArgb(41, 128, 185),  // Đang giao - Xanh dương
                Color.FromArgb(52, 152, 219),  // Đã giao - Xanh nhạt
                Color.FromArgb(39, 174, 96),   // Hoàn thành - Xanh lá
                Color.FromArgb(231, 76, 60),   // Hủy - Đỏ
            };

            int colorIdx = 0;
            foreach (DataRow row in dt.Rows)
            {
                int idx = series.Points.AddXY(
                    row["TrangThai"].ToString(),
                    Convert.ToInt32(row["SoLuong"]));

                if (colorIdx < colors.Length)
                    series.Points[idx].Color = colors[colorIdx];

                series.Points[idx].LegendText = row["TrangThai"].ToString() + " (" + row["SoLuong"].ToString() + ")";
                colorIdx++;
            }

            chartTrangThai.Series.Add(series);
        }

        // ==================== TOP SẢN PHẨM BÁN CHẠY ====================
        private void LoadTopBanChay()
        {
            DataTable dt = thongKeBLL.LayTopBanChay(10);
            dgvTopBanChay.DataSource = dt;

            if (dgvTopBanChay.Columns.Contains("MaSP"))
                dgvTopBanChay.Columns["MaSP"].HeaderText = "Mã SP";
            if (dgvTopBanChay.Columns.Contains("TenSP"))
                dgvTopBanChay.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            if (dgvTopBanChay.Columns.Contains("SoLuongBan"))
                dgvTopBanChay.Columns["SoLuongBan"].HeaderText = "SL bán";
            if (dgvTopBanChay.Columns.Contains("DoanhThu"))
            {
                dgvTopBanChay.Columns["DoanhThu"].HeaderText = "Doanh thu";
                dgvTopBanChay.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
            }
        }

        // ==================== TỒN KHO CẢNH BÁO ====================
        private void LoadTonKhoCanhBao()
        {
            DataTable dt = thongKeBLL.LayTonKhoCanhBao();
            dgvTonKho.DataSource = dt;

            if (dgvTonKho.Columns.Contains("MaSP"))
                dgvTonKho.Columns["MaSP"].HeaderText = "Mã SP";
            if (dgvTonKho.Columns.Contains("TenSP"))
                dgvTonKho.Columns["TenSP"].HeaderText = "Tên SP";
            if (dgvTonKho.Columns.Contains("TonKho"))
                dgvTonKho.Columns["TonKho"].HeaderText = "Tồn kho";
            if (dgvTonKho.Columns.Contains("MucToiThieu"))
                dgvTonKho.Columns["MucToiThieu"].HeaderText = "Tối thiểu";
            if (dgvTonKho.Columns.Contains("DanhMuc"))
                dgvTonKho.Columns["DanhMuc"].HeaderText = "Danh mục";
            if (dgvTonKho.Columns.Contains("ThuongHieu"))
                dgvTonKho.Columns["ThuongHieu"].HeaderText = "Thương hiệu";
        }

        // ==================== NÚT LÀM MỚI ====================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllData();
        }

        // ==================== ĐỔI NĂM → TỰ ĐỘNG LOAD LẠI ====================
        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoading && cboNam.SelectedIndex >= 0)
            {
                LoadChartDoanhThu();
            }
        }
    }
}

