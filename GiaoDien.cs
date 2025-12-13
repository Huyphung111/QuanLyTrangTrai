using System;
using System.Windows.Forms;
using Đồ_án;
using QL_TrangTrai;

namespace QuanLyTrangTrai
{
    public partial class GiaoDien : Form
    {
        // Biến lưu mã vai trò của người dùng đăng nhập
        private int _maVaiTro;
        public int MaNguoiDung { get; private set; }
        public int MaVaiTro { get { return _maVaiTro; } }


        // Constructor nhận MaVaiTro từ form đăng nhập
        public GiaoDien(int maVaiTro, int maNguoiDung = 0)
        {
            InitializeComponent();
            _maVaiTro = maVaiTro;
            MaNguoiDung = maNguoiDung;
            this.Load += GiaoDien_Load;
        }

        // Constructor mặc định (nếu cần)
        public GiaoDien()
        {
            InitializeComponent();
            _maVaiTro = 1; // Mặc định là quản trị
            this.Load += GiaoDien_Load;
        }

        // ==========================
        // SỰ KIỆN LOAD FORM
        // ==========================
        private void GiaoDien_Load(object sender, EventArgs e)
        {
            PhanQuyenTheoVaiTro();
        }

        // ==========================
        // PHÂN QUYỀN THEO VAI TRÒ
        // ==========================
        private void PhanQuyenTheoVaiTro()
        {
            // Tên button thực tế trong Designer:
            // btnPets = Cây trồng
            // btnServices = Vật nuôi
            // btnAccessories = Sản phẩm
            // btnReports = Lịch công việc
            // button1 = Kho Thiết Bị
            // btnInvoices = Thu hoạch
            // btnAccounts = Tài khoản
            // btn_taichinh = Tài Chính
            // btn_khoiphucdulieu = Dữ liệu

            if (_maVaiTro == 1)
            {
                // QUẢN TRỊ VIÊN - Hiện tất cả button
                btnPets.Visible = true;           // Cây trồng
                btnServices.Visible = true;       // Vật nuôi
                btnAccessories.Visible = true;    // Sản phẩm
                btnReports.Visible = true;        // Lịch công việc
                button1.Visible = true;           // Kho Thiết Bị
                btnInvoices.Visible = true;       // Thu hoạch
                btnAccounts.Visible = true;       // Tài khoản
                btn_taichinh.Visible = true;      // Tài Chính
                btn_khoiphucdulieu.Visible = true; // Dữ liệu
            }
            else if (_maVaiTro == 2)
            {
                // NHÂN VIÊN - Chỉ hiện: Cây trồng, Vật nuôi, Sản phẩm, Lịch công việc, Kho thiết bị
                btnPets.Visible = true;           // Cây trồng
                btnServices.Visible = true;       // Vật nuôi
                btnAccessories.Visible = true;    // Sản phẩm
                btnReports.Visible = true;        // Lịch công việc
                button1.Visible = true;           // Kho Thiết Bị

                // ẨN các button không cho phép
                btnInvoices.Visible = false;      // Thu hoạch
                btnAccounts.Visible = false;      // Tài khoản
                btn_taichinh.Visible = false;     // Tài Chính
                btn_khoiphucdulieu.Visible = false; // Dữ liệu
            }
            else
            {
                // VAI TRÒ KHÁC - Mặc định ẩn hết các chức năng nhạy cảm
                btnPets.Visible = true;
                btnServices.Visible = true;
                btnAccessories.Visible = true;
                btnReports.Visible = true;
                button1.Visible = true;

                btnInvoices.Visible = false;
                btnAccounts.Visible = false;
                btn_taichinh.Visible = false;
                btn_khoiphucdulieu.Visible = false;
            }
        }

        // ==========================
        // HÀM MỞ FORM TRONG PANEL1
        // ==========================
        public void OpenFormInPanel(Form childForm)
        {
            panel1.Controls.Clear();                  // Xóa form cũ
            childForm.TopLevel = false;               // BẮT BUỘC
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;          // Full panel
            panel1.Controls.Add(childForm);
            childForm.Show();
        }

        // ==========================
        // MENU BÊN TRÁI
        // ==========================

        // 🌱 CÂY TRỒNG (btnPets)
        private void btnQLCayTrong_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new QL_CayTrong());
        }

        // 🐄 VẬT NUÔI (btnServices)
        private void btnQLVatNuoi_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new QL_VatNuoi());
        }

        // 📦 SẢN PHẨM (btnAccessories)
        private void btnQLSanPham_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new QL_SanPham(MaNguoiDung, MaVaiTro));

        }

        // 📅 LỊCH CÔNG VIỆC (btnReports)
        private void btnLichCongViec_Click(object sender, EventArgs e)
        {
            if (MaVaiTro == 1)
            {
                // ADMIN: mở form quản lý lịch công việc (CRUD)
                OpenFormInPanel(new frmLichCongViec());
            }
            else if (MaVaiTro == 2)
            {
                // NHÂN VIÊN: mở form "Công việc của tôi"
                // (lọc theo MaNguoiDung -> MaNV -> LichCongViec)
                OpenFormInPanel(new frmCongViecNhanVien(MaNguoiDung));
            }
            else
            {
                // Vai trò khác (nếu có)
                OpenFormInPanel(new frmCongViecNhanVien(MaNguoiDung));
            }
        }


        // 🏬 KHO THIẾT BỊ (button1)
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmQuanLyKho(MaNguoiDung, MaVaiTro));

        }

        // 🌾 THU HOẠCH (btnInvoices)
        private void btnThuHoach_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmThuHoach());
        }

        // 🌱 CHI TIẾT THU HOẠCH CÂY TRỒNG
        private void btnCTCayTrong_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmChiTietThuHoachCayTrong());
        }

        // 🐄 CHI TIẾT THU HOẠCH VẬT NUÔI
        private void btnCTVatNuoi_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmChiTietThuHoachVatNuoi());
        }

        // 👤 QUẢN LÝ TÀI KHOẢN (btnAccounts)
        private void btnQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frm_QuanLyTaiKhoan());
        }

        // ➕ TẠO TÀI KHOẢN
        private void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new TaoTaiKhoang());
        }

        // 🔑 ĐỔI MẬT KHẨU
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new DoiMatKhau());
        }

        // 💰 TÀI CHÍNH (btn_taichinh)
        private void btn_taichinh_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmTaiChinh(MaNguoiDung, MaVaiTro));
        }

        // 💾 KHÔI PHỤC DỮ LIỆU (btn_khoiphucdulieu)
        private void btn_khoiphucdulieu_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmBackupDatabase());
        }

        // ❌ THOÁT (btnExit)
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ==========================
        // SỰ KIỆN KHÔNG DÙNG
        // ==========================
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}