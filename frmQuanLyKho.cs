using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QL_TrangTrai
{
    public partial class frmQuanLyKho : Form
    {
        // Connection string
        private string connectionString = @"Data Source=HUYNE;Initial Catalog=QL_TrangTraiv13;Integrated Security=True";

        // Biến lưu MaTB đang chọn
        private int selectedMaTB = -1;

        // ========== THÊM: Biến lưu MaNV người đang đăng nhập ==========
        private int currentMaNV = 1; // Mặc định là 1, hoặc truyền từ form đăng nhập

        public frmQuanLyKho()
        {
            InitializeComponent();
            CustomizeDataGridView();
        }

        // Constructor có tham số MaNV (nếu cần truyền từ form khác)
        public frmQuanLyKho(int maNV)
        {
            InitializeComponent();
            CustomizeDataGridView();
            currentMaNV = maNV;
        }

        #region Form Load & Initialize

        private void frmQuanLyKho_Load(object sender, EventArgs e)
        {
            LoadThongTinKho();
            LoadNhaCungCap();
            LoadThietBi();
            UpdateTongThietBi();
        }

        private void CustomizeDataGridView()
        {
            // Header style
            dgvThietBi.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(63, 81, 181);
            dgvThietBi.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvThietBi.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvThietBi.ColumnHeadersHeight = 40;

            // Row style
            dgvThietBi.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvThietBi.DefaultCellStyle.SelectionBackColor = Color.FromArgb(63, 81, 181);
            dgvThietBi.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvThietBi.RowTemplate.Height = 35;

            // Alternating row color
            dgvThietBi.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
        }

        #endregion

        #region Load Data Methods

        /// <summary>
        /// Load thông tin kho (chỉ có 1 kho)
        /// </summary>
        private void LoadThongTinKho()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Kho WHERE MaKho = 1";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtMaKho.Text = reader["MaKho"].ToString();
                                txtTenKho.Text = reader["TenKho"].ToString();
                                txtDiaChi.Text = reader["DiaChi"].ToString();
                                dtpNgayNhap.Value = Convert.ToDateTime(reader["NgayNhap"]);
                                cboTrangThai.Text = reader["TrangThai"].ToString();
                            }
                        }
                    }
                }
                UpdateStatus("Đã tải thông tin kho", Color.Green);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin kho: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus("Lỗi kết nối", Color.Red);
            }
        }

        /// <summary>
        /// Load danh sách nhà cung cấp vào ComboBox
        /// </summary>
        private void LoadNhaCungCap()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MaNCC, TenNCC FROM NhaCungCap";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cboNhaCungCap.DataSource = dt;
                        cboNhaCungCap.DisplayMember = "TenNCC";
                        cboNhaCungCap.ValueMember = "MaNCC";
                        cboNhaCungCap.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhà cung cấp: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load danh sách thiết bị trong kho vào DataGridView
        /// </summary>
        private void LoadThietBi(string searchKeyword = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            tb.MaTB AS N'Mã TB',
                            tb.TenTB AS N'Tên thiết bị',
                            tb.SoLuong AS N'Số lượng',
                            FORMAT(tb.NgayNhap, 'dd/MM/yyyy') AS N'Ngày nhập',
                            ncc.TenNCC AS N'Nhà cung cấp'
                        FROM ThietBi tb
                        INNER JOIN NhaCungCap ncc ON tb.MaNCC = ncc.MaNCC
                        WHERE tb.MaKho = 1";

                    // Thêm điều kiện tìm kiếm
                    if (!string.IsNullOrEmpty(searchKeyword))
                    {
                        query += " AND tb.TenTB LIKE @keyword";
                    }

                    query += " ORDER BY tb.NgayNhap DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(searchKeyword))
                        {
                            cmd.Parameters.AddWithValue("@keyword", "%" + searchKeyword + "%");
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvThietBi.DataSource = dt;
                        }
                    }
                }
                UpdateStatus($"Đã tải {dgvThietBi.RowCount} thiết bị", Color.Green);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách thiết bị: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus("Lỗi khi tải dữ liệu", Color.Red);
            }
        }

        /// <summary>
        /// Cập nhật tổng số thiết bị trong kho (sử dụng FUNCTION fn_TongThietBiTrongKho)
        /// </summary>
        private void UpdateTongThietBi()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Gọi Function fn_TongThietBiTrongKho
                    string query = "SELECT dbo.fn_TongThietBiTrongKho(1) AS TongSL";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        lblTongThietBiValue.Text = result?.ToString() ?? "0";
                    }
                }
            }
            catch (Exception ex)
            {
                lblTongThietBiValue.Text = "N/A";
                MessageBox.Show("Lỗi khi tính tổng thiết bị: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Button Events

        /// <summary>
        /// ========== ĐÃ SỬA: Thêm thiết bị mới vào kho + Ghi giao dịch Chi ==========
        /// </summary>
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtTenThietBi.Text))
            {
                MessageBox.Show("Vui lòng nhập tên thiết bị!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenThietBi.Focus();
                return;
            }

            if (cboNhaCungCap.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNhaCungCap.Focus();
                return;
            }

            // ========== THÊM: Validate đơn giá ==========
            if (nudDonGia.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập đơn giá thiết bị!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudDonGia.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // ========== ĐÃ SỬA: Gọi Stored Procedure với đầy đủ tham số ==========
                    using (SqlCommand cmd = new SqlCommand("sp_NhapThietBiVaoKho", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@TenTB", txtTenThietBi.Text.Trim());
                        cmd.Parameters.AddWithValue("@SoLuong", (int)nudSoLuong.Value);
                        cmd.Parameters.AddWithValue("@MaKho", 1); // Chỉ có 1 kho
                        cmd.Parameters.AddWithValue("@MaNCC", cboNhaCungCap.SelectedValue);

                        // ========== THÊM MỚI: Các tham số để ghi giao dịch ==========
                        cmd.Parameters.AddWithValue("@DonGia", nudDonGia.Value);
                        cmd.Parameters.AddWithValue("@MaNV", currentMaNV);
                        cmd.Parameters.AddWithValue("@PhuongThucTT", cboPhuongThucTT.Text ?? "Tiền mặt");

                        cmd.ExecuteNonQuery();
                    }
                }

                // Tính tổng tiền để hiển thị
                decimal tongTien = nudSoLuong.Value * nudDonGia.Value;

                MessageBox.Show(
                    $"✅ Thêm thiết bị thành công!\n\n" +
                    $"📦 Thiết bị: {txtTenThietBi.Text}\n" +
                    $"📊 Số lượng: {nudSoLuong.Value}\n" +
                    $"💰 Đơn giá: {nudDonGia.Value:N0} VNĐ\n" +
                    $"💵 Tổng tiền: {tongTien:N0} VNĐ\n\n" +
                    $"✅ Đã ghi nhận giao dịch CHI vào tài chính!",
                    "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh data
                ClearInputFields();
                LoadThietBi();
                UpdateTongThietBi();
                UpdateStatus("Đã thêm thiết bị và ghi giao dịch Chi", Color.Green);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi thêm thiết bị: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus("Lỗi khi thêm thiết bị", Color.Red);
            }
        }

        /// <summary>
        /// Làm mới các trường nhập liệu
        /// </summary>
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            LoadThietBi();
            UpdateTongThietBi();
            UpdateStatus("Đã làm mới", Color.Green);
        }

        /// <summary>
        /// Xóa thiết bị đang chọn
        /// </summary>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedMaTB == -1)
            {
                MessageBox.Show("Vui lòng chọn thiết bị cần xóa!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa thiết bị có mã {selectedMaTB}?",
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
                        string query = "DELETE FROM ThietBi WHERE MaTB = @MaTB";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaTB", selectedMaTB);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("✅ Xóa thiết bị thành công!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                ClearInputFields();
                                LoadThietBi();
                                UpdateTongThietBi();
                                UpdateStatus("Đã xóa thiết bị", Color.Green);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Lỗi khi xóa thiết bị: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UpdateStatus("Lỗi khi xóa thiết bị", Color.Red);
                }
            }
        }

        /// <summary>
        /// Tìm kiếm thiết bị theo tên
        /// </summary>
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadThietBi(txtTimKiem.Text.Trim());
        }

        /// <summary>
        /// Thống kê thiết bị trong kho
        /// </summary>
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            COUNT(*) AS TongLoaiTB,
                            SUM(SoLuong) AS TongSoLuong,
                            (SELECT COUNT(DISTINCT MaNCC) FROM ThietBi WHERE MaKho = 1) AS SoNCC
                        FROM ThietBi 
                        WHERE MaKho = 1";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string message = $@"
📊 THỐNG KÊ THIẾT BỊ TRONG KHO
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
📦 Tổng số loại thiết bị: {reader["TongLoaiTB"]}
📈 Tổng số lượng thiết bị: {reader["TongSoLuong"]}
🏢 Số nhà cung cấp: {reader["SoNCC"]}
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━";

                                MessageBox.Show(message, "Thống kê thiết bị",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                UpdateStatus("Đã hiển thị thống kê", Color.Green);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi thống kê: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region DataGridView Events

        /// <summary>
        /// Xử lý khi click vào dòng trong DataGridView
        /// </summary>
        private void dgvThietBi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvThietBi.Rows[e.RowIndex];

                selectedMaTB = Convert.ToInt32(row.Cells["Mã TB"].Value);
                txtTenThietBi.Text = row.Cells["Tên thiết bị"].Value.ToString();
                nudSoLuong.Value = Convert.ToDecimal(row.Cells["Số lượng"].Value);

                // Tìm và chọn nhà cung cấp
                string tenNCC = row.Cells["Nhà cung cấp"].Value.ToString();
                for (int i = 0; i < cboNhaCungCap.Items.Count; i++)
                {
                    DataRowView drv = cboNhaCungCap.Items[i] as DataRowView;
                    if (drv != null && drv["TenNCC"].ToString() == tenNCC)
                    {
                        cboNhaCungCap.SelectedIndex = i;
                        break;
                    }
                }

                UpdateStatus($"Đã chọn thiết bị: {txtTenThietBi.Text}", Color.Blue);
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Xóa các trường nhập liệu
        /// </summary>
        private void ClearInputFields()
        {
            txtTenThietBi.Text = "";
            nudSoLuong.Value = 1;
            nudDonGia.Value = 0;  // ========== THÊM ==========
            cboNhaCungCap.SelectedIndex = -1;
            cboPhuongThucTT.SelectedIndex = 0;  // ========== THÊM ==========
            txtTimKiem.Text = "";
            selectedMaTB = -1;
        }

        /// <summary>
        /// Cập nhật trạng thái trên StatusStrip
        /// </summary>
        private void UpdateStatus(string message, Color color)
        {
            toolStripStatusLabel1.Text = "✅ " + message;
            toolStripStatusLabel1.ForeColor = color;
        }

        #endregion

        private void cboPhuongThucTT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void nudDonGia_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}