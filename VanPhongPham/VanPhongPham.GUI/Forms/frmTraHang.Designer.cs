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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlChonDon = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChonDon = new System.Windows.Forms.Label();
            this.cboDonHang = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.lblNgayDat = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblThongTinDon = new System.Windows.Forms.Label();
            this.pnlSanPham = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvSanPham = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblSanPhamTra = new System.Windows.Forms.Label();
            this.pnlTaoPhieu = new Guna.UI2.WinForms.Guna2Panel();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.txtLyDo = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTongHoan = new System.Windows.Forms.Label();
            this.txtTongHoan = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnTaoPhieu = new Guna.UI2.WinForms.Guna2Button();
            this.pnlDanhSach = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvPhieuTra = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlDanhSachHeader = new System.Windows.Forms.Panel();
            this.lblDanhSachPhieu = new System.Windows.Forms.Label();
            this.txtTimPhieu = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnTimPhieu = new Guna.UI2.WinForms.Guna2Button();
            this.pnlHeader.SuspendLayout();
            this.pnlChonDon.SuspendLayout();
            this.pnlSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.pnlTaoPhieu.SuspendLayout();
            this.pnlDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuTra)).BeginInit();
            this.pnlDanhSachHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(899, 45);
            this.pnlHeader.TabIndex = 4;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.lblTitle.Location = new System.Drawing.Point(15, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(247, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "↩️ HOÀN TRẢ HÀNG";
            // 
            // pnlChonDon
            // 
            this.pnlChonDon.BackColor = System.Drawing.Color.White;
            this.pnlChonDon.Controls.Add(this.lblChonDon);
            this.pnlChonDon.Controls.Add(this.cboDonHang);
            this.pnlChonDon.Controls.Add(this.lblKhachHang);
            this.pnlChonDon.Controls.Add(this.lblNgayDat);
            this.pnlChonDon.Controls.Add(this.lblTongTien);
            this.pnlChonDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChonDon.Location = new System.Drawing.Point(0, 45);
            this.pnlChonDon.Name = "pnlChonDon";
            this.pnlChonDon.Size = new System.Drawing.Size(899, 80);
            this.pnlChonDon.TabIndex = 3;
            // 
            // lblChonDon
            // 
            this.lblChonDon.AutoSize = true;
            this.lblChonDon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblChonDon.Location = new System.Drawing.Point(15, 10);
            this.lblChonDon.Name = "lblChonDon";
            this.lblChonDon.Size = new System.Drawing.Size(119, 20);
            this.lblChonDon.TabIndex = 0;
            this.lblChonDon.Text = "Chọn đơn hàng:";
            // 
            // cboDonHang
            // 
            this.cboDonHang.BackColor = System.Drawing.Color.Transparent;
            this.cboDonHang.BorderRadius = 5;
            this.cboDonHang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDonHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDonHang.FocusedColor = System.Drawing.Color.Empty;
            this.cboDonHang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboDonHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboDonHang.ItemHeight = 30;
            this.cboDonHang.Location = new System.Drawing.Point(140, 3);
            this.cboDonHang.Name = "cboDonHang";
            this.cboDonHang.Size = new System.Drawing.Size(350, 36);
            this.cboDonHang.TabIndex = 1;
            this.cboDonHang.SelectedIndexChanged += new System.EventHandler(this.cboDonHang_SelectedIndexChanged);
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKhachHang.Location = new System.Drawing.Point(15, 48);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(111, 20);
            this.lblKhachHang.TabIndex = 2;
            this.lblKhachHang.Text = "Khách hàng: ---";
            // 
            // lblNgayDat
            // 
            this.lblNgayDat.AutoSize = true;
            this.lblNgayDat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNgayDat.Location = new System.Drawing.Point(300, 48);
            this.lblNgayDat.Name = "lblNgayDat";
            this.lblNgayDat.Size = new System.Drawing.Size(95, 20);
            this.lblNgayDat.TabIndex = 3;
            this.lblNgayDat.Text = "Ngày đặt: ---";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTongTien.Location = new System.Drawing.Point(550, 48);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(102, 20);
            this.lblTongTien.TabIndex = 4;
            this.lblTongTien.Text = "Tổng tiền: ---";
            // 
            // lblThongTinDon
            // 
            this.lblThongTinDon.Location = new System.Drawing.Point(0, 0);
            this.lblThongTinDon.Name = "lblThongTinDon";
            this.lblThongTinDon.Size = new System.Drawing.Size(100, 23);
            this.lblThongTinDon.TabIndex = 0;
            // 
            // pnlSanPham
            // 
            this.pnlSanPham.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlSanPham.Controls.Add(this.dgvSanPham);
            this.pnlSanPham.Controls.Add(this.lblSanPhamTra);
            this.pnlSanPham.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSanPham.Location = new System.Drawing.Point(0, 125);
            this.pnlSanPham.Name = "pnlSanPham";
            this.pnlSanPham.Size = new System.Drawing.Size(899, 195);
            this.pnlSanPham.TabIndex = 2;
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AllowUserToAddRows = false;
            this.dgvSanPham.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.dgvSanPham.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvSanPham.ColumnHeadersHeight = 32;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSanPham.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSanPham.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSanPham.Location = new System.Drawing.Point(0, 25);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.RowHeadersVisible = false;
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.RowTemplate.Height = 28;
            this.dgvSanPham.Size = new System.Drawing.Size(899, 170);
            this.dgvSanPham.TabIndex = 0;
            this.dgvSanPham.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.dgvSanPham.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvSanPham.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvSanPham.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvSanPham.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvSanPham.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvSanPham.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSanPham.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.dgvSanPham.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSanPham.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvSanPham.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvSanPham.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSanPham.ThemeStyle.HeaderStyle.Height = 32;
            this.dgvSanPham.ThemeStyle.ReadOnly = false;
            this.dgvSanPham.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSanPham.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSanPham.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSanPham.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvSanPham.ThemeStyle.RowsStyle.Height = 28;
            this.dgvSanPham.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSanPham.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvSanPham.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellValueChanged);
            // 
            // lblSanPhamTra
            // 
            this.lblSanPhamTra.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSanPhamTra.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSanPhamTra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.lblSanPhamTra.Location = new System.Drawing.Point(0, 0);
            this.lblSanPhamTra.Name = "lblSanPhamTra";
            this.lblSanPhamTra.Size = new System.Drawing.Size(899, 25);
            this.lblSanPhamTra.TabIndex = 1;
            this.lblSanPhamTra.Text = "    📦 Sản phẩm trong đơn (nhập số lượng trả):";
            this.lblSanPhamTra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTaoPhieu
            // 
            this.pnlTaoPhieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlTaoPhieu.Controls.Add(this.lblLyDo);
            this.pnlTaoPhieu.Controls.Add(this.txtLyDo);
            this.pnlTaoPhieu.Controls.Add(this.lblTongHoan);
            this.pnlTaoPhieu.Controls.Add(this.txtTongHoan);
            this.pnlTaoPhieu.Controls.Add(this.btnTaoPhieu);
            this.pnlTaoPhieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTaoPhieu.Location = new System.Drawing.Point(0, 320);
            this.pnlTaoPhieu.Name = "pnlTaoPhieu";
            this.pnlTaoPhieu.Size = new System.Drawing.Size(899, 50);
            this.pnlTaoPhieu.TabIndex = 1;
            // 
            // lblLyDo
            // 
            this.lblLyDo.AutoSize = true;
            this.lblLyDo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLyDo.Location = new System.Drawing.Point(15, 14);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Size = new System.Drawing.Size(51, 20);
            this.lblLyDo.TabIndex = 0;
            this.lblLyDo.Text = "Lý do:";
            // 
            // txtLyDo
            // 
            this.txtLyDo.BorderRadius = 5;
            this.txtLyDo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLyDo.DefaultText = "";
            this.txtLyDo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLyDo.Location = new System.Drawing.Point(70, 7);
            this.txtLyDo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.PlaceholderText = "Nhập lý do trả hàng...";
            this.txtLyDo.SelectedText = "";
            this.txtLyDo.Size = new System.Drawing.Size(280, 36);
            this.txtLyDo.TabIndex = 1;
            // 
            // lblTongHoan
            // 
            this.lblTongHoan.AutoSize = true;
            this.lblTongHoan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTongHoan.Location = new System.Drawing.Point(370, 14);
            this.lblTongHoan.Name = "lblTongHoan";
            this.lblTongHoan.Size = new System.Drawing.Size(88, 20);
            this.lblTongHoan.TabIndex = 2;
            this.lblTongHoan.Text = "Tổng hoàn:";
            // 
            // txtTongHoan
            // 
            this.txtTongHoan.BorderRadius = 5;
            this.txtTongHoan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTongHoan.DefaultText = "0";
            this.txtTongHoan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtTongHoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.txtTongHoan.Location = new System.Drawing.Point(455, 7);
            this.txtTongHoan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTongHoan.Name = "txtTongHoan";
            this.txtTongHoan.PlaceholderText = "";
            this.txtTongHoan.ReadOnly = true;
            this.txtTongHoan.SelectedText = "";
            this.txtTongHoan.Size = new System.Drawing.Size(150, 36);
            this.txtTongHoan.TabIndex = 3;
            // 
            // btnTaoPhieu
            // 
            this.btnTaoPhieu.BorderRadius = 5;
            this.btnTaoPhieu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnTaoPhieu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTaoPhieu.ForeColor = System.Drawing.Color.White;
            this.btnTaoPhieu.Location = new System.Drawing.Point(625, 7);
            this.btnTaoPhieu.Name = "btnTaoPhieu";
            this.btnTaoPhieu.Size = new System.Drawing.Size(180, 36);
            this.btnTaoPhieu.TabIndex = 4;
            this.btnTaoPhieu.Text = "✅ Tạo phiếu trả hàng";
            this.btnTaoPhieu.Click += new System.EventHandler(this.btnTaoPhieu_Click);
            // 
            // pnlDanhSach
            // 
            this.pnlDanhSach.BackColor = System.Drawing.Color.White;
            this.pnlDanhSach.Controls.Add(this.dgvPhieuTra);
            this.pnlDanhSach.Controls.Add(this.pnlDanhSachHeader);
            this.pnlDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDanhSach.Location = new System.Drawing.Point(0, 370);
            this.pnlDanhSach.Name = "pnlDanhSach";
            this.pnlDanhSach.Size = new System.Drawing.Size(899, 391);
            this.pnlDanhSach.TabIndex = 0;
            // 
            // dgvPhieuTra
            // 
            this.dgvPhieuTra.AllowUserToAddRows = false;
            this.dgvPhieuTra.AllowUserToDeleteRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.dgvPhieuTra.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhieuTra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvPhieuTra.ColumnHeadersHeight = 32;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPhieuTra.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvPhieuTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhieuTra.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPhieuTra.Location = new System.Drawing.Point(0, 40);
            this.dgvPhieuTra.Name = "dgvPhieuTra";
            this.dgvPhieuTra.ReadOnly = true;
            this.dgvPhieuTra.RowHeadersVisible = false;
            this.dgvPhieuTra.RowHeadersWidth = 51;
            this.dgvPhieuTra.RowTemplate.Height = 28;
            this.dgvPhieuTra.Size = new System.Drawing.Size(899, 351);
            this.dgvPhieuTra.TabIndex = 0;
            this.dgvPhieuTra.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.dgvPhieuTra.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvPhieuTra.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvPhieuTra.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvPhieuTra.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvPhieuTra.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvPhieuTra.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPhieuTra.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.dgvPhieuTra.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPhieuTra.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvPhieuTra.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPhieuTra.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPhieuTra.ThemeStyle.HeaderStyle.Height = 32;
            this.dgvPhieuTra.ThemeStyle.ReadOnly = true;
            this.dgvPhieuTra.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPhieuTra.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPhieuTra.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPhieuTra.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvPhieuTra.ThemeStyle.RowsStyle.Height = 28;
            this.dgvPhieuTra.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPhieuTra.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // pnlDanhSachHeader
            // 
            this.pnlDanhSachHeader.BackColor = System.Drawing.Color.White;
            this.pnlDanhSachHeader.Controls.Add(this.lblDanhSachPhieu);
            this.pnlDanhSachHeader.Controls.Add(this.txtTimPhieu);
            this.pnlDanhSachHeader.Controls.Add(this.btnTimPhieu);
            this.pnlDanhSachHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDanhSachHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlDanhSachHeader.Name = "pnlDanhSachHeader";
            this.pnlDanhSachHeader.Size = new System.Drawing.Size(899, 40);
            this.pnlDanhSachHeader.TabIndex = 1;
            // 
            // lblDanhSachPhieu
            // 
            this.lblDanhSachPhieu.AutoSize = true;
            this.lblDanhSachPhieu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDanhSachPhieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.lblDanhSachPhieu.Location = new System.Drawing.Point(10, 10);
            this.lblDanhSachPhieu.Name = "lblDanhSachPhieu";
            this.lblDanhSachPhieu.Size = new System.Drawing.Size(259, 23);
            this.lblDanhSachPhieu.TabIndex = 0;
            this.lblDanhSachPhieu.Text = "📝 Danh sách phiếu trả đã tạo:";
            // 
            // txtTimPhieu
            // 
            this.txtTimPhieu.BorderRadius = 5;
            this.txtTimPhieu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimPhieu.DefaultText = "";
            this.txtTimPhieu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimPhieu.Location = new System.Drawing.Point(310, 3);
            this.txtTimPhieu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTimPhieu.Name = "txtTimPhieu";
            this.txtTimPhieu.PlaceholderText = "🔍 Tìm phiếu trả...";
            this.txtTimPhieu.SelectedText = "";
            this.txtTimPhieu.Size = new System.Drawing.Size(200, 34);
            this.txtTimPhieu.TabIndex = 1;
            // 
            // btnTimPhieu
            // 
            this.btnTimPhieu.BorderRadius = 5;
            this.btnTimPhieu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnTimPhieu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTimPhieu.ForeColor = System.Drawing.Color.White;
            this.btnTimPhieu.Location = new System.Drawing.Point(520, 3);
            this.btnTimPhieu.Name = "btnTimPhieu";
            this.btnTimPhieu.Size = new System.Drawing.Size(104, 34);
            this.btnTimPhieu.TabIndex = 2;
            this.btnTimPhieu.Text = "🔍 Tìm";
            this.btnTimPhieu.Click += new System.EventHandler(this.btnTimPhieu_Click);
            // 
            // frmTraHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(899, 761);
            this.Controls.Add(this.pnlDanhSach);
            this.Controls.Add(this.pnlTaoPhieu);
            this.Controls.Add(this.pnlSanPham);
            this.Controls.Add(this.pnlChonDon);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmTraHang";
            this.Text = "Hoàn trả hàng";
            this.Load += new System.EventHandler(this.frmTraHang_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlChonDon.ResumeLayout(false);
            this.pnlChonDon.PerformLayout();
            this.pnlSanPham.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.pnlTaoPhieu.ResumeLayout(false);
            this.pnlTaoPhieu.PerformLayout();
            this.pnlDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuTra)).EndInit();
            this.pnlDanhSachHeader.ResumeLayout(false);
            this.pnlDanhSachHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlChonDon;
        private System.Windows.Forms.Label lblChonDon;
        private Guna.UI2.WinForms.Guna2ComboBox cboDonHang;
        private System.Windows.Forms.Label lblThongTinDon;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.Label lblNgayDat;
        private System.Windows.Forms.Label lblTongTien;
        private Guna.UI2.WinForms.Guna2Panel pnlSanPham;
        private System.Windows.Forms.Label lblSanPhamTra;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSanPham;
        private Guna.UI2.WinForms.Guna2Panel pnlTaoPhieu;
        private System.Windows.Forms.Label lblLyDo;
        private Guna.UI2.WinForms.Guna2TextBox txtLyDo;
        private System.Windows.Forms.Label lblTongHoan;
        private Guna.UI2.WinForms.Guna2TextBox txtTongHoan;
        private Guna.UI2.WinForms.Guna2Button btnTaoPhieu;
        private Guna.UI2.WinForms.Guna2Panel pnlDanhSach;
        private System.Windows.Forms.Panel pnlDanhSachHeader;
        private System.Windows.Forms.Label lblDanhSachPhieu;
        private Guna.UI2.WinForms.Guna2DataGridView dgvPhieuTra;
        private Guna.UI2.WinForms.Guna2TextBox txtTimPhieu;
        private Guna.UI2.WinForms.Guna2Button btnTimPhieu;
    }
}