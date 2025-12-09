namespace GiaoDienDangNhap
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
            this.groupTaiChinh = new System.Windows.Forms.GroupBox();
            this.dgv_TaiChinh = new System.Windows.Forms.DataGridView();
            this.groupChiTiet = new System.Windows.Forms.GroupBox();
            this.dgv_ChiTiet = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_MaChiTiet = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_MaGiaoDich = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_SanPham = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_SoLuong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_DonGia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_ThanhTien = new System.Windows.Forms.TextBox();
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.groupTaiChinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TaiChinh)).BeginInit();
            this.groupChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // groupTaiChinh
            // 
            this.groupTaiChinh.Controls.Add(this.dgv_TaiChinh);
            this.groupTaiChinh.Location = new System.Drawing.Point(12, 12);
            this.groupTaiChinh.Name = "groupTaiChinh";
            this.groupTaiChinh.Size = new System.Drawing.Size(860, 200);
            this.groupTaiChinh.TabIndex = 0;
            this.groupTaiChinh.TabStop = false;
            this.groupTaiChinh.Text = "DANH SÁCH GIAO DỊCH (BẢNG TÀI CHÍNH)";
            // 
            // dgv_TaiChinh
            // 
            this.dgv_TaiChinh.AllowUserToAddRows = false;
            this.dgv_TaiChinh.AllowUserToDeleteRows = false;
            this.dgv_TaiChinh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_TaiChinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TaiChinh.Location = new System.Drawing.Point(10, 20);
            this.dgv_TaiChinh.MultiSelect = false;
            this.dgv_TaiChinh.Name = "dgv_TaiChinh";
            this.dgv_TaiChinh.ReadOnly = true;
            this.dgv_TaiChinh.RowHeadersWidth = 62;
            this.dgv_TaiChinh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_TaiChinh.Size = new System.Drawing.Size(840, 170);
            this.dgv_TaiChinh.TabIndex = 0;
            this.dgv_TaiChinh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_TaiChinh_CellClick);
            // 
            // groupChiTiet
            // 
            this.groupChiTiet.Controls.Add(this.dgv_ChiTiet);
            this.groupChiTiet.Controls.Add(this.label1);
            this.groupChiTiet.Controls.Add(this.txt_MaChiTiet);
            this.groupChiTiet.Controls.Add(this.label2);
            this.groupChiTiet.Controls.Add(this.txt_MaGiaoDich);
            this.groupChiTiet.Controls.Add(this.label3);
            this.groupChiTiet.Controls.Add(this.cbo_SanPham);
            this.groupChiTiet.Controls.Add(this.label4);
            this.groupChiTiet.Controls.Add(this.txt_SoLuong);
            this.groupChiTiet.Controls.Add(this.label5);
            this.groupChiTiet.Controls.Add(this.txt_DonGia);
            this.groupChiTiet.Controls.Add(this.label6);
            this.groupChiTiet.Controls.Add(this.txt_ThanhTien);
            this.groupChiTiet.Location = new System.Drawing.Point(12, 218);
            this.groupChiTiet.Name = "groupChiTiet";
            this.groupChiTiet.Size = new System.Drawing.Size(860, 260);
            this.groupChiTiet.TabIndex = 1;
            this.groupChiTiet.TabStop = false;
            this.groupChiTiet.Text = "CHI TIẾT GIAO DỊCH (BẢNG ChiTietGiaoDich)";
            // 
            // dgv_ChiTiet
            // 
            this.dgv_ChiTiet.AllowUserToAddRows = false;
            this.dgv_ChiTiet.AllowUserToDeleteRows = false;
            this.dgv_ChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ChiTiet.Location = new System.Drawing.Point(10, 100);
            this.dgv_ChiTiet.MultiSelect = false;
            this.dgv_ChiTiet.Name = "dgv_ChiTiet";
            this.dgv_ChiTiet.ReadOnly = true;
            this.dgv_ChiTiet.RowHeadersWidth = 62;
            this.dgv_ChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ChiTiet.Size = new System.Drawing.Size(840, 150);
            this.dgv_ChiTiet.TabIndex = 12;
            this.dgv_ChiTiet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ChiTiet_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã chi tiết:";
            // 
            // txt_MaChiTiet
            // 
            this.txt_MaChiTiet.Location = new System.Drawing.Point(85, 27);
            this.txt_MaChiTiet.Name = "txt_MaChiTiet";
            this.txt_MaChiTiet.ReadOnly = true;
            this.txt_MaChiTiet.Size = new System.Drawing.Size(80, 26);
            this.txt_MaChiTiet.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã giao dịch:";
            // 
            // txt_MaGiaoDich
            // 
            this.txt_MaGiaoDich.Location = new System.Drawing.Point(265, 27);
            this.txt_MaGiaoDich.Name = "txt_MaGiaoDich";
            this.txt_MaGiaoDich.ReadOnly = true;
            this.txt_MaGiaoDich.Size = new System.Drawing.Size(80, 26);
            this.txt_MaGiaoDich.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(370, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sản phẩm:";
            // 
            // cbo_SanPham
            // 
            this.cbo_SanPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_SanPham.Location = new System.Drawing.Point(462, 25);
            this.cbo_SanPham.Name = "cbo_SanPham";
            this.cbo_SanPham.Size = new System.Drawing.Size(180, 28);
            this.cbo_SanPham.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Số lượng:";
            // 
            // txt_SoLuong
            // 
            this.txt_SoLuong.Location = new System.Drawing.Point(85, 62);
            this.txt_SoLuong.Name = "txt_SoLuong";
            this.txt_SoLuong.Size = new System.Drawing.Size(80, 26);
            this.txt_SoLuong.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(185, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Đơn giá:";
            // 
            // txt_DonGia
            // 
            this.txt_DonGia.Location = new System.Drawing.Point(265, 62);
            this.txt_DonGia.Name = "txt_DonGia";
            this.txt_DonGia.Size = new System.Drawing.Size(120, 26);
            this.txt_DonGia.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(410, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Thành tiền:";
            // 
            // txt_ThanhTien
            // 
            this.txt_ThanhTien.Location = new System.Drawing.Point(480, 62);
            this.txt_ThanhTien.Name = "txt_ThanhTien";
            this.txt_ThanhTien.ReadOnly = true;
            this.txt_ThanhTien.Size = new System.Drawing.Size(135, 26);
            this.txt_ThanhTien.TabIndex = 11;
            // 
            // btn_Them
            // 
            this.btn_Them.Location = new System.Drawing.Point(230, 485);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(75, 30);
            this.btn_Them.TabIndex = 2;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // btn_Luu
            // 
            this.btn_Luu.Location = new System.Drawing.Point(330, 485);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(75, 30);
            this.btn_Luu.TabIndex = 3;
            this.btn_Luu.Text = "Lưu";
            this.btn_Luu.UseVisualStyleBackColor = true;
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Location = new System.Drawing.Point(430, 485);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(75, 30);
            this.btn_Xoa.TabIndex = 4;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Location = new System.Drawing.Point(530, 485);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(75, 30);
            this.btn_Thoat.TabIndex = 5;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // frmChiTietGiaoDich
            // 
            this.ClientSize = new System.Drawing.Size(884, 531);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_Luu);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.groupChiTiet);
            this.Controls.Add(this.groupTaiChinh);
            this.Name = "frmChiTietGiaoDich";
            this.Text = "Chi tiết giao dịch (TaiChinh + ChiTietGiaoDich)";
            this.Load += new System.EventHandler(this.frmChiTietGiaoDich_Load);
            this.groupTaiChinh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TaiChinh)).EndInit();
            this.groupChiTiet.ResumeLayout(false);
            this.groupChiTiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ChiTiet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupTaiChinh;
        private System.Windows.Forms.DataGridView dgv_TaiChinh;
        private System.Windows.Forms.GroupBox groupChiTiet;
        private System.Windows.Forms.DataGridView dgv_ChiTiet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_MaChiTiet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_MaGiaoDich;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbo_SanPham;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_SoLuong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_DonGia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_ThanhTien;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Thoat;
    }
}
