using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTrangTrai
{
    public partial class DoiMatKhau : Form
    {
        // Chuỗi kết nối - Thay đổi theo cấu hình của bạn
        private string connectionString = @"Data Source=YOURSERVER;Initial Catalog=QL_TrangTraiv13;Integrated Security=True";

        public DoiMatKhau()
        {
            InitializeComponent();
        }

        // Sự kiện hiển thị/ẩn mật khẩu
        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            bool hienMatKhau = chkHienMatKhau.Checked;
            txtMatKhauCu.UseSystemPasswordChar = !hienMatKhau;
            txtMatKhauMoi.UseSystemPasswordChar = !hienMatKhau;
            txtXacNhanMatKhau.UseSystemPasswordChar = !hienMatKhau;
        }

        // Nút Đổi mật khẩu
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường không được để trống
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMatKhauCu.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauCu.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMatKhauMoi.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtXacNhanMatKhau.Text))
            {
                MessageBox.Show("Vui lòng xác nhận mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXacNhanMatKhau.Focus();
                return;
            }

            // Kiểm tra mật khẩu mới phải khác mật khẩu cũ
            if (txtMatKhauCu.Text == txtMatKhauMoi.Text)
            {
                MessageBox.Show("Mật khẩu mới phải khác mật khẩu cũ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            // Kiểm tra mật khẩu mới và xác nhận mật khẩu phải giống nhau
            if (txtMatKhauMoi.Text != txtXacNhanMatKhau.Text)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXacNhanMatKhau.Focus();
                return;
            }

            // Kiểm tra độ dài mật khẩu tối thiểu
            if (txtMatKhauMoi.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            // Thực hiện đổi mật khẩu
            DoiMatKhauDatabase();
        }

        // Hàm đổi mật khẩu trong database
        private void DoiMatKhauDatabase()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra tên đăng nhập và mật khẩu cũ
                    string sqlCheck = "SELECT COUNT(*) FROM DangNhap WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhauCu";
                    using (SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@TenDangNhap", txtTenDangNhap.Text.Trim());
                        cmdCheck.Parameters.AddWithValue("@MatKhauCu", txtMatKhauCu.Text);

                        int count = (int)cmdCheck.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show("Tên đăng nhập hoặc mật khẩu cũ không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Cập nhật mật khẩu mới
                    string sqlUpdate = "UPDATE DangNhap SET MatKhau = @MatKhauMoi WHERE TenDangNhap = @TenDangNhap";
                    using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@MatKhauMoi", txtMatKhauMoi.Text);
                        cmdUpdate.Parameters.AddWithValue("@TenDangNhap", txtTenDangNhap.Text.Trim());

                        int rowsAffected = cmdUpdate.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Đổi mật khẩu thành công!\nVui lòng đăng nhập lại với mật khẩu mới.",
                                          "Thành công",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Đổi mật khẩu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối database: " + ex.Message,
                              "Lỗi",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        // Nút Hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy thao tác đổi mật khẩu?",
                                                  "Xác nhận",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}