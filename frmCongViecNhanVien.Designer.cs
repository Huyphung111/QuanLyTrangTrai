namespace QL_TrangTrai
{
    partial class frmCongViecNhanVien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvCongViec = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnHoanThanh = new System.Windows.Forms.Button();
            this.btnDangLam = new System.Windows.Forms.Button();
            this.grpMoTa = new System.Windows.Forms.GroupBox();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongViec)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.grpMoTa.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblMaNV);
            this.pnlTop.Controls.Add(this.label3);
            this.pnlTop.Controls.Add(this.lblHoTen);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(12);
            this.pnlTop.Size = new System.Drawing.Size(1100, 80);
            this.pnlTop.TabIndex = 0;
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMaNV.Location = new System.Drawing.Point(795, 45);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(22, 23);
            this.lblMaNV.TabIndex = 4;
            this.lblMaNV.Text = "--";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(730, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "MaNV:";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHoTen.Location = new System.Drawing.Point(110, 45);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(22, 23);
            this.lblHoTen.TabIndex = 2;
            this.lblHoTen.Text = "--";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhân viên:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(208, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CÔNG VIỆC CỦA TÔI";
            // 
            // dgvCongViec
            // 
            this.dgvCongViec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCongViec.Location = new System.Drawing.Point(0, 80);
            this.dgvCongViec.Name = "dgvCongViec";
            this.dgvCongViec.RowHeadersWidth = 51;
            this.dgvCongViec.RowTemplate.Height = 29;
            this.dgvCongViec.Size = new System.Drawing.Size(1100, 420);
            this.dgvCongViec.TabIndex = 1;
            this.dgvCongViec.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCongViec_CellClick);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnHoanThanh);
            this.pnlBottom.Controls.Add(this.btnDangLam);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 650);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(12);
            this.pnlBottom.Size = new System.Drawing.Size(1100, 70);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnHoanThanh
            // 
            this.btnHoanThanh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHoanThanh.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHoanThanh.Location = new System.Drawing.Point(905, 12);
            this.btnHoanThanh.Name = "btnHoanThanh";
            this.btnHoanThanh.Size = new System.Drawing.Size(180, 45);
            this.btnHoanThanh.TabIndex = 1;
            this.btnHoanThanh.Text = "HOÀN THÀNH";
            this.btnHoanThanh.UseVisualStyleBackColor = true;
            this.btnHoanThanh.Click += new System.EventHandler(this.btnHoanThanh_Click);
            // 
            // btnDangLam
            // 
            this.btnDangLam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDangLam.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDangLam.Location = new System.Drawing.Point(715, 12);
            this.btnDangLam.Name = "btnDangLam";
            this.btnDangLam.Size = new System.Drawing.Size(180, 45);
            this.btnDangLam.TabIndex = 0;
            this.btnDangLam.Text = "ĐANG LÀM";
            this.btnDangLam.UseVisualStyleBackColor = true;
            this.btnDangLam.Click += new System.EventHandler(this.btnDangLam_Click);
            // 
            // grpMoTa
            // 
            this.grpMoTa.Controls.Add(this.txtMoTa);
            this.grpMoTa.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpMoTa.Location = new System.Drawing.Point(0, 500);
            this.grpMoTa.Name = "grpMoTa";
            this.grpMoTa.Padding = new System.Windows.Forms.Padding(12);
            this.grpMoTa.Size = new System.Drawing.Size(1100, 150);
            this.grpMoTa.TabIndex = 3;
            this.grpMoTa.TabStop = false;
            this.grpMoTa.Text = "Mô tả";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMoTa.Location = new System.Drawing.Point(12, 32);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.ReadOnly = true;
            this.txtMoTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMoTa.Size = new System.Drawing.Size(1076, 106);
            this.txtMoTa.TabIndex = 0;
            // 
            // frmCongViecNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Controls.Add(this.dgvCongViec);
            this.Controls.Add(this.grpMoTa);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmCongViecNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Công việc của tôi";
            this.Load += new System.EventHandler(this.frmCongViecNhanVien_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongViec)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.grpMoTa.ResumeLayout(false);
            this.grpMoTa.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvCongViec;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnHoanThanh;
        private System.Windows.Forms.Button btnDangLam;
        private System.Windows.Forms.GroupBox grpMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
    }
}
