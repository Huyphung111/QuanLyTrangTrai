namespace QL_TrangTrai
{
    partial class frmChiTietGiaoDich
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpBoLoc = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnLoc = new System.Windows.Forms.Button();
            this.cboSanPham = new System.Windows.Forms.ComboBox();
            this.lblSanPham = new System.Windows.Forms.Label();
            this.cboMaGiaoDich = new System.Windows.Forms.ComboBox();
            this.lblLoaiGD = new System.Windows.Forms.Label();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.grpTongCong = new System.Windows.Forms.GroupBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblTongTienText = new System.Windows.Forms.Label();
            this.btnTinhTong = new System.Windows.Forms.Button();
            this.lblSoDong = new System.Windows.Forms.Label();
            this.lblSoDongText = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.grpBoLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.grpTongCong.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(884, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CHI TIẾT GIAO DỊCH";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpBoLoc
            // 
            this.grpBoLoc.Controls.Add(this.btnLamMoi);
            this.grpBoLoc.Controls.Add(this.btnLoc);
            this.grpBoLoc.Controls.Add(this.cboSanPham);
            this.grpBoLoc.Controls.Add(this.lblSanPham);
            this.grpBoLoc.Controls.Add(this.cboMaGiaoDich);
            this.grpBoLoc.Controls.Add(this.lblLoaiGD);
            this.grpBoLoc.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.grpBoLoc.Location = new System.Drawing.Point(12, 53);
            this.grpBoLoc.Name = "grpBoLoc";
            this.grpBoLoc.Size = new System.Drawing.Size(860, 70);
            this.grpBoLoc.TabIndex = 1;
            this.grpBoLoc.TabStop = false;
            this.grpBoLoc.Text = "Bộ lọc";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.Gray;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(760, 28);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(85, 30);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "↻ Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnLoc.FlatAppearance.BorderSize = 0;
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(669, 28);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(85, 30);
            this.btnLoc.TabIndex = 4;
            this.btnLoc.Text = "🔍 Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // cboSanPham
            // 
            this.cboSanPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSanPham.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cboSanPham.FormattingEnabled = true;
            this.cboSanPham.Location = new System.Drawing.Point(430, 29);
            this.cboSanPham.Name = "cboSanPham";
            this.cboSanPham.Size = new System.Drawing.Size(220, 25);
            this.cboSanPham.TabIndex = 3;
            // 
            // lblSanPham
            // 
            this.lblSanPham.AutoSize = true;
            this.lblSanPham.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblSanPham.Location = new System.Drawing.Point(355, 32);
            this.lblSanPham.Name = "lblSanPham";
            this.lblSanPham.Size = new System.Drawing.Size(69, 17);
            this.lblSanPham.TabIndex = 2;
            this.lblSanPham.Text = "Sản phẩm:";
            // 
            // cboMaGiaoDich
            // 
            this.cboMaGiaoDich.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaGiaoDich.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cboMaGiaoDich.FormattingEnabled = true;
            this.cboMaGiaoDich.Location = new System.Drawing.Point(120, 29);
            this.cboMaGiaoDich.Name = "cboMaGiaoDich";
            this.cboMaGiaoDich.Size = new System.Drawing.Size(220, 25);
            this.cboMaGiaoDich.TabIndex = 1;
            // 
            // lblLoaiGD
            // 
            this.lblLoaiGD.AutoSize = true;
            this.lblLoaiGD.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblLoaiGD.Location = new System.Drawing.Point(15, 32);
            this.lblLoaiGD.Name = "lblLoaiGD";
            this.lblLoaiGD.Size = new System.Drawing.Size(99, 17);
            this.lblLoaiGD.TabIndex = 0;
            this.lblLoaiGD.Text = "Loại giao dịch:";
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTiet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Location = new System.Drawing.Point(12, 129);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersWidth = 30;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(860, 300);
            this.dgvChiTiet.TabIndex = 2;
            // 
            // grpTongCong
            // 
            this.grpTongCong.Controls.Add(this.lblTongTien);
            this.grpTongCong.Controls.Add(this.lblTongTienText);
            this.grpTongCong.Controls.Add(this.btnTinhTong);
            this.grpTongCong.Controls.Add(this.lblSoDong);
            this.grpTongCong.Controls.Add(this.lblSoDongText);
            this.grpTongCong.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.grpTongCong.Location = new System.Drawing.Point(12, 435);
            this.grpTongCong.Name = "grpTongCong";
            this.grpTongCong.Size = new System.Drawing.Size(860, 60);
            this.grpTongCong.TabIndex = 3;
            this.grpTongCong.TabStop = false;
            this.grpTongCong.Text = "Tổng cộng";
            // 
            // lblTongTien
            // 
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.Blue;
            this.lblTongTien.Location = new System.Drawing.Point(660, 22);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(190, 25);
            this.lblTongTien.TabIndex = 4;
            this.lblTongTien.Text = "0 đ";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTongTienText
            // 
            this.lblTongTienText.AutoSize = true;
            this.lblTongTienText.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblTongTienText.Location = new System.Drawing.Point(570, 26);
            this.lblTongTienText.Name = "lblTongTienText";
            this.lblTongTienText.Size = new System.Drawing.Size(84, 17);
            this.lblTongTienText.TabIndex = 3;
            this.lblTongTienText.Text = "Tổng tiền:";
            // 
            // btnTinhTong
            // 
            this.btnTinhTong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnTinhTong.FlatAppearance.BorderSize = 0;
            this.btnTinhTong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTinhTong.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnTinhTong.ForeColor = System.Drawing.Color.White;
            this.btnTinhTong.Location = new System.Drawing.Point(350, 22);
            this.btnTinhTong.Name = "btnTinhTong";
            this.btnTinhTong.Size = new System.Drawing.Size(120, 30);
            this.btnTinhTong.TabIndex = 2;
            this.btnTinhTong.Text = "🔢 Tính tổng";
            this.btnTinhTong.UseVisualStyleBackColor = false;
            this.btnTinhTong.Click += new System.EventHandler(this.btnTinhTong_Click);
            // 
            // lblSoDong
            // 
            this.lblSoDong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSoDong.ForeColor = System.Drawing.Color.Green;
            this.lblSoDong.Location = new System.Drawing.Point(80, 24);
            this.lblSoDong.Name = "lblSoDong";
            this.lblSoDong.Size = new System.Drawing.Size(60, 20);
            this.lblSoDong.TabIndex = 1;
            this.lblSoDong.Text = "0";
            // 
            // lblSoDongText
            // 
            this.lblSoDongText.AutoSize = true;
            this.lblSoDongText.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblSoDongText.Location = new System.Drawing.Point(15, 25);
            this.lblSoDongText.Name = "lblSoDongText";
            this.lblSoDongText.Size = new System.Drawing.Size(59, 17);
            this.lblSoDongText.TabIndex = 0;
            this.lblSoDongText.Text = "Số dòng:";
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(380, 505);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(120, 35);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "✕ Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmChiTietGiaoDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 551);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.grpTongCong);
            this.Controls.Add(this.dgvChiTiet);
            this.Controls.Add(this.grpBoLoc);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmChiTietGiaoDich";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết giao dịch";
            this.Load += new System.EventHandler(this.frmChiTietGiaoDich_Load);
            this.grpBoLoc.ResumeLayout(false);
            this.grpBoLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.grpTongCong.ResumeLayout(false);
            this.grpTongCong.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpBoLoc;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.ComboBox cboSanPham;
        private System.Windows.Forms.Label lblSanPham;
        private System.Windows.Forms.ComboBox cboMaGiaoDich;
        private System.Windows.Forms.Label lblLoaiGD;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.GroupBox grpTongCong;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblTongTienText;
        private System.Windows.Forms.Button btnTinhTong;
        private System.Windows.Forms.Label lblSoDong;
        private System.Windows.Forms.Label lblSoDongText;
        private System.Windows.Forms.Button btnDong;
    }
}