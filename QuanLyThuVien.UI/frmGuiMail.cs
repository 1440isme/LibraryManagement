using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace QuanLyThuVien.UI
{
    public partial class frmGuiMail : DevExpress.XtraEditors.XtraForm
    {
        private readonly string _connectionString;
        private int maThanhVien;
        
        public frmGuiMail(int maThanhVien)
        {
            InitializeComponent();
            _connectionString = ConfigurationManager.ConnectionStrings["QuanLyThuVienConnectionString"].ConnectionString;
            this.maThanhVien = maThanhVien;
            LoadMemberDetails();
        }

        private void LoadMemberDetails()
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("SELECT * FROM SachQuaHanTheoThanhVien WHERE MaThanhVien = @MaThanhVien", conn))
                    {
                        cmd.Parameters.AddWithValue("@MaThanhVien", maThanhVien);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtMaThanhVien.Text = reader["MaThanhVien"].ToString();
                                txtTenThanhVien.Text = reader["TenThanhVien"].ToString();
                                txtTongSoSach.Text = reader["TongSoSachQuaHan"].ToString();
                                txtTongNgayQuaHan.Text = reader["TongNgayQuaHan"].ToString();
                                txtTongPhat.Text = Convert.ToDecimal(reader["TongPhat"]).ToString("C");
                                txtDanhSachSach.Text = reader["DanhSachSachQuaHan"].ToString();
                            }
                            else
                            {
                                SetDefaultValues();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin thành viên: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetDefaultValues();
            }
        }

        private void SetDefaultValues()
        {
            txtTongSoSach.Text = "0";
            txtTongNgayQuaHan.Text = "0";
            txtTongPhat.Text = "0 ₫";
            txtDanhSachSach.Text = "Không có sách quá hạn";
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return emailRegex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }

        private void btnGuiMail_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra có sách quá hạn không
                if (txtTongSoSach.Text == "0")
                {
                    MessageBox.Show("Thành viên này không có sách quá hạn để gửi nhắc nhở!", 
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Lấy email của thành viên
                string email = GetMemberEmail();
                if (string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Thành viên này chưa có email trong hệ thống!", 
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Email của thành viên không hợp lệ!", 
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xác nhận gửi email
                var confirmResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn gửi email nhắc nhở đến địa chỉ: {email}?",
                    "Xác nhận gửi email", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult != DialogResult.Yes)
                    return;

                // Gửi email
                SendReminderEmail(email);
                
                MessageBox.Show("Email nhắc nhở đã được gửi thành công!", 
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi email: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetMemberEmail()
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("SELECT Email FROM ThanhVien WHERE MaThanhVien = @MaThanhVien", conn))
                    {
                        cmd.Parameters.AddWithValue("@MaThanhVien", maThanhVien);
                        return cmd.ExecuteScalar()?.ToString();
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        private void SendReminderEmail(string toEmail)
        {
            // Đọc cấu hình email từ App.config
            string smtpHost = ConfigurationManager.AppSettings["SmtpHost"] ?? "smtp.gmail.com";
            int smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"] ?? "587");
            string fromEmail = ConfigurationManager.AppSettings["FromEmail"] ?? "your-email@gmail.com";
            string fromPassword = ConfigurationManager.AppSettings["FromPassword"] ?? "your-app-password";

            var emailBody = BuildEmailBody();

            using (var mail = new MailMessage())
            using (var smtpClient = new SmtpClient(smtpHost))
            {
                smtpClient.Port = smtpPort;
                smtpClient.Credentials = new System.Net.NetworkCredential(fromEmail, fromPassword);
                smtpClient.EnableSsl = true;
                smtpClient.Timeout = 30000; // 30 seconds timeout

                mail.From = new MailAddress(fromEmail, "Thư Viện Đại Học SPKT");
                mail.To.Add(toEmail);
                mail.Subject = "Nhắc Nhở Sách Quá Hạn - Thư Viện Đại Học SPKT";
                mail.Body = emailBody;
                mail.IsBodyHtml = false;

                smtpClient.Send(mail);
            }
        }

        private string BuildEmailBody()
        {
            var emailBody = new StringBuilder();
            emailBody.AppendLine($"Kính gửi {txtTenThanhVien.Text},");
            emailBody.AppendLine();
            emailBody.AppendLine("Chúng tôi xin thông báo rằng bạn hiện có sách chưa trả quá hạn tại thư viện:");
            emailBody.AppendLine();
            emailBody.AppendLine($"• Số lượng sách quá hạn: {txtTongSoSach.Text} cuốn");
            emailBody.AppendLine($"• Tổng số ngày quá hạn: {txtTongNgayQuaHan.Text} ngày");
            emailBody.AppendLine($"• Tổng tiền phạt: {txtTongPhat.Text}");
            emailBody.AppendLine();
            emailBody.AppendLine("Danh sách sách quá hạn:");
            emailBody.AppendLine(txtDanhSachSach.Text);
            emailBody.AppendLine();
            emailBody.AppendLine("Vui lòng đến thư viện để trả sách và thanh toán tiền phạt sớm nhất có thể.");
            emailBody.AppendLine("Để biết thêm chi tiết, xin vui lòng liên hệ với chúng tôi.");
            emailBody.AppendLine();
            emailBody.AppendLine("Trân trọng,");
            emailBody.AppendLine("Ban Quản lý Thư viện");
            
            return emailBody.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}