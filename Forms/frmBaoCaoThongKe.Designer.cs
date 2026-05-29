namespace VanPhongPham.GUI.Forms
{
    partial class frmBaoCaoThongKe
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCard4 = new System.Windows.Forms.Panel();
            this.lblKhachHangValue = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlCard3 = new System.Windows.Forms.Panel();
            this.lblSPSapHetValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlCard2 = new System.Windows.Forms.Panel();
            this.lblSoDonValue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlCard1 = new System.Windows.Forms.Panel();
            this.lblDoanhThuValue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanelCharts = new System.Windows.Forms.TableLayoutPanel();
            this.pnlChartLeft = new System.Windows.Forms.Panel();
            this.pnlChartRight = new System.Windows.Forms.Panel();
            this.tableLayoutPanelGrids = new System.Windows.Forms.TableLayoutPanel();
            this.dgvTonKho = new System.Windows.Forms.DataGridView();
            this.dgvTopBanChay = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlCard4.SuspendLayout();
            this.pnlCard3.SuspendLayout();
            this.pnlCard2.SuspendLayout();
            this.pnlCard1.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.tableLayoutPanelCharts.SuspendLayout();
            this.tableLayoutPanelGrids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopBanChay)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1644, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(512, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HỆ THỐNG BÁO CÁO THỐNG KÊ";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.pnlCard4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlCard3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlCard2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlCard1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 60);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1644, 100);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pnlCard4
            // 
            this.pnlCard4.BackColor = System.Drawing.Color.White;
            this.pnlCard4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard4.Controls.Add(this.lblKhachHangValue);
            this.pnlCard4.Controls.Add(this.label5);
            this.pnlCard4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard4.Location = new System.Drawing.Point(1238, 5);
            this.pnlCard4.Margin = new System.Windows.Forms.Padding(5);
            this.pnlCard4.Name = "pnlCard4";
            this.pnlCard4.Size = new System.Drawing.Size(401, 90);
            this.pnlCard4.TabIndex = 3;
            // 
            // lblKhachHangValue
            // 
            this.lblKhachHangValue.AutoSize = true;
            this.lblKhachHangValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblKhachHangValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.lblKhachHangValue.Location = new System.Drawing.Point(15, 40);
            this.lblKhachHangValue.Name = "lblKhachHangValue";
            this.lblKhachHangValue.Size = new System.Drawing.Size(33, 38);
            this.lblKhachHangValue.TabIndex = 1;
            this.lblKhachHangValue.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(15, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 28);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tổng Khách Hàng";
            // 
            // pnlCard3
            // 
            this.pnlCard3.BackColor = System.Drawing.Color.White;
            this.pnlCard3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard3.Controls.Add(this.lblSPSapHetValue);
            this.pnlCard3.Controls.Add(this.label4);
            this.pnlCard3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard3.Location = new System.Drawing.Point(827, 5);
            this.pnlCard3.Margin = new System.Windows.Forms.Padding(5);
            this.pnlCard3.Name = "pnlCard3";
            this.pnlCard3.Size = new System.Drawing.Size(401, 90);
            this.pnlCard3.TabIndex = 2;
            // 
            // lblSPSapHetValue
            // 
            this.lblSPSapHetValue.AutoSize = true;
            this.lblSPSapHetValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSPSapHetValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblSPSapHetValue.Location = new System.Drawing.Point(15, 40);
            this.lblSPSapHetValue.Name = "lblSPSapHetValue";
            this.lblSPSapHetValue.Size = new System.Drawing.Size(33, 38);
            this.lblSPSapHetValue.TabIndex = 1;
            this.lblSPSapHetValue.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(15, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 28);
            this.label4.TabIndex = 0;
            this.label4.Text = "Sản Phẩm Sắp Hết";
            // 
            // pnlCard2
            // 
            this.pnlCard2.BackColor = System.Drawing.Color.White;
            this.pnlCard2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard2.Controls.Add(this.lblSoDonValue);
            this.pnlCard2.Controls.Add(this.label3);
            this.pnlCard2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard2.Location = new System.Drawing.Point(416, 5);
            this.pnlCard2.Margin = new System.Windows.Forms.Padding(5);
            this.pnlCard2.Name = "pnlCard2";
            this.pnlCard2.Size = new System.Drawing.Size(401, 90);
            this.pnlCard2.TabIndex = 1;
            // 
            // lblSoDonValue
            // 
            this.lblSoDonValue.AutoSize = true;
            this.lblSoDonValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSoDonValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblSoDonValue.Location = new System.Drawing.Point(15, 40);
            this.lblSoDonValue.Name = "lblSoDonValue";
            this.lblSoDonValue.Size = new System.Drawing.Size(33, 38);
            this.lblSoDonValue.TabIndex = 1;
            this.lblSoDonValue.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(15, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Đơn Hàng Hôm Này";
            // 
            // pnlCard1
            // 
            this.pnlCard1.BackColor = System.Drawing.Color.White;
            this.pnlCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard1.Controls.Add(this.lblDoanhThuValue);
            this.pnlCard1.Controls.Add(this.label2);
            this.pnlCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard1.Location = new System.Drawing.Point(5, 5);
            this.pnlCard1.Margin = new System.Windows.Forms.Padding(5);
            this.pnlCard1.Name = "pnlCard1";
            this.pnlCard1.Size = new System.Drawing.Size(401, 90);
            this.pnlCard1.TabIndex = 0;
            // 
            // lblDoanhThuValue
            // 
            this.lblDoanhThuValue.AutoSize = true;
            this.lblDoanhThuValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDoanhThuValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblDoanhThuValue.Location = new System.Drawing.Point(15, 40);
            this.lblDoanhThuValue.Name = "lblDoanhThuValue";
            this.lblDoanhThuValue.Size = new System.Drawing.Size(51, 38);
            this.lblDoanhThuValue.TabIndex = 1;
            this.lblDoanhThuValue.Text = "0đ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(15, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Doanh Thu Tháng Này";
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.btnRefresh);
            this.pnlFilter.Controls.Add(this.cboNam);
            this.pnlFilter.Controls.Add(this.label6);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 160);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1644, 50);
            this.pnlFilter.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(260, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(140, 35);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Xem Báo Cáo";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // cboNam
            // 
            this.cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNam.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(120, 9);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(120, 38);
            this.cboNam.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(15, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 28);
            this.label6.TabIndex = 0;
            this.label6.Text = "Chọn năm:";
            // 
            // tableLayoutPanelCharts
            // 
            this.tableLayoutPanelCharts.ColumnCount = 2;
            this.tableLayoutPanelCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanelCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanelCharts.Controls.Add(this.pnlChartLeft, 0, 0);
            this.tableLayoutPanelCharts.Controls.Add(this.pnlChartRight, 1, 0);
            this.tableLayoutPanelCharts.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelCharts.Location = new System.Drawing.Point(0, 210);
            this.tableLayoutPanelCharts.Name = "tableLayoutPanelCharts";
            this.tableLayoutPanelCharts.RowCount = 1;
            this.tableLayoutPanelCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCharts.Size = new System.Drawing.Size(1644, 280);
            this.tableLayoutPanelCharts.TabIndex = 3;
            // 
            // pnlChartLeft
            // 
            this.pnlChartLeft.BackColor = System.Drawing.Color.White;
            this.pnlChartLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChartLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartLeft.Location = new System.Drawing.Point(5, 5);
            this.pnlChartLeft.Margin = new System.Windows.Forms.Padding(5);
            this.pnlChartLeft.Name = "pnlChartLeft";
            this.pnlChartLeft.Size = new System.Drawing.Size(894, 270);
            this.pnlChartLeft.TabIndex = 0;
            // 
            // pnlChartRight
            // 
            this.pnlChartRight.BackColor = System.Drawing.Color.White;
            this.pnlChartRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChartRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartRight.Location = new System.Drawing.Point(909, 5);
            this.pnlChartRight.Margin = new System.Windows.Forms.Padding(5);
            this.pnlChartRight.Name = "pnlChartRight";
            this.pnlChartRight.Size = new System.Drawing.Size(730, 270);
            this.pnlChartRight.TabIndex = 1;
            // 
            // tableLayoutPanelGrids
            // 
            this.tableLayoutPanelGrids.ColumnCount = 2;
            this.tableLayoutPanelGrids.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelGrids.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelGrids.Controls.Add(this.dgvTonKho, 1, 0);
            this.tableLayoutPanelGrids.Controls.Add(this.dgvTopBanChay, 0, 0);
            this.tableLayoutPanelGrids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelGrids.Location = new System.Drawing.Point(0, 490);
            this.tableLayoutPanelGrids.Name = "tableLayoutPanelGrids";
            this.tableLayoutPanelGrids.RowCount = 1;
            this.tableLayoutPanelGrids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelGrids.Size = new System.Drawing.Size(1644, 714);
            this.tableLayoutPanelGrids.TabIndex = 4;
            // 
            // dgvTonKho
            // 
            this.dgvTonKho.AllowUserToAddRows = false;
            this.dgvTonKho.AllowUserToDeleteRows = false;
            this.dgvTonKho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTonKho.BackgroundColor = System.Drawing.Color.White;
            this.dgvTonKho.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTonKho.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTonKho.ColumnHeadersHeight = 35;
            this.dgvTonKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTonKho.EnableHeadersVisualStyles = false;
            this.dgvTonKho.Location = new System.Drawing.Point(827, 5);
            this.dgvTonKho.Margin = new System.Windows.Forms.Padding(5);
            this.dgvTonKho.Name = "dgvTonKho";
            this.dgvTonKho.ReadOnly = true;
            this.dgvTonKho.RowHeadersVisible = false;
            this.dgvTonKho.RowHeadersWidth = 62;
            this.dgvTonKho.RowTemplate.Height = 30;
            this.dgvTonKho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTonKho.Size = new System.Drawing.Size(812, 704);
            this.dgvTonKho.TabIndex = 1;
            // 
            // dgvTopBanChay
            // 
            this.dgvTopBanChay.AllowUserToAddRows = false;
            this.dgvTopBanChay.AllowUserToDeleteRows = false;
            this.dgvTopBanChay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopBanChay.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopBanChay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTopBanChay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTopBanChay.ColumnHeadersHeight = 35;
            this.dgvTopBanChay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopBanChay.EnableHeadersVisualStyles = false;
            this.dgvTopBanChay.Location = new System.Drawing.Point(5, 5);
            this.dgvTopBanChay.Margin = new System.Windows.Forms.Padding(5);
            this.dgvTopBanChay.Name = "dgvTopBanChay";
            this.dgvTopBanChay.ReadOnly = true;
            this.dgvTopBanChay.RowHeadersVisible = false;
            this.dgvTopBanChay.RowHeadersWidth = 62;
            this.dgvTopBanChay.RowTemplate.Height = 30;
            this.dgvTopBanChay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopBanChay.Size = new System.Drawing.Size(812, 704);
            this.dgvTopBanChay.TabIndex = 0;
            // 
            // frmBaoCaoThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1644, 1204);
            this.Controls.Add(this.tableLayoutPanelGrids);
            this.Controls.Add(this.tableLayoutPanelCharts);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "frmBaoCaoThongKe";
            this.Text = "Dashboard Thống Kê";
            this.Load += new System.EventHandler(this.frmBaoCaoThongKe_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlCard4.ResumeLayout(false);
            this.pnlCard4.PerformLayout();
            this.pnlCard3.ResumeLayout(false);
            this.pnlCard3.PerformLayout();
            this.pnlCard2.ResumeLayout(false);
            this.pnlCard2.PerformLayout();
            this.pnlCard1.ResumeLayout(false);
            this.pnlCard1.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.tableLayoutPanelCharts.ResumeLayout(false);
            this.tableLayoutPanelGrids.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopBanChay)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Panel pnlCard4;
        private System.Windows.Forms.Label lblKhachHangValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Label lblSPSapHetValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Label lblSoDonValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDoanhThuValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCharts;
        private System.Windows.Forms.Panel pnlChartLeft;
        private System.Windows.Forms.Panel pnlChartRight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGrids;
        private System.Windows.Forms.DataGridView dgvTonKho;
        private System.Windows.Forms.DataGridView dgvTopBanChay;
    }
}