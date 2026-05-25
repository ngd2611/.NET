using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.WinForms;
using VanPhongPham.BLL;

namespace VanPhongPham.GUI.Forms
{
    public partial class frmBaoCaoThongKe : Form
    {
        private ThongKeBLL thongKeBLL = new ThongKeBLL();

        public frmBaoCaoThongKe()
        {
            InitializeComponent();
        }

        // ==================== FORM LOAD ====================
        private void frmBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            // Nạp ComboBox năm (5 năm gần đây)
            cboNam.Items.Clear();
            int currentYear = DateTime.Now.Year;
            for (int y = currentYear; y >= currentYear - 4; y--)
            {
                cboNam.Items.Add(y.ToString());
            }
            cboNam.SelectedIndex = 0;

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

            // Tạo mảng 12 tháng
            ChartValues<double> values = new ChartValues<double>();
            string[] labels = new string[12];

            for (int i = 1; i <= 12; i++)
            {
                labels[i - 1] = "T" + i;
                double revenue = 0;

                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToInt32(row["Thang"]) == i)
                    {
                        revenue = Convert.ToDouble(row["DoanhThu"]);
                        break;
                    }
                }
                values.Add(revenue);
            }

            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Doanh thu (VNĐ)",
                    Values = values,
                    Fill = new System.Windows.Media.SolidColorBrush(
                        System.Windows.Media.Color.FromRgb(41, 128, 185)),
                    MaxColumnWidth = 40
                }
            };

            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Tháng",
                Labels = labels,
                Separator = new Separator { Step = 1 }
            });

            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Doanh thu (VNĐ)",
                LabelFormatter = value => value.ToString("N0")
            });

            cartesianChart1.LegendLocation = LegendLocation.Bottom;
        }

        // ==================== BIỂU ĐỒ TRÒN: TRẠNG THÁI ĐƠN HÀNG ====================
        private void LoadChartTrangThai()
        {
            DataTable dt = thongKeBLL.LayThongKeTrangThai();

            SeriesCollection series = new SeriesCollection();

            // Màu sắc cho từng trạng thái
            System.Windows.Media.SolidColorBrush[] colors = new System.Windows.Media.SolidColorBrush[]
            {
                new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(243, 156, 18)),   // Chờ xử lý - Vàng cam
                new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(41, 128, 185)),   // Đang giao - Xanh dương
                new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(52, 152, 219)),   // Đã giao - Xanh nhạt
                new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(39, 174, 96)),    // Hoàn thành - Xanh lá
                new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(231, 76, 60)),    // Hủy - Đỏ
            };

            int colorIdx = 0;
            foreach (DataRow row in dt.Rows)
            {
                series.Add(new PieSeries
                {
                    Title = row["TrangThai"].ToString(),
                    Values = new ChartValues<int> { Convert.ToInt32(row["SoLuong"]) },
                    DataLabels = true,
                    LabelPoint = chartPoint => $"{chartPoint.Y} ({chartPoint.Participation:P0})",
                    Fill = colorIdx < colors.Length ? colors[colorIdx] : null
                });
                colorIdx++;
            }

            pieChart1.Series = series;
            pieChart1.LegendLocation = LegendLocation.Right;
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
    }
}
