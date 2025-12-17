using QL_TrangTrai;
using QuanLyTrangTrai;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Đồ_án
{
    public partial class QL_VatNuoi : Form
    {
        // Connection string - điều chỉnh theo cấu hình của bạn
        private string connectionString = @"Data Source=HUYNE;Initial Catalog=QL_TrangTraiv13;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter da;
        private DataTable dt;
        private bool isAdding = false;
        private bool isEditing = false;
        private bool isFiltered = false; // Đang lọc vật nuôi bệnh hay không

        // Trong QL_VatNuoi.cs - thêm fields
        private int _maNguoiDung = 0;
        private int _maVaiTro = 1;

        // Thêm constructor mới
        public QL_VatNuoi(int maNguoiDung, int maVaiTro)
        {
            InitializeComponent();
            _maNguoiDung = maNguoiDung;
            _maVaiTro = maVaiTro;
        }

        public QL_VatNuoi()
        {
            InitializeComponent();
        }

        private void QL_VatNuoi_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadComboBoxTimKiem();
            SetControlState(false);

            // Kiểm tra cảnh báo vật nuôi bệnh khi mở form
            KiemTraVatNuoiBenh();

            // Đăng ký sự kiện
            dgv_QLVatNuoi.SelectionChanged += dgv_QLVatNuoi_SelectionChanged;
            btn_Them.Click += btn_Them_Click;
            btn_Xoa.Click += btn_Xoa_Click;
            btn_Sua.Click += btn_Sua_Click;
            btn_Luu.Click += btn_Luu_Click;
            btn_Huy.Click += btn_Huy_Click;
            btn_TimKiem.Click += btn_TimKiem_Click;
            btn_Thoat.Click += btn_Thoat_Click;
        }

        #region Load Data
        private void LoadData()
        {
            try
            {
                conn = new SqlConnection(connectionString);
                string query = "SELECT MaVat, TenVat, LoaiVat, SoLuong, TinhTrangSucKhoe FROM VatNuoi";
                da = new SqlDataAdapter(query, conn);
                dt = new DataTable();
                da.Fill(dt);

                // Xóa AutoGenerateColumns nếu đang dùng BindingSource từ Designer
                dgv_QLVatNuoi.AutoGenerateColumns = true;
                dgv_QLVatNuoi.DataSource = null;
                dgv_QLVatNuoi.DataSource = dt;

                // Đặt tên cột hiển thị - kiểm tra null trước
                FormatDataGridView();

                // Reset trạng thái lọc
                isFiltered = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            if (dgv_QLVatNuoi.Columns.Count > 0)
            {
                if (dgv_QLVatNuoi.Columns["MaVat"] != null)
                    dgv_QLVatNuoi.Columns["MaVat"].HeaderText = "Mã Vật";
                if (dgv_QLVatNuoi.Columns["TenVat"] != null)
                    dgv_QLVatNuoi.Columns["TenVat"].HeaderText = "Tên Vật";
                if (dgv_QLVatNuoi.Columns["LoaiVat"] != null)
                    dgv_QLVatNuoi.Columns["LoaiVat"].HeaderText = "Loại Vật";
                if (dgv_QLVatNuoi.Columns["SoLuong"] != null)
                    dgv_QLVatNuoi.Columns["SoLuong"].HeaderText = "Số Lượng";
                if (dgv_QLVatNuoi.Columns["TinhTrangSucKhoe"] != null)
                    dgv_QLVatNuoi.Columns["TinhTrangSucKhoe"].HeaderText = "Tình Trạng Sức Khỏe";
            }
        }

        private void LoadComboBoxTimKiem()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT TenVat FROM VatNuoi";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    cbo_TimKiem.Items.Clear();
                    cbo_TimKiem.Items.Add("-- Tất cả --");
                    while (reader.Read())
                    {
                        cbo_TimKiem.Items.Add(reader["TenVat"].ToString());
                    }
                    cbo_TimKiem.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Hiển thị dữ liệu lên TextBox
        private void dgv_QLVatNuoi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_QLVatNuoi.CurrentRow != null && !isAdding)
            {
                DataGridViewRow row = dgv_QLVatNuoi.CurrentRow;
                txt_MaVat.Text = row.Cells["MaVat"].Value?.ToString() ?? "";
                txt_TenVat.Text = row.Cells["TenVat"].Value?.ToString() ?? "";
                txt_LoaiVat.Text = row.Cells["LoaiVat"].Value?.ToString() ?? "";
                txt_SoLuong.Text = row.Cells["SoLuong"].Value?.ToString() ?? "";

                string tinhTrang = row.Cells["TinhTrangSucKhoe"].Value?.ToString() ?? "";
                int index = txt_TinhTrangSucKhoe.FindStringExact(tinhTrang);
                txt_TinhTrangSucKhoe.SelectedIndex = index >= 0 ? index : -1;
            }
        }
        #endregion

        #region Trạng thái Controls
        private void SetControlState(bool enabled)
        {
            txt_TenVat.Enabled = enabled;
            txt_LoaiVat.Enabled = enabled;
            txt_SoLuong.Enabled = enabled;
            txt_TinhTrangSucKhoe.Enabled = enabled;

            btn_Luu.Enabled = enabled;
            btn_Huy.Enabled = enabled;

            btn_Them.Enabled = !enabled;
            btn_Xoa.Enabled = !enabled;
            btn_Sua.Enabled = !enabled;

            // Mã vật luôn không cho sửa khi edit, chỉ hiển thị khi thêm mới
            txt_MaVat.Enabled = isAdding;
        }

        private void ClearInputs()
        {
            txt_MaVat.Clear();
            txt_TenVat.Clear();
            txt_LoaiVat.Clear();
            txt_SoLuong.Clear();
            txt_TinhTrangSucKhoe.SelectedIndex = -1;
        }
        #endregion

        #region Nút Thêm
        private void btn_Them_Click(object sender, EventArgs e)
        {
            isAdding = true;
            isEditing = false;
            ClearInputs();
            SetControlState(true);

            // Tự động tạo mã mới
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT ISNULL(MAX(MaVat), 0) + 1 FROM VatNuoi";
                    SqlCommand cmd = new SqlCommand(query, con);
                    int newId = Convert.ToInt32(cmd.ExecuteScalar());
                    txt_MaVat.Text = newId.ToString();
                    txt_MaVat.Enabled = false; // Không cho sửa mã tự động
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo mã mới: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txt_TenVat.Focus();
        }
        #endregion

        #region Nút Sửa
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (dgv_QLVatNuoi.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isAdding = false;
            isEditing = true;
            SetControlState(true);
            txt_MaVat.Enabled = false; // Không cho sửa mã
            txt_TenVat.Focus();
        }
        #endregion

        #region Nút Xóa
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dgv_QLVatNuoi.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maVat = txt_MaVat.Text;
            string tenVat = txt_TenVat.Text;

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa vật nuôi '{tenVat}' (Mã: {maVat})?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        // Kiểm tra xem có dữ liệu liên quan không
                        string checkQuery = "SELECT COUNT(*) FROM ChiTietThuHoachVatNuoi WHERE MaVat = @MaVat";
                        SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                        checkCmd.Parameters.AddWithValue("@MaVat", maVat);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Không thể xóa vì vật nuôi này có dữ liệu thu hoạch liên quan!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Thực hiện xóa
                        string deleteQuery = "DELETE FROM VatNuoi WHERE MaVat = @MaVat";
                        SqlCommand cmd = new SqlCommand(deleteQuery, con);
                        cmd.Parameters.AddWithValue("@MaVat", maVat);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            LoadComboBoxTimKiem();
                            ClearInputs();
                            KiemTraVatNuoiBenh(); // Cập nhật lại cảnh báo
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Nút Lưu
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            // Validate dữ liệu
            if (!ValidateInput())
                return;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd;

                    if (isAdding)
                    {
                        // Thêm mới
                        string insertQuery = @"INSERT INTO VatNuoi (MaVat, TenVat, LoaiVat, SoLuong, TinhTrangSucKhoe) 
                                              VALUES (@MaVat, @TenVat, @LoaiVat, @SoLuong, @TinhTrangSucKhoe)";
                        cmd = new SqlCommand(insertQuery, con);
                    }
                    else
                    {
                        // Cập nhật
                        string updateQuery = @"UPDATE VatNuoi 
                                              SET TenVat = @TenVat, 
                                                  LoaiVat = @LoaiVat, 
                                                  SoLuong = @SoLuong, 
                                                  TinhTrangSucKhoe = @TinhTrangSucKhoe 
                                              WHERE MaVat = @MaVat";
                        cmd = new SqlCommand(updateQuery, con);
                    }

                    cmd.Parameters.AddWithValue("@MaVat", int.Parse(txt_MaVat.Text));
                    cmd.Parameters.AddWithValue("@TenVat", txt_TenVat.Text.Trim());
                    cmd.Parameters.AddWithValue("@LoaiVat", txt_LoaiVat.Text.Trim());
                    cmd.Parameters.AddWithValue("@SoLuong", int.Parse(txt_SoLuong.Text));
                    cmd.Parameters.AddWithValue("@TinhTrangSucKhoe", txt_TinhTrangSucKhoe.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        string message = isAdding ? "Thêm mới thành công!" : "Cập nhật thành công!";
                        MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadData();
                        LoadComboBoxTimKiem();
                        isAdding = false;
                        isEditing = false;
                        SetControlState(false);

                        // ⭐ KIỂM TRA CẢNH BÁO BỆNH SAU KHI LƯU
                        KiemTraVatNuoiBenh();

                        // ⭐ KIỂM TRA LOG CẢNH BÁO TỪ TRIGGER
                        KiemTraLogCanhBao();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txt_MaVat.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã vật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaVat.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_TenVat.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên vật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenVat.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_LoaiVat.Text))
            {
                MessageBox.Show("Vui lòng nhập Loại vật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_LoaiVat.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_SoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập Số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SoLuong.Focus();
                return false;
            }

            if (!int.TryParse(txt_SoLuong.Text, out int soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên không âm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SoLuong.Focus();
                return false;
            }

            if (txt_TinhTrangSucKhoe.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn Tình trạng sức khỏe!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TinhTrangSucKhoe.Focus();
                return false;
            }

            return true;
        }
        #endregion

        #region Nút Hủy
        private void btn_Huy_Click(object sender, EventArgs e)
        {
            isAdding = false;
            isEditing = false;
            SetControlState(false);

            // Hiển thị lại dữ liệu từ dòng đang chọn
            if (dgv_QLVatNuoi.CurrentRow != null)
            {
                dgv_QLVatNuoi_SelectionChanged(sender, e);
            }
            else
            {
                ClearInputs();
            }
        }
        #endregion

        #region Nút Tìm Kiếm
        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = cbo_TimKiem.Text.Trim();

                if (string.IsNullOrEmpty(searchText) || searchText == "-- Tất cả --")
                {
                    LoadData();
                    KiemTraVatNuoiBenh(); // Cập nhật lại cảnh báo
                    return;
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"SELECT MaVat, TenVat, LoaiVat, SoLuong, TinhTrangSucKhoe 
                                    FROM VatNuoi 
                                    WHERE TenVat LIKE @SearchText 
                                       OR LoaiVat LIKE @SearchText
                                       OR TinhTrangSucKhoe LIKE @SearchText";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    adapter.SelectCommand.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                    DataTable searchResult = new DataTable();
                    adapter.Fill(searchResult);

                    dgv_QLVatNuoi.DataSource = searchResult;

                    if (searchResult.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Nút Thoát
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        #endregion

        #region Cảnh báo vật nuôi bệnh

        /// <summary>
        /// Kiểm tra và hiển thị cảnh báo vật nuôi bệnh trên ToolStripLabel
        /// </summary>
        private void KiemTraVatNuoiBenh()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Đếm số vật nuôi bị bệnh
                    string sql = "SELECT COUNT(*) FROM VatNuoi WHERE TinhTrangSucKhoe = N'Bệnh'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    int soBenh = (int)cmd.ExecuteScalar();

                    if (soBenh > 0)
                    {
                        // Có vật nuôi bệnh - hiển thị cảnh báo
                        Thongbao_label.Text = $"⚠️ CẢNH BÁO: Có {soBenh} vật nuôi đang bị bệnh!";
                        Thongbao_label.ForeColor = Color.Red;
                        Thongbao_label.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                        Thongbao_label.Visible = true;
                        isFiltered = false;
                    }
                    else
                    {
                        // Không có vật nuôi bệnh
                        Thongbao_label.Text = "✅ Tất cả vật nuôi đều khỏe mạnh!";
                        Thongbao_label.ForeColor = Color.Green;
                        Thongbao_label.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                        Thongbao_label.Visible = true;
                        isFiltered = false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Ẩn label nếu có lỗi
                Thongbao_label.Visible = false;
            }
        }

        /// <summary>
        /// Kiểm tra Log cảnh báo từ Trigger (sau khi cập nhật)
        /// </summary>
        private void KiemTraLogCanhBao()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Lấy cảnh báo mới nhất (trong 1 phút gần đây)
                    string sql = @"SELECT NoiDung, NgayGhi 
                                  FROM LogCanhBao 
                                  WHERE NgayGhi >= DATEADD(MINUTE, -1, GETDATE())
                                  ORDER BY NgayGhi DESC";

                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataTable dtLog = new DataTable();
                    da.Fill(dtLog);

                    if (dtLog.Rows.Count > 0)
                    {
                        string canhBao = "🚨 CẢNH BÁO TỪ HỆ THỐNG:\n";
                        canhBao += "════════════════════════════════\n\n";

                        foreach (DataRow row in dtLog.Rows)
                        {
                            canhBao += "• " + row["NoiDung"].ToString() + "\n";
                        }

                        canhBao += "\n════════════════════════════════\n";
                        canhBao += "⚠️ Vui lòng kiểm tra và điều trị kịp thời!";

                        MessageBox.Show(canhBao, "⚠️ Cảnh báo vật nuôi bệnh",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                // Bỏ qua lỗi kiểm tra log
            }
        }

        /// <summary>
        /// Click vào ToolStripLabel cảnh báo để lọc/hiện tất cả vật nuôi
        /// </summary>
        private void Thongbao_label_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isFiltered)
                {
                    // Đang hiện tất cả -> Lọc chỉ hiện vật nuôi bệnh
                    LocVatNuoiBenh();
                }
                else
                {
                    // Đang lọc -> Hiện lại tất cả
                    LoadData();
                    KiemTraVatNuoiBenh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Lọc DataGridView chỉ hiện vật nuôi bệnh
        /// </summary>
        private void LocVatNuoiBenh()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Lọc chỉ lấy vật nuôi bệnh
                    string sql = @"SELECT MaVat, TenVat, LoaiVat, SoLuong, TinhTrangSucKhoe 
                                  FROM VatNuoi 
                                  WHERE TinhTrangSucKhoe = N'Bệnh'";

                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    DataTable dtBenh = new DataTable();
                    adapter.Fill(dtBenh);

                    if (dtBenh.Rows.Count > 0)
                    {
                        // Hiển thị lên DataGridView
                        dgv_QLVatNuoi.DataSource = null;
                        dgv_QLVatNuoi.DataSource = dtBenh;

                        // Format lại cột
                        FormatDataGridView();

                        // Tô màu dòng bệnh
                        foreach (DataGridViewRow row in dgv_QLVatNuoi.Rows)
                        {
                            row.DefaultCellStyle.BackColor = Color.LightPink;
                            row.DefaultCellStyle.ForeColor = Color.DarkRed;
                        }

                        // Đổi text label
                        Thongbao_label.Text = $"🔍 Đang lọc: {dtBenh.Rows.Count} vật nuôi bệnh [Click để xem tất cả]";
                        Thongbao_label.ForeColor = Color.DarkOrange;
                        isFiltered = true;
                    }
                    else
                    {
                        MessageBox.Show("Không có vật nuôi nào bị bệnh!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nút Xem cảnh báo trên ToolStrip - Hiện MessageBox với 2 nút OK và XEM
        /// </summary>
        #region Báo cáo tình trạng vật nuôi (có Cursor trong SP)

        /// <summary>
        /// Hiển thị báo cáo tổng hợp tình trạng vật nuôi (gọi SP có cursor)
        /// </summary>
        private void HienThiBaoCaoTinhTrang()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // ⭐ GỌI STORED PROCEDURE CÓ CURSOR
                    SqlCommand cmd = new SqlCommand("sp_KiemTraTinhTrangVatNuoi", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dtBaoCao = new DataTable();
                    da.Fill(dtBaoCao);

                    if (dtBaoCao.Rows.Count > 0)
                    {
                        // Tạo form báo cáo
                        Form frmBaoCao = new Form();
                        frmBaoCao.Text = "📊 Báo cáo tình trạng vật nuôi (Cursor)";
                        frmBaoCao.Size = new Size(900, 600);
                        frmBaoCao.StartPosition = FormStartPosition.CenterParent;

                        // Panel header
                        Panel pnlHeader = new Panel();
                        pnlHeader.Dock = DockStyle.Top;
                        pnlHeader.Height = 60;
                        pnlHeader.BackColor = Color.FromArgb(41, 128, 185);

                        Label lblTitle = new Label();
                        lblTitle.Dock = DockStyle.Fill;
                        lblTitle.Text = "📊 BÁO CÁO TỔNG HỢP TÌNH TRẠNG VẬT NUÔI";
                        lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                        lblTitle.ForeColor = Color.White;
                        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
                        pnlHeader.Controls.Add(lblTitle);

                        // DataGridView hiển thị báo cáo
                        DataGridView dgvBaoCao = new DataGridView();
                        dgvBaoCao.Dock = DockStyle.Fill;
                        dgvBaoCao.DataSource = dtBaoCao;
                        dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvBaoCao.ReadOnly = true;
                        dgvBaoCao.AllowUserToAddRows = false;
                        dgvBaoCao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvBaoCao.RowHeadersVisible = false;
                        dgvBaoCao.BackgroundColor = Color.White;
                        dgvBaoCao.BorderStyle = BorderStyle.None;
                        dgvBaoCao.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
                        dgvBaoCao.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        dgvBaoCao.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                        dgvBaoCao.ColumnHeadersHeight = 35;
                        dgvBaoCao.EnableHeadersVisualStyles = false;

                        // Tô màu các cột
                        dgvBaoCao.DataBindingComplete += (s, ev) =>
                        {
                            foreach (DataGridViewRow row in dgvBaoCao.Rows)
                            {
                                row.Height = 30;

                                // Tô màu cột "Bệnh"
                                if (Convert.ToInt32(row.Cells["Bệnh"].Value) > 0)
                                {
                                    row.Cells["Bệnh"].Style.BackColor = Color.FromArgb(231, 76, 60);
                                    row.Cells["Bệnh"].Style.ForeColor = Color.White;
                                    row.Cells["Bệnh"].Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                                }

                                // Tô màu cột "Tốt"
                                row.Cells["Tốt"].Style.BackColor = Color.FromArgb(46, 204, 113);
                                row.Cells["Tốt"].Style.ForeColor = Color.White;
                                row.Cells["Tốt"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

                                // Tô màu cột "Yếu"
                                if (Convert.ToInt32(row.Cells["Yếu"].Value) > 0)
                                {
                                    row.Cells["Yếu"].Style.BackColor = Color.FromArgb(241, 196, 15);
                                    row.Cells["Yếu"].Style.ForeColor = Color.White;
                                }

                                // Tô màu cột "Trung bình"
                                row.Cells["Trung bình"].Style.BackColor = Color.FromArgb(52, 152, 219);
                                row.Cells["Trung bình"].Style.ForeColor = Color.White;
                            }
                        };

                        // Panel tổng kết
                        Panel pnlSummary = new Panel();
                        pnlSummary.Dock = DockStyle.Bottom;
                        pnlSummary.Height = 100;
                        pnlSummary.BackColor = Color.FromArgb(236, 240, 241);
                        pnlSummary.Padding = new Padding(20);

                        // Tính tổng
                        int tongTatCa = 0, tongTot = 0, tongTB = 0, tongYeu = 0, tongBenh = 0;
                        foreach (DataRow row in dtBaoCao.Rows)
                        {
                            tongTatCa += Convert.ToInt32(row["Tổng SL"]);
                            tongTot += Convert.ToInt32(row["Tốt"]);
                            tongTB += Convert.ToInt32(row["Trung bình"]);
                            tongYeu += Convert.ToInt32(row["Yếu"]);
                            tongBenh += Convert.ToInt32(row["Bệnh"]);
                        }

                        double tyLeBenh = tongTatCa > 0 ? (tongBenh * 100.0 / tongTatCa) : 0;

                        Label lblSummary = new Label();
                        lblSummary.Dock = DockStyle.Fill;
                        lblSummary.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                        lblSummary.Text = $"📊 TỔNG KẾT: {tongTatCa} con | " +
                                         $"✅ Tốt: {tongTot} | 🔵 TB: {tongTB} | " +
                                         $"⚠️ Yếu: {tongYeu} | 🔴 Bệnh: {tongBenh} ({tyLeBenh:0.00}%)";

                        if (tyLeBenh > 10)
                        {
                            lblSummary.ForeColor = Color.FromArgb(192, 57, 43);
                            lblSummary.Text += "\n⚠️ CẢNH BÁO: Tỷ lệ bệnh cao!";
                        }
                        else
                        {
                            lblSummary.ForeColor = Color.FromArgb(44, 62, 80);
                        }

                        pnlSummary.Controls.Add(lblSummary);

                        // Thêm controls
                        frmBaoCao.Controls.Add(dgvBaoCao);
                        frmBaoCao.Controls.Add(pnlSummary);
                        frmBaoCao.Controls.Add(pnlHeader);

                        frmBaoCao.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nút "Báo cáo tổng hợp" trên ToolStrip
        /// </summary>
        private void toolStrip_BaoCao_Click(object sender, EventArgs e)
        {
            HienThiBaoCaoTinhTrang();
        }

        #endregion

        // ═══════════════════════════════════════════════════════════
        // PHẦN 2: XEM CHI TIẾT VẬT NUÔI BỆNH (CẢI TIẾN TỪ CODE CŨ)
        // ═══════════════════════════════════════════════════════════

        #region Xem chi tiết vật nuôi bệnh (Query thông thường)

        /// <summary>
        /// Xem chi tiết vật nuôi bệnh - PHIÊN BẢN CẢI TIẾN
        /// Giữ logic của bạn + thêm form hiển thị đẹp hơn
        /// </summary>
        private void toolStrip_XemCanhBao_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Lấy danh sách vật nuôi bệnh
                    string sql = "SELECT MaVat, TenVat, LoaiVat, SoLuong FROM VatNuoi WHERE TinhTrangSucKhoe = N'Bệnh'";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    DataTable dtBenh = new DataTable();
                    adapter.Fill(dtBenh);

                    if (dtBenh.Rows.Count > 0)
                    {
                        // Tạo form hiển thị danh sách bệnh
                        Form frmCanhBao = new Form();
                        frmCanhBao.Text = "⚠️ Chi tiết vật nuôi bệnh";
                        frmCanhBao.Size = new Size(700, 500);
                        frmCanhBao.StartPosition = FormStartPosition.CenterParent;

                        // Panel header
                        Panel pnlHeader = new Panel();
                        pnlHeader.Dock = DockStyle.Top;
                        pnlHeader.Height = 60;
                        pnlHeader.BackColor = Color.FromArgb(231, 76, 60);

                        Label lblTitle = new Label();
                        lblTitle.Dock = DockStyle.Fill;
                        lblTitle.Text = $"⚠️ CẢNH BÁO: {dtBenh.Rows.Count} VẬT NUÔI BỊ BỆNH";
                        lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
                        lblTitle.ForeColor = Color.White;
                        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
                        pnlHeader.Controls.Add(lblTitle);

                        // DataGridView hiển thị danh sách
                        DataGridView dgvBenh = new DataGridView();
                        dgvBenh.Dock = DockStyle.Fill;
                        dgvBenh.DataSource = dtBenh;
                        dgvBenh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvBenh.ReadOnly = true;
                        dgvBenh.AllowUserToAddRows = false;
                        dgvBenh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvBenh.RowHeadersVisible = false;
                        dgvBenh.BackgroundColor = Color.White;
                        dgvBenh.BorderStyle = BorderStyle.None;
                        dgvBenh.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 57, 43);
                        dgvBenh.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        dgvBenh.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                        dgvBenh.ColumnHeadersHeight = 35;
                        dgvBenh.EnableHeadersVisualStyles = false;

                        // Đổi tên cột
                        dgvBenh.DataBindingComplete += (s, ev) =>
                        {
                            dgvBenh.Columns["MaVat"].HeaderText = "Mã";
                            dgvBenh.Columns["TenVat"].HeaderText = "Tên vật nuôi";
                            dgvBenh.Columns["LoaiVat"].HeaderText = "Loại";
                            dgvBenh.Columns["SoLuong"].HeaderText = "Số lượng";

                            foreach (DataGridViewRow row in dgvBenh.Rows)
                            {
                                row.Height = 30;
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 76, 60);
                            }
                        };

                        // Panel footer với 2 nút
                        Panel pnlFooter = new Panel();
                        pnlFooter.Dock = DockStyle.Bottom;
                        pnlFooter.Height = 80;
                        pnlFooter.BackColor = Color.FromArgb(236, 240, 241);

                        Button btnLocBenh = new Button();
                        btnLocBenh.Text = "🔍 Lọc vật nuôi bệnh";
                        btnLocBenh.Size = new Size(180, 40);
                        btnLocBenh.Location = new Point(150, 20);
                        btnLocBenh.BackColor = Color.FromArgb(52, 152, 219);
                        btnLocBenh.ForeColor = Color.White;
                        btnLocBenh.FlatStyle = FlatStyle.Flat;
                        btnLocBenh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                        btnLocBenh.Cursor = Cursors.Hand;
                        btnLocBenh.Click += (s, ev) =>
                        {
                            frmCanhBao.Close();
                            LocVatNuoiBenh();
                        };

                        Button btnDong = new Button();
                        btnDong.Text = "✖ Đóng";
                        btnDong.Size = new Size(120, 40);
                        btnDong.Location = new Point(350, 20);
                        btnDong.BackColor = Color.FromArgb(149, 165, 166);
                        btnDong.ForeColor = Color.White;
                        btnDong.FlatStyle = FlatStyle.Flat;
                        btnDong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                        btnDong.Cursor = Cursors.Hand;
                        btnDong.Click += (s, ev) => frmCanhBao.Close();

                        pnlFooter.Controls.Add(btnLocBenh);
                        pnlFooter.Controls.Add(btnDong);

                        // Thêm controls
                        frmCanhBao.Controls.Add(dgvBenh);
                        frmCanhBao.Controls.Add(pnlFooter);
                        frmCanhBao.Controls.Add(pnlHeader);

                        frmCanhBao.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("✅ Tất cả vật nuôi đều khỏe mạnh!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // Tìm form cha (GiaoDien) thông qua Parent
            Form parentForm = this.ParentForm;

            // Nếu form được nhúng trong panel, cần tìm khác
            if (parentForm == null)
            {
                Control parent = this.Parent;
                while (parent != null)
                {
                    if (parent is Form)
                    {
                        parentForm = parent as Form;
                        break;
                    }
                    parent = parent.Parent;
                }
            }

            GiaoDien mainForm = parentForm as GiaoDien;

            if (mainForm != null)
            {
                mainForm.OpenFormInPanel(new frmChiTietThuHoachVatNuoi(mainForm.MaNguoiDung, mainForm.MaVaiTro));
            }
            else
            {
                MessageBox.Show("Không thể xác định thông tin đăng nhập!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}