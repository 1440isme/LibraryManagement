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
 
        private BanSaoSachService _banSaoSachService;
        public ucPageBanSaoSach()
        {
            InitializeComponent();

            var dbContext = ContextFactory.CreateContext(); 
            var banSSRepo = new GenericRepository<BanSaoSach>(dbContext);
            _banSaoSachService = new BanSaoSachService(banSSRepo);
        }
       

        private void ucPageBanSaoSach_Load(object sender, EventArgs e)
        {
            
            gcBanSaoSach.DataSource = _banSaoSachService.GetAllBanSaoSach();
            

            _enable(false);
            txtTenSach.Enabled = false;
            txtBarcode.Enabled = false;
            cboTinhTrang.Enabled = false;
            dtNgayNhap.Enabled = false; 
            _reset();
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
                MessageBox.Show("Lỗi khi lưu bản sao sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void gvBanSaoSach_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "TinhTrang")
            {
                string status = Convert.ToString(gvBanSaoSach.GetRowCellValue(e.RowHandle, "TinhTrang"));
                if (status =="Sẵn sàng")
                    e.Appearance.BackColor = Color.LightGreen;
                else if (status == "Đang mượn")
                    e.Appearance.BackColor = Color.LightYellow;
                else if (status == "Mất")
                    e.Appearance.BackColor = Color.LightCoral;
                else
                    e.Appearance.BackColor = Color.MistyRose;
            }
        }
    }
}
