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
                        string danhSach = "🏥 DANH SÁCH VẬT NUÔI ĐANG BỊ BỆNH:\n";
                        danhSach += "════════════════════════════════\n\n";

                        int stt = 1;
                        foreach (DataRow row in dtBenh.Rows)
                        {
                            danhSach += $"{stt}. {row["TenVat"]}\n";
                            danhSach += $"   • Mã: {row["MaVat"]}\n";
                            danhSach += $"   • Loại: {row["LoaiVat"]}\n";
                            danhSach += $"   • Số lượng: {row["SoLuong"]}\n\n";
                            stt++;
                        }

                        danhSach += "════════════════════════════════\n";
                        danhSach += "⚠️ Vui lòng kiểm tra và điều trị kịp thời!\n\n";
                        danhSach += "Bấm [Yes] để lọc danh sách vật nuôi bệnh\n";
                        danhSach += "Bấm [No] để đóng";

                        // ⭐ MESSAGEBOX VỚI 2 NÚT: YES (XEM) VÀ NO (OK)
                        DialogResult result = MessageBox.Show(
                            danhSach,
                            "⚠️ Chi tiết vật nuôi bệnh",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        // Nếu bấm YES (Xem) -> Lọc DataGridView
                        if (result == DialogResult.Yes)
                        {
                            LocVatNuoiBenh();
                        }
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
    }
}