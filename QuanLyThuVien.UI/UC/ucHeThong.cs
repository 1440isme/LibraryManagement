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
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace QuanLyThuVien.UI.UC
{
    public partial class ucHeThong : UserControl, IActivatable
    {
        private CauHinhService _cauHinhService;
        private bool _isDataLoaded = false;
        private bool _isInitialized = false;
        public ucHeThong()
        {
            InitializeComponent();
        }

        public bool IsDataLoaded => _isDataLoaded;

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
            var auditlogRepo = new GenericRepository<AuditLog>(dbContext);
            _cauHinhService = new CauHinhService(auditlogRepo);

            showHideControl(true);
            _enable(false);
        }
        private void LoadData()
        {
            try
            {
                gcCauHinhHeThong.DataSource = _cauHinhService.LoadCauHinh();
                gcAuditLog.DataSource = _cauHinhService.GetAllLogs();
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
                    gcCauHinhHeThong.DataSource = _cauHinhService.LoadCauHinh();
                    gcAuditLog.DataSource = _cauHinhService .GetAllLogs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi làm mới dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void showHideControl(bool t)
        {
            btnSua.Enabled = t;
            btnLuu.Enabled = !t;
            btnBoQua.Enabled = !t;
        }
        void _enable(bool t)
        {
            txtTenCauHinh.Enabled = t;
            txtGiaTri.Enabled = t;
            txtMoTa.Enabled = t;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            showHideControl(false);
            _enable(true);
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            decimal giaTriMoi = decimal.TryParse(txtGiaTri.Text, out decimal result) ? result : 0;
            if (string.IsNullOrWhiteSpace(txtTenCauHinh.Text) || string.IsNullOrWhiteSpace(txtGiaTri.Text))
            {
                MessageBox.Show("Vui lòng chọn đúng cấu hình.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (giaTriMoi <= 0)
            {
                MessageBox.Show("Giá trị phải là số dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var cauHinh = gvCauHinhTheThong.GetFocusedRow();
                if (cauHinh != null)
                {
                    
                    _cauHinhService.UpdateCauHinh(txtTenCauHinh.Text, giaTriMoi, txtMoTa.Text);
                    MessageBox.Show("Cập nhật cấu hình thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showHideControl(true);
                    _enable(false);
                    RefreshData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật cấu hình: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBoQua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            showHideControl(true);
            _enable(false);
        }

        private void gvCauHinhTheThong_Click(object sender, EventArgs e)
        {
            if (gvCauHinhTheThong.GetFocusedRow() != null)
            {
                var selectedRow = gvCauHinhTheThong.GetFocusedDataRow();

                if (selectedRow != null)
                {
                    txtTenCauHinh.Text = selectedRow["TenCauHinh"]?.ToString() ?? "";
                    txtGiaTri.Text = selectedRow["GiaTri"]?.ToString() ?? "";
                    txtMoTa.Text = selectedRow["MoTa"]?.ToString() ?? "";
                }
            }
        }
    }
}
