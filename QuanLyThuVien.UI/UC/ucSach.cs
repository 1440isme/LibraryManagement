using QuanLyThuVien.BLL.Services;
using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.UI.Interfaces;
using QuanLyThuVien.UI.UC.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.UI.UI
{
    public partial class ucSach : UserControl
    {
        private Size originalFormSize;
        private Dictionary<Control, Rectangle> controlBounds = new Dictionary<Control, Rectangle>();
        private ucPageSach _pageSach;
        private ucPageBanSaoSach _pageBanSaoSach;

        public ucSach()
        {
            InitializeComponent();
            _pageSach = new ucPageSach();
            _pageBanSaoSach = new ucPageBanSaoSach();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint, true);
            this.UpdateStyles();
            pageSach.Controls.Add(_pageSach);
            pageBanSaoSach.Controls.Add(_pageBanSaoSach);
            _pageSach.DataChanged += (s, e) => _pageBanSaoSach.RefreshData();
        }

            
        
        private ICrudOperations GetActiveCrudPage()
        {
            if (tabQLSach.SelectedTabPage.Controls.Count > 0)
                return tabQLSach.SelectedTabPage.Controls[0] as ICrudOperations;
            return null;
        }


        
        private void ucSach_Load(object sender, EventArgs e)
        {
            originalFormSize = this.Size;
            StoreControlBounds(this);
            showHideControl(true);

        }

        void showHideControl(bool t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
            btnBoQua.Enabled = !t;

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

        private void ucSach_Resize(object sender, EventArgs e)
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
        private void GvSach_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                var sach = e.Row as Sach;
                if (sach != null)
                {

                    if (e.Column.FieldName == "TenTacGia")
                        e.Value = sach.MaTacGiaNavigation?.TenTacGia ?? "";
                    else if (e.Column.FieldName == "TenTheLoai")
                        e.Value = sach.MaTheLoaiNavigation?.TenTheLoai ?? "";
                    else if (e.Column.FieldName == "TenNhaXuatBan")
                        e.Value = sach.MaNhaXuatBanNavigation?.TenNhaXuatBan ?? "";
                }
            }
        }

        

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            showHideControl(false);
            GetActiveCrudPage()?.Add();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            showHideControl(false);
            GetActiveCrudPage()?.Edit();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetActiveCrudPage()?.Delete();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            showHideControl(true);
            GetActiveCrudPage()?.Save();
        }

        private void btnBoQua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            showHideControl(true);
            GetActiveCrudPage()?.Cancel();
        }

        
    }
}
