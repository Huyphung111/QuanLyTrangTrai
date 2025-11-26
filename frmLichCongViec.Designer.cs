namespace QL_TrangTrai
{
    partial class frmLichCongViec
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDemCongViec = new System.Windows.Forms.TabPage();
            this.grpDemCV = new System.Windows.Forms.GroupBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.btnDemCongViec = new System.Windows.Forms.Button();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.txtKetQua = new System.Windows.Forms.TextBox();
            this.dgvLichCongViec = new System.Windows.Forms.DataGridView();
            this.lblTongSo = new System.Windows.Forms.Label();
            this.tabThongKe = new System.Windows.Forms.TabPage();
            this.grpThongKe = new System.Windows.Forms.GroupBox();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.lblThongKeTong = new System.Windows.Forms.Label();
            this.tabPhanCong = new System.Windows.Forms.TabPage();
            this.grpPhanCong = new System.Windows.Forms.GroupBox();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.txtTieuDe = new System.Windows.Forms.TextBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.lblNgayBatDau = new System.Windows.Forms.Label();
            this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.lblNgayKetThuc = new System.Windows.Forms.Label();
            this.dtpNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.btnPhanCong = new System.Windows.Forms.Button();
            this.grpHuongDan = new System.Windows.Forms.GroupBox();
            this.lblHuongDan = new System.Windows.Forms.Label();
            this.lblKetQuaPhanCong = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabDemCongViec.SuspendLayout();
            this.grpDemCV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichCongViec)).BeginInit();
            this.tabThongKe.SuspendLayout();
            this.grpThongKe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            this.tabPhanCong.SuspendLayout();
            this.grpPhanCong.SuspendLayout();
            this.grpHuongDan.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDemCongViec);
            this.tabControl1.Controls.Add(this.tabThongKe);
            this.tabControl1.Controls.Add(this.tabPhanCong);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1157, 800);
            this.tabControl1.TabIndex = 0;
            // 
            // tabDemCongViec
            // 
            this.tabDemCongViec.Controls.Add(this.grpDemCV);
            this.tabDemCongViec.Controls.Add(this.dgvLichCongViec);
            this.tabDemCongViec.Controls.Add(this.lblTongSo);
            this.tabDemCongViec.Location = new System.Drawing.Point(4, 37);
            this.tabDemCongViec.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabDemCongViec.Name = "tabDemCongViec";
            this.tabDemCongViec.Padding = new System.Windows.Forms.Padding(13, 13, 13, 13);
            this.tabDemCongViec.Size = new System.Drawing.Size(1149, 759);
            this.tabDemCongViec.TabIndex = 0;
            this.tabDemCongViec.Text = "📋 Đếm Công Việc (NV3)";
            this.tabDemCongViec.UseVisualStyleBackColor = true;
            // 
            // grpDemCV
            // 
            this.grpDemCV.Controls.Add(this.lblNhanVien);
            this.grpDemCV.Controls.Add(this.cboNhanVien);
            this.grpDemCV.Controls.Add(this.lblTrangThai);
            this.grpDemCV.Controls.Add(this.cboTrangThai);
            this.grpDemCV.Controls.Add(this.btnDemCongViec);
            this.grpDemCV.Controls.Add(this.lblKetQua);
            this.grpDemCV.Controls.Add(this.txtKetQua);
            this.grpDemCV.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.grpDemCV.ForeColor = System.Drawing.Color.DarkBlue;
            this.grpDemCV.Location = new System.Drawing.Point(17, 17);
            this.grpDemCV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpDemCV.Name = "grpDemCV";
            this.grpDemCV.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpDemCV.Size = new System.Drawing.Size(1113, 160);
            this.grpDemCV.TabIndex = 0;
            this.grpDemCV.TabStop = false;
            this.grpDemCV.Text = "🔢 ĐẾM CÔNG VIỆC NHÂN VIÊN (FUNCTION)";
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNhanVien.ForeColor = System.Drawing.Color.Black;
            this.lblNhanVien.Location = new System.Drawing.Point(26, 53);
            this.lblNhanVien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(104, 28);
            this.lblNhanVien.TabIndex = 0;
            this.lblNhanVien.Text = "Nhân viên:";
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboNhanVien.Location = new System.Drawing.Point(141, 49);
            this.cboNhanVien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(256, 36);
            this.cboNhanVien.TabIndex = 1;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTrangThai.ForeColor = System.Drawing.Color.Black;
            this.lblTrangThai.Location = new System.Drawing.Point(26, 100);
            this.lblTrangThai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(102, 28);
            this.lblTrangThai.TabIndex = 2;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTrangThai.Location = new System.Drawing.Point(141, 96);
            this.cboTrangThai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(256, 36);
            this.cboTrangThai.TabIndex = 3;
            // 
            // btnDemCongViec
            // 
            this.btnDemCongViec.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnDemCongViec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDemCongViec.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnDemCongViec.ForeColor = System.Drawing.Color.White;
            this.btnDemCongViec.Location = new System.Drawing.Point(437, 67);
            this.btnDemCongViec.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDemCongViec.Name = "btnDemCongViec";
            this.btnDemCongViec.Size = new System.Drawing.Size(154, 47);
            this.btnDemCongViec.TabIndex = 4;
            this.btnDemCongViec.Text = "🔢 Đếm";
            this.btnDemCongViec.UseVisualStyleBackColor = false;
            this.btnDemCongViec.Click += new System.EventHandler(this.btnDemCongViec_Click);
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKetQua.ForeColor = System.Drawing.Color.Black;
            this.lblKetQua.Location = new System.Drawing.Point(767, 67);
            this.lblKetQua.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(83, 28);
            this.lblKetQua.TabIndex = 5;
            this.lblKetQua.Text = "Kết quả:";
            // 
            // txtKetQua
            // 
            this.txtKetQua.BackColor = System.Drawing.Color.LightYellow;
            this.txtKetQua.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txtKetQua.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtKetQua.Location = new System.Drawing.Point(858, 56);
            this.txtKetQua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.ReadOnly = true;
            this.txtKetQua.Size = new System.Drawing.Size(102, 45);
            this.txtKetQua.TabIndex = 6;
            this.txtKetQua.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvLichCongViec
            // 
            this.dgvLichCongViec.AllowUserToAddRows = false;
            this.dgvLichCongViec.AllowUserToDeleteRows = false;
            this.dgvLichCongViec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichCongViec.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichCongViec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichCongViec.Location = new System.Drawing.Point(17, 193);
            this.dgvLichCongViec.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvLichCongViec.Name = "dgvLichCongViec";
            this.dgvLichCongViec.ReadOnly = true;
            this.dgvLichCongViec.RowHeadersVisible = false;
            this.dgvLichCongViec.RowHeadersWidth = 62;
            this.dgvLichCongViec.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichCongViec.Size = new System.Drawing.Size(1113, 507);
            this.dgvLichCongViec.TabIndex = 1;
            // 
            // lblTongSo
            // 
            this.lblTongSo.AutoSize = true;
            this.lblTongSo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTongSo.Location = new System.Drawing.Point(17, 713);
            this.lblTongSo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongSo.Name = "lblTongSo";
            this.lblTongSo.Size = new System.Drawing.Size(190, 28);
            this.lblTongSo.TabIndex = 2;
            this.lblTongSo.Text = "Tổng số: 0 công việc";
            // 
            // tabThongKe
            // 
            this.tabThongKe.Controls.Add(this.grpThongKe);
            this.tabThongKe.Controls.Add(this.dgvThongKe);
            this.tabThongKe.Controls.Add(this.lblThongKeTong);
            this.tabThongKe.Location = new System.Drawing.Point(4, 37);
            this.tabThongKe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabThongKe.Name = "tabThongKe";
            this.tabThongKe.Padding = new System.Windows.Forms.Padding(13, 13, 13, 13);
            this.tabThongKe.Size = new System.Drawing.Size(1149, 759);
            this.tabThongKe.TabIndex = 1;
            this.tabThongKe.Text = "📊 Thống Kê Hiệu Suất (NV4)";
            this.tabThongKe.UseVisualStyleBackColor = true;
            // 
            // grpThongKe
            // 
            this.grpThongKe.Controls.Add(this.btnThongKe);
            this.grpThongKe.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.grpThongKe.ForeColor = System.Drawing.Color.DarkGreen;
            this.grpThongKe.Location = new System.Drawing.Point(17, 17);
            this.grpThongKe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpThongKe.Name = "grpThongKe";
            this.grpThongKe.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpThongKe.Size = new System.Drawing.Size(1113, 93);
            this.grpThongKe.TabIndex = 0;
            this.grpThongKe.TabStop = false;
            this.grpThongKe.Text = "📊 THỐNG KÊ HIỆU SUẤT NHÂN VIÊN (CURSOR)";
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.ForestGreen;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(26, 37);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(257, 47);
            this.btnThongKe.TabIndex = 0;
            this.btnThongKe.Text = "📊 Chạy Thống Kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.AllowUserToAddRows = false;
            this.dgvThongKe.AllowUserToDeleteRows = false;
            this.dgvThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKe.BackgroundColor = System.Drawing.Color.White;
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Location = new System.Drawing.Point(17, 127);
            this.dgvThongKe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.ReadOnly = true;
            this.dgvThongKe.RowHeadersVisible = false;
            this.dgvThongKe.RowHeadersWidth = 62;
            this.dgvThongKe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongKe.Size = new System.Drawing.Size(1113, 573);
            this.dgvThongKe.TabIndex = 1;
            // 
            // lblThongKeTong
            // 
            this.lblThongKeTong.AutoSize = true;
            this.lblThongKeTong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblThongKeTong.Location = new System.Drawing.Point(17, 713);
            this.lblThongKeTong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblThongKeTong.Name = "lblThongKeTong";
            this.lblThongKeTong.Size = new System.Drawing.Size(285, 28);
            this.lblThongKeTong.TabIndex = 2;
            this.lblThongKeTong.Text = "📈 Tổng NV: 0 | Trung bình: 0%";
            // 
            // tabPhanCong
            // 
            this.tabPhanCong.Controls.Add(this.grpPhanCong);
            this.tabPhanCong.Controls.Add(this.grpHuongDan);
            this.tabPhanCong.Controls.Add(this.lblKetQuaPhanCong);
            this.tabPhanCong.Location = new System.Drawing.Point(4, 37);
            this.tabPhanCong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPhanCong.Name = "tabPhanCong";
            this.tabPhanCong.Padding = new System.Windows.Forms.Padding(13, 13, 13, 13);
            this.tabPhanCong.Size = new System.Drawing.Size(1149, 759);
            this.tabPhanCong.TabIndex = 2;
            this.tabPhanCong.Text = "⚡ Phân Công Tự Động (NV5)";
            this.tabPhanCong.UseVisualStyleBackColor = true;
            // 
            // grpPhanCong
            // 
            this.grpPhanCong.Controls.Add(this.lblTieuDe);
            this.grpPhanCong.Controls.Add(this.txtTieuDe);
            this.grpPhanCong.Controls.Add(this.lblMoTa);
            this.grpPhanCong.Controls.Add(this.txtMoTa);
            this.grpPhanCong.Controls.Add(this.lblNgayBatDau);
            this.grpPhanCong.Controls.Add(this.dtpNgayBatDau);
            this.grpPhanCong.Controls.Add(this.lblNgayKetThuc);
            this.grpPhanCong.Controls.Add(this.dtpNgayKetThuc);
            this.grpPhanCong.Controls.Add(this.btnPhanCong);
            this.grpPhanCong.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.grpPhanCong.ForeColor = System.Drawing.Color.DarkOrange;
            this.grpPhanCong.Location = new System.Drawing.Point(17, 17);
            this.grpPhanCong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpPhanCong.Name = "grpPhanCong";
            this.grpPhanCong.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpPhanCong.Size = new System.Drawing.Size(643, 373);
            this.grpPhanCong.TabIndex = 0;
            this.grpPhanCong.TabStop = false;
            this.grpPhanCong.Text = "⚡ PHÂN CÔNG CÔNG VIỆC TỰ ĐỘNG (PROCEDURE)";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTieuDe.ForeColor = System.Drawing.Color.Black;
            this.lblTieuDe.Location = new System.Drawing.Point(26, 53);
            this.lblTieuDe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(79, 28);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Tiêu đề:";
            // 
            // txtTieuDe
            // 
            this.txtTieuDe.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTieuDe.Location = new System.Drawing.Point(154, 49);
            this.txtTieuDe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTieuDe.Name = "txtTieuDe";
            this.txtTieuDe.Size = new System.Drawing.Size(449, 34);
            this.txtTieuDe.TabIndex = 1;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMoTa.ForeColor = System.Drawing.Color.Black;
            this.lblMoTa.Location = new System.Drawing.Point(26, 100);
            this.lblMoTa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(68, 28);
            this.lblMoTa.TabIndex = 2;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMoTa.Location = new System.Drawing.Point(154, 96);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(449, 79);
            this.txtMoTa.TabIndex = 3;
            // 
            // lblNgayBatDau
            // 
            this.lblNgayBatDau.AutoSize = true;
            this.lblNgayBatDau.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNgayBatDau.ForeColor = System.Drawing.Color.Black;
            this.lblNgayBatDau.Location = new System.Drawing.Point(26, 200);
            this.lblNgayBatDau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgayBatDau.Name = "lblNgayBatDau";
            this.lblNgayBatDau.Size = new System.Drawing.Size(135, 28);
            this.lblNgayBatDau.TabIndex = 4;
            this.lblNgayBatDau.Text = "Ngày bắt đầu:";
            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBatDau.Location = new System.Drawing.Point(169, 194);
            this.dtpNgayBatDau.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.Size = new System.Drawing.Size(192, 34);
            this.dtpNgayBatDau.TabIndex = 5;
            // 
            // lblNgayKetThuc
            // 
            this.lblNgayKetThuc.AutoSize = true;
            this.lblNgayKetThuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNgayKetThuc.ForeColor = System.Drawing.Color.Black;
            this.lblNgayKetThuc.Location = new System.Drawing.Point(26, 253);
            this.lblNgayKetThuc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgayKetThuc.Name = "lblNgayKetThuc";
            this.lblNgayKetThuc.Size = new System.Drawing.Size(138, 28);
            this.lblNgayKetThuc.TabIndex = 6;
            this.lblNgayKetThuc.Text = "Ngày kết thúc:";
            // 
            // dtpNgayKetThuc
            // 
            this.dtpNgayKetThuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(169, 253);
            this.dtpNgayKetThuc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            this.dtpNgayKetThuc.Size = new System.Drawing.Size(192, 34);
            this.dtpNgayKetThuc.TabIndex = 7;
            // 
            // btnPhanCong
            // 
            this.btnPhanCong.BackColor = System.Drawing.Color.OrangeRed;
            this.btnPhanCong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhanCong.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.btnPhanCong.ForeColor = System.Drawing.Color.White;
            this.btnPhanCong.Location = new System.Drawing.Point(154, 307);
            this.btnPhanCong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPhanCong.Name = "btnPhanCong";
            this.btnPhanCong.Size = new System.Drawing.Size(257, 53);
            this.btnPhanCong.TabIndex = 8;
            this.btnPhanCong.Text = "⚡ PHÂN CÔNG TỰ ĐỘNG";
            this.btnPhanCong.UseVisualStyleBackColor = false;
            this.btnPhanCong.Click += new System.EventHandler(this.btnPhanCong_Click);
            // 
            // grpHuongDan
            // 
            this.grpHuongDan.Controls.Add(this.lblHuongDan);
            this.grpHuongDan.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.grpHuongDan.ForeColor = System.Drawing.Color.Teal;
            this.grpHuongDan.Location = new System.Drawing.Point(681, 17);
            this.grpHuongDan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpHuongDan.Name = "grpHuongDan";
            this.grpHuongDan.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpHuongDan.Size = new System.Drawing.Size(450, 373);
            this.grpHuongDan.TabIndex = 1;
            this.grpHuongDan.TabStop = false;
            this.grpHuongDan.Text = "💡 HƯỚNG DẪN";
            // 
            // lblHuongDan
            // 
            this.lblHuongDan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHuongDan.ForeColor = System.Drawing.Color.Black;
            this.lblHuongDan.Location = new System.Drawing.Point(19, 40);
            this.lblHuongDan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHuongDan.Name = "lblHuongDan";
            this.lblHuongDan.Size = new System.Drawing.Size(411, 320);
            this.lblHuongDan.TabIndex = 0;
            this.lblHuongDan.Text = "🔹 Hệ thống sẽ TỰ ĐỘNG tìm nhân viên\r\n   có ít công việc \"Chưa thực hiện\" nhất\r\n\r" +
    "\n🔹Sau đó gán công việc mới cho\r\n nhân viên ";
            // 
            // lblKetQuaPhanCong
            // 
            this.lblKetQuaPhanCong.BackColor = System.Drawing.Color.LightCyan;
            this.lblKetQuaPhanCong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKetQuaPhanCong.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblKetQuaPhanCong.Location = new System.Drawing.Point(17, 413);
            this.lblKetQuaPhanCong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKetQuaPhanCong.Name = "lblKetQuaPhanCong";
            this.lblKetQuaPhanCong.Size = new System.Drawing.Size(1113, 66);
            this.lblKetQuaPhanCong.TabIndex = 2;
            this.lblKetQuaPhanCong.Text = "⏳ Chờ phân công...";
            this.lblKetQuaPhanCong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmLichCongViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 800);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmLichCongViec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ LỊCH CÔNG VIỆC & NHÂN VIÊN";
            this.Load += new System.EventHandler(this.frmLichCongViec_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabDemCongViec.ResumeLayout(false);
            this.tabDemCongViec.PerformLayout();
            this.grpDemCV.ResumeLayout(false);
            this.grpDemCV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichCongViec)).EndInit();
            this.tabThongKe.ResumeLayout(false);
            this.tabThongKe.PerformLayout();
            this.grpThongKe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            this.tabPhanCong.ResumeLayout(false);
            this.grpPhanCong.ResumeLayout(false);
            this.grpPhanCong.PerformLayout();
            this.grpHuongDan.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDemCongViec;
        private System.Windows.Forms.TabPage tabThongKe;
        private System.Windows.Forms.TabPage tabPhanCong;

        // Tab 1 controls
        private System.Windows.Forms.GroupBox grpDemCV;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Button btnDemCongViec;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.TextBox txtKetQua;
        private System.Windows.Forms.DataGridView dgvLichCongViec;
        private System.Windows.Forms.Label lblTongSo;

        // Tab 2 controls
        private System.Windows.Forms.GroupBox grpThongKe;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.Label lblThongKeTong;

        // Tab 3 controls
        private System.Windows.Forms.GroupBox grpPhanCong;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.TextBox txtTieuDe;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label lblNgayBatDau;
        private System.Windows.Forms.DateTimePicker dtpNgayBatDau;
        private System.Windows.Forms.Label lblNgayKetThuc;
        private System.Windows.Forms.DateTimePicker dtpNgayKetThuc;
        private System.Windows.Forms.Button btnPhanCong;
        private System.Windows.Forms.GroupBox grpHuongDan;
        private System.Windows.Forms.Label lblHuongDan;
        private System.Windows.Forms.Label lblKetQuaPhanCong;
    }
}