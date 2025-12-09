namespace GiaoDienDangNhap
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
            this.groupThongTin = new System.Windows.Forms.GroupBox();
            this.txt_MaGD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_LoaiGD = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_SoTien = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_NgayGD = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_MoTa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbo_PhuongThucTT = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbo_NhanVien = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbo_NhaCungCap = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();

            this.dgv_TaiChinh = new System.Windows.Forms.DataGridView();
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();

            this.groupThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TaiChinh)).BeginInit();
            this.SuspendLayout();

            // groupThongTin
            this.groupThongTin.Controls.Add(this.cbo_NhaCungCap);
            this.groupThongTin.Controls.Add(this.label8);
            this.groupThongTin.Controls.Add(this.cbo_NhanVien);
            this.groupThongTin.Controls.Add(this.label7);
            this.groupThongTin.Controls.Add(this.cbo_PhuongThucTT);
            this.groupThongTin.Controls.Add(this.label6);
            this.groupThongTin.Controls.Add(this.txt_MoTa);
            this.groupThongTin.Controls.Add(this.label5);
            this.groupThongTin.Controls.Add(this.dtp_NgayGD);
            this.groupThongTin.Controls.Add(this.label4);
            this.groupThongTin.Controls.Add(this.txt_SoTien);
            this.groupThongTin.Controls.Add(this.label3);
            this.groupThongTin.Controls.Add(this.cbo_LoaiGD);
            this.groupThongTin.Controls.Add(this.label2);
            this.groupThongTin.Controls.Add(this.txt_MaGD);
            this.groupThongTin.Controls.Add(this.label1);
            this.groupThongTin.Location = new System.Drawing.Point(12, 12);
            this.groupThongTin.Name = "groupThongTin";
            this.groupThongTin.Size = new System.Drawing.Size(820, 170);
            this.groupThongTin.TabIndex = 0;
            this.groupThongTin.TabStop = false;
            this.groupThongTin.Text = "THÔNG TIN GIAO DỊCH (BẢNG TÀI CHÍNH)";

            // label1 - MaGD
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã giao dịch:";

            this.txt_MaGD.Location = new System.Drawing.Point(100, 27);
            this.txt_MaGD.Name = "txt_MaGD";
            this.txt_MaGD.ReadOnly = true;
            this.txt_MaGD.Size = new System.Drawing.Size(100, 20);
            this.txt_MaGD.TabIndex = 1;

            // label2 - LoaiGD
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Loại giao:";

            this.cbo_LoaiGD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_LoaiGD.Location = new System.Drawing.Point(100, 57);
            this.cbo_LoaiGD.Name = "cbo_LoaiGD";
            this.cbo_LoaiGD.Size = new System.Drawing.Size(100, 21);
            this.cbo_LoaiGD.TabIndex = 3;

            // label3 - SoTien
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số tiền:";

            this.txt_SoTien.Location = new System.Drawing.Point(100, 87);
            this.txt_SoTien.Name = "txt_SoTien";
            this.txt_SoTien.Size = new System.Drawing.Size(150, 20);
            this.txt_SoTien.TabIndex = 5;

            // label4 - NgayGD
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ngày giao:";

            this.dtp_NgayGD.Location = new System.Drawing.Point(100, 117);
            this.dtp_NgayGD.Name = "dtp_NgayGD";
            this.dtp_NgayGD.Size = new System.Drawing.Size(200, 20);
            this.dtp_NgayGD.TabIndex = 7;

            // label5 - MoTa
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(330, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Mô tả:";

            this.txt_MoTa.Location = new System.Drawing.Point(380, 27);
            this.txt_MoTa.Multiline = true;
            this.txt_MoTa.Name = "txt_MoTa";
            this.txt_MoTa.Size = new System.Drawing.Size(200, 60);
            this.txt_MoTa.TabIndex = 9;

            // label6 - PhuongThucTT
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(330, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Phương thức:";

            this.cbo_PhuongThucTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_PhuongThucTT.Location = new System.Drawing.Point(410, 97);
            this.cbo_PhuongThucTT.Name = "cbo_PhuongThucTT";
            this.cbo_PhuongThucTT.Size = new System.Drawing.Size(170, 21);
            this.cbo_PhuongThucTT.TabIndex = 11;

            // label7 - NhanVien
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(610, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Nhân viên:";

            this.cbo_NhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_NhanVien.Location = new System.Drawing.Point(680, 27);
            this.cbo_NhanVien.Name = "cbo_NhanVien";
            this.cbo_NhanVien.Size = new System.Drawing.Size(120, 21);
            this.cbo_NhanVien.TabIndex = 13;

            // label8 - NhaCungCap
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(610, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Nhà cung cấp:";

            this.cbo_NhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_NhaCungCap.Location = new System.Drawing.Point(680, 62);
            this.cbo_NhaCungCap.Name = "cbo_NhaCungCap";
            this.cbo_NhaCungCap.Size = new System.Drawing.Size(120, 21);
            this.cbo_NhaCungCap.TabIndex = 15;

            // dgv_TaiChinh
            this.dgv_TaiChinh.AllowUserToAddRows = false;
            this.dgv_TaiChinh.AllowUserToDeleteRows = false;
            this.dgv_TaiChinh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_TaiChinh.Location = new System.Drawing.Point(12, 190);
            this.dgv_TaiChinh.MultiSelect = false;
            this.dgv_TaiChinh.Name = "dgv_TaiChinh";
            this.dgv_TaiChinh.ReadOnly = true;
            this.dgv_TaiChinh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_TaiChinh.Size = new System.Drawing.Size(820, 260);
            this.dgv_TaiChinh.TabIndex = 1;
            this.dgv_TaiChinh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_TaiChinh_CellClick);

            // Buttons
            this.btn_Them.Location = new System.Drawing.Point(230, 460);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(75, 30);
            this.btn_Them.TabIndex = 2;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);

            this.btn_Luu.Location = new System.Drawing.Point(330, 460);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(75, 30);
            this.btn_Luu.TabIndex = 3;
            this.btn_Luu.Text = "Lưu";
            this.btn_Luu.UseVisualStyleBackColor = true;
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);

            this.btn_Xoa.Location = new System.Drawing.Point(430, 460);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(75, 30);
            this.btn_Xoa.TabIndex = 4;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);

            this.btn_Thoat.Location = new System.Drawing.Point(530, 460);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(75, 30);
            this.btn_Thoat.TabIndex = 5;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);

            // frmTaiChinh
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 501);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_Luu);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.dgv_TaiChinh);
            this.Controls.Add(this.groupThongTin);
            this.Name = "frmTaiChinh";
            this.Text = "Quản lý giao dịch - Bảng Tài Chính";

            // ⭐ RẤT QUAN TRỌNG: gắn sự kiện Load
            this.Load += new System.EventHandler(this.frmTaiChinh_Load);

            this.groupThongTin.ResumeLayout(false);
            this.groupThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TaiChinh)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupThongTin;
        private System.Windows.Forms.TextBox txt_MaGD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_LoaiGD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_SoTien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_NgayGD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_MoTa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbo_PhuongThucTT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbo_NhanVien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbo_NhaCungCap;
        private System.Windows.Forms.Label label8;

        private System.Windows.Forms.DataGridView dgv_TaiChinh;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Thoat;
    }
}
