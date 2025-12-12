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
            LoadChiTiet();
            LoadComboMaGiaoDich();
            LoadComboSanPham();
        }

        // ========== LOAD DỮ LIỆU ==========
        private void LoadChiTiet(int? maGD = null, int? maSP = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT CTGD.MaChiTiet, CTGD.MaGiaoDich, SP.TenSP, 
                                            CTGD.SoLuong, CTGD.DonGia, CTGD.ThanhTien
                                     FROM ChiTietGiaoDich CTGD
                                     JOIN SanPham SP ON CTGD.MaSP = SP.MaSP
                                     WHERE 1=1";

                    if (maGD.HasValue)
                        query += " AND CTGD.MaGiaoDich = @MaGD";

                    if (maSP.HasValue)
                        query += " AND CTGD.MaSP = @MaSP";

                    query += " ORDER BY CTGD.MaGiaoDich, CTGD.MaChiTiet";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);

                    if (maGD.HasValue)
                        da.SelectCommand.Parameters.AddWithValue("@MaGD", maGD.Value);
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
                        dgvChiTiet.Columns["TenSP"].HeaderText = "Tên sản phẩm";
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

                    // Reset label tổng tiền
                    lblTongTien.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboMaGiaoDich()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT DISTINCT CTGD.MaGiaoDich, 
                                            CONCAT('GD ', CTGD.MaGiaoDich, ' - ', TC.LoaiGiaoDich, ' - ', FORMAT(TC.NgayGiaoDich, 'dd/MM/yyyy')) AS HienThi
                                     FROM ChiTietGiaoDich CTGD
                                     JOIN TaiChinh TC ON CTGD.MaGiaoDich = TC.MaGiaoDich
                                     ORDER BY CTGD.MaGiaoDich";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Thêm dòng "Tất cả"
                    DataRow dr = dt.NewRow();
                    dr["MaGiaoDich"] = DBNull.Value;
                    dr["HienThi"] = "(Tất cả)";
                    dt.Rows.InsertAt(dr, 0);

                    cboMaGiaoDich.DataSource = dt;
                    cboMaGiaoDich.DisplayMember = "HienThi";
                    cboMaGiaoDich.ValueMember = "MaGiaoDich";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load mã giao dịch: " + ex.Message);
            }
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

        // ========== SỰ KIỆN ==========
        private void btnLoc_Click(object sender, EventArgs e)
        {
            int? maGD = null;
            int? maSP = null;

            if (cboMaGiaoDich.SelectedValue != null && cboMaGiaoDich.SelectedValue != DBNull.Value)
                maGD = Convert.ToInt32(cboMaGiaoDich.SelectedValue);

            if (cboSanPham.SelectedValue != null && cboSanPham.SelectedValue != DBNull.Value)
                maSP = Convert.ToInt32(cboSanPham.SelectedValue);

            LoadChiTiet(maGD, maSP);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cboMaGiaoDich.SelectedIndex = 0;
            cboSanPham.SelectedIndex = 0;
            LoadChiTiet();
            lblTongTien.Text = "";
        }

        private void btnTinhTong_Click(object sender, EventArgs e)
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
                MessageBox.Show("Lỗi tính tổng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
