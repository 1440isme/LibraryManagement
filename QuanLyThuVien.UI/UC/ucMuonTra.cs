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
        private TraSachProcService _traSachProcService;

        private int _currentPhieuMuonId = 0;

        public ucMuonTra()
        {
            InitializeComponent();              
        }
        bool _them;
     
        GridHitInfo downHitInfo = null;
        private DataTable _selectedBooksTable;
        private DataTable _availableBooksTable; 
        private List<dynamic> _originalBooksList; 

        private void InitializeSelectedBooksTable()
        {
            _selectedBooksTable = new DataTable();
            
            _selectedBooksTable.Columns.Add("MaChiTiet", typeof(int));
            _selectedBooksTable.Columns.Add("MaPhieuMuon", typeof(int));
            _selectedBooksTable.Columns.Add("MaThanhVien", typeof(int));
            _selectedBooksTable.Columns.Add("TenThanhVien", typeof(string));
            _selectedBooksTable.Columns.Add("SoPhieuDangMuon", typeof(int));
            _selectedBooksTable.Columns.Add("SoSachDangMuon", typeof(int));
            _selectedBooksTable.Columns.Add("TongNoPhat", typeof(decimal));
            _selectedBooksTable.Columns.Add("Barcode", typeof(string));
            _selectedBooksTable.Columns.Add("TenSach", typeof(string));
            _selectedBooksTable.Columns.Add("TinhTrang", typeof(string));
            _selectedBooksTable.Columns.Add("MaBanSao", typeof(int));
            _selectedBooksTable.Columns.Add("NgayTraDuKien", typeof(DateTime));
            _selectedBooksTable.Columns.Add("NgayTraThucTe", typeof(DateTime));
            _selectedBooksTable.Columns.Add("TrangThai", typeof(string));
            _selectedBooksTable.Columns.Add("GhiChu", typeof(string));
            _selectedBooksTable.Columns.Add("NgayMuon", typeof(DateTime));
            _selectedBooksTable.Columns.Add("TraButtonCol", typeof(string));

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
            
            _traSachProcService = new TraSachProcService(); 
            
            InitializeSelectedBooksTable();
            InitializeAvailableBooksTable();
            
            loadDanhSachMuon();
            loadBanSaoChuaMuon();                
            loadThanhVien();
            AddTraButtonColumn();

            _reset();
            showHideControl(true);
            _enable(false);
            
            gcSach.AllowDrop = true;
            gcChiTietMuon.AllowDrop = true;
            gvChiTietMuon.OptionsSelection.MultiSelect = true;
            gvChiTietMuon.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;

            gvChiTietMuon.CellValueChanged += gvChiTietMuon_CellValueChanged;
            gvChiTietMuon.ValidateRow += gvChiTietMuon_ValidateRow;


            btnTra.Click += btnTra_Click;
        }
        private void AddTraButtonColumn()
        {
            var existingCol = gvChiTietMuon.Columns["TraButtonCol"];
            if (existingCol != null)
            {
                gvChiTietMuon.Columns.Remove(existingCol);
            }
            if (gvChiTietMuon.Columns["TraButtonCol"] == null)
            {
                var traButtonCol = gvChiTietMuon.Columns.AddField("TraButtonCol");
                traButtonCol.Caption = "TRẢ";
                traButtonCol.AppearanceHeader.Font = new Font(traButtonCol.AppearanceHeader.Font, FontStyle.Bold); 
                traButtonCol.Visible = true;
                traButtonCol.AppearanceCell.BackColor = Color.FromArgb(255, 223, 186);
                traButtonCol.UnboundType = DevExpress.Data.UnboundColumnType.Object;
                traButtonCol.OptionsColumn.AllowEdit = true;
                traButtonCol.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                traButtonCol.OptionsColumn.AllowMove = false;
                traButtonCol.Width = 50;

                var buttonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                buttonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                buttonEdit.Buttons.Clear();
                buttonEdit.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton(
                    DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Trả", -1, true, true, false,
                    DevExpress.XtraEditors.ImageLocation.MiddleCenter, null));

                traButtonCol.ColumnEdit = buttonEdit;

                buttonEdit.ButtonClick += (sender, e) => {
                    var gridView = gvChiTietMuon;
                    var currentRowHandle = gridView.FocusedRowHandle;
                    
                    if (currentRowHandle >= 0 && !gridView.IsRowSelected(currentRowHandle))
                    {
                        gridView.SelectRow(currentRowHandle);
                    }
                    
                    btnTra_Click(sender, EventArgs.Empty);
                };
            }
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
        void loadChiTietMuon(int maPhieuMuon, bool isEditMode = false)
        {
            try
            {
                _currentPhieuMuonId = maPhieuMuon;
                
                var chiTietList = _chiTietPhieuMuonService.GetAllByPhieuMuon(maPhieuMuon);
                
                var phieuMuon = _phieuMuonService.GetAllPhieuMuons()
                    .FirstOrDefault(pm => pm.MaPhieuMuon == maPhieuMuon);
                
                _selectedBooksTable.Clear();
                
                foreach (var ct in chiTietList)
                {
                    if (ct.MaBanSaoNavigation != null && ct.MaSachNavigation != null)
                    {
                        var thanhVien = phieuMuon?.MaThanhVienNavigation;
                        
                        var newRow = _selectedBooksTable.NewRow();
                        
                        newRow["MaChiTiet"] = ct.MaChiTiet;
                        newRow["MaPhieuMuon"] = ct.MaPhieuMuon;
                        
                        newRow["MaThanhVien"] = phieuMuon?.MaThanhVien ?? 0;
                        newRow["TenThanhVien"] = thanhVien?.TenThanhVien ?? "N/A";
                        
                        newRow["Barcode"] = ct.MaBanSaoNavigation.Barcode;
                        newRow["TenSach"] = ct.MaSachNavigation.TenSach;
                        newRow["MaBanSao"] = ct.MaBanSao ?? 0;
                        
                        newRow["NgayMuon"] = phieuMuon?.NgayMuon ?? DateTime.Now;
                        newRow["NgayTraDuKien"] = ct.NgayTraDuKien ?? DateTime.Now;
                        newRow["NgayTraThucTe"] = ct.NgayTraThucTe.HasValue ? (object)ct.NgayTraThucTe.Value : DBNull.Value;
                        newRow["TrangThai"] = ct.TrangThai ?? "N/A";
                        newRow["GhiChu"] = ct.GhiChu ?? "";
                        
                        _selectedBooksTable.Rows.Add(newRow);
                    }
                }
                
                _selectedBooksTable.AcceptChanges();
                gcChiTietMuon.RefreshDataSource();
                gvChiTietMuon.RefreshData();

                ConfigureEditableColumns(isEditMode);
                
                RefreshAvailableBooks();
                
                if (phieuMuon != null)
                {
                    LoadPhieuMuonInfoToControls(phieuMuon);
                }
                
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết phiếu mượn: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureEditableColumns(bool isEditMode = false)
        {
            gvChiTietMuon.OptionsBehavior.Editable = true;
            
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvChiTietMuon.Columns)
            {
                if (col.FieldName == "TraButtonCol")
                {
                    col.OptionsColumn.AllowEdit = true;
                }
                else if (isEditMode && (col.FieldName == "NgayTraDuKien" || 
                                  col.FieldName == "NgayTraThucTe" || 
                                  col.FieldName == "TrangThai" || 
                                  col.FieldName == "GhiChu"))
                {
                    col.OptionsColumn.AllowEdit = true;
                }
                else
                {
                    col.OptionsColumn.AllowEdit = false;
                }
            }
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
            
            gcSach.AllowDrop = true;
            gcChiTietMuon.AllowDrop = true;
            
            tabQLSach.SelectedTabPage = pageChiTiet;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var pm = gvDanhSachMuon.GetFocusedRow() as PhieuMuon;
            if (pm == null || pm.MaPhieuMuon == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (pm.TrangThai == "Đã trả hết")
            {
                MessageBox.Show("Phiếu đã hoàn tất không được chỉnh sửa!\nBạn chỉ có thể xem thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            _them = false;
            _enable(true);
            showHideControl(false);
            
            loadChiTietMuon(pm.MaPhieuMuon, isEditMode: true);
            
            gcSach.AllowDrop = false;
            gcChiTietMuon.AllowDrop = false;
            
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
            if (searchThanhVien.EditValue == null)
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
            
            try
            {
                SaveData();
                _them = false;
                _enable(false);
                showHideControl(true);
                
                loadDanhSachMuon();
                loadBanSaoChuaMuon();
                
                if (!_them && gvDanhSachMuon.GetFocusedRow() is PhieuMuon pm)
                {
                    loadChiTietMuon(pm.MaPhieuMuon, isEditMode: false);
                }
                tabQLSach.SelectedTabPage = pageDanhSachMuon;
                //MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBoQua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            showHideControl(true);
            _enable(false);
            _reset();
            
            gcSach.AllowDrop = true;
            gcChiTietMuon.AllowDrop = true;
            
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
                    string ghichu = txtGhiChu.Text.Trim();
                    DateTime ngayTraDuKien = dtNgayTraDuKien.Value;

                    int maPhieuMuon = _phieuMuonService.MuonSach(
                        maThanhVien, 
                        userId, 
                        ngayTraDuKien, 
                        selectedBanSao,
                        ghichu
                    );

                    MessageBox.Show($"Tạo phiếu mượn thành công! Mã phiếu: {maPhieuMuon}", 
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (_selectedBooksTable.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }                   

                    SaveChangedChiTietPhieuMuon();
                    
                    MessageBox.Show("Cập nhật phiếu mượn thành công!", 
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveChangedChiTietPhieuMuon()
        {
            try
            {
                int updatedCount = 0;
                
                gvChiTietMuon.PostEditor();
                gvChiTietMuon.UpdateCurrentRow();
                
                
                foreach (DataRow row in _selectedBooksTable.Rows)
                {
                    if (row["MaChiTiet"] != DBNull.Value && Convert.ToInt32(row["MaChiTiet"]) > 0)
                    {
                        int maChiTiet = Convert.ToInt32(row["MaChiTiet"]);
                        
                        
                        var chiTiet = _chiTietPhieuMuonService.GetById(maChiTiet);
                        if (chiTiet != null)
                        {
                            var oldNgayTraDuKien = chiTiet.NgayTraDuKien;
                            var newNgayTraDuKien = Convert.ToDateTime(row["NgayTraDuKien"]);
                            
                            
                            if (oldNgayTraDuKien != newNgayTraDuKien || 
                                (chiTiet.NgayTraThucTe?.ToString() != (row["NgayTraThucTe"] == DBNull.Value ? null : row["NgayTraThucTe"].ToString())) ||
                                chiTiet.TrangThai != row["TrangThai"]?.ToString() ||
                                chiTiet.GhiChu != row["GhiChu"]?.ToString())
                            {
                                chiTiet.NgayTraDuKien = newNgayTraDuKien;
                                chiTiet.NgayTraThucTe = row["NgayTraThucTe"] == DBNull.Value ? 
                                    (DateTime?)null : Convert.ToDateTime(row["NgayTraThucTe"]);
                                chiTiet.TrangThai = row["TrangThai"]?.ToString();
                                chiTiet.GhiChu = row["GhiChu"]?.ToString();
                                
                                _chiTietPhieuMuonService.UpdateChiTietPhieuMuon(chiTiet);
                                updatedCount++;
                                
                            }
                            
                        }
                        
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lưu chi tiết phiếu mượn: {ex.Message}");
            }
        }

        private List<int> GetSelectedBanSaoList()
        {
            var selectedBanSao = new List<int>();
            
            if (_them)
            {
                foreach (DataRow row in _selectedBooksTable.Rows)
                {
                    if (int.TryParse(row["MaBanSao"].ToString(), out int maBanSao))
                    {
                        selectedBanSao.Add(maBanSao);
                    }
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
                                foreach (DataRow row in _selectedBooksTable.Rows
                                )
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

        private void gvDanhSachMuon_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "TrangThai")
            {
                string status = Convert.ToString(gvDanhSachMuon.GetRowCellValue(e.RowHandle, "TrangThai"));
                if (status == "Đã trả hết")
                    e.Appearance.BackColor = Color.LightGreen;
                else e.Appearance.BackColor = Color.MistyRose;
            }
        }

        private void gvDanhSachMuon_DoubleClick(object sender, EventArgs e)
        {
            if (gvDanhSachMuon.RowCount > 0)
            {
                int maphieumuon = Convert.ToInt32(gvDanhSachMuon.GetFocusedRowCellValue("MaPhieuMuon"));
                
                loadChiTietMuon(maphieumuon, isEditMode: false);
                
                gcSach.AllowDrop = false;
                gcChiTietMuon.AllowDrop = false;
                
                _enable(false);
                
                tabQLSach.SelectedTabPage = pageChiTiet;
            }
        }

        private void LoadPhieuMuonInfoToControls(PhieuMuon phieuMuon)
        {
            try
            {
                searchThanhVien.EditValue = phieuMuon.MaThanhVien;
                dtNgayMuon.Value = phieuMuon.NgayMuon;
                dtNgayTraDuKien.Value = phieuMuon.NgayTraDuKien ?? DateTime.Now.AddDays(7);
                txtGhiChu.Text = phieuMuon.GhiChu ?? "";
                
                if (phieuMuon.MaThanhVienNavigation != null)
                {
                    var ttThanhVienList = _thongTinThanhVienService.GetThongTinThanhVien(phieuMuon.MaThanhVien);
                    if (ttThanhVienList != null && ttThanhVienList.Count > 0)
                    {
                        var ttThanhVien = ttThanhVienList.First();
                        txtSoPhieuDangMuon.Text = ttThanhVien.SoPhieuDangMuon.ToString();
                        txtSoSachDangMuon.Text = ttThanhVien.SoSachDangMuon.ToString();
                        txtTongNoPhat.Text = ttThanhVien.TongNoPhat.ToString("N0") + " VNĐ";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin phiếu mượn: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvChiTietMuon_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
           
                if (!gvChiTietMuon.OptionsBehavior.Editable) return;
                                
                var rowHandle = e.RowHandle;
                var maChiTiet = gvChiTietMuon.GetRowCellValue(rowHandle, "MaChiTiet");
                       
        }

        private void gvChiTietMuon_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            
                var gridView = sender as GridView;
                

                var ngayTraDuKien = gridView.GetRowCellValue(e.RowHandle, "NgayTraDuKien");
                var ngayMuon = gridView.GetRowCellValue(e.RowHandle, "NgayMuon");
                
                if (ngayTraDuKien != null && ngayMuon != null)
                {
                    var duKien = Convert.ToDateTime(ngayTraDuKien);
                    var muon = Convert.ToDateTime(ngayMuon);
                    
                    if (duKien < muon)
                    {
                        e.Valid = false;
                        e.ErrorText = "Ngày trả dự kiến không thể nhỏ hơn ngày mượn.";
                        return;
                    }
                }
                
                var ngayTraThucTe = gridView.GetRowCellValue(e.RowHandle, "NgayTraThucTe");
                if (ngayTraThucTe != null && ngayTraThucTe != DBNull.Value)
                {
                    var thucTe = Convert.ToDateTime(ngayTraThucTe);
                    var muon = Convert.ToDateTime(ngayMuon);
                    
                    if (thucTe < muon)
                    {
                        e.Valid = false;
                        e.ErrorText = "Ngày trả thực tế không thể nhỏ hơn ngày mượn.";
                        return;
                    }
                }
                
                     
        }

        private void btnTra_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = GetSelectedUnreturnedBooks();

                if (selectedRows == null || selectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một sách chưa trả để thực hiện trả sách!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiển thị thông tin các sách sẽ được trả
                var bookNames = selectedRows.Select(row => row["TenSach"].ToString()).ToList();
                var confirmMessage = $"Bạn đang trả {selectedRows.Count} cuốn sách:\n" +
                           string.Join("\n• ", bookNames.Take(3));
        
                if (bookNames.Count > 3)
                {
                    confirmMessage += $"\n• ... và {bookNames.Count - 3} cuốn khác";
                }
        
                confirmMessage += "\n\nBạn có chắc chắn muốn tiếp tục?";

                var confirmResult = MessageBox.Show(confirmMessage, "Xác nhận trả sách", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
                if (confirmResult != DialogResult.Yes)
                    return;

                using (var form = new frmTraSach())
                {
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.Text = $"Trả {selectedRows.Count} cuốn sách";

                    var result = form.ShowDialog(this.ParentForm);

                    if (result == DialogResult.OK)
                    {
                        try
                        {
                            var listMaBanSao = selectedRows.Select(row => Convert.ToInt32(row["MaBanSao"])).ToList();
                            int userId = 3;

                            _traSachProcService.ExecuteTraNhieuSachProc(
                                listMaBanSao,
                                userId,
                                form.TinhTrangSach,
                                form.GhiChu
                            );

                            MessageBox.Show($"Trả sách thành công cho {selectedRows.Count} cuốn sách!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            RefreshDataAfterReturn();
                            tabQLSach.SelectedTabPage = pageDanhSachMuon;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi trả sách: {ex.Message}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form trả sách: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<DataRow> GetSelectedUnreturnedBooks()
        {
            var selectedRows = new List<DataRow>();
            
            var selectedRowHandles = gvChiTietMuon.GetSelectedRows();
            
            if (selectedRowHandles.Length == 0)
            {
                var focusedRowHandle = gvChiTietMuon.FocusedRowHandle;
                if (focusedRowHandle >= 0)
                {
                    selectedRowHandles = new int[] { focusedRowHandle };
                }
            }

            foreach (var rowHandle in selectedRowHandles)
            {
                if (rowHandle >= 0)
                {
                    var row = gvChiTietMuon.GetDataRow(rowHandle);
                    if (row != null)
                    {
                        var ngayTraThucTe = row["NgayTraThucTe"];
                        var trangThai = row["TrangThai"]?.ToString();
                        
                        if (ngayTraThucTe == DBNull.Value && trangThai != "Đã trả")
                        {
                            selectedRows.Add(row);
                        }
                    }
                }
            }

            return selectedRows;
        }

        private void RefreshDataAfterReturn()
        {
            try
            {
                int currentPhieuMuonId = _currentPhieuMuonId;

                loadDanhSachMuon();
                loadBanSaoChuaMuon();

                if (currentPhieuMuonId > 0)
                {
                    gcDanhSachMuon.RefreshDataSource();
                    gvDanhSachMuon.RefreshData();
                    Application.DoEvents();

                    _selectedBooksTable.Clear();

                    bool found = false;
                    for (int i = 0; i < gvDanhSachMuon.RowCount; i++)
                    {
                        var phieuMuon = gvDanhSachMuon.GetRow(i) as PhieuMuon;
                        if (phieuMuon != null && phieuMuon.MaPhieuMuon == currentPhieuMuonId)
                        {
                            gvDanhSachMuon.FocusedRowHandle = i;
                            gvDanhSachMuon.SelectRow(i);
                            found = true;
                            break;
                        }
                    }

                    var chiTietList = _chiTietPhieuMuonService.GetAllByPhieuMuon(currentPhieuMuonId);
                    loadChiTietMuon(currentPhieuMuonId, isEditMode: false);
                }

                if (searchThanhVien.EditValue != null)
                {
                    searchThanhVien_EditValueChanged(searchThanhVien, EventArgs.Empty);
                }

                gcDanhSachMuon.RefreshDataSource();
                gcChiTietMuon.RefreshDataSource();
                gcSach.RefreshDataSource();

                Application.DoEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi làm mới dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
