using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Đồ_án
{
    public partial class QL_CayTrong : Form
    {
        // Connection string
        private string connectionString = @"Data Source=HUYNE;Initial Catalog=QL_TrangTraiv13;Integrated Security=True";
        private SqlConnection conn;
        private bool isAddNew = false; // Trạng thái đang thêm mới

        public QL_CayTrong()
        {
            InitializeComponent();
        }

        #region Form Load & Data Loading

        private void QL_CayTrong_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            LoadCayTrong();
            LoadComboBoxTimKiem();
            SetControlState(false);

            // Thêm event CellClick cho DataGridView
            dgv_QLCayTrong.CellClick += dgv_QLCayTrong_CellClick;
        }

        // Load danh sách cây trồng
        private void LoadCayTrong()
        {
            try
            {
                conn.Open();
                string query = "SELECT MaCay, TenCay, LoaiCay, NgayGieoTrong, KhuVuc, SanLuongDuKien FROM CayTrong ORDER BY MaCay";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgv_QLCayTrong.DataSource = dt;

                // Đặt tên cột hiển thị
                if (dgv_QLCayTrong.Columns.Count > 0)
                {
                    dgv_QLCayTrong.Columns["MaCay"].HeaderText = "Mã Cây";
                    dgv_QLCayTrong.Columns["TenCay"].HeaderText = "Tên Cây";
                    dgv_QLCayTrong.Columns["LoaiCay"].HeaderText = "Loại Cây";
                    dgv_QLCayTrong.Columns["NgayGieoTrong"].HeaderText = "Ngày Gieo Trồng";
                    dgv_QLCayTrong.Columns["KhuVuc"].HeaderText = "Khu Vực";
                    dgv_QLCayTrong.Columns["SanLuongDuKien"].HeaderText = "Sản Lượng Dự Kiến";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        // Load ComboBox tìm kiếm
        private void LoadComboBoxTimKiem()
        {
            cbo_TimKiem.Items.Clear();
            cbo_TimKiem.Items.Add("Mã cây");
            cbo_TimKiem.Items.Add("Tên cây");
            cbo_TimKiem.Items.Add("Loại cây");
            cbo_TimKiem.Items.Add("Khu vực");
            cbo_TimKiem.SelectedIndex = 0;
        }

        #endregion

        #region Control State Management

        // Set trạng thái các control
        private void SetControlState(bool isEditing)
        {
            txt_TenCay.Enabled = isEditing;
            txt_LoaiCay.Enabled = isEditing;
            txt_NgayGieoTrong.Enabled = isEditing;
            txt_KhuVuc.Enabled = isEditing;
            txt_SanLuongDuKien.Enabled = isEditing;

            btn_Luu.Enabled = isEditing;
            btn_Huy.Enabled = isEditing;

            btn_Them.Enabled = !isEditing;
            btn_Xoa.Enabled = !isEditing;
            btn_Sua.Enabled = !isEditing;

            dgv_QLCayTrong.Enabled = !isEditing;
        }

        // Xóa trắng các textbox
        private void ClearInputs()
        {
            txt_MaCay.Text = "";
            txt_TenCay.Text = "";
            txt_LoaiCay.Text = "";
            txt_NgayGieoTrong.Value = DateTime.Now;
            txt_KhuVuc.Text = "";
            txt_SanLuongDuKien.Text = "";
        }

        #endregion

        #region CRUD Operations

        // Lấy mã cây tiếp theo
        private int GetNextMaCay()
        {
            int nextId = 1;
            try
            {
                conn.Open();
                string query = "SELECT ISNULL(MAX(MaCay), 0) + 1 FROM CayTrong";
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

        // Kiểm tra dữ liệu nhập vào
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txt_TenCay.Text))
            {
                MessageBox.Show("Vui lòng nhập tên cây!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenCay.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_LoaiCay.Text))
            {
                MessageBox.Show("Vui lòng nhập loại cây!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_LoaiCay.Focus();
                return false;
            }

            if (txt_NgayGieoTrong.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày gieo trồng không được lớn hơn ngày hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_NgayGieoTrong.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txt_SanLuongDuKien.Text))
            {
                decimal sanLuong;
                if (!decimal.TryParse(txt_SanLuongDuKien.Text, out sanLuong) || sanLuong < 0)
                {
                    MessageBox.Show("Sản lượng dự kiến phải là số >= 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_SanLuongDuKien.Focus();
                    return false;
                }
            }

            return true;
        }

        // Nút Thêm
        private void btn_Them_Click(object sender, EventArgs e)
        {
            isAddNew = true;
            ClearInputs();
            txt_MaCay.Text = GetNextMaCay().ToString();
            SetControlState(true);
            txt_TenCay.Focus();
        }

        // Nút Sửa
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaCay.Text))
            {
                MessageBox.Show("Vui lòng chọn cây trồng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isAddNew = false;
            SetControlState(true);
            txt_TenCay.Focus();
        }

        // Nút Xóa
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaCay.Text))
            {
                MessageBox.Show("Vui lòng chọn cây trồng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa cây trồng này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    conn.Open();

                    // Kiểm tra ràng buộc với bảng ChiTietThuHoachCayTrong
                    string checkQuery = "SELECT COUNT(*) FROM ChiTietThuHoachCayTrong WHERE MaCay = @MaCay";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@MaCay", int.Parse(txt_MaCay.Text));
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Không thể xóa! Cây trồng này đã có chi tiết thu hoạch.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string query = "DELETE FROM CayTrong WHERE MaCay = @MaCay";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaCay", int.Parse(txt_MaCay.Text));

                    int deleteResult = cmd.ExecuteNonQuery();
                    if (deleteResult > 0)
                    {
                        MessageBox.Show("Xóa cây trồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCayTrong();
                        ClearInputs();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa cây trồng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        // Nút Lưu
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                conn.Open();

                if (isAddNew)
                {
                    // Thêm mới
                    string query = @"INSERT INTO CayTrong (MaCay, TenCay, LoaiCay, NgayGieoTrong, KhuVuc, SanLuongDuKien)
                                    VALUES (@MaCay, @TenCay, @LoaiCay, @NgayGieoTrong, @KhuVuc, @SanLuongDuKien)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaCay", int.Parse(txt_MaCay.Text));
                    cmd.Parameters.AddWithValue("@TenCay", txt_TenCay.Text.Trim());
                    cmd.Parameters.AddWithValue("@LoaiCay", txt_LoaiCay.Text.Trim());
                    cmd.Parameters.AddWithValue("@NgayGieoTrong", txt_NgayGieoTrong.Value.Date);
                    cmd.Parameters.AddWithValue("@KhuVuc", string.IsNullOrWhiteSpace(txt_KhuVuc.Text) ? DBNull.Value : (object)txt_KhuVuc.Text.Trim());
                    cmd.Parameters.AddWithValue("@SanLuongDuKien", string.IsNullOrWhiteSpace(txt_SanLuongDuKien.Text) ? DBNull.Value : (object)decimal.Parse(txt_SanLuongDuKien.Text));

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Thêm cây trồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Cập nhật
                    string query = @"UPDATE CayTrong 
                                    SET TenCay = @TenCay, 
                                        LoaiCay = @LoaiCay, 
                                        NgayGieoTrong = @NgayGieoTrong, 
                                        KhuVuc = @KhuVuc, 
                                        SanLuongDuKien = @SanLuongDuKien
                                    WHERE MaCay = @MaCay";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaCay", int.Parse(txt_MaCay.Text));
                    cmd.Parameters.AddWithValue("@TenCay", txt_TenCay.Text.Trim());
                    cmd.Parameters.AddWithValue("@LoaiCay", txt_LoaiCay.Text.Trim());
                    cmd.Parameters.AddWithValue("@NgayGieoTrong", txt_NgayGieoTrong.Value.Date);
                    cmd.Parameters.AddWithValue("@KhuVuc", string.IsNullOrWhiteSpace(txt_KhuVuc.Text) ? DBNull.Value : (object)txt_KhuVuc.Text.Trim());
                    cmd.Parameters.AddWithValue("@SanLuongDuKien", string.IsNullOrWhiteSpace(txt_SanLuongDuKien.Text) ? DBNull.Value : (object)decimal.Parse(txt_SanLuongDuKien.Text));

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật cây trồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LoadCayTrong();
                SetControlState(false);
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        // Nút Hủy
        private void btn_Huy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy thao tác?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SetControlState(false);
                ClearInputs();
                isAddNew = false;
            }
        }

        #endregion

        #region Search

        // Nút Tìm kiếm
        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            // Lấy text tìm kiếm - sửa lại nếu bạn có TextBox riêng
            // Ví dụ: string searchText = txt_TimKiem.Text;
            string searchText = cbo_TimKiem.Text;

            // Kiểm tra nếu text là một trong các item của combobox thì không tìm
            if (cbo_TimKiem.Items.Contains(searchText))
            {
                LoadCayTrong();
                return;
            }

            TimKiem(searchText);
        }

        // Tìm kiếm với TextBox riêng (nếu có)
        private void TimKiem(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadCayTrong();
                return;
            }

            try
            {
                conn.Open();
                string searchField = "";
                switch (cbo_TimKiem.SelectedIndex)
                {
                    case 0: searchField = "MaCay"; break;
                    case 1: searchField = "TenCay"; break;
                    case 2: searchField = "LoaiCay"; break;
                    case 3: searchField = "KhuVuc"; break;
                    default: searchField = "TenCay"; break;
                }

                string query = $@"SELECT MaCay, TenCay, LoaiCay, NgayGieoTrong, KhuVuc, SanLuongDuKien 
                                FROM CayTrong 
                                WHERE CAST({searchField} AS NVARCHAR(MAX)) LIKE @SearchText
                                ORDER BY MaCay";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgv_QLCayTrong.DataSource = dt;

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

        private void cbo_TimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Có thể để trống hoặc thêm logic nếu cần
        }

        #endregion

        #region DataGridView Events

        // Click vào dòng trong DataGridView
        private void dgv_QLCayTrong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_QLCayTrong.Rows[e.RowIndex];

                txt_MaCay.Text = row.Cells["MaCay"].Value.ToString();
                txt_TenCay.Text = row.Cells["TenCay"].Value?.ToString() ?? "";
                txt_LoaiCay.Text = row.Cells["LoaiCay"].Value?.ToString() ?? "";

                if (row.Cells["NgayGieoTrong"].Value != DBNull.Value)
                {
                    txt_NgayGieoTrong.Value = Convert.ToDateTime(row.Cells["NgayGieoTrong"].Value);
                }

                txt_KhuVuc.Text = row.Cells["KhuVuc"].Value?.ToString() ?? "";
                txt_SanLuongDuKien.Text = row.Cells["SanLuongDuKien"].Value?.ToString() ?? "";
            }
        }

        // Event CellContentClick (đã có trong Designer)
        private void dgv_QLCayTrong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Có thể để trống hoặc gọi CellClick
        }

        #endregion

        #region Other Events

        // Nút Thoát
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Các event TextChanged (có thể để trống hoặc thêm validation)
        private void txt_MaCay_TextChanged(object sender, EventArgs e)
        {
            // Mã cây không cho sửa
        }

        private void txt_NgayGieoTrong_ValueChanged(object sender, EventArgs e)
        {
            // Có thể thêm validation
        }

        private void txt_TenCay_TextChanged(object sender, EventArgs e)
        {
            // Có thể thêm validation
        }

        private void txt_KhuVuc_TextChanged(object sender, EventArgs e)
        {
            // Có thể thêm validation
        }

        private void txt_LoaiCay_TextChanged(object sender, EventArgs e)
        {
            // Có thể thêm validation
        }

        private void txt_SanLuongDuKien_TextChanged(object sender, EventArgs e)
        {
            // Có thể thêm validation chỉ cho nhập số
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // Nếu đây là nút refresh
            LoadCayTrong();
            ClearInputs();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Để trống
        }

        #endregion

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cayTrongBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}