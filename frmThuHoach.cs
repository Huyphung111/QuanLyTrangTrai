using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_TrangTrai
{
    public partial class frmThuHoach : Form
    {
        // Connection string
        private string connectionString = @"Data Source=HUYNE;Initial Catalog=QL_TrangTraiv13;Integrated Security=True";
        private SqlConnection conn;

        public frmThuHoach()
        {
            InitializeComponent();
        }

        #region Form Load & Data Loading

        private void frmThuHoach_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            LoadNhanVien();
            LoadChiTietCayTrong();
            LoadChiTietVatNuoi();
            LoadThuHoach();
            UpdateThongKe();
            cboTimTheo.SelectedIndex = 0;
            LamMoi();
        }

        // Load danh sách nhân viên
        private void LoadNhanVien()
        {
            try
            {
                conn.Open();
                string query = "SELECT MaNV, HoTen FROM NhanVien ORDER BY HoTen";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboNhanVien.DataSource = dt;
                cboNhanVien.DisplayMember = "HoTen";
                cboNhanVien.ValueMember = "MaNV";
                cboNhanVien.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        // Load chi tiết thu hoạch cây trồng
        private void LoadChiTietCayTrong()
        {
            try
            {
                conn.Open();
                string query = @"SELECT ct.MaChiTietCT, 
                                CONCAT('#', ct.MaChiTietCT, ' - ', c.TenCay, ' - ', ct.SoLuong, 'kg - ', ct.ChatLuong) AS ThongTin,
                                ct.SoLuong
                                FROM ChiTietThuHoachCayTrong ct
                                INNER JOIN CayTrong c ON ct.MaCay = c.MaCay
                                WHERE ct.MaChiTietCT NOT IN (SELECT ISNULL(MaChiTietCT, 0) FROM ThuHoach WHERE MaChiTietCT IS NOT NULL)
                                ORDER BY ct.MaChiTietCT";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Thêm dòng trống
                DataRow emptyRow = dt.NewRow();
                emptyRow["MaChiTietCT"] = DBNull.Value;
                emptyRow["ThongTin"] = "-- Chọn chi tiết cây trồng --";
                emptyRow["SoLuong"] = 0;
                dt.Rows.InsertAt(emptyRow, 0);

                cboChiTietCT.DataSource = dt;
                cboChiTietCT.DisplayMember = "ThongTin";
                cboChiTietCT.ValueMember = "MaChiTietCT";
                cboChiTietCT.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load chi tiết cây trồng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        // Load chi tiết thu hoạch vật nuôi
        private void LoadChiTietVatNuoi()
        {
            try
            {
                conn.Open();
                string query = @"SELECT ct.MaChiTietVN, 
                                CONCAT('#', ct.MaChiTietVN, ' - ', v.TenVat, ' - ', ct.LoaiThuHoach, ' - ', ct.SoLuong) AS ThongTin,
                                ct.SoLuong
                                FROM ChiTietThuHoachVatNuoi ct
                                INNER JOIN VatNuoi v ON ct.MaVat = v.MaVat
                                WHERE ct.MaChiTietVN NOT IN (SELECT ISNULL(MaChiTietVN, 0) FROM ThuHoach WHERE MaChiTietVN IS NOT NULL)
                                ORDER BY ct.MaChiTietVN";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Thêm dòng trống
                DataRow emptyRow = dt.NewRow();
                emptyRow["MaChiTietVN"] = DBNull.Value;
                emptyRow["ThongTin"] = "-- Chọn chi tiết vật nuôi --";
                emptyRow["SoLuong"] = 0;
                dt.Rows.InsertAt(emptyRow, 0);

                cboChiTietVN.DataSource = dt;
                cboChiTietVN.DisplayMember = "ThongTin";
                cboChiTietVN.ValueMember = "MaChiTietVN";
                cboChiTietVN.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load chi tiết vật nuôi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        // Load danh sách thu hoạch
        private void LoadThuHoach()
        {
            try
            {
                conn.Open();
                string query = @"SELECT th.MaThuHoach, 
                                th.NgayThuHoach, 
                                nv.HoTen AS NhanVien,
                                CASE 
                                    WHEN th.MaChiTietCT IS NOT NULL THEN N'Cây trồng'
                                    ELSE N'Vật nuôi'
                                END AS LoaiThuHoach,
                                th.TongSoLuong, 
                                th.GhiChu,
                                th.MaNV,
                                th.MaChiTietCT,
                                th.MaChiTietVN
                                FROM ThuHoach th
                                LEFT JOIN NhanVien nv ON th.MaNV = nv.MaNV
                                ORDER BY th.NgayThuHoach DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvThuHoach.DataSource = dt;

                // Đặt tên cột
                if (dgvThuHoach.Columns.Count > 0)
                {
                    dgvThuHoach.Columns["MaThuHoach"].HeaderText = "Mã TH";
                    dgvThuHoach.Columns["NgayThuHoach"].HeaderText = "Ngày Thu Hoạch";
                    dgvThuHoach.Columns["NhanVien"].HeaderText = "Nhân Viên";
                    dgvThuHoach.Columns["LoaiThuHoach"].HeaderText = "Loại";
                    dgvThuHoach.Columns["TongSoLuong"].HeaderText = "Tổng SL";
                    dgvThuHoach.Columns["GhiChu"].HeaderText = "Ghi Chú";

                    // Ẩn các cột không cần thiết
                    dgvThuHoach.Columns["MaNV"].Visible = false;
                    dgvThuHoach.Columns["MaChiTietCT"].Visible = false;
                    dgvThuHoach.Columns["MaChiTietVN"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load thu hoạch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        // Cập nhật thống kê
        private void UpdateThongKe()
        {
            try
            {
                conn.Open();
                string query = @"SELECT 
                                ISNULL(SUM(TongSoLuong), 0) AS TongSL,
                                ISNULL(SUM(CASE WHEN MaChiTietCT IS NOT NULL THEN TongSoLuong ELSE 0 END), 0) AS CayTrong,
                                ISNULL(SUM(CASE WHEN MaChiTietVN IS NOT NULL THEN TongSoLuong ELSE 0 END), 0) AS VatNuoi
                                FROM ThuHoach";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    decimal tongSL = reader.GetDecimal(0);
                    decimal cayTrong = reader.GetDecimal(1);
                    decimal vatNuoi = reader.GetDecimal(2);

                    lblThongKe.Text = $"📈 Tổng số lượng: {tongSL:N2}  |  🌱 Cây trồng: {cayTrong:N2}  |  🐄 Vật nuôi: {vatNuoi:N2}";
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        #endregion

        #region Radio Button Events

        private void rbCayTrong_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCayTrong.Checked)
            {
                lblChiTietCT.Visible = true;
                cboChiTietCT.Visible = true;
                lblChiTietVN.Visible = false;
                cboChiTietVN.Visible = false;
                cboChiTietVN.SelectedIndex = 0;
            }
        }

        private void rbVatNuoi_CheckedChanged(object sender, EventArgs e)
        {
            if (rbVatNuoi.Checked)
            {
                lblChiTietCT.Visible = false;
                cboChiTietCT.Visible = false;
                lblChiTietVN.Visible = true;
                cboChiTietVN.Visible = true;
                cboChiTietCT.SelectedIndex = 0;
            }
        }

        #endregion

        #region ComboBox Events

        private void cboChiTietCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChiTietCT.SelectedIndex > 0)
            {
                DataRowView row = cboChiTietCT.SelectedItem as DataRowView;
                if (row != null && row["SoLuong"] != DBNull.Value)
                {
                    nudTongSL.Value = Convert.ToDecimal(row["SoLuong"]);
                }
            }
        }

        private void cboChiTietVN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChiTietVN.SelectedIndex > 0)
            {
                DataRowView row = cboChiTietVN.SelectedItem as DataRowView;
                if (row != null && row["SoLuong"] != DBNull.Value)
                {
                    nudTongSL.Value = Convert.ToDecimal(row["SoLuong"]);
                }
            }
        }

        #endregion

        #region CRUD Operations

        // Lấy mã thu hoạch tiếp theo
        private int GetNextMaThuHoach()
        {
            int nextId = 1;
            try
            {
                conn.Open();
                string query = "SELECT ISNULL(MAX(MaThuHoach), 0) + 1 FROM ThuHoach";
                SqlCommand cmd = new SqlCommand(query, conn);
                nextId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch { }
            finally
            {
                conn.Close();
            }
            return nextId;
        }

        // Kiểm tra dữ liệu
        private bool ValidateInput()
        {
            if (cboNhanVien.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNhanVien.Focus();
                return false;
            }

            if (rbCayTrong.Checked && cboChiTietCT.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn chi tiết cây trồng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboChiTietCT.Focus();
                return false;
            }

            if (rbVatNuoi.Checked && cboChiTietVN.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn chi tiết vật nuôi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboChiTietVN.Focus();
                return false;
            }

            return true;
        }

        // Thêm thu hoạch
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                conn.Open();
                string query = @"INSERT INTO ThuHoach (MaThuHoach, NgayThuHoach, MaNV, MaChiTietCT, MaChiTietVN, TongSoLuong, GhiChu)
                                VALUES (@MaTH, @NgayTH, @MaNV, @MaChiTietCT, @MaChiTietVN, @TongSL, @GhiChu)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaTH", GetNextMaThuHoach());
                cmd.Parameters.AddWithValue("@NgayTH", dtpNgayTH.Value.Date);
                cmd.Parameters.AddWithValue("@MaNV", cboNhanVien.SelectedValue);

                // Xử lý chi tiết cây trồng hoặc vật nuôi
                if (rbCayTrong.Checked)
                {
                    cmd.Parameters.AddWithValue("@MaChiTietCT", cboChiTietCT.SelectedValue);
                    cmd.Parameters.AddWithValue("@MaChiTietVN", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaChiTietCT", DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaChiTietVN", cboChiTietVN.SelectedValue);
                }

                cmd.Parameters.AddWithValue("@TongSL", nudTongSL.Value);
                cmd.Parameters.AddWithValue("@GhiChu", string.IsNullOrEmpty(txtGhiChu.Text) ? DBNull.Value : (object)txtGhiChu.Text);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Thêm thu hoạch thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadThuHoach();
                    LoadChiTietCayTrong();
                    LoadChiTietVatNuoi();
                    UpdateThongKe();
                    LamMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm thu hoạch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        // Sửa thu hoạch
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTH.Text))
            {
                MessageBox.Show("Vui lòng chọn thu hoạch cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                conn.Open();
                string query = @"UPDATE ThuHoach 
                                SET NgayThuHoach = @NgayTH, 
                                    MaNV = @MaNV, 
                                    MaChiTietCT = @MaChiTietCT, 
                                    MaChiTietVN = @MaChiTietVN, 
                                    TongSoLuong = @TongSL, 
                                    GhiChu = @GhiChu
                                WHERE MaThuHoach = @MaTH";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaTH", int.Parse(txtMaTH.Text));
                cmd.Parameters.AddWithValue("@NgayTH", dtpNgayTH.Value.Date);
                cmd.Parameters.AddWithValue("@MaNV", cboNhanVien.SelectedValue);

                if (rbCayTrong.Checked)
                {
                    cmd.Parameters.AddWithValue("@MaChiTietCT", cboChiTietCT.SelectedValue);
                    cmd.Parameters.AddWithValue("@MaChiTietVN", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaChiTietCT", DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaChiTietVN", cboChiTietVN.SelectedValue);
                }

                cmd.Parameters.AddWithValue("@TongSL", nudTongSL.Value);
                cmd.Parameters.AddWithValue("@GhiChu", string.IsNullOrEmpty(txtGhiChu.Text) ? DBNull.Value : (object)txtGhiChu.Text);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thu hoạch thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadThuHoach();
                    LoadChiTietCayTrong();
                    LoadChiTietVatNuoi();
                    UpdateThongKe();
                    LamMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật thu hoạch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        // Xóa thu hoạch
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTH.Text))
            {
                MessageBox.Show("Vui lòng chọn thu hoạch cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thu hoạch này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    conn.Open();

                    // Kiểm tra ràng buộc với bảng SanPham
                    string checkQuery = "SELECT COUNT(*) FROM SanPham WHERE MaThuHoach = @MaTH";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@MaTH", int.Parse(txtMaTH.Text));
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Không thể xóa! Thu hoạch này đã có sản phẩm liên quan.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string query = "DELETE FROM ThuHoach WHERE MaThuHoach = @MaTH";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaTH", int.Parse(txtMaTH.Text));

                    int deleteResult = cmd.ExecuteNonQuery();
                    if (deleteResult > 0)
                    {
                        MessageBox.Show("Xóa thu hoạch thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadThuHoach();
                        LoadChiTietCayTrong();
                        LoadChiTietVatNuoi();
                        UpdateThongKe();
                        LamMoi();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa thu hoạch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Làm mới form
        private void LamMoi()
        {
            txtMaTH.Text = GetNextMaThuHoach().ToString();
            txtMaTH.ReadOnly = true;
            dtpNgayTH.Value = DateTime.Now;
            cboNhanVien.SelectedIndex = -1;
            rbCayTrong.Checked = true;
            cboChiTietCT.SelectedIndex = 0;
            cboChiTietVN.SelectedIndex = 0;
            nudTongSL.Value = 1;
            txtGhiChu.Text = "";
            txtTimKiem.Text = "";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadChiTietCayTrong();
            LoadChiTietVatNuoi();
            LoadThuHoach();
            LamMoi();
        }

        #endregion

        #region Search & Grid Events

        // Tìm kiếm
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text))
            {
                LoadThuHoach();
                return;
            }

            try
            {
                conn.Open();
                string searchField = "";
                switch (cboTimTheo.SelectedIndex)
                {
                    case 0: searchField = "th.MaThuHoach"; break;
                    case 1: searchField = "nv.HoTen"; break;
                    case 2: searchField = "CASE WHEN th.MaChiTietCT IS NOT NULL THEN N'Cây trồng' ELSE N'Vật nuôi' END"; break;
                    case 3: searchField = "th.GhiChu"; break;
                }

                string query = $@"SELECT th.MaThuHoach, 
                                th.NgayThuHoach, 
                                nv.HoTen AS NhanVien,
                                CASE 
                                    WHEN th.MaChiTietCT IS NOT NULL THEN N'Cây trồng'
                                    ELSE N'Vật nuôi'
                                END AS LoaiThuHoach,
                                th.TongSoLuong, 
                                th.GhiChu,
                                th.MaNV,
                                th.MaChiTietCT,
                                th.MaChiTietVN
                                FROM ThuHoach th
                                LEFT JOIN NhanVien nv ON th.MaNV = nv.MaNV
                                WHERE CAST({searchField} AS NVARCHAR(MAX)) LIKE @SearchText
                                ORDER BY th.NgayThuHoach DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@SearchText", "%" + txtTimKiem.Text + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvThuHoach.DataSource = dt;

                if (dgvThuHoach.Columns.Count > 0)
                {
                    dgvThuHoach.Columns["MaThuHoach"].HeaderText = "Mã TH";
                    dgvThuHoach.Columns["NgayThuHoach"].HeaderText = "Ngày Thu Hoạch";
                    dgvThuHoach.Columns["NhanVien"].HeaderText = "Nhân Viên";
                    dgvThuHoach.Columns["LoaiThuHoach"].HeaderText = "Loại";
                    dgvThuHoach.Columns["TongSoLuong"].HeaderText = "Tổng SL";
                    dgvThuHoach.Columns["GhiChu"].HeaderText = "Ghi Chú";
                    dgvThuHoach.Columns["MaNV"].Visible = false;
                    dgvThuHoach.Columns["MaChiTietCT"].Visible = false;
                    dgvThuHoach.Columns["MaChiTietVN"].Visible = false;
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        // Click vào dòng trong DataGridView
        private void dgvThuHoach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvThuHoach.Rows[e.RowIndex];

                txtMaTH.Text = row.Cells["MaThuHoach"].Value.ToString();
                dtpNgayTH.Value = Convert.ToDateTime(row.Cells["NgayThuHoach"].Value);

                // Set nhân viên
                if (row.Cells["MaNV"].Value != DBNull.Value)
                {
                    cboNhanVien.SelectedValue = row.Cells["MaNV"].Value;
                }

                // Set loại thu hoạch và chi tiết
                if (row.Cells["MaChiTietCT"].Value != DBNull.Value)
                {
                    rbCayTrong.Checked = true;
                    // Load lại danh sách và thêm item hiện tại
                    LoadChiTietCayTrongForEdit(Convert.ToInt32(row.Cells["MaChiTietCT"].Value));
                }
                else
                {
                    rbVatNuoi.Checked = true;
                    // Load lại danh sách và thêm item hiện tại
                    LoadChiTietVatNuoiForEdit(Convert.ToInt32(row.Cells["MaChiTietVN"].Value));
                }

                nudTongSL.Value = Convert.ToDecimal(row.Cells["TongSoLuong"].Value);
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";
            }
        }

        // Load chi tiết cây trồng khi sửa (bao gồm item đang được chọn)
        private void LoadChiTietCayTrongForEdit(int maChiTietCT)
        {
            try
            {
                conn.Open();
                string query = @"SELECT ct.MaChiTietCT, 
                                CONCAT('#', ct.MaChiTietCT, ' - ', c.TenCay, ' - ', ct.SoLuong, 'kg - ', ct.ChatLuong) AS ThongTin,
                                ct.SoLuong
                                FROM ChiTietThuHoachCayTrong ct
                                INNER JOIN CayTrong c ON ct.MaCay = c.MaCay
                                WHERE ct.MaChiTietCT NOT IN (SELECT ISNULL(MaChiTietCT, 0) FROM ThuHoach WHERE MaChiTietCT IS NOT NULL)
                                   OR ct.MaChiTietCT = @CurrentId
                                ORDER BY ct.MaChiTietCT";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@CurrentId", maChiTietCT);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataRow emptyRow = dt.NewRow();
                emptyRow["MaChiTietCT"] = DBNull.Value;
                emptyRow["ThongTin"] = "-- Chọn chi tiết cây trồng --";
                emptyRow["SoLuong"] = 0;
                dt.Rows.InsertAt(emptyRow, 0);

                cboChiTietCT.DataSource = dt;
                cboChiTietCT.DisplayMember = "ThongTin";
                cboChiTietCT.ValueMember = "MaChiTietCT";
                cboChiTietCT.SelectedValue = maChiTietCT;
            }
            catch { }
            finally
            {
                conn.Close();
            }
        }

        // Load chi tiết vật nuôi khi sửa (bao gồm item đang được chọn)
        private void LoadChiTietVatNuoiForEdit(int maChiTietVN)
        {
            try
            {
                conn.Open();
                string query = @"SELECT ct.MaChiTietVN, 
                                CONCAT('#', ct.MaChiTietVN, ' - ', v.TenVat, ' - ', ct.LoaiThuHoach, ' - ', ct.SoLuong) AS ThongTin,
                                ct.SoLuong
                                FROM ChiTietThuHoachVatNuoi ct
                                INNER JOIN VatNuoi v ON ct.MaVat = v.MaVat
                                WHERE ct.MaChiTietVN NOT IN (SELECT ISNULL(MaChiTietVN, 0) FROM ThuHoach WHERE MaChiTietVN IS NOT NULL)
                                   OR ct.MaChiTietVN = @CurrentId
                                ORDER BY ct.MaChiTietVN";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@CurrentId", maChiTietVN);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataRow emptyRow = dt.NewRow();
                emptyRow["MaChiTietVN"] = DBNull.Value;
                emptyRow["ThongTin"] = "-- Chọn chi tiết vật nuôi --";
                emptyRow["SoLuong"] = 0;
                dt.Rows.InsertAt(emptyRow, 0);

                cboChiTietVN.DataSource = dt;
                cboChiTietVN.DisplayMember = "ThongTin";
                cboChiTietVN.ValueMember = "MaChiTietVN";
                cboChiTietVN.SelectedValue = maChiTietVN;
            }
            catch { }
            finally
            {
                conn.Close();
            }
        }

        #endregion

        #region Close Button

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}