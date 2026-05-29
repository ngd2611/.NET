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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDoanhThuTitle = new System.Windows.Forms.Label();
            this.lblDoanhThuValue = new System.Windows.Forms.Label();
            this.lblSoDonTitle = new System.Windows.Forms.Label();
            this.lblSoDonValue = new System.Windows.Forms.Label();
            this.lblSPHetTitle = new System.Windows.Forms.Label();
            this.lblSPHetValue = new System.Windows.Forms.Label();
            this.lblKhachHangTitle = new System.Windows.Forms.Label();
            this.lblKhachHangValue = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTrangThai = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dgvTopBanChay = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvTonKho = new System.Windows.Forms.DataGridView();
            this.pnlCard1 = new System.Windows.Forms.Panel();
            this.pnlCard2 = new System.Windows.Forms.Panel();
            this.pnlCard3 = new System.Windows.Forms.Panel();
            this.pnlCard4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTrangThai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopBanChay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).BeginInit();
            this.pnlCard1.SuspendLayout();
            this.pnlCard2.SuspendLayout();
            this.pnlCard3.SuspendLayout();
            this.pnlCard4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1 - DASHBOARD BÁO CÁO
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1600, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "DASHBOARD BÁO CÁO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ===== CARD 1: Doanh thu =====
            // 
            this.pnlCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnlCard1.Controls.Add(this.lblDoanhThuValue);
            this.pnlCard1.Controls.Add(this.lblDoanhThuTitle);
            this.pnlCard1.Location = new System.Drawing.Point(15, 58);
            this.pnlCard1.Size = new System.Drawing.Size(280, 70);
            // 
            this.lblDoanhThuTitle.AutoSize = true;
            this.lblDoanhThuTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblDoanhThuTitle.ForeColor = System.Drawing.Color.FromArgb(200, 220, 240);
            this.lblDoanhThuTitle.Location = new System.Drawing.Point(10, 6);
            this.lblDoanhThuTitle.Text = "Doanh thu tháng";
            // 
            this.lblDoanhThuValue.AutoSize = true;
            this.lblDoanhThuValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblDoanhThuValue.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThuValue.Location = new System.Drawing.Point(10, 30);
            this.lblDoanhThuValue.Text = "0 đ";
            // 
            // ===== CARD 2: Số đơn =====
            // 
            this.pnlCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.pnlCard2.Controls.Add(this.lblSoDonValue);
            this.pnlCard2.Controls.Add(this.lblSoDonTitle);
            this.pnlCard2.Location = new System.Drawing.Point(310, 58);
            this.pnlCard2.Size = new System.Drawing.Size(280, 70);
            // 
            this.lblSoDonTitle.AutoSize = true;
            this.lblSoDonTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblSoDonTitle.ForeColor = System.Drawing.Color.FromArgb(200, 240, 220);
            this.lblSoDonTitle.Location = new System.Drawing.Point(10, 6);
            this.lblSoDonTitle.Text = "Đơn hàng hôm nay";
            // 
            this.lblSoDonValue.AutoSize = true;
            this.lblSoDonValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblSoDonValue.ForeColor = System.Drawing.Color.White;
            this.lblSoDonValue.Location = new System.Drawing.Point(10, 30);
            this.lblSoDonValue.Text = "0";
            // 
            // ===== CARD 3: SP sắp hết =====
            // 
            this.pnlCard3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.pnlCard3.Controls.Add(this.lblSPHetValue);
            this.pnlCard3.Controls.Add(this.lblSPHetTitle);
            this.pnlCard3.Location = new System.Drawing.Point(605, 58);
            this.pnlCard3.Size = new System.Drawing.Size(280, 70);
            // 
            this.lblSPHetTitle.AutoSize = true;
            this.lblSPHetTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblSPHetTitle.ForeColor = System.Drawing.Color.FromArgb(255, 210, 210);
            this.lblSPHetTitle.Location = new System.Drawing.Point(10, 6);
            this.lblSPHetTitle.Text = "SP sắp hết hàng";
            // 
            this.lblSPHetValue.AutoSize = true;
            this.lblSPHetValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblSPHetValue.ForeColor = System.Drawing.Color.White;
            this.lblSPHetValue.Location = new System.Drawing.Point(10, 30);
            this.lblSPHetValue.Text = "0";
            // 
            // ===== CARD 4: Khách hàng =====
            // 
            this.pnlCard4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.pnlCard4.Controls.Add(this.lblKhachHangValue);
            this.pnlCard4.Controls.Add(this.lblKhachHangTitle);
            this.pnlCard4.Location = new System.Drawing.Point(900, 58);
            this.pnlCard4.Size = new System.Drawing.Size(280, 70);
            // 
            this.lblKhachHangTitle.AutoSize = true;
            this.lblKhachHangTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblKhachHangTitle.ForeColor = System.Drawing.Color.FromArgb(220, 200, 240);
            this.lblKhachHangTitle.Location = new System.Drawing.Point(10, 6);
            this.lblKhachHangTitle.Text = "Tổng khách hàng";
            // 
            this.lblKhachHangValue.AutoSize = true;
            this.lblKhachHangValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblKhachHangValue.ForeColor = System.Drawing.Color.White;
            this.lblKhachHangValue.Location = new System.Drawing.Point(10, 30);
            this.lblKhachHangValue.Text = "0";
            // 
            // ===== BỘ LỌC =====
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(15, 145);
            this.label10.Text = "Năm:";
            // 
            this.cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cboNam.Location = new System.Drawing.Point(70, 143);
            this.cboNam.Size = new System.Drawing.Size(100, 28);
            this.cboNam.SelectedIndexChanged += new System.EventHandler(this.cboNam_SelectedIndexChanged);
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(185, 140);
            this.btnRefresh.Size = new System.Drawing.Size(110, 32);
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ===== BIỂU ĐỒ CỘT =====
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(15, 185);
            this.label11.Text = "Doanh thu theo tháng:";
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea1);
            this.chartDoanhThu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartDoanhThu.BackColor = System.Drawing.Color.White;
            this.chartDoanhThu.Location = new System.Drawing.Point(15, 210);
            this.chartDoanhThu.Name = "chartDoanhThu";
            this.chartDoanhThu.Size = new System.Drawing.Size(960, 330);
            this.chartDoanhThu.TabIndex = 30;
            // 
            // ===== BIỂU ĐỒ TRÒN =====
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(1000, 185);
            this.label12.Text = "Trạng thái đơn hàng:";
            // 
            chartArea2.Name = "ChartArea1";
            this.chartTrangThai.ChartAreas.Add(chartArea2);
            this.chartTrangThai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chartTrangThai.BackColor = System.Drawing.Color.White;
            this.chartTrangThai.Location = new System.Drawing.Point(1000, 210);
            this.chartTrangThai.Name = "chartTrangThai";
            this.chartTrangThai.Size = new System.Drawing.Size(580, 330);
            this.chartTrangThai.TabIndex = 31;
            // 
            // ===== TOP BÁN CHẠY =====
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(15, 558);
            this.label13.Text = "Top sản phẩm bán chạy:";
            // 
            this.dgvTopBanChay.AllowUserToAddRows = false;
            this.dgvTopBanChay.AllowUserToDeleteRows = false;
            this.dgvTopBanChay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopBanChay.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopBanChay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopBanChay.Location = new System.Drawing.Point(15, 585);
            this.dgvTopBanChay.ReadOnly = true;
            this.dgvTopBanChay.RowHeadersWidth = 30;
            this.dgvTopBanChay.RowTemplate.Height = 24;
            this.dgvTopBanChay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopBanChay.Size = new System.Drawing.Size(760, 300);
            this.dgvTopBanChay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvTopBanChay.TabIndex = 32;
            // 
            // ===== TỒN KHO CẢNH BÁO =====
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(800, 558);
            this.label14.Text = "Sản phẩm sắp hết hàng:";
            // 
            this.dgvTonKho.AllowUserToAddRows = false;
            this.dgvTonKho.AllowUserToDeleteRows = false;
            this.dgvTonKho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTonKho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTonKho.BackgroundColor = System.Drawing.Color.White;
            this.dgvTonKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTonKho.Location = new System.Drawing.Point(800, 585);
            this.dgvTonKho.ReadOnly = true;
            this.dgvTonKho.RowHeadersWidth = 30;
            this.dgvTonKho.RowTemplate.Height = 24;
            this.dgvTonKho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTonKho.Size = new System.Drawing.Size(780, 300);
            this.dgvTonKho.TabIndex = 33;
            // 
            // frmBaoCaoThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.dgvTonKho);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dgvTopBanChay);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.chartTrangThai);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.chartDoanhThu);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cboNam);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pnlCard4);
            this.Controls.Add(this.pnlCard3);
            this.Controls.Add(this.pnlCard2);
            this.Controls.Add(this.pnlCard1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBaoCaoThongKe";
            this.Text = "Dashboard & Báo cáo thống kê";
            this.Load += new System.EventHandler(this.frmBaoCaoThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTrangThai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopBanChay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).EndInit();
            this.pnlCard1.ResumeLayout(false);
            this.pnlCard1.PerformLayout();
            this.pnlCard2.ResumeLayout(false);
            this.pnlCard2.PerformLayout();
            this.pnlCard3.ResumeLayout(false);
            this.pnlCard3.PerformLayout();
            this.pnlCard4.ResumeLayout(false);
            this.pnlCard4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Label lblDoanhThuTitle;
        private System.Windows.Forms.Label lblDoanhThuValue;
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Label lblSoDonTitle;
        private System.Windows.Forms.Label lblSoDonValue;
        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Label lblSPHetTitle;
        private System.Windows.Forms.Label lblSPHetValue;
        private System.Windows.Forms.Panel pnlCard4;
        private System.Windows.Forms.Label lblKhachHangTitle;
        private System.Windows.Forms.Label lblKhachHangValue;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTrangThai;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgvTopBanChay;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvTonKho;
    }
}