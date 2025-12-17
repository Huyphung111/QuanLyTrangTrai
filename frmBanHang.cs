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

            // HỎI CÓ MUỐN DEMO LOCKING KHÔNG (CLO 2.3)
            DialogResult demoResult = MessageBox.Show(
                "🔒 Bạn có muốn DEMO LOCKING (CLO 2.3) không?\n\n" +
                "✅ YES: Khóa sản phẩm 10 giây (để demo blocking)\n" +
                "❌ NO: Bán hàng bình thường\n" +
                "⚠️ CANCEL: Hủy giao dịch",
                "Demo CLO 2.3 - Transaction Locking",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (demoResult == DialogResult.Cancel)
                return;

            bool demoLocking = (demoResult == DialogResult.Yes);

            // XÁC NHẬN BÁN HÀNG
            if (MessageBox.Show(
                $"Xác nhận bán?\n\n" +
                $"📦 Sản phẩm: {tenSP}\n" +
                $"📊 Số lượng: {soLuongBan} {donVi}\n" +
                $"💰 Thành tiền: {thanhTien:N0} VNĐ\n\n" +
                (demoLocking ? "🔒 CHẾ ĐỘ DEMO LOCKING (10 giây)" : ""),
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                BanHang(soLuongBan, thanhTien, demoLocking);
            }
        }

        // =========================
        // HÀM BÁN HÀNG (TRANSACTION + DEMO LOCKING)
        // =========================
        private void BanHang(int soLuongBan, decimal thanhTien, bool demoLocking)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    int maNV = Convert.ToInt32(cboNhanVien.SelectedValue);

                    // ✅ NẾU CHỌN DEMO LOCKING → Gọi SP để khóa sản phẩm
                    if (demoLocking)
                    {
                        MessageBox.Show(
                            "🔒 DEMO LOCKING (CLO 2.3)\n\n" +
                            "Đang khóa sản phẩm trong 10 giây...\n" +
                            "Hãy thử mở app khác và bán cùng sản phẩm này\n" +
                            "để thấy hiện tượng BLOCKING!",
                            "Demo Locking",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        SqlCommand cmdKhoa = new SqlCommand("sp_KhoaBanSanPham", conn, trans);
                        cmdKhoa.CommandType = CommandType.StoredProcedure;
                        cmdKhoa.Parameters.AddWithValue("@MaSP", maSP);
                        cmdKhoa.Parameters.AddWithValue("@SoLuong", soLuongBan);
                        cmdKhoa.CommandTimeout = 30; // Timeout 30 giây
                        cmdKhoa.ExecuteNonQuery();

                        MessageBox.Show(
                            "✅ Đã giữ khóa 10 giây!\n\n" +
                            "Transaction khác phải chờ hoặc timeout.",
                            "Demo Locking",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

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

                    // ✅ TRIGGER `trg_CapNhatTonKhoKhiBan` tự động trừ tồn kho

                    trans.Commit();

                    MessageBox.Show(
                        $"✅ Bán thành công!\n\n" +
                        $"Mã GD: {maGD}\n" +
                        $"Sản phẩm: {tenSP}\n" +
                        $"Số lượng: {soLuongBan} {donVi}\n" +
                        $"Thành tiền: {thanhTien:N0} VNĐ",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (SqlException sqlEx)
                {
                    trans.Rollback();

                    // XỬ LÝ LỖI TIMEOUT/BLOCKING (cho demo CLO 2.3)
                    if (sqlEx.Number == -2) // Timeout
                    {
                        MessageBox.Show(
                            "⏰ TIMEOUT - DEMO BLOCKING (CLO 2.3)\n\n" +
                            "❌ Không thể thực hiện giao dịch vì sản phẩm đang bị KHÓA bởi transaction khác!\n\n" +
                            "📌 Đây là hiện tượng BLOCKING:\n" +
                            "- Transaction 1 đang giữ UPDLOCK trên sản phẩm\n" +
                            "- Transaction 2 phải chờ hoặc timeout\n\n" +
                            "✅ Giải pháp: Rút ngắn thời gian transaction, hoặc retry sau.",
                            "Demo CLO 2.3 - Blocking",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else if (sqlEx.Number == 1205) // Deadlock
                    {
                        MessageBox.Show(
                            "💀 DEADLOCK - DEMO CLO 2.3\n\n" +
                            "❌ Transaction này bị chọn làm DEADLOCK VICTIM!\n\n" +
                            "📌 Deadlock xảy ra khi:\n" +
                            "- Transaction A khóa resource X, chờ resource Y\n" +
                            "- Transaction B khóa resource Y, chờ resource X\n\n" +
                            "✅ Giải pháp: Retry transaction hoặc sắp xếp lại thứ tự khóa.",
                            "Demo CLO 2.3 - Deadlock",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(
                            "❌ Lỗi SQL:\n\n" + sqlEx.Message,
                            "Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show(
                        "❌ Lỗi:\n\n" + ex.Message,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
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