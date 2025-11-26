using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QL_TrangTrai
{
    public partial class frmChiTietThuHoachVatNuoi : Form
    {
        #region Fields

        // Connection string
        private readonly string connectionString = @"Data Source=HUYNE;Initial Catalog=QL_TrangTraiv13;Integrated Security=True";

        // DataTable để lưu trữ dữ liệu
        private DataTable dtChiTiet;
        private DataTable dtVatNuoi;

        // Biến lưu trạng thái đang thêm mới hay sửa
        private bool isAddNew = false;

        #endregion

        #region Constructor

        public frmChiTietThuHoachVatNuoi()
        {
            InitializeComponent();
            this.Load += FrmChiTietThuHoachVatNuoi_Load;
        }

        #endregion

        #region Form Events

        private void FrmChiTietThuHoachVatNuoi_Load(object sender, EventArgs e)
        {
            // Đăng ký sự kiện
            RegisterEvents();

            // Load dữ liệu
            LoadVatNuoi();
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
            cboMaVat.SelectedIndexChanged += CboMaVat_SelectedIndexChanged;

            // DataGridView events
            dgvChiTiet.CellClick += DgvChiTiet_CellClick;

            // TextBox events - Enter key for search
            txtTimKiem.KeyPress += TxtTimKiem_KeyPress;
        }

        #endregion

        #region Data Loading Methods

        /// <summary>
        /// Load danh sách vật nuôi vào ComboBox
        /// </summary>
        private void LoadVatNuoi()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MaVat, TenVat, LoaiVat, TinhTrangSucKhoe FROM VatNuoi ORDER BY TenVat";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    dtVatNuoi = new DataTable();
                    da.Fill(dtVatNuoi);

                    // Thêm dòng trống đầu tiên
                    DataRow emptyRow = dtVatNuoi.NewRow();
                    emptyRow["MaVat"] = DBNull.Value;
                    emptyRow["TenVat"] = "-- Chọn vật nuôi --";
                    dtVatNuoi.Rows.InsertAt(emptyRow, 0);

                    cboMaVat.DataSource = dtVatNuoi;
                    cboMaVat.DisplayMember = "TenVat";
                    cboMaVat.ValueMember = "MaVat";
                    cboMaVat.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách vật nuôi:\n{ex.Message}",
                    "❌ Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load dữ liệu chi tiết thu hoạch vật nuôi
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
                            ct.MaChiTietVN,
                            ct.MaVat,
                            v.TenVat,
                            v.LoaiVat,
                            ct.LoaiThuHoach,
                            ct.SoLuong,
                            ct.CanNang,
                            ct.GhiChu
                        FROM ChiTietThuHoachVatNuoi ct
                        INNER JOIN VatNuoi v ON ct.MaVat = v.MaVat
                        ORDER BY ct.MaChiTietVN DESC";

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
                dgvChiTiet.Columns["MaChiTietVN"].HeaderText = "Mã Chi Tiết";
                dgvChiTiet.Columns["MaVat"].HeaderText = "Mã Vật";
                dgvChiTiet.Columns["TenVat"].HeaderText = "Tên Vật Nuôi";
                dgvChiTiet.Columns["LoaiVat"].HeaderText = "Loại Vật";
                dgvChiTiet.Columns["LoaiThuHoach"].HeaderText = "Loại Thu Hoạch";
                dgvChiTiet.Columns["SoLuong"].HeaderText = "Số Lượng";
                dgvChiTiet.Columns["CanNang"].HeaderText = "Cân Nặng (kg)";
                dgvChiTiet.Columns["GhiChu"].HeaderText = "Ghi Chú";

                // Căn chỉnh
                dgvChiTiet.Columns["MaChiTietVN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvChiTiet.Columns["MaVat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvChiTiet.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvChiTiet.Columns["SoLuong"].DefaultCellStyle.Format = "N2";
                dgvChiTiet.Columns["CanNang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvChiTiet.Columns["CanNang"].DefaultCellStyle.Format = "N2";
                dgvChiTiet.Columns["LoaiThuHoach"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Độ rộng cột
                dgvChiTiet.Columns["MaChiTietVN"].Width = 85;
                dgvChiTiet.Columns["MaVat"].Width = 65;
                dgvChiTiet.Columns["TenVat"].Width = 110;
                dgvChiTiet.Columns["LoaiVat"].Width = 90;
                dgvChiTiet.Columns["LoaiThuHoach"].Width = 100;
                dgvChiTiet.Columns["SoLuong"].Width = 85;
                dgvChiTiet.Columns["CanNang"].Width = 100;
                dgvChiTiet.Columns["GhiChu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        #endregion

        #region Button Events

        /// <summary>
        /// Xử lý sự kiện nút Thêm
        /// </summary>
        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Lấy mã chi tiết mới
                    int newId = GetNextId(conn);

                    string query = @"
                        INSERT INTO ChiTietThuHoachVatNuoi (MaChiTietVN, MaVat, LoaiThuHoach, SoLuong, CanNang, GhiChu)
                        VALUES (@MaChiTietVN, @MaVat, @LoaiThuHoach, @SoLuong, @CanNang, @GhiChu)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaChiTietVN", newId);
                        cmd.Parameters.AddWithValue("@MaVat", cboMaVat.SelectedValue);
                        cmd.Parameters.AddWithValue("@LoaiThuHoach", cboLoaiThuHoach.Text);
                        cmd.Parameters.AddWithValue("@SoLuong", numSoLuong.Value);
                        cmd.Parameters.AddWithValue("@CanNang", numCanNang.Value);
                        cmd.Parameters.AddWithValue("@GhiChu", string.IsNullOrEmpty(txtGhiChu.Text) ? (object)DBNull.Value : txtGhiChu.Text);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("✅ Thêm chi tiết thu hoạch vật nuôi thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        /// Xử lý sự kiện nút Sửa
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
                "Bạn có chắc chắn muốn cập nhật thông tin này?",
                "❓ Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        UPDATE ChiTietThuHoachVatNuoi 
                        SET MaVat = @MaVat, 
                            LoaiThuHoach = @LoaiThuHoach,
                            SoLuong = @SoLuong, 
                            CanNang = @CanNang, 
                            GhiChu = @GhiChu
                        WHERE MaChiTietVN = @MaChiTietVN";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaChiTietVN", int.Parse(txtMaChiTiet.Text));
                        cmd.Parameters.AddWithValue("@MaVat", cboMaVat.SelectedValue);
                        cmd.Parameters.AddWithValue("@LoaiThuHoach", cboLoaiThuHoach.Text);
                        cmd.Parameters.AddWithValue("@SoLuong", numSoLuong.Value);
                        cmd.Parameters.AddWithValue("@CanNang", numCanNang.Value);
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
                    string checkQuery = "SELECT COUNT(*) FROM ThuHoach WHERE MaChiTietVN = @MaChiTietVN";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@MaChiTietVN", int.Parse(txtMaChiTiet.Text));
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

                    string query = "DELETE FROM ChiTietThuHoachVatNuoi WHERE MaChiTietVN = @MaChiTietVN";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaChiTietVN", int.Parse(txtMaChiTiet.Text));
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
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đóng form này?",
                "❓ Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        #endregion

        #region Control Events

        /// <summary>
        /// Xử lý sự kiện chọn vật nuôi
        /// </summary>
        private void CboMaVat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaVat.SelectedIndex > 0 && cboMaVat.SelectedValue != null)
            {
                DataRowView row = cboMaVat.SelectedItem as DataRowView;
                if (row != null)
                {
                    string tenVat = row["TenVat"]?.ToString() ?? "";
                    string loaiVat = row["LoaiVat"]?.ToString() ?? "";
                    string tinhTrang = row["TinhTrangSucKhoe"]?.ToString() ?? "";
                    txtTenVat.Text = $"{tenVat} - {loaiVat} ({tinhTrang})";
                    txtTenVat.ForeColor = Color.FromArgb(33, 33, 33);
                    txtTenVat.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                }
            }
            else
            {
                txtTenVat.Text = "(Tự động hiển thị khi chọn vật nuôi)";
                txtTenVat.ForeColor = Color.FromArgb(100, 100, 100);
                txtTenVat.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
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

                txtMaChiTiet.Text = row.Cells["MaChiTietVN"].Value?.ToString() ?? "";

                // Chọn vật nuôi
                if (row.Cells["MaVat"].Value != null)
                {
                    cboMaVat.SelectedValue = row.Cells["MaVat"].Value;
                }

                // Loại thu hoạch
                string loaiThuHoach = row.Cells["LoaiThuHoach"].Value?.ToString() ?? "";
                cboLoaiThuHoach.SelectedIndex = cboLoaiThuHoach.Items.IndexOf(loaiThuHoach);

                // Số lượng
                if (decimal.TryParse(row.Cells["SoLuong"].Value?.ToString(), out decimal soLuong))
                {
                    numSoLuong.Value = soLuong;
                }

                // Cân nặng
                if (decimal.TryParse(row.Cells["CanNang"].Value?.ToString(), out decimal canNang))
                {
                    numCanNang.Value = canNang;
                }

                // Ghi chú
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";

                // Đổi màu dòng được chọn
                foreach (DataGridViewRow r in dgvChiTiet.Rows)
                {
                    r.DefaultCellStyle.BackColor = Color.White;
                }
                row.DefaultCellStyle.BackColor = Color.FromArgb(253, 227, 212);
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
            cboLoaiThuHoach.SelectedIndex = 0;
            numSoLuong.Value = 1;
            numCanNang.Value = 0;
        }

        /// <summary>
        /// Xóa form và reset về trạng thái ban đầu
        /// </summary>
        private void ClearForm()
        {
            txtMaChiTiet.Clear();
            cboMaVat.SelectedIndex = 0;
            cboLoaiThuHoach.SelectedIndex = 0;
            numSoLuong.Value = 1;
            numCanNang.Value = 0;
            txtGhiChu.Clear();
            txtTenVat.Text = "(Tự động hiển thị khi chọn vật nuôi)";
            txtTenVat.ForeColor = Color.FromArgb(100, 100, 100);
            txtTenVat.Font = new Font("Segoe UI", 10F, FontStyle.Italic);

            // Reset màu DataGridView
            foreach (DataGridViewRow row in dgvChiTiet.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }

            cboMaVat.Focus();
        }

        /// <summary>
        /// Kiểm tra dữ liệu nhập vào
        /// </summary>
        private bool ValidateInput()
        {
            // Kiểm tra vật nuôi
            if (cboMaVat.SelectedIndex <= 0 || cboMaVat.SelectedValue == null || cboMaVat.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("⚠️ Vui lòng chọn vật nuôi!",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaVat.Focus();
                return false;
            }

            // Kiểm tra loại thu hoạch
            if (cboLoaiThuHoach.SelectedIndex < 0 || string.IsNullOrEmpty(cboLoaiThuHoach.Text))
            {
                MessageBox.Show("⚠️ Vui lòng chọn loại thu hoạch!",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiThuHoach.Focus();
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

            // Kiểm tra cân nặng (cho phép = 0 theo database)
            if (numCanNang.Value < 0)
            {
                MessageBox.Show("⚠️ Cân nặng không được âm!",
                    "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numCanNang.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Lấy mã chi tiết tiếp theo
        /// </summary>
        private int GetNextId(SqlConnection conn)
        {
            string query = "SELECT ISNULL(MAX(MaChiTietVN), 0) + 1 FROM ChiTietThuHoachVatNuoi";
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
                        searchColumn = "ct.MaChiTietVN";
                        break;
                    case 1: // Tên vật nuôi
                        searchColumn = "v.TenVat";
                        break;
                    case 2: // Loại thu hoạch
                        searchColumn = "ct.LoaiThuHoach";
                        break;
                    default:
                        searchColumn = "ct.MaChiTietVN";
                        break;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = $@"
                        SELECT 
                            ct.MaChiTietVN,
                            ct.MaVat,
                            v.TenVat,
                            v.LoaiVat,
                            ct.LoaiThuHoach,
                            ct.SoLuong,
                            ct.CanNang,
                            ct.GhiChu
                        FROM ChiTietThuHoachVatNuoi ct
                        INNER JOIN VatNuoi v ON ct.MaVat = v.MaVat
                        WHERE CAST({searchColumn} AS NVARCHAR(MAX)) LIKE @SearchText
                        ORDER BY ct.MaChiTietVN DESC";

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
                lblTongSoLuong.Text = "📦 Tổng số lượng: 0  |  Cân nặng: 0 kg";
                lblThongKeLoai.Text = "📈 Giết mổ: 0  |  Trứng: 0  |  Sữa: 0  |  Khác: 0";
                return;
            }

            try
            {
                // Tính tổng
                decimal tongSoLuong = 0;
                decimal tongCanNang = 0;
                int gietMo = 0, trung = 0, sua = 0, khac = 0;

                foreach (DataRow row in dtChiTiet.Rows)
                {
                    if (row["SoLuong"] != DBNull.Value)
                    {
                        tongSoLuong += Convert.ToDecimal(row["SoLuong"]);
                    }

                    if (row["CanNang"] != DBNull.Value)
                    {
                        tongCanNang += Convert.ToDecimal(row["CanNang"]);
                    }

                    string loaiThuHoach = row["LoaiThuHoach"]?.ToString() ?? "";
                    switch (loaiThuHoach)
                    {
                        case "Giết mổ":
                            gietMo++;
                            break;
                        case "Trứng":
                            trung++;
                            break;
                        case "Sữa":
                            sua++;
                            break;
                        case "Khác":
                            khac++;
                            break;
                    }
                }

                lblTongSoLuong.Text = $"📦 Tổng số lượng: {tongSoLuong:N2}  |  Cân nặng: {tongCanNang:N2} kg";
                lblThongKeLoai.Text = $"📈 Giết mổ: {gietMo}  |  Trứng: {trung}  |  Sữa: {sua}  |  Khác: {khac}";
            }
            catch (Exception ex)
            {
                lblTongSoLuong.Text = "📦 Tổng số lượng: --  |  Cân nặng: -- kg";
                lblThongKeLoai.Text = "📈 Giết mổ: --  |  Trứng: --  |  Sữa: --  |  Khác: --";
            }
        }

        /// <summary>
        /// Thiết lập ToolTips
        /// </summary>
        private void SetupToolTips()
        {
            toolTip1.SetToolTip(txtMaChiTiet, "Mã chi tiết được tự động tạo");
            toolTip1.SetToolTip(cboMaVat, "Chọn vật nuôi cần thu hoạch");
            toolTip1.SetToolTip(cboLoaiThuHoach, "Chọn loại thu hoạch: Giết mổ, Trứng, Sữa, Khác");
            toolTip1.SetToolTip(numSoLuong, "Nhập số lượng thu hoạch");
            toolTip1.SetToolTip(numCanNang, "Nhập cân nặng (kg)");
            toolTip1.SetToolTip(txtGhiChu, "Nhập ghi chú nếu có (tối đa 255 ký tự)");
            toolTip1.SetToolTip(btnThem, "Thêm mới chi tiết thu hoạch");
            toolTip1.SetToolTip(btnSua, "Cập nhật thông tin đã chọn");
            toolTip1.SetToolTip(btnXoa, "Xóa bản ghi đã chọn");
            toolTip1.SetToolTip(btnLamMoi, "Làm mới form và tải lại dữ liệu");
            toolTip1.SetToolTip(btnTimKiem, "Tìm kiếm theo tiêu chí đã chọn");
            toolTip1.SetToolTip(txtTimKiem, "Nhập từ khóa tìm kiếm, nhấn Enter để tìm");
        }

        #endregion

        private void lblSoLuong_Click(object sender, EventArgs e)
        {

        }
    }
}