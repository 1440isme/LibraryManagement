using DevExpress.XtraBars;
using QuanLyThuVien.UI.UC;
using QuanLyThuVien.UI.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien.UI
{
    public partial class frmMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        //private Size originalFormSize;
        //private Dictionary<Control, Rectangle> controlBounds = new Dictionary<Control, Rectangle>();
        public frmMain()
        {
            InitializeComponent();
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
            //      ControlStyles.AllPaintingInWmPaint |
            //      ControlStyles.UserPaint, true);
            //this.UpdateStyles();
        }
        ucSach _ucSach;
        ucThanhVien _ucThanhVien;
        ucMuonTra _ucMuonTra;
        ucPhat _ucPhat;


        private void frmMain_Load(object sender, EventArgs e)
        {
            //originalFormSize = this.Size;
            //StoreControlBounds(this);
        }

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

        //private void frmMain_Resize(object sender, EventArgs e)
        //{
        //    if (originalFormSize.Width == 0 || originalFormSize.Height == 0)
        //        return;

        //    float xRatio = (float)this.Width / originalFormSize.Width;
        //    float yRatio = (float)this.Height / originalFormSize.Height;

        //    this.SuspendLayout();
        //    ResizeControls(this, xRatio, yRatio);
        //    this.ResumeLayout();
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

        //            Rectangle newBounds = new Rectangle(newX, newY, newWidth, newHeight);
        //            if (ctrl.Bounds != newBounds)
        //                ctrl.Bounds = newBounds;
        //        }
        //        if (ctrl.HasChildren)
        //        {
        //            ResizeControls(ctrl, xRatio, yRatio);
        //        }
        //    }
        //    parent.ResumeLayout();
        //}
        private void mnSach_Click(object sender, EventArgs e)
        {
            if (_ucSach == null)
            {
                _ucSach = new ucSach();
                _ucSach.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(_ucSach);
                _ucSach.BringToFront();
            }
            else
                _ucSach.BringToFront();
            lblTieuDe.Caption = mnSach.Text;
        }
        private void mnThanhVien_Click(object sender, EventArgs e)
        {
            if (_ucThanhVien == null)
            {
                _ucThanhVien = new ucThanhVien();
                _ucThanhVien.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(_ucThanhVien);
                _ucThanhVien.BringToFront();
            }
            else
                _ucThanhVien.BringToFront();
            lblTieuDe.Caption = mnThanhVien.Text;
        }

        private void mnMuonTra_Click(object sender, EventArgs e)
        {
            if (_ucMuonTra == null)
            {
                _ucMuonTra = new ucMuonTra();
                _ucMuonTra.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(_ucMuonTra);
                _ucMuonTra.BringToFront();
            }
            else
                _ucMuonTra.BringToFront();
            lblTieuDe.Caption = mnMuonTra.Text;
        }

        private void mnPhat_Click(object sender, EventArgs e)
        {
            if (_ucPhat == null)
            {
                _ucPhat = new ucPhat();
                _ucPhat.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(_ucPhat);
                _ucPhat.BringToFront();
            }
            else
                _ucPhat.BringToFront();
            lblTieuDe.Caption = mnPhat.Text;
        }
    }
}
