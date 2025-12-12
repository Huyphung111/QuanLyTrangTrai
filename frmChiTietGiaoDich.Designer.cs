namespace QL_TrangTrai
{
    partial class frmChiTietGiaoDich
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
            this.lblMaGD = new System.Windows.Forms.Label();
            this.cboMaGiaoDich = new System.Windows.Forms.ComboBox();
            this.lblSP = new System.Windows.Forms.Label();
            this.cboSanPham = new System.Windows.Forms.ComboBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.grpTongCong = new System.Windows.Forms.GroupBox();
            this.lblSoDongText = new System.Windows.Forms.Label();
            this.lblSoDong = new System.Windows.Forms.Label();
            this.btnTinhTong = new System.Windows.Forms.Button();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.grpLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.grpTongCong.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(330, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(359, 48);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CHI TIẾT GIAO DỊCH";
            // 
            // grpLoc
            // 
            this.grpLoc.Controls.Add(this.lblMaGD);
            this.grpLoc.Controls.Add(this.cboMaGiaoDich);
            this.grpLoc.Controls.Add(this.lblSP);
            this.grpLoc.Controls.Add(this.cboSanPham);
            this.grpLoc.Controls.Add(this.btnLoc);
            this.grpLoc.Controls.Add(this.btnLamMoi);
            this.grpLoc.Location = new System.Drawing.Point(20, 55);
            this.grpLoc.Name = "grpLoc";
            this.grpLoc.Size = new System.Drawing.Size(869, 70);
            this.grpLoc.TabIndex = 1;
            this.grpLoc.TabStop = false;
            this.grpLoc.Text = "Bộ lọc";
            // 
            // lblMaGD
            // 
            this.lblMaGD.AutoSize = true;
            this.lblMaGD.Location = new System.Drawing.Point(15, 28);
            this.lblMaGD.Name = "lblMaGD";
            this.lblMaGD.Size = new System.Drawing.Size(119, 25);
            this.lblMaGD.TabIndex = 0;
            this.lblMaGD.Text = "Mã giao dịch:";
            // 
            // cboMaGiaoDich
            // 
            this.cboMaGiaoDich.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaGiaoDich.FormattingEnabled = true;
            this.cboMaGiaoDich.Location = new System.Drawing.Point(110, 25);
            this.cboMaGiaoDich.Name = "cboMaGiaoDich";
            this.cboMaGiaoDich.Size = new System.Drawing.Size(180, 33);
            this.cboMaGiaoDich.TabIndex = 1;
            // 
            // lblSP
            // 
            this.lblSP.AutoSize = true;
            this.lblSP.Location = new System.Drawing.Point(310, 28);
            this.lblSP.Name = "lblSP";
            this.lblSP.Size = new System.Drawing.Size(96, 25);
            this.lblSP.TabIndex = 2;
            this.lblSP.Text = "Sản phẩm:";
            // 
            // cboSanPham
            // 
            this.cboSanPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSanPham.FormattingEnabled = true;
            this.cboSanPham.Location = new System.Drawing.Point(385, 25);
            this.cboSanPham.Name = "cboSanPham";
            this.cboSanPham.Size = new System.Drawing.Size(200, 33);
            this.cboSanPham.TabIndex = 3;
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(610, 23);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(100, 30);
            this.btnLoc.TabIndex = 4;
            this.btnLoc.Text = "🔍 Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.Gray;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(720, 23);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 30);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "↻ Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Location = new System.Drawing.Point(20, 135);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.RowHeadersWidth = 62;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(840, 250);
            this.dgvChiTiet.TabIndex = 2;
            // 
            // grpTongCong
            // 
            this.grpTongCong.Controls.Add(this.lblSoDongText);
            this.grpTongCong.Controls.Add(this.lblSoDong);
            this.grpTongCong.Controls.Add(this.btnTinhTong);
            this.grpTongCong.Controls.Add(this.lblTongTien);
            this.grpTongCong.Location = new System.Drawing.Point(20, 395);
            this.grpTongCong.Name = "grpTongCong";
            this.grpTongCong.Size = new System.Drawing.Size(840, 60);
            this.grpTongCong.TabIndex = 3;
            this.grpTongCong.TabStop = false;
            this.grpTongCong.Text = "Tổng cộng";
            // 
            // lblSoDongText
            // 
            this.lblSoDongText.AutoSize = true;
            this.lblSoDongText.Location = new System.Drawing.Point(30, 25);
            this.lblSoDongText.Name = "lblSoDongText";
            this.lblSoDongText.Size = new System.Drawing.Size(85, 25);
            this.lblSoDongText.TabIndex = 0;
            this.lblSoDongText.Text = "Số dòng:";
            // 
            // lblSoDong
            // 
            this.lblSoDong.AutoSize = true;
            this.lblSoDong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSoDong.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSoDong.Location = new System.Drawing.Point(100, 23);
            this.lblSoDong.Name = "lblSoDong";
            this.lblSoDong.Size = new System.Drawing.Size(26, 30);
            this.lblSoDong.TabIndex = 1;
            this.lblSoDong.Text = "0";
            // 
            // btnTinhTong
            // 
            this.btnTinhTong.BackColor = System.Drawing.Color.ForestGreen;
            this.btnTinhTong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTinhTong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTinhTong.ForeColor = System.Drawing.Color.White;
            this.btnTinhTong.Location = new System.Drawing.Point(350, 18);
            this.btnTinhTong.Name = "btnTinhTong";
            this.btnTinhTong.Size = new System.Drawing.Size(180, 32);
            this.btnTinhTong.TabIndex = 2;
            this.btnTinhTong.Text = "💰 Tính tổng thành tiền";
            this.btnTinhTong.UseVisualStyleBackColor = false;
            this.btnTinhTong.Click += new System.EventHandler(this.btnTinhTong_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.Green;
            this.lblTongTien.Location = new System.Drawing.Point(550, 22);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(0, 32);
            this.lblTongTien.TabIndex = 3;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.Gray;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(380, 465);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(120, 40);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "✖ Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmChiTietGiaoDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 571);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpLoc);
            this.Controls.Add(this.dgvChiTiet);
            this.Controls.Add(this.grpTongCong);
            this.Controls.Add(this.btnDong);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmChiTietGiaoDich";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHI TIẾT GIAO DỊCH";
            this.Load += new System.EventHandler(this.frmChiTietGiaoDich_Load);
            this.grpLoc.ResumeLayout(false);
            this.grpLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.grpTongCong.ResumeLayout(false);
            this.grpTongCong.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpLoc;
        private System.Windows.Forms.Label lblMaGD;
        private System.Windows.Forms.ComboBox cboMaGiaoDich;
        private System.Windows.Forms.Label lblSP;
        private System.Windows.Forms.ComboBox cboSanPham;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.GroupBox grpTongCong;
        private System.Windows.Forms.Label lblSoDongText;
        private System.Windows.Forms.Label lblSoDong;
        private System.Windows.Forms.Button btnTinhTong;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnDong;
    }
}
