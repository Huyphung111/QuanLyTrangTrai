
namespace QuanLyTrangTrai
{
    partial class GiaoDien
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
            this.leftPanel = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAccounts = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnInvoices = new System.Windows.Forms.Button();
            this.btnAccessories = new System.Windows.Forms.Button();
            this.btnServices = new System.Windows.Forms.Button();
            this.btnPets = new System.Windows.Forms.Button();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.leftPanel.SuspendLayout();
            this.logoPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(76)))), ((int)(((byte)(67)))));
            this.leftPanel.Controls.Add(this.button1);
            this.leftPanel.Controls.Add(this.btnAccessories);
            this.leftPanel.Controls.Add(this.btnServices);
            this.leftPanel.Controls.Add(this.btnPets);
            this.leftPanel.Controls.Add(this.logoPanel);
            this.leftPanel.Controls.Add(this.btnInvoices);
            this.leftPanel.Controls.Add(this.btnReports);
            this.leftPanel.Controls.Add(this.btnAccounts);
            this.leftPanel.Controls.Add(this.btnExit);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(248, 948);
            this.leftPanel.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(76)))), ((int)(((byte)(67)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.Khaki;
            this.btnExit.Location = new System.Drawing.Point(-3, 678);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(248, 88);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "   Thoát";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAccounts
            // 
            this.btnAccounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(76)))), ((int)(((byte)(67)))));
            this.btnAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAccounts.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAccounts.ForeColor = System.Drawing.Color.Khaki;
            this.btnAccounts.Location = new System.Drawing.Point(-3, 592);
            this.btnAccounts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.Size = new System.Drawing.Size(248, 88);
            this.btnAccounts.TabIndex = 6;
            this.btnAccounts.Text = "   Tài khoản";
            this.btnAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccounts.UseVisualStyleBackColor = false;
            this.btnAccounts.Click += new System.EventHandler(this.btnQuanLyTaiKhoan_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(76)))), ((int)(((byte)(67)))));
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReports.ForeColor = System.Drawing.Color.Khaki;
            this.btnReports.Location = new System.Drawing.Point(0, 351);
            this.btnReports.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(248, 80);
            this.btnReports.TabIndex = 5;
            this.btnReports.Text = "   Lịch công việc";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnLichCongViec_Click);
            // 
            // btnInvoices
            // 
            this.btnInvoices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(76)))), ((int)(((byte)(67)))));
            this.btnInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInvoices.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnInvoices.ForeColor = System.Drawing.Color.Khaki;
            this.btnInvoices.Location = new System.Drawing.Point(-3, 506);
            this.btnInvoices.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnInvoices.Name = "btnInvoices";
            this.btnInvoices.Size = new System.Drawing.Size(248, 88);
            this.btnInvoices.TabIndex = 4;
            this.btnInvoices.Text = "   Thu hoạch";
            this.btnInvoices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInvoices.UseVisualStyleBackColor = false;
            this.btnInvoices.Click += new System.EventHandler(this.btnThuHoach_Click);
            // 
            // btnAccessories
            // 
            this.btnAccessories.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(76)))), ((int)(((byte)(67)))));
            this.btnAccessories.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAccessories.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAccessories.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAccessories.ForeColor = System.Drawing.Color.Khaki;
            this.btnAccessories.Location = new System.Drawing.Point(0, 264);
            this.btnAccessories.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAccessories.Name = "btnAccessories";
            this.btnAccessories.Size = new System.Drawing.Size(248, 88);
            this.btnAccessories.TabIndex = 3;
            this.btnAccessories.Text = "   Sản phẩm";
            this.btnAccessories.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccessories.UseVisualStyleBackColor = false;
            this.btnAccessories.Click += new System.EventHandler(this.btnQLSanPham_Click);
            // 
            // btnServices
            // 
            this.btnServices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(76)))), ((int)(((byte)(67)))));
            this.btnServices.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnServices.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnServices.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnServices.ForeColor = System.Drawing.Color.Khaki;
            this.btnServices.Location = new System.Drawing.Point(0, 176);
            this.btnServices.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnServices.Name = "btnServices";
            this.btnServices.Size = new System.Drawing.Size(248, 88);
            this.btnServices.TabIndex = 2;
            this.btnServices.Text = "   Vật nuôi";
            this.btnServices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnServices.UseVisualStyleBackColor = false;
            this.btnServices.Click += new System.EventHandler(this.btnQLVatNuoi_Click);
            // 
            // btnPets
            // 
            this.btnPets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(76)))), ((int)(((byte)(67)))));
            this.btnPets.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPets.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPets.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPets.ForeColor = System.Drawing.Color.Khaki;
            this.btnPets.Location = new System.Drawing.Point(0, 88);
            this.btnPets.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPets.Name = "btnPets";
            this.btnPets.Size = new System.Drawing.Size(248, 88);
            this.btnPets.TabIndex = 1;
            this.btnPets.Text = "   Cây trồng";
            this.btnPets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPets.UseVisualStyleBackColor = false;
            this.btnPets.Click += new System.EventHandler(this.btnQLCayTrong_Click);
            // 
            // logoPanel
            // 
            this.logoPanel.Controls.Add(this.panel2);
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(248, 88);
            this.logoPanel.TabIndex = 0;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.topPanel.Controls.Add(this.lblHeader);
            this.topPanel.Controls.Add(this.panel3);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(248, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1103, 88);
            this.topPanel.TabIndex = 1;
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(76)))), ((int)(((byte)(67)))));
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.Khaki;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1103, 88);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "QUẢN LÝ TRANG TRẠI";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.SystemColors.Control;
            this.mainPanel.Controls.Add(this.panel1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(248, 88);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1103, 860);
            this.mainPanel.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1103, 860);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(76)))), ((int)(((byte)(67)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Khaki;
            this.button1.Location = new System.Drawing.Point(-3, 427);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(248, 88);
            this.button1.TabIndex = 8;
            this.button1.Text = "   Kho Thiết Bị";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(12, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1103, 88);
            this.panel3.TabIndex = 1;
            // 
            // MainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 948);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.leftPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(897, 611);
            this.Name = "MainDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng điều khiển chức năng";
            this.leftPanel.ResumeLayout(false);
            this.logoPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAccounts;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnInvoices;
        private System.Windows.Forms.Button btnAccessories;
        private System.Windows.Forms.Button btnServices;
        private System.Windows.Forms.Button btnPets;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}