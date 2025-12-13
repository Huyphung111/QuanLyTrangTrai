using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QL_TrangTrai
{
    public partial class frmCongViecNhanVien : Form
    {
        private string connectionString = @"Data Source=HUYNE;Initial Catalog=QL_TrangTraiv13;Integrated Security=True";

        private int _maNguoiDung;
        private int _maNV;
        private int _maLichDangChon = -1;

        public frmCongViecNhanVien(int maNguoiDung)
        {
            InitializeComponent();
            _maNguoiDung = maNguoiDung;
        }

        // Nếu bạn muốn mở form theo MaNV luôn (khỏi cần MaNguoiDung)
        public frmCongViecNhanVien(int maNguoiDung, int maNV) : this(maNguoiDung)
        {
            _maNV = maNV;
        }

        private void frmCongViecNhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                LoadThongTinNhanVien();
                LoadCongViecCuaToi();
                SetupGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load form: " + ex.Message);
            }
        }

        private void SetupGridView()
        {
            dgvCongViec.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCongViec.MultiSelect = false;
            dgvCongViec.ReadOnly = true;
            dgvCongViec.AllowUserToAddRows = false;
            dgvCongViec.AllowUserToDeleteRows = false;
            dgvCongViec.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvCongViec.Columns["MaLich"] != null) dgvCongViec.Columns["MaLich"].HeaderText = "Mã lịch";
            if (dgvCongViec.Columns["TieuDe"] != null) dgvCongViec.Columns["TieuDe"].HeaderText = "Tiêu đề";
            if (dgvCongViec.Columns["NgayBatDau"] != null) dgvCongViec.Columns["NgayBatDau"].HeaderText = "Ngày bắt đầu";
            if (dgvCongViec.Columns["NgayKetThuc"] != null) dgvCongViec.Columns["NgayKetThuc"].HeaderText = "Ngày kết thúc";
            if (dgvCongViec.Columns["TrangThai"] != null) dgvCongViec.Columns["TrangThai"].HeaderText = "Trạng thái";
            if (dgvCongViec.Columns["MoTa"] != null) dgvCongViec.Columns["MoTa"].Visible = false; // mô tả đưa xuống textbox
        }

        private void LoadThongTinNhanVien()
        {
            // Nếu _maNV đã có sẵn thì chỉ lấy HoTen
            if (_maNV > 0)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string q = "SELECT HoTen FROM NhanVien WHERE MaNV = @MaNV";
                    using (SqlCommand cmd = new SqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", _maNV);
                        object ten = cmd.ExecuteScalar();
                        lblHoTen.Text = ten != null ? ten.ToString() : "(Không tìm thấy)";
                        lblMaNV.Text = _maNV.ToString();
                    }
                }
                return;
            }

            // Chuẩn: map MaNguoiDung -> MaNV, HoTen
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT TOP 1 MaNV, HoTen
                    FROM NhanVien
                    WHERE MaNguoiDung = @MaNguoiDung";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNguoiDung", _maNguoiDung);
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            _maNV = Convert.ToInt32(rd["MaNV"]);
                            lblHoTen.Text = rd["HoTen"].ToString();
                            lblMaNV.Text = _maNV.ToString();
                        }
                        else
                        {
                            throw new Exception("Không tìm thấy nhân viên ứng với MaNguoiDung = " + _maNguoiDung);
                        }
                    }
                }
            }
        }

        private void LoadCongViecCuaToi()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT MaLich, TieuDe, MoTa, NgayBatDau, NgayKetThuc, TrangThai
                    FROM LichCongViec
                    WHERE MaNV = @MaNV
                    ORDER BY NgayBatDau DESC, MaLich DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", _maNV);

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    dgvCongViec.DataSource = dt;

                    txtMoTa.Text = "";
                    _maLichDangChon = -1;
                }
            }
        }

        private void dgvCongViec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvCongViec.Rows[e.RowIndex];
            _maLichDangChon = Convert.ToInt32(row.Cells["MaLich"].Value);

            string moTa = row.Cells["MoTa"].Value?.ToString() ?? "";
            txtMoTa.Text = moTa;
        }

        private string GetTrangThaiDangChon()
        {
            if (_maLichDangChon <= 0) return "";
            if (dgvCongViec.SelectedRows.Count == 0) return "";

            return dgvCongViec.SelectedRows[0].Cells["TrangThai"].Value?.ToString() ?? "";
        }

        private void btnDangLam_Click(object sender, EventArgs e)
        {
            if (_maLichDangChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn 1 công việc!");
                return;
            }

            string tt = GetTrangThaiDangChon();
            if (tt == "Hoàn thành")
            {
                MessageBox.Show("Công việc đã hoàn thành rồi, không thể chuyển lại 'Đang làm'.");
                return;
            }
            if (tt == "Đang làm")
            {
                MessageBox.Show("Công việc đang ở trạng thái 'Đang làm' rồi.");
                return;
            }

            UpdateTrangThai("Đang làm");
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            if (_maLichDangChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn 1 công việc!");
                return;
            }

            string tt = GetTrangThaiDangChon();
            if (tt == "Hoàn thành")
            {
                MessageBox.Show("Công việc đã hoàn thành rồi.");
                return;
            }
            if (tt != "Đang làm")
            {
                MessageBox.Show("Muốn hoàn thành thì phải chuyển sang 'Đang làm' trước.");
                return;
            }

            UpdateTrangThai("Hoàn thành");
        }

        private void UpdateTrangThai(string trangThaiMoi)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    UPDATE LichCongViec
                    SET TrangThai = @TrangThai
                    WHERE MaLich = @MaLich AND MaNV = @MaNV";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TrangThai", trangThaiMoi);
                    cmd.Parameters.AddWithValue("@MaLich", _maLichDangChon);
                    cmd.Parameters.AddWithValue("@MaNV", _maNV);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 1)
                    {
                        LoadCongViecCuaToi();
                        MessageBox.Show("Cập nhật trạng thái thành công: " + trangThaiMoi);
                    }
                    else
                    {
                        MessageBox.Show("Không cập nhật được (có thể công việc không thuộc nhân viên này).");
                    }
                }
            }
        }
    }
}
