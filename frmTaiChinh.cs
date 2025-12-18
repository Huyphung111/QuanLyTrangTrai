using QuanLyTrangTrai;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace QL_TrangTrai
{
    public partial class frmTaiChinh : Form
    {
        private string connectionString = "Data Source=HUYNE;Initial Catalog=QL_TrangTraiv13;Integrated Security=True";

        private int _maNguoiDung = 0;
        private int _maVaiTro = 1;
        public frmTaiChinh()
        {
            InitializeComponent();
            _maNguoiDung = 0;
            _maVaiTro = 1;
        }

        public frmTaiChinh(int maNguoiDung, int maVaiTro)
        {
            InitializeComponent();
            _maNguoiDung = maNguoiDung;
            _maVaiTro = maVaiTro;
        }
        private void frmTaiChinh_Load(object sender, EventArgs e)
        {
         

            // Set giá trị mặc định cho ComboBox (có kiểm tra)
            if (cboLoaiGD.Items.Count > 0)
                cboLoaiGD.SelectedIndex = 0;

            // Set DateTimePicker
            dtpTuNgay.Value = DateTime.Now.AddMonths(-6);
            dtpDenNgay.Value = DateTime.Now;

            LoadGiaoDich();
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

        
      

        // ========== TÍNH THỐNG KÊ ==========
        // ========== TÍNH THỐNG KÊ THEO THÁNG ==========
        private void TinhThongKe(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Nếu có chọn khoảng thời gian cụ thể
                    if (tuNgay.HasValue && denNgay.HasValue)
                    {
                        string queryThu = "SELECT ISNULL(SUM(SoTien), 0) FROM TaiChinh WHERE LoaiGiaoDich = N'Thu' AND NgayGiaoDich BETWEEN @TuNgay AND @DenNgay";
                        string queryChi = "SELECT ISNULL(SUM(SoTien), 0) FROM TaiChinh WHERE LoaiGiaoDich = N'Chi' AND NgayGiaoDich BETWEEN @TuNgay AND @DenNgay";

                        SqlCommand cmdThu = new SqlCommand(queryThu, conn);
                        SqlCommand cmdChi = new SqlCommand(queryChi, conn);

                        cmdThu.Parameters.AddWithValue("@TuNgay", tuNgay.Value);
                        cmdThu.Parameters.AddWithValue("@DenNgay", denNgay.Value);
                        cmdChi.Parameters.AddWithValue("@TuNgay", tuNgay.Value);
                        cmdChi.Parameters.AddWithValue("@DenNgay", denNgay.Value);

                        decimal tongThu = Convert.ToDecimal(cmdThu.ExecuteScalar());
                        decimal tongChi = Convert.ToDecimal(cmdChi.ExecuteScalar());
                        decimal loiNhuan = tongThu - tongChi;

                        lblTongThu.Text = tongThu.ToString("N0") + " đ";
                        lblTongChi.Text = tongChi.ToString("N0") + " đ";
                        lblLoiNhuan.Text = loiNhuan.ToString("N0") + " đ";

                        // Đổi màu lợi nhuận
                        lblLoiNhuan.ForeColor = loiNhuan >= 0 ? Color.Blue : Color.Red;
                    }
                    else
                    {
                        // ✅ SỬ DỤNG FUNCTION fn_TinhLaiLoTheoThang
                        // Lấy tháng/năm hiện tại
                        int thang = DateTime.Now.Month;
                        int nam = DateTime.Now.Year;

                        // Tính Tổng Thu
                        string queryThu = "SELECT ISNULL(SUM(SoTien), 0) FROM TaiChinh WHERE MONTH(NgayGiaoDich) = @Thang AND YEAR(NgayGiaoDich) = @Nam AND LoaiGiaoDich = N'Thu'";
                        SqlCommand cmdThu = new SqlCommand(queryThu, conn);
                        cmdThu.Parameters.AddWithValue("@Thang", thang);
                        cmdThu.Parameters.AddWithValue("@Nam", nam);
                        decimal tongThu = Convert.ToDecimal(cmdThu.ExecuteScalar());

                        // Tính Tổng Chi
                        string queryChi = "SELECT ISNULL(SUM(SoTien), 0) FROM TaiChinh WHERE MONTH(NgayGiaoDich) = @Thang AND YEAR(NgayGiaoDich) = @Nam AND LoaiGiaoDich = N'Chi'";
                        SqlCommand cmdChi = new SqlCommand(queryChi, conn);
                        cmdChi.Parameters.AddWithValue("@Thang", thang);
                        cmdChi.Parameters.AddWithValue("@Nam", nam);
                        decimal tongChi = Convert.ToDecimal(cmdChi.ExecuteScalar());

                        // ✅ GỌI FUNCTION fn_TinhLaiLoTheoThang
                        string queryFunction = "SELECT dbo.fn_TinhLaiLoTheoThang(@Thang, @Nam)";
                        SqlCommand cmdFunction = new SqlCommand(queryFunction, conn);
                        cmdFunction.Parameters.AddWithValue("@Thang", thang);
                        cmdFunction.Parameters.AddWithValue("@Nam", nam);
                        decimal loiNhuan = Convert.ToDecimal(cmdFunction.ExecuteScalar());

                        lblTongThu.Text = tongThu.ToString("N0") + " đ";
                        lblTongChi.Text = tongChi.ToString("N0") + " đ";
                        lblLoiNhuan.Text = loiNhuan.ToString("N0") + " đ";

                        // Đổi màu lợi nhuận
                        lblLoiNhuan.ForeColor = loiNhuan >= 0 ? Color.Blue : Color.Red;
                    }
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

        private void btn_xembaocaohomnay_Click(object sender, EventArgs e)
        {
            DateTime ngayBaoCao = DateTime.Today; // Hôm nay

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_BaoCaoTaiChinhNgay", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NgayBaoCao", ngayBaoCao);

                        // Vì procedure dùng PRINT để xuất báo cáo dạng text
                        // Ta sẽ bắt output từ SqlInfoMessageEventHandler
                        StringBuilder baoCao = new StringBuilder();

                        conn.InfoMessage += (s, args) =>
                        {
                            baoCao.AppendLine(args.Message);
                        };

                        cmd.ExecuteNonQuery();

                        // Nếu không có dữ liệu giao dịch nào trong ngày
                        if (baoCao.Length == 0)
                        {
                            MessageBox.Show($"Không có giao dịch tài chính nào trong ngày {ngayBaoCao:dd/MM/yyyy}.",
                                            "Báo cáo hôm nay",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                            return;
                        }

                        // Hiển thị báo cáo trong một Form mới đẹp mắt
                        HienThiBaoCaoText(baoCao.ToString(), ngayBaoCao);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo: " + ex.Message,
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        // Phương thức phụ để hiển thị báo cáo dạng text đẹp (dùng RichTextBox hoặc TextBox đa dòng)
        private void HienThiBaoCaoText(string noiDungBaoCao, DateTime ngay)
        {
            Form frmBaoCao = new Form
            {
                Text = $"BÁO CÁO TÀI CHÍNH NGÀY {ngay:dd/MM/yyyy}",
                Size = new Size(800, 600),
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            RichTextBox rtb = new RichTextBox
            {
                Location = new Point(20, 20),
                Size = new Size(740, 480),
                Font = new Font("Consolas", 11F), // Font cố định để căn lề đẹp
                BackColor = Color.Black,
                ForeColor = Color.LimeGreen, // Màu chữ kiểu "Matrix" cho chuyên nghiệp :)
                ReadOnly = true,
                WordWrap = false,
                ScrollBars = RichTextBoxScrollBars.Vertical
            };

            // Tô màu đặc biệt cho các dòng tổng kết
            string[] lines = noiDungBaoCao.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            rtb.Text = string.Join("\n", lines);

            // Tô màu nổi bật cho tiêu đề và tổng kết
            rtb.Select(0, rtb.Text.IndexOf('\n') > 0 ? rtb.Text.IndexOf('\n') : rtb.Text.Length);
            rtb.SelectionColor = Color.Yellow;
            rtb.SelectionFont = new Font(rtb.Font, FontStyle.Bold);

            // Tô màu cho dòng "TỔNG KẾT:"
            int indexTongKet = rtb.Text.IndexOf("TỔNG KẾT:");
            if (indexTongKet >= 0)
            {
                rtb.Select(indexTongKet, rtb.Text.Substring(indexTongKet).IndexOf('\n') + 1);
                rtb.SelectionColor = Color.Cyan;
                rtb.SelectionFont = new Font(rtb.Font, FontStyle.Bold);
            }

            // Tô màu cho các dòng tổng thu, chi, chênh lệch
            string[] keywords = { "Tổng Thu:", "Tổng Chi:", "Chênh lệch:" };
            foreach (string kw in keywords)
            {
                int index = rtb.Text.IndexOf(kw);
                if (index >= 0)
                {
                    int lineStart = rtb.GetFirstCharIndexFromLine(rtb.GetLineFromCharIndex(index));
                    int lineEnd = rtb.Text.IndexOf('\n', index);
                    if (lineEnd == -1) lineEnd = rtb.Text.Length;

                    rtb.Select(lineStart, lineEnd - lineStart);
                    rtb.SelectionColor = kw.Contains("Thu") ? Color.Lime :
                                         kw.Contains("Chi") ? Color.OrangeRed :
                                         Color.Yellow;
                    rtb.SelectionFont = new Font(rtb.Font, FontStyle.Bold);
                }
            }

            rtb.SelectionStart = 0; // Cuộn lên đầu

            Button btnDong = new Button
            {
                Text = "Đóng",
                Size = new Size(100, 40),
                Location = new Point(340, 520),
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnDong.Click += (s, ev) => frmBaoCao.Close();

            Button btnIn = new Button
            {
                Text = "In báo cáo",
                Size = new Size(120, 40),
                Location = new Point(460, 520),
                BackColor = Color.RoyalBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            btnIn.Click += (s, ev) =>
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (senderPrint, ePrint) =>
                {
                    ePrint.Graphics.DrawString(rtb.Text, new Font("Consolas", 10), Brushes.Black, 50, 50);
                };
                PrintDialog printDlg = new PrintDialog { Document = pd };
                if (printDlg.ShowDialog() == DialogResult.OK)
                    pd.Print();
            };

            frmBaoCao.Controls.Add(rtb);
            frmBaoCao.Controls.Add(btnDong);
            frmBaoCao.Controls.Add(btnIn);

            frmBaoCao.ShowDialog();
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}







