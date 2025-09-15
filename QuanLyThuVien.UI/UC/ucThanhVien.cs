using QuanLyThuVien.BLL.Services;
using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.UI.UI;
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
    public partial class ucThanhVien : UserControl, IActivatable
    {
        private ThanhVienService _thanhVienService;
        private bool _isDataLoaded = false;
        private bool _isInitialized = false;
        
        public bool IsDataLoaded => _isDataLoaded;

        public ucThanhVien()
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
            var TVRepo = new GenericRepository<ThanhVien>(dbContext);
            _thanhVienService = new ThanhVienService(TVRepo);

            showHideControl(true);
            _enable(false);
            _reset();
        }

        private void LoadData()
        {
            try
            {
                gcThanhVien.DataSource = _thanhVienService.GetAllMembers();
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
                    gcThanhVien.DataSource = _thanhVienService.GetAllMembers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi làm mới dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ucThanhVien_Load(object sender, EventArgs e)
        {
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
            txtMaThanhVien.Enabled = t;
            txtTenThanhVien.Enabled = t;
            txtEmail.Enabled = t;
            txtSDT.Enabled = t;
            txtDiaChi.Enabled = t;
            cboLoaiThanhVien.Enabled = t;
            dtNgayDK.Enabled = t;
        }

        void _reset()
        {
            txtMaThanhVien.Text = "";
            txtTenThanhVien.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            cboLoaiThanhVien.SelectedIndex = -1;
            dtNgayDK.Value = DateTime.Now;
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
                if (gvThanhVien.RowCount > 0)
                {
                    var tvien = gvThanhVien.GetFocusedRow() as ThanhVien;
                    if (tvien != null)
                    {
                        if (MessageBox.Show("Bạn có chắc chắn muốn xóa thành viên này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _thanhVienService.DeleteMember(tvien.MaThanhVien);
                            gcThanhVien.DataSource = _thanhVienService.GetAllMembers();
                            EventBus.Publish("ThanhVienChanged");
                            MessageBox.Show("Xóa thành viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = SqlErrorTranslator.ToFriendlyMessage(ex);
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaThanhVien.Text))
            {
                MessageBox.Show("Mã thành viên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (!int.TryParse(txtMaThanhVien.Text, out int maThanhVien))
            {
                MessageBox.Show("Mã thành viên phải là số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtTenThanhVien.Text))
            {
                MessageBox.Show("Tên thành viên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (cboLoaiThanhVien.SelectedItem == null || cboLoaiThanhVien.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại thành viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (_them)
                {
                    var tvien = new ThanhVien
                    {
                        MaThanhVien = int.Parse(txtMaThanhVien.Text),
                        TenThanhVien = txtTenThanhVien.Text,
                        Email = txtEmail.Text,
                        SoDienThoai = txtSDT.Text,
                        DiaChi = txtDiaChi.Text,
                        LoaiThanhVien = cboLoaiThanhVien.SelectedItem.ToString(),
                        NgayDangKy = dtNgayDK.Value
                    };
                    
                    _thanhVienService.AddMember(tvien);
                    gcThanhVien.DataSource = _thanhVienService.GetAllMembers();
                    EventBus.Publish("ThanhVienChanged");
                    MessageBox.Show("Thêm thành viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showHideControl(true);
                    _enable(false);
                }
                else
                {
                    var tvien = gvThanhVien.GetFocusedRow() as ThanhVien;
                    if (tvien.MaThanhVien == 0)
                    {
                        MessageBox.Show("Vui lòng chọn thành viên để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (tvien != null)
                    {
                        tvien.TenThanhVien = txtTenThanhVien.Text;
                        tvien.Email = txtEmail.Text;
                        tvien.SoDienThoai = txtSDT.Text;
                        tvien.DiaChi = txtDiaChi.Text;
                        tvien.LoaiThanhVien = cboLoaiThanhVien.SelectedItem.ToString();
                        tvien.NgayDangKy = dtNgayDK.Value;
                        _thanhVienService.UpdateMember(tvien);
                    }
                    gcThanhVien.DataSource = _thanhVienService.GetAllMembers();
                    EventBus.Publish("ThanhVienChanged");
                    MessageBox.Show("Cập nhật thành viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void gvThanhVien_Click(object sender, EventArgs e)
        {
            if (gvThanhVien.RowCount > 0)
            {
                var tvien = gvThanhVien.GetFocusedRow() as ThanhVien;
                if (tvien != null)
                {
                    txtMaThanhVien.Text = tvien.MaThanhVien.ToString();
                    txtTenThanhVien.Text = tvien.TenThanhVien;
                    txtEmail.Text = tvien.Email;
                    txtSDT.Text = tvien.SoDienThoai;
                    txtDiaChi.Text = tvien.DiaChi;
                    cboLoaiThanhVien.SelectedItem = tvien.LoaiThanhVien;
                    dtNgayDK.Value = tvien.NgayDangKy;
                }
            }
        }
    }
}
