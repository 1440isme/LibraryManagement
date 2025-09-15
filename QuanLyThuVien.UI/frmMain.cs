using DevExpress.XtraBars;
using QuanLyThuVien.UI.UC;
using QuanLyThuVien.UI.UI;
using QuanLyThuVien.UI.Interfaces;
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
        public frmMain()
        {
            InitializeComponent();
        }
        
        ucSach _ucSach;
        ucThanhVien _ucThanhVien;
        ucMuonTra _ucMuonTra;
        ucPhat _ucPhat;
        ucBaoCaoThongKe _ucBCTK;
        ucDashboard _ucDashboard;
        
        private IActivatable _currentActiveControl;

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void ActivateUserControl(UserControl control)
        {
            if (_currentActiveControl != null)
            {
                _currentActiveControl.OnDeactivated();
            }

            control.BringToFront();

            if (control is IActivatable activatable)
            {
                activatable.OnActivated();
                _currentActiveControl = activatable;
            }
        }

        private void mnSach_Click(object sender, EventArgs e)
        {
            if (_ucSach == null)
            {
                _ucSach = new ucSach();
                _ucSach.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(_ucSach);
            }
            
            ActivateUserControl(_ucSach);
            lblTieuDe.Caption = mnSach.Text;
        }
        
        private void mnThanhVien_Click(object sender, EventArgs e)
        {
            if (_ucThanhVien == null)
            {
                _ucThanhVien = new ucThanhVien();
                _ucThanhVien.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(_ucThanhVien);
            }
            
            ActivateUserControl(_ucThanhVien);
            lblTieuDe.Caption = mnThanhVien.Text;
        }

        private void mnMuonTra_Click(object sender, EventArgs e)
        {
            if (_ucMuonTra == null)
            {
                _ucMuonTra = new ucMuonTra();
                _ucMuonTra.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(_ucMuonTra);
            }
            
            ActivateUserControl(_ucMuonTra);
            lblTieuDe.Caption = mnMuonTra.Text;
        }

        private void mnPhat_Click(object sender, EventArgs e)
        {
            if (_ucPhat == null)
            {
                _ucPhat = new ucPhat();
                _ucPhat.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(_ucPhat);
            }
            
            ActivateUserControl(_ucPhat);
            lblTieuDe.Caption = mnPhat.Text;
        }

        private void mnTKBC_Click(object sender, EventArgs e)
        {
            if (_ucBCTK == null)
            {
                _ucBCTK = new ucBaoCaoThongKe();
                _ucBCTK.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(_ucBCTK);
            }
            
            ActivateUserControl(_ucBCTK);
            lblTieuDe.Caption = mnTKBC.Text;
        }

        private void mnTrangChu_Click(object sender, EventArgs e)
        {
            if (_ucDashboard == null)
            {
                _ucDashboard = new ucDashboard();
                _ucDashboard.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(_ucDashboard);
            }
            
            ActivateUserControl(_ucDashboard);
            lblTieuDe.Caption = mnTrangChu.Text;
        }
    }
}
