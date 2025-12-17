using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QL_TrangTrai
{
    public partial class frmChiTietThuHoachVatNuoi : Form
    {
        #region Fields

        // Connection string - điều chỉnh theo cấu hình của bạn
        private readonly string connectionString = @"Data Source=HUYNE;Initial Catalog=QL_TrangTraiv13;Integrated Security=True";

        // DataTable để lưu trữ dữ liệu
        private DataTable dtChiTiet;
        private DataTable dtVatNuoi;
        private DataTable dtNhanVien;
        private int _maNguoiDung = 0;
        private int _maVaiTro = 1;



        // Biến lưu trạng thái đang thêm mới hay sửa
        private bool isAddNew = false;

        #endregion

        #region Constructor

        public frmChiTietThuHoachVatNuoi(int maNguoiDung, int maVaiTro)
        {
            InitializeComponent();
            _maNguoiDung = maNguoiDung;
            _maVaiTro = maVaiTro;
            this.Load += FrmChiTietThuHoachVatNuoi_Load;
        }



        #endregion

        #region Form Events

        private void FrmChiTietThuHoachVatNuoi_Load(object sender, EventArgs e)
        {
            // Đăng ký sự kiện
            RegisterEvents();
            // Đặt font hỗ trợ tiếng Việt cho DataGridView
            dgvChiTiet.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dgvChiTiet.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            // Load dữ liệu
            LoadVatNuoi();
            LoadNhanVien();
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
            cboLoaiThuHoach.SelectedIndexChanged += CboLoaiThuHoach_SelectedIndexChanged;

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
                    string query = "SELECT MaVat, TenVat, LoaiVat, SoLuong, TinhTrangSucKhoe FROM VatNuoi ORDER BY TenVat";
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
        /// Load danh sách nhân viên vào ComboBox
        /// </summary>
        private void LoadNhanVien()
        {
            MessageBox.Show($"DEBUG - MaVaiTro: {_maVaiTro}, MaNguoiDung: {_maNguoiDung}");
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query;
                    SqlDataAdapter da;

                    if (_maVaiTro == 2 && _maNguoiDung > 0)
                    {
                        // NHÂN VIÊN: chỉ load đúng người đang đăng nhập
                        // Lấy nhân viên có MaNguoiDung trùng với người đăng nhập
                        query = "SELECT MaNV, HoTen FROM NhanVien WHERE MaNguoiDung = @MaNguoiDung";
                        da = new SqlDataAdapter(query, conn);
                        da.SelectCommand.Parameters.AddWithValue("@MaNguoiDung", _maNguoiDung);
                    }
                    else
                    {
                        // ADMIN (MaVaiTro = 1): load tất cả nhân viên
                        query = "SELECT MaNV, HoTen FROM NhanVien ORDER BY HoTen";
                        da = new SqlDataAdapter(query, conn);
                    }

                    dtNhanVien = new DataTable();
                    da.Fill(dtNhanVien);

                    // Nếu ADMIN thì thêm dòng "-- Chọn nhân viên --"
                    if (_maVaiTro == 1)
                    {
                        DataRow emptyRow = dtNhanVien.NewRow();
                        emptyRow["MaNV"] = 0;
                        emptyRow["HoTen"] = "-- Chọn nhân viên --";
                        dtNhanVien.Rows.InsertAt(emptyRow, 0);
                    }

                    cboNhanVien.DisplayMember = "HoTen";
                    cboNhanVien.ValueMember = "MaNV";
                    cboNhanVien.DataSource = dtNhanVien;
                    cboNhanVien.ForeColor = Color.Black;

                    if (_maVaiTro == 2 && _maNguoiDung > 0)
                    {
                        // NHÂN VIÊN: combo chỉ có 1 dòng, tự chọn và KHÓA
                        if (dtNhanVien.Rows.Count > 0)
                        {
                            cboNhanVien.SelectedIndex = 0;
                        }
                        cboNhanVien.Enabled = false; // KHÓA không cho chọn
                    }
                    else
                    {
                        // ADMIN: cho phép chọn
                        cboNhanVien.SelectedIndex = 0;
                        cboNhanVien.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhân viên:\n{ex.Message}",
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
                            v.SoLuong AS SoLuongConLai,
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
                if (dgvChiTiet.Columns["MaChiTietVN"] != null)
                    dgvChiTiet.Columns["MaChiTietVN"].HeaderText = "Mã Chi Tiết";
                if (dgvChiTiet.Columns["MaVat"] != null)
                    dgvChiTiet.Columns["MaVat"].HeaderText = "Mã Vật";
                if (dgvChiTiet.Columns["TenVat"] != null)
                    dgvChiTiet.Columns["TenVat"].HeaderText = "Tên Vật Nuôi";
                if (dgvChiTiet.Columns["LoaiVat"] != null)
                    dgvChiTiet.Columns["LoaiVat"].HeaderText = "Loại Vật";
                if (dgvChiTiet.Columns["SoLuongConLai"] != null)
                    dgvChiTiet.Columns["SoLuongConLai"].HeaderText = "SL Còn Lại";
                if (dgvChiTiet.Columns["LoaiThuHoach"] != null)
                    dgvChiTiet.Columns["LoaiThuHoach"].HeaderText = "Loại Thu Hoạch";
                if (dgvChiTiet.Columns["SoLuong"] != null)
                    dgvChiTiet.Columns["SoLuong"].HeaderText = "Số Lượng TH";
                if (dgvChiTiet.Columns["CanNang"] != null)
                    dgvChiTiet.Columns["CanNang"].HeaderText = "Cân Nặng (kg)";
                if (dgvChiTiet.Columns["GhiChu"] != null)
                    dgvChiTiet.Columns["GhiChu"].HeaderText = "Ghi Chú";

                // Căn chỉnh và format
                if (dgvChiTiet.Columns["MaChiTietVN"] != null)
                {
                    dgvChiTiet.Columns["MaChiTietVN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvChiTiet.Columns["MaChiTietVN"].Width = 85;
                }
                if (dgvChiTiet.Columns["MaVat"] != null)
                {
                    dgvChiTiet.Columns["MaVat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvChiTiet.Columns["MaVat"].Width = 65;
                }
                if (dgvChiTiet.Columns["SoLuong"] != null)
                {
                    dgvChiTiet.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvChiTiet.Columns["SoLuong"].DefaultCellStyle.Format = "N2";
                    dgvChiTiet.Columns["SoLuong"].Width = 85;
                }
                if (dgvChiTiet.Columns["CanNang"] != null)
                {
                    dgvChiTiet.Columns["CanNang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvChiTiet.Columns["CanNang"].DefaultCellStyle.Format = "N2";
                    dgvChiTiet.Columns["CanNang"].Width = 100;
                }
                if (dgvChiTiet.Columns["LoaiThuHoach"] != null)
                {
                    dgvChiTiet.Columns["LoaiThuHoach"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvChiTiet.Columns["LoaiThuHoach"].Width = 100;
                }
                if (dgvChiTiet.Columns["GhiChu"] != null)
                {
                    dgvChiTiet.Columns["GhiChu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }

        #endregion

        #region Button Events

        /// <summary>
        /// Xử lý sự kiện nút Thêm - SỬ DỤNG STORED PROCEDURE sp_ThemThuHoachVatNuoi
        /// </summary>
        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            // Kiểm tra nếu là "Giết mổ" thì cảnh báo sẽ trừ số lượng
            string loaiThuHoach = cboLoaiThuHoach.Text;
            if (loaiThuHoach == "Giết mổ")
            {
                // Lấy số lượng hiện tại của vật nuôi
                int soLuongHienTai = GetSoLuongVatNuoi((int)cboMaVat.SelectedValue);
                decimal soLuongThuHoach = numSoLuong.Value;

                if (soLuongThuHoach > soLuongHienTai)
                {
                    MessageBox.Show(
                        $"⚠️ Số lượng giết mổ ({soLuongThuHoach:N0}) vượt quá số lượng hiện có ({soLuongHienTai})!\n\n" +
                        "Vui lòng nhập số lượng hợp lệ.",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numSoLuong.Focus();
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    $"🔪 Loại thu hoạch: GIẾT MỔ\n\n" +
                    $"Số lượng hiện có: {soLuongHienTai}\n" +
                    $"Số lượng giết mổ: {soLuongThuHoach:N0}\n" +
                    $"Số lượng còn lại: {soLuongHienTai - soLuongThuHoach:N0}\n\n" +
                    "⚠️ Số lượng vật nuôi sẽ bị TRỪ sau khi thêm!\n\n" +
                    "Bạn có chắc chắn muốn tiếp tục?",
                    "❓ Xác nhận giết mổ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Lấy MaNV (mặc định là 3 nếu không có ComboBox nhân viên)
                    int maNV;
                    if (cboNhanVien.SelectedValue == null || cboNhanVien.SelectedValue == DBNull.Value)
                    {
                        MessageBox.Show("⚠️ Vui lòng chọn nhân viên!", "Thiếu thông tin",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    maNV = Convert.ToInt32(cboNhanVien.SelectedValue); // Mặc định
                    if (this.Controls.Find("cboNhanVien", true).Length > 0)
                    {
                        ComboBox cboNV = (ComboBox)this.Controls.Find("cboNhanVien", true)[0];
                        if (cboNV.SelectedValue != null && cboNV.SelectedValue != DBNull.Value)
                        {
                            maNV = (int)cboNV.SelectedValue;
                        }
                    }

                    // GỌI STORED PROCEDURE sp_ThemThuHoachVatNuoi
                    using (SqlCommand cmd = new SqlCommand("sp_ThemThuHoachVatNuoi", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MaVat", cboMaVat.SelectedValue);
                        cmd.Parameters.AddWithValue("@LoaiThuHoach", loaiThuHoach);
                        cmd.Parameters.AddWithValue("@SoLuong", numSoLuong.Value);
                        cmd.Parameters.AddWithValue("@CanNang", numCanNang.Value);
                        cmd.Parameters.AddWithValue("@MaNV", maNV);
                        cmd.Parameters.AddWithValue("@GhiChu",
                            string.IsNullOrEmpty(txtGhiChu.Text) ? (object)DBNull.Value : txtGhiChu.Text);

                        cmd.ExecuteNonQuery();
                    }
                }

                string thongBao = "✅ Thêm thu hoạch vật nuôi thành công!\n\n";
                thongBao += $"• Đã thêm vào bảng ChiTietThuHoachVatNuoi\n";
                thongBao += $"• Đã thêm vào bảng ThuHoach\n";
                thongBao += $"• Đã thêm vào bảng SanPham\n";

                if (loaiThuHoach == "Giết mổ")
                {
                    thongBao += $"• Đã TRỪ {numSoLuong.Value:N0} trong bảng VatNuoi";
                }

                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload dữ liệu
                LoadData();
                LoadVatNuoi(); // Reload để cập nhật số lượng mới
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi khi thêm dữ liệu:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Lấy số lượng hiện tại của vật nuôi
        /// </summary>
        private int GetSoLuongVatNuoi(int maVat)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT SoLuong FROM VatNuoi WHERE MaVat = @MaVat";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaVat", maVat);
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch
            {
                return 0;
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
                "⚠️ Lưu ý: Chỉ cập nhật thông tin trong bảng ChiTietThuHoachVatNuoi.\n" +
                "Số lượng vật nuôi sẽ KHÔNG được điều chỉnh lại.\n\n" +
                "Bạn có chắc chắn muốn cập nhật?",
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
                        cmd.Parameters.AddWithValue("@GhiChu",
                            string.IsNullOrEmpty(txtGhiChu.Text) ? (object)DBNull.Value : txtGhiChu.Text);

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
                "⚠️ Lưu ý: \n" +
                "• Hành động này không thể hoàn tác!\n" +
                "• Số lượng vật nuôi sẽ KHÔNG được hoàn lại!",
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
            LoadVatNuoi(); // Reload số lượng vật nuôi mới nhất
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
            if (cboMaVat.SelectedIndex > 0 && cboMaVat.SelectedValue != null && cboMaVat.SelectedValue != DBNull.Value)
            {
                DataRowView row = cboMaVat.SelectedItem as DataRowView;
                if (row != null)
                {
                    string tenVat = row["TenVat"]?.ToString() ?? "";
                    string loaiVat = row["LoaiVat"]?.ToString() ?? "";
                    string tinhTrang = row["TinhTrangSucKhoe"]?.ToString() ?? "";
                    int soLuong = row["SoLuong"] != DBNull.Value ? Convert.ToInt32(row["SoLuong"]) : 0;

                    txtTenVat.Text = $"{tenVat} - {loaiVat} | SL: {soLuong} ({tinhTrang})";
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
        /// Xử lý sự kiện thay đổi loại thu hoạch
        /// </summary>
        private void CboLoaiThuHoach_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hiển thị cảnh báo nếu chọn "Giết mổ"
            if (cboLoaiThuHoach.Text == "Giết mổ")
            {
                // Có thể thay đổi màu hoặc hiển thị warning
                cboLoaiThuHoach.BackColor = Color.FromArgb(255, 235, 235);
            }
            else
            {
                cboLoaiThuHoach.BackColor = Color.White;
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
                int idx = cboLoaiThuHoach.Items.IndexOf(loaiThuHoach);
                if (idx >= 0) cboLoaiThuHoach.SelectedIndex = idx;

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
            if (cboTimTheo.Items.Count > 0)
                cboTimTheo.SelectedIndex = 0;
            if (cboLoaiThuHoach.Items.Count > 0)
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
            if (cboLoaiThuHoach.Items.Count > 0)
                cboLoaiThuHoach.SelectedIndex = 0;
            cboLoaiThuHoach.BackColor = Color.White;
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

            // Kiểm tra cân nặng
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
                            v.SoLuong AS SoLuongConLai,
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
                decimal tongSoLuong = 0;
                decimal tongCanNang = 0;
                int gietMo = 0, trung = 0, sua = 0, khac = 0;

                foreach (DataRow row in dtChiTiet.Rows)
                {
                    if (row["SoLuong"] != DBNull.Value)
                        tongSoLuong += Convert.ToDecimal(row["SoLuong"]);

                    if (row["CanNang"] != DBNull.Value)
                        tongCanNang += Convert.ToDecimal(row["CanNang"]);

                    string loaiThuHoach = row["LoaiThuHoach"]?.ToString() ?? "";
                    switch (loaiThuHoach)
                    {
                        case "Giết mổ": gietMo++; break;
                        case "Trứng": trung++; break;
                        case "Sữa": sua++; break;
                        case "Khác": khac++; break;
                    }
                }

                lblTongSoLuong.Text = $"📦 Tổng số lượng: {tongSoLuong:N2}  |  Cân nặng: {tongCanNang:N2} kg";
                lblThongKeLoai.Text = $"📈 Giết mổ: {gietMo}  |  Trứng: {trung}  |  Sữa: {sua}  |  Khác: {khac}";
            }
            catch
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
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(txtMaChiTiet, "Mã chi tiết được tự động tạo");
            toolTip.SetToolTip(cboMaVat, "Chọn vật nuôi cần thu hoạch");
            toolTip.SetToolTip(cboLoaiThuHoach, "Chọn loại thu hoạch: Giết mổ (sẽ trừ SL), Trứng, Sữa, Khác");
            toolTip.SetToolTip(numSoLuong, "Nhập số lượng thu hoạch");
            toolTip.SetToolTip(numCanNang, "Nhập cân nặng (kg)");
            toolTip.SetToolTip(txtGhiChu, "Nhập ghi chú nếu có (tối đa 255 ký tự)");
            toolTip.SetToolTip(btnThem, "Thêm mới - Sử dụng Stored Procedure sp_ThemThuHoachVatNuoi");
            toolTip.SetToolTip(btnSua, "Cập nhật thông tin đã chọn");
            toolTip.SetToolTip(btnXoa, "Xóa bản ghi đã chọn");
            toolTip.SetToolTip(btnLamMoi, "Làm mới form và tải lại dữ liệu");
            toolTip.SetToolTip(btnTimKiem, "Tìm kiếm theo tiêu chí đã chọn");
            toolTip.SetToolTip(txtTimKiem, "Nhập từ khóa tìm kiếm, nhấn Enter để tìm");
        }

        #endregion

        private void lblSoLuong_Click(object sender, EventArgs e)
        {
            // Empty event handler
        }

        private void dgvChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label_NhanVien_Click(object sender, EventArgs e)
        {

        }
    }
}