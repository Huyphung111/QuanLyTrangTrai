namespace QL_TrangTrai
{
    partial class frmChiTietThuHoachVatNuoi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.label_NhanVien = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.lblMaChiTiet = new System.Windows.Forms.Label();
            this.txtMaChiTiet = new System.Windows.Forms.TextBox();
            this.lblMaVat = new System.Windows.Forms.Label();
            this.cboMaVat = new System.Windows.Forms.ComboBox();
            this.lblTenVat = new System.Windows.Forms.Label();
            this.txtTenVat = new System.Windows.Forms.TextBox();
            this.lblLoaiThuHoach = new System.Windows.Forms.Label();
            this.cboLoaiThuHoach = new System.Windows.Forms.ComboBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblCanNang = new System.Windows.Forms.Label();
            this.numCanNang = new System.Windows.Forms.NumericUpDown();
            this.lblDonViCanNang = new System.Windows.Forms.Label();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.grpTimKiem = new System.Windows.Forms.GroupBox();
            this.lblTimTheo = new System.Windows.Forms.Label();
            this.cboTimTheo = new System.Windows.Forms.ComboBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.pnlThongKe = new System.Windows.Forms.Panel();
            this.lblTongSoLuong = new System.Windows.Forms.Label();
            this.lblThongKeLoai = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnDong = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCanNang)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.grpTimKiem.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.pnlThongKe.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Black;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblUserInfo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1480, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Black;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1054, 48);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "                                QUẢN LÝ CHI TIẾT THU HOẠCH VẬT NUÔI";
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblUserInfo.ForeColor = System.Drawing.Color.White;
            this.lblUserInfo.Location = new System.Drawing.Point(1000, 28);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(460, 30);
            this.lblUserInfo.TabIndex = 1;
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlMain.Controls.Add(this.grpThongTin);
            this.pnlMain.Controls.Add(this.pnlButtons);
            this.pnlMain.Controls.Add(this.grpTimKiem);
            this.pnlMain.Controls.Add(this.grpDanhSach);
            this.pnlMain.Controls.Add(this.pnlThongKe);
            this.pnlMain.Controls.Add(this.pnlFooter);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 80);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(1480, 799);
            this.pnlMain.TabIndex = 1;
            // 
            // grpThongTin
            // 
            this.grpThongTin.BackColor = System.Drawing.Color.White;
            this.grpThongTin.Controls.Add(this.label_NhanVien);
            this.grpThongTin.Controls.Add(this.cboNhanVien);
            this.grpThongTin.Controls.Add(this.lblMaChiTiet);
            this.grpThongTin.Controls.Add(this.txtMaChiTiet);
            this.grpThongTin.Controls.Add(this.lblMaVat);
            this.grpThongTin.Controls.Add(this.cboMaVat);
            this.grpThongTin.Controls.Add(this.lblTenVat);
            this.grpThongTin.Controls.Add(this.txtTenVat);
            this.grpThongTin.Controls.Add(this.lblLoaiThuHoach);
            this.grpThongTin.Controls.Add(this.cboLoaiThuHoach);
            this.grpThongTin.Controls.Add(this.lblSoLuong);
            this.grpThongTin.Controls.Add(this.numSoLuong);
            this.grpThongTin.Controls.Add(this.lblCanNang);
            this.grpThongTin.Controls.Add(this.numCanNang);
            this.grpThongTin.Controls.Add(this.lblDonViCanNang);
            this.grpThongTin.Controls.Add(this.lblGhiChu);
            this.grpThongTin.Controls.Add(this.txtGhiChu);
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpThongTin.ForeColor = System.Drawing.Color.Black;
            this.grpThongTin.Location = new System.Drawing.Point(215, 23);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(1135, 246);
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "📋 THÔNG TIN CHI TIẾT THU HOẠCH";
            // 
            // label_NhanVien
            // 
            this.label_NhanVien.AutoSize = true;
            this.label_NhanVien.Location = new System.Drawing.Point(5, 182);
            this.label_NhanVien.Name = "label_NhanVien";
            this.label_NhanVien.Size = new System.Drawing.Size(110, 28);
            this.label_NhanVien.TabIndex = 16;
            this.label_NhanVien.Text = "Nhân viên:";
            this.label_NhanVien.Click += new System.EventHandler(this.label_NhanVien_Click);
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(121, 179);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(178, 36);
            this.cboNhanVien.TabIndex = 15;
            this.cboNhanVien.SelectedIndexChanged += new System.EventHandler(this.cboNhanVien_SelectedIndexChanged);
            // 
            // lblMaChiTiet
            // 
            this.lblMaChiTiet.AutoSize = true;
            this.lblMaChiTiet.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMaChiTiet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblMaChiTiet.Location = new System.Drawing.Point(20, 35);
            this.lblMaChiTiet.Name = "lblMaChiTiet";
            this.lblMaChiTiet.Size = new System.Drawing.Size(105, 25);
            this.lblMaChiTiet.TabIndex = 0;
            this.lblMaChiTiet.Text = "Mã chi tiết:";
            // 
            // txtMaChiTiet
            // 
            this.txtMaChiTiet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(224)))));
            this.txtMaChiTiet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaChiTiet.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaChiTiet.Location = new System.Drawing.Point(130, 32);
            this.txtMaChiTiet.Name = "txtMaChiTiet";
            this.txtMaChiTiet.ReadOnly = true;
            this.txtMaChiTiet.Size = new System.Drawing.Size(144, 34);
            this.txtMaChiTiet.TabIndex = 1;
            this.txtMaChiTiet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMaVat
            // 
            this.lblMaVat.AutoSize = true;
            this.lblMaVat.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMaVat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblMaVat.Location = new System.Drawing.Point(280, 35);
            this.lblMaVat.Name = "lblMaVat";
            this.lblMaVat.Size = new System.Drawing.Size(139, 25);
            this.lblMaVat.TabIndex = 2;
            this.lblMaVat.Text = "Chọn vật nuôi: ";
            // 
            // cboMaVat
            // 
            this.cboMaVat.BackColor = System.Drawing.Color.White;
            this.cboMaVat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaVat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMaVat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboMaVat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cboMaVat.FormattingEnabled = true;
            this.cboMaVat.Location = new System.Drawing.Point(446, 28);
            this.cboMaVat.Name = "cboMaVat";
            this.cboMaVat.Size = new System.Drawing.Size(180, 36);
            this.cboMaVat.TabIndex = 3;
            // 
            // lblTenVat
            // 
            this.lblTenVat.AutoSize = true;
            this.lblTenVat.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTenVat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblTenVat.Location = new System.Drawing.Point(648, 35);
            this.lblTenVat.Name = "lblTenVat";
            this.lblTenVat.Size = new System.Drawing.Size(118, 25);
            this.lblTenVat.TabIndex = 4;
            this.lblTenVat.Text = "Tên vật nuôi:";
            // 
            // txtTenVat
            // 
            this.txtTenVat.BackColor = System.Drawing.Color.White;
            this.txtTenVat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenVat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.txtTenVat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.txtTenVat.Location = new System.Drawing.Point(793, 30);
            this.txtTenVat.Name = "txtTenVat";
            this.txtTenVat.ReadOnly = true;
            this.txtTenVat.Size = new System.Drawing.Size(310, 34);
            this.txtTenVat.TabIndex = 5;
            // 
            // lblLoaiThuHoach
            // 
            this.lblLoaiThuHoach.AutoSize = true;
            this.lblLoaiThuHoach.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblLoaiThuHoach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblLoaiThuHoach.Location = new System.Drawing.Point(20, 75);
            this.lblLoaiThuHoach.Name = "lblLoaiThuHoach";
            this.lblLoaiThuHoach.Size = new System.Drawing.Size(146, 25);
            this.lblLoaiThuHoach.TabIndex = 6;
            this.lblLoaiThuHoach.Text = "Loại thu hoạch: ";
            // 
            // cboLoaiThuHoach
            // 
            this.cboLoaiThuHoach.BackColor = System.Drawing.Color.White;
            this.cboLoaiThuHoach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiThuHoach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLoaiThuHoach.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiThuHoach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cboLoaiThuHoach.FormattingEnabled = true;
            this.cboLoaiThuHoach.Items.AddRange(new object[] {
            "Giết mổ",
            "Trứng",
            "Sữa",
            "Khác"});
            this.cboLoaiThuHoach.Location = new System.Drawing.Point(167, 74);
            this.cboLoaiThuHoach.Name = "cboLoaiThuHoach";
            this.cboLoaiThuHoach.Size = new System.Drawing.Size(107, 36);
            this.cboLoaiThuHoach.TabIndex = 7;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSoLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblSoLuong.Location = new System.Drawing.Point(323, 80);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(96, 25);
            this.lblSoLuong.TabIndex = 8;
            this.lblSoLuong.Text = "Số lượng: ";
            this.lblSoLuong.Click += new System.EventHandler(this.lblSoLuong_Click);
            // 
            // numSoLuong
            // 
            this.numSoLuong.BackColor = System.Drawing.Color.White;
            this.numSoLuong.DecimalPlaces = 2;
            this.numSoLuong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numSoLuong.Location = new System.Drawing.Point(446, 75);
            this.numSoLuong.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(120, 34);
            this.numSoLuong.TabIndex = 9;
            this.numSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSoLuong.ThousandsSeparator = true;
            this.numSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCanNang
            // 
            this.lblCanNang.AutoSize = true;
            this.lblCanNang.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCanNang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblCanNang.Location = new System.Drawing.Point(664, 77);
            this.lblCanNang.Name = "lblCanNang";
            this.lblCanNang.Size = new System.Drawing.Size(102, 25);
            this.lblCanNang.TabIndex = 10;
            this.lblCanNang.Text = "Cân nặng: ";
            // 
            // numCanNang
            // 
            this.numCanNang.BackColor = System.Drawing.Color.White;
            this.numCanNang.DecimalPlaces = 2;
            this.numCanNang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numCanNang.Location = new System.Drawing.Point(793, 72);
            this.numCanNang.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numCanNang.Name = "numCanNang";
            this.numCanNang.Size = new System.Drawing.Size(120, 34);
            this.numCanNang.TabIndex = 11;
            this.numCanNang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numCanNang.ThousandsSeparator = true;
            // 
            // lblDonViCanNang
            // 
            this.lblDonViCanNang.AutoSize = true;
            this.lblDonViCanNang.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblDonViCanNang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblDonViCanNang.Location = new System.Drawing.Point(929, 75);
            this.lblDonViCanNang.Name = "lblDonViCanNang";
            this.lblDonViCanNang.Size = new System.Drawing.Size(31, 25);
            this.lblDonViCanNang.TabIndex = 12;
            this.lblDonViCanNang.Text = "kg";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblGhiChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblGhiChu.Location = new System.Drawing.Point(20, 115);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(81, 25);
            this.lblGhiChu.TabIndex = 13;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BackColor = System.Drawing.Color.White;
            this.txtGhiChu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGhiChu.Location = new System.Drawing.Point(121, 112);
            this.txtGhiChu.MaxLength = 255;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(964, 34);
            this.txtGhiChu.TabIndex = 14;
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.Transparent;
            this.pnlButtons.Controls.Add(this.btnThem);
            this.pnlButtons.Controls.Add(this.btnSua);
            this.pnlButtons.Controls.Add(this.btnXoa);
            this.pnlButtons.Controls.Add(this.btnLamMoi);
            this.pnlButtons.Location = new System.Drawing.Point(215, 275);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(1135, 64);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Green;
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(20, 5);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 40);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "➕ THÊM";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(153, 5);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(120, 40);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "✏️ SỬA";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(290, 5);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(120, 40);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "🗑️ XÓA";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(425, 5);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(130, 40);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "🔄 LÀM MỚI";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // grpTimKiem
            // 
            this.grpTimKiem.BackColor = System.Drawing.Color.White;
            this.grpTimKiem.Controls.Add(this.lblTimTheo);
            this.grpTimKiem.Controls.Add(this.cboTimTheo);
            this.grpTimKiem.Controls.Add(this.txtTimKiem);
            this.grpTimKiem.Controls.Add(this.btnTimKiem);
            this.grpTimKiem.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.grpTimKiem.Location = new System.Drawing.Point(215, 330);
            this.grpTimKiem.Name = "grpTimKiem";
            this.grpTimKiem.Size = new System.Drawing.Size(1135, 55);
            this.grpTimKiem.TabIndex = 2;
            this.grpTimKiem.TabStop = false;
            this.grpTimKiem.Text = "🔍 TÌM KIẾM";
            // 
            // lblTimTheo
            // 
            this.lblTimTheo.AutoSize = true;
            this.lblTimTheo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTimTheo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.lblTimTheo.Location = new System.Drawing.Point(148, 19);
            this.lblTimTheo.Name = "lblTimTheo";
            this.lblTimTheo.Size = new System.Drawing.Size(90, 25);
            this.lblTimTheo.TabIndex = 0;
            this.lblTimTheo.Text = "Tìm theo:";
            // 
            // cboTimTheo
            // 
            this.cboTimTheo.BackColor = System.Drawing.Color.White;
            this.cboTimTheo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimTheo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTimTheo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTimTheo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cboTimTheo.FormattingEnabled = true;
            this.cboTimTheo.Items.AddRange(new object[] {
            "Mã chi tiết",
            "Tên vật nuôi",
            "Loại thu hoạch"});
            this.cboTimTheo.Location = new System.Drawing.Point(260, 15);
            this.cboTimTheo.Name = "cboTimTheo";
            this.cboTimTheo.Size = new System.Drawing.Size(150, 36);
            this.cboTimTheo.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BackColor = System.Drawing.Color.White;
            this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Location = new System.Drawing.Point(446, 14);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(300, 34);
            this.txtTimKiem.TabIndex = 2;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(776, 14);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 34);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "🔍 TÌM";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // grpDanhSach
            // 
            this.grpDanhSach.BackColor = System.Drawing.Color.White;
            this.grpDanhSach.Controls.Add(this.dgvChiTiet);
            this.grpDanhSach.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpDanhSach.ForeColor = System.Drawing.Color.Black;
            this.grpDanhSach.Location = new System.Drawing.Point(215, 390);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new System.Drawing.Size(1135, 230);
            this.grpDanhSach.TabIndex = 3;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "📊 DANH SÁCH CHI TIẾT THU HOẠCH VẬT NUÔI";
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
            this.dgvChiTiet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTiet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChiTiet.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvChiTiet.ColumnHeadersHeight = 40;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(227)))), ((int)(((byte)(212)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTiet.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvChiTiet.EnableHeadersVisualStyles = false;
            this.dgvChiTiet.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvChiTiet.Location = new System.Drawing.Point(10, 33);
            this.dgvChiTiet.MultiSelect = false;
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.RowHeadersWidth = 62;
            this.dgvChiTiet.RowTemplate.Height = 35;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(1108, 187);
            this.dgvChiTiet.TabIndex = 0;
            this.dgvChiTiet.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTiet_CellContentClick);
            // 
            // pnlThongKe
            // 
            this.pnlThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(227)))), ((int)(((byte)(212)))));
            this.pnlThongKe.Controls.Add(this.lblTongSoLuong);
            this.pnlThongKe.Controls.Add(this.lblThongKeLoai);
            this.pnlThongKe.Location = new System.Drawing.Point(215, 626);
            this.pnlThongKe.Name = "pnlThongKe";
            this.pnlThongKe.Size = new System.Drawing.Size(1135, 40);
            this.pnlThongKe.TabIndex = 4;
            // 
            // lblTongSoLuong
            // 
            this.lblTongSoLuong.AutoSize = true;
            this.lblTongSoLuong.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongSoLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.lblTongSoLuong.Location = new System.Drawing.Point(15, 10);
            this.lblTongSoLuong.Name = "lblTongSoLuong";
            this.lblTongSoLuong.Size = new System.Drawing.Size(368, 28);
            this.lblTongSoLuong.TabIndex = 0;
            this.lblTongSoLuong.Text = "📦 Tổng số lượng: 0  |  Cân nặng: 0 kg";
            // 
            // lblThongKeLoai
            // 
            this.lblThongKeLoai.AutoSize = true;
            this.lblThongKeLoai.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblThongKeLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.lblThongKeLoai.Location = new System.Drawing.Point(400, 10);
            this.lblThongKeLoai.Name = "lblThongKeLoai";
            this.lblThongKeLoai.Size = new System.Drawing.Size(425, 28);
            this.lblThongKeLoai.TabIndex = 1;
            this.lblThongKeLoai.Text = "📈 Giết mổ: 0  |  Trứng: 0  |  Sữa: 0  |  Khác: 0";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.Transparent;
            this.pnlFooter.Controls.Add(this.btnDong);
            this.pnlFooter.Location = new System.Drawing.Point(215, 671);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1135, 45);
            this.pnlFooter.TabIndex = 5;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(1005, 5);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(130, 38);
            this.btnDong.TabIndex = 0;
            this.btnDong.Text = "❌ ĐÓNG";
            this.btnDong.UseVisualStyleBackColor = false;
            // 
            // frmChiTietThuHoachVatNuoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1480, 879);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmChiTietThuHoachVatNuoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Chi tiết Thu hoạch Vật nuôi - Trang Trại Xanh Phát Đạt";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCanNang)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.grpTimKiem.ResumeLayout(false);
            this.grpTimKiem.PerformLayout();
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.pnlThongKe.ResumeLayout(false);
            this.pnlThongKe.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // Header
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUserInfo;

        // Main Panel
        private System.Windows.Forms.Panel pnlMain;

        // GroupBox Thông tin
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblMaChiTiet;
        private System.Windows.Forms.TextBox txtMaChiTiet;
        private System.Windows.Forms.Label lblMaVat;
        private System.Windows.Forms.ComboBox cboMaVat;
        private System.Windows.Forms.Label lblTenVat;
        private System.Windows.Forms.TextBox txtTenVat;
        private System.Windows.Forms.Label lblLoaiThuHoach;
        private System.Windows.Forms.ComboBox cboLoaiThuHoach;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Label lblCanNang;
        private System.Windows.Forms.NumericUpDown numCanNang;
        private System.Windows.Forms.Label lblDonViCanNang;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;

        // Panel Buttons
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;

        // GroupBox Tìm kiếm
        private System.Windows.Forms.GroupBox grpTimKiem;
        private System.Windows.Forms.Label lblTimTheo;
        private System.Windows.Forms.ComboBox cboTimTheo;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;

        // GroupBox Danh sách
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.DataGridView dgvChiTiet;

        // Panel Thống kê
        private System.Windows.Forms.Panel pnlThongKe;
        private System.Windows.Forms.Label lblTongSoLuong;
        private System.Windows.Forms.Label lblThongKeLoai;

        // Panel Footer
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnDong;

        // ToolTip
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label label_NhanVien;
    }
}