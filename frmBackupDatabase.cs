using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_TrangTrai
{
    public partial class frmBackupDatabase : Form
    {
        string connectionString =
            @"Data Source=HUYNE;
              Initial Catalog=QL_TrangTraiv13;
              Integrated Security=True;
              TrustServerCertificate=True";

        public frmBackupDatabase()
        {
            InitializeComponent();
        }

        private void frmBackupDatabase_Load(object sender, EventArgs e)
        {
            txtDatabase.Text = "QL_TrangTraiv13";
            lblStatus.Text = "Trạng thái: Sẵn sàng";
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "SQL Backup (*.bak)|*.bak";
            saveFileDialog1.FileName = "QL_TrangTraiv13.bak";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtBackupPath.Text = saveFileDialog1.FileName;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBackupPath.Text))
            {
                MessageBox.Show("Vui lòng chọn nơi lưu file backup!", "Thông báo");
                return;
            }

            try
            {
                progressBar.Visible = true;
                lblStatus.Text = "Trạng thái: Đang sao lưu...";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"
BACKUP DATABASE QL_TrangTraiv13
TO DISK = @path
WITH FORMAT,
     NAME = 'WinForms Backup Database';";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@path", txtBackupPath.Text);
                    cmd.ExecuteNonQuery();
                }

                progressBar.Visible = false;
                lblStatus.Text = "Trạng thái: Sao lưu thành công";

                MessageBox.Show("Backup dữ liệu thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                progressBar.Visible = false;
                lblStatus.Text = "Trạng thái: Lỗi";

                MessageBox.Show("Lỗi backup:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_formrestore_Click(object sender, EventArgs e)
        {
            frmRestoreDatabase frm = new frmRestoreDatabase();
            frm.ShowDialog(); // mở dạng modal (khóa form Backup)
        }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }
    }
}
