using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GiaoDienDangNhap
{
    public partial class frmTaiChinh : Form
    {
        string connectionString = @"Data Source=HUYNE;Initial Catalog=QL_TrangTraiv13;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection conn;
        DataTable dtTaiChinh;
        bool isAdding = false;

        public frmTaiChinh()
        {
            InitializeComponent();
        }

        private void frmTaiChinh_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            LoadComboLoai();
            LoadComboPTTT();
            LoadNhanVien();
            LoadNhaCungCap();
            LoadTaiChinh();
        }

        // ============= LOAD COMBO =============
        private void LoadComboLoai()
        {
            cbo_LoaiGD.Items.Clear();
            cbo_LoaiGD.Items.Add("Thu");
            cbo_LoaiGD.Items.Add("Chi");
            cbo_LoaiGD.SelectedIndex = 0;
        }

        private void LoadComboPTTT()
        {
            cbo_PhuongThucTT.Items.Clear();
            cbo_PhuongThucTT.Items.Add("Tiền mặt");
            cbo_PhuongThucTT.Items.Add("Chuyển khoản");
            cbo_PhuongThucTT.Items.Add("Khác");
            cbo_PhuongThucTT.SelectedIndex = 0;
        }

        private void LoadNhanVien()
        {
            string sql = "SELECT MaNV, HoTen FROM NhanVien";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbo_NhanVien.DataSource = dt;
            cbo_NhanVien.DisplayMember = "HoTen";
            cbo_NhanVien.ValueMember = "MaNV";
        }

        private void LoadNhaCungCap()
        {
            string sql = "SELECT MaNCC, TenNCC FROM NhaCungCap";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // thêm dòng trống = NULL
            DataRow r = dt.NewRow();
            r["MaNCC"] = DBNull.Value;
            r["TenNCC"] = "<Không>";
            dt.Rows.InsertAt(r, 0);

            cbo_NhaCungCap.DataSource = dt;
            cbo_NhaCungCap.DisplayMember = "TenNCC";
            cbo_NhaCungCap.ValueMember = "MaNCC";
        }

        // ============= LOAD GRID =============
        private void LoadTaiChinh()
        {
            string sql = "SELECT * FROM TaiChinh ORDER BY MaGiaoDich";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            dtTaiChinh = new DataTable();
            da.Fill(dtTaiChinh);
            dgv_TaiChinh.DataSource = dtTaiChinh;
        }

        // ============= HỖ TRỢ =============
        private void ClearInput()
        {
            txt_MaGD.Text = "";
            cbo_LoaiGD.SelectedIndex = 0;
            txt_SoTien.Text = "";
            dtp_NgayGD.Value = DateTime.Now;
            txt_MoTa.Text = "";
            cbo_PhuongThucTT.SelectedIndex = 0;
            if (cbo_NhanVien.Items.Count > 0) cbo_NhanVien.SelectedIndex = 0;
            if (cbo_NhaCungCap.Items.Count > 0) cbo_NhaCungCap.SelectedIndex = 0;
        }

        private void FillInputFromRow(DataGridViewRow row)
        {
            if (row == null) return;

            txt_MaGD.Text = row.Cells["MaGiaoDich"].Value.ToString();
            cbo_LoaiGD.SelectedItem = row.Cells["LoaiGiaoDich"].Value.ToString();
            txt_SoTien.Text = row.Cells["SoTien"].Value.ToString();
            dtp_NgayGD.Value = Convert.ToDateTime(row.Cells["NgayGiaoDich"].Value);
            txt_MoTa.Text = row.Cells["MoTa"].Value.ToString();
            cbo_PhuongThucTT.SelectedItem = row.Cells["PhuongThucTT"].Value.ToString();

            if (row.Cells["MaNV"].Value != DBNull.Value)
                cbo_NhanVien.SelectedValue = Convert.ToInt32(row.Cells["MaNV"].Value);

            if (row.Cells["MaNCC"].Value == DBNull.Value || row.Cells["MaNCC"].Value == null)
                cbo_NhaCungCap.SelectedIndex = 0;      // <Không>
            else
                cbo_NhaCungCap.SelectedValue = Convert.ToInt32(row.Cells["MaNCC"].Value);
        }

        // ============= SỰ KIỆN GRID =============
        private void dgv_TaiChinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                isAdding = false;
                DataGridViewRow row = dgv_TaiChinh.Rows[e.RowIndex];
                FillInputFromRow(row);
            }
        }

        // ============= NÚT THÊM =============
        private void btn_Them_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearInput();
            txt_SoTien.Focus();
        }

        // ============= NÚT LƯU (INSERT / UPDATE) =============
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_SoTien.Text))
            {
                MessageBox.Show("Vui lòng nhập số tiền.");
                return;
            }

            decimal soTien;
            if (!decimal.TryParse(txt_SoTien.Text, out soTien))
            {
                MessageBox.Show("Số tiền không hợp lệ.");
                return;
            }

            string loai = cbo_LoaiGD.Text;
            string moTa = txt_MoTa.Text;
            string pttt = cbo_PhuongThucTT.Text;
            DateTime ngay = dtp_NgayGD.Value;
            int maNV = Convert.ToInt32(cbo_NhanVien.SelectedValue);
            object maNCC = cbo_NhaCungCap.SelectedValue; // có thể null

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (isAdding || string.IsNullOrEmpty(txt_MaGD.Text))
                {
                    cmd.CommandText = @"INSERT INTO TaiChinh
                                        (LoaiGiaoDich, SoTien, NgayGiaoDich, MoTa, PhuongThucTT, MaNV, MaNCC)
                                        VALUES(@Loai, @SoTien, @Ngay, @MoTa, @PTTT, @MaNV, @MaNCC)";
                }
                else
                {
                    cmd.CommandText = @"UPDATE TaiChinh
                                        SET LoaiGiaoDich=@Loai, SoTien=@SoTien, NgayGiaoDich=@Ngay,
                                            MoTa=@MoTa, PhuongThucTT=@PTTT, MaNV=@MaNV, MaNCC=@MaNCC
                                        WHERE MaGiaoDich=@MaGD";
                    cmd.Parameters.AddWithValue("@MaGD", int.Parse(txt_MaGD.Text));
                }

                cmd.Parameters.AddWithValue("@Loai", loai);
                cmd.Parameters.AddWithValue("@SoTien", soTien);
                cmd.Parameters.AddWithValue("@Ngay", ngay);
                cmd.Parameters.AddWithValue("@MoTa", moTa);
                cmd.Parameters.AddWithValue("@PTTT", pttt);
                cmd.Parameters.AddWithValue("@MaNV", maNV);

                if (maNCC == null || maNCC == DBNull.Value)
                    cmd.Parameters.AddWithValue("@MaNCC", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@MaNCC", maNCC);

                int kq = cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Lưu dữ liệu thành công!");
                    LoadTaiChinh();
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

        // ============= NÚT XÓA =============
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaGD.Text))
            {
                MessageBox.Show("Chưa chọn giao dịch để xóa.");
                return;
            }

            int maGD = int.Parse(txt_MaGD.Text);

            if (MessageBox.Show("Xóa giao dịch này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM TaiChinh WHERE MaGiaoDich=@MaGD", conn);
                cmd.Parameters.AddWithValue("@MaGD", maGD);
                int kq = cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Đã xóa.");
                    LoadTaiChinh();
                    ClearInput();
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

        // ============= NÚT THOÁT =============
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
