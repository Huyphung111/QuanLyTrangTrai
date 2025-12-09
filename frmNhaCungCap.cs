using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QL_TrangTrai
{
    public partial class frmNhaCungCap : Form
    {
        // Chuỗi kết nối - thay đổi theo cấu hình của bạn
        private string connectionString = @"Data Source=HUYNE;Initial Catalog=QL_TrangTraiv13;Integrated Security=True";

        public frmNhaCungCap()
        {
            InitializeComponent();
            CustomizeDataGridView();
        }

        #region Form Load
        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadData();
            LamMoi();
        }
        #endregion

        #region Customize DataGridView
        private void CustomizeDataGridView()
        {
            // Header style
            dgvNhaCungCap.EnableHeadersVisualStyles = false;
            dgvNhaCungCap.ColumnHeadersDefaultCellStyle.BackColor = Color.ForestGreen;
            dgvNhaCungCap.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvNhaCungCap.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvNhaCungCap.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNhaCungCap.ColumnHeadersHeight = 35;

            // Row style
            dgvNhaCungCap.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvNhaCungCap.RowTemplate.Height = 30;
            dgvNhaCungCap.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew;

            // Selection style
            dgvNhaCungCap.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgvNhaCungCap.DefaultCellStyle.SelectionForeColor = Color.White;

            // Grid lines
            dgvNhaCungCap.GridColor = Color.LightGreen;

            // ===== THÊM NHỮNG DÒNG NÀY ĐỂ FIX VẤN ĐỀ HIỂN THỊ =====
            dgvNhaCungCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhaCungCap.Dock = DockStyle.Fill;
            dgvNhaCungCap.ScrollBars = ScrollBars.Both;
            dgvNhaCungCap.AllowUserToAddRows = false;
            dgvNhaCungCap.AllowUserToDeleteRows = false;
            dgvNhaCungCap.ReadOnly = true;
            dgvNhaCungCap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhaCungCap.MultiSelect = false;
        }
        #endregion

        #region Load Data
        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT MaNCC, TenNCC, SDT, Email, DiaChi FROM NhaCungCap ORDER BY MaNCC";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvNhaCungCap.DataSource = dt;

                    // Đặt tên cột hiển thị
                    if (dgvNhaCungCap.Columns.Count > 0)
                    {
                        dgvNhaCungCap.Columns["MaNCC"].HeaderText = "Mã NCC";
                        dgvNhaCungCap.Columns["TenNCC"].HeaderText = "Tên Nhà Cung Cấp";
                        dgvNhaCungCap.Columns["SDT"].HeaderText = "Số Điện Thoại";
                        dgvNhaCungCap.Columns["Email"].HeaderText = "Email";
                        dgvNhaCungCap.Columns["DiaChi"].HeaderText = "Địa Chỉ";

                        // ===== ĐỔI CÁCH SET CHIỀU RỘNG CỘT - DÙNG FILLWEIGHT =====
                        dgvNhaCungCap.Columns["MaNCC"].FillWeight = 10;  // 10%
                        dgvNhaCungCap.Columns["TenNCC"].FillWeight = 30; // 30%
                        dgvNhaCungCap.Columns["SDT"].FillWeight = 15;    // 15%
                        dgvNhaCungCap.Columns["Email"].FillWeight = 25;  // 25%
                        dgvNhaCungCap.Columns["DiaChi"].FillWeight = 20; // 20%
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Lấy Mã NCC tự động
        private int GetNextMaNCC()
        {
            int nextId = 1;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ISNULL(MAX(MaNCC), 0) + 1 FROM NhaCungCap";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    nextId = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy mã: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return nextId;
        }
        #endregion

        #region Làm mới form
        private void LamMoi()
        {
            txtMaNCC.Text = GetNextMaNCC().ToString();
            txtTenNCC.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtTenNCC.Focus();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
            LoadData();
        }
        #endregion

        #region Kiểm tra dữ liệu
        private bool ValidateInput()
        {
            // Kiểm tra tên NCC
            if (string.IsNullOrWhiteSpace(txtTenNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNCC.Focus();
                return false;
            }

            // Kiểm tra số điện thoại
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            if (txtSDT.Text.Length < 9 || txtSDT.Text.Length > 11)
            {
                MessageBox.Show("Số điện thoại phải từ 9-11 ký tự!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            // Kiểm tra email
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
                {
                    MessageBox.Show("Email không hợp lệ!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region Thêm nhà cung cấp
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO NhaCungCap (MaNCC, TenNCC, SDT, Email, DiaChi) 
                                     VALUES (@MaNCC, @TenNCC, @SDT, @Email, @DiaChi)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNCC", int.Parse(txtMaNCC.Text));
                    cmd.Parameters.AddWithValue("@TenNCC", txtTenNCC.Text.Trim());
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(txtEmail.Text) ?
                        (object)DBNull.Value : txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@DiaChi", string.IsNullOrWhiteSpace(txtDiaChi.Text) ?
                        (object)DBNull.Value : txtDiaChi.Text.Trim());

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("✓ Thêm nhà cung cấp thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        LamMoi();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Unique constraint violation
                {
                    MessageBox.Show("Số điện thoại hoặc Email đã tồn tại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi thêm dữ liệu: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Sửa nhà cung cấp
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"UPDATE NhaCungCap 
                                     SET TenNCC = @TenNCC, SDT = @SDT, Email = @Email, DiaChi = @DiaChi 
                                     WHERE MaNCC = @MaNCC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNCC", int.Parse(txtMaNCC.Text));
                    cmd.Parameters.AddWithValue("@TenNCC", txtTenNCC.Text.Trim());
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(txtEmail.Text) ?
                        (object)DBNull.Value : txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@DiaChi", string.IsNullOrWhiteSpace(txtDiaChi.Text) ?
                        (object)DBNull.Value : txtDiaChi.Text.Trim());

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("✓ Cập nhật thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        LamMoi();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Số điện thoại hoặc Email đã tồn tại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Xóa nhà cung cấp
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa nhà cung cấp \"{txtTenNCC.Text}\"?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string query = "DELETE FROM NhaCungCap WHERE MaNCC = @MaNCC";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MaNCC", int.Parse(txtMaNCC.Text));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("✓ Xóa thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            LamMoi();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Foreign key constraint
                    {
                        MessageBox.Show("Không thể xóa! Nhà cung cấp này đang được sử dụng.",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi xóa: " + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region Tìm kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword) || keyword == "Tìm kiếm...")
            {
                LoadData();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT MaNCC, TenNCC, SDT, Email, DiaChi 
                                     FROM NhaCungCap 
                                     WHERE TenNCC LIKE @keyword 
                                        OR SDT LIKE @keyword 
                                        OR Email LIKE @keyword 
                                        OR DiaChi LIKE @keyword
                                     ORDER BY MaNCC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvNhaCungCap.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Click vào DataGridView
        private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhaCungCap.Rows[e.RowIndex];

                txtMaNCC.Text = row.Cells["MaNCC"].Value.ToString();
                txtTenNCC.Text = row.Cells["TenNCC"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString() ?? "";
            }
        }
        #endregion

        #region Placeholder cho TextBox tìm kiếm
        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Tìm kiếm...")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "Tìm kiếm...";
                txtTimKiem.ForeColor = Color.Gray;
            }
        }
        #endregion
    }
}