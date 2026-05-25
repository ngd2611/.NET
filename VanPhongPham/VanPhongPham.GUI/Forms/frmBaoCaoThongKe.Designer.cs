namespace VanPhongPham.GUI.Forms
{
    partial class frmBaoCaoThongKe
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // ===== TITLE =====
            this.pnlTitle = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();

            // ===== SUMMARY CARDS =====
            this.pnlCards = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlDoanhThu = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDoanhThuTitle = new System.Windows.Forms.Label();
            this.lblDoanhThuValue = new System.Windows.Forms.Label();
            this.pnlSoDon = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSoDonTitle = new System.Windows.Forms.Label();
            this.lblSoDonValue = new System.Windows.Forms.Label();
            this.pnlSPHet = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSPHetTitle = new System.Windows.Forms.Label();
            this.lblSPHetValue = new System.Windows.Forms.Label();
            this.pnlKhachHang = new Guna.UI2.WinForms.Guna2Panel();
            this.lblKhachHangTitle = new System.Windows.Forms.Label();
            this.lblKhachHangValue = new System.Windows.Forms.Label();

            // ===== BỘ LỌC =====
            this.pnlFilter = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNam = new System.Windows.Forms.Label();
            this.cboNam = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();

            // ===== BIỂU ĐỒ =====
            this.pnlChartArea = new System.Windows.Forms.TableLayoutPanel();
            this.pnlChartCot = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChartCot = new System.Windows.Forms.Label();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.pnlChartTron = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChartTron = new System.Windows.Forms.Label();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();

            // ===== BẢNG DỮ LIỆU =====
            this.pnlTableArea = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTopBanChay = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTopBanChay = new System.Windows.Forms.Label();
            this.dgvTopBanChay = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlTonKho = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTonKho = new System.Windows.Forms.Label();
            this.dgvTonKho = new Guna.UI2.WinForms.Guna2DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvTopBanChay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).BeginInit();
            this.pnlTitle.SuspendLayout();
            this.pnlCards.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlChartArea.SuspendLayout();
            this.pnlChartCot.SuspendLayout();
            this.pnlChartTron.SuspendLayout();
            this.pnlTableArea.SuspendLayout();
            this.pnlTopBanChay.SuspendLayout();
            this.pnlTonKho.SuspendLayout();
            this.SuspendLayout();

            // ========== pnlTitle (Dock Top) ==========
            this.pnlTitle.BackColor = System.Drawing.Color.White;
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Size = new System.Drawing.Size(899, 40);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 42, 58);
            this.lblTitle.Location = new System.Drawing.Point(15, 6);
            this.lblTitle.Text = "📊 DASHBOARD & BÁO CÁO";

            // ========== pnlCards (Dock Top, FlowLayout) ==========
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.pnlCards.Location = new System.Drawing.Point(0, 40);
            this.pnlCards.Size = new System.Drawing.Size(899, 80);
            this.pnlCards.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);

            // === Card 1: Doanh thu ===
            this.pnlDoanhThu.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.pnlDoanhThu.BorderRadius = 8;
            this.pnlDoanhThu.Size = new System.Drawing.Size(210, 68);
            this.pnlDoanhThu.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDoanhThu.Controls.Add(this.lblDoanhThuTitle);
            this.pnlDoanhThu.Controls.Add(this.lblDoanhThuValue);

            this.lblDoanhThuTitle.AutoSize = true;
            this.lblDoanhThuTitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDoanhThuTitle.ForeColor = System.Drawing.Color.FromArgb(200, 220, 240);
            this.lblDoanhThuTitle.Location = new System.Drawing.Point(10, 6);
            this.lblDoanhThuTitle.Text = "💰 Doanh thu tháng";

            this.lblDoanhThuValue.AutoSize = true;
            this.lblDoanhThuValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDoanhThuValue.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThuValue.Location = new System.Drawing.Point(10, 28);
            this.lblDoanhThuValue.Text = "0 đ";

            // === Card 2: Số đơn ===
            this.pnlSoDon.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.pnlSoDon.BorderRadius = 8;
            this.pnlSoDon.Size = new System.Drawing.Size(210, 68);
            this.pnlSoDon.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSoDon.Controls.Add(this.lblSoDonTitle);
            this.pnlSoDon.Controls.Add(this.lblSoDonValue);

            this.lblSoDonTitle.AutoSize = true;
            this.lblSoDonTitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblSoDonTitle.ForeColor = System.Drawing.Color.FromArgb(200, 240, 220);
            this.lblSoDonTitle.Location = new System.Drawing.Point(10, 6);
            this.lblSoDonTitle.Text = "📋 Đơn hàng hôm nay";

            this.lblSoDonValue.AutoSize = true;
            this.lblSoDonValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSoDonValue.ForeColor = System.Drawing.Color.White;
            this.lblSoDonValue.Location = new System.Drawing.Point(10, 28);
            this.lblSoDonValue.Text = "0";

            // === Card 3: SP sắp hết ===
            this.pnlSPHet.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.pnlSPHet.BorderRadius = 8;
            this.pnlSPHet.Size = new System.Drawing.Size(210, 68);
            this.pnlSPHet.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSPHet.Controls.Add(this.lblSPHetTitle);
            this.pnlSPHet.Controls.Add(this.lblSPHetValue);

            this.lblSPHetTitle.AutoSize = true;
            this.lblSPHetTitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblSPHetTitle.ForeColor = System.Drawing.Color.FromArgb(255, 210, 210);
            this.lblSPHetTitle.Location = new System.Drawing.Point(10, 6);
            this.lblSPHetTitle.Text = "⚠️ SP sắp hết hàng";

            this.lblSPHetValue.AutoSize = true;
            this.lblSPHetValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSPHetValue.ForeColor = System.Drawing.Color.White;
            this.lblSPHetValue.Location = new System.Drawing.Point(10, 28);
            this.lblSPHetValue.Text = "0";

            // === Card 4: Khách hàng ===
            this.pnlKhachHang.BackColor = System.Drawing.Color.FromArgb(142, 68, 173);
            this.pnlKhachHang.BorderRadius = 8;
            this.pnlKhachHang.Size = new System.Drawing.Size(210, 68);
            this.pnlKhachHang.Margin = new System.Windows.Forms.Padding(4);
            this.pnlKhachHang.Controls.Add(this.lblKhachHangTitle);
            this.pnlKhachHang.Controls.Add(this.lblKhachHangValue);

            this.lblKhachHangTitle.AutoSize = true;
            this.lblKhachHangTitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblKhachHangTitle.ForeColor = System.Drawing.Color.FromArgb(220, 200, 240);
            this.lblKhachHangTitle.Location = new System.Drawing.Point(10, 6);
            this.lblKhachHangTitle.Text = "👥 Tổng khách hàng";

            this.lblKhachHangValue.AutoSize = true;
            this.lblKhachHangValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblKhachHangValue.ForeColor = System.Drawing.Color.White;
            this.lblKhachHangValue.Location = new System.Drawing.Point(10, 28);
            this.lblKhachHangValue.Text = "0";

            this.pnlCards.Controls.Add(this.pnlDoanhThu);
            this.pnlCards.Controls.Add(this.pnlSoDon);
            this.pnlCards.Controls.Add(this.pnlSPHet);
            this.pnlCards.Controls.Add(this.pnlKhachHang);

            // ========== pnlFilter (Dock Top, 38px) ==========
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Controls.Add(this.lblNam);
            this.pnlFilter.Controls.Add(this.cboNam);
            this.pnlFilter.Controls.Add(this.btnRefresh);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 120);
            this.pnlFilter.Size = new System.Drawing.Size(899, 38);

            this.lblNam.AutoSize = true;
            this.lblNam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNam.Location = new System.Drawing.Point(15, 10);
            this.lblNam.Text = "Năm:";

            this.cboNam.BorderRadius = 5;
            this.cboNam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboNam.Location = new System.Drawing.Point(55, 2);
            this.cboNam.Size = new System.Drawing.Size(90, 34);

            this.btnRefresh.BorderRadius = 5;
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(155, 2);
            this.btnRefresh.Size = new System.Drawing.Size(110, 34);
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ========== pnlChartArea (Dock Top, 280px) ==========
            this.pnlChartArea.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChartArea.Location = new System.Drawing.Point(0, 158);
            this.pnlChartArea.Size = new System.Drawing.Size(899, 280);
            this.pnlChartArea.ColumnCount = 2;
            this.pnlChartArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.pnlChartArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.pnlChartArea.RowCount = 1;
            this.pnlChartArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlChartArea.Padding = new System.Windows.Forms.Padding(5);

            // === Chart cột ===
            this.pnlChartCot.BackColor = System.Drawing.Color.White;
            this.pnlChartCot.BorderRadius = 8;
            this.pnlChartCot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartCot.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.pnlChartCot.Controls.Add(this.cartesianChart1);
            this.pnlChartCot.Controls.Add(this.lblChartCot);

            this.lblChartCot.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChartCot.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblChartCot.ForeColor = System.Drawing.Color.FromArgb(30, 42, 58);
            this.lblChartCot.Size = new System.Drawing.Size(480, 25);
            this.lblChartCot.Text = "  📈 Doanh thu theo tháng";
            this.lblChartCot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.cartesianChart1.Dock = System.Windows.Forms.DockStyle.Fill;

            // === Chart tròn (nhiều space hơn) ===
            this.pnlChartTron.BackColor = System.Drawing.Color.White;
            this.pnlChartTron.BorderRadius = 8;
            this.pnlChartTron.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartTron.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.pnlChartTron.Controls.Add(this.pieChart1);
            this.pnlChartTron.Controls.Add(this.lblChartTron);

            this.lblChartTron.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChartTron.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblChartTron.ForeColor = System.Drawing.Color.FromArgb(30, 42, 58);
            this.lblChartTron.Size = new System.Drawing.Size(390, 25);
            this.lblChartTron.Text = "  🥧 Trạng thái đơn hàng";
            this.lblChartTron.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.pieChart1.Dock = System.Windows.Forms.DockStyle.Fill;

            this.pnlChartArea.Controls.Add(this.pnlChartCot, 0, 0);
            this.pnlChartArea.Controls.Add(this.pnlChartTron, 1, 0);

            // ========== pnlTableArea (Dock Fill - phần còn lại) ==========
            this.pnlTableArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTableArea.Location = new System.Drawing.Point(0, 438);
            this.pnlTableArea.Size = new System.Drawing.Size(899, 323);
            this.pnlTableArea.ColumnCount = 2;
            this.pnlTableArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlTableArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlTableArea.RowCount = 1;
            this.pnlTableArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlTableArea.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);

            // === Top bán chạy ===
            this.pnlTopBanChay.BackColor = System.Drawing.Color.White;
            this.pnlTopBanChay.BorderRadius = 8;
            this.pnlTopBanChay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTopBanChay.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.pnlTopBanChay.Controls.Add(this.dgvTopBanChay);
            this.pnlTopBanChay.Controls.Add(this.lblTopBanChay);

            this.lblTopBanChay.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTopBanChay.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTopBanChay.ForeColor = System.Drawing.Color.FromArgb(30, 42, 58);
            this.lblTopBanChay.Size = new System.Drawing.Size(430, 25);
            this.lblTopBanChay.Text = "  🔥 Top sản phẩm bán chạy";
            this.lblTopBanChay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.dgvTopBanChay.AllowUserToAddRows = false;
            this.dgvTopBanChay.ReadOnly = true;
            this.dgvTopBanChay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopBanChay.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopBanChay.ColumnHeadersHeight = 28;
            this.dgvTopBanChay.RowTemplate.Height = 24;
            this.dgvTopBanChay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopBanChay.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.dgvTopBanChay.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTopBanChay.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);

            // === Tồn kho cảnh báo ===
            this.pnlTonKho.BackColor = System.Drawing.Color.White;
            this.pnlTonKho.BorderRadius = 8;
            this.pnlTonKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTonKho.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.pnlTonKho.Controls.Add(this.dgvTonKho);
            this.pnlTonKho.Controls.Add(this.lblTonKho);

            this.lblTonKho.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTonKho.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTonKho.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.lblTonKho.Size = new System.Drawing.Size(430, 25);
            this.lblTonKho.Text = "  ⚠️ Sản phẩm sắp hết hàng";
            this.lblTonKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.dgvTonKho.AllowUserToAddRows = false;
            this.dgvTonKho.ReadOnly = true;
            this.dgvTonKho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTonKho.BackgroundColor = System.Drawing.Color.White;
            this.dgvTonKho.ColumnHeadersHeight = 28;
            this.dgvTonKho.RowTemplate.Height = 24;
            this.dgvTonKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTonKho.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.dgvTonKho.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTonKho.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);

            this.pnlTableArea.Controls.Add(this.pnlTopBanChay, 0, 0);
            this.pnlTableArea.Controls.Add(this.pnlTonKho, 1, 0);

            // ========== frmBaoCaoThongKe ==========
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(899, 761);
            this.Controls.Add(this.pnlTableArea);
            this.Controls.Add(this.pnlChartArea);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.pnlTitle);
            this.Name = "frmBaoCaoThongKe";
            this.Text = "Dashboard & Báo cáo thống kê";
            this.Load += new System.EventHandler(this.frmBaoCaoThongKe_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvTopBanChay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).EndInit();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.pnlCards.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlChartArea.ResumeLayout(false);
            this.pnlChartCot.ResumeLayout(false);
            this.pnlChartTron.ResumeLayout(false);
            this.pnlTableArea.ResumeLayout(false);
            this.pnlTopBanChay.ResumeLayout(false);
            this.pnlTonKho.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel pnlCards;
        private Guna.UI2.WinForms.Guna2Panel pnlDoanhThu;
        private System.Windows.Forms.Label lblDoanhThuTitle;
        private System.Windows.Forms.Label lblDoanhThuValue;
        private Guna.UI2.WinForms.Guna2Panel pnlSoDon;
        private System.Windows.Forms.Label lblSoDonTitle;
        private System.Windows.Forms.Label lblSoDonValue;
        private Guna.UI2.WinForms.Guna2Panel pnlSPHet;
        private System.Windows.Forms.Label lblSPHetTitle;
        private System.Windows.Forms.Label lblSPHetValue;
        private Guna.UI2.WinForms.Guna2Panel pnlKhachHang;
        private System.Windows.Forms.Label lblKhachHangTitle;
        private System.Windows.Forms.Label lblKhachHangValue;
        private Guna.UI2.WinForms.Guna2Panel pnlFilter;
        private System.Windows.Forms.Label lblNam;
        private Guna.UI2.WinForms.Guna2ComboBox cboNam;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private System.Windows.Forms.TableLayoutPanel pnlChartArea;
        private Guna.UI2.WinForms.Guna2Panel pnlChartCot;
        private System.Windows.Forms.Label lblChartCot;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private Guna.UI2.WinForms.Guna2Panel pnlChartTron;
        private System.Windows.Forms.Label lblChartTron;
        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.TableLayoutPanel pnlTableArea;
        private Guna.UI2.WinForms.Guna2Panel pnlTopBanChay;
        private System.Windows.Forms.Label lblTopBanChay;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTopBanChay;
        private Guna.UI2.WinForms.Guna2Panel pnlTonKho;
        private System.Windows.Forms.Label lblTonKho;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTonKho;
    }
}