using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace Đồ_án
{
    public partial class frmChatbotSanPham : Form
    {
        #region Fields

        // Connection string - đổi theo máy của bạn
        private string connectionString = @"Data Source=HUYNE;Initial Catalog=QL_TrangTraiv13;Integrated Security=True";
        private SqlConnection conn;

        #endregion

        #region Constructor

        public frmChatbotSanPham()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Load

        private void frmChatbotSanPham_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);

            // Hiển thị lời chào
            AppendMessage("Bot", "🤖 Xin chào! Tôi là trợ lý ảo của hệ thống quản lý sản phẩm.\n" +
                                 "Bạn có thể hỏi tôi về:\n" +
                                 "• Danh sách sản phẩm\n" +
                                 "• Tìm sản phẩm theo tên\n" +
                                 "• Thông tin chi tiết sản phẩm\n" +
                                 "• Sản phẩm sắp hết hàng\n" +
                                 "• Sản phẩm theo loại (cây trồng, vật nuôi)\n\n" +
                                 "Hãy đặt câu hỏi cho tôi! 😊");
        }

        #endregion

        #region Chat Methods

        /// <summary>
        /// Xử lý khi người dùng gửi tin nhắn
        /// </summary>
        private void btnSend_Click(object sender, EventArgs e)
        {
            string userMessage = txtInput.Text.Trim();

            if (string.IsNullOrEmpty(userMessage))
            {
                MessageBox.Show("Vui lòng nhập câu hỏi!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị tin nhắn của người dùng
            AppendMessage("Bạn", userMessage);
            txtInput.Clear();

            // Xử lý và trả lời
            ProcessUserMessage(userMessage);
        }

        /// <summary>
        /// Xử lý tin nhắn người dùng
        /// </summary>
        private void ProcessUserMessage(string message)
        {
            string response = "";
            message = message.ToLower();

            try
            {
                // Danh sách sản phẩm
                if (message.Contains("danh sách") || message.Contains("tất cả") ||
                    message.Contains("có những") || message.Contains("liệt kê"))
                {
                    response = GetDanhSachSanPham();
                }
                // Tìm sản phẩm theo tên
                else if (message.Contains("tìm") || message.Contains("có") ||
                         message.Contains("thông tin"))
                {
                    string tenSP = ExtractProductName(message);
                    if (!string.IsNullOrEmpty(tenSP))
                    {
                        response = TimSanPham(tenSP);
                    }
                    else
                    {
                        response = "🔍 Bạn muốn tìm sản phẩm nào? Vui lòng nói rõ tên sản phẩm.";
                    }
                }
                // Sản phẩm sắp hết
                else if (message.Contains("sắp hết") || message.Contains("tồn kho thấp") ||
                         message.Contains("cần nhập"))
                {
                    response = GetSanPhamSapHet();
                }
                // Sản phẩm cây trồng
                else if (message.Contains("cây trồng") || message.Contains("rau") ||
                         message.Contains("trái cây"))
                {
                    response = GetSanPhamTheoLoai("Cây trồng");
                }
                // Sản phẩm vật nuôi
                else if (message.Contains("vật nuôi") || message.Contains("thịt") ||
                         message.Contains("trứng"))
                {
                    response = GetSanPhamTheoLoai("Vật nuôi");
                }
                // Giá sản phẩm
                else if (message.Contains("giá") || message.Contains("bao nhiêu"))
                {
                    string tenSP = ExtractProductName(message);
                    if (!string.IsNullOrEmpty(tenSP))
                    {
                        response = GetGiaSanPham(tenSP);
                    }
                    else
                    {
                        response = "💰 Bạn muốn biết giá sản phẩm nào?";
                    }
                }
                // Tổng số sản phẩm
                else if (message.Contains("có bao nhiêu") || message.Contains("số lượng"))
                {
                    response = GetTongSoSanPham();
                }
                // Trợ giúp
                else if (message.Contains("giúp") || message.Contains("hướng dẫn") ||
                         message.Contains("help"))
                {
                    response = "🤖 Tôi có thể giúp bạn:\n\n" +
                               "1️⃣ Xem danh sách sản phẩm: 'cho tôi xem danh sách sản phẩm'\n" +
                               "2️⃣ Tìm sản phẩm: 'tìm sản phẩm [tên]'\n" +
                               "3️⃣ Xem giá: 'giá của [tên sản phẩm]'\n" +
                               "4️⃣ Sản phẩm sắp hết: 'những sản phẩm nào sắp hết?'\n" +
                               "5️⃣ Lọc theo loại: 'sản phẩm cây trồng' hoặc 'sản phẩm vật nuôi'\n" +
                               "6️⃣ Đếm sản phẩm: 'có bao nhiêu sản phẩm?'";
                }
                // Lời chào
                else if (message.Contains("chào") || message.Contains("hello") ||
                         message.Contains("hi"))
                {
                    response = "👋 Xin chào! Tôi có thể giúp gì cho bạn về sản phẩm?";
                }
                // Cảm ơn
                else if (message.Contains("cảm ơn") || message.Contains("thanks"))
                {
                    response = "😊 Không có gì! Tôi luôn sẵn sàng hỗ trợ bạn.";
                }
                // Không hiểu
                else
                {
                    response = "❓ Xin lỗi, tôi không hiểu câu hỏi của bạn.\n" +
                               "Gõ 'giúp' để xem hướng dẫn sử dụng.";
                }

                AppendMessage("Bot", response);
            }
            catch (Exception ex)
            {
                AppendMessage("Bot", "❌ Đã xảy ra lỗi: " + ex.Message);
            }
        }

        /// <summary>
        /// Trích xuất tên sản phẩm từ câu hỏi
        /// </summary>
        private string ExtractProductName(string message)
        {
            // Các từ khóa cần loại bỏ
            string[] keywords = { "tìm", "có", "sản phẩm", "thông tin", "về", "của",
                                  "giá", "bao nhiêu", "không", "à" };

            string result = message.ToLower();
            foreach (string keyword in keywords)
            {
                result = result.Replace(keyword, "");
            }

            return result.Trim();
        }

        /// <summary>
        /// Lấy danh sách sản phẩm
        /// </summary>
        private string GetDanhSachSanPham()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                conn.Open();

                string query = "SELECT TOP 10 TenSP, SoLuongTon, GiaBan, LoaiSP FROM SanPham ORDER BY MaSP DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                string result = "📋 DANH SÁCH SẢN PHẨM (10 mới nhất):\n\n";
                int count = 1;

                while (reader.Read())
                {
                    string tenSP = reader["TenSP"].ToString();
                    int ton = Convert.ToInt32(reader["SoLuongTon"]);
                    decimal gia = Convert.ToDecimal(reader["GiaBan"]);
                    string loai = reader["LoaiSP"].ToString();

                    result += $"{count}. {tenSP}\n";
                    result += $"   📦 Tồn: {ton:N0} | 💰 Giá: {gia:N0}đ | 🏷️ {loai}\n\n";
                    count++;
                }

                reader.Close();

                if (count == 1)
                    return "📋 Không có sản phẩm nào trong hệ thống.";

                return result;
            }
            catch (Exception ex)
            {
                return "❌ Lỗi: " + ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        /// <summary>
        /// Tìm sản phẩm theo tên
        /// </summary>
        private string TimSanPham(string tenSP)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                conn.Open();

                string query = @"SELECT TenSP, LoaiSP, DonVi, SoLuongTon, GiaBan, NgayCapNhat
                                FROM SanPham
                                WHERE TenSP LIKE @TenSP";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenSP", "%" + tenSP + "%");
                SqlDataReader reader = cmd.ExecuteReader();

                string result = "";
                int count = 0;

                while (reader.Read())
                {
                    count++;
                    string ten = reader["TenSP"].ToString();
                    string loai = reader["LoaiSP"].ToString();
                    string donvi = reader["DonVi"].ToString();
                    int ton = Convert.ToInt32(reader["SoLuongTon"]);
                    decimal gia = Convert.ToDecimal(reader["GiaBan"]);
                    DateTime ngay = Convert.ToDateTime(reader["NgayCapNhat"]);

                    result += $"🔍 TÌM THẤY: {ten}\n\n";
                    result += $"🏷️ Loại: {loai}\n";
                    result += $"📏 Đơn vị: {donvi}\n";
                    result += $"📦 Số lượng tồn: {ton:N0}\n";
                    result += $"💰 Giá bán: {gia:N0}đ\n";
                    result += $"📅 Cập nhật: {ngay:dd/MM/yyyy}\n\n";
                }

                reader.Close();

                if (count == 0)
                    return $"❌ Không tìm thấy sản phẩm '{tenSP}'.";

                return result;
            }
            catch (Exception ex)
            {
                return "❌ Lỗi: " + ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        /// <summary>
        /// Lấy sản phẩm sắp hết
        /// </summary>
        private string GetSanPhamSapHet()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                conn.Open();

                string query = "SELECT TenSP, SoLuongTon FROM SanPham WHERE SoLuongTon < 50 ORDER BY SoLuongTon";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                string result = "⚠️ SẢN PHẨM SẮP HẾT (tồn < 50):\n\n";
                int count = 1;

                while (reader.Read())
                {
                    string tenSP = reader["TenSP"].ToString();
                    int ton = Convert.ToInt32(reader["SoLuongTon"]);

                    string icon = ton == 0 ? "🔴" : ton < 20 ? "🟠" : "🟡";
                    result += $"{icon} {count}. {tenSP}: {ton:N0}\n";
                    count++;
                }

                reader.Close();

                if (count == 1)
                    return "✅ Tất cả sản phẩm đều còn đủ hàng!";

                return result;
            }
            catch (Exception ex)
            {
                return "❌ Lỗi: " + ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        /// <summary>
        /// Lấy sản phẩm theo loại
        /// </summary>
        private string GetSanPhamTheoLoai(string loaiSP)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                conn.Open();

                string query = "SELECT TenSP, SoLuongTon, GiaBan FROM SanPham WHERE LoaiSP = @LoaiSP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LoaiSP", loaiSP);
                SqlDataReader reader = cmd.ExecuteReader();

                string icon = loaiSP == "Cây trồng" ? "🌱" : "🐄";
                string result = $"{icon} SẢN PHẨM {loaiSP.ToUpper()}:\n\n";
                int count = 1;

                while (reader.Read())
                {
                    string tenSP = reader["TenSP"].ToString();
                    int ton = Convert.ToInt32(reader["SoLuongTon"]);
                    decimal gia = Convert.ToDecimal(reader["GiaBan"]);

                    result += $"{count}. {tenSP}\n";
                    result += $"   📦 Tồn: {ton:N0} | 💰 Giá: {gia:N0}đ\n\n";
                    count++;
                }

                reader.Close();

                if (count == 1)
                    return $"❌ Không có sản phẩm {loaiSP}.";

                return result;
            }
            catch (Exception ex)
            {
                return "❌ Lỗi: " + ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        /// <summary>
        /// Lấy giá sản phẩm
        /// </summary>
        private string GetGiaSanPham(string tenSP)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                conn.Open();

                string query = "SELECT TenSP, GiaBan, DonVi FROM SanPham WHERE TenSP LIKE @TenSP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenSP", "%" + tenSP + "%");
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string ten = reader["TenSP"].ToString();
                    decimal gia = Convert.ToDecimal(reader["GiaBan"]);
                    string donvi = reader["DonVi"].ToString();

                    reader.Close();
                    return $"💰 Giá sản phẩm '{ten}':\n{gia:N0}đ/{donvi}";
                }
                else
                {
                    reader.Close();
                    return $"❌ Không tìm thấy sản phẩm '{tenSP}'.";
                }
            }
            catch (Exception ex)
            {
                return "❌ Lỗi: " + ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        /// <summary>
        /// Lấy tổng số sản phẩm
        /// </summary>
        private string GetTongSoSanPham()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                conn.Open();

                string query = @"SELECT
                                    COUNT(*) as TongSP,
                                    SUM(SoLuongTon) as TongTon,
                                    (SELECT COUNT(*) FROM SanPham WHERE LoaiSP = N'Cây trồng') as SoCayTrong,
                                    (SELECT COUNT(*) FROM SanPham WHERE LoaiSP = N'Vật nuôi') as SoVatNuoi";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int tongSP = Convert.ToInt32(reader["TongSP"]);
                    int tongTon = reader["TongTon"] != DBNull.Value ? Convert.ToInt32(reader["TongTon"]) : 0;
                    int soCayTrong = Convert.ToInt32(reader["SoCayTrong"]);
                    int soVatNuoi = Convert.ToInt32(reader["SoVatNuoi"]);

                    reader.Close();

                    string result = "📊 THỐNG KÊ SẢN PHẨM:\n\n";
                    result += $"📦 Tổng số loại sản phẩm: {tongSP}\n";
                    result += $"📈 Tổng số lượng tồn kho: {tongTon:N0}\n";
                    result += $"🌱 Sản phẩm cây trồng: {soCayTrong}\n";
                    result += $"🐄 Sản phẩm vật nuôi: {soVatNuoi}\n";

                    return result;
                }

                reader.Close();
                return "❌ Không thể lấy thông tin.";
            }
            catch (Exception ex)
            {
                return "❌ Lỗi: " + ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        /// <summary>
        /// Thêm tin nhắn vào chat box
        /// </summary>
        private void AppendMessage(string sender, string message)
        {
            // Thêm thời gian
            string time = DateTime.Now.ToString("HH:mm");

            // Màu sắc khác nhau cho Bot và User
            if (sender == "Bot")
            {
                rtbChat.SelectionColor = Color.Blue;
                rtbChat.SelectionFont = new Font(rtbChat.Font, FontStyle.Bold);
            }
            else
            {
                rtbChat.SelectionColor = Color.Green;
                rtbChat.SelectionFont = new Font(rtbChat.Font, FontStyle.Bold);
            }

            rtbChat.AppendText($"[{time}] {sender}:\n");

            // Nội dung tin nhắn
            rtbChat.SelectionColor = Color.Black;
            rtbChat.SelectionFont = new Font(rtbChat.Font, FontStyle.Regular);
            rtbChat.AppendText($"{message}\n\n");

            // Scroll xuống cuối
            rtbChat.SelectionStart = rtbChat.Text.Length;
            rtbChat.ScrollToCaret();
        }

        #endregion

        #region Events

        /// <summary>
        /// Nhấn Enter để gửi tin nhắn
        /// </summary>
        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSend_Click(sender, e);
            }
        }

        #endregion
    }
}
