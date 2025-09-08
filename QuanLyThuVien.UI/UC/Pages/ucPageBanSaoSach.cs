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

namespace QuanLyThuVien.UI.UC.Pages
{
    public partial class ucPageBanSaoSach : UserControl, ICrudOperations
    {
        private Size originalFormSize;
        private Dictionary<Control, Rectangle> controlBounds = new Dictionary<Control, Rectangle>();
        private SachService _sachService;
        private BanSaoSachService _banSaoSachService;
        public ucPageBanSaoSach()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint, true);
            var dbContext = new QuanLyThuVienContext();
            var banSSRepo = new GenericRepository<BanSaoSach>(dbContext);
            _banSaoSachService = new BanSaoSachService(banSSRepo);
        }
       

        private void ucPageBanSaoSach_Load(object sender, EventArgs e)
        {
            originalFormSize = this.Size;
            StoreControlBounds(this);
            gcBanSaoSach.DataSource = _banSaoSachService.GetAllBanSaoSach();
            

            _enable(false);
            txtTenSach.Enabled = false;
            txtBarcode.Enabled = false;
            cboTinhTrang.Enabled = false;
            dtNgayNhap.Enabled = false; 
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

        private void ucPageBanSaoSach_Resize(object sender, EventArgs e)
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
        void _enable(bool t)
        {
            
            txtViTri.Enabled = t;
            cboTinhTrang.Enabled = t;
            txtGhiChu.Enabled = t;
            
        }
        void _reset()
        {
            txtTenSach.Text = "";
            txtBarcode.Text = "";
            txtViTri.Text = "";
            cboTinhTrang.SelectedIndex = -1;
            dtNgayNhap.Value = DateTime.Now;
            txtGhiChu.Text = "";
        }
        public void Add()
        {
            MessageBox.Show("Không được thêm bản sao", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;

        }

        public void Cancel()
        {
            
            _enable(false);
        }

        public void Delete()
        {
            MessageBox.Show("Không được xoá bản sao", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        public void Edit()
        {
            
            _enable(true);
        }

        public void Save()
        {
            if (cboTinhTrang.SelectedItem == null || cboTinhTrang.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn tình trạng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var bssach = gvBanSaoSach.GetFocusedRow() as BanSaoSach;
                if ( bssach.MaBanSao == 0)
                {
                    MessageBox.Show("Vui lòng chọn bản sao để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (bssach != null)
                {
                    bssach.ViTri = txtViTri.Text;
                    bssach.GhiChu = txtGhiChu.Text;
                    bssach.TinhTrang = cboTinhTrang.SelectedItem.ToString();
                    _banSaoSachService.UpdateBanSaoSach(bssach);
                }
                gcBanSaoSach.DataSource = _banSaoSachService.GetAllBanSaoSach();
                _enable(false);
                MessageBox.Show("Cập nhật bản sao sách thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string message = SqlErrorTranslator.ToFriendlyMessage(ex);
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gvBanSaoSach_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                var bssach = e.Row as BanSaoSach;
                if (bssach != null)
                {

                    if (e.Column.FieldName == "TenSach")
                        e.Value = bssach.MaSachNavigation?.TenSach;

                }
            }
        }

        private void gvBanSaoSach_Click(object sender, EventArgs e)
        {
            if (gvBanSaoSach.RowCount>0)
            {
                var bssach = gvBanSaoSach.GetFocusedRow() as BanSaoSach;
                if (bssach != null)
                {
                    txtTenSach.Text = bssach.MaSachNavigation?.TenSach;
                    txtBarcode.Text = bssach.Barcode;
                    txtViTri.Text = bssach.ViTri;
                    cboTinhTrang.SelectedItem = bssach.TinhTrang;
                    dtNgayNhap.Value = bssach.NgayNhap;
                    txtGhiChu.Text = bssach.GhiChu;
                }
            }
        }

        public void RefreshData()
        {
            gcBanSaoSach.DataSource = _banSaoSachService.GetAllBanSaoSach();
        }
    }
}
