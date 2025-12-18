namespace QL_TrangTrai
{
    partial class frmBackupDatabase
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
            this.grpBackup = new System.Windows.Forms.GroupBox();
            this.btnLogBackup = new System.Windows.Forms.Button();
            this.btnDiffBackup = new System.Windows.Forms.Button();
            this.btnFullBackup = new System.Windows.Forms.Button();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.lblBackupPath = new System.Windows.Forms.Label();
            this.grpRestore = new System.Windows.Forms.GroupBox();
            this.lblWarning = new System.Windows.Forms.Label();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.txtRestoreFile = new System.Windows.Forms.TextBox();
            this.lblRestoreFile = new System.Windows.Forms.Label();
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpBackup.SuspendLayout();
            this.grpRestore.SuspendLayout();
            this.grpLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBackup
            // 
            this.grpBackup.Controls.Add(this.btnLogBackup);
            this.grpBackup.Controls.Add(this.btnDiffBackup);
            this.grpBackup.Controls.Add(this.btnFullBackup);
            this.grpBackup.Controls.Add(this.txtBackupPath);
            this.grpBackup.Controls.Add(this.lblBackupPath);
            this.grpBackup.Location = new System.Drawing.Point(18, 69);
            this.grpBackup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpBackup.Name = "grpBackup";
            this.grpBackup.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpBackup.Size = new System.Drawing.Size(555, 277);
            this.grpBackup.TabIndex = 1;
            this.grpBackup.TabStop = false;
            this.grpBackup.Text = "1. Sao lưu Dữ liệu (Backup)";
            // 
            // btnLogBackup
            // 
            this.btnLogBackup.BackColor = System.Drawing.Color.Orange;
            this.btnLogBackup.ForeColor = System.Drawing.Color.Black;
            this.btnLogBackup.Location = new System.Drawing.Point(22, 208);
            this.btnLogBackup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogBackup.Name = "btnLogBackup";
            this.btnLogBackup.Size = new System.Drawing.Size(510, 54);
            this.btnLogBackup.TabIndex = 4;
            this.btnLogBackup.Text = "LOG BACKUP (Sao lưu Nhật ký)";
            this.btnLogBackup.UseVisualStyleBackColor = false;
            this.btnLogBackup.Click += new System.EventHandler(this.btnLogBackup_Click);
            // 
            // btnDiffBackup
            // 
            this.btnDiffBackup.BackColor = System.Drawing.Color.Purple;
            this.btnDiffBackup.ForeColor = System.Drawing.Color.White;
            this.btnDiffBackup.Location = new System.Drawing.Point(22, 146);
            this.btnDiffBackup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDiffBackup.Name = "btnDiffBackup";
            this.btnDiffBackup.Size = new System.Drawing.Size(510, 54);
            this.btnDiffBackup.TabIndex = 3;
            this.btnDiffBackup.Text = "DIFFERENTIAL BACKUP (Sao lưu Khác biệt)";
            this.btnDiffBackup.UseVisualStyleBackColor = false;
            this.btnDiffBackup.Click += new System.EventHandler(this.btnDiffBackup_Click);
            // 
            // btnFullBackup
            // 
            this.btnFullBackup.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnFullBackup.ForeColor = System.Drawing.Color.White;
            this.btnFullBackup.Location = new System.Drawing.Point(22, 85);
            this.btnFullBackup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFullBackup.Name = "btnFullBackup";
            this.btnFullBackup.Size = new System.Drawing.Size(510, 54);
            this.btnFullBackup.TabIndex = 2;
            this.btnFullBackup.Text = "FULL BACKUP (Sao lưu Đầy đủ)";
            this.btnFullBackup.UseVisualStyleBackColor = false;
            this.btnFullBackup.Click += new System.EventHandler(this.btnFullBackup_Click);
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Location = new System.Drawing.Point(98, 34);
            this.txtBackupPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new System.Drawing.Size(433, 26);
            this.txtBackupPath.TabIndex = 1;
            this.txtBackupPath.Text = "D:\\Backup\\";
            // 
            // lblBackupPath
            // 
            this.lblBackupPath.Location = new System.Drawing.Point(15, 38);
            this.lblBackupPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBackupPath.Name = "lblBackupPath";
            this.lblBackupPath.Size = new System.Drawing.Size(75, 31);
            this.lblBackupPath.TabIndex = 0;
            this.lblBackupPath.Text = "Lưu tại:";
            // 
            // grpRestore
            // 
            this.grpRestore.Controls.Add(this.lblWarning);
            this.grpRestore.Controls.Add(this.btnRestore);
            this.grpRestore.Controls.Add(this.btnBrowseFile);
            this.grpRestore.Controls.Add(this.txtRestoreFile);
            this.grpRestore.Controls.Add(this.lblRestoreFile);
            this.grpRestore.Location = new System.Drawing.Point(600, 69);
            this.grpRestore.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpRestore.Name = "grpRestore";
            this.grpRestore.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpRestore.Size = new System.Drawing.Size(555, 277);
            this.grpRestore.TabIndex = 2;
            this.grpRestore.TabStop = false;
            this.grpRestore.Text = "2. Phục hồi Dữ liệu (Restore)";
            // 
            // lblWarning
            // 
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(22, 208);
            this.lblWarning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(510, 54);
            this.lblWarning.TabIndex = 4;
            this.lblWarning.Text = "Cảnh báo: Hệ thống sẽ ngắt kết nối để phục hồi.";
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.LimeGreen;
            this.btnRestore.ForeColor = System.Drawing.Color.White;
            this.btnRestore.Location = new System.Drawing.Point(22, 131);
            this.btnRestore.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(510, 62);
            this.btnRestore.TabIndex = 3;
            this.btnRestore.Text = "TIẾN HÀNH PHỤC HỒI";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.BackColor = System.Drawing.Color.Gold;
            this.btnBrowseFile.Location = new System.Drawing.Point(480, 74);
            this.btnBrowseFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(52, 37);
            this.btnBrowseFile.TabIndex = 2;
            this.btnBrowseFile.Text = "...";
            this.btnBrowseFile.UseVisualStyleBackColor = false;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // txtRestoreFile
            // 
            this.txtRestoreFile.Location = new System.Drawing.Point(22, 77);
            this.txtRestoreFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRestoreFile.Name = "txtRestoreFile";
            this.txtRestoreFile.Size = new System.Drawing.Size(448, 26);
            this.txtRestoreFile.TabIndex = 1;
            // 
            // lblRestoreFile
            // 
            this.lblRestoreFile.Location = new System.Drawing.Point(15, 38);
            this.lblRestoreFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRestoreFile.Name = "lblRestoreFile";
            this.lblRestoreFile.Size = new System.Drawing.Size(225, 31);
            this.lblRestoreFile.TabIndex = 0;
            this.lblRestoreFile.Text = "Chọn file bản sao (.bak / .trn):";
            // 
            // grpLog
            // 
            this.grpLog.Controls.Add(this.rtbLog);
            this.grpLog.Location = new System.Drawing.Point(18, 362);
            this.grpLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpLog.Name = "grpLog";
            this.grpLog.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpLog.Size = new System.Drawing.Size(1137, 308);
            this.grpLog.TabIndex = 3;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "Nhật ký hệ thống";
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.Color.Black;
            this.rtbLog.ForeColor = System.Drawing.Color.Lime;
            this.rtbLog.Location = new System.Drawing.Point(15, 31);
            this.rtbLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(1105, 259);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "All Backup Files (*.bak;*.trn)|*.bak;*.trn|Full/Diff Backup (*.bak)|*.bak|Log Bac" +
    "kup (*.trn)|*.trn|All Files (*.*)|*.*";
            this.openFileDialog1.Title = "Chọn file backup";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(18, 14);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1140, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN TRỊ HỆ THỐNG  AN TOÀN DỮ LIỆU";
            // 
            // frmBackupDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 692);
            this.Controls.Add(this.grpLog);
            this.Controls.Add(this.grpRestore);
            this.Controls.Add(this.grpBackup);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmBackupDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản trị Hệ thống - An toàn Dữ liệu";
            this.Load += new System.EventHandler(this.frmBackupDatabase_Load);
            this.grpBackup.ResumeLayout(false);
            this.grpBackup.PerformLayout();
            this.grpRestore.ResumeLayout(false);
            this.grpRestore.PerformLayout();
            this.grpLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpBackup;
        private System.Windows.Forms.Button btnLogBackup;
        private System.Windows.Forms.Button btnDiffBackup;
        private System.Windows.Forms.Button btnFullBackup;
        private System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.Label lblBackupPath;
        private System.Windows.Forms.GroupBox grpRestore;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.TextBox txtRestoreFile;
        private System.Windows.Forms.Label lblRestoreFile;
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}