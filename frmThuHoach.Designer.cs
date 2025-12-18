namespace QL_TrangTrai
{
    partial class frmThuHoach
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.lblMaTH = new System.Windows.Forms.Label();
            this.txtMaTH = new System.Windows.Forms.TextBox();
            this.lblNgayTH = new System.Windows.Forms.Label();
            this.dtpNgayTH = new System.Windows.Forms.DateTimePicker();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.lblLoaiTH = new System.Windows.Forms.Label();
            this.rbCayTrong = new System.Windows.Forms.RadioButton();
            this.rbVatNuoi = new System.Windows.Forms.RadioButton();
            this.lblChiTietCT = new System.Windows.Forms.Label();
            this.cboChiTietCT = new System.Windows.Forms.ComboBox();
            this.lblChiTietVN = new System.Windows.Forms.Label();
            this.cboChiTietVN = new System.Windows.Forms.ComboBox();
            this.lblTongSL = new System.Windows.Forms.Label();
            this.nudTongSL = new System.Windows.Forms.NumericUpDown();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.gbTimKiem = new System.Windows.Forms.GroupBox();
            this.lblTimTheo = new System.Windows.Forms.Label();
            this.cboTimTheo = new System.Windows.Forms.ComboBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.gbDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvThuHoach = new System.Windows.Forms.DataGridView();
            this.pnlThongKe = new System.Windows.Forms.Panel();
            this.lblThongKe = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.gbThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTongSL)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.gbTimKiem.SuspendLayout();
            this.gbDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuHoach)).BeginInit();
            this.pnlThongKe.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1265, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Black;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1265, 80);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ THU HOẠCH";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbThongTin
            // 
            this.gbThongTin.Controls.Add(this.lblMaTH);
            this.gbThongTin.Controls.Add(this.txtMaTH);
            this.gbThongTin.Controls.Add(this.lblNgayTH);
            this.gbThongTin.Controls.Add(this.dtpNgayTH);
            this.gbThongTin.Controls.Add(this.lblNhanVien);
            this.gbThongTin.Controls.Add(this.cboNhanVien);
            this.gbThongTin.Controls.Add(this.lblLoaiTH);
            this.gbThongTin.Controls.Add(this.rbCayTrong);
            this.gbThongTin.Controls.Add(this.rbVatNuoi);
            this.gbThongTin.Controls.Add(this.lblChiTietCT);
            this.gbThongTin.Controls.Add(this.cboChiTietCT);
            this.gbThongTin.Controls.Add(this.lblChiTietVN);
            this.gbThongTin.Controls.Add(this.cboChiTietVN);
            this.gbThongTin.Controls.Add(this.lblTongSL);
            this.gbThongTin.Controls.Add(this.nudTongSL);
            this.gbThongTin.Controls.Add(this.lblGhiChu);
            this.gbThongTin.Controls.Add(this.txtGhiChu);
            this.gbThongTin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gbThongTin.ForeColor = System.Drawing.Color.Black;
            this.gbThongTin.Location = new System.Drawing.Point(15, 93);
            this.gbThongTin.Margin = new System.Windows.Forms.Padding(4);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Padding = new System.Windows.Forms.Padding(4);
            this.gbThongTin.Size = new System.Drawing.Size(1234, 240);
            this.gbThongTin.TabIndex = 1;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "📋 THÔNG TIN THU HOẠCH";
            // 
            // lblMaTH
            // 
            this.lblMaTH.AutoSize = true;
            this.lblMaTH.ForeColor = System.Drawing.Color.Black;
            this.lblMaTH.Location = new System.Drawing.Point(10, 46);
            this.lblMaTH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaTH.Name = "lblMaTH";
            this.lblMaTH.Size = new System.Drawing.Size(136, 28);
            this.lblMaTH.TabIndex = 0;
            this.lblMaTH.Text = "Mã thu hoạch:";
            // 
            // txtMaTH
            // 
            this.txtMaTH.ForeColor = System.Drawing.Color.Black;
            this.txtMaTH.Location = new System.Drawing.Point(154, 43);
            this.txtMaTH.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaTH.Name = "txtMaTH";
            this.txtMaTH.Size = new System.Drawing.Size(153, 34);
            this.txtMaTH.TabIndex = 1;
            // 
            // lblNgayTH
            // 
            this.lblNgayTH.AutoSize = true;
            this.lblNgayTH.ForeColor = System.Drawing.Color.Black;
            this.lblNgayTH.Location = new System.Drawing.Point(332, 47);
            this.lblNgayTH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgayTH.Name = "lblNgayTH";
            this.lblNgayTH.Size = new System.Drawing.Size(155, 28);
            this.lblNgayTH.TabIndex = 2;
            this.lblNgayTH.Text = "Ngày thu hoạch:";
            // 
            // dtpNgayTH
            // 
            this.dtpNgayTH.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayTH.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayTH.Location = new System.Drawing.Point(495, 43);
            this.dtpNgayTH.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNgayTH.Name = "dtpNgayTH";
            this.dtpNgayTH.Size = new System.Drawing.Size(192, 34);
            this.dtpNgayTH.TabIndex = 3;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.ForeColor = System.Drawing.Color.Black;
            this.lblNhanVien.Location = new System.Drawing.Point(715, 43);
            this.lblNhanVien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(104, 28);
            this.lblNhanVien.TabIndex = 4;
            this.lblNhanVien.Text = "Nhân viên:";
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.ForeColor = System.Drawing.Color.Black;
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(836, 43);
            this.cboNhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(359, 36);
            this.cboNhanVien.TabIndex = 5;
            // 
            // lblLoaiTH
            // 
            this.lblLoaiTH.AutoSize = true;
            this.lblLoaiTH.ForeColor = System.Drawing.Color.Black;
            this.lblLoaiTH.Location = new System.Drawing.Point(26, 100);
            this.lblLoaiTH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoaiTH.Name = "lblLoaiTH";
            this.lblLoaiTH.Size = new System.Drawing.Size(144, 28);
            this.lblLoaiTH.TabIndex = 6;
            this.lblLoaiTH.Text = "Loại thu hoạch:";
            // 
            // rbCayTrong
            // 
            this.rbCayTrong.AutoSize = true;
            this.rbCayTrong.Checked = true;
            this.rbCayTrong.ForeColor = System.Drawing.Color.Black;
            this.rbCayTrong.Location = new System.Drawing.Point(180, 97);
            this.rbCayTrong.Margin = new System.Windows.Forms.Padding(4);
            this.rbCayTrong.Name = "rbCayTrong";
            this.rbCayTrong.Size = new System.Drawing.Size(123, 32);
            this.rbCayTrong.TabIndex = 7;
            this.rbCayTrong.TabStop = true;
            this.rbCayTrong.Text = "Cây trồng";
            this.rbCayTrong.UseVisualStyleBackColor = true;
            this.rbCayTrong.CheckedChanged += new System.EventHandler(this.rbCayTrong_CheckedChanged);
            // 
            // rbVatNuoi
            // 
            this.rbVatNuoi.AutoSize = true;
            this.rbVatNuoi.ForeColor = System.Drawing.Color.Black;
            this.rbVatNuoi.Location = new System.Drawing.Point(321, 97);
            this.rbVatNuoi.Margin = new System.Windows.Forms.Padding(4);
            this.rbVatNuoi.Name = "rbVatNuoi";
            this.rbVatNuoi.Size = new System.Drawing.Size(110, 32);
            this.rbVatNuoi.TabIndex = 8;
            this.rbVatNuoi.Text = "Vật nuôi";
            this.rbVatNuoi.UseVisualStyleBackColor = true;
            this.rbVatNuoi.CheckedChanged += new System.EventHandler(this.rbVatNuoi_CheckedChanged);
            // 
            // lblChiTietCT
            // 
            this.lblChiTietCT.AutoSize = true;
            this.lblChiTietCT.ForeColor = System.Drawing.Color.Black;
            this.lblChiTietCT.Location = new System.Drawing.Point(476, 100);
            this.lblChiTietCT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChiTietCT.Name = "lblChiTietCT";
            this.lblChiTietCT.Size = new System.Drawing.Size(166, 28);
            this.lblChiTietCT.TabIndex = 9;
            this.lblChiTietCT.Text = "Chi tiết cây trồng:";
            // 
            // cboChiTietCT
            // 
            this.cboChiTietCT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChiTietCT.ForeColor = System.Drawing.Color.Black;
            this.cboChiTietCT.FormattingEnabled = true;
            this.cboChiTietCT.Location = new System.Drawing.Point(643, 96);
            this.cboChiTietCT.Margin = new System.Windows.Forms.Padding(4);
            this.cboChiTietCT.Name = "cboChiTietCT";
            this.cboChiTietCT.Size = new System.Drawing.Size(552, 36);
            this.cboChiTietCT.TabIndex = 10;
            this.cboChiTietCT.SelectedIndexChanged += new System.EventHandler(this.cboChiTietCT_SelectedIndexChanged);
            // 
            // lblChiTietVN
            // 
            this.lblChiTietVN.AutoSize = true;
            this.lblChiTietVN.ForeColor = System.Drawing.Color.Black;
            this.lblChiTietVN.Location = new System.Drawing.Point(476, 100);
            this.lblChiTietVN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChiTietVN.Name = "lblChiTietVN";
            this.lblChiTietVN.Size = new System.Drawing.Size(154, 28);
            this.lblChiTietVN.TabIndex = 11;
            this.lblChiTietVN.Text = "Chi tiết vật nuôi:";
            this.lblChiTietVN.Visible = false;
            // 
            // cboChiTietVN
            // 
            this.cboChiTietVN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChiTietVN.ForeColor = System.Drawing.Color.Black;
            this.cboChiTietVN.FormattingEnabled = true;
            this.cboChiTietVN.Location = new System.Drawing.Point(643, 96);
            this.cboChiTietVN.Margin = new System.Windows.Forms.Padding(4);
            this.cboChiTietVN.Name = "cboChiTietVN";
            this.cboChiTietVN.Size = new System.Drawing.Size(552, 36);
            this.cboChiTietVN.TabIndex = 12;
            this.cboChiTietVN.Visible = false;
            this.cboChiTietVN.SelectedIndexChanged += new System.EventHandler(this.cboChiTietVN_SelectedIndexChanged);
            // 
            // lblTongSL
            // 
            this.lblTongSL.AutoSize = true;
            this.lblTongSL.ForeColor = System.Drawing.Color.Black;
            this.lblTongSL.Location = new System.Drawing.Point(26, 153);
            this.lblTongSL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongSL.Name = "lblTongSL";
            this.lblTongSL.Size = new System.Drawing.Size(143, 28);
            this.lblTongSL.TabIndex = 13;
            this.lblTongSL.Text = "Tổng số lượng:";
            // 
            // nudTongSL
            // 
            this.nudTongSL.DecimalPlaces = 2;
            this.nudTongSL.ForeColor = System.Drawing.Color.Black;
            this.nudTongSL.Location = new System.Drawing.Point(166, 150);
            this.nudTongSL.Margin = new System.Windows.Forms.Padding(4);
            this.nudTongSL.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudTongSL.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudTongSL.Name = "nudTongSL";
            this.nudTongSL.Size = new System.Drawing.Size(193, 34);
            this.nudTongSL.TabIndex = 14;
            this.nudTongSL.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.ForeColor = System.Drawing.Color.Black;
            this.lblGhiChu.Location = new System.Drawing.Point(386, 153);
            this.lblGhiChu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(82, 28);
            this.lblGhiChu.TabIndex = 15;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.ForeColor = System.Drawing.Color.Black;
            this.txtGhiChu.Location = new System.Drawing.Point(476, 149);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(4);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(719, 34);
            this.txtGhiChu.TabIndex = 16;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnThem);
            this.pnlButtons.Controls.Add(this.btnSua);
            this.pnlButtons.Controls.Add(this.btnXoa);
            this.pnlButtons.Controls.Add(this.btnLamMoi);
            this.pnlButtons.Location = new System.Drawing.Point(15, 341);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(4);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(1234, 60);
            this.pnlButtons.TabIndex = 2;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(257, 7);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(141, 47);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "➕ THÊM";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(424, 7);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(141, 47);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "✏️ SỬA";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(591, 7);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(141, 47);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "🗑️ XÓA";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(759, 7);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(154, 47);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "📋 LÀM MỚI";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // gbTimKiem
            // 
            this.gbTimKiem.Controls.Add(this.lblTimTheo);
            this.gbTimKiem.Controls.Add(this.cboTimTheo);
            this.gbTimKiem.Controls.Add(this.txtTimKiem);
            this.gbTimKiem.Controls.Add(this.btnTim);
            this.gbTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gbTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.gbTimKiem.Location = new System.Drawing.Point(15, 407);
            this.gbTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.gbTimKiem.Name = "gbTimKiem";
            this.gbTimKiem.Padding = new System.Windows.Forms.Padding(4);
            this.gbTimKiem.Size = new System.Drawing.Size(1234, 73);
            this.gbTimKiem.TabIndex = 3;
            this.gbTimKiem.TabStop = false;
            this.gbTimKiem.Text = "🔍 TÌM KIẾM";
            // 
            // lblTimTheo
            // 
            this.lblTimTheo.AutoSize = true;
            this.lblTimTheo.ForeColor = System.Drawing.Color.Black;
            this.lblTimTheo.Location = new System.Drawing.Point(26, 29);
            this.lblTimTheo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimTheo.Name = "lblTimTheo";
            this.lblTimTheo.Size = new System.Drawing.Size(93, 28);
            this.lblTimTheo.TabIndex = 0;
            this.lblTimTheo.Text = "Tìm theo:";
            // 
            // cboTimTheo
            // 
            this.cboTimTheo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimTheo.ForeColor = System.Drawing.Color.Black;
            this.cboTimTheo.FormattingEnabled = true;
            this.cboTimTheo.Items.AddRange(new object[] {
            "Mã thu hoạch",
            "Nhân viên",
            "Loại thu hoạch",
            "Ghi chú"});
            this.cboTimTheo.Location = new System.Drawing.Point(129, 25);
            this.cboTimTheo.Margin = new System.Windows.Forms.Padding(4);
            this.cboTimTheo.Name = "cboTimTheo";
            this.cboTimTheo.Size = new System.Drawing.Size(230, 36);
            this.cboTimTheo.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.ForeColor = System.Drawing.Color.Black;
            this.txtTimKiem.Location = new System.Drawing.Point(386, 25);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(513, 34);
            this.txtTimKiem.TabIndex = 2;
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnTim.FlatAppearance.BorderSize = 0;
            this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTim.ForeColor = System.Drawing.Color.White;
            this.btnTim.Location = new System.Drawing.Point(926, 20);
            this.btnTim.Margin = new System.Windows.Forms.Padding(4);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(129, 40);
            this.btnTim.TabIndex = 3;
            this.btnTim.Text = "🔎 TÌM";
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // gbDanhSach
            // 
            this.gbDanhSach.Controls.Add(this.dgvThuHoach);
            this.gbDanhSach.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gbDanhSach.ForeColor = System.Drawing.Color.Black;
            this.gbDanhSach.Location = new System.Drawing.Point(15, 487);
            this.gbDanhSach.Margin = new System.Windows.Forms.Padding(4);
            this.gbDanhSach.Name = "gbDanhSach";
            this.gbDanhSach.Padding = new System.Windows.Forms.Padding(4);
            this.gbDanhSach.Size = new System.Drawing.Size(1234, 307);
            this.gbDanhSach.TabIndex = 4;
            this.gbDanhSach.TabStop = false;
            this.gbDanhSach.Text = "📊 DANH SÁCH THU HOẠCH";
            // 
            // dgvThuHoach
            // 
            this.dgvThuHoach.AllowUserToAddRows = false;
            this.dgvThuHoach.AllowUserToDeleteRows = false;
            this.dgvThuHoach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThuHoach.BackgroundColor = System.Drawing.Color.White;
            this.dgvThuHoach.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvThuHoach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThuHoach.Location = new System.Drawing.Point(13, 33);
            this.dgvThuHoach.Margin = new System.Windows.Forms.Padding(4);
            this.dgvThuHoach.MultiSelect = false;
            this.dgvThuHoach.Name = "dgvThuHoach";
            this.dgvThuHoach.ReadOnly = true;
            this.dgvThuHoach.RowHeadersVisible = false;
            this.dgvThuHoach.RowHeadersWidth = 62;
            this.dgvThuHoach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThuHoach.Size = new System.Drawing.Size(1209, 260);
            this.dgvThuHoach.TabIndex = 0;
            this.dgvThuHoach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThuHoach_CellClick);
            // 
            // pnlThongKe
            // 
            this.pnlThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.pnlThongKe.Controls.Add(this.lblThongKe);
            this.pnlThongKe.Location = new System.Drawing.Point(15, 800);
            this.pnlThongKe.Margin = new System.Windows.Forms.Padding(4);
            this.pnlThongKe.Name = "pnlThongKe";
            this.pnlThongKe.Size = new System.Drawing.Size(1234, 47);
            this.pnlThongKe.TabIndex = 5;
            // 
            // lblThongKe
            // 
            this.lblThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThongKe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblThongKe.ForeColor = System.Drawing.Color.White;
            this.lblThongKe.Location = new System.Drawing.Point(0, 0);
            this.lblThongKe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblThongKe.Name = "lblThongKe";
            this.lblThongKe.Size = new System.Drawing.Size(1234, 47);
            this.lblThongKe.TabIndex = 0;
            this.lblThongKe.Text = "📈 Tổng số lượng: 0  |  🌱 Cây trồng: 0  |  🐄 Vật nuôi: 0";
            this.lblThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(1108, 860);
            this.btnDong.Margin = new System.Windows.Forms.Padding(4);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(141, 47);
            this.btnDong.TabIndex = 6;
            this.btnDong.Text = "❌ ĐÓNG";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmThuHoach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1265, 921);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.pnlThongKe);
            this.Controls.Add(this.gbDanhSach);
            this.Controls.Add(this.gbTimKiem);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.gbThongTin);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmThuHoach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Thu Hoạch";
            this.Load += new System.EventHandler(this.frmThuHoach_Load);
            this.pnlHeader.ResumeLayout(false);
            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTongSL)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.gbTimKiem.ResumeLayout(false);
            this.gbTimKiem.PerformLayout();
            this.gbDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuHoach)).EndInit();
            this.pnlThongKe.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.Label lblMaTH;
        private System.Windows.Forms.TextBox txtMaTH;
        private System.Windows.Forms.Label lblNgayTH;
        private System.Windows.Forms.DateTimePicker dtpNgayTH;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label lblLoaiTH;
        private System.Windows.Forms.RadioButton rbCayTrong;
        private System.Windows.Forms.RadioButton rbVatNuoi;
        private System.Windows.Forms.Label lblChiTietCT;
        private System.Windows.Forms.ComboBox cboChiTietCT;
        private System.Windows.Forms.Label lblChiTietVN;
        private System.Windows.Forms.ComboBox cboChiTietVN;
        private System.Windows.Forms.Label lblTongSL;
        private System.Windows.Forms.NumericUpDown nudTongSL;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.GroupBox gbTimKiem;
        private System.Windows.Forms.Label lblTimTheo;
        private System.Windows.Forms.ComboBox cboTimTheo;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.GroupBox gbDanhSach;
        private System.Windows.Forms.DataGridView dgvThuHoach;
        private System.Windows.Forms.Panel pnlThongKe;
        private System.Windows.Forms.Label lblThongKe;
        private System.Windows.Forms.Button btnDong;
    }
}