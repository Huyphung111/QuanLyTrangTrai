
using QL_TrangTrai;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Đồ_án
{
    public partial class QL_SanPham : Form
    {
        #region Fields

        // ====================================================
        // ĐỔI CONNECTIONSTRING THEO MÁY CỦA BẠN
        // ====================================================
        private string connectionString = @"Data Source=HUYNE;Initial Catalog=QL_TrangTraiv13;Integrated Security=True";

        // Các cách khác nếu không được:
        // private string connectionString = @"Data Source=localhost;Initial Catalog=QL_TrangTraiv13;Integrated Security=True";
        // private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QL_TrangTraiv13;Integrated Security=True";
        // private string connectionString = @"Data Source=DESKTOP-XXXXXX;Initial Catalog=QL_TrangTraiv13;Integrated Security=True";

        private SqlConnection conn;
        private DataTable dtSanPham;

        // Biến kiểm tra trạng thái
        private bool isAdding = false;
        private bool isEditing = false;

        #endregion

        #region Constructor

        public QL_SanPham()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Load & Data Loading

        private void QL_SanPham_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);

            // Gỡ bỏ DataSource cũ của DataGridView (nếu có bind từ Designer)
            dgv_QLSanPham.DataSource = null;
            dgv_QLSanPham.AutoGenerateColumns = true;

            // Đăng ký sự kiện cho các button
            RegisterEvents();

            // Setup ComboBox tìm kiếm
            SetupComboBoxTimKiem();

            // Setup ComboBox Loại SP
            SetupComboBoxLoaiSP();

            // Load dữ liệu
            LoadSanPham();

            // Thiết lập trạng thái ban đầu
            SetDefaultState();
        }

        /// <summary>
        /// Đăng ký sự kiện cho các control
        /// </summary>
        private void RegisterEvents()
        {
            // Button events
            btn_Them.Click += Btn_Them_Click;
            btn_Xoa.Click += Btn_Xoa_Click;
            btn_Sua.Click += Btn_Sua_Click;
            btn_Luu.Click += Btn_Luu_Click;
            btn_Huy.Click += Btn_Huy_Click;
            btn_TimKiem.Click += Btn_TimKiem_Click;
            btn_Thoat.Click += Btn_Thoat_Click;

            // DataGridView events
            dgv_QLSanPham.CellClick += Dgv_QLSanPham_CellClick;

            // ComboBox tìm kiếm event - Enter để tìm
            cbo_TimKiem.KeyPress += Cbo_TimKiem_KeyPress;
        }

        /// <summary>
        /// Setup ComboBox tìm kiếm
        /// </summary>
        private void SetupComboBoxTimKiem()
        {
            cbo_TimKiem.Items.Clear();
            cbo_TimKiem.Items.Add("-- Tìm theo --");
            cbo_TimKiem.Items.Add("Mã sản phẩm");
            cbo_TimKiem.Items.Add("Tên sản phẩm");
            cbo_TimKiem.Items.Add("Loại sản phẩm");
            cbo_TimKiem.SelectedIndex = 0;
            cbo_TimKiem.DropDownStyle = ComboBoxStyle.DropDown; // Cho phép nhập text để tìm
        }

        /// <summary>
        /// Setup ComboBox Loại SP
        /// </summary>
        private void SetupComboBoxLoaiSP()
        {
            cbo_LoaiSP.Items.Clear();
            cbo_LoaiSP.Items.Add("Cây trồng");
            cbo_LoaiSP.Items.Add("Vật nuôi");
            cbo_LoaiSP.Items.Add("Khác");
            cbo_LoaiSP.SelectedIndex = -1;
        }

        /// <summary>
        /// Load danh sách sản phẩm
        /// </summary>
        private void LoadSanPham()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                conn.Open();

                string query = @"SELECT 
                                    MaSP,
                                    TenSP,
                                    LoaiSP,
                                    DonVi,
                                    SoLuongTon,
                                    GiaBan,
                                    NgayCapNhat,
                                    MaThuHoach
                                FROM SanPham
                                ORDER BY MaSP DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                dtSanPham = new DataTable();
                da.Fill(dtSanPham);

                // Bind dữ liệu
                dgv_QLSanPham.DataSource = null;
                dgv_QLSanPham.DataSource = dtSanPham;

                // Format DataGridView
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        /// <summary>
        /// Format DataGridView
        /// </summary>
        private void FormatDataGridView()
        {
            if (dgv_QLSanPham.Columns.Count > 0)
            {
                dgv_QLSanPham.Columns["MaSP"].HeaderText = "Mã SP";
                dgv_QLSanPham.Columns["TenSP"].HeaderText = "Tên sản phẩm";
                dgv_QLSanPham.Columns["LoaiSP"].HeaderText = "Loại SP";
                dgv_QLSanPham.Columns["DonVi"].HeaderText = "Đơn vị";
                dgv_QLSanPham.Columns["SoLuongTon"].HeaderText = "SL Tồn";
                dgv_QLSanPham.Columns["GiaBan"].HeaderText = "Giá bán";
                dgv_QLSanPham.Columns["NgayCapNhat"].HeaderText = "Ngày cập nhật";
                dgv_QLSanPham.Columns["MaThuHoach"].HeaderText = "Mã TH";

                // Format số
                dgv_QLSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
                dgv_QLSanPham.Columns["GiaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_QLSanPham.Columns["SoLuongTon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_QLSanPham.Columns["MaSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_QLSanPham.Columns["MaThuHoach"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        #endregion

        #region Button Events

        /// <summary>
        /// Nút THÊM - Chuẩn bị thêm mới
        /// </summary>
        private void Btn_Them_Click(object sender, EventArgs e)
        {
            isAdding = true;
            isEditing = false;

            // Xóa form
            ClearForm();

            // Tạo mã SP mới
            txt_MaSP.Text = GetNextMaSP().ToString();
            txt_MaSP.ReadOnly = true;

            // Cho phép nhập liệu
            SetControlsEnabled(true);

            // Focus vào tên SP
            txt_TenSP.Focus();

            // Cập nhật trạng thái nút
            UpdateButtonState();
        }

        /// <summary>
        /// Nút SỬA - Chuẩn bị sửa
        /// </summary>
        private void Btn_Sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isAdding = false;
            isEditing = true;

            // Cho phép nhập liệu (trừ mã SP)
            SetControlsEnabled(true);
            txt_MaSP.ReadOnly = true;

            // Focus vào tên SP
            txt_TenSP.Focus();

            // Cập nhật trạng thái nút
            UpdateButtonState();
        }

        /// <summary>
        /// Nút LƯU - Lưu thêm mới hoặc cập nhật
        /// </summary>
        private void Btn_Luu_Click(object sender, EventArgs e)
        {
            // Validate dữ liệu
            if (!ValidateInput()) return;

            if (isAdding)
            {
                // Thêm mới
                ThemSanPham();
            }
            else if (isEditing)
            {
                // Cập nhật
                CapNhatSanPham();
            }
        }

        /// <summary>
        /// Nút XÓA
        /// </summary>
        private void Btn_Xoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sản phẩm '{txt_TenSP.Text}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                XoaSanPham();
            }
        }

        /// <summary>
        /// Nút HỦY - Hủy thao tác
        /// </summary>
        private void Btn_Huy_Click(object sender, EventArgs e)
        {
            isAdding = false;
            isEditing = false;

            ClearForm();
            SetControlsEnabled(false);
            UpdateButtonState();
        }

        /// <summary>
        /// Nút TÌM KIẾM
        /// </summary>
        private void Btn_TimKiem_Click(object sender, EventArgs e)
        {
            TimKiemSanPham();
        }

        /// <summary>
        /// Nút THOÁT
        /// </summary>
        private void Btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region CRUD Operations

        /// <summary>
        /// Thêm sản phẩm mới
        /// </summary>
        private void ThemSanPham()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                conn.Open();

                string query = @"INSERT INTO SanPham 
                                (MaSP, TenSP, LoaiSP, DonVi, SoLuongTon, GiaBan, NgayCapNhat, MaThuHoach)
                                VALUES 
                                (@MaSP, @TenSP, @LoaiSP, @DonVi, @SoLuongTon, @GiaBan, @NgayCapNhat, @MaThuHoach)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSP", int.Parse(txt_MaSP.Text));
                cmd.Parameters.AddWithValue("@TenSP", txt_TenSP.Text.Trim());
                cmd.Parameters.AddWithValue("@LoaiSP", cbo_LoaiSP.Text.Trim());
                cmd.Parameters.AddWithValue("@DonVi", txt_DonVi.Text.Trim());
                cmd.Parameters.AddWithValue("@SoLuongTon", int.Parse(txt_SoLuongTon.Text));
                cmd.Parameters.AddWithValue("@GiaBan", decimal.Parse(txt_GiaBan.Text));
                cmd.Parameters.AddWithValue("@NgayCapNhat", dateTimePicker_NgayCapNhat.Value.Date);

                // Xử lý MaThuHoach (có thể null)
                if (string.IsNullOrEmpty(txt_MaThuHoach.Text))
                    cmd.Parameters.AddWithValue("@MaThuHoach", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@MaThuHoach", int.Parse(txt_MaThuHoach.Text));

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("✅ Thêm sản phẩm thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    isAdding = false;
                    LoadSanPham();
                    ClearForm();
                    SetControlsEnabled(false);
                    UpdateButtonState();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi thêm sản phẩm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        /// <summary>
        /// Cập nhật sản phẩm
        /// </summary>
        private void CapNhatSanPham()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                conn.Open();

                string query = @"UPDATE SanPham SET 
                                TenSP = @TenSP,
                                LoaiSP = @LoaiSP,
                                DonVi = @DonVi,
                                SoLuongTon = @SoLuongTon,
                                GiaBan = @GiaBan,
                                NgayCapNhat = @NgayCapNhat,
                                MaThuHoach = @MaThuHoach
                                WHERE MaSP = @MaSP";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSP", int.Parse(txt_MaSP.Text));
                cmd.Parameters.AddWithValue("@TenSP", txt_TenSP.Text.Trim());
                cmd.Parameters.AddWithValue("@LoaiSP", cbo_LoaiSP.Text.Trim());
                cmd.Parameters.AddWithValue("@DonVi", txt_DonVi.Text.Trim());
                cmd.Parameters.AddWithValue("@SoLuongTon", int.Parse(txt_SoLuongTon.Text));
                cmd.Parameters.AddWithValue("@GiaBan", decimal.Parse(txt_GiaBan.Text));
                cmd.Parameters.AddWithValue("@NgayCapNhat", dateTimePicker_NgayCapNhat.Value.Date);

                if (string.IsNullOrEmpty(txt_MaThuHoach.Text))
                    cmd.Parameters.AddWithValue("@MaThuHoach", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@MaThuHoach", int.Parse(txt_MaThuHoach.Text));

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("✅ Cập nhật sản phẩm thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    isEditing = false;
                    LoadSanPham();
                    ClearForm();
                    SetControlsEnabled(false);
                    UpdateButtonState();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi cập nhật sản phẩm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        /// <summary>
        /// Xóa sản phẩm
        /// </summary>
        private void XoaSanPham()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                conn.Open();

                // Kiểm tra ràng buộc với ChiTietGiaoDich
                string checkQuery = "SELECT COUNT(*) FROM ChiTietGiaoDich WHERE MaSP = @MaSP";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@MaSP", int.Parse(txt_MaSP.Text));
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show(
                        "❌ Không thể xóa sản phẩm này!\nSản phẩm đã có trong chi tiết giao dịch.",
                        "Lỗi ràng buộc",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Xóa sản phẩm
                string query = "DELETE FROM SanPham WHERE MaSP = @MaSP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSP", int.Parse(txt_MaSP.Text));

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("✅ Xóa sản phẩm thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadSanPham();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi xóa sản phẩm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        /// <summary>
        /// Tìm kiếm sản phẩm
        /// </summary>
        private void TimKiemSanPham()
        {
            string searchText = cbo_TimKiem.Text.Trim();

            // Nếu chọn option mặc định hoặc rỗng thì load lại tất cả
            if (string.IsNullOrEmpty(searchText) ||
                searchText == "-- Tìm theo --" ||
                searchText == "Mã sản phẩm" ||
                searchText == "Tên sản phẩm" ||
                searchText == "Loại sản phẩm")
            {
                LoadSanPham();
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                conn.Open();

                // Tìm kiếm theo tất cả các trường
                string query = @"SELECT 
                                    MaSP,
                                    TenSP,
                                    LoaiSP,
                                    DonVi,
                                    SoLuongTon,
                                    GiaBan,
                                    NgayCapNhat,
                                    MaThuHoach
                                FROM SanPham
                                WHERE CAST(MaSP AS NVARCHAR) LIKE @Search
                                   OR TenSP LIKE @Search
                                   OR LoaiSP LIKE @Search
                                ORDER BY MaSP DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Search", "%" + searchText + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dtSanPham = new DataTable();
                da.Fill(dtSanPham);

                dgv_QLSanPham.DataSource = null;
                dgv_QLSanPham.DataSource = dtSanPham;
                FormatDataGridView();

                if (dtSanPham.Rows.Count == 0)
                {
                    MessageBox.Show("🔍 Không tìm thấy sản phẩm phù hợp!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        #endregion

        #region DataGridView Events

        /// <summary>
        /// Click vào dòng trong DataGridView
        /// </summary>
        private void Dgv_QLSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgv_QLSanPham.Rows.Count)
            {
                DataGridViewRow row = dgv_QLSanPham.Rows[e.RowIndex];

                // Hiển thị dữ liệu lên form
                txt_MaSP.Text = row.Cells["MaSP"].Value?.ToString() ?? "";
                txt_TenSP.Text = row.Cells["TenSP"].Value?.ToString() ?? "";

                // Loại SP
                string loaiSP = row.Cells["LoaiSP"].Value?.ToString() ?? "";
                int index = cbo_LoaiSP.FindStringExact(loaiSP);
                if (index >= 0)
                    cbo_LoaiSP.SelectedIndex = index;
                else
                    cbo_LoaiSP.Text = loaiSP;

                txt_DonVi.Text = row.Cells["DonVi"].Value?.ToString() ?? "";
                txt_SoLuongTon.Text = row.Cells["SoLuongTon"].Value?.ToString() ?? "0";
                txt_GiaBan.Text = row.Cells["GiaBan"].Value?.ToString() ?? "0";

                // Ngày cập nhật
                if (row.Cells["NgayCapNhat"].Value != DBNull.Value && row.Cells["NgayCapNhat"].Value != null)
                {
                    dateTimePicker_NgayCapNhat.Value = Convert.ToDateTime(row.Cells["NgayCapNhat"].Value);
                }
                else
                {
                    dateTimePicker_NgayCapNhat.Value = DateTime.Now;
                }

                txt_MaThuHoach.Text = row.Cells["MaThuHoach"].Value?.ToString() ?? "";
            }
        }

        /// <summary>
        /// Nhấn Enter để tìm kiếm
        /// </summary>
        private void Cbo_TimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TimKiemSanPham();
                e.Handled = true;
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Lấy mã sản phẩm tiếp theo
        /// </summary>
        private int GetNextMaSP()
        {
            int nextId = 1;
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                conn.Open();
                string query = "SELECT ISNULL(MAX(MaSP), 0) + 1 FROM SanPham";
                SqlCommand cmd = new SqlCommand(query, conn);
                nextId = (int)cmd.ExecuteScalar();
            }
            catch { }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return nextId;
        }

        /// <summary>
        /// Validate dữ liệu nhập
        /// </summary>
        private bool ValidateInput()
        {
            // Kiểm tra tên SP
            if (string.IsNullOrWhiteSpace(txt_TenSP.Text))
            {
                MessageBox.Show("⚠️ Vui lòng nhập tên sản phẩm!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenSP.Focus();
                return false;
            }

            // Kiểm tra loại SP
            if (string.IsNullOrWhiteSpace(cbo_LoaiSP.Text))
            {
                MessageBox.Show("⚠️ Vui lòng chọn loại sản phẩm!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbo_LoaiSP.Focus();
                return false;
            }

            // Kiểm tra đơn vị
            if (string.IsNullOrWhiteSpace(txt_DonVi.Text))
            {
                MessageBox.Show("⚠️ Vui lòng nhập đơn vị!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_DonVi.Focus();
                return false;
            }

            // Kiểm tra số lượng tồn
            if (!int.TryParse(txt_SoLuongTon.Text, out int soLuong) || soLuong < 0)
            {
                MessageBox.Show("⚠️ Số lượng tồn phải là số nguyên >= 0!", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SoLuongTon.Focus();
                return false;
            }

            // Kiểm tra giá bán
            if (!decimal.TryParse(txt_GiaBan.Text, out decimal giaBan) || giaBan < 0)
            {
                MessageBox.Show("⚠️ Giá bán phải là số >= 0!", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_GiaBan.Focus();
                return false;
            }

            // Kiểm tra mã thu hoạch (nếu có)
            if (!string.IsNullOrEmpty(txt_MaThuHoach.Text))
            {
                if (!int.TryParse(txt_MaThuHoach.Text, out int maTH))
                {
                    MessageBox.Show("⚠️ Mã thu hoạch phải là số nguyên!", "Dữ liệu không hợp lệ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_MaThuHoach.Focus();
                    return false;
                }

                // Kiểm tra mã thu hoạch có tồn tại không
                if (!CheckMaThuHoachExists(maTH))
                {
                    MessageBox.Show("⚠️ Mã thu hoạch không tồn tại!", "Dữ liệu không hợp lệ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_MaThuHoach.Focus();
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Kiểm tra mã thu hoạch có tồn tại không
        /// </summary>
        private bool CheckMaThuHoachExists(int maTH)
        {
            bool exists = false;
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                conn.Open();
                string query = "SELECT COUNT(*) FROM ThuHoach WHERE MaThuHoach = @MaTH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaTH", maTH);
                exists = (int)cmd.ExecuteScalar() > 0;
            }
            catch { }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return exists;
        }

        /// <summary>
        /// Xóa form
        /// </summary>
        private void ClearForm()
        {
            txt_MaSP.Text = "";
            txt_TenSP.Text = "";
            cbo_LoaiSP.SelectedIndex = -1;
            cbo_LoaiSP.Text = "";
            txt_DonVi.Text = "";
            txt_SoLuongTon.Text = "0";
            txt_GiaBan.Text = "0";
            dateTimePicker_NgayCapNhat.Value = DateTime.Now;
            txt_MaThuHoach.Text = "";
        }

        /// <summary>
        /// Thiết lập trạng thái enabled cho các control nhập liệu
        /// </summary>
        private void SetControlsEnabled(bool enabled)
        {
            txt_TenSP.Enabled = enabled;
            cbo_LoaiSP.Enabled = enabled;
            txt_DonVi.Enabled = enabled;
            txt_SoLuongTon.Enabled = enabled;
            txt_GiaBan.Enabled = enabled;
            dateTimePicker_NgayCapNhat.Enabled = enabled;
            txt_MaThuHoach.Enabled = enabled;
        }

        /// <summary>
        /// Thiết lập trạng thái mặc định
        /// </summary>
        private void SetDefaultState()
        {
            isAdding = false;
            isEditing = false;
            SetControlsEnabled(false);
            txt_MaSP.ReadOnly = true;
            UpdateButtonState();
        }

        /// <summary>
        /// Cập nhật trạng thái các nút
        /// </summary>
        private void UpdateButtonState()
        {
            if (isAdding || isEditing)
            {
                // Đang thêm hoặc sửa
                btn_Them.Enabled = false;
                btn_Sua.Enabled = false;
                btn_Xoa.Enabled = false;
                btn_Luu.Enabled = true;
                btn_Huy.Enabled = true;
            }
            else
            {
                // Trạng thái bình thường
                btn_Them.Enabled = true;
                btn_Sua.Enabled = true;
                btn_Xoa.Enabled = true;
                btn_Luu.Enabled = false;
                btn_Huy.Enabled = false;
            }
        }

        #endregion
        /// <summary>
        /// NV4: CURSOR - Báo cáo sản phẩm sắp hết (SoLuongTon < 50)
        /// </summary>
        private void toolBaoCaoSapHet_Click(object sender, EventArgs e)
        {
            BaoCaoSanPhamSapHet();
        }

        /// <summary>
        /// Gọi Procedure sp_BaoCaoSanPhamSapHet dùng CURSOR
        /// </summary>
        private void BaoCaoSanPhamSapHet()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                conn.Open();

                // Gọi Procedure có CURSOR
                using (SqlCommand cmd = new SqlCommand("sp_BaoCaoSanPhamSapHet", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dtBaoCao = new DataTable();
                    da.Fill(dtBaoCao);

                    // Hiển thị kết quả lên DataGridView
                    dgv_QLSanPham.DataSource = null;
                    dgv_QLSanPham.DataSource = dtBaoCao;

                    // Format lại cột
                    if (dgv_QLSanPham.Columns.Count > 0)
                    {
                        dgv_QLSanPham.Columns[0].HeaderText = "Mã SP";
                        dgv_QLSanPham.Columns[1].HeaderText = "Tên Sản Phẩm";
                        dgv_QLSanPham.Columns[2].HeaderText = "Số Lượng Tồn";
                        dgv_QLSanPham.Columns[3].HeaderText = "Trạng Thái";

                        // Tô màu cảnh báo
                        dgv_QLSanPham.Columns[3].DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                        dgv_QLSanPham.Columns[3].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
                    }

                    // Thông báo kết quả
                    if (dtBaoCao.Rows.Count > 0)
                    {
                        MessageBox.Show($"⚠️ Có {dtBaoCao.Rows.Count} sản phẩm sắp hết hàng (tồn < 50)!",
                            "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("✅ Không có sản phẩm nào sắp hết hàng!",
                            "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi tạo báo cáo: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void toolStrip_ban_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn dòng trong DataGridView chưa
            if (dgv_QLSanPham.CurrentRow == null || dgv_QLSanPham.CurrentRow.Index < 0)
            {
                MessageBox.Show("⚠️ Vui lòng chọn sản phẩm cần bán!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgv_QLSanPham.CurrentRow;

            // Lấy dữ liệu an toàn từ DataGridView
            int maSP = row.Cells["MaSP"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["MaSP"].Value) : 0;
            string tenSP = row.Cells["TenSP"].Value != DBNull.Value ? row.Cells["TenSP"].Value.ToString() : "";
            string donVi = row.Cells["DonVi"].Value != DBNull.Value ? row.Cells["DonVi"].Value.ToString() : "";
            int tonKho = row.Cells["SoLuongTon"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["SoLuongTon"].Value) : 0;
            decimal giaBan = row.Cells["GiaBan"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["GiaBan"].Value) : 0;

            // Kiểm tra tồn kho
            if (tonKho <= 0)
            {
                MessageBox.Show("⚠️ Sản phẩm này đã hết hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở form bán hàng
            frmBanHang frmBan = new frmBanHang(maSP, tenSP, giaBan, tonKho, donVi);
            DialogResult result = frmBan.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadSanPham();
                ClearForm();
            }
        }
    }
}