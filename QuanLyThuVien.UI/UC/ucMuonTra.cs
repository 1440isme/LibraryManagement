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
    public partial class ucMuonTra : UserControl
    {
        //private Size originalFormSize;
        //private Dictionary<Control, Rectangle> controlBounds = new Dictionary<Control, Rectangle>();
        public ucMuonTra()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        private void ucMuonTra_Load(object sender, EventArgs e)
        {
            //originalFormSize = this.Size;
            //StoreControlBounds(this);
            showHideControl(true);
        }

        //private void ucMuonTra_Resize(object sender, EventArgs e)
        //{
        //    if (originalFormSize.Width == 0 || originalFormSize.Height == 0)
        //        return;

        //    float xRatio = (float)this.Width / originalFormSize.Width;
        //    float yRatio = (float)this.Height / originalFormSize.Height;

        //    this.SuspendLayout();
        //    ResizeControls(this, xRatio, yRatio);
        //    this.ResumeLayout();
        //}
        //private void StoreControlBounds(Control parent)
        //{
        //    foreach (Control ctrl in parent.Controls)
        //    {
        //        if (!controlBounds.ContainsKey(ctrl))
        //        {
        //            controlBounds[ctrl] = ctrl.Bounds;
        //        }
        //        if (ctrl.HasChildren)
        //        {
        //            StoreControlBounds(ctrl);
        //        }
        //    }
        //}
        //private void ResizeControls(Control parent, float xRatio, float yRatio)
        //{
        //    parent.SuspendLayout();
        //    foreach (Control ctrl in parent.Controls)
        //    {
        //        if (controlBounds.TryGetValue(ctrl, out Rectangle originalBounds))
        //        {
        //            int newX = (int)(originalBounds.X * xRatio);
        //            int newY = (int)(originalBounds.Y * yRatio);
        //            int newWidth = (int)(originalBounds.Width * xRatio);
        //            int newHeight = (int)(originalBounds.Height * yRatio);

        //            // Chỉ set Bounds nếu thực sự thay đổi
        //            if (ctrl.Bounds != new Rectangle(newX, newY, newWidth, newHeight))
        //                ctrl.Bounds = new Rectangle(newX, newY, newWidth, newHeight);
        //        }
        //        if (ctrl.HasChildren)
        //        {
        //            ResizeControls(ctrl, xRatio, yRatio);
        //        }
        //    }
        //    parent.ResumeLayout();
        //}
        void showHideControl(bool t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
            btnBoQua.Enabled = !t;

        }
    }
}
