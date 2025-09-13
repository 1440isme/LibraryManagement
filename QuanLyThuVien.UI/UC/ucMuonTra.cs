using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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

namespace QuanLyThuVien.UI.UC
{
    public partial class ucMuonTra : UserControl
    {
        
        private PhieuMuonService _phieuMuonService;
        private ThanhVienService _thanhVienService;
        private ThongTinThanhVienService _thongTinThanhVienService;
        private BanSaoSachService _banSaoSachService;
        private ChiTietPhieuMuonService _chiTietPhieuMuonService;

        public ucMuonTra()
        {
            InitializeComponent();              
        }
        bool _them;
        string _barcode;
        string _tenSach;
        GridHitInfo downHitInfo = null;
        private DataTable _selectedBooksTable;
        private DataTable _availableBooksTable; 
        private List<dynamic> _originalBooksList; 

        private void InitializeSelectedBooksTable()
        {
            _selectedBooksTable = new DataTable();
            _selectedBooksTable.Columns.Add("Barcode", typeof(string));
            _selectedBooksTable.Columns.Add("TenSach", typeof(string));
            _selectedBooksTable.Columns.Add("TinhTrang", typeof(string));
            _selectedBooksTable.Columns.Add("MaBanSao", typeof(int));
            
            gcChiTietMuon.DataSource = _selectedBooksTable;
        }

        private void InitializeAvailableBooksTable()
        {
            _availableBooksTable = new DataTable();
            _availableBooksTable.Columns.Add("Barcode", typeof(string));
            _availableBooksTable.Columns.Add("TenSach", typeof(string));
            _availableBooksTable.Columns.Add("TinhTrang", typeof(string));
            _availableBooksTable.Columns.Add("MaBanSao", typeof(int));
            
            gcSach.DataSource = _availableBooksTable;
        }

        private void ucMuonTra_Load(object sender, EventArgs e)
        {
        
            var dbContext = new QuanLyThuVienContext();
            var repo = new GenericRepository<PhieuMuon>(dbContext);
            _phieuMuonService = new PhieuMuonService(repo);

            var TVRepo = new GenericRepository<ThanhVien>(dbContext);
            _thanhVienService = new ThanhVienService(TVRepo);

            _thongTinThanhVienService = new ThongTinThanhVienService();
            var BSSRepo = new GenericRepository<BanSaoSach>(dbContext);
            _banSaoSachService = new BanSaoSachService(BSSRepo);

            var ctMuonRepo = new GenericRepository<ChiTietPhieuMuon>(dbContext);
            _chiTietPhieuMuonService = new ChiTietPhieuMuonService(ctMuonRepo);
            
            InitializeSelectedBooksTable();
            InitializeAvailableBooksTable();
            
            loadDanhSachMuon();
            loadBanSaoChuaMuon();                
            loadThanhVien();


            _reset();
            showHideControl(true);
            _enable(false);
            
            gcSach.AllowDrop = true;
            gcChiTietMuon.AllowDrop = true;
        }
        void loadDanhSachMuon()
        {
            gcDanhSachMuon.DataSource = _phieuMuonService.GetAllPhieuMuons();
            gvDanhSachMuon.OptionsBehavior.Editable = false;
        }
        void loadBanSaoChuaMuon()
        {
            _originalBooksList = _banSaoSachService.GetBaoSaoChuaMuon()
                .Where(bss => bss.MaSachNavigation != null)
                .Select(bss => new
                {
                    Barcode = bss.Barcode,
                    TenSach = bss.MaSachNavigation.TenSach,
                    TinhTrang = bss.TinhTrang,
                    MaBanSao = bss.MaBanSao
                })
                .Cast<dynamic>()
                .ToList();
            
            RefreshAvailableBooks();
        }

        private void RefreshAvailableBooks()
        {
            _availableBooksTable.Clear();
            
            var selectedBarcodes = new HashSet<string>();
            foreach (DataRow row in _selectedBooksTable.Rows)
            {
                selectedBarcodes.Add(row["Barcode"].ToString());
            }
            
            foreach (var book in _originalBooksList)
            {
                if (!selectedBarcodes.Contains(book.Barcode))
                {
                    var newRow = _availableBooksTable.NewRow();
                    newRow["Barcode"] = book.Barcode;
                    newRow["TenSach"] = book.TenSach;
                    newRow["TinhTrang"] = book.TinhTrang;
                    newRow["MaBanSao"] = book.MaBanSao;
                    _availableBooksTable.Rows.Add(newRow);
                }
            }
            
            gcSach.RefreshDataSource();
        }
        void _reset()
        {
            searchThanhVien.EditValue = null;
            dtNgayMuon.Value = DateTime.Now;
            dtNgayTraDuKien.Value = DateTime.Now.AddDays(7);
            dtNgayTraThucTe.ResetText();
            txtGhiChu.Text = "";
            
            if (_selectedBooksTable != null)
            {
                _selectedBooksTable.Clear();
                gcChiTietMuon.RefreshDataSource();
            }
            
            if (_originalBooksList != null)
            {
                RefreshAvailableBooks();
            }
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
        void showHideControl(bool t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
            btnBoQua.Enabled = !t;

        }
        void _enable(bool t)
        {
            searchThanhVien.Enabled = t;
            dtNgayMuon.Enabled = t;
            dtNgayTraDuKien.Enabled = t;
            dtNgayTraThucTe.Enabled = t;
            txtGhiChu.Enabled = t;
            
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true;
            showHideControl(false);
            _enable(true);
            _reset();            
            tabQLSach.SelectedTabPage = pageChiTiet;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var pm = gvDanhSachMuon.GetFocusedRow() as PhieuMuon;
            if (pm.MaPhieuMuon == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (pm.TrangThai == "Đã trả hết")
            {
                MessageBox.Show("Phiếu đã hoàn tất không được chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _them = false;
            _enable(true);
            showHideControl(false);
            tabQLSach.SelectedTabPage = pageChiTiet;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var pm = gvDanhSachMuon.GetFocusedRow() as PhieuMuon;
            if (pm == null || pm.MaPhieuMuon == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn để xoá.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (pm.TrangThai == "Đã trả hết")
            {
                MessageBox.Show("Phiếu đã hoàn tất không được xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu mượn này?\nViệc này sẽ xóa tất cả chi tiết mượn sách liên quan.", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var lstChiTietPhieuMuon = _chiTietPhieuMuonService.GetAllByPhieuMuon(pm.MaPhieuMuon);
                    
                    foreach (var chiTiet in lstChiTietPhieuMuon)
                    {
                        if (chiTiet.NgayTraThucTe == null)
                        {
                            if (chiTiet.MaBanSao.HasValue)
                            {
                                var banSao = _banSaoSachService.GetAllBanSaoSach()
                                    .FirstOrDefault(bs => bs.MaBanSao == chiTiet.MaBanSao.Value);
                                if (banSao != null)
                                {
                                    banSao.TinhTrang = "Sẵn sàng";
                                    _banSaoSachService.UpdateBanSaoSach(banSao);
                                }
                            }
                        }
                        
                        _chiTietPhieuMuonService.DeleteChiTietPhieuMuon(chiTiet.MaChiTiet);
                    }
                    
                    _phieuMuonService.DeletePhieuMuon(pm.MaPhieuMuon);
                    
                    loadDanhSachMuon();
                    loadBanSaoChuaMuon();
                    
                    MessageBox.Show("Xóa phiếu mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa phiếu mượn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (searchThanhVien.EditValue == null )
            {
                MessageBox.Show("Vui lòng chọn thành viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_selectedBooksTable.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (DateTime.Now > dtNgayTraDuKien.Value)
            {
                MessageBox.Show("Ngày trả sách không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SaveData();
            _them = false;
            _enable(false);
            showHideControl(true);
            loadDanhSachMuon();
            loadBanSaoChuaMuon(); 
            MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnBoQua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            showHideControl(true);
            _enable(false);
            _reset();
            loadDanhSachMuon();
            loadBanSaoChuaMuon(); 
            tabQLSach.SelectedTabPage = pageDanhSachMuon;
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


        private void SaveData()
        {
            try
            {
                if (_them)
                {
                    if (searchThanhVien.EditValue == null)
                    {
                        MessageBox.Show("Vui lòng chọn thành viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var selectedBanSao = GetSelectedBanSaoList(); 
                    
                    if (selectedBanSao == null || selectedBanSao.Count == 0)
                    {
                        MessageBox.Show("Vui lòng chọn ít nhất một sách để mượn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int maThanhVien = (int)searchThanhVien.EditValue;
                    int userId = 3;
                    DateTime ngayTraDuKien = dtNgayTraDuKien.Value;

                    int maPhieuMuon = _phieuMuonService.MuonSach(
                        maThanhVien, 
                        userId, 
                        ngayTraDuKien, 
                        selectedBanSao
                    );

                    MessageBox.Show($"Tạo phiếu mượn thành công! Mã phiếu: {maPhieuMuon}", 
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var pm = gvDanhSachMuon.GetFocusedRow() as PhieuMuon;
                    if (pm != null)
                    {
                        var selectedBanSao = GetSelectedBanSaoList();
                        if (selectedBanSao != null && selectedBanSao.Count > 0)
                        {
                            int userId = 3;
                            
                            // Update phiếu mượn với các sách mới
                            _phieuMuonService.MuonSach(
                                pm.MaThanhVien,
                                userId,
                                dtNgayTraDuKien.Value,
                                selectedBanSao,
                                pm.MaPhieuMuon
                            );

                            MessageBox.Show("Cập nhật phiếu mượn thành công!", 
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<int> GetSelectedBanSaoList()
        {
            var selectedBanSao = new List<int>();
            
            foreach (DataRow row in _selectedBooksTable.Rows)
            {
                if (int.TryParse(row["MaBanSao"].ToString(), out int maBanSao))
                {
                    selectedBanSao.Add(maBanSao);
                }
            }
            
            return selectedBanSao;
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

        private void gvSach_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            downHitInfo = null;
            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None) return;
            if (e.Button == MouseButtons.Left && hitInfo.RowHandle >= 0)
            {
                downHitInfo = hitInfo;
            }
        }

        private void gvSach_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(
                    new Point(downHitInfo.HitPoint.X - dragSize.Width / 2, 
                             downHitInfo.HitPoint.Y - dragSize.Height / 2), 
                    dragSize);
                    
                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    var rowHandle = downHitInfo.RowHandle;
                    var barcode = view.GetRowCellValue(rowHandle, "Barcode")?.ToString();
                    var tenSach = view.GetRowCellValue(rowHandle, "TenSach")?.ToString();
                    var tinhTrang = view.GetRowCellValue(rowHandle, "TinhTrang")?.ToString();
                    var maBanSao = view.GetRowCellValue(rowHandle, "MaBanSao");

                    if (!string.IsNullOrEmpty(barcode))
                    {
                        string dragData = $"gvSach|{barcode}|{tenSach}|{tinhTrang}|{maBanSao}";
                        view.GridControl.DoDragDrop(dragData, DragDropEffects.Move);
                    }
                    
                    downHitInfo = null;
                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                }
            }
        }

        private void gvChiTietMuon_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            downHitInfo = null;
            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None) return;
            if (e.Button == MouseButtons.Left && hitInfo.RowHandle >= 0)
            {
                downHitInfo = hitInfo;
            }
        }

        private void gvChiTietMuon_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(
                    new Point(downHitInfo.HitPoint.X - dragSize.Width / 2, 
                             downHitInfo.HitPoint.Y - dragSize.Height / 2), 
                    dragSize);
                    
                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    var rowHandle = downHitInfo.RowHandle;
                    var barcode = view.GetRowCellValue(rowHandle, "Barcode")?.ToString();
                    var tenSach = view.GetRowCellValue(rowHandle, "TenSach")?.ToString();
                    var tinhTrang = view.GetRowCellValue(rowHandle, "TinhTrang")?.ToString();
                    var maBanSao = view.GetRowCellValue(rowHandle, "MaBanSao");

                    if (!string.IsNullOrEmpty(barcode))
                    {
                        string dragData = $"gvChiTietMuon|{barcode}|{tenSach}|{tinhTrang}|{maBanSao}";
                        view.GridControl.DoDragDrop(dragData, DragDropEffects.Move);
                    }
                    
                    downHitInfo = null;
                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                }
            }
        }

        private void gcChiTietMuon_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string data = e.Data.GetData(DataFormats.StringFormat) as string;
                if (!string.IsNullOrEmpty(data) && data.StartsWith("gvSach|"))
                {
                    if (_them || (!_them && gvDanhSachMuon.GetFocusedRow() != null))
                    {
                        e.Effect = DragDropEffects.Move;
                    }
                    else
                    {
                        e.Effect = DragDropEffects.None;
                    }
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void gcChiTietMuon_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string dragData = e.Data.GetData(DataFormats.StringFormat) as string;
                    if (!string.IsNullOrEmpty(dragData))
                    {
                        string[] parts = dragData.Split('|');
                        if (parts.Length >= 5 && parts[0] == "gvSach")
                        {
                            string barcode = parts[1];
                            string tenSach = parts[2];
                            string tinhTrang = parts[3];
                            string maBanSaoStr = parts[4];

                            if (!string.IsNullOrEmpty(barcode))
                            {
                                bool alreadyExists = false;
                                foreach (DataRow row in _selectedBooksTable.Rows)
                                {
                                    if (row["Barcode"].ToString() == barcode)
                                    {
                                        alreadyExists = true;
                                        break;
                                    }
                                }

                                if (!alreadyExists)
                                {
                                    var newRow = _selectedBooksTable.NewRow();
                                    newRow["Barcode"] = barcode;
                                    newRow["TenSach"] = tenSach;
                                    newRow["TinhTrang"] = tinhTrang;
                                    
                                    if (int.TryParse(maBanSaoStr, out int maBanSao))
                                    {
                                        newRow["MaBanSao"] = maBanSao;
                                    }
                                    
                                    _selectedBooksTable.Rows.Add(newRow);
                                    gcChiTietMuon.RefreshDataSource();
                                    
                                    RemoveFromAvailableBooks(barcode);
                                }
                                else
                                {
                                    MessageBox.Show($"Sách '{tenSach}' đã được chọn.", "Thông báo", 
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm sách: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcSach_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string data = e.Data.GetData(DataFormats.StringFormat) as string;
                if (!string.IsNullOrEmpty(data) && data.StartsWith("gvChiTietMuon|"))
                {
                    e.Effect = DragDropEffects.Move;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void gcSach_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string dragData = e.Data.GetData(DataFormats.StringFormat) as string;
                    if (!string.IsNullOrEmpty(dragData))
                    {
                        string[] parts = dragData.Split('|');
                        if (parts.Length >= 3 && parts[0] == "gvChiTietMuon")
                        {
                            string barcode = parts[1];
                            string tenSach = parts[2];

                            if (!string.IsNullOrEmpty(barcode))
                            {
                                for (int i = _selectedBooksTable.Rows.Count - 1; i >= 0; i--)
                                {
                                    if (_selectedBooksTable.Rows[i]["Barcode"].ToString() == barcode)
                                    {
                                        _selectedBooksTable.Rows.RemoveAt(i);
                                        break;
                                    }
                                }

                                gcChiTietMuon.RefreshDataSource();
                                
                                AddBackToAvailableBooks(barcode);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa sách: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveFromAvailableBooks(string barcode)
        {
            for (int i = _availableBooksTable.Rows.Count - 1; i >= 0; i--)
            {
                if (_availableBooksTable.Rows[i]["Barcode"].ToString() == barcode)
                {
                    _availableBooksTable.Rows.RemoveAt(i);
                    break;
                }
            }

            gcSach.RefreshDataSource();
        }

        private void AddBackToAvailableBooks(string barcode)
        {
            var book = _originalBooksList.FirstOrDefault(b => b.Barcode == barcode);
            if (book != null)
            {
                var newRow = _availableBooksTable.NewRow();
                newRow["Barcode"] = book.Barcode;
                newRow["TenSach"] = book.TenSach;
                newRow["TinhTrang"] = book.TinhTrang;
                newRow["MaBanSao"] = book.MaBanSao;
                _availableBooksTable.Rows.Add(newRow);
            }

            gcSach.RefreshDataSource();
        }
    }
}
