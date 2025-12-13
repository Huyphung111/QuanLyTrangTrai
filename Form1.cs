using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTrangTrai
{
    public partial class Form1 : Form
    {
        // Chuỗi kết nối - SỬA LẠI CHO ĐÚNG MÁY CỦA BẠN
        // Kiểm tra dòng này trong Form1.cs
        private string connectionString = @"Data Source=HUYNE;Initial Catalog=QL_TrangTraiv13;Integrated Security=True";
        private int _maVaiTro = 0;
        private int _maNguoiDung = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Ẩn mật khẩu khi load form
            txt_nhapmatkhau.PasswordChar = '●';

            // Xóa thông báo lỗi
            txt_thongbaotendangnhap.Text = "";
            txt_thongbaomatkhau.Text = "";

            // Focus vào ô tài khoản
            txt_nhaptaikhoang.Focus();
        }

        // Nút ĐĂNG NHẬP - button1
        private void button1_Click(object sender, EventArgs e)
        {
            // Xóa thông báo lỗi cũ
            txt_thongbaotendangnhap.Text = "";
            txt_thongbaomatkhau.Text = "";

            // Lấy dữ liệu từ TextBox
            string tenDangNhap = txt_nhaptaikhoang.Text.Trim();
            string matKhau = txt_nhapmatkhau.Text.Trim();

            // Kiểm tra rỗng
            if (string.IsNullOrEmpty(tenDangNhap))
            {
                txt_thongbaotendangnhap.Text = "Tên đăng nhập không tồn tại, thử lại!";
                txt_thongbaotendangnhap.ForeColor = Color.Red;
                txt_nhaptaikhoang.Focus();
                return;
            }

            if (string.IsNullOrEmpty(matKhau))
            {
                txt_thongbaomatkhau.Text = "Tên đăng nhập không tồn tại, thử lại!";
                txt_thongbaomatkhau.ForeColor = Color.Red;
                txt_nhapmatkhau.Focus();
                return;
            }

            // Thực hiện đăng nhập
            if (KiemTraDangNhap(tenDangNhap, matKhau))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ẩn form đăng nhập
                this.Hide();

                // Hiển thị form Giao Diện
                GiaoDien formGiaoDien = new GiaoDien(_maVaiTro, _maNguoiDung);
                formGiaoDien.ShowDialog();

                // Đóng form đăng nhập khi thoát giao diện chính
                this.Close();
            }
            else
            {
                txt_thongbaotendangnhap.Text = "Tên đăng nhập không tồn tại, thử lại!";
                txt_thongbaomatkhau.Text = "Tên đăng nhập không tồn tại, thử lại!";
                txt_thongbaotendangnhap.ForeColor = Color.Red;
                txt_thongbaomatkhau.ForeColor = Color.Red;
                txt_nhaptaikhoang.Clear();
                txt_nhapmatkhau.Clear();
                txt_nhaptaikhoang.Focus();
            }
        }

        // Hàm kiểm tra đăng nhập (KHÔNG MÃ HÓA - QL_TrangTraiv13)
        private bool KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                SELECT nd.MaVaiTro, nd.MaNguoiDung 
                FROM DangNhap dn
                INNER JOIN NguoiDung nd ON dn.MaNguoiDung = nd.MaNguoiDung
                WHERE dn.TenDangNhap = @TenDangNhap 
                AND dn.MatKhau = @MatKhau";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                        cmd.Parameters.AddWithValue("@MatKhau", matKhau);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            _maVaiTro = Convert.ToInt32(reader["MaVaiTro"]);
                            _maNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]);
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // CheckBox hiện/ẩn mật khẩu
        private void check_hienmatkhau_CheckedChanged(object sender, EventArgs e)
        {
            if (check_hienmatkhau.Checked)
            {
                txt_nhapmatkhau.PasswordChar = '\0'; // Hiện mật khẩu
            }
            else
            {
                txt_nhapmatkhau.PasswordChar = '●'; // Ẩn mật khẩu
            }
        }

        // Nút TẠO TÀI KHOẢN
        private void btn_taotaikhoang_Click(object sender, EventArgs e)
        {
            // Mở form Tạo tài khoản
            TaoTaiKhoang formTaoTK = new TaoTaiKhoang();

            // Hiển thị dạng Dialog (modal)
            DialogResult result = formTaoTK.ShowDialog();

            // Nếu tạo thành công, focus vào ô tài khoản để đăng nhập
            if (result == DialogResult.OK)
            {
                txt_nhaptaikhoang.Focus();
            }
        }

        // Nút ĐỔI MẬT KHẨU (để sau)
        private void btn_doimatkhau_Click(object sender, EventArgs e)
        {
            // Mở form Đổi mật khẩu
            DoiMatKhau formDoiMatKhau = new DoiMatKhau();

            // Hiển thị dạng Dialog (modal)
            formDoiMatKhau.ShowDialog();
        }


        // Xóa thông báo khi click vào label
        private void txt_thongbaotendangnhap_Click(object sender, EventArgs e)
        {
            txt_thongbaotendangnhap.Text = "";
        }

        private void txt_thongbaomatkhau_Click(object sender, EventArgs e)
        {
            txt_thongbaomatkhau.Text = "";
        }

        private void txt_nhaptaikhoang_TextChanged(object sender, EventArgs e)
        {
            // Xóa thông báo lỗi khi người dùng gõ
            txt_thongbaotendangnhap.Text = "";
        }

        private void txt_nhapmatkhau_TextChanged(object sender, EventArgs e)
        {
            // Xóa thông báo lỗi khi người dùng gõ
            txt_thongbaomatkhau.Text = "";
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            // Không cần xử lý
        }
    }
}

// ============================================
// HƯỚNG DẪN SỬ DỤNG (QL_TrangTraiv13):
// ============================================
// 1. SỬA CHUỖI KẾT NỐI Ở DÒNG 18:
//    - Thay YOUR_SERVER_NAME bằng tên SQL Server của bạn
//    - Ví dụ: Data Source=DESKTOP-ABC123\SQLEXPRESS;...
//    - Hoặc: Data Source=.;... (nếu dùng local)
//
// 2. TÀI KHOẢN MẪU TRONG DATABASE:
//    - admin / 123456
//    - ttbinh / 123456
//    - lvcuong / 123456
//    - ptdung / 123456
//
// 3. MẬT KHẨU KHÔNG MÃ HÓA (NVARCHAR):
//    - Database v13 lưu mật khẩu dạng text thường
//    - So sánh trực tiếp, không cần HASHBYTES
//
// 4. KHI ĐĂNG NHẬP THÀNH CÔNG:
//    - Form1 sẽ ẩn đi
//    - Form GiaoDien sẽ hiện ra
// ============================================