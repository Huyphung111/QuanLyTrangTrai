using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_TrangTrai
{
    public partial class frmLichCongViec : Form
    {
        // Connection string - thay đổi theo cấu hình của bạn
        private string connectionString = @"Data Source=HUYNE;Initial Catalog=QL_TrangTraiv13;Integrated Security=True";

        public frmLichCongViec()
        {
            InitializeComponent();
        }

        #region FORM LOAD
        private void frmLichCongViec_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            LoadTrangThai();
            LoadLichCongViec();
        }

        // Load danh sách nhân viên vào ComboBox
        private void LoadNhanVien()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MaNV, HoTen FROM NhanVien ORDER BY HoTen";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Thêm dòng "Tất cả"
                    DataRow dr = dt.NewRow();
                    dr["MaNV"] = 0;
                    dr["HoTen"] = "-- Tất cả --";
                    dt.Rows.InsertAt(dr, 0);

                    cboNhanVien.DataSource = dt;
                    cboNhanVien.DisplayMember = "HoTen";
                    cboNhanVien.ValueMember = "MaNV";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load danh sách trạng thái vào ComboBox
        private void LoadTrangThai()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("-- Tất cả --");
            cboTrangThai.Items.Add("Chưa thực hiện");
            cboTrangThai.Items.Add("Đang làm");
            cboTrangThai.Items.Add("Hoàn thành");
            cboTrangThai.SelectedIndex = 0;
        }

        // Load danh sách lịch công việc
        private void LoadLichCongViec()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT l.MaLich, l.TieuDe, l.MoTa, l.NgayBatDau, l.NgayKetThuc, 
                                           l.TrangThai, n.HoTen AS NhanVien
                                    FROM LichCongViec l
                                    INNER JOIN NhanVien n ON l.MaNV = n.MaNV
                                    ORDER BY l.NgayBatDau DESC";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvLichCongViec.DataSource = dt;

                    // Đặt tiêu đề cột
                    if (dgvLichCongViec.Columns.Count > 0)
                    {
                        dgvLichCongViec.Columns["MaLich"].HeaderText = "Mã";
                        dgvLichCongViec.Columns["TieuDe"].HeaderText = "Tiêu đề";
                        dgvLichCongViec.Columns["MoTa"].HeaderText = "Mô tả";
                        dgvLichCongViec.Columns["NgayBatDau"].HeaderText = "Ngày BĐ";
                        dgvLichCongViec.Columns["NgayKetThuc"].HeaderText = "Ngày KT";
                        dgvLichCongViec.Columns["TrangThai"].HeaderText = "Trạng thái";
                        dgvLichCongViec.Columns["NhanVien"].HeaderText = "Nhân viên";
                    }

                    lblTongSo.Text = $"Tổng số: {dt.Rows.Count} công việc";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load lịch công việc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region TAB 1: ĐẾM CÔNG VIỆC (NV3 - FUNCTION)
        private void btnDemCongViec_Click(object sender, EventArgs e)
        {
            try
            {
                int maNV = Convert.ToInt32(cboNhanVien.SelectedValue);
                string trangThai = cboTrangThai.SelectedItem.ToString();

                // Nếu chọn "Tất cả" thì truyền NULL
                if (trangThai == "-- Tất cả --")
                    trangThai = null;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Gọi Function fn_DemCongViecNhanVien
                    string query;
                    SqlCommand cmd;

                    if (maNV == 0) // Tất cả nhân viên
                    {
                        // Đếm tất cả công việc theo trạng thái
                        if (trangThai == null)
                        {
                            query = "SELECT COUNT(*) FROM LichCongViec";
                            cmd = new SqlCommand(query, conn);
                        }
                        else
                        {
                            query = "SELECT COUNT(*) FROM LichCongViec WHERE TrangThai = @TrangThai";
                            cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                        }
                    }
                    else // Nhân viên cụ thể - sử dụng FUNCTION
                    {
                        query = "SELECT dbo.fn_DemCongViecNhanVien(@MaNV, @TrangThai)";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MaNV", maNV);
                        cmd.Parameters.AddWithValue("@TrangThai", (object)trangThai ?? DBNull.Value);
                    }

                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    txtKetQua.Text = result.ToString();

                    // Hiệu ứng highlight kết quả
                    txtKetQua.BackColor = System.Drawing.Color.LightGreen;

                    // Load lại danh sách theo filter
                    LoadLichCongViecFiltered(maNV, trangThai);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đếm công việc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load danh sách lịch công việc theo filter
        private void LoadLichCongViecFiltered(int maNV, string trangThai)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT l.MaLich, l.TieuDe, l.MoTa, l.NgayBatDau, l.NgayKetThuc, 
                                           l.TrangThai, n.HoTen AS NhanVien
                                    FROM LichCongViec l
                                    INNER JOIN NhanVien n ON l.MaNV = n.MaNV
                                    WHERE (@MaNV = 0 OR l.MaNV = @MaNV)
                                      AND (@TrangThai IS NULL OR l.TrangThai = @TrangThai)
                                    ORDER BY l.NgayBatDau DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    cmd.Parameters.AddWithValue("@TrangThai", (object)trangThai ?? DBNull.Value);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvLichCongViec.DataSource = dt;
                    lblTongSo.Text = $"Tổng số: {dt.Rows.Count} công việc (đã lọc)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lọc công việc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region TAB 2: THỐNG KÊ HIỆU SUẤT (NV4 - CURSOR)
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Gọi Stored Procedure sp_ThongKeHieuSuatNhanVien (dùng CURSOR)
                    SqlCommand cmd = new SqlCommand("sp_ThongKeHieuSuatNhanVien", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvThongKe.DataSource = dt;

                    // Format DataGridView
                    FormatThongKeGrid();

                    // Tính thống kê tổng
                    if (dt.Rows.Count > 0)
                    {
                        int tongNV = dt.Rows.Count;
                        decimal tongTyLe = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            tongTyLe += Convert.ToDecimal(row["Tỷ lệ %"]);
                        }
                        decimal trungBinh = tongTyLe / tongNV;

                        lblThongKeTong.Text = $"📈 Tổng NV: {tongNV} | Trung bình hoàn thành: {trungBinh:F2}%";
                    }

                    MessageBox.Show("✅ Thống kê hiệu suất thành công!\n\n(Sử dụng CURSOR duyệt từng nhân viên)",
                                  "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Format DataGridView thống kê
        private void FormatThongKeGrid()
        {
            if (dgvThongKe.Columns.Count > 0)
            {
                // Đổi màu cột tỷ lệ %
                foreach (DataGridViewRow row in dgvThongKe.Rows)
                {
                    if (row.Cells["Tỷ lệ %"].Value != null)
                    {
                        decimal tyLe = Convert.ToDecimal(row.Cells["Tỷ lệ %"].Value);
                        if (tyLe >= 70)
                            row.Cells["Tỷ lệ %"].Style.BackColor = System.Drawing.Color.LightGreen;
                        else if (tyLe >= 40)
                            row.Cells["Tỷ lệ %"].Style.BackColor = System.Drawing.Color.LightYellow;
                        else
                            row.Cells["Tỷ lệ %"].Style.BackColor = System.Drawing.Color.LightCoral;
                    }
                }
            }
        }
        #endregion

        #region TAB 3: PHÂN CÔNG TỰ ĐỘNG (NV5 - PROCEDURE)
        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtTieuDe.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề công việc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTieuDe.Focus();
                return;
            }

            if (dtpNgayKetThuc.Value < dtpNgayBatDau.Value)
            {
                MessageBox.Show("Ngày kết thúc phải >= ngày bắt đầu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Gọi Stored Procedure sp_PhanCongViecTuDong
                    SqlCommand cmd = new SqlCommand("sp_PhanCongViecTuDong", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TieuDe", txtTieuDe.Text.Trim());
                    cmd.Parameters.AddWithValue("@MoTa", txtMoTa.Text.Trim());
                    cmd.Parameters.AddWithValue("@NgayBatDau", dtpNgayBatDau.Value.Date);
                    cmd.Parameters.AddWithValue("@NgayKetThuc", dtpNgayKetThuc.Value.Date);

                    cmd.ExecuteNonQuery();

                    // Lấy thông tin nhân viên được gán
                    string queryInfo = @"SELECT TOP 1 l.MaLich, n.HoTen, n.MaNV,
                                        (SELECT COUNT(*) FROM LichCongViec WHERE MaNV = n.MaNV AND TrangThai = N'Chưa thực hiện') AS SoViecChuaLam
                                        FROM LichCongViec l
                                        INNER JOIN NhanVien n ON l.MaNV = n.MaNV
                                        ORDER BY l.MaLich DESC";

                    SqlCommand cmdInfo = new SqlCommand(queryInfo, conn);
                    SqlDataReader reader = cmdInfo.ExecuteReader();

                    if (reader.Read())
                    {
                        string hoTen = reader["HoTen"].ToString();
                        int maNV = Convert.ToInt32(reader["MaNV"]);
                        int soViec = Convert.ToInt32(reader["SoViecChuaLam"]);

                        lblKetQuaPhanCong.BackColor = System.Drawing.Color.LightGreen;
                        lblKetQuaPhanCong.Text = $"✅ PHÂN CÔNG THÀNH CÔNG!\n" +
                                                 $"   Công việc \"{txtTieuDe.Text}\" đã được giao cho: {hoTen} (Mã NV: {maNV}) - Hiện có {soViec} việc chưa thực hiện";
                    }
                    reader.Close();

                    // Clear form
                    txtTieuDe.Clear();
                    txtMoTa.Clear();

                    // Refresh danh sách ở Tab 1
                    LoadLichCongViec();

                    MessageBox.Show("✅ Phân công việc tự động thành công!\n\n" +
                                  "• Hệ thống đã tìm nhân viên có ít việc nhất\n" +
                                  "• Sử dụng TRANSACTION + Subquery",
                                  "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                lblKetQuaPhanCong.BackColor = System.Drawing.Color.LightCoral;
                lblKetQuaPhanCong.Text = $"❌ LỖI: {ex.Message}";
                MessageBox.Show("Lỗi phân công: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}