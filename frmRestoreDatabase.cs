using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_TrangTrai
{
    public partial class frmRestoreDatabase : Form
    {
        string connectionString =
            @"Data Source=HUYNE;
              Initial Catalog=master;
              Integrated Security=True;
              TrustServerCertificate=True";

        public frmRestoreDatabase()
        {
            InitializeComponent();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "SQL Backup (*.bak)|*.bak";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtBackupPath.Text = openFileDialog1.FileName;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBackupPath.Text))
            {
                MessageBox.Show("Vui lòng chọn file backup!", "Thông báo");
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Khôi phục sẽ ghi đè toàn bộ dữ liệu hiện tại.\nBạn có chắc chắn không?",
                "Xác nhận khôi phục",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes) return;

            try
            {
                progressBar.Visible = true;
                lblStatus.Text = "Trạng thái: Đang khôi phục...";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"
ALTER DATABASE QL_TrangTraiv13
SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

RESTORE DATABASE QL_TrangTraiv13
FROM DISK = @path
WITH REPLACE, RECOVERY;

ALTER DATABASE QL_TrangTraiv13
SET MULTI_USER;
";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@path", txtBackupPath.Text);
                    cmd.ExecuteNonQuery();
                }

                progressBar.Visible = false;
                lblStatus.Text = "Trạng thái: Khôi phục thành công";

                MessageBox.Show("Khôi phục dữ liệu thành công!",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                progressBar.Visible = false;
                lblStatus.Text = "Trạng thái: Lỗi";

                MessageBox.Show("Lỗi khôi phục:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }
    }
}
