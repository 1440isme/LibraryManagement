using QuanLyThuVien.BLL.Services;
using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.UI.Interfaces;
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

namespace QuanLyThuVien.UI.UC.Pages
{
    public partial class ucPageDanhSach : UserControl, ICrudOperations
    {
        private PhieuMuonService _phieuMuonService;
        public ucPageDanhSach()
        {
            InitializeComponent();
        }

        bool _them;
        private void ucPageDanhSach_Load(object sender, EventArgs e)
        {
            var dbContext = new QuanLyThuVienContext();
            var repo = new GenericRepository<PhieuMuon>(dbContext);
            _phieuMuonService = new PhieuMuonService(repo);

            gcDanhSachMuon.DataSource = _phieuMuonService.GetAllPhieuMuons();
                
        }

        private void gvDanhSachMuon_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                var pm = e.Row as PhieuMuon;
                if (pm != null)
                {
                    if (e.Column.FieldName == "TenThanhVien")
                        e.Value = pm.MaThanhVienNavigation?.TenThanhVien;
                }
            }
        }

        public void Add()
        {
           
        }

        public void Edit()
        {
            var pm = gvDanhSachMuon.GetFocusedRow() as PhieuMuon;
            if (pm.MaPhieuMuon == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public void RefreshData()
        {
            throw new NotImplementedException();
        }
    }
}
