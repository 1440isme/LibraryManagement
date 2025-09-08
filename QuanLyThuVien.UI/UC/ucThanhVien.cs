using QuanLyThuVien.BLL.Services;
using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.UI.UI;
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
    public partial class ucThanhVien : UserControl
    {
        private Size originalFormSize;
        private Dictionary<Control, Rectangle> controlBounds = new Dictionary<Control, Rectangle>();
        private ThanhVienService _thanhVienService;
        public ucThanhVien()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint, true);
            this.UpdateStyles();
            var dbContext = new QuanLyThuVienContext();
            var TVRepo = new GenericRepository<ThanhVien>(dbContext);
            _thanhVienService = new ThanhVienService(TVRepo);
        }
        bool _them;
        private void ucThanhVien_Load(object sender, EventArgs e)
        {
            originalFormSize = this.Size;
            StoreControlBounds(this);
            gcThanhVien.DataSource = _thanhVienService.GetAllMembers();

            showHideControl(true);
            _enable(false);
            _reset();
        }
        private void StoreControlBounds(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (!controlBounds.ContainsKey(ctrl))
                {
                    controlBounds[ctrl] = ctrl.Bounds;
                }
                if (ctrl.HasChildren)
                {
                    StoreControlBounds(ctrl);
                }
            }
        }

        private void ucThanhVien_Resize(object sender, EventArgs e)
        {
            if (originalFormSize.Width == 0 || originalFormSize.Height == 0)
                return;

            float xRatio = (float)this.Width / originalFormSize.Width;
            float yRatio = (float)this.Height / originalFormSize.Height;

            this.SuspendLayout();
            ResizeControls(this, xRatio, yRatio);
            this.ResumeLayout();
        }
        private void ResizeControls(Control parent, float xRatio, float yRatio)
        {
            parent.SuspendLayout();
            foreach (Control ctrl in parent.Controls)
            {
                if (controlBounds.TryGetValue(ctrl, out Rectangle originalBounds))
                {
                    int newX = (int)(originalBounds.X * xRatio);
                    int newY = (int)(originalBounds.Y * yRatio);
                    int newWidth = (int)(originalBounds.Width * xRatio);
                    int newHeight = (int)(originalBounds.Height * yRatio);

                    // Chỉ set Bounds nếu thực sự thay đổi
                    if (ctrl.Bounds != new Rectangle(newX, newY, newWidth, newHeight))
                        ctrl.Bounds = new Rectangle(newX, newY, newWidth, newHeight);
                }
                if (ctrl.HasChildren)
                {
                    ResizeControls(ctrl, xRatio, yRatio);
                }
            }
            parent.ResumeLayout();
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
            txtTenThanhVien.Enabled = t;
            txtEmail.Enabled = t;
            txtSDT.Enabled = t;
            txtDiaChi.Enabled = t;
            cboLoaiThanhVien.Enabled = t;
            dtNgayDK.Enabled = t;
        }
        void _reset()
        {
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
                        TenThanhVien = txtTenThanhVien.Text,
                        Email = txtEmail.Text,
                        SoDienThoai = txtSDT.Text,
                        DiaChi = txtDiaChi.Text,
                        LoaiThanhVien = cboLoaiThanhVien.SelectedItem.ToString(),
                        NgayDangKy = dtNgayDK.Value
                    };
                    _thanhVienService.AddMember(tvien);
                    gcThanhVien.DataSource = _thanhVienService.GetAllMembers();
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
                    MessageBox.Show("Cập nhật thành viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showHideControl(true);
                    _enable(false);
                }
            }
            catch (Exception ex)
            {
                string message = SqlErrorTranslator.ToFriendlyMessage(ex);
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
