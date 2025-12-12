using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_TrangTrai
{
    public partial class frmBanHang : Form
    {
        // Connection string - THAY ĐỔI THEO DATABASE CỦA BẠN
        private string connectionString = @"Data Source=HUYNE;Initial Catalog=QL_TrangTraiv13;Integrated Security=True";

        // Biến lưu thông tin sản phẩm
        private int maSP;
        private string tenSP;
        private decimal giaBan;
        private int tonKho;
        private string donVi;

        // Constructor nhận thông tin sản phẩm từ form Quản lý Sản phẩm
        public frmBanHang(int maSP, string tenSP, decimal giaBan, int tonKho, string donVi)
        {
            InitializeComponent();

            this.maSP = maSP;
            this.tenSP = tenSP;
            this.giaBan = giaBan;
            this.tonKho = tonKho;
            this.donVi = donVi;
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            // Load nhân viên
            LoadNhanVien();

            // Load phương thức thanh toán
            cboPhuongThuc.Items.AddRange(new string[] { "Tiền mặt", "Chuyển khoản", "Khác" });
            cboPhuongThuc.SelectedIndex = 0;

            // Set ngày mặc định = hôm nay
            dtpNgayGiaoDich.Value = DateTime.Now;

            // Điền thông tin sản phẩm vào form
            txtMaSP.Text = maSP.ToString();
            txtTenSP.Text = tenSP;
            txtDonVi.Text = donVi;
            txtTonKho.Text = tonKho.ToString() + " " + donVi;
            txtGiaBan.Text = giaBan.ToString("N0") + " VNĐ";

            // Mô tả mặc định
            txtMoTa.Text = "Bán " + tenSP;

            // Focus vào ô số lượng bán
            txtSoLuongBan.Focus();
        }

        private void LoadNhanVien()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT MaNV, HoTen FROM NhanVien";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboNhanVien.DataSource = dt;
                    cboNhanVien.DisplayMember = "HoTen";
                    cboNhanVien.ValueMember = "MaNV";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load nhân viên: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSoLuongBan_TextChanged(object sender, EventArgs e)
        {
            // Tự động tính thành tiền khi thay đổi số lượng
            TinhThanhTien();
        }

        private void TinhThanhTien()
        {
            try
            {
                // Lấy số lượng bán
                if (int.TryParse(txtSoLuongBan.Text, out int soLuongBan) && soLuongBan > 0)
                {
                    decimal thanhTien = soLuongBan * giaBan;
                    lblThanhTien.Text = thanhTien.ToString("N0") + " VNĐ";
                }
                else
                {
                    lblThanhTien.Text = "0 VNĐ";
                }
            }
            catch
            {
                lblThanhTien.Text = "0 VNĐ";
            }
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            // Validation
            if (cboNhanVien.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNhanVien.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoLuongBan.Text))
            {
                MessageBox.Show("Vui lòng nhập số lượng bán!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuongBan.Focus();
                return;
            }

            if (!int.TryParse(txtSoLuongBan.Text, out int soLuongBan) || soLuongBan <= 0)
            {
                MessageBox.Show("Số lượng bán phải là số nguyên dương!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuongBan.Focus();
                return;
            }

            if (soLuongBan > tonKho)
            {
                MessageBox.Show($"Số lượng bán ({soLuongBan}) vượt quá tồn kho ({tonKho})!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuongBan.Focus();
                return;
            }

            // Xác nhận
            decimal thanhTien = soLuongBan * giaBan;
            DialogResult confirm = MessageBox.Show(
                $"Xác nhận bán hàng?\n\n" +
                $"📦 Sản phẩm: {tenSP}\n" +
                $"📊 Số lượng: {soLuongBan} {donVi}\n" +
                $"💰 Thành tiền: {thanhTien:N0} VNĐ",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                // Thực hiện bán hàng
                BanHang(soLuongBan, thanhTien);
            }
        }

        private void BanHang(int soLuongBan, decimal thanhTien)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlTransaction trans = null;

            try
            {
                conn.Open();
                trans = conn.BeginTransaction();

                // Lấy thông tin
                int maNV = Convert.ToInt32(cboNhanVien.SelectedValue);
                string phuongThuc = cboPhuongThuc.SelectedItem.ToString();
                DateTime ngayGD = dtpNgayGiaoDich.Value;
                string moTa = txtMoTa.Text;

                // BƯỚC 1: Lấy MaGiaoDich mới TRƯỚC
                string sqlGetMaGD = "SELECT ISNULL(MAX(MaGiaoDich), 0) + 1 FROM TaiChinh";
                SqlCommand cmdGetMaGD = new SqlCommand(sqlGetMaGD, conn, trans);
                int maGiaoDich = Convert.ToInt32(cmdGetMaGD.ExecuteScalar());

                // BƯỚC 2: Thêm vào TaiChinh
                string sqlTaiChinh = @"
            INSERT INTO TaiChinh (MaGiaoDich, LoaiGiaoDich, SoTien, NgayGiaoDich, MoTa, PhuongThucTT, MaNV)
            VALUES (@MaGiaoDich, N'Thu', @SoTien, @NgayGD, @MoTa, @PhuongThuc, @MaNV)";

                SqlCommand cmdTaiChinh = new SqlCommand(sqlTaiChinh, conn, trans);
                cmdTaiChinh.Parameters.AddWithValue("@MaGiaoDich", maGiaoDich);
                cmdTaiChinh.Parameters.AddWithValue("@SoTien", thanhTien);
                cmdTaiChinh.Parameters.AddWithValue("@NgayGD", ngayGD);
                cmdTaiChinh.Parameters.AddWithValue("@MoTa", moTa);
                cmdTaiChinh.Parameters.AddWithValue("@PhuongThuc", phuongThuc);
                cmdTaiChinh.Parameters.AddWithValue("@MaNV", maNV);
                cmdTaiChinh.ExecuteNonQuery();

                // BƯỚC 3: Lấy MaChiTiet mới
                string sqlGetMaCT = "SELECT ISNULL(MAX(MaChiTiet), 0) + 1 FROM ChiTietGiaoDich";
                SqlCommand cmdGetMaCT = new SqlCommand(sqlGetMaCT, conn, trans);
                int maChiTiet = Convert.ToInt32(cmdGetMaCT.ExecuteScalar());

                // BƯỚC 4: Thêm vào ChiTietGiaoDich (Trigger sẽ tự động trừ tồn kho)
                string sqlChiTiet = @"
            INSERT INTO ChiTietGiaoDich (MaChiTiet, MaGiaoDich, MaSP, SoLuong, DonGia)
            VALUES (@MaChiTiet, @MaGiaoDich, @MaSP, @SoLuong, @DonGia)";

                SqlCommand cmdChiTiet = new SqlCommand(sqlChiTiet, conn, trans);
                cmdChiTiet.Parameters.AddWithValue("@MaChiTiet", maChiTiet);
                cmdChiTiet.Parameters.AddWithValue("@MaGiaoDich", maGiaoDich);
                cmdChiTiet.Parameters.AddWithValue("@MaSP", maSP);
                cmdChiTiet.Parameters.AddWithValue("@SoLuong", soLuongBan);
                cmdChiTiet.Parameters.AddWithValue("@DonGia", giaBan);
                cmdChiTiet.ExecuteNonQuery();

                // Commit transaction
                trans.Commit();

                // Thông báo thành công
                MessageBox.Show(
                    $"✅ THÀNH CÔNG!\n\n" +
                    $"Đã bán thành công:\n" +
                    $"• Sản phẩm: {tenSP}\n" +
                    $"• Số lượng: {soLuongBan} {donVi}\n" +
                    $"• Thành tiền: {thanhTien:N0} VNĐ\n\n" +
                    $"📝 Mã giao dịch: #{maGiaoDich}",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Đóng form và trả kết quả thành công
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Rollback nếu có lỗi
                if (trans != null)
                {
                    trans.Rollback();
                }

                MessageBox.Show(
                    $"❌ LỖI!\n\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Đóng form
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
