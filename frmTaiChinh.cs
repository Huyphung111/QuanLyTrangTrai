using QuanLyTrangTrai;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QL_TrangTrai
{
    public partial class frmTaiChinh : Form
    {
        private string connectionString = "Data Source=HUYNE;Initial Catalog=QL_TrangTraiv13;Integrated Security=True";

        public frmTaiChinh()
        {
            InitializeComponent();
        }

        private void frmTaiChinh_Load(object sender, EventArgs e)
        {
            // Set giá trị mặc định cho ComboBox và DateTimePicker
            cboLoaiGD.SelectedIndex = 0;
            cboPhuongThuc.SelectedIndex = 0;
            dtpTuNgay.Value = DateTime.Now.AddMonths(-6);
            dtpDenNgay.Value = DateTime.Now;

            LoadGiaoDich();
            LoadNhaCungCap();
            LoadNhanVien();
            TinhThongKe();
        }

        // ========== LOAD DỮ LIỆU ==========
        private void LoadGiaoDich(string loaiGD = "Tất cả", DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT TC.MaGiaoDich, TC.LoaiGiaoDich, TC.SoTien, TC.NgayGiaoDich, 
                                            TC.MoTa, TC.PhuongThucTT, NV.HoTen AS NhanVien, NCC.TenNCC AS NhaCungCap
                                     FROM TaiChinh TC
                                     LEFT JOIN NhanVien NV ON TC.MaNV = NV.MaNV
                                     LEFT JOIN NhaCungCap NCC ON TC.MaNCC = NCC.MaNCC
                                     WHERE 1=1";

                    if (loaiGD != "Tất cả")
                        query += " AND TC.LoaiGiaoDich = @LoaiGD";

                    if (tuNgay.HasValue)
                        query += " AND TC.NgayGiaoDich >= @TuNgay";

                    if (denNgay.HasValue)
                        query += " AND TC.NgayGiaoDich <= @DenNgay";

                    query += " ORDER BY TC.NgayGiaoDich DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);

                    if (loaiGD != "Tất cả")
                        da.SelectCommand.Parameters.AddWithValue("@LoaiGD", loaiGD);
                    if (tuNgay.HasValue)
                        da.SelectCommand.Parameters.AddWithValue("@TuNgay", tuNgay.Value);
                    if (denNgay.HasValue)
                        da.SelectCommand.Parameters.AddWithValue("@DenNgay", denNgay.Value);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvTaiChinh.DataSource = dt;

                    // Đổi tên cột
                    if (dgvTaiChinh.Columns.Count > 0)
                    {
                        dgvTaiChinh.Columns["MaGiaoDich"].HeaderText = "Mã GD";
                        dgvTaiChinh.Columns["LoaiGiaoDich"].HeaderText = "Loại";
                        dgvTaiChinh.Columns["SoTien"].HeaderText = "Số tiền";
                        dgvTaiChinh.Columns["NgayGiaoDich"].HeaderText = "Ngày GD";
                        dgvTaiChinh.Columns["MoTa"].HeaderText = "Mô tả";
                        dgvTaiChinh.Columns["PhuongThucTT"].HeaderText = "PT Thanh toán";
                        dgvTaiChinh.Columns["NhanVien"].HeaderText = "Nhân viên";
                        dgvTaiChinh.Columns["NhaCungCap"].HeaderText = "Nhà cung cấp";

                        // Format số tiền
                        dgvTaiChinh.Columns["SoTien"].DefaultCellStyle.Format = "N0";
                        dgvTaiChinh.Columns["SoTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNhaCungCap()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT MaNCC, TenNCC FROM NhaCungCap";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Thêm dòng trống đầu tiên
                    DataRow dr = dt.NewRow();
                    dr["MaNCC"] = DBNull.Value;
                    dr["TenNCC"] = "(Không chọn)";
                    dt.Rows.InsertAt(dr, 0);

                    cboNhaCungCap.DataSource = dt;
                    cboNhaCungCap.DisplayMember = "TenNCC";
                    cboNhaCungCap.ValueMember = "MaNCC";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load nhà cung cấp: " + ex.Message);
            }
        }

        private void LoadNhanVien()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT MaNV, HoTen FROM NhanVien";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Thêm dòng trống đầu tiên
                    DataRow dr = dt.NewRow();
                    dr["MaNV"] = DBNull.Value;
                    dr["HoTen"] = "(Không chọn)";
                    dt.Rows.InsertAt(dr, 0);

                    cboNhanVien.DataSource = dt;
                    cboNhanVien.DisplayMember = "HoTen";
                    cboNhanVien.ValueMember = "MaNV";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load nhân viên: " + ex.Message);
            }
        }

        // ========== TÍNH THỐNG KÊ ==========
        private void TinhThongKe(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string queryThu = "SELECT ISNULL(SUM(SoTien), 0) FROM TaiChinh WHERE LoaiGiaoDich = N'Thu'";
                    string queryChi = "SELECT ISNULL(SUM(SoTien), 0) FROM TaiChinh WHERE LoaiGiaoDich = N'Chi'";

                    if (tuNgay.HasValue && denNgay.HasValue)
                    {
                        queryThu += " AND NgayGiaoDich BETWEEN @TuNgay AND @DenNgay";
                        queryChi += " AND NgayGiaoDich BETWEEN @TuNgay AND @DenNgay";
                    }

                    SqlCommand cmdThu = new SqlCommand(queryThu, conn);
                    SqlCommand cmdChi = new SqlCommand(queryChi, conn);

                    if (tuNgay.HasValue && denNgay.HasValue)
                    {
                        cmdThu.Parameters.AddWithValue("@TuNgay", tuNgay.Value);
                        cmdThu.Parameters.AddWithValue("@DenNgay", denNgay.Value);
                        cmdChi.Parameters.AddWithValue("@TuNgay", tuNgay.Value);
                        cmdChi.Parameters.AddWithValue("@DenNgay", denNgay.Value);
                    }

                    decimal tongThu = Convert.ToDecimal(cmdThu.ExecuteScalar());
                    decimal tongChi = Convert.ToDecimal(cmdChi.ExecuteScalar());
                    decimal loiNhuan = tongThu - tongChi;

                    lblTongThu.Text = tongThu.ToString("N0") + " đ";
                    lblTongChi.Text = tongChi.ToString("N0") + " đ";
                    lblLoiNhuan.Text = loiNhuan.ToString("N0") + " đ";

                    // Đổi màu lợi nhuận
                    lblLoiNhuan.ForeColor = loiNhuan >= 0 ? Color.Blue : Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính thống kê: " + ex.Message);
            }
        }

        // ========== SỰ KIỆN ==========
        private void btnLoc_Click(object sender, EventArgs e)
        {
            string loaiGD = cboLoaiGD.SelectedItem.ToString();
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            LoadGiaoDich(loaiGD, tuNgay, denNgay);
            TinhThongKe(tuNgay, denNgay);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cboLoaiGD.SelectedIndex = 0;
            dtpTuNgay.Value = DateTime.Now.AddMonths(-6);
            dtpDenNgay.Value = DateTime.Now;

            LoadGiaoDich();
            TinhThongKe();
        }

        private void btnThemChi_Click(object sender, EventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(txtMoTa.Text))
            {
                MessageBox.Show("Vui lòng nhập mô tả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMoTa.Focus();
                return;
            }

            decimal soTien;
            if (!decimal.TryParse(txtSoTien.Text, out soTien) || soTien <= 0)
            {
                MessageBox.Show("Số tiền không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTien.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Lấy mã giao dịch mới
                    string queryMax = "SELECT ISNULL(MAX(MaGiaoDich), 0) + 1 FROM TaiChinh";
                    SqlCommand cmdMax = new SqlCommand(queryMax, conn);
                    int maGD = Convert.ToInt32(cmdMax.ExecuteScalar());

                    // Thêm giao dịch Chi
                    string queryInsert = @"INSERT INTO TaiChinh (MaGiaoDich, LoaiGiaoDich, SoTien, NgayGiaoDich, MoTa, PhuongThucTT, MaNV, MaNCC)
                                           VALUES (@MaGD, N'Chi', @SoTien, GETDATE(), @MoTa, @PhuongThuc, @MaNV, @MaNCC)";

                    SqlCommand cmd = new SqlCommand(queryInsert, conn);
                    cmd.Parameters.AddWithValue("@MaGD", maGD);
                    cmd.Parameters.AddWithValue("@SoTien", soTien);
                    cmd.Parameters.AddWithValue("@MoTa", txtMoTa.Text.Trim());
                    cmd.Parameters.AddWithValue("@PhuongThuc", cboPhuongThuc.SelectedItem.ToString());

                    // Xử lý MaNV
                    if (cboNhanVien.SelectedValue != null && cboNhanVien.SelectedValue != DBNull.Value)
                        cmd.Parameters.AddWithValue("@MaNV", cboNhanVien.SelectedValue);
                    else
                        cmd.Parameters.AddWithValue("@MaNV", DBNull.Value);

                    // Xử lý MaNCC
                    if (cboNhaCungCap.SelectedValue != null && cboNhaCungCap.SelectedValue != DBNull.Value)
                        cmd.Parameters.AddWithValue("@MaNCC", cboNhaCungCap.SelectedValue);
                    else
                        cmd.Parameters.AddWithValue("@MaNCC", DBNull.Value);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm giao dịch Chi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset form
                    txtMoTa.Clear();
                    txtSoTien.Clear();
                    cboPhuongThuc.SelectedIndex = 0;
                    cboNhaCungCap.SelectedIndex = 0;
                    cboNhanVien.SelectedIndex = 0;

                    // Reload
                    LoadGiaoDich();
                    TinhThongKe();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm giao dịch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvTaiChinh.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một giao dịch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã giao dịch đã chọn
            int maGD = Convert.ToInt32(dgvTaiChinh.SelectedRows[0].Cells["MaGiaoDich"].Value);

            // Lấy form cha (GiaoDien)
            GiaoDien mainForm = this.ParentForm as GiaoDien;

            if (mainForm != null)
            {
                // Tạo form chi tiết giao dịch và truyền mã GD
                frmChiTietGiaoDich frmChiTiet = new frmChiTietGiaoDich();

                // Mở form trong panel
                mainForm.OpenFormInPanel(frmChiTiet);
            }
            else
            {
                // Nếu không tìm thấy form cha, mở form mới độc lập
                frmChiTietGiaoDich frmChiTiet = new frmChiTietGiaoDich();
                frmChiTiet.Show();
            }
        }

        private void dgvTaiChinh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int maGD = Convert.ToInt32(dgvTaiChinh.Rows[e.RowIndex].Cells["MaGiaoDich"].Value);
                HienThiChiTiet(maGD);
            }
        }

        private void HienThiChiTiet(int maGD)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT CTGD.MaChiTiet, SP.TenSP, CTGD.SoLuong, CTGD.DonGia, CTGD.ThanhTien
                                     FROM ChiTietGiaoDich CTGD
                                     JOIN SanPham SP ON CTGD.MaSP = SP.MaSP
                                     WHERE CTGD.MaGiaoDich = @MaGD";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@MaGD", maGD);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Giao dịch này không có chi tiết sản phẩm.\n(Có thể là giao dịch Chi thủ công)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Tạo form hiển thị chi tiết
                    Form frmChiTiet = new Form
                    {
                        Text = "Chi tiết giao dịch #" + maGD,
                        Size = new Size(600, 350),
                        StartPosition = FormStartPosition.CenterParent,
                        FormBorderStyle = FormBorderStyle.FixedDialog,
                        MaximizeBox = false,
                        MinimizeBox = false
                    };

                    DataGridView dgv = new DataGridView
                    {
                        Location = new Point(20, 20),
                        Size = new Size(540, 230),
                        DataSource = dt,
                        AllowUserToAddRows = false,
                        ReadOnly = true,
                        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                        BackgroundColor = Color.White
                    };

                    dgv.Columns["MaChiTiet"].HeaderText = "Mã CT";
                    dgv.Columns["TenSP"].HeaderText = "Sản phẩm";
                    dgv.Columns["SoLuong"].HeaderText = "Số lượng";
                    dgv.Columns["DonGia"].HeaderText = "Đơn giá";
                    dgv.Columns["ThanhTien"].HeaderText = "Thành tiền";

                    dgv.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                    dgv.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

                    Button btnDongChiTiet = new Button
                    {
                        Text = "Đóng",
                        Location = new Point(250, 260),
                        Size = new Size(100, 35),
                        BackColor = Color.Gray,
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat
                    };
                    btnDongChiTiet.Click += (s, ev) => frmChiTiet.Close();

                    frmChiTiet.Controls.Add(dgv);
                    frmChiTiet.Controls.Add(btnDongChiTiet);
                    frmChiTiet.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xem chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
