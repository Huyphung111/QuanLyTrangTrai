using System;
using System.Windows.Forms;
using Đồ_án;
using QL_TrangTrai;

namespace QuanLyTrangTrai
{
    public partial class GiaoDien : Form
    {
        public GiaoDien()
        {
            InitializeComponent();
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

        // 🌱 CÂY TRỒNG
        private void btnQLCayTrong_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new QL_CayTrong());
        }

        // 🐄 VẬT NUÔI
        private void btnQLVatNuoi_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new QL_VatNuoi());
        }

        // 📦 SẢN PHẨM
        private void btnQLSanPham_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new QL_SanPham());
        }

        // 📅 LỊCH CÔNG VIỆC
        private void btnLichCongViec_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmLichCongViec());
        }

        // 🏬 KHO THIẾT BỊ  (button1)
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmQuanLyKho());
        }

        // 🌾 THU HOẠCH
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

        // 👤 QUẢN LÝ TÀI KHOẢN
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

        // ❌ THOÁT
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

        private void btn_taichinh_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmTaiChinh());
        }

        private void btn_khoiphucdulieu_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmBackupDatabase());
        }

    }
}
