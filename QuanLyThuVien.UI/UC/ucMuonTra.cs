using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using QuanLyThuVien.BLL.Services;
using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.UI.Interfaces;
using QuanLyThuVien.UI.UC.Pages;
using System;
using System.Data.Entity; 
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
    public partial class ucMuonTra : UserControl, IActivatable
    {
        private PhieuMuonService _phieuMuonService;
        private ThanhVienService _thanhVienService;
        private ThongTinThanhVienService _thongTinThanhVienService;
        private BanSaoSachService _banSaoSachService;
        private ChiTietPhieuMuonService _chiTietPhieuMuonService;
        private TraSachProcService _traSachProcService;

        private int _currentPhieuMuonId = 0;
        private bool _isDataLoaded = false;
        private bool _isInitialized = false;

        public bool IsDataLoaded => _isDataLoaded;

        public ucMuonTra()
        {
            InitializeComponent();
        }
        bool _them;

        GridHitInfo downHitInfo = null;
        private List<ChiTietPhieuMuonViewModel> _selectedBooksData;
        private List<BanSaoSachViewModel> _availableBooksData;

        private List<dynamic> _originalBooksList;

        private void InitializeDataSources()
        {
            _selectedBooksData = new List<ChiTietPhieuMuonViewModel>();
            _availableBooksData = new List<BanSaoSachViewModel>();

            gcChiTietMuon.DataSource = _selectedBooksData;
            gcSach.DataSource = _availableBooksData;
        }

        private void ucMuonTra_Load(object sender, EventArgs e)
        {
           
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

                buttonEdit.ButtonClick += (sender, e) =>
                {
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
            try
            {
                using (var freshContext = ContextFactory.CreateContext())
                {
                    var freshRepo = new GenericRepository<PhieuMuon>(freshContext);
                    var freshService = new PhieuMuonService(freshRepo);

                    gcDanhSachMuon.DataSource = null;
                    gcDanhSachMuon.DataSource = freshService.GetAllPhieuMuons().ToList();
                }

                gvDanhSachMuon.OptionsBehavior.Editable = true;
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvDanhSachMuon.Columns)
                {
                    col.OptionsColumn.AllowEdit = false;
                }

                var mailColumn = gvDanhSachMuon.Columns["Mail"];
                if (mailColumn != null)
                {
                    mailColumn.OptionsColumn.AllowEdit = true;
                }
                gcDanhSachMuon.RefreshDataSource();
                gvDanhSachMuon.RefreshData();
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi load danh sách mượn: {ex.Message}");
            }
        }
        void loadBanSaoChuaMuon()
        {
            try
            {
                using (var freshContext = ContextFactory.CreateContext())
                {
                    var freshRepo = new GenericRepository<BanSaoSach>(freshContext);
                    var freshService = new BanSaoSachService(freshRepo);

                    var availableBooks = freshService.GetAvailableBooksViewModel();
                    _originalBooksList = availableBooks.Cast<dynamic>().ToList();
                }

                RefreshAvailableBooks();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi load bản sao chưa mượn: {ex.Message}");
            }
        }
        void loadChiTietMuon(int maPhieuMuon, bool isEditMode = false)
        {
            try
            {
                _currentPhieuMuonId = maPhieuMuon;

                using (var freshContext = ContextFactory.CreateContext())
                {
                    var freshCtRepo = new GenericRepository<ChiTietPhieuMuon>(freshContext);
                    var freshCtService = new ChiTietPhieuMuonService(freshCtRepo);

                    _selectedBooksData.Clear();
                    var viewModels = freshCtService.GetChiTietPhieuMuonViewModels(maPhieuMuon);
                    _selectedBooksData.AddRange(viewModels);

                    var phieuMuon = freshContext.PhieuMuon
                        .Include(pm => pm.MaThanhVienNavigation)
                        .FirstOrDefault(pm => pm.MaPhieuMuon == maPhieuMuon);

                    gcChiTietMuon.RefreshDataSource();
                    gvChiTietMuon.RefreshData();

                    ConfigureEditableColumns(isEditMode);
                    RefreshAvailableBooks();

                    if (phieuMuon != null)
                    {
                        LoadPhieuMuonInfoToControls(phieuMuon);
                    }
                }
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
            _availableBooksData.Clear();

            var selectedBarcodes = new HashSet<string>(_selectedBooksData.Select(x => x.Barcode));

            foreach (var book in _originalBooksList)
            {
                if (!selectedBarcodes.Contains(book.Barcode))
                {
                    _availableBooksData.Add(new BanSaoSachViewModel
                    {
                        Barcode = book.Barcode,
                        TenSach = book.TenSach,
                        TinhTrang = book.TinhTrang,
                        MaBanSao = book.MaBanSao
                    });
                }
            }

            gcSach.RefreshDataSource();
        }
        void _reset()
        {
            searchThanhVien.EditValue = null;
            dtNgayMuon.Value = DateTime.Now;
            dtNgayTraDuKien.Value = DateTime.Now.AddDays(7);
            txtGhiChu.Text = "";

            if (_selectedBooksData != null)
            {
                _selectedBooksData.Clear();
                gcChiTietMuon.RefreshDataSource();
            }

            if (_originalBooksList != null)
            {
                RefreshAvailableBooks();
            }
        }
        void loadThanhVien()
        {
            try
            {
                var currentSelectedValue = searchThanhVien.EditValue;

                using (var freshContext = ContextFactory.CreateContext())
                {
                    var freshRepo = new GenericRepository<ThanhVien>(freshContext);
                    var freshService = new ThanhVienService(freshRepo);

                    var members = freshService.GetAllMembers()
                        .Select(tv => new
                        {
                            MaThanhVien = tv.MaThanhVien,
                            TenThanhVien = tv.TenThanhVien,
                        })
                        .ToList();

                    searchThanhVien.Properties.DataSource = null;
                    searchThanhVien.RefreshEditValue();
                    Application.DoEvents();

                    searchThanhVien.Properties.DataSource = members;
                    searchThanhVien.Properties.DisplayMember = "TenThanhVien";
                    searchThanhVien.Properties.ValueMember = "MaThanhVien";

                    searchThanhVien.Properties.PopulateViewColumns();
                    searchThanhVien.RefreshEditValue();
                    Application.DoEvents();
                }

                if (currentSelectedValue != null)
                {
                    var stillExists = ((List<dynamic>)searchThanhVien.Properties.DataSource)
                        .Any(m => m.MaThanhVien.Equals(currentSelectedValue));
                    if (stillExists)
                    {
                        searchThanhVien.EditValue = currentSelectedValue;
                    }
                    else
                    {
                        searchThanhVien.EditValue = null;
                        DeleteInfoTV();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi load thành viên: {ex.Message}");
            }
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
            if (_selectedBooksData.Count == 0)
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

                    int userId = frmMain.CurrentUser;
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
                    if (_selectedBooksData.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var pm = gvDanhSachMuon.GetFocusedRow() as PhieuMuon;
                    if (pm == null || pm.MaPhieuMuon == 0)
                    {
                        MessageBox.Show("Phiếu mượn không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    SynchronizeReturnDates(pm);

                    pm.NgayMuon = dtNgayMuon.Value;
                    pm.NgayTraDuKien = dtNgayTraDuKien.Value;
                    pm.GhiChu = txtGhiChu.Text.Trim();
                    _phieuMuonService.UpdatePhieuMuon(pm);

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
        private void SynchronizeReturnDates(PhieuMuon pm)
        {
            try
            {
                DateTime phieuMuonNgayTraDuKien = dtNgayTraDuKien.Value;

                var maxChildReturnDate = _selectedBooksData
                    .Where(x => x.NgayTraThucTe == null) 
                    .Max(x => x.NgayTraDuKien);

                if (phieuMuonNgayTraDuKien < maxChildReturnDate)
                {
                    dtNgayTraDuKien.Value = maxChildReturnDate;
                    phieuMuonNgayTraDuKien = maxChildReturnDate;

                    MessageBox.Show($"Ngày trả dự kiến của phiếu mượn đã được cập nhật thành {maxChildReturnDate:dd/MM/yyyy} " +
                                  "để phù hợp với ngày trả dự kiến muộn nhất của các sách trong phiếu.",
                                  "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            
                else if (phieuMuonNgayTraDuKien > maxChildReturnDate)
                {
                    var booksToUpdate = _selectedBooksData
                        .Where(x => x.NgayTraThucTe == null && x.NgayTraDuKien < phieuMuonNgayTraDuKien)
                        .ToList();

                    if (booksToUpdate.Any())
                    {
                        var bookNames = string.Join(", ", booksToUpdate.Select(x => x.TenSach).Take(3));
                        if (booksToUpdate.Count > 3)
                        {
                            bookNames += $" và {booksToUpdate.Count - 3} sách khác";
                        }

                        var confirmResult = MessageBox.Show(
                            $"Ngày trả dự kiến của các sách sau sẽ được cập nhật thành {phieuMuonNgayTraDuKien:dd/MM/yyyy}:\n" +
                            $"{bookNames}\n\n" +
                            "Bạn có muốn tiếp tục?",
                            "Xác nhận cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (confirmResult == DialogResult.Yes)
                        {
                            foreach (var book in booksToUpdate)
                            {
                                book.NgayTraDuKien = phieuMuonNgayTraDuKien;
                            }

                            gcChiTietMuon.RefreshDataSource();
                        }
                        else
                        {
                            dtNgayTraDuKien.Value = maxChildReturnDate;
                            return;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi đồng bộ ngày trả dự kiến: {ex.Message}");
            }
        }
        
        private void SaveChangedChiTietPhieuMuon()
        {
            try
            {
                gvChiTietMuon.PostEditor();
                gvChiTietMuon.UpdateCurrentRow();

                foreach (var item in _selectedBooksData.Where(x => x.MaChiTiet > 0))
                {
                    var chiTiet = _chiTietPhieuMuonService.GetById(item.MaChiTiet);
                    if (chiTiet != null)
                    {
                        bool hasChanges = false;

                        if (chiTiet.NgayTraDuKien != item.NgayTraDuKien)
                        {
                            chiTiet.NgayTraDuKien = item.NgayTraDuKien;
                            hasChanges = true;
                        }

                        if (chiTiet.NgayTraThucTe != item.NgayTraThucTe)
                        {
                            chiTiet.NgayTraThucTe = item.NgayTraThucTe;
                            hasChanges = true;
                        }

                        if (chiTiet.TrangThai != item.TrangThai)
                        {
                            chiTiet.TrangThai = item.TrangThai;
                            hasChanges = true;
                        }

                        if (chiTiet.GhiChu != item.GhiChu)
                        {
                            chiTiet.GhiChu = item.GhiChu;
                            hasChanges = true;
                        }

                        if (hasChanges)
                        {
                            _chiTietPhieuMuonService.UpdateChiTietPhieuMuon(chiTiet);
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
                foreach (var item in _selectedBooksData)
                {
                    selectedBanSao.Add(item.MaBanSao);
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
                                bool alreadyExists = _selectedBooksData.Any(x => x.Barcode == barcode);

                                if (!alreadyExists)
                                {
                                    if (int.TryParse(maBanSaoStr, out int maBanSao))
                                    {
                                        _selectedBooksData.Add(new ChiTietPhieuMuonViewModel
                                        {
                                            Barcode = barcode,
                                            TenSach = tenSach,
                                            MaBanSao = maBanSao,
                                            NgayTraDuKien = dtNgayTraDuKien.Value,
                                            TrangThai = "Đang mượn",
                                            NgayMuon = DateTime.Now
                                        });

                                        gcChiTietMuon.RefreshDataSource();
                                        RemoveFromAvailableBooks(barcode);
                                    }
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

                            if (!string.IsNullOrEmpty(barcode))
                            {
                                for (int i = _selectedBooksData.Count - 1; i >= 0; i--)
                                {
                                    if (_selectedBooksData[i].Barcode == barcode)
                                    {
                                        _selectedBooksData.RemoveAt(i);
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
                                for (int i = _selectedBooksData.Count - 1; i >= 0; i--)
                                {
                                    if (_selectedBooksData[i].Barcode == barcode)
                                    {
                                        _selectedBooksData.RemoveAt(i);
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
            for (int i = _availableBooksData.Count - 1; i >= 0; i--)
            {
                if (_availableBooksData[i].Barcode == barcode)
                {
                    _availableBooksData.RemoveAt(i);
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
                _availableBooksData.Add(new BanSaoSachViewModel
                {
                    Barcode = book.Barcode,
                    TenSach = book.TenSach,
                    TinhTrang = book.TinhTrang,
                    MaBanSao = book.MaBanSao
                });
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

                var bookNames = selectedRows.Select(x => x.TenSach).ToList();
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
                            var listMaBanSao = selectedRows.Select(x => x.MaBanSao).ToList();
                            int userId = frmMain.CurrentUser; 

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

        private List<ChiTietPhieuMuonViewModel> GetSelectedUnreturnedBooks()
        {
            var selectedRows = new List<ChiTietPhieuMuonViewModel>();

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
                    var item = gvChiTietMuon.GetRow(rowHandle) as ChiTietPhieuMuonViewModel;
                    if (item != null && item.CanReturn)
                    {
                        selectedRows.Add(item);
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

                    _selectedBooksData.Clear();

                    for (int i = 0; i < gvDanhSachMuon.RowCount; i++)
                    {
                        var phieuMuon = gvDanhSachMuon.GetRow(i) as PhieuMuon;
                        if (phieuMuon != null && phieuMuon.MaPhieuMuon == currentPhieuMuonId)
                        {
                            gvDanhSachMuon.FocusedRowHandle = i;
                            gvDanhSachMuon.SelectRow(i);
                            break;
                        }
                    }

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

        private void btnTraSach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var selectedPhieuMuon = gvDanhSachMuon.GetFocusedRow() as PhieuMuon;
                if (selectedPhieuMuon == null || selectedPhieuMuon.MaPhieuMuon == 0)
                {
                    MessageBox.Show("Vui lòng chọn phiếu mượn để trả sách!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (selectedPhieuMuon.TrangThai == "Đã trả hết")
                {
                    MessageBox.Show("Phiếu mượn này đã được trả hết!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var allUnreturnedBooks = GetAllUnreturnedBooksFromPhieuMuon(selectedPhieuMuon.MaPhieuMuon);

                if (allUnreturnedBooks == null || allUnreturnedBooks.Count == 0)
                {
                    MessageBox.Show("Không có sách nào chưa trả trong phiếu mượn này!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var bookNames = allUnreturnedBooks.Select(x => x.TenSach).ToList();
                var memberName = selectedPhieuMuon.MaThanhVienNavigation?.TenThanhVien ?? "N/A";

                var confirmMessage = $"Bạn đang trả TẤT CẢ {allUnreturnedBooks.Count} cuốn sách chưa trả của phiếu mượn {selectedPhieuMuon.MaPhieuMuon}:\n" +
                               $"Thành viên: {memberName}\n\n" +
                               $"Các sách sẽ được trả:\n" +
                               string.Join("\n• ", bookNames.Take(5));

                if (bookNames.Count > 5)
                {
                    confirmMessage += $"\n• ... và {bookNames.Count - 5} cuốn khác";
                }

                confirmMessage += "\n\nBạn có chắc chắn muốn trả TẤT CẢ các sách này?";

                var confirmResult = MessageBox.Show(confirmMessage, "Xác nhận trả tất cả sách",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult != DialogResult.Yes)
                    return;

                using (var form = new frmTraSach())
                {
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.Text = $"Trả tất cả {allUnreturnedBooks.Count} cuốn sách - Phiếu {selectedPhieuMuon.MaPhieuMuon}";

                    var result = form.ShowDialog(this.ParentForm);

                    if (result == DialogResult.OK)
                    {
                        try
                        {
                            var listMaBanSao = allUnreturnedBooks.Select(x => x.MaBanSao).ToList();
                            int userId = frmMain.CurrentUser;

                            _traSachProcService.ExecuteTraNhieuSachProc(
                                listMaBanSao,
                                userId,
                                form.TinhTrangSach,
                                form.GhiChu
                            );

                            MessageBox.Show($"Trả tất cả sách thành công!\n" +
                                          $"Đã trả {allUnreturnedBooks.Count} cuốn sách của phiếu mượn {selectedPhieuMuon.MaPhieuMuon}!",
                                          "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                MessageBox.Show($"Lỗi khi thực hiện trả tất cả sách: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<ChiTietPhieuMuonViewModel> GetAllUnreturnedBooksFromPhieuMuon(int maPhieuMuon)
        {
            try
            {
                using (var freshContext = ContextFactory.CreateContext())
                {
                    var freshCtRepo = new GenericRepository<ChiTietPhieuMuon>(freshContext);
                    var freshCtService = new ChiTietPhieuMuonService(freshCtRepo);

                    return freshCtService.GetUnreturnedBooksFromPhieuMuon(maPhieuMuon);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách sách chưa trả: {ex.Message}");
            }
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
            else
            {
                RefreshData();
            }
        }

        public void OnDeactivated()
        {
            
        }

        private void InitializeControls()
        {
            var dbContext = ContextFactory.CreateContext(); 
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

            InitializeDataSources();
            AddTraButtonColumn();

            EventBus.Subscribe("ThanhVienChanged", () =>
            {
                if (_isDataLoaded)
                {
                    loadThanhVien();
                }
            });

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

        private void LoadData()
        {
            try
            {
                loadDanhSachMuon();
                loadBanSaoChuaMuon();
                loadThanhVien();

                if (_selectedBooksData != null)
                {
                    _selectedBooksData.Clear();
                    gcChiTietMuon.RefreshDataSource();
                }

                if (_availableBooksData != null)
                {
                    _availableBooksData.Clear();
                    RefreshAvailableBooks();
                }

                _isDataLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu mượn trả: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshData()
        {
            try
            {
                loadDanhSachMuon();
                loadBanSaoChuaMuon();
                loadThanhVien();

                _currentPhieuMuonId = 0;
                if (_selectedBooksData != null)
                {
                    _selectedBooksData.Clear();
                    gcChiTietMuon.RefreshDataSource();
                }

                RefreshAvailableBooks();

                if (btnLuu.Enabled == false) 
                {
                    _reset();
                    tabQLSach.SelectedTabPage = pageDanhSachMuon;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi làm mới dữ liệu mượn trả: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMail_Click(object sender, EventArgs e)
        {
           
        }

        private void btnMail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var pm = gvDanhSachMuon.GetFocusedRow() as PhieuMuon;

                if (pm == null)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một thanh viên  để thực hiện gửi mail!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (pm.TrangThai == "Đã trả hết")
                {
                    MessageBox.Show("Phiếu mượn này đã được trả hết!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                using (var form = new frmGuiMail(pm.MaThanhVien))
                {
                    form.StartPosition = FormStartPosition.CenterParent;

                    var result = form.ShowDialog(this.ParentForm);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form gửi mail: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}