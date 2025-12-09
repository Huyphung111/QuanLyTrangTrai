using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GiaoDienDangNhap
{
    public partial class frmChiTietGiaoDich : Form
    {
        string connectionString = @"Data Source=HUYNE;Initial Catalog=QL_TrangTraiv13;Integrated Security=True;TrustServerCertificate=True";

        SqlConnection conn;
        DataTable dtTaiChinh;
        DataTable dtChiTiet;
        bool isAdding = false;

        public frmChiTietGiaoDich()
        {
            InitializeComponent();
        }

        private void frmChiTietGiaoDich_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            LoadSanPham();
            LoadTaiChinh();
        }

        private void LoadTaiChinh()
        {
            string sql = "SELECT * FROM TaiChinh ORDER BY MaGiaoDich";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            dtTaiChinh = new DataTable();
            da.Fill(dtTaiChinh);
            dgv_TaiChinh.DataSource = dtTaiChinh;
        }

        private void LoadSanPham()
        {
            string sql = "SELECT MaSP, TenSP FROM SanPham";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cbo_SanPham.DataSource = dt;
            cbo_SanPham.DisplayMember = "TenSP";
            cbo_SanPham.ValueMember = "MaSP";
        }

        private void LoadChiTietByMaGD(int maGD)
        {
            string sql = "SELECT * FROM ChiTietGiaoDich WHERE MaGiaoDich = @MaGD";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@MaGD", maGD);
            dtChiTiet = new DataTable();
            da.Fill(dtChiTiet);
            dgv_ChiTiet.DataSource = dtChiTiet;
        }

        // ================== GRID TÀI CHÍNH ==================
        private void dgv_TaiChinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv_TaiChinh.Rows.Count > 0)
            {
                DataGridViewRow row = dgv_TaiChinh.Rows[e.RowIndex];
                int maGD = Convert.ToInt32(row.Cells["MaGiaoDich"].Value);
                txt_MaGiaoDich.Text = maGD.ToString();

                // load chi tiết cho mã giao dịch này
                LoadChiTietByMaGD(maGD);
                ClearChiTietInput();
            }
        }

        // ================== GRID CHI TIẾT ==================
        private void dgv_ChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv_ChiTiet.Rows.Count > 0)
            {
                isAdding = false;
                DataGridViewRow row = dgv_ChiTiet.Rows[e.RowIndex];

                txt_MaChiTiet.Text = row.Cells["MaChiTiet"].Value.ToString();
                txt_MaGiaoDich.Text = row.Cells["MaGiaoDich"].Value.ToString();
                cbo_SanPham.SelectedValue = Convert.ToInt32(row.Cells["MaSP"].Value);
                txt_SoLuong.Text = row.Cells["SoLuong"].Value.ToString();
                txt_DonGia.Text = row.Cells["DonGia"].Value.ToString();
                txt_ThanhTien.Text = row.Cells["ThanhTien"].Value.ToString();
            }
        }

        private void ClearChiTietInput()
        {
            txt_MaChiTiet.Text = "";
            txt_SoLuong.Text = "";
            txt_DonGia.Text = "";
            txt_ThanhTien.Text = "";
        }

        private void TinhThanhTien()
        {
            if (decimal.TryParse(txt_DonGia.Text, out decimal dg) &&
                decimal.TryParse(txt_SoLuong.Text, out decimal sl))
            {
                txt_ThanhTien.Text = (dg * sl).ToString();
            }
        }

        // ================== THÊM ==================
        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaGiaoDich.Text))
            {
                MessageBox.Show("Hãy chọn một giao dịch ở phía trên trước.");
                return;
            }
            isAdding = true;
            ClearChiTietInput();
            txt_SoLuong.Focus();
        }

        // ================== LƯU (INSERT / UPDATE) ==================
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaGiaoDich.Text))
            {
                MessageBox.Show("Chưa có mã giao dịch.");
                return;
            }

            if (!int.TryParse(txt_SoLuong.Text, out int soLuong) ||
                !decimal.TryParse(txt_DonGia.Text, out decimal donGia))
            {
                MessageBox.Show("Số lượng / Đơn giá không hợp lệ.");
                return;
            }

            TinhThanhTien();
            int maGD = int.Parse(txt_MaGiaoDich.Text);
            int maSP = Convert.ToInt32(cbo_SanPham.SelectedValue);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (isAdding || string.IsNullOrEmpty(txt_MaChiTiet.Text))
                {
                    cmd.CommandText = @"INSERT INTO ChiTietGiaoDich(MaGiaoDich, MaSP, SoLuong, DonGia)
                                        VALUES(@MaGD, @MaSP, @SoLuong, @DonGia)";
                }
                else
                {
                    cmd.CommandText = @"UPDATE ChiTietGiaoDich
                                        SET MaSP=@MaSP, SoLuong=@SoLuong, DonGia=@DonGia
                                        WHERE MaChiTiet=@MaCT";
                    cmd.Parameters.AddWithValue("@MaCT", int.Parse(txt_MaChiTiet.Text));
                }

                cmd.Parameters.AddWithValue("@MaGD", maGD);
                cmd.Parameters.AddWithValue("@MaSP", maSP);
                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                cmd.Parameters.AddWithValue("@DonGia", donGia);

                int kq = cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Lưu chi tiết thành công!");
                    LoadChiTietByMaGD(maGD);
                    isAdding = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // ================== XÓA ==================
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaChiTiet.Text))
            {
                MessageBox.Show("Chưa chọn chi tiết để xóa.");
                return;
            }

            int maCT = int.Parse(txt_MaChiTiet.Text);
            int maGD = int.Parse(txt_MaGiaoDich.Text);

            if (MessageBox.Show("Xóa chi tiết này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM ChiTietGiaoDich WHERE MaChiTiet=@MaCT", conn);
                cmd.Parameters.AddWithValue("@MaCT", maCT);
                int kq = cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Đã xóa.");
                    LoadChiTietByMaGD(maGD);
                    ClearChiTietInput();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // ================== THOÁT ==================
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
