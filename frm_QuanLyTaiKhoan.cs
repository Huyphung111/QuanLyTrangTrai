using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyTrangTrai
{
    public partial class frm_QuanLyTaiKhoan : Form
    {
        // Chuỗi kết nối - thay đổi theo máy của bạn
        private string connectionString = @"Data Source=HUYNE;Initial Catalog=QL_TrangTraiv13;Integrated Security=True";

        public frm_QuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        #region SỰ KIỆN FORM LOAD
        private void frm_QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadVaiTro();
            LoadDanhSachTaiKhoan();
            cbo_ChucVu.SelectedIndex = 0;
        }
        #endregion

        #region LOAD DỮ LIỆU

        // Load danh sách vai trò vào ComboBox
        private void LoadVaiTro()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MaVaiTro, TenVaiTro FROM VaiTro";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbo_VaiTro.DataSource = dt;
                    cbo_VaiTro.DisplayMember = "TenVaiTro";
                    cbo_VaiTro.ValueMember = "MaVaiTro";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load vai trò: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load danh sách tài khoản lên DataGridView
        private void LoadDanhSachTaiKhoan()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            nv.MaNV,
                            nv.HoTen,
                            nv.GioiTinh,
                            CONVERT(VARCHAR(10), nv.NgaySinh, 103) AS NgaySinh,
                            nv.SoDienThoai,
                            nd.Email,
                            nv.ChucVu,
                            vt.TenVaiTro,
                            dn.TenDangNhap,
                            nd.MaNguoiDung,
                            nd.MaVaiTro
                        FROM NhanVien nv
                        INNER JOIN NguoiDung nd ON nv.MaNguoiDung = nd.MaNguoiDung
                        INNER JOIN VaiTro vt ON nd.MaVaiTro = vt.MaVaiTro
                        LEFT JOIN DangNhap dn ON nd.MaNguoiDung = dn.MaNguoiDung
                        ORDER BY nv.MaNV";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Thêm cột STT
                    dgv_DanhSachTaiKhoan.DataSource = dt;

                    // Đánh số thứ tự
                    for (int i = 0; i < dgv_DanhSachTaiKhoan.Rows.Count; i++)
                    {
                        dgv_DanhSachTaiKhoan.Rows[i].Cells["STT"].Value = i + 1;
                    }

                    // Cập nhật tổng số tài khoản
                    lbl_TongSoTaiKhoan.Text = $"📌 Tổng số tài khoản: {dt.Rows.Count}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region XỬ LÝ SỰ KIỆN CELL CLICK
        private void dgv_DanhSachTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_DanhSachTaiKhoan.Rows[e.RowIndex];

                // Hiển thị thông tin lên form
                txt_HoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? "";

                // Giới tính
                string gioiTinh = row.Cells["GioiTinh"].Value?.ToString() ?? "";
                if (gioiTinh == "Nam") rb_Nam.Checked = true;
                else if (gioiTinh == "Nữ") rb_Nu.Checked = true;
                else rb_Khac.Checked = true;

                // Ngày sinh
                string ngaySinh = row.Cells["NgaySinh"].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(ngaySinh))
                {
                    dtp_NgaySinh.Value = DateTime.ParseExact(ngaySinh, "dd/MM/yyyy", null);
                }

                txt_SoDienThoai.Text = row.Cells["SoDienThoai"].Value?.ToString() ?? "";
                txt_Email.Text = row.Cells["Email"].Value?.ToString() ?? "";

                // Load địa chỉ từ database
                LoadDiaChi(row.Cells["MaNguoiDung"].Value?.ToString());

                // Chức vụ
                string chucVu = row.Cells["ChucVu"].Value?.ToString() ?? "";
                cbo_ChucVu.Text = chucVu;

                // Vai trò
                if (row.Cells["MaVaiTro"].Value != null)
                {
                    cbo_VaiTro.SelectedValue = Convert.ToInt32(row.Cells["MaVaiTro"].Value);
                }

                txt_TenDangNhap.Text = row.Cells["TenDangNhap"].Value?.ToString() ?? "";

                // Xóa mật khẩu (không hiển thị)
                txt_MatKhau.Text = "";
                txt_NhapLaiMatKhau.Text = "";
            }
        }

        // Load địa chỉ từ bảng NguoiDung
        private void LoadDiaChi(string maNguoiDung)
        {
            if (string.IsNullOrEmpty(maNguoiDung)) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT DiaChi FROM NguoiDung WHERE MaNguoiDung = @MaNguoiDung";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                    object result = cmd.ExecuteScalar();
                    txt_DiaChi.Text = result?.ToString() ?? "";
                }
            }
            catch { }
        }
        #endregion

        #region NÚT THÊM MỚI - Gọi Stored Procedure
        private void btn_ThemMoi_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu nhập
            if (!KiemTraDuLieu()) return;

            // Kiểm tra mật khẩu khớp
            if (txt_MatKhau.Text != txt_NhapLaiMatKhau.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_NhapLaiMatKhau.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_ThemNhanVienKemTaiKhoan", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số
                    cmd.Parameters.AddWithValue("@HoTen", txt_HoTen.Text.Trim());
                    cmd.Parameters.AddWithValue("@GioiTinh", LayGioiTinh());
                    cmd.Parameters.AddWithValue("@NgaySinh", dtp_NgaySinh.Value.Date);
                    cmd.Parameters.AddWithValue("@ChucVu", cbo_ChucVu.Text);
                    cmd.Parameters.AddWithValue("@SoDienThoai", txt_SoDienThoai.Text.Trim());
                    cmd.Parameters.AddWithValue("@TenDangNhap", txt_TenDangNhap.Text.Trim());
                    cmd.Parameters.AddWithValue("@MatKhau", txt_MatKhau.Text);
                    cmd.Parameters.AddWithValue("@Email", txt_Email.Text.Trim());
                    cmd.Parameters.AddWithValue("@DiaChi", txt_DiaChi.Text.Trim());
                    cmd.Parameters.AddWithValue("@MaVaiTro", cbo_VaiTro.SelectedValue);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("✓ Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadDanhSachTaiKhoan();
                    LamMoiForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region NÚT CẬP NHẬT
        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            if (dgv_DanhSachTaiKhoan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!KiemTraDuLieu()) return;

            try
            {
                DataGridViewRow row = dgv_DanhSachTaiKhoan.SelectedRows[0];
                int maNV = Convert.ToInt32(row.Cells["MaNV"].Value);
                int maNguoiDung = Convert.ToInt32(row.Cells["MaNguoiDung"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // 1. Cập nhật bảng NguoiDung
                        string queryND = @"UPDATE NguoiDung 
                                          SET TenNguoiDung = @HoTen, 
                                              SoDienThoai = @SoDienThoai, 
                                              Email = @Email, 
                                              DiaChi = @DiaChi, 
                                              MaVaiTro = @MaVaiTro
                                          WHERE MaNguoiDung = @MaNguoiDung";
                        SqlCommand cmdND = new SqlCommand(queryND, conn, transaction);
                        cmdND.Parameters.AddWithValue("@HoTen", txt_HoTen.Text.Trim());
                        cmdND.Parameters.AddWithValue("@SoDienThoai", txt_SoDienThoai.Text.Trim());
                        cmdND.Parameters.AddWithValue("@Email", txt_Email.Text.Trim());
                        cmdND.Parameters.AddWithValue("@DiaChi", txt_DiaChi.Text.Trim());
                        cmdND.Parameters.AddWithValue("@MaVaiTro", cbo_VaiTro.SelectedValue);
                        cmdND.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                        cmdND.ExecuteNonQuery();

                        // 2. Cập nhật bảng NhanVien
                        string queryNV = @"UPDATE NhanVien 
                                          SET HoTen = @HoTen, 
                                              GioiTinh = @GioiTinh, 
                                              NgaySinh = @NgaySinh, 
                                              ChucVu = @ChucVu, 
                                              SoDienThoai = @SoDienThoai
                                          WHERE MaNV = @MaNV";
                        SqlCommand cmdNV = new SqlCommand(queryNV, conn, transaction);
                        cmdNV.Parameters.AddWithValue("@HoTen", txt_HoTen.Text.Trim());
                        cmdNV.Parameters.AddWithValue("@GioiTinh", LayGioiTinh());
                        cmdNV.Parameters.AddWithValue("@NgaySinh", dtp_NgaySinh.Value.Date);
                        cmdNV.Parameters.AddWithValue("@ChucVu", cbo_ChucVu.Text);
                        cmdNV.Parameters.AddWithValue("@SoDienThoai", txt_SoDienThoai.Text.Trim());
                        cmdNV.Parameters.AddWithValue("@MaNV", maNV);
                        cmdNV.ExecuteNonQuery();

                        // 3. Cập nhật tên đăng nhập (nếu có thay đổi)
                        if (!string.IsNullOrEmpty(txt_TenDangNhap.Text))
                        {
                            string queryDN = @"UPDATE DangNhap 
                                              SET TenDangNhap = @TenDangNhap
                                              WHERE MaNguoiDung = @MaNguoiDung";
                            SqlCommand cmdDN = new SqlCommand(queryDN, conn, transaction);
                            cmdDN.Parameters.AddWithValue("@TenDangNhap", txt_TenDangNhap.Text.Trim());
                            cmdDN.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                            cmdDN.ExecuteNonQuery();
                        }

                        // 4. Cập nhật mật khẩu (nếu có nhập mới)
                        if (!string.IsNullOrEmpty(txt_MatKhau.Text))
                        {
                            if (txt_MatKhau.Text != txt_NhapLaiMatKhau.Text)
                            {
                                throw new Exception("Mật khẩu nhập lại không khớp!");
                            }

                            string queryMK = @"UPDATE DangNhap 
                                              SET MatKhau = @MatKhau
                                              WHERE MaNguoiDung = @MaNguoiDung";
                            SqlCommand cmdMK = new SqlCommand(queryMK, conn, transaction);
                            cmdMK.Parameters.AddWithValue("@MatKhau", txt_MatKhau.Text);
                            cmdMK.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                            cmdMK.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("✓ Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadDanhSachTaiKhoan();
                        LamMoiForm();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region NÚT XÓA
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dgv_DanhSachTaiKhoan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgv_DanhSachTaiKhoan.SelectedRows[0];
            string hoTen = row.Cells["HoTen"].Value?.ToString() ?? "";

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa nhân viên '{hoTen}'?\nThao tác này sẽ xóa cả tài khoản đăng nhập!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int maNV = Convert.ToInt32(row.Cells["MaNV"].Value);
                    int maNguoiDung = Convert.ToInt32(row.Cells["MaNguoiDung"].Value);

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlTransaction transaction = conn.BeginTransaction();

                        try
                        {
                            // 1. Xóa DangNhap (ON DELETE CASCADE sẽ tự xóa, nhưng làm thủ công cho chắc)
                            string queryDN = "DELETE FROM DangNhap WHERE MaNguoiDung = @MaNguoiDung";
                            SqlCommand cmdDN = new SqlCommand(queryDN, conn, transaction);
                            cmdDN.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                            cmdDN.ExecuteNonQuery();

                            // 2. Cập nhật NhanVien (set MaNguoiDung = NULL)
                            string queryNV = "UPDATE NhanVien SET MaNguoiDung = NULL WHERE MaNV = @MaNV";
                            SqlCommand cmdNV = new SqlCommand(queryNV, conn, transaction);
                            cmdNV.Parameters.AddWithValue("@MaNV", maNV);
                            cmdNV.ExecuteNonQuery();

                            // 3. Xóa NhanVien
                            string queryXoaNV = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                            SqlCommand cmdXoaNV = new SqlCommand(queryXoaNV, conn, transaction);
                            cmdXoaNV.Parameters.AddWithValue("@MaNV", maNV);
                            cmdXoaNV.ExecuteNonQuery();

                            // 4. Xóa NguoiDung
                            string queryND = "DELETE FROM NguoiDung WHERE MaNguoiDung = @MaNguoiDung";
                            SqlCommand cmdND = new SqlCommand(queryND, conn, transaction);
                            cmdND.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                            cmdND.ExecuteNonQuery();

                            transaction.Commit();
                            MessageBox.Show("✓ Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadDanhSachTaiKhoan();
                            LamMoiForm();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region NÚT LÀM MỚI
        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
            LoadDanhSachTaiKhoan();
        }

        private void LamMoiForm()
        {
            txt_HoTen.Text = "";
            rb_Nam.Checked = true;
            dtp_NgaySinh.Value = DateTime.Now;
            txt_SoDienThoai.Text = "";
            txt_Email.Text = "";
            txt_DiaChi.Text = "";
            cbo_ChucVu.SelectedIndex = 0;
            if (cbo_VaiTro.Items.Count > 0) cbo_VaiTro.SelectedIndex = 0;
            txt_TenDangNhap.Text = "";
            txt_MatKhau.Text = "";
            txt_NhapLaiMatKhau.Text = "";
            txt_HoTen.Focus();
        }
        #endregion

        #region NÚT TÌM KIẾM
        private void btn_Tim_Click(object sender, EventArgs e)
        {
            string keyword = txt_TimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword) || keyword == "Nhập tên, SĐT, email để tìm kiếm...")
            {
                LoadDanhSachTaiKhoan();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            nv.MaNV,
                            nv.HoTen,
                            nv.GioiTinh,
                            CONVERT(VARCHAR(10), nv.NgaySinh, 103) AS NgaySinh,
                            nv.SoDienThoai,
                            nd.Email,
                            nv.ChucVu,
                            vt.TenVaiTro,
                            dn.TenDangNhap,
                            nd.MaNguoiDung,
                            nd.MaVaiTro
                        FROM NhanVien nv
                        INNER JOIN NguoiDung nd ON nv.MaNguoiDung = nd.MaNguoiDung
                        INNER JOIN VaiTro vt ON nd.MaVaiTro = vt.MaVaiTro
                        LEFT JOIN DangNhap dn ON nd.MaNguoiDung = dn.MaNguoiDung
                        WHERE nv.HoTen LIKE @keyword 
                           OR nv.SoDienThoai LIKE @keyword 
                           OR nd.Email LIKE @keyword
                           OR dn.TenDangNhap LIKE @keyword
                        ORDER BY nv.MaNV";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv_DanhSachTaiKhoan.DataSource = dt;

                    // Đánh số thứ tự
                    for (int i = 0; i < dgv_DanhSachTaiKhoan.Rows.Count; i++)
                    {
                        dgv_DanhSachTaiKhoan.Rows[i].Cells["STT"].Value = i + 1;
                    }

                    lbl_TongSoTaiKhoan.Text = $"📌 Tìm thấy: {dt.Rows.Count} tài khoản";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region NÚT THỐNG KÊ
        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Thống kê theo vai trò
                    string queryVaiTro = @"
                        SELECT vt.TenVaiTro, COUNT(*) AS SoLuong
                        FROM NguoiDung nd
                        INNER JOIN VaiTro vt ON nd.MaVaiTro = vt.MaVaiTro
                        GROUP BY vt.TenVaiTro";

                    SqlCommand cmdVT = new SqlCommand(queryVaiTro, conn);
                    SqlDataReader readerVT = cmdVT.ExecuteReader();

                    string thongKeVaiTro = "📊 THỐNG KÊ THEO VAI TRÒ:\n";
                    while (readerVT.Read())
                    {
                        thongKeVaiTro += $"  • {readerVT["TenVaiTro"]}: {readerVT["SoLuong"]} người\n";
                    }
                    readerVT.Close();

                    // Thống kê theo chức vụ
                    string queryChucVu = @"
                        SELECT ChucVu, COUNT(*) AS SoLuong
                        FROM NhanVien
                        WHERE MaNguoiDung IS NOT NULL
                        GROUP BY ChucVu";

                    SqlCommand cmdCV = new SqlCommand(queryChucVu, conn);
                    SqlDataReader readerCV = cmdCV.ExecuteReader();

                    string thongKeChucVu = "\n📊 THỐNG KÊ THEO CHỨC VỤ:\n";
                    while (readerCV.Read())
                    {
                        thongKeChucVu += $"  • {readerCV["ChucVu"]}: {readerCV["SoLuong"]} người\n";
                    }
                    readerCV.Close();

                    // Thống kê theo giới tính
                    string queryGioiTinh = @"
                        SELECT GioiTinh, COUNT(*) AS SoLuong
                        FROM NhanVien
                        WHERE MaNguoiDung IS NOT NULL
                        GROUP BY GioiTinh";

                    SqlCommand cmdGT = new SqlCommand(queryGioiTinh, conn);
                    SqlDataReader readerGT = cmdGT.ExecuteReader();

                    string thongKeGioiTinh = "\n📊 THỐNG KÊ THEO GIỚI TÍNH:\n";
                    while (readerGT.Read())
                    {
                        thongKeGioiTinh += $"  • {readerGT["GioiTinh"]}: {readerGT["SoLuong"]} người\n";
                    }
                    readerGT.Close();

                    // Tổng số tài khoản
                    string queryTong = "SELECT COUNT(*) FROM NguoiDung";
                    SqlCommand cmdTong = new SqlCommand(queryTong, conn);
                    int tongSo = (int)cmdTong.ExecuteScalar();

                    string ketQua = $"📌 TỔNG SỐ TÀI KHOẢN: {tongSo}\n\n" + thongKeVaiTro + thongKeChucVu + thongKeGioiTinh;

                    MessageBox.Show(ketQua, "Thống kê tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region HÀM HỖ TRỢ

        // Lấy giới tính từ RadioButton
        private string LayGioiTinh()
        {
            if (rb_Nam.Checked) return "Nam";
            if (rb_Nu.Checked) return "Nữ";
            return "Khác";
        }

        // Kiểm tra dữ liệu nhập
        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txt_HoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_HoTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_SoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SoDienThoai.Focus();
                return false;
            }

            if (txt_SoDienThoai.Text.Length < 9 || txt_SoDienThoai.Text.Length > 11)
            {
                MessageBox.Show("Số điện thoại phải từ 9-11 số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SoDienThoai.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_Email.Text))
            {
                MessageBox.Show("Vui lòng nhập email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Email.Focus();
                return false;
            }

            if (!txt_Email.Text.Contains("@") || !txt_Email.Text.Contains("."))
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Email.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_TenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenDangNhap.Focus();
                return false;
            }

            return true;
        }

        // Chỉ cho phép nhập số vào SĐT
        private void txt_SoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region XỬ LÝ PLACEHOLDER CHO Ô TÌM KIẾM
        private void txt_TimKiem_Enter(object sender, EventArgs e)
        {
            if (txt_TimKiem.Text == "Nhập tên, SĐT, email để tìm kiếm...")
            {
                txt_TimKiem.Text = "";
                txt_TimKiem.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txt_TimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_TimKiem.Text))
            {
                txt_TimKiem.Text = "Nhập tên, SĐT, email để tìm kiếm...";
                txt_TimKiem.ForeColor = System.Drawing.Color.Gray;
            }
        }
        #endregion

        private void gbx_ThongTinTaiKhoan_Enter(object sender, EventArgs e)
        {
            // Không cần xử lý
        }
    }
}