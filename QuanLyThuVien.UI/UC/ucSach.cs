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
    public partial class ucSach : UserControl, IActivatable
    {
        private ucPageSach _pageSach;
        private ucPageBanSaoSach _pageBanSaoSach;
        private ucPageTacGia _pageTacGia;
        private ucPageNXB _pageNXB;
        private ucPageTheLoai _pageTheLoai;
        
        private bool _isDataLoaded = false;
        private bool _isInitialized = false;

        public bool IsDataLoaded => _isDataLoaded;

        public ucSach()
        {
            InitializeComponent();
        }

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
        }

        public void OnDeactivated()
        {
            
        }

        private void InitializeControls()
        {
            _pageSach = new ucPageSach();
            _pageBanSaoSach = new ucPageBanSaoSach();
            _pageTacGia = new ucPageTacGia();
            _pageNXB = new ucPageNXB();
            _pageTheLoai = new ucPageTheLoai();

            pageSach.Controls.Add(_pageSach);
            pageBanSaoSach.Controls.Add(_pageBanSaoSach);
            pageTacGia.Controls.Add(_pageTacGia);
            pageNXB.Controls.Add(_pageNXB);
            pageTheLoai.Controls.Add(_pageTheLoai);

            _pageSach.DataChanged += (s, e) => _pageBanSaoSach.RefreshData();
            tabQLSach.SelectedPageChanged += TabQLSach_SelectedPageChanged;

            showHideControl(true);
        }

        private void LoadData()
        {
            try
            {
                LoadActiveTabData();
                _isDataLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu sách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TabQLSach_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (_isDataLoaded)
            {
                LoadActiveTabData();
            }
        }

        private void LoadActiveTabData()
        {
            try
            {
                var activeControl = GetActiveCrudPage();
                if (activeControl != null)
                {
                    activeControl.RefreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu tab: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ICrudOperations GetActiveCrudPage()
        {
            if (tabQLSach.SelectedTabPage.Controls.Count > 0)
                return tabQLSach.SelectedTabPage.Controls[0] as ICrudOperations;
            return null;
        }

        private void ucSach_Load(object sender, EventArgs e)
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

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetActiveCrudPage()?.Add();
            showHideControl(false);

        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetActiveCrudPage()?.Edit();
            showHideControl(false);

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetActiveCrudPage()?.Delete();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetActiveCrudPage()?.Save();
            showHideControl(true);

        }

        private void btnBoQua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetActiveCrudPage()?.Cancel();
            showHideControl(true);

        }
    }
}
