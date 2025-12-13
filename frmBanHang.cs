using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_TrangTrai
{
    public partial class frmBanHang : Form
    {
        // =========================
        // CONNECTION STRING
        // =========================
        private string connectionString = @"Data Source=HUYNE;Initial Catalog=QL_TrangTraiv13;Integrated Security=True";

        // =========================
        // THÔNG TIN SẢN PHẨM
        // =========================
        private int maSP;
        private string tenSP;
        private decimal giaBan;
        private int tonKho;
        private string donVi;

        // =========================
        // THÔNG TIN ĐĂNG NHẬP
        // =========================
        private int _maNguoiDung;
        private int _maVaiTro;

        // =========================
        // CONSTRUCTOR
        // =========================
        public frmBanHang(
            int maSP,
            string tenSP,
            decimal giaBan,
            int tonKho,
            string donVi,
            int maNguoiDung,
            int maVaiTro)
        {
            InitializeComponent();

            this.maSP = maSP;
            this.tenSP = tenSP;
            this.giaBan = giaBan;
            this.tonKho = tonKho;
            this.donVi = donVi;

            _maNguoiDung = maNguoiDung;
            _maVaiTro = maVaiTro;
        }

        // =========================
        // FORM LOAD
        // =========================
        private void frmBanHang_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            LoadPhuongThuc();

            dtpNgayGiaoDich.Value = DateTime.Now;

            txtMaSP.Text = maSP.ToString();
            txtTenSP.Text = tenSP;
            txtDonVi.Text = donVi;
            txtTonKho.Text = $"{tonKho} {donVi}";
            txtGiaBan.Text = $"{giaBan:N0} VNĐ";
            txtMoTa.Text = "Bán " + tenSP;

            txtSoLuongBan.Focus();
        }

        // =========================
        // LOAD NHÂN VIÊN + PHÂN QUYỀN
        // =========================
        private void LoadNhanVien()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Load danh sách nhân viên
                    string sql = "SELECT MaNV, HoTen FROM NhanVien";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboNhanVien.DataSource = dt;
                    cboNhanVien.DisplayMember = "HoTen";
                    cboNhanVien.ValueMember = "MaNV";

                    // Nếu là NHÂN VIÊN → auto chọn & khóa
                    if (_maVaiTro == 2 && _maNguoiDung > 0)
                    {
                        string sqlNV = "SELECT MaNV FROM NhanVien WHERE MaNguoiDung = @MaNguoiDung";
                        using (SqlCommand cmd = new SqlCommand(sqlNV, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaNguoiDung", _maNguoiDung);
                            object result = cmd.ExecuteScalar();

                            if (result != null && result != DBNull.Value)
                            {
                                cboNhanVien.SelectedValue = Convert.ToInt32(result);
                                cboNhanVien.Enabled = false; // 🔒 khóa
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load nhân viên:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================
        // LOAD PHƯƠNG THỨC
        // =========================
        private void LoadPhuongThuc()
        {
            cboPhuongThuc.Items.Clear();
            cboPhuongThuc.Items.AddRange(new string[] { "Tiền mặt", "Chuyển khoản", "Khác" });
            cboPhuongThuc.SelectedIndex = 0;
        }

        // =========================
        // TÍNH THÀNH TIỀN
        // =========================
        private void txtSoLuongBan_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtSoLuongBan.Text, out int sl) && sl > 0)
                lblThanhTien.Text = $"{sl * giaBan:N0} VNĐ";
            else
                lblThanhTien.Text = "0 VNĐ";
        }

        // =========================
        // NÚT HOÀN THÀNH
        // =========================
        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSoLuongBan.Text, out int soLuongBan) || soLuongBan <= 0)
            {
                MessageBox.Show("Số lượng bán không hợp lệ!", "Cảnh báo");
                return;
            }

            if (soLuongBan > tonKho)
            {
                MessageBox.Show("Số lượng bán vượt tồn kho!", "Cảnh báo");
                return;
            }

            decimal thanhTien = soLuongBan * giaBan;

            if (MessageBox.Show(
                $"Xác nhận bán?\n\nSản phẩm: {tenSP}\nSố lượng: {soLuongBan} {donVi}\nThành tiền: {thanhTien:N0} VNĐ",
                "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                BanHang(soLuongBan, thanhTien);
            }
        }

        // =========================
        // HÀM BÁN HÀNG (TRANSACTION)
        // =========================
        private void BanHang(int soLuongBan, decimal thanhTien)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    int maNV = Convert.ToInt32(cboNhanVien.SelectedValue);

                    // 1. Mã giao dịch
                    SqlCommand cmdMaGD = new SqlCommand(
                        "SELECT ISNULL(MAX(MaGiaoDich),0)+1 FROM TaiChinh",
                        conn, trans);
                    int maGD = Convert.ToInt32(cmdMaGD.ExecuteScalar());

                    // 2. TaiChinh
                    SqlCommand cmdTC = new SqlCommand(@"
                        INSERT INTO TaiChinh
                        (MaGiaoDich, LoaiGiaoDich, SoTien, NgayGiaoDich, MoTa, PhuongThucTT, MaNV)
                        VALUES (@MaGD, N'Thu', @Tien, @Ngay, @MoTa, @PT, @MaNV)",
                        conn, trans);

                    cmdTC.Parameters.AddWithValue("@MaGD", maGD);
                    cmdTC.Parameters.AddWithValue("@Tien", thanhTien);
                    cmdTC.Parameters.AddWithValue("@Ngay", dtpNgayGiaoDich.Value);
                    cmdTC.Parameters.AddWithValue("@MoTa", txtMoTa.Text);
                    cmdTC.Parameters.AddWithValue("@PT", cboPhuongThuc.Text);
                    cmdTC.Parameters.AddWithValue("@MaNV", maNV);
                    cmdTC.ExecuteNonQuery();

                    // 3. Chi tiết giao dịch
                    SqlCommand cmdCT = new SqlCommand(
                        "SELECT ISNULL(MAX(MaChiTiet),0)+1 FROM ChiTietGiaoDich",
                        conn, trans);
                    int maCT = Convert.ToInt32(cmdCT.ExecuteScalar());

                    SqlCommand cmdInsertCT = new SqlCommand(@"
                        INSERT INTO ChiTietGiaoDich
                        (MaChiTiet, MaGiaoDich, MaSP, SoLuong, DonGia)
                        VALUES (@CT, @GD, @SP, @SL, @Gia)",
                        conn, trans);

                    cmdInsertCT.Parameters.AddWithValue("@CT", maCT);
                    cmdInsertCT.Parameters.AddWithValue("@GD", maGD);
                    cmdInsertCT.Parameters.AddWithValue("@SP", maSP);
                    cmdInsertCT.Parameters.AddWithValue("@SL", soLuongBan);
                    cmdInsertCT.Parameters.AddWithValue("@Gia", giaBan);
                    cmdInsertCT.ExecuteNonQuery();

                    // 4. Trừ tồn kho (SP)
                    SqlCommand cmdKhoa = new SqlCommand(
                        "sp_KhoaBanSanPham", conn, trans);
                    cmdKhoa.CommandType = CommandType.StoredProcedure;
                    cmdKhoa.Parameters.AddWithValue("@MaSP", maSP);
                    cmdKhoa.Parameters.AddWithValue("@SoLuong", soLuongBan);
                    cmdKhoa.ExecuteNonQuery();

                    trans.Commit();

                    MessageBox.Show($"✅ Bán thành công!\n\nMã GD: {maGD}", "Thành công");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("❌ Lỗi:\n" + ex.Message);
                }
            }
        }

        // =========================
        // HỦY
        // =========================
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
