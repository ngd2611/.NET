namespace VanPhongPham.GUI.Forms
{
    partial class frmTraHang
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDonHang = new System.Windows.Forms.ComboBox();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.lblNgayDat = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTongHoan = new System.Windows.Forms.TextBox();
            this.btnTaoPhieu = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTimPhieu = new System.Windows.Forms.TextBox();
            this.btnTimPhieu = new System.Windows.Forms.Button();
            this.dgvPhieuTra = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuTra)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1600, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "HOÀN TRẢ HÀNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(15, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chọn đơn hàng:";
            // 
            // cboDonHang
            // 
            this.cboDonHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDonHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cboDonHang.FormattingEnabled = true;
            this.cboDonHang.Location = new System.Drawing.Point(190, 65);
            this.cboDonHang.Name = "cboDonHang";
            this.cboDonHang.Size = new System.Drawing.Size(500, 30);
            this.cboDonHang.TabIndex = 2;
            this.cboDonHang.SelectedIndexChanged += new System.EventHandler(this.cboDonHang_SelectedIndexChanged);
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblKhachHang.Location = new System.Drawing.Point(730, 68);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(140, 24);
            this.lblKhachHang.TabIndex = 3;
            this.lblKhachHang.Text = "Khách hàng: ---";
            // 
            // lblNgayDat
            // 
            this.lblNgayDat.AutoSize = true;
            this.lblNgayDat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblNgayDat.Location = new System.Drawing.Point(1000, 68);
            this.lblNgayDat.Name = "lblNgayDat";
            this.lblNgayDat.Size = new System.Drawing.Size(113, 24);
            this.lblNgayDat.TabIndex = 4;
            this.lblNgayDat.Text = "Ngày đặt: ---";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.Red;
            this.lblTongTien.Location = new System.Drawing.Point(1250, 68);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(132, 24);
            this.lblTongTien.TabIndex = 5;
            this.lblTongTien.Text = "Tổng tiền: ---";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(15, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(403, 25);
            this.label6.TabIndex = 6;
            this.label6.Text = "Sản phẩm trong đơn (nhập số lượng trả):";
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AllowUserToAddRows = false;
            this.dgvSanPham.AllowUserToDeleteRows = false;
            this.dgvSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.BackgroundColor = System.Drawing.Color.White;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Location = new System.Drawing.Point(15, 142);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.RowHeadersWidth = 30;
            this.dgvSanPham.RowTemplate.Height = 24;
            this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSanPham.Size = new System.Drawing.Size(1565, 250);
            this.dgvSanPham.TabIndex = 7;
            this.dgvSanPham.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(15, 410);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 25);
            this.label7.TabIndex = 8;
            this.label7.Text = "Lý do:";
            // 
            // txtLyDo
            // 
            this.txtLyDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtLyDo.Location = new System.Drawing.Point(100, 410);
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(500, 28);
            this.txtLyDo.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(640, 408);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(176, 26);
            this.label8.TabIndex = 10;
            this.label8.Text = "Tổng tiền hoàn:";
            // 
            // txtTongHoan
            // 
            this.txtTongHoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.txtTongHoan.ForeColor = System.Drawing.Color.Red;
            this.txtTongHoan.Location = new System.Drawing.Point(865, 405);
            this.txtTongHoan.Name = "txtTongHoan";
            this.txtTongHoan.ReadOnly = true;
            this.txtTongHoan.Size = new System.Drawing.Size(300, 32);
            this.txtTongHoan.TabIndex = 11;
            this.txtTongHoan.Text = "0";
            // 
            // btnTaoPhieu
            // 
            this.btnTaoPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaoPhieu.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnTaoPhieu.FlatAppearance.BorderSize = 0;
            this.btnTaoPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnTaoPhieu.ForeColor = System.Drawing.Color.White;
            this.btnTaoPhieu.Location = new System.Drawing.Point(1331, 402);
            this.btnTaoPhieu.Name = "btnTaoPhieu";
            this.btnTaoPhieu.Size = new System.Drawing.Size(230, 40);
            this.btnTaoPhieu.TabIndex = 12;
            this.btnTaoPhieu.Text = "Tạo phiếu trả hàng";
            this.btnTaoPhieu.UseVisualStyleBackColor = false;
            this.btnTaoPhieu.Click += new System.EventHandler(this.btnTaoPhieu_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(15, 460);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(278, 25);
            this.label9.TabIndex = 13;
            this.label9.Text = "Danh sách phiếu trả đã tạo:";
            // 
            // txtTimPhieu
            // 
            this.txtTimPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtTimPhieu.Location = new System.Drawing.Point(360, 457);
            this.txtTimPhieu.Name = "txtTimPhieu";
            this.txtTimPhieu.Size = new System.Drawing.Size(300, 28);
            this.txtTimPhieu.TabIndex = 14;
            // 
            // btnTimPhieu
            // 
            this.btnTimPhieu.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnTimPhieu.FlatAppearance.BorderSize = 0;
            this.btnTimPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnTimPhieu.ForeColor = System.Drawing.Color.White;
            this.btnTimPhieu.Location = new System.Drawing.Point(670, 455);
            this.btnTimPhieu.Name = "btnTimPhieu";
            this.btnTimPhieu.Size = new System.Drawing.Size(80, 32);
            this.btnTimPhieu.TabIndex = 15;
            this.btnTimPhieu.Text = "Tìm";
            this.btnTimPhieu.UseVisualStyleBackColor = false;
            this.btnTimPhieu.Click += new System.EventHandler(this.btnTimPhieu_Click);
            // 
            // dgvPhieuTra
            // 
            this.dgvPhieuTra.AllowUserToAddRows = false;
            this.dgvPhieuTra.AllowUserToDeleteRows = false;
            this.dgvPhieuTra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPhieuTra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuTra.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhieuTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuTra.Location = new System.Drawing.Point(15, 495);
            this.dgvPhieuTra.Name = "dgvPhieuTra";
            this.dgvPhieuTra.ReadOnly = true;
            this.dgvPhieuTra.RowHeadersWidth = 30;
            this.dgvPhieuTra.RowTemplate.Height = 24;
            this.dgvPhieuTra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuTra.Size = new System.Drawing.Size(1565, 390);
            this.dgvPhieuTra.TabIndex = 16;
            // 
            // frmTraHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.dgvPhieuTra);
            this.Controls.Add(this.btnTimPhieu);
            this.Controls.Add(this.txtTimPhieu);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnTaoPhieu);
            this.Controls.Add(this.txtTongHoan);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtLyDo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvSanPham);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.lblNgayDat);
            this.Controls.Add(this.lblKhachHang);
            this.Controls.Add(this.cboDonHang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTraHang";
            this.Text = "Hoàn trả hàng";
            this.Load += new System.EventHandler(this.frmTraHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuTra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboDonHang;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.Label lblNgayDat;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTongHoan;
        private System.Windows.Forms.Button btnTaoPhieu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTimPhieu;
        private System.Windows.Forms.Button btnTimPhieu;
        private System.Windows.Forms.DataGridView dgvPhieuTra;
    }
}