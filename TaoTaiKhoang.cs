using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTrangTrai
{
    public partial class TaoTaiKhoang : Form
    {
        // Chuỗi kết nối - GIỐNG FORM1
        private string connectionString = @"Data Source=HUYNE;Initial Catalog=QL_TrangTraiv13;Integrated Security=True";

        public TaoTaiKhoang()
        {
            InitializeComponent();
        }

        private void TaoTaiKhoang_Load(object sender, EventArgs e)
        {
            // Ẩn mật khẩu
            txt_nhapmatkhau.PasswordChar = '●';
            txt_nhaplaimatkhau.PasswordChar = '●';

            // Xóa tất cả thông báo lỗi
            XoaTatCaThongBaoLoi();

            // Focus vào ô họ tên
            txt_hovaten.Focus();
        }

        // Xóa tất cả thông báo lỗi
        private void XoaTatCaThongBaoLoi()
        {
            txt_hovatendaydu.Text = "";
            txt_thongbaotaikhoangcongdung.Text = "";
            txt_matkhauitnhat6kitu.Text = "";
            txt_matkhaukhongtrungkhop.Text = "";
            txt_emailkhongphuhop.Text = "";
        }

        // NÚT TẠO TÀI KHOẢN
        private void btn_taotaikhoang_Click(object sender, EventArgs e)
        {
            // Xóa thông báo lỗi cũ
            XoaTatCaThongBaoLoi();

            // Lấy dữ liệu từ form
            string hoVaTen = txt_hovaten.Text.Trim();
            string tenTaiKhoan = txt_nhaptaikhoang.Text.Trim();
            string matKhau = txt_nhapmatkhau.Text.Trim();
            string nhapLaiMatKhau = txt_nhaplaimatkhau.Text.Trim();
            string email = txt_email.Text.Trim();

            // 1. VALIDATE DỮ LIỆU
            bool coLoi = false;

            // Kiểm tra họ tên
            if (string.IsNullOrEmpty(hoVaTen))
            {
                txt_hovatendaydu.Text = "Họ và tên đầy đủ";
                txt_hovatendaydu.ForeColor = Color.Red;
                coLoi = true;
            }

            // Kiểm tra tài khoản
            if (string.IsNullOrEmpty(tenTaiKhoan))
            {
                txt_thongbaotaikhoangcongdung.Text = "Tên tài khoản đã có người dùng";
                txt_thongbaotaikhoangcongdung.ForeColor = Color.Red;
                coLoi = true;
            }
            else if (KiemTraTaiKhoanDaTonTai(tenTaiKhoan))
            {
                txt_thongbaotaikhoangcongdung.Text = "Tên tài khoản đã có người dùng";
                txt_thongbaotaikhoangcongdung.ForeColor = Color.Red;
                coLoi = true;
            }

            // Kiểm tra mật khẩu
            if (string.IsNullOrEmpty(matKhau))
            {
                txt_matkhauitnhat6kitu.Text = "Mật khẩu ít nhất 6 kí tự";
                txt_matkhauitnhat6kitu.ForeColor = Color.Red;
                coLoi = true;
            }
            else if (matKhau.Length < 6)
            {
                txt_matkhauitnhat6kitu.Text = "Mật khẩu ít nhất 6 kí tự";
                txt_matkhauitnhat6kitu.ForeColor = Color.Red;
                coLoi = true;
            }

            // Kiểm tra nhập lại mật khẩu
            if (matKhau != nhapLaiMatKhau)
            {
                txt_matkhaukhongtrungkhop.Text = "Mật khẩu nhập lại không trùng khớp";
                txt_matkhaukhongtrungkhop.ForeColor = Color.Red;
                coLoi = true;
            }

            // Kiểm tra email
            if (string.IsNullOrEmpty(email))
            {
                txt_emailkhongphuhop.Text = "Email không phù hợp";
                txt_emailkhongphuhop.ForeColor = Color.Red;
                coLoi = true;
            }
            else if (!KiemTraEmailHopLe(email))
            {
                txt_emailkhongphuhop.Text = "Email không phù hợp";
                txt_emailkhongphuhop.ForeColor = Color.Red;
                coLoi = true;
            }
            else if (KiemTraEmailDaTonTai(email))
            {
                txt_emailkhongphuhop.Text = "Email đã được sử dụng";
                txt_emailkhongphuhop.ForeColor = Color.Red;
                coLoi = true;
            }

            // Nếu có lỗi thì dừng lại
            if (coLoi)
            {
                return;
            }

            // 2. TẠO TÀI KHOẢN
            if (TaoTaiKhoan(hoVaTen, tenTaiKhoan, matKhau, email))
            {
                MessageBox.Show(
                    "Tạo tài khoản thành công!\n\n" +
                    "Bạn có thể đăng nhập ngay bây giờ.",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Đóng form và quay lại đăng nhập
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        // ⭐ HÀM TẠO TÀI KHOẢN - GHI VÀO 3 BẢNG: NguoiDung, DangNhap, NhanVien
        private bool TaoTaiKhoan(string hoVaTen, string tenTaiKhoan, string matKhau, string email)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // 1. Lấy mã tự động cho 3 bảng
                        SqlCommand cmdGetMaxID = new SqlCommand();
                        cmdGetMaxID.Connection = conn;
                        cmdGetMaxID.Transaction = transaction;

                        cmdGetMaxID.CommandText = "SELECT ISNULL(MAX(MaNguoiDung), 0) + 1 FROM NguoiDung";
                        int maNguoiDung = (int)cmdGetMaxID.ExecuteScalar();

                        cmdGetMaxID.CommandText = "SELECT ISNULL(MAX(MaDangNhap), 0) + 1 FROM DangNhap";
                        int maDangNhap = (int)cmdGetMaxID.ExecuteScalar();

                        cmdGetMaxID.CommandText = "SELECT ISNULL(MAX(MaNV), 0) + 1 FROM NhanVien";
                        int maNV = (int)cmdGetMaxID.ExecuteScalar();

                        // 2. Thêm vào bảng NguoiDung - MẶC ĐỊNH LÀ NHÂN VIÊN (MaVaiTro = 2)
                        string queryNguoiDung = @"
                            INSERT INTO NguoiDung (MaNguoiDung, TenNguoiDung, Email, MaVaiTro)
                            VALUES (@MaNguoiDung, @TenNguoiDung, @Email, 2)";

                        SqlCommand cmdNguoiDung = new SqlCommand(queryNguoiDung, conn, transaction);
                        cmdNguoiDung.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                        cmdNguoiDung.Parameters.AddWithValue("@TenNguoiDung", hoVaTen);
                        cmdNguoiDung.Parameters.AddWithValue("@Email", email);
                        cmdNguoiDung.ExecuteNonQuery();

                        // 3. Thêm vào bảng DangNhap
                        string queryDangNhap = @"
                            INSERT INTO DangNhap (MaDangNhap, TenDangNhap, MatKhau, MaNguoiDung)
                            VALUES (@MaDangNhap, @TenDangNhap, @MatKhau, @MaNguoiDung)";

                        SqlCommand cmdDangNhap = new SqlCommand(queryDangNhap, conn, transaction);
                        cmdDangNhap.Parameters.AddWithValue("@MaDangNhap", maDangNhap);
                        cmdDangNhap.Parameters.AddWithValue("@TenDangNhap", tenTaiKhoan);
                        cmdDangNhap.Parameters.AddWithValue("@MatKhau", matKhau);
                        cmdDangNhap.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                        cmdDangNhap.ExecuteNonQuery();

                        // ⭐ 4. THÊM VÀO BẢNG NHANVIEN - TỰ ĐỘNG HIỆN TRONG DANH SÁCH NHÂN VIÊN
                        string queryNhanVien = @"
                            INSERT INTO NhanVien (MaNV, HoTen, ChucVu, MaTrangTrai, MaNguoiDung)
                            VALUES (@MaNV, @HoTen, N'Nhân Viên', 1, @MaNguoiDung)";

                        SqlCommand cmdNhanVien = new SqlCommand(queryNhanVien, conn, transaction);
                        cmdNhanVien.Parameters.AddWithValue("@MaNV", maNV);
                        cmdNhanVien.Parameters.AddWithValue("@HoTen", hoVaTen);
                        cmdNhanVien.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                        cmdNhanVien.ExecuteNonQuery();

                        // Commit transaction - Lưu tất cả thay đổi
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Kiểm tra tài khoản đã tồn tại chưa
        private bool KiemTraTaiKhoanDaTonTai(string tenTaiKhoan)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM DangNhap WHERE TenDangNhap = @TenDangNhap";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenDangNhap", tenTaiKhoan);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        // Kiểm tra email đã tồn tại chưa
        private bool KiemTraEmailDaTonTai(string email)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM NguoiDung WHERE Email = @Email";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        // Kiểm tra email hợp lệ
        private bool KiemTraEmailHopLe(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        // ========== CÁC SỰ KIỆN TEXTBOX ==========

        private void txt_hovaten_TextChanged(object sender, EventArgs e)
        {
            txt_hovatendaydu.Text = ""; // Xóa lỗi khi người dùng gõ
        }

        private void txt_nhaptaikhoang_TextChanged(object sender, EventArgs e)
        {
            txt_thongbaotaikhoangcongdung.Text = "";
        }

        private void txt_nhapmatkhau_TextChanged(object sender, EventArgs e)
        {
            txt_matkhauitnhat6kitu.Text = "";
        }

        private void txt_nhaplaimatkhau_TextChanged(object sender, EventArgs e)
        {
            txt_matkhaukhongtrungkhop.Text = "";
        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {
            txt_emailkhongphuhop.Text = "";
        }

        // ========== CLICK VÀO LABEL ĐỂ XÓA LỖI ==========

        private void txt_hovatendaydu_Click(object sender, EventArgs e)
        {
            txt_hovatendaydu.Text = "";
        }

        private void txt_thongbaotaikhoangcongdung_Click(object sender, EventArgs e)
        {
            txt_thongbaotaikhoangcongdung.Text = "";
        }

        private void txt_matkhauitnhat6kitu_Click(object sender, EventArgs e)
        {
            txt_matkhauitnhat6kitu.Text = "";
        }

        private void txt_matkhaukhongtrungkhop_Click(object sender, EventArgs e)
        {
            txt_matkhaukhongtrungkhop.Text = "";
        }

        private void txt_emailkhongphuhop_Click(object sender, EventArgs e)
        {
            txt_emailkhongphuhop.Text = "";
        }

        private void txt_sdt_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTime_NgayThangNamSi_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_sodienthoaichuadaydu_Click(object sender, EventArgs e)
        {

        }
    }
}