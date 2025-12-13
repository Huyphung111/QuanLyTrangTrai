namespace Đồ_án
{
    partial class QL_CayTrong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QL_CayTrong));
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_QLCayTrong = new System.Windows.Forms.DataGridView();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cbo_TimKiem = new System.Windows.Forms.ComboBox();
            this.txt_MaCay = new System.Windows.Forms.TextBox();
            this.txt_TenCay = new System.Windows.Forms.TextBox();
            this.txt_LoaiCay = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_TimKiem = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btn_Them = new System.Windows.Forms.ToolStripButton();
            this.btn_Xoa = new System.Windows.Forms.ToolStripButton();
            this.btn_Sua = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.btn_Huy = new System.Windows.Forms.ToolStripButton();
            this.toolStrip_thuhoach = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_SanLuongDuKien = new System.Windows.Forms.TextBox();
            this.txt_KhuVuc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_NgayGieoTrong = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_QLCayTrong)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("MS Reference Specialty", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(366, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(456, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ CÂY TRỒNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 402);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 39);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mã cây:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(366, 402);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 39);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên cây:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(828, 402);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 39);
            this.label4.TabIndex = 3;
            this.label4.Text = "Loài cây:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 441);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 41);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày gieo trồng:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgv_QLCayTrong
            // 
            this.dgv_QLCayTrong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_QLCayTrong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgv_QLCayTrong, 6);
            this.dgv_QLCayTrong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_QLCayTrong.Location = new System.Drawing.Point(3, 100);
            this.dgv_QLCayTrong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv_QLCayTrong.Name = "dgv_QLCayTrong";
            this.dgv_QLCayTrong.RowHeadersWidth = 51;
            this.dgv_QLCayTrong.RowTemplate.Height = 24;
            this.dgv_QLCayTrong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_QLCayTrong.Size = new System.Drawing.Size(1191, 234);
            this.dgv_QLCayTrong.TabIndex = 6;
            this.dgv_QLCayTrong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_QLCayTrong_CellContentClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 64);
            // 
            // cbo_TimKiem
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cbo_TimKiem, 2);
            this.cbo_TimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbo_TimKiem.FormattingEnabled = true;
            this.cbo_TimKiem.Location = new System.Drawing.Point(366, 52);
            this.cbo_TimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbo_TimKiem.Name = "cbo_TimKiem";
            this.cbo_TimKiem.Size = new System.Drawing.Size(456, 28);
            this.cbo_TimKiem.TabIndex = 8;
            this.cbo_TimKiem.SelectedIndexChanged += new System.EventHandler(this.cbo_TimKiem_SelectedIndexChanged);
            // 
            // txt_MaCay
            // 
            this.txt_MaCay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_MaCay.Location = new System.Drawing.Point(168, 406);
            this.txt_MaCay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_MaCay.Name = "txt_MaCay";
            this.txt_MaCay.Size = new System.Drawing.Size(192, 26);
            this.txt_MaCay.TabIndex = 10;
            this.txt_MaCay.TextChanged += new System.EventHandler(this.txt_MaCay_TextChanged);
            // 
            // txt_TenCay
            // 
            this.txt_TenCay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_TenCay.Location = new System.Drawing.Point(510, 406);
            this.txt_TenCay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_TenCay.Name = "txt_TenCay";
            this.txt_TenCay.Size = new System.Drawing.Size(312, 26);
            this.txt_TenCay.TabIndex = 11;
            this.txt_TenCay.TextChanged += new System.EventHandler(this.txt_TenCay_TextChanged);
            // 
            // txt_LoaiCay
            // 
            this.txt_LoaiCay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_LoaiCay.Location = new System.Drawing.Point(1019, 406);
            this.txt_LoaiCay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_LoaiCay.Name = "txt_LoaiCay";
            this.txt_LoaiCay.Size = new System.Drawing.Size(175, 26);
            this.txt_LoaiCay.TabIndex = 12;
            this.txt_LoaiCay.TextChanged += new System.EventHandler(this.txt_LoaiCay_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_TimKiem});
            this.toolStrip1.Location = new System.Drawing.Point(825, 48);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(191, 48);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // btn_TimKiem
            // 
            this.btn_TimKiem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_TimKiem.Image = ((System.Drawing.Image)(resources.GetObject("btn_TimKiem.Image")));
            this.btn_TimKiem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_TimKiem.Name = "btn_TimKiem";
            this.btn_TimKiem.Size = new System.Drawing.Size(34, 43);
            this.btn_TimKiem.Text = "Tìm kiếm";
            this.btn_TimKiem.Click += new System.EventHandler(this.btn_TimKiem_Click);
            // 
            // toolStrip2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.toolStrip2, 3);
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Them,
            this.btn_Xoa,
            this.btn_Sua,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.btn_Huy,
            this.toolStrip_thuhoach,
            this.toolStripSeparator,
            this.toolStripSeparator3});
            this.toolStrip2.Location = new System.Drawing.Point(0, 338);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(507, 64);
            this.toolStrip2.TabIndex = 15;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btn_Them
            // 
            this.btn_Them.Image = ((System.Drawing.Image)(resources.GetObject("btn_Them.Image")));
            this.btn_Them.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(80, 59);
            this.btn_Them.Text = "Thêm";
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Image = ((System.Drawing.Image)(resources.GetObject("btn_Xoa.Image")));
            this.btn_Xoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(67, 59);
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.Image = ((System.Drawing.Image)(resources.GetObject("btn_Sua.Image")));
            this.btn_Sua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(66, 59);
            this.btn_Sua.Text = "Sửa";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(65, 59);
            this.toolStripButton2.Text = "Lưu";
            // 
            // btn_Huy
            // 
            this.btn_Huy.Image = ((System.Drawing.Image)(resources.GetObject("btn_Huy.Image")));
            this.btn_Huy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(68, 59);
            this.btn_Huy.Text = "Hủy";
            this.btn_Huy.Click += new System.EventHandler(this.btn_Huy_Click);
            // 
            // toolStrip_thuhoach
            // 
            this.toolStrip_thuhoach.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_thuhoach.Name = "toolStrip_thuhoach";
            this.toolStrip_thuhoach.Size = new System.Drawing.Size(98, 59);
            this.toolStrip_thuhoach.Text = "Thu hoạch";
            this.toolStrip_thuhoach.Click += new System.EventHandler(this.toolStrip_thuhoach_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 64);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 64);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.78446F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.54135F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.03008F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.56642F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.95656F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.03759F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip4, 5, 6);
            this.tableLayoutPanel1.Controls.Add(this.label17, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.dgv_QLCayTrong, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbo_TimKiem, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_MaCay, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txt_TenCay, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.txt_LoaiCay, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_SanLuongDuKien, 5, 5);
            this.tableLayoutPanel1.Controls.Add(this.txt_KhuVuc, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.label7, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_NgayGieoTrong, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.button1, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.45454F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.0075F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.317073F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1197, 533);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // toolStrip4
            // 
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip4.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip4.Location = new System.Drawing.Point(1016, 482);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(181, 51);
            this.toolStrip4.TabIndex = 33;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(81, 46);
            this.toolStripButton1.Text = "Thoát";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Location = new System.Drawing.Point(828, 441);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(185, 41);
            this.label17.TabIndex = 26;
            this.label17.Text = "Sản lượng dự kiến( >0):";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_SanLuongDuKien
            // 
            this.txt_SanLuongDuKien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_SanLuongDuKien.Location = new System.Drawing.Point(1019, 445);
            this.txt_SanLuongDuKien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_SanLuongDuKien.Name = "txt_SanLuongDuKien";
            this.txt_SanLuongDuKien.Size = new System.Drawing.Size(175, 26);
            this.txt_SanLuongDuKien.TabIndex = 34;
            this.txt_SanLuongDuKien.TextChanged += new System.EventHandler(this.txt_SanLuongDuKien_TextChanged);
            // 
            // txt_KhuVuc
            // 
            this.txt_KhuVuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_KhuVuc.Location = new System.Drawing.Point(510, 445);
            this.txt_KhuVuc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_KhuVuc.Name = "txt_KhuVuc";
            this.txt_KhuVuc.Size = new System.Drawing.Size(312, 26);
            this.txt_KhuVuc.TabIndex = 35;
            this.txt_KhuVuc.TextChanged += new System.EventHandler(this.txt_KhuVuc_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(168, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 48);
            this.label7.TabIndex = 36;
            this.label7.Text = "Tìm kiếm:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_NgayGieoTrong
            // 
            this.txt_NgayGieoTrong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_NgayGieoTrong.Location = new System.Drawing.Point(168, 445);
            this.txt_NgayGieoTrong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_NgayGieoTrong.Name = "txt_NgayGieoTrong";
            this.txt_NgayGieoTrong.Size = new System.Drawing.Size(192, 26);
            this.txt_NgayGieoTrong.TabIndex = 37;
            this.txt_NgayGieoTrong.ValueChanged += new System.EventHandler(this.txt_NgayGieoTrong_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1019, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 42);
            this.button1.TabIndex = 39;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(431, 441);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 41);
            this.label6.TabIndex = 40;
            this.label6.Text = "Khu vực: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QL_CayTrong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 533);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QL_CayTrong";
            this.Text = "QL_CayTrong";
            this.Load += new System.EventHandler(this.QL_CayTrong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_QLCayTrong)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btn_Xoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_QLCayTrong;
        private System.Windows.Forms.ComboBox cbo_TimKiem;
        private System.Windows.Forms.TextBox txt_MaCay;
        private System.Windows.Forms.TextBox txt_TenCay;
        private System.Windows.Forms.TextBox txt_LoaiCay;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_TimKiem;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btn_Them;
        private System.Windows.Forms.ToolStripButton btn_Sua;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_Huy;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_SanLuongDuKien;
        private System.Windows.Forms.TextBox txt_KhuVuc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn maCayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenCayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loaiCayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayGieoTrongDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn khuVucDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sanLuongDuKienDataGridViewTextBoxColumn;
        private System.Windows.Forms.DateTimePicker txt_NgayGieoTrong;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStrip_thuhoach;
    }
}