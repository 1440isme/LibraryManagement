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

namespace QuanLyThuVien.UI.UC.Pages
{
    public partial class ucPageChiTiet : UserControl
    {
        private ThanhVienService _thanhVienService;
        private ThongTinThanhVienService _thongTinThanhVienService;
        private BanSaoSachService _banSaoSachService;
        private ChiTietPhieuMuonService _chiTietPhieuMuonService;

        public ucPageChiTiet()
        {
            InitializeComponent();
        }

        private void ucPageChiTiet_Load(object sender, EventArgs e)
        {
            var dbContext = new QuanLyThuVienContext();
            var TVRepo = new GenericRepository<ThanhVien>(dbContext);
            _thanhVienService = new ThanhVienService(TVRepo);
            
            _thongTinThanhVienService = new ThongTinThanhVienService();
            var BSSRepo = new GenericRepository<BanSaoSach>(dbContext);
            _banSaoSachService = new BanSaoSachService(BSSRepo);

            var ctMuonRepo = new GenericRepository<ChiTietPhieuMuon>(dbContext);
            _chiTietPhieuMuonService = new ChiTietPhieuMuonService(ctMuonRepo);
            var phieuMuonRepo = new GenericRepository<PhieuMuon>(dbContext);

            gcSach.DataSource = _banSaoSachService.GetBaoSaoChuaMuon()
                .Where(bss => bss.MaSachNavigation != null) 
                .Select(bss => new
                {
                    Barcode = bss.Barcode,
                    TenSach = bss.MaSachNavigation.TenSach,
                    TinhTrang = bss.TinhTrang,
                   
                }).ToList();
            gcChiTietMuon.DataSource = _chiTietPhieuMuonService.GetAllChiTietPhieuMuons();
            loadThanhVien();
            _reset();

        }
        void _reset()
        {
            searchThanhVien.EditValue = null;
            dtNgayMuon.Value = DateTime.Now;
            dtNgayTraDuKien.Value = DateTime.Now.AddDays(7);          
            dtNgayTraThucTe.ResetText(); 
            txtGhiChu.Text = "";
        }
        void loadThanhVien()
        {
            var members = _thanhVienService.GetAllMembers()
                .Select(tv => new
                {
                    MaThanhVien = tv.MaThanhVien,
                    TenThanhVien = tv.TenThanhVien,
                })
                .ToList();

            searchThanhVien.Properties.DataSource = members;
            searchThanhVien.Properties.DisplayMember = "TenThanhVien";
            searchThanhVien.Properties.ValueMember = "MaThanhVien";
        }

        private void searchThanhVien_EditValueChanged(object sender, EventArgs e)
        {
            if (searchThanhVien.EditValue != null)
            {
                try
                {
                    int maThanhVien = (int)searchThanhVien.EditValue;
                    var ttThanhVienList = _thongTinThanhVienService.GetThongTinThanhVien(maThanhVien);
                    
                    if (ttThanhVienList != null && ttThanhVienList.Count > 0)
                    {
                        var ttThanhVien = ttThanhVienList.First();
                        
                        txtSoPhieuDangMuon.Text = ttThanhVien.SoPhieuDangMuon.ToString();
                        txtSoSachDangMuon.Text = ttThanhVien.SoSachDangMuon.ToString();
                        txtTongNoPhat.Text = ttThanhVien.TongNoPhat.ToString("N0") + " VNĐ";
                    }
                    else
                    {
                        DeleteInfoTV();
                        MessageBox.Show("Không tìm thấy thông tin chi tiết cho thành viên này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    DeleteInfoTV();
                    MessageBox.Show($"Lỗi khi tải thông tin thành viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                DeleteInfoTV();
            }
        }
        
        private void DeleteInfoTV()
        {
            txtSoPhieuDangMuon.Text = "";
            txtSoSachDangMuon.Text = "";
            txtTongNoPhat.Text = "";
        }

        private void gvChiTietMuon_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                var ctp = e.Row as ChiTietPhieuMuon;
                if (ctp != null) 
                {
                    if (e.Column.FieldName == "TenSach")
                        e.Value = ctp.MaSachNavigation?.TenSach ?? "";
                    if (e.Column.FieldName == "Barcode")
                        e.Value = ctp.MaBanSaoNavigation?.Barcode ?? "";
                    
                }
            }
        }

        private void gvChiTietMuon_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "TrangThai")
            {
                string status = Convert.ToString(gvChiTietMuon.GetRowCellValue(e.RowHandle, "TrangThai"));
                if (status == "Đã trả")
                    e.Appearance.BackColor = Color.LightGreen;
                else e.Appearance.BackColor = Color.MistyRose;
            }
        }
    }
}
