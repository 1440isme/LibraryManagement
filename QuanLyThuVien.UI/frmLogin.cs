using DevExpress.XtraEditors;
using QuanLyThuVien.BLL.Services;
using QuanLyThuVien.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.UI
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        private NguoiDungService _nguoiDungService;
        private readonly string _integratedConnString; 
        private readonly string _sqlAuthConnStringTemplate;

        public class UserSession
        {
            public static string CurrentUserName { get; set; }
            public static string CurrentUserPassword { get; set; } 
            public static Users CurrentUser { get; set; }
            public static string ConnectionString { get; set; }

            public static void Clear()
            {
                CurrentUserName = null;
                CurrentUserPassword = null;
                CurrentUser = null;
                ConnectionString = null;
            }
        }
        public frmLogin()
        {
            InitializeComponent();
            _integratedConnString = ConfigurationManager.ConnectionStrings["QuanLyThuVien_Integrated"]?.ConnectionString;
            _sqlAuthConnStringTemplate = ConfigurationManager.ConnectionStrings["QuanLyThuVienConnectionString"]?.ConnectionString;

            if (string.IsNullOrEmpty(_integratedConnString))
            {
                throw new Exception("Không tìm thấy connection string 'QuanLyThuVien_Integrated' trong app.config!");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            ConnectionStringProvider.SetConnectionString(_integratedConnString);
            
            var dbContext = ContextFactory.CreateContext();
            var userRepository = new GenericRepository<Users>(dbContext);
            _nguoiDungService = new NguoiDungService(userRepository);

            this.AcceptButton = btnXacNhan;
            this.CancelButton = btnThoat;

            txtUsername.Focus();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim(); 

            if (string.IsNullOrEmpty(username))
            {
                XtraMessageBox.Show("Tên đăng nhập không được để trống!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                XtraMessageBox.Show("Mật khẩu không được để trống!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return;
            }
            if (!ValidateUser(username, password))
            {
                return; 
            }

            string sqlAuthConnString = BuildSqlAuthConnectionString(username, password);
            if (string.IsNullOrEmpty(sqlAuthConnString))
            {
                XtraMessageBox.Show("Không thể tạo connection string SQL Authentication!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!TestSqlAuthConnection(sqlAuthConnString))
            {
                XtraMessageBox.Show("Lỗi kết nối database với tài khoản này! Vui lòng liên hệ admin.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveUserSession(username, password, sqlAuthConnString);

            var user = _nguoiDungService.GetAllUsers().FirstOrDefault(u => u.UserName == username);

            frmMain frm = new frmMain(user, sqlAuthConnString); 
            frm.FormClosed += FrmMain_FormClosed;
            frm.Show();
            this.Hide();
        }
        private bool ValidateUser(string username, string password)
        {
            try
            {
                bool userExists = _nguoiDungService.checkUserExist(username);
                if (!userExists)
                {
                    XtraMessageBox.Show("Tên đăng nhập không tồn tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUsername.Focus();
                    return false;
                }

                var user = _nguoiDungService.GetAllUsers().FirstOrDefault(u => u.UserName == username);
                if (user == null || !user.PasswordHash.Equals(password)) 
                {
                    XtraMessageBox.Show("Mật khẩu không đúng!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassword.Focus();
                    txtPassword.SelectAll();
                    return false;
                }

                if ((bool)!user.IsActive)
                {
                    XtraMessageBox.Show("Tài khoản này đã bị khóa! Vui lòng liên hệ admin.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi kiểm tra thông tin đăng nhập: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private string BuildSqlAuthConnectionString(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(_sqlAuthConnStringTemplate))
                {
                    XtraMessageBox.Show("Không tìm thấy template SQL Auth trong app.config!", "Lỗi cấu hình",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                string connString = string.Format(_sqlAuthConnStringTemplate, username, password);

                System.Diagnostics.Debug.WriteLine($"SQL Auth Conn: {connString}");

                return connString;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi tạo connection string: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private bool TestSqlAuthConnection(string connectionString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    System.Diagnostics.Debug.WriteLine($"Kết nối thành công với user: {UserSession.CurrentUserName}");

                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Sach]", conn))
                    {
                        int bookCount = (int)cmd.ExecuteScalar();
                        System.Diagnostics.Debug.WriteLine($"Số sách trong DB: {bookCount}");
                    }

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("EXEC [dbo].[TimKiemSach]", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                System.Diagnostics.Debug.WriteLine("Proc TimKiemSach chạy OK");
                            }
                        }
                    }
                    catch (SqlException procEx)
                    {
                        System.Diagnostics.Debug.WriteLine($"Proc test warning: {procEx.Message}");
                    }

                    return true;
                }
            }
            catch (SqlException sqlEx)
            {
                string errorDetails = $"SQL Error #{sqlEx.Number}: {sqlEx.Message}\n" +
                                    $"State: {sqlEx.State}, Class: {sqlEx.Class}\n" +
                                    $"Server: {sqlEx.Server}\n" +
                                    $"User: {UserSession.CurrentUserName}";

                System.Diagnostics.Debug.WriteLine(errorDetails);

                if (sqlEx.Number == 18456) 
                {
                    XtraMessageBox.Show("Tài khoản hoặc mật khẩu SQL Server không đúng! Vui lòng liên hệ admin.", "Lỗi đăng nhập",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (sqlEx.Number == 4060) 
                {
                    XtraMessageBox.Show("Không thể kết nối đến database QuanLyThuVien!", "Lỗi database",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    XtraMessageBox.Show($"Lỗi kết nối database: {sqlEx.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void SaveUserSession(string username, string password, string connectionString)
        {
            UserSession.CurrentUserName = username;
            UserSession.CurrentUserPassword = password;
            UserSession.ConnectionString = connectionString;

            ConnectionStringProvider.SetConnectionString(connectionString);

            System.Diagnostics.Debug.WriteLine($"Session lưu thành công - User: {username}");
        }
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            UserSession.Clear();
            ConnectionStringProvider.Clear(); 
            
            ConnectionStringProvider.SetConnectionString(_integratedConnString);
            
            this.Show();
            txtUsername.Focus();
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            UserSession.Clear();
            Application.Exit();
        }
    }
}