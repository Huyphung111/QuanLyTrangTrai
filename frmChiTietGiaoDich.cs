using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QL_TrangTrai
{
    public partial class frmChiTietGiaoDich : Form
    {
        private string connectionString = "Data Source=HUYNE;Initial Catalog=QL_TrangTraiv13;Integrated Security=True";

        public frmChiTietGiaoDich()
        {
            InitializeComponent();
        }

        private void frmChiTietGiaoDich_Load(object sender, EventArgs e)
        {
            LoadComboLoaiGD();
            LoadComboSanPham();
            LoadChiTiet(); // Load tất cả dữ liệu khi mở form
            TinhTong(); // Tính tổng luôn
        }

        // ========== LOAD DỮ LIỆU ==========
        private void LoadChiTiet(string loaiGD = "Tất cả", int? maSP = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Query lấy tất cả chi tiết giao dịch + loại giao dịch
                    // Sử dụng CASE để lấy TenSP hoặc TenHangMua tùy theo MaSP có NULL hay không
                    string query = @"SELECT CTGD.MaChiTiet, CTGD.MaGiaoDich, 
                                            CASE 
                                                WHEN CTGD.MaSP IS NOT NULL THEN SP.TenSP 
                                                ELSE CTGD.TenHangMua 
                                            END AS TenHang,
                                            TC.LoaiGiaoDich AS Loai,
                                            ISNULL(CTGD.DonVi, SP.DonVi) AS DonVi,
                                            CTGD.SoLuong, CTGD.DonGia, CTGD.ThanhTien
                                     FROM ChiTietGiaoDich CTGD
                                     LEFT JOIN SanPham SP ON CTGD.MaSP = SP.MaSP
                                     JOIN TaiChinh TC ON CTGD.MaGiaoDich = TC.MaGiaoDich
                                     WHERE 1=1";

                    // Lọc theo loại giao dịch
                    if (loaiGD == "Thu")
                        query += " AND TC.LoaiGiaoDich = N'Thu'";
                    else if (loaiGD == "Chi")
                        query += " AND TC.LoaiGiaoDich = N'Chi'";

                    // Lọc theo sản phẩm (chỉ áp dụng khi có MaSP)
                    if (maSP.HasValue)
                        query += " AND CTGD.MaSP = @MaSP";

                    query += " ORDER BY TC.LoaiGiaoDich DESC, CTGD.MaGiaoDich, CTGD.MaChiTiet";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);

                    if (maSP.HasValue)
                        da.SelectCommand.Parameters.AddWithValue("@MaSP", maSP.Value);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvChiTiet.DataSource = dt;

                    // Đổi tên cột
                    if (dgvChiTiet.Columns.Count > 0)
                    {
                        dgvChiTiet.Columns["MaChiTiet"].HeaderText = "Mã CT";
                        dgvChiTiet.Columns["MaGiaoDich"].HeaderText = "Mã GD";
                        dgvChiTiet.Columns["TenHang"].HeaderText = "Tên hàng/SP";
                        dgvChiTiet.Columns["Loai"].HeaderText = "Loại";
                        dgvChiTiet.Columns["DonVi"].HeaderText = "ĐVT";
                        dgvChiTiet.Columns["SoLuong"].HeaderText = "Số lượng";
                        dgvChiTiet.Columns["DonGia"].HeaderText = "Đơn giá";
                        dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành tiền";

                        // Format số tiền
                        dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                        dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                        dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvChiTiet.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    // Cập nhật số dòng
                    lblSoDong.Text = dt.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboLoaiGD()
        {
            // Thêm các lựa chọn lọc theo loại giao dịch
            cboMaGiaoDich.Items.Clear();
            cboMaGiaoDich.Items.Add("Tất cả");
            cboMaGiaoDich.Items.Add("Thu (Bán hàng)");
            cboMaGiaoDich.Items.Add("Chi (Mua hàng)");
            cboMaGiaoDich.SelectedIndex = 0;
        }

        private void LoadComboSanPham()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT DISTINCT SP.MaSP, SP.TenSP
                                     FROM ChiTietGiaoDich CTGD
                                     JOIN SanPham SP ON CTGD.MaSP = SP.MaSP
                                     ORDER BY SP.TenSP";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Thêm dòng "Tất cả"
                    DataRow dr = dt.NewRow();
                    dr["MaSP"] = DBNull.Value;
                    dr["TenSP"] = "(Tất cả)";
                    dt.Rows.InsertAt(dr, 0);

                    cboSanPham.DataSource = dt;
                    cboSanPham.DisplayMember = "TenSP";
                    cboSanPham.ValueMember = "MaSP";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load sản phẩm: " + ex.Message);
            }
        }

        // ========== TÍNH TỔNG ==========
        private void TinhTong()
        {
            try
            {
                decimal tongTien = 0;

                foreach (DataGridViewRow row in dgvChiTiet.Rows)
                {
                    if (row.Cells["ThanhTien"].Value != null && row.Cells["ThanhTien"].Value != DBNull.Value)
                    {
                        tongTien += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
                    }
                }

                lblTongTien.Text = tongTien.ToString("N0") + " đ";
            }
            catch (Exception ex)
            {
                lblTongTien.Text = "0 đ";
            }
        }

        // ========== SỰ KIỆN ==========
        private void btnLoc_Click(object sender, EventArgs e)
        {
            // Lấy loại giao dịch được chọn
            string loaiGD = "Tất cả";
            string selected = cboMaGiaoDich.SelectedItem.ToString();

            if (selected.Contains("Thu"))
                loaiGD = "Thu";
            else if (selected.Contains("Chi"))
                loaiGD = "Chi";

            // Lấy sản phẩm được chọn
            int? maSP = null;
            if (cboSanPham.SelectedValue != null && cboSanPham.SelectedValue != DBNull.Value)
                maSP = Convert.ToInt32(cboSanPham.SelectedValue);

            // Load dữ liệu theo bộ lọc
            LoadChiTiet(loaiGD, maSP);

            // Tính tổng sau khi lọc
            TinhTong();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cboMaGiaoDich.SelectedIndex = 0;
            cboSanPham.SelectedIndex = 0;
            LoadChiTiet();
            TinhTong();
        }

        private void btnTinhTong_Click(object sender, EventArgs e)
        {
            TinhTong();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra có chọn dòng nào không
            if (dgvChiTiet.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn chi tiết giao dịch cần xóa!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // ✅ LẤY MaChiTiet thay vì MaGiaoDich
            int maChiTiet = Convert.ToInt32(dgvChiTiet.SelectedRows[0].Cells["MaChiTiet"].Value);
            string tenHang = dgvChiTiet.SelectedRows[0].Cells["TenHang"].Value?.ToString() ?? "";

            // Xác nhận xóa
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa chi tiết này?\n\n" +
                $"Mã chi tiết: {maChiTiet}\n" +
                $"Tên hàng: {tenHang}\n\n" +
                $"Hành động này không thể hoàn tác!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Gọi stored procedure
                        SqlCommand cmd = new SqlCommand("sp_XoaChiTietGiaoDich", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        // ✅ TRUYỀN @MaChiTiet
                        cmd.Parameters.AddWithValue("@MaChiTiet", maChiTiet);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Xóa chi tiết giao dịch thành công!",
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                        // Reload dữ liệu
                        LoadChiTiet();
                        TinhTong();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi xóa chi tiết: " + ex.Message,
                                    "Lỗi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message,
                                    "Lỗi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }
    }
}