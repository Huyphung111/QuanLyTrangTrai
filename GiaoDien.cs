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

        private void btnQLCayTrong_Click(object sender, EventArgs e)
        {
            OpenForm(new QL_CayTrong());
        }

        private void btnQLVatNuoi_Click(object sender, EventArgs e)
        {
            OpenForm(new QL_VatNuoi());
        }

        private void btnQLSanPham_Click(object sender, EventArgs e)
        {
            OpenForm(new QL_SanPham());
        }

        private void btnThuHoach_Click(object sender, EventArgs e)
        {
            OpenForm(new frmThuHoach());
        }

        private void btnCTCayTrong_Click(object sender, EventArgs e)
        {
            OpenForm(new frmChiTietThuHoachCayTrong());
        }

        private void btnCTVatNuoi_Click(object sender, EventArgs e)
        {
            OpenForm(new frmChiTietThuHoachVatNuoi());
        }

        private void btnLichCongViec_Click(object sender, EventArgs e)
        {
            OpenForm(new frmLichCongViec());
        }

        private void btnQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenForm(new frm_QuanLyTaiKhoan());
        }

        private void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenForm(new TaoTaiKhoang());
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            OpenForm(new DoiMatKhau());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OpenForm(Form form)
        {
            using (form)
            {
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog(this);
            }
        }
    }
}