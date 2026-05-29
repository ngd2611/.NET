using System;
using System.Data;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using VanPhongPham.BLL;

namespace VanPhongPham.GUI.Forms
{
    public partial class frmBaoCaoThongKe : Form
    {
        private ThongKeBLL thongKeBLL;

        // Khai báo biểu đồ động, cách ly khỏi Designer
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private LiveCharts.WinForms.PieChart pieChart1;

        public frmBaoCaoThongKe()
        {
            InitializeComponent();

            // Ngắt thiết kế nếu ở chế độ Design Mode của Visual Studio
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
            {
                return;
            }

            btnRefresh.Click += BtnRefresh_Click;
        }

        private void frmBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            try
            {
                thongKeBLL = new ThongKeBLL();

                // Tạo và bơm biểu đồ vào panel
                cartesianChart1 = new LiveCharts.WinForms.CartesianChart { Dock = DockStyle.Fill };
                pnlChartLeft.Controls.Add(cartesianChart1);

                pieChart1 = new LiveCharts.WinForms.PieChart { Dock = DockStyle.Fill };
                pnlChartRight.Controls.Add(pieChart1);

                // Nạp năm vào bộ lọc
                int namHienTai = DateTime.Now.Year;
                cboNam.Items.AddRange(new object[] { namHienTai - 2, namHienTai - 1, namHienTai });
                cboNam.SelectedItem = namHienTai;

                HienThiDuLieuThongKe();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load Form: " + ex.Message, "Lỗi");
            }
        }

        private void HienThiDuLieuThongKe()
        {
            if (thongKeBLL == null) return;

            try
            {
                // 1. Thẻ thông tin
                lblDoanhThuValue.Text = thongKeBLL.LayDoanhThuThangNay().ToString("#,##0") + " đ";
                lblSoDonValue.Text = thongKeBLL.LaySoDonHomNay().ToString() + " đơn";
                lblSPSapHetValue.Text = thongKeBLL.LaySoSPSapHet().ToString() + " mã";
                lblKhachHangValue.Text = thongKeBLL.LayTongKhachHang().ToString() + " người";

                // 2. Bảng dữ liệu
                dgvTopBanChay.DataSource = thongKeBLL.LayTopBanChay(10);
                if (dgvTopBanChay.Columns.Count > 0)
                {
                    dgvTopBanChay.Columns[0].HeaderText = "Mã SP";
                    dgvTopBanChay.Columns[1].HeaderText = "Tên Sản Phẩm";
                    dgvTopBanChay.Columns[2].HeaderText = "SL Bán";
                    dgvTopBanChay.Columns[3].HeaderText = "Doanh Thu";
                    dgvTopBanChay.Columns[3].DefaultCellStyle.Format = "#,##0 đ";
                }

                dgvTonKho.DataSource = thongKeBLL.LayTonKhoCanhBao();
                if (dgvTonKho.Columns.Count > 0)
                {
                    dgvTonKho.Columns[0].HeaderText = "Mã SP";
                    dgvTonKho.Columns[1].HeaderText = "Tên Sản Phẩm";
                    dgvTonKho.Columns[2].HeaderText = "Tồn Kho";
                    dgvTonKho.Columns[3].HeaderText = "Mức Tối Thiểu";
                }

                // 3. Biểu đồ cột
                int namChon = Convert.ToInt32(cboNam.SelectedItem ?? DateTime.Now.Year);
                DataTable dtDoanhThu = thongKeBLL.LayDoanhThuTheoThang(namChon);
                ChartValues<double> vals = new ChartValues<double>();
                string[] labels = new string[12];

                for (int i = 1; i <= 12; i++)
                {
                    labels[i - 1] = "T" + i;
                    DataRow[] rows = dtDoanhThu.Select($"Thang = {i}");
                    vals.Add(rows.Length > 0 ? Convert.ToDouble(rows[0]["DoanhThu"]) : 0);
                }

                cartesianChart1.Series = new SeriesCollection {
                    new ColumnSeries { Title = "Doanh thu", Values = vals }
                };
                cartesianChart1.AxisX.Clear();
                cartesianChart1.AxisX.Add(new Axis { Labels = labels });

                // 4. Biểu đồ tròn
                DataTable dtTrangThai = thongKeBLL.LayThongKeTrangThai();
                SeriesCollection pieSeries = new SeriesCollection();
                foreach (DataRow row in dtTrangThai.Rows)
                {
                    pieSeries.Add(new PieSeries
                    {
                        Title = row["TrangThai"].ToString(),
                        Values = new ChartValues<int> { Convert.ToInt32(row["SoLuong"]) },
                        DataLabels = true
                    });
                }
                pieChart1.Series = pieSeries;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message, "Lỗi");
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            HienThiDuLieuThongKe();
        }
    }
}