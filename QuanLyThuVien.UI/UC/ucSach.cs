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

namespace QuanLyThuVien.UI.UI
{
    public partial class ucSach : UserControl
    {
        private Size originalFormSize;
        private Dictionary<Control, Rectangle> controlBounds = new Dictionary<Control, Rectangle>();
        private SachService _sachService;
        public ucSach()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint, true);
            gvSach.CustomUnboundColumnData += GvSach_CustomUnboundColumnData;
            this.UpdateStyles();
            var dbContext = new QuanLyThuVienContext();
            var sachRepo = new GenericRepository<Sach>(dbContext);
            _sachService = new SachService(sachRepo);
        }

        private void ucSach_Load(object sender, EventArgs e)
        {
            originalFormSize = this.Size;
            StoreControlBounds(this);
            var danhSachSach = _sachService.GetAllBooks();
            gcSach.DataSource = danhSachSach;
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
    }
}
