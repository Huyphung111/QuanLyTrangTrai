using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QL_TrangTrai
{
    public partial class frmChiTietThuHoachCayTrong : Form
    {
        #region Fields

        // Connection string - ĐỔI THEO MÁY CỦA BẠN
        private readonly string connectionString = @"Data Source=HUYNE;Initial Catalog=QL_TrangTraiv13;Integrated Security=True";

        // DataTable để lưu trữ dữ liệu
        private DataTable dtChiTiet;
        private DataTable dtCayTrong;
        private DataTable dtNhanVien;

        // Biến lưu trạng thái đang thêm mới hay sửa
        private bool isAddNew = false;

        #endregion

        #region Constructor

        public frmChiTietThuHoachCayTrong()
        {
            InitializeComponent();
            this.Load += FrmChiTietThuHoachCayTrong_Load;
        }

        #endregion

        #region Form Events

        private void FrmChiTietThuHoachCayTrong_Load(object sender, EventArgs e)
        {
            // Đăng ký sự kiện
            RegisterEvents();
            dgvChiTiet.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dgvChiTiet.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            LoadCayTrong();
            LoadNhanVien();  // THÊM MỚI
            LoadData();

            // Thiết lập ban đầu
            SetDefaultValues();
            UpdateStatistics();

            // Thiết lập tooltip
            SetupToolTips();
        }

        #endregion

        #region Event Registration

        private void RegisterEvents()
        {
            // Button events
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLamMoi.Click += BtnLamMoi_Click;
            btnTimKiem.Click += BtnTimKiem_Click;
            btnDong.Click += BtnDong_Click;

            // ComboBox events
            cboMaCay.SelectedIndexChanged += CboMaCay_SelectedIndexChanged;

            // DataGridView events
            dgvChiTiet.CellClick += DgvChiTiet_CellClick;

            // TextBox events - Enter key for search
            txtTimKiem.KeyPress += TxtTimKiem_KeyPress;
        }

        #endregion

        #region Data Loading Methods

        /// <summary>
        /// Load danh sách cây trồng vào ComboBox
        /// </summary>
        private void LoadCayTrong()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MaCay, TenCay, LoaiCay FROM CayTrong ORDER BY TenCay";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    dtCayTrong = new DataTable();
                    da.Fill(dtCayTrong);

                    // Thêm dòng trống đầu tiên
                    DataRow emptyRow = dtCayTrong.NewRow();
                    emptyRow["MaCay"] = DBNull.Value;
                    emptyRow["TenCay"] = "-- Chọn cây trồng --";
                    dtCayTrong.Rows.InsertAt(emptyRow, 0);

                    cboMaCay.DataSource = dtCayTrong;
                    cboMaCay.DisplayMember = "TenCay";
                    cboMaCay.ValueMember = "MaCay";
                    cboMaCay.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách cây trồng:\n{ex.Message}",
                    "❌ Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load danh sách nhân viên vào ComboBox - THÊM MỚI
        /// </summary>
        private void LoadNhanVien()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MaNV, HoTen FROM NhanVien ORDER BY HoTen";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    dtNhanVien = new DataTable();
                    da.Fill(dtNhanVien);

                    // Thêm dòng trống đầu tiên
                    DataRow emptyRow = dtNhanVien.NewRow();
                    emptyRow["MaNV"] = DBNull.Value;
                    emptyRow["HoTen"] = "-- Chọn nhân viên --";
                    dtNhanVien.Rows.InsertAt(emptyRow, 0);

                    cboNhanVien.DataSource = dtNhanVien;
                    cboNhanVien.DisplayMember = "HoTen";
                    cboNhanVien.ValueMember = "MaNV";
                    cboNhanVien.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhân viên:\n{ex.Message}",
                    "❌ Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load dữ liệu chi tiết thu hoạch
        /// </summary>
        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            ct.MaChiTietCT,
                            ct.MaCay,
                            c.TenCay,
                            c.LoaiCay,
                            ct.SoLuong,
                            ct.ChatLuong,
                            ct.GhiChu
                        FROM ChiTietThuHoachCayTrong ct
                        INNER JOIN CayTrong c ON ct.MaCay = c.MaCay
                        ORDER BY ct.MaChiTietCT DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    dtChiTiet = new DataTable();
                    da.Fill(dtChiTiet);

                    // Bind dữ liệu vào DataGridView
                    dgvChiTiet.DataSource = dtChiTiet;

                    // Định dạng các cột
                    FormatDataGridView();

                    // Cập nhật thống kê
                    UpdateStatistics();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu:\n{ex.Message}",
                    "❌ Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Định dạng DataGridView
        /// </summary>
        private void FormatDataGridView()
        {
            if (dgvChiTiet.Columns.Count > 0)
            {
                // Đặt tiêu đề cột
                dgvChiTiet.Columns["MaChiTietCT"].HeaderText = "Mã Chi Tiết";
                dgvChiTiet.Columns["MaCay"].HeaderText = "Mã Cây";
                dgvChiTiet.Columns["TenCay"].HeaderText = "Tên Cây";
                dgvChiTiet.Columns["LoaiCay"].HeaderText = "Loại Cây";
                dgvChiTiet.Columns["SoLuong"].HeaderText = "Số Lượng (kg)";
                dgvChiTiet.Columns["ChatLuong"].HeaderText = "Chất Lượng";
                dgvChiTiet.Columns["GhiChu"].HeaderText = "Ghi Chú";

                // Căn chỉnh
                dgvChiTiet.Columns["MaChiTietCT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvChiTiet.Columns["MaCay"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvChiTiet.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvChiTiet.Columns["SoLuong"].DefaultCellStyle.Format = "N2";
                dgvChiTiet.Columns["ChatLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Độ rộng cột
                dgvChiTiet.Columns["MaChiTietCT"].Width = 90;
                dgvChiTiet.Columns["MaCay"].Width = 70;
                dgvChiTiet.Columns["TenCay"].Width = 120;
                dgvChiTiet.Columns["LoaiCay"].Width = 100;
                dgvChiTiet.Columns["SoLuong"].Width = 110;
                dgvChiTiet.Columns["ChatLuong"].Width = 90;
                dgvChiTiet.Columns["GhiChu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        #endregion

        #region Button Events

        /// <summary>
        /// ✅ SỬA LẠI - Xử lý sự kiện nút Thêm - GỌI PROCEDURE
        /// Thêm thu hoạch + Tự động tạo sản phẩm
        /// </summary>
        private void BtnThem_Click(object sender, EventArgs e)
        {
            // Validate dữ liệu đầu vào
            if (!ValidateInput()) return;
            if (!ValidateInputSanPham()) return;  // Validate thêm phần sản phẩm

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // ========================================
                    // GỌI PROCEDURE sp_ThemThuHoachCayTrong
                    // Thêm vào 3 bảng: ChiTietThuHoachCayTrong, ThuHoach, SanPham
                    // ========================================
                    using (SqlCommand cmd = new SqlCommand("sp_ThemThuHoachCayTrong", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Tham số cho Chi tiết thu hoạch
                        cmd.Parameters.AddWithValue("@MaCay", cboMaCay.SelectedValue);
                        cmd.Parameters.AddWithValue("@SoLuongTH", numSoLuong.Value);
                        cmd.Parameters.AddWithValue("@ChatLuong", cboChatLuong.Text);
                        cmd.Parameters.AddWithValue("@GhiChuCT", string.IsNullOrEmpty(txtGhiChu.Text) ? (object)DBNull.Value : txtGhiChu.Text);

                        // Tham số cho Thu hoạch
                        cmd.Parameters.AddWithValue("@MaNV", cboNhanVien.SelectedValue);

                        // Tham số cho Sản phẩm
                        cmd.Parameters.AddWithValue("@TenSP", txtTenSP.Text.Trim());
                        cmd.Parameters.AddWithValue("@DonViSP", txtDonViSP.Text.Trim());
                        cmd.Parameters.AddWithValue("@GiaBan", decimal.Parse(txtGiaBan.Text));

                        // Thực thi và lấy kết quả
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            string result = reader["Result"].ToString();
                            MessageBox.Show($"✅ {result}",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        reader.Close();
                    }
                }

                // Reload dữ liệu
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi khi thêm dữ liệu:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện nút Sửa (Chỉ sửa Chi tiết thu hoạch, không sửa sản phẩm)
        /// </summary>
        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaChiTiet.Text))
            {
                MessageBox.Show("⚠️ Vui lòng chọn một bản ghi để sửa!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn cập nhật thông tin này?\n\n" +
                "⚠️ Lưu ý: Chỉ cập nhật chi tiết thu hoạch, không ảnh hưởng sản phẩm đã tạo.",
                "❓ Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        UPDATE ChiTietThuHoachCayTrong 
                        SET MaCay = @MaCay, 
                            SoLuong = @SoLuong, 
                            ChatLuong = @ChatLuong, 
                            GhiChu = @GhiChu
                        WHERE MaChiTietCT = @MaChiTietCT";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaChiTietCT", int.Parse(txtMaChiTiet.Text));
                        cmd.Parameters.AddWithValue("@MaCay", cboMaCay.SelectedValue);
                        cmd.Parameters.AddWithValue("@SoLuong", numSoLuong.Value);
                        cmd.Parameters.AddWithValue("@ChatLuong", cboChatLuong.Text);
                        cmd.Parameters.AddWithValue("@GhiChu", string.IsNullOrEmpty(txtGhiChu.Text) ? (object)DBNull.Value : txtGhiChu.Text);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("✅ Cập nhật thông tin thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi khi cập nhật dữ liệu:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện nút Xóa
        /// </summary>
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaChiTiet.Text))
            {
                MessageBox.Show("⚠️ Vui lòng chọn một bản ghi để xóa!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa chi tiết thu hoạch có mã '{txtMaChiTiet.Text}'?\n\n" +
                "⚠️ Lưu ý: Hành động này không thể hoàn tác!",
                "❓ Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra xem có ràng buộc với bảng ThuHoach không
                    string checkQuery = "SELECT COUNT(*) FROM ThuHoach WHERE MaChiTietCT = @MaChiTietCT";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@MaChiTietCT", int.Parse(txtMaChiTiet.Text));
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show(
                                "❌ Không thể xóa!\n\n" +
                                "Chi tiết thu hoạch này đã được sử dụng trong bảng Thu Hoạch.\n" +
                                "Vui lòng xóa các bản ghi liên quan trước.",
                                "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string query = "DELETE FROM ChiTietThuHoachCayTrong WHERE MaChiTietCT = @MaChiTietCT";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaChiTietCT", int.Parse(txtMaChiTiet.Text));
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("✅ Xóa chi tiết thu hoạch thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi khi xóa dữ liệu:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện nút Làm mới
        /// </summary>
        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadData();
            txtTimKiem.Clear();
            cboTimTheo.SelectedIndex = 0;
        }

        /// <summary>
        /// Xử lý sự kiện nút Tìm kiếm
        /// </summary>
        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        /// <summary>
        /// Xử lý sự kiện nút Đóng
        /// </summary>
        private void BtnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Control Events

        /// <summary>
        /// Xử lý sự kiện chọn cây trồng - Tự động điền tên sản phẩm
        /// </summary>
        private void CboMaCay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaCay.SelectedIndex > 0 && cboMaCay.SelectedValue != null)
            {
                DataRowView row = cboMaCay.SelectedItem as DataRowView;
                if (row != null)
                {
                    string tenCay = row["TenCay"]?.ToString() ?? "";
                    string loaiCay = row["LoaiCay"]?.ToString() ?? "";
                    txtTenCay.Text = $"{tenCay} ({loaiCay})";
                    txtTenCay.ForeColor = Color.FromArgb(33, 33, 33);
                    txtTenCay.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

                    // ✅ TỰ ĐỘNG ĐIỀN TÊN SẢN PHẨM
                    txtTenSP.Text = $"{tenCay} tươi";
                    txtDonViSP.Text = "Kg";
                }
            }
            else
            {
                txtTenCay.Text = "(Tự động hiển thị khi chọn cây)";
                txtTenCay.ForeColor = Color.FromArgb(100, 100, 100);
                txtTenCay.Font = new Font("Segoe UI", 10F, FontStyle.Italic);

                // Clear thông tin sản phẩm
                txtTenSP.Text = "";
                txtDonViSP.Text = "";
            }
        }

        /// <summary>
        /// Xử lý sự kiện click vào DataGridView
        /// </summary>
        private void DgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvChiTiet.Rows.Count)
            {
                DataGridViewRow row = dgvChiTiet.Rows[e.RowIndex];

                txtMaChiTiet.Text = row.Cells["MaChiTietCT"].Value?.ToString() ?? "";

                // Chọn cây trồng
                if (row.Cells["MaCay"].Value != null)
                {
                    cboMaCay.SelectedValue = row.Cells["MaCay"].Value;
                }

                // Số lượng
                if (decimal.TryParse(row.Cells["SoLuong"].Value?.ToString(), out decimal soLuong))
                {
                    numSoLuong.Value = soLuong;
                }

                // Chất lượng
                string chatLuong = row.Cells["ChatLuong"].Value?.ToString() ?? "";
                cboChatLuong.SelectedIndex = cboChatLuong.Items.IndexOf(chatLuong);

                // Ghi chú
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";

                // Đổi màu dòng được chọn
                foreach (DataGridViewRow r in dgvChiTiet.Rows)
                {
                    r.DefaultCellStyle.BackColor = Color.White;
                }
                row.DefaultCellStyle.BackColor = Color.FromArgb(200, 230, 201);

                // ⚠️ Khi chọn dòng cũ, disable phần sản phẩm (vì đã tạo rồi)
                SetSanPhamControlsEnabled(false);
            }
        }

        /// <summary>
        /// Xử lý sự kiện nhấn Enter trong ô tìm kiếm
        /// </summary>
        private void TxtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchData();
                e.Handled = true;
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Thiết lập giá trị mặc định
        /// </summary>
        private void SetDefaultValues()
        {
            cboTimTheo.SelectedIndex = 0;
            cboChatLuong.SelectedIndex = 0;
            numSoLuong.Value = 1;
            txtGiaBan.Text = "0";
        }

        /// <summary>
        /// Xóa form và reset về trạng thái ban đầu
        /// </summary>
        private void ClearForm()
        {
            txtMaChiTiet.Clear();
            cboMaCay.SelectedIndex = 0;
            numSoLuong.Value = 1;
            cboChatLuong.SelectedIndex = 0;
            txtGhiChu.Clear();
            txtTenCay.Text = "(Tự động hiển thị khi chọn cây)";
            txtTenCay.ForeColor = Color.FromArgb(100, 100, 100);
            txtTenCay.Font = new Font("Segoe UI", 10F, FontStyle.Italic);

            // Clear phần sản phẩm
            cboNhanVien.SelectedIndex = 0;
            txtTenSP.Text = "";
            txtDonViSP.Text = "";
            txtGiaBan.Text = "0";

            // Enable lại phần sản phẩm
            SetSanPhamControlsEnabled(true);

            // Reset màu DataGridView
            foreach (DataGridViewRow row in dgvChiTiet.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }

            cboMaCay.Focus();
        }

        /// <summary>
        /// Bật/Tắt các control nhập sản phẩm
        /// </summary>
        private void SetSanPhamControlsEnabled(bool enabled)
        {
            cboNhanVien.Enabled = enabled;
            txtTenSP.Enabled = enabled;
            txtDonViSP.Enabled = enabled;
            txtGiaBan.Enabled = enabled;
        }

        /// <summary>
        /// Kiểm tra dữ liệu nhập vào (Chi tiết thu hoạch)
        /// </summary>
        private bool ValidateInput()
        {
            // Kiểm tra cây trồng
            if (cboMaCay.SelectedIndex <= 0 || cboMaCay.SelectedValue == null || cboMaCay.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("⚠️ Vui lòng chọn cây trồng!",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaCay.Focus();
                return false;
            }

            // Kiểm tra số lượng
            if (numSoLuong.Value <= 0)
            {
                MessageBox.Show("⚠️ Số lượng phải lớn hơn 0!",
                    "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numSoLuong.Focus();
                return false;
            }

            // Kiểm tra chất lượng
            if (cboChatLuong.SelectedIndex < 0 || string.IsNullOrEmpty(cboChatLuong.Text))
            {
                MessageBox.Show("⚠️ Vui lòng chọn chất lượng!",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboChatLuong.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Kiểm tra dữ liệu sản phẩm - THÊM MỚI
        /// </summary>
        private bool ValidateInputSanPham()
        {
            // Kiểm tra nhân viên
            if (cboNhanVien.SelectedIndex <= 0 || cboNhanVien.SelectedValue == null || cboNhanVien.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("⚠️ Vui lòng chọn nhân viên thu hoạch!",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNhanVien.Focus();
                return false;
            }

            // Kiểm tra tên sản phẩm
            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("⚠️ Vui lòng nhập tên sản phẩm!",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSP.Focus();
                return false;
            }

            // Kiểm tra đơn vị
            if (string.IsNullOrWhiteSpace(txtDonViSP.Text))
            {
                MessageBox.Show("⚠️ Vui lòng nhập đơn vị sản phẩm!",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonViSP.Focus();
                return false;
            }

            // Kiểm tra giá bán
            if (!decimal.TryParse(txtGiaBan.Text, out decimal giaBan) || giaBan < 0)
            {
                MessageBox.Show("⚠️ Giá bán phải là số >= 0!",
                    "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaBan.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Lấy mã chi tiết tiếp theo
        /// </summary>
        private int GetNextId(SqlConnection conn)
        {
            string query = "SELECT ISNULL(MAX(MaChiTietCT), 0) + 1 FROM ChiTietThuHoachCayTrong";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                return (int)cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Tìm kiếm dữ liệu
        /// </summary>
        private void SearchData()
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                LoadData();
                return;
            }

            try
            {
                string searchColumn;
                switch (cboTimTheo.SelectedIndex)
                {
                    case 0: // Mã chi tiết
                        searchColumn = "ct.MaChiTietCT";
                        break;
                    case 1: // Tên cây
                        searchColumn = "c.TenCay";
                        break;
                    case 2: // Chất lượng
                        searchColumn = "ct.ChatLuong";
                        break;
                    default:
                        searchColumn = "ct.MaChiTietCT";
                        break;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = $@"
                        SELECT 
                            ct.MaChiTietCT,
                            ct.MaCay,
                            c.TenCay,
                            c.LoaiCay,
                            ct.SoLuong,
                            ct.ChatLuong,
                            ct.GhiChu
                        FROM ChiTietThuHoachCayTrong ct
                        INNER JOIN CayTrong c ON ct.MaCay = c.MaCay
                        WHERE CAST({searchColumn} AS NVARCHAR(MAX)) LIKE @SearchText
                        ORDER BY ct.MaChiTietCT DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SearchText", "%" + txtTimKiem.Text.Trim() + "%");

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dtChiTiet = new DataTable();
                        da.Fill(dtChiTiet);

                        dgvChiTiet.DataSource = dtChiTiet;
                        FormatDataGridView();
                        UpdateStatistics();
                    }
                }

                if (dtChiTiet.Rows.Count == 0)
                {
                    MessageBox.Show("🔍 Không tìm thấy kết quả phù hợp!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi khi tìm kiếm:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cập nhật thống kê
        /// </summary>
        private void UpdateStatistics()
        {
            if (dtChiTiet == null || dtChiTiet.Rows.Count == 0)
            {
                lblTongSoLuong.Text = "📦 Tổng số lượng thu hoạch: 0 kg";
                lblThongKeLoai.Text = "📈 Loại A: 0  |  Loại B: 0  |  Loại C: 0";
                return;
            }

            try
            {
                // Tính tổng số lượng
                decimal tongSoLuong = 0;
                int loaiA = 0, loaiB = 0, loaiC = 0;

                foreach (DataRow row in dtChiTiet.Rows)
                {
                    if (row["SoLuong"] != DBNull.Value)
                    {
                        tongSoLuong += Convert.ToDecimal(row["SoLuong"]);
                    }

                    string chatLuong = row["ChatLuong"]?.ToString() ?? "";
                    switch (chatLuong)
                    {
                        case "Loại A":
                            loaiA++;
                            break;
                        case "Loại B":
                            loaiB++;
                            break;
                        case "Loại C":
                            loaiC++;
                            break;
                    }
                }

                lblTongSoLuong.Text = $"📦 Tổng số lượng thu hoạch: {tongSoLuong:N2} kg";
                lblThongKeLoai.Text = $"📈 Loại A: {loaiA}  |  Loại B: {loaiB}  |  Loại C: {loaiC}";
            }
            catch
            {
                lblTongSoLuong.Text = "📦 Tổng số lượng thu hoạch: -- kg";
                lblThongKeLoai.Text = "📈 Loại A: --  |  Loại B: --  |  Loại C: --";
            }
        }

        /// <summary>
        /// Thiết lập ToolTips
        /// </summary>
        private void SetupToolTips()
        {
            toolTip1.SetToolTip(txtMaChiTiet, "Mã chi tiết được tự động tạo");
            toolTip1.SetToolTip(cboMaCay, "Chọn cây trồng cần thu hoạch");
            toolTip1.SetToolTip(numSoLuong, "Nhập số lượng thu hoạch (kg)");
            toolTip1.SetToolTip(cboChatLuong, "Chọn loại chất lượng: A, B hoặc C");
            toolTip1.SetToolTip(txtGhiChu, "Nhập ghi chú nếu có (tối đa 255 ký tự)");
            toolTip1.SetToolTip(btnThem, "Thêm thu hoạch + Tự động tạo sản phẩm");
            toolTip1.SetToolTip(btnSua, "Cập nhật thông tin đã chọn");
            toolTip1.SetToolTip(btnXoa, "Xóa bản ghi đã chọn");
            toolTip1.SetToolTip(btnLamMoi, "Làm mới form và tải lại dữ liệu");
            toolTip1.SetToolTip(btnTimKiem, "Tìm kiếm theo tiêu chí đã chọn");
            toolTip1.SetToolTip(txtTimKiem, "Nhập từ khóa tìm kiếm, nhấn Enter để tìm");

            // Tooltip cho phần sản phẩm
            toolTip1.SetToolTip(cboNhanVien, "Chọn nhân viên thực hiện thu hoạch");
            toolTip1.SetToolTip(txtTenSP, "Tên sản phẩm sẽ được tạo");
            toolTip1.SetToolTip(txtDonViSP, "Đơn vị tính của sản phẩm (Kg, Quả...)");
            toolTip1.SetToolTip(txtGiaBan, "Giá bán sản phẩm (VNĐ)");
        }

        #endregion

        #region Event Handlers (Generated by Designer)

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
        }

        private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtDonViSP_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
        }

        #endregion

        private void pnlThongKe_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}