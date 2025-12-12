namespace QL_TrangTrai
{
    partial class frmTaiChinh
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpLoc = new System.Windows.Forms.GroupBox();
            this.lblLoai = new System.Windows.Forms.Label();
            this.cboLoaiGD = new System.Windows.Forms.ComboBox();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnLoc = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.dgvTaiChinh = new System.Windows.Forms.DataGridView();
            this.grpThongKe = new System.Windows.Forms.GroupBox();
            this.pnlThu = new System.Windows.Forms.Panel();
            this.lblThuTitle = new System.Windows.Forms.Label();
            this.lblTongThu = new System.Windows.Forms.Label();
            this.pnlChi = new System.Windows.Forms.Panel();
            this.lblChiTitle = new System.Windows.Forms.Label();
            this.lblTongChi = new System.Windows.Forms.Label();
            this.pnlLoiNhuan = new System.Windows.Forms.Panel();
            this.lblLoiNhuanTitle = new System.Windows.Forms.Label();
            this.lblLoiNhuan = new System.Windows.Forms.Label();
            this.grpThemChi = new System.Windows.Forms.GroupBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.lblPT = new System.Windows.Forms.Label();
            this.cboPhuongThuc = new System.Windows.Forms.ComboBox();
            this.lblNCC = new System.Windows.Forms.Label();
            this.cboNhaCungCap = new System.Windows.Forms.ComboBox();
            this.lblNV = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.btnThemChi = new System.Windows.Forms.Button();
            this.btnXemChiTiet = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.grpLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiChinh)).BeginInit();
            this.grpThongKe.SuspendLayout();
            this.pnlThu.SuspendLayout();
            this.pnlChi.SuspendLayout();
            this.pnlLoiNhuan.SuspendLayout();
            this.grpThemChi.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTitle.Location = new System.Drawing.Point(380, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(240, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ TÀI CHÍNH";
            // 
            // grpLoc
            // 
            this.grpLoc.Controls.Add(this.lblLoai);
            this.grpLoc.Controls.Add(this.cboLoaiGD);
            this.grpLoc.Controls.Add(this.lblTuNgay);
            this.grpLoc.Controls.Add(this.dtpTuNgay);
            this.grpLoc.Controls.Add(this.lblDenNgay);
            this.grpLoc.Controls.Add(this.dtpDenNgay);
            this.grpLoc.Controls.Add(this.btnLoc);
            this.grpLoc.Controls.Add(this.btnLamMoi);
            this.grpLoc.Location = new System.Drawing.Point(20, 55);
            this.grpLoc.Name = "grpLoc";
            this.grpLoc.Size = new System.Drawing.Size(940, 70);
            this.grpLoc.TabIndex = 1;
            this.grpLoc.TabStop = false;
            this.grpLoc.Text = "Bộ lọc";
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Location = new System.Drawing.Point(15, 28);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(55, 15);
            this.lblLoai.TabIndex = 0;
            this.lblLoai.Text = "Loại GD:";
            // 
            // cboLoaiGD
            // 
            this.cboLoaiGD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiGD.FormattingEnabled = true;
            this.cboLoaiGD.Items.AddRange(new object[] { "Tất cả", "Thu", "Chi" });
            this.cboLoaiGD.Location = new System.Drawing.Point(80, 25);
            this.cboLoaiGD.Name = "cboLoaiGD";
            this.cboLoaiGD.Size = new System.Drawing.Size(120, 23);
            this.cboLoaiGD.TabIndex = 1;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(220, 28);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(55, 15);
            this.lblTuNgay.TabIndex = 2;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(290, 25);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(150, 23);
            this.dtpTuNgay.TabIndex = 3;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(460, 28);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(63, 15);
            this.lblDenNgay.TabIndex = 4;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(540, 25);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(150, 23);
            this.dtpDenNgay.TabIndex = 5;
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(710, 23);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(100, 30);
            this.btnLoc.TabIndex = 6;
            this.btnLoc.Text = "🔍 Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.Gray;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(820, 23);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 30);
            this.btnLamMoi.TabIndex = 7;
            this.btnLamMoi.Text = "↻ Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // dgvTaiChinh
            // 
            this.dgvTaiChinh.AllowUserToAddRows = false;
            this.dgvTaiChinh.AllowUserToDeleteRows = false;
            this.dgvTaiChinh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTaiChinh.BackgroundColor = System.Drawing.Color.White;
            this.dgvTaiChinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaiChinh.Location = new System.Drawing.Point(20, 135);
            this.dgvTaiChinh.Name = "dgvTaiChinh";
            this.dgvTaiChinh.ReadOnly = true;
            this.dgvTaiChinh.RowHeadersVisible = false;
            this.dgvTaiChinh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTaiChinh.Size = new System.Drawing.Size(940, 250);
            this.dgvTaiChinh.TabIndex = 2;
            this.dgvTaiChinh.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTaiChinh_CellDoubleClick);
            // 
            // grpThongKe
            // 
            this.grpThongKe.Controls.Add(this.pnlThu);
            this.grpThongKe.Controls.Add(this.pnlChi);
            this.grpThongKe.Controls.Add(this.pnlLoiNhuan);
            this.grpThongKe.Location = new System.Drawing.Point(20, 395);
            this.grpThongKe.Name = "grpThongKe";
            this.grpThongKe.Size = new System.Drawing.Size(940, 80);
            this.grpThongKe.TabIndex = 3;
            this.grpThongKe.TabStop = false;
            this.grpThongKe.Text = "Thống kê";
            // 
            // pnlThu
            // 
            this.pnlThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(200)))));
            this.pnlThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThu.Controls.Add(this.lblThuTitle);
            this.pnlThu.Controls.Add(this.lblTongThu);
            this.pnlThu.Location = new System.Drawing.Point(50, 25);
            this.pnlThu.Name = "pnlThu";
            this.pnlThu.Size = new System.Drawing.Size(250, 45);
            this.pnlThu.TabIndex = 0;
            // 
            // lblThuTitle
            // 
            this.lblThuTitle.AutoSize = true;
            this.lblThuTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblThuTitle.Location = new System.Drawing.Point(10, 5);
            this.lblThuTitle.Name = "lblThuTitle";
            this.lblThuTitle.Size = new System.Drawing.Size(66, 15);
            this.lblThuTitle.TabIndex = 0;
            this.lblThuTitle.Text = "TỔNG THU";
            // 
            // lblTongThu
            // 
            this.lblTongThu.AutoSize = true;
            this.lblTongThu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongThu.ForeColor = System.Drawing.Color.Green;
            this.lblTongThu.Location = new System.Drawing.Point(10, 22);
            this.lblTongThu.Name = "lblTongThu";
            this.lblTongThu.Size = new System.Drawing.Size(30, 21);
            this.lblTongThu.TabIndex = 1;
            this.lblTongThu.Text = "0 đ";
            // 
            // pnlChi
            // 
            this.pnlChi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.pnlChi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChi.Controls.Add(this.lblChiTitle);
            this.pnlChi.Controls.Add(this.lblTongChi);
            this.pnlChi.Location = new System.Drawing.Point(350, 25);
            this.pnlChi.Name = "pnlChi";
            this.pnlChi.Size = new System.Drawing.Size(250, 45);
            this.pnlChi.TabIndex = 1;
            // 
            // lblChiTitle
            // 
            this.lblChiTitle.AutoSize = true;
            this.lblChiTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblChiTitle.Location = new System.Drawing.Point(10, 5);
            this.lblChiTitle.Name = "lblChiTitle";
            this.lblChiTitle.Size = new System.Drawing.Size(62, 15);
            this.lblChiTitle.TabIndex = 0;
            this.lblChiTitle.Text = "TỔNG CHI";
            // 
            // lblTongChi
            // 
            this.lblTongChi.AutoSize = true;
            this.lblTongChi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongChi.ForeColor = System.Drawing.Color.Red;
            this.lblTongChi.Location = new System.Drawing.Point(10, 22);
            this.lblTongChi.Name = "lblTongChi";
            this.lblTongChi.Size = new System.Drawing.Size(30, 21);
            this.lblTongChi.TabIndex = 1;
            this.lblTongChi.Text = "0 đ";
            // 
            // pnlLoiNhuan
            // 
            this.pnlLoiNhuan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.pnlLoiNhuan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLoiNhuan.Controls.Add(this.lblLoiNhuanTitle);
            this.pnlLoiNhuan.Controls.Add(this.lblLoiNhuan);
            this.pnlLoiNhuan.Location = new System.Drawing.Point(650, 25);
            this.pnlLoiNhuan.Name = "pnlLoiNhuan";
            this.pnlLoiNhuan.Size = new System.Drawing.Size(250, 45);
            this.pnlLoiNhuan.TabIndex = 2;
            // 
            // lblLoiNhuanTitle
            // 
            this.lblLoiNhuanTitle.AutoSize = true;
            this.lblLoiNhuanTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLoiNhuanTitle.Location = new System.Drawing.Point(10, 5);
            this.lblLoiNhuanTitle.Name = "lblLoiNhuanTitle";
            this.lblLoiNhuanTitle.Size = new System.Drawing.Size(70, 15);
            this.lblLoiNhuanTitle.TabIndex = 0;
            this.lblLoiNhuanTitle.Text = "LỢI NHUẬN";
            // 
            // lblLoiNhuan
            // 
            this.lblLoiNhuan.AutoSize = true;
            this.lblLoiNhuan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLoiNhuan.ForeColor = System.Drawing.Color.Blue;
            this.lblLoiNhuan.Location = new System.Drawing.Point(10, 22);
            this.lblLoiNhuan.Name = "lblLoiNhuan";
            this.lblLoiNhuan.Size = new System.Drawing.Size(30, 21);
            this.lblLoiNhuan.TabIndex = 1;
            this.lblLoiNhuan.Text = "0 đ";
            // 
            // grpThemChi
            // 
            this.grpThemChi.Controls.Add(this.lblMoTa);
            this.grpThemChi.Controls.Add(this.txtMoTa);
            this.grpThemChi.Controls.Add(this.lblSoTien);
            this.grpThemChi.Controls.Add(this.txtSoTien);
            this.grpThemChi.Controls.Add(this.lblPT);
            this.grpThemChi.Controls.Add(this.cboPhuongThuc);
            this.grpThemChi.Controls.Add(this.lblNCC);
            this.grpThemChi.Controls.Add(this.cboNhaCungCap);
            this.grpThemChi.Controls.Add(this.lblNV);
            this.grpThemChi.Controls.Add(this.cboNhanVien);
            this.grpThemChi.Controls.Add(this.btnThemChi);
            this.grpThemChi.Location = new System.Drawing.Point(20, 485);
            this.grpThemChi.Name = "grpThemChi";
            this.grpThemChi.Size = new System.Drawing.Size(940, 110);
            this.grpThemChi.TabIndex = 4;
            this.grpThemChi.TabStop = false;
            this.grpThemChi.Text = "Thêm giao dịch Chi thủ công";
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(15, 30);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(43, 15);
            this.lblMoTa.TabIndex = 0;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(70, 27);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(200, 23);
            this.txtMoTa.TabIndex = 1;
            // 
            // lblSoTien
            // 
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Location = new System.Drawing.Point(290, 30);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(49, 15);
            this.lblSoTien.TabIndex = 2;
            this.lblSoTien.Text = "Số tiền:";
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(350, 27);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(120, 23);
            this.txtSoTien.TabIndex = 3;
            // 
            // lblPT
            // 
            this.lblPT.AutoSize = true;
            this.lblPT.Location = new System.Drawing.Point(490, 30);
            this.lblPT.Name = "lblPT";
            this.lblPT.Size = new System.Drawing.Size(88, 15);
            this.lblPT.TabIndex = 4;
            this.lblPT.Text = "Phương thức:";
            // 
            // cboPhuongThuc
            // 
            this.cboPhuongThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhuongThuc.FormattingEnabled = true;
            this.cboPhuongThuc.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản", "Khác" });
            this.cboPhuongThuc.Location = new System.Drawing.Point(590, 27);
            this.cboPhuongThuc.Name = "cboPhuongThuc";
            this.cboPhuongThuc.Size = new System.Drawing.Size(130, 23);
            this.cboPhuongThuc.TabIndex = 5;
            // 
            // lblNCC
            // 
            this.lblNCC.AutoSize = true;
            this.lblNCC.Location = new System.Drawing.Point(15, 65);
            this.lblNCC.Name = "lblNCC";
            this.lblNCC.Size = new System.Drawing.Size(90, 15);
            this.lblNCC.TabIndex = 6;
            this.lblNCC.Text = "Nhà cung cấp:";
            // 
            // cboNhaCungCap
            // 
            this.cboNhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhaCungCap.FormattingEnabled = true;
            this.cboNhaCungCap.Location = new System.Drawing.Point(115, 62);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Size = new System.Drawing.Size(200, 23);
            this.cboNhaCungCap.TabIndex = 7;
            // 
            // lblNV
            // 
            this.lblNV.AutoSize = true;
            this.lblNV.Location = new System.Drawing.Point(340, 65);
            this.lblNV.Name = "lblNV";
            this.lblNV.Size = new System.Drawing.Size(68, 15);
            this.lblNV.TabIndex = 8;
            this.lblNV.Text = "Nhân viên:";
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(420, 62);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(180, 23);
            this.cboNhanVien.TabIndex = 9;
            // 
            // btnThemChi
            // 
            this.btnThemChi.BackColor = System.Drawing.Color.OrangeRed;
            this.btnThemChi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemChi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnThemChi.ForeColor = System.Drawing.Color.White;
            this.btnThemChi.Location = new System.Drawing.Point(750, 40);
            this.btnThemChi.Name = "btnThemChi";
            this.btnThemChi.Size = new System.Drawing.Size(150, 45);
            this.btnThemChi.TabIndex = 10;
            this.btnThemChi.Text = "➕ Thêm Chi";
            this.btnThemChi.UseVisualStyleBackColor = false;
            this.btnThemChi.Click += new System.EventHandler(this.btnThemChi_Click);
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.BackColor = System.Drawing.Color.Teal;
            this.btnXemChiTiet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemChiTiet.ForeColor = System.Drawing.Color.White;
            this.btnXemChiTiet.Location = new System.Drawing.Point(300, 610);
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.Size = new System.Drawing.Size(150, 40);
            this.btnXemChiTiet.TabIndex = 5;
            this.btnXemChiTiet.Text = "📋 Xem chi tiết";
            this.btnXemChiTiet.UseVisualStyleBackColor = false;
            this.btnXemChiTiet.Click += new System.EventHandler(this.btnXemChiTiet_Click);
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.Gray;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(500, 610);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(150, 40);
            this.btnDong.TabIndex = 6;
            this.btnDong.Text = "✖ Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmTaiChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpLoc);
            this.Controls.Add(this.dgvTaiChinh);
            this.Controls.Add(this.grpThongKe);
            this.Controls.Add(this.grpThemChi);
            this.Controls.Add(this.btnXemChiTiet);
            this.Controls.Add(this.btnDong);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmTaiChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ TÀI CHÍNH";
            this.Load += new System.EventHandler(this.frmTaiChinh_Load);
            this.grpLoc.ResumeLayout(false);
            this.grpLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiChinh)).EndInit();
            this.grpThongKe.ResumeLayout(false);
            this.pnlThu.ResumeLayout(false);
            this.pnlThu.PerformLayout();
            this.pnlChi.ResumeLayout(false);
            this.pnlChi.PerformLayout();
            this.pnlLoiNhuan.ResumeLayout(false);
            this.pnlLoiNhuan.PerformLayout();
            this.grpThemChi.ResumeLayout(false);
            this.grpThemChi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpLoc;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.ComboBox cboLoaiGD;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dgvTaiChinh;
        private System.Windows.Forms.GroupBox grpThongKe;
        private System.Windows.Forms.Panel pnlThu;
        private System.Windows.Forms.Label lblThuTitle;
        private System.Windows.Forms.Label lblTongThu;
        private System.Windows.Forms.Panel pnlChi;
        private System.Windows.Forms.Label lblChiTitle;
        private System.Windows.Forms.Label lblTongChi;
        private System.Windows.Forms.Panel pnlLoiNhuan;
        private System.Windows.Forms.Label lblLoiNhuanTitle;
        private System.Windows.Forms.Label lblLoiNhuan;
        private System.Windows.Forms.GroupBox grpThemChi;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.Label lblPT;
        private System.Windows.Forms.ComboBox cboPhuongThuc;
        private System.Windows.Forms.Label lblNCC;
        private System.Windows.Forms.ComboBox cboNhaCungCap;
        private System.Windows.Forms.Label lblNV;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Button btnThemChi;
        private System.Windows.Forms.Button btnXemChiTiet;
        private System.Windows.Forms.Button btnDong;
    }
}
