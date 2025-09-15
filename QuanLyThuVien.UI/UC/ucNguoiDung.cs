using QuanLyThuVien.BLL.Services;
using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.UI.UC
{
    public partial class ucNguoiDung : UserControl, IActivatable
    {
        private NguoiDungService _nguoiDungService;
        private RoleService _roleService;
        private bool _isDataLoaded = false;
        private bool _isInitialized = false;
        public bool IsDataLoaded => _isDataLoaded;
        public ucNguoiDung()
        {
            InitializeComponent();
        }
        bool _them;

        public void OnActivated()
        {
            if (!_isInitialized)
            {
                InitializeControls();
                _isInitialized = true;
            }

            if (!_isDataLoaded)
            {
                LoadData();
            }
            else
            {
                RefreshData();
            }
        }

       

        public void OnDeactivated()
        {
        }
        private void InitializeControls()
        {
            var dbContext = new QuanLyThuVienContext();
            var userRepository = new GenericRepository<Users>(dbContext);
            var roleRepository = new GenericRepository<Roles>(dbContext);
            _nguoiDungService = new NguoiDungService(userRepository);
            _roleService = new RoleService(roleRepository);

            showHideControl(true);
            _enable(false);
            _reset();
        }
        private void LoadData()
        {
            try
            {
                cboRole.DataSource = _roleService.GetAllRoles();
                cboRole.DisplayMember = "RoleName";
                cboRole.ValueMember = "RoleID";
                gcUser.DataSource = _nguoiDungService.GetAllUsers();
                _isDataLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshData()
        {
            if (!btnLuu.Enabled)
            {
                try
                {
                    gcUser.DataSource = _nguoiDungService.GetAllUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi làm mới dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

      
        void showHideControl(bool t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
            btnBoQua.Enabled = !t;
        }

        void _enable(bool t)
        {
            txtUsername.Enabled = t;
            txtFullname.Enabled = t;
            txtPassword.Enabled = t;
            txtEmail.Enabled = t;
            cboRole.Enabled = t;
            chkHoatDong.Enabled = t;
        }

        void _reset()
        {
            txtUsername.Text = "";
            txtFullname.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            cboRole.SelectedIndex = -1;
            chkHoatDong.Checked = true;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true;
            showHideControl(false);
            _enable(true);
            _reset();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            showHideControl(false);
            _enable(true);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (gvUser.RowCount > 0)
                {
                    var user = gvUser.GetFocusedRow() as Users;
                    if (user != null)
                    {
                        if (MessageBox.Show("Bạn có chắc chắn muốn xóa thành viên này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _nguoiDungService.DeleteUser(user.UserId);
                            gcUser.DataSource = _nguoiDungService.GetAllUsers();
                            MessageBox.Show("Xóa người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errorDetails = $"Error Message: {ex.Message}\n\n";
                errorDetails += $"Stack Trace: {ex.StackTrace}\n\n";

                if (ex.InnerException != null)
                {
                    errorDetails += $"Inner Exception: {ex.InnerException.Message}\n\n";
                    errorDetails += $"Inner Stack Trace: {ex.InnerException.StackTrace}";
                }

                MessageBox.Show(errorDetails, "Chi tiết lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Tên đăng nhập không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtFullname.Text))
            {
                MessageBox.Show("Tên người dùng không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (_them)
                {
                    var user = new Users
                    {
                        UserName = txtUsername.Text.Trim(),
                        FullName = txtFullname.Text.Trim(),
                        PasswordHash = txtPassword.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        RoleId = cboRole.SelectedItem != null ? (int)cboRole.SelectedValue : (int?)null,
                        IsActive = chkHoatDong.Checked
                    };
                    _nguoiDungService.AddUser(user);
                    gcUser.DataSource = _nguoiDungService.GetAllUsers();
                    MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showHideControl(true);
                    _enable(false);
                }
                else
                {
                    var user = gvUser.GetFocusedRow() as Users;
                    if (user == null) 
                    {
                        MessageBox.Show("Vui lòng chọn người dùng để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    user.UserName = txtUsername.Text.Trim();
                    user.FullName = txtFullname.Text.Trim();
                    user.PasswordHash = txtPassword.Text.Trim();
                    user.Email = txtEmail.Text.Trim();
                    user.RoleId = cboRole.SelectedItem != null ? (int)cboRole.SelectedValue : (int?)null;
                    user.IsActive = chkHoatDong.Checked;
                    _nguoiDungService.UpdateUser(user);
                    
                    gcUser.DataSource = _nguoiDungService.GetAllUsers();
                    MessageBox.Show("Cập nhật người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showHideControl(true);
                    _enable(false);
                }    
            }
            catch (Exception ex)
            {
                string errorDetails = $"Error Message: {ex.Message}\n\n";
                errorDetails += $"Stack Trace: {ex.StackTrace}\n\n";

                if (ex.InnerException != null)
                {
                    errorDetails += $"Inner Exception: {ex.InnerException.Message}\n\n";
                    errorDetails += $"Inner Stack Trace: {ex.InnerException.StackTrace}";
                }

                MessageBox.Show(errorDetails, "Chi tiết lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBoQua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            showHideControl(true);
            _enable(false);
        }

        private void gvUser_Click(object sender, EventArgs e)
        {
            if (gvUser.RowCount > 0)
            {
                var user = gvUser.GetFocusedRow() as Users;
                if (user != null)
                {
                    txtUsername.Text = user.UserName;
                    txtFullname.Text = user.FullName;
                    txtPassword.Text = user.PasswordHash;
                    txtEmail.Text = user.Email;
                    cboRole.SelectedValue = user.RoleId;
                    chkHoatDong.Checked = user.IsActive ?? false;

                }
            }
        }

        private void gvUser_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "IsActive")
            {
                bool status = Convert.ToBoolean(gvUser.GetRowCellValue(e.RowHandle, "IsActive"));
                if (status)
                    e.Appearance.BackColor = Color.LightGreen;
                else
                    e.Appearance.BackColor = Color.LightCoral;
            }
        }

        private void gvUser_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                var user = e.Row as Users;
                if (user != null)
                {

                    if (e.Column.FieldName == "RoleName")
                        e.Value =  user.Role?.RoleName ?? "Chưa phân quyền";

                }
            }
        }
    }
}
