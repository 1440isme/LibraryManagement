using DevExpress.XtraEditors;
using QuanLyThuVien.BLL.Services;
using QuanLyThuVien.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            var dbContext = new QuanLyThuVienContext();
            var userRepository = new GenericRepository<Users>(dbContext);
            _nguoiDungService = new NguoiDungService(userRepository);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "")
            {
                XtraMessageBox.Show("Tên đăng nhập không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool us = _nguoiDungService.checkUserExist(txtUsername.Text.Trim());
            if (!us)
            {
                XtraMessageBox.Show("Tên đăng nhập không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string pass = txtPassword.Text.Trim();
            var user = _nguoiDungService.GetAllUsers().FirstOrDefault(u => u.UserName == txtUsername.Text.Trim());
            if (user.PasswordHash.Equals(pass))
            {
                frmMain frm = new frmMain(user);
                frm.FormClosed += FrmMain_FormClosed;
                frm.Show();
                this.Hide();
            }
            else
            {
                XtraMessageBox.Show("Mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            txtUsername.Focus();
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}