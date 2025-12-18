using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QL_TrangTrai
{
    public partial class frmBackupDatabase : Form
    {
        // Connection string - chỉnh theo máy của bạn
        private string connectionString = @"Data Source=HUYNE;Initial Catalog=master;Integrated Security=True";
        private string databaseName = "QL_TrangTraiv13";

        public frmBackupDatabase()
        {
            InitializeComponent();
        }

        private void frmBackupDatabase_Load(object sender, EventArgs e)
        {
            WriteLog("Hệ thống sẵn sàng.", Color.Lime);
            WriteLog("Database: " + databaseName, Color.Cyan);
        }

        // Ghi log ra màn hình
        private void WriteLog(string message, Color color)
        {
            rtbLog.SelectionStart = rtbLog.TextLength;
            rtbLog.SelectionLength = 0;
            rtbLog.SelectionColor = color;
            rtbLog.AppendText("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + message + "\n");
            rtbLog.ScrollToCaret();
        }

        // ========== BACKUP ==========

        private void btnFullBackup_Click(object sender, EventArgs e)
        {
            DoBackup("FULL");
        }

        private void btnDiffBackup_Click(object sender, EventArgs e)
        {
            DoBackup("DIFFERENTIAL");
        }

        private void btnLogBackup_Click(object sender, EventArgs e)
        {
            DoBackup("LOG");
        }

        private void DoBackup(string backupType)
        {
            // Kiểm tra thư mục
            string backupPath = txtBackupPath.Text.Trim();
            if (string.IsNullOrEmpty(backupPath))
            {
                MessageBox.Show("Vui lòng nhập đường dẫn lưu backup!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo thư mục nếu chưa có
            if (!Directory.Exists(backupPath))
            {
                try
                {
                    Directory.CreateDirectory(backupPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tạo thư mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Tạo tên file
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string extension = (backupType == "LOG") ? ".trn" : ".bak";
            string fileName = databaseName + "_" + backupType + "_" + timestamp + extension;
            string fullPath = Path.Combine(backupPath, fileName);

            // Tạo câu lệnh SQL (không dùng COMPRESSION vì Express Edition không hỗ trợ)
            string sql = "";
            switch (backupType)
            {
                case "FULL":
                    sql = string.Format(@"
                        BACKUP DATABASE [{0}]
                        TO DISK = N'{1}'
                        WITH FORMAT,
                        NAME = N'Full Backup - {2}'",
                        databaseName, fullPath, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                    break;

                case "DIFFERENTIAL":
                    sql = string.Format(@"
                        BACKUP DATABASE [{0}]
                        TO DISK = N'{1}'
                        WITH DIFFERENTIAL,
                        NAME = N'Differential Backup - {2}'",
                        databaseName, fullPath, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                    break;

                case "LOG":
                    // LOG BACKUP yêu cầu:
                    // 1. Recovery Model = FULL
                    // 2. Phải có FULL BACKUP trước đó
                    sql = string.Format(@"
                        -- Chuyển sang FULL recovery nếu đang là SIMPLE
                        IF (SELECT recovery_model_desc FROM sys.databases WHERE name = '{0}') = 'SIMPLE'
                        BEGIN
                            ALTER DATABASE [{0}] SET RECOVERY FULL;
                        END
                        
                        -- Kiểm tra nếu chưa có Full Backup thì backup Full trước
                        IF NOT EXISTS (
                            SELECT 1 FROM msdb.dbo.backupset 
                            WHERE database_name = '{0}' AND type = 'D'
                            AND backup_finish_date > (SELECT create_date FROM sys.databases WHERE name = '{0}')
                        )
                        BEGIN
                            BACKUP DATABASE [{0}] TO DISK = N'{1}_FULL_AUTO.bak' WITH FORMAT, NAME = N'Auto Full Backup';
                        END
                        
                        -- Thực hiện Log Backup
                        BACKUP LOG [{0}]
                        TO DISK = N'{1}'
                        WITH NAME = N'Log Backup - {2}'",
                        databaseName, fullPath, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                    break;
            }

            // Thực hiện backup
            WriteLog("Đang thực hiện " + backupType + " BACKUP...", Color.Yellow);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandTimeout = 300; // 5 phút
                        cmd.ExecuteNonQuery();
                    }
                }

                WriteLog(backupType + " BACKUP thành công!", Color.Lime);
                WriteLog("File: " + fullPath, Color.White);

                MessageBox.Show(backupType + " BACKUP thành công!\n\nFile: " + fileName,
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                WriteLog("Lỗi: " + ex.Message, Color.Red);
                MessageBox.Show("Lỗi backup: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== RESTORE ==========

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRestoreFile.Text = openFileDialog1.FileName;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            // Kiểm tra file
            string restoreFile = txtRestoreFile.Text.Trim();
            if (string.IsNullOrEmpty(restoreFile))
            {
                MessageBox.Show("Vui lòng chọn file backup!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(restoreFile))
            {
                MessageBox.Show("File không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nhận diện loại backup từ tên file
            string fileName = Path.GetFileName(restoreFile).ToUpper();
            bool isDifferential = fileName.Contains("DIFF") || fileName.Contains("DIFFERENTIAL");
            bool isLog = fileName.Contains("LOG") || restoreFile.EndsWith(".trn", StringComparison.OrdinalIgnoreCase);
            bool isFull = fileName.Contains("FULL") || (!isDifferential && !isLog);

            // Nếu là DIFF hoặc LOG, cần hỏi file FULL
            string fullBackupFile = "";
            if (isDifferential || isLog)
            {
                MessageBox.Show(
                    "Bạn đang restore file " + (isDifferential ? "DIFFERENTIAL" : "LOG") + ".\n\n" +
                    "Cần chọn file FULL BACKUP trước!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Full Backup (*.bak)|*.bak";
                ofd.Title = "Chọn file FULL BACKUP";
                ofd.InitialDirectory = Path.GetDirectoryName(restoreFile);

                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                fullBackupFile = ofd.FileName;
            }

            // Xác nhận
            string confirmMsg = "Bạn có chắc muốn phục hồi database?\n\n";
            if (isDifferential || isLog)
            {
                confirmMsg += "Bước 1: Restore FULL từ:\n" + Path.GetFileName(fullBackupFile) + "\n\n";
                confirmMsg += "Bước 2: Restore " + (isDifferential ? "DIFFERENTIAL" : "LOG") + " từ:\n" + Path.GetFileName(restoreFile) + "\n\n";
            }
            confirmMsg += "⚠ Dữ liệu hiện tại sẽ bị ghi đè!\n⚠ Tất cả kết nối sẽ bị ngắt!";

            DialogResult result = MessageBox.Show(confirmMsg, "Xác nhận phục hồi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Bước 1: Ngắt kết nối
                    WriteLog("Đang ngắt kết nối người dùng...", Color.White);
                    string sqlSingle = string.Format(
                        "ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", databaseName);
                    using (SqlCommand cmd = new SqlCommand(sqlSingle, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    if (isDifferential || isLog)
                    {
                        // === RESTORE FULL + DIFF/LOG ===

                        // Bước 2a: Restore FULL với NORECOVERY
                        WriteLog("Đang phục hồi FULL BACKUP...", Color.Yellow);
                        string sqlRestoreFull = string.Format(@"
                            RESTORE DATABASE [{0}]
                            FROM DISK = N'{1}'
                            WITH REPLACE, NORECOVERY",
                            databaseName, fullBackupFile);
                        using (SqlCommand cmd = new SqlCommand(sqlRestoreFull, conn))
                        {
                            cmd.CommandTimeout = 600;
                            cmd.ExecuteNonQuery();
                        }
                        WriteLog("FULL BACKUP đã restore!", Color.Lime);

                        // Bước 2b: Restore DIFF/LOG với RECOVERY
                        WriteLog("Đang phục hồi " + (isDifferential ? "DIFFERENTIAL" : "LOG") + "...", Color.Yellow);
                        string sqlRestoreDiff = string.Format(@"
                            RESTORE {0} [{1}]
                            FROM DISK = N'{2}'
                            WITH RECOVERY",
                            isLog ? "LOG" : "DATABASE",
                            databaseName, restoreFile);
                        using (SqlCommand cmd = new SqlCommand(sqlRestoreDiff, conn))
                        {
                            cmd.CommandTimeout = 600;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // === RESTORE FULL ONLY ===
                        WriteLog("Đang phục hồi FULL BACKUP...", Color.Yellow);
                        string sqlRestore = string.Format(@"
                            RESTORE DATABASE [{0}]
                            FROM DISK = N'{1}'
                            WITH REPLACE, RECOVERY",
                            databaseName, restoreFile);
                        using (SqlCommand cmd = new SqlCommand(sqlRestore, conn))
                        {
                            cmd.CommandTimeout = 600;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Bước 3: Mở lại multi user
                    WriteLog("Đang mở lại kết nối...", Color.White);
                    string sqlMulti = string.Format(
                        "ALTER DATABASE [{0}] SET MULTI_USER", databaseName);
                    using (SqlCommand cmd = new SqlCommand(sqlMulti, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                WriteLog("PHỤC HỒI THÀNH CÔNG!", Color.Lime);
                MessageBox.Show("Phục hồi dữ liệu thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                WriteLog("Lỗi: " + ex.Message, Color.Red);

                // Cố gắng mở lại multi user nếu lỗi
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sqlMulti = string.Format(
                            "ALTER DATABASE [{0}] SET MULTI_USER", databaseName);
                        using (SqlCommand cmd = new SqlCommand(sqlMulti, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch { }

                MessageBox.Show("Lỗi phục hồi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}