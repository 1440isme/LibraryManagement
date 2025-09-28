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
    public partial class ucPageSach : UserControl, ICrudOperations
    {
       
        private SachService _sachService;
        private TheLoaiService _theLoaiService;
        private NXBService _nxbService;
        private TacGiaService _tacGiaService;
        public event EventHandler DataChanged;
        public ucPageSach()
        {
            InitializeComponent();
       
            gvSach.CustomUnboundColumnData += GvSach_CustomUnboundColumnData;
            this.UpdateStyles();
            var dbContext = ContextFactory.CreateContext();
            var sachRepo = new GenericRepository<Sach>(dbContext);
            _sachService = new SachService(sachRepo);

            var tacGiaRepo = new GenericRepository<TacGia>(dbContext);
            _tacGiaService = new TacGiaService(tacGiaRepo);

            var theLoaiRepo = new GenericRepository<TheLoai>(dbContext);
            _theLoaiService = new TheLoaiService(theLoaiRepo);

            var nxbRepo = new GenericRepository<NhaXuatBan>(dbContext);
            _nxbService = new NXBService(nxbRepo);
        }
       
        bool _them;
        private void ucPageSach_Load(object sender, EventArgs e)
        {
            var danhSachSach = _sachService.GetAllBooks();
            gcSach.DataSource = danhSachSach;
            
            ConfigureUnboundColumns();
            
            gvSach.OptionsFind.HighlightFindResults = false;
            gvSach.OptionsFind.FindNullPrompt = "Tìm kiếm...";
            gvSach.OptionsFind.ShowClearButton = true;
            gvSach.OptionsFind.ShowFindButton = true;
            
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvSach.Columns)
            {
                if (col.ColumnType == typeof(string))
                {
                    col.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
                    col.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
                }
            }
            
            LoadTacGia();
            LoadTheLoai();
            LoadNXB();
            
            EventBus.Subscribe("TacGiaChanged", LoadTacGia);
            EventBus.Subscribe("TheLoaiChanged", LoadTheLoai);
            EventBus.Subscribe("NXBChanged", LoadNXB);

            _enable(false);
            _reset();
            
            Console.WriteLine($"gcSach Design Size: 1200x464");
            Console.WriteLine($"gcSach Actual Size: {gcSach.Width}x{gcSach.Height}");
            Console.WriteLine($"Panel1 Size: {splitContainerControl1.Panel1.Width}x{splitContainerControl1.Panel1.Height}");
        }

        private void ConfigureUnboundColumns()
        {
            var tenTacGiaColumn = gvSach.Columns["TenTacGia"];
            if (tenTacGiaColumn != null)
            {
                tenTacGiaColumn.UnboundType = DevExpress.Data.UnboundColumnType.String;
            }
            
            var tenTheLoaiColumn = gvSach.Columns["TenTheLoai"];
            if (tenTheLoaiColumn != null)
            {
                tenTheLoaiColumn.UnboundType = DevExpress.Data.UnboundColumnType.String;
            }
            
            var tenNhaXuatBanColumn = gvSach.Columns["TenNhaXuatBan"];
            if (tenNhaXuatBanColumn != null)
            {
                tenNhaXuatBanColumn.UnboundType = DevExpress.Data.UnboundColumnType.String;
            }
        }

        void LoadTacGia()
        {
            cboTacGia.DataSource = _tacGiaService.GetAllAuthors();
            cboTacGia.DisplayMember = "TenTacGia";
            cboTacGia.ValueMember = "MaTacGia";            
            if (cboTacGia.Items.Count > 0)
            {
                cboTacGia.SelectedIndex = 0;
            }
        }
        void LoadTheLoai()
        {
            cboTheLoai.DataSource = _theLoaiService.GetAllCategories();
            cboTheLoai.DisplayMember = "TenTheLoai";
            cboTheLoai.ValueMember = "MaTheLoai";
            
            if (cboTheLoai.Items.Count > 0)
            {
                cboTheLoai.SelectedIndex = 0;
            }
        }
        void LoadNXB()
        {
            cboNXB.DataSource = _nxbService.GetAllPublishers();
            cboNXB.DisplayMember = "TenNhaXuatBan";
            cboNXB.ValueMember = "MaNhaXuatBan";
            
            if (cboNXB.Items.Count > 0)
            {
                cboNXB.SelectedIndex = 0;
            }
        }
        
        private void GvSach_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                var sach = e.Row as Sach;
                if (sach != null)
                {
                    try
                    {
                        if (e.Column.FieldName == "TenTacGia")
                        {
                            string tenTacGia = "";
                            if (sach.MaTacGiaNavigation?.TenTacGia != null)
                                tenTacGia = sach.MaTacGiaNavigation.TenTacGia;
                            else
                            {
                                var tacGia = _tacGiaService.GetAllAuthors().FirstOrDefault(t => t.MaTacGia == sach.MaTacGia);
                                tenTacGia = tacGia?.TenTacGia ?? "";
                            }
                            
                            e.Value = string.IsNullOrEmpty(tenTacGia) ? " " : tenTacGia;
                        }
                        else if (e.Column.FieldName == "TenTheLoai")
                        {
                            string tenTheLoai = "";
                            if (sach.MaTheLoaiNavigation?.TenTheLoai != null)
                                tenTheLoai = sach.MaTheLoaiNavigation.TenTheLoai;
                            else
                            {
                                var theLoai = _theLoaiService.GetAllCategories().FirstOrDefault(t => t.MaTheLoai == sach.MaTheLoai);
                                tenTheLoai = theLoai?.TenTheLoai ?? "";
                            }
                            
                            e.Value = string.IsNullOrEmpty(tenTheLoai) ? " " : tenTheLoai;
                        }
                        else if (e.Column.FieldName == "TenNhaXuatBan")
                        {
                            string tenNXB = "";
                            if (sach.MaNhaXuatBanNavigation?.TenNhaXuatBan != null)
                                tenNXB = sach.MaNhaXuatBanNavigation.TenNhaXuatBan;
                            else
                            {
                                var nxb = _nxbService.GetAllPublishers().FirstOrDefault(n => n.MaNhaXuatBan == sach.MaNhaXuatBan);
                                tenNXB = nxb?.TenNhaXuatBan ?? "";
                            }
                            
                            e.Value = string.IsNullOrEmpty(tenNXB) ? " " : tenNXB;
                        }
                    }
                    catch (Exception ex)
                    {
                        e.Value = " ";
                        System.Diagnostics.Debug.WriteLine($"Error in CustomUnboundColumnData: {ex.Message}");
                    }
                }
                else
                {
                    e.Value = " "; 
                }
            }
        }

        
        void _enable(bool t)
        {
            txtTenSach.Enabled = t;
            txtISBN.Enabled = t;
            cboTacGia.Enabled = t;
            cboNXB.Enabled = t;
            cboTheLoai.Enabled = t;
            numNamXB.Enabled = t;
            numGia.Enabled = t;
            numSoLuong.Enabled = t;
            chkTrangThai.Enabled = t;
        }
        void _reset()
        {
            txtTenSach.Text = "";
            txtISBN.Text = "";            
            if (cboTacGia.Items.Count > 0)
                cboTacGia.SelectedIndex = 0;            
            if (cboNXB.Items.Count > 0)
                cboNXB.SelectedIndex = 0;            
            if (cboTheLoai.Items.Count > 0)
                cboTheLoai.SelectedIndex = 0;            
            numNamXB.Value = 0;
            numGia.Value = 0;
            numSoLuong.Value = 0;
            chkTrangThai.Checked = false;
        }

        private void gvSach_Click(object sender, EventArgs e)
        {
            if (gvSach.RowCount > 0)
            {
                var sach = gvSach.GetFocusedRow() as Sach;
                if (sach != null)
                {
                    txtTenSach.Text = sach.TenSach;
                    txtISBN.Text = sach.ISBN;
                    cboTacGia.SelectedValue = sach.MaTacGia;
                    cboNXB.SelectedValue = sach.MaNhaXuatBan;
                    cboTheLoai.SelectedValue = sach.MaTheLoai;
                    numNamXB.Value = sach.NamXuatBan;
                    numGia.Value = sach.Gia;
                    numSoLuong.Value = sach.SoLuong;
                    chkTrangThai.Checked = sach.TrangThai ?? false;
                }
            }
        }

        public void Add()
        {
            _them = true;            
            _enable(true);
            _reset();
        }

        public void Edit()
        {
            _them = false;
            _enable(true);

        }

        public void Delete()
        {
            try
            {
                if (gvSach.RowCount > 0)
                {
                    var sach = gvSach.GetFocusedRow() as Sach;
                    if (sach != null)
                    {
                        if (MessageBox.Show("Bạn có chắc chắn muốn xóa sách này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _sachService.DeleteBook(sach.MaSach);
                            gcSach.DataSource = _sachService.GetAllBooks();
                            MessageBox.Show("Xóa sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (InvalidOperationException invOpEx)
            {
                MessageBox.Show("Không thể xóa sách này vì có liên quan đến dữ liệu khác: " + invOpEx.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xoá sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Save()
        {
            List<string> validationErrors = new List<string>();
            
            if (cboTacGia.SelectedValue == null || cboNXB.SelectedValue == null || cboTheLoai.SelectedValue == null)
            {
                validationErrors.Add("Vui lòng chọn đầy đủ Tác giả, NXB và Thể loại.");
            }
            
            if (string.IsNullOrWhiteSpace(txtTenSach.Text))
            {
                validationErrors.Add("Tên sách không được để trống.");
            }

            if (string.IsNullOrWhiteSpace(txtISBN.Text))
            {
                validationErrors.Add("ISBN không được để trống.");
            }

            if (numNamXB.Value <= 0)
            {
                validationErrors.Add("Năm xuất bản phải lớn hơn 0.");
            }

            if (numGia.Value <= 0)
            {
                validationErrors.Add("Giá sách phải lớn hơn 0.");
            }

            if (validationErrors.Count > 0)
            {
                string errorMessage = "Vui lòng kiểm tra lại thông tin:\n\n" + string.Join("\n", validationErrors);
                MessageBox.Show(errorMessage, "Thông tin chưa hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                if (cboTacGia.SelectedValue == null)
                    cboTacGia.Focus();
                else if (string.IsNullOrWhiteSpace(txtTenSach.Text))
                    txtTenSach.Focus();
                else if (string.IsNullOrWhiteSpace(txtISBN.Text))
                    txtISBN.Focus();
                else if (numNamXB.Value <= 0)
                    numNamXB.Focus();
                else if (numGia.Value <= 0)
                    numGia.Focus();
                    
                return;
            }

            bool saveSuccessful = false;

            try
            {
                if (_them)
                {
                    _sachService.AddBook(
                        txtTenSach.Text, 
                        txtISBN.Text, 
                        Convert.ToInt32(cboTacGia.SelectedValue), 
                        Convert.ToInt32(cboNXB.SelectedValue), 
                        Convert.ToInt32(cboTheLoai.SelectedValue),
                        (int)numNamXB.Value, 
                        numGia.Value, 
                        (int)numSoLuong.Value, 
                        chkTrangThai.Checked
                    );
                    
                    saveSuccessful = true;
                    MessageBox.Show("✅ Thêm sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var sach = gvSach.GetFocusedRow() as Sach;
                    if (sach == null || sach.MaSach == 0)
                    {
                        MessageBox.Show("Vui lòng chọn sách để sửa.", "Chưa chọn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return; 
                    }

                    _sachService.UpdateBook(
                        sach.MaSach, 
                        txtTenSach.Text, 
                        txtISBN.Text, 
                        Convert.ToInt32(cboTacGia.SelectedValue), 
                        Convert.ToInt32(cboNXB.SelectedValue), 
                        Convert.ToInt32(cboTheLoai.SelectedValue),
                        (int)numNamXB.Value, 
                        numGia.Value, 
                        (int)numSoLuong.Value, 
                        chkTrangThai.Checked
                    );
                    
                    saveSuccessful = true;
                    MessageBox.Show("✅ Cập nhật sách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show($"❌ Dữ liệu không hợp lệ:\n\n{argEx.Message}\n\nVui lòng kiểm tra lại và thử lưu lần nữa.", 
                               "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                FocusToErrorField(argEx.Message);
                
                return;
            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
             
                FocusToSqlErrorField(sqlEx.Message);
                
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Có lỗi xảy ra:\n\n{ex.Message}\n\nVui lòng thử lại.", 
                               "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }

            if (saveSuccessful)
            {
                try
                {
                    gcSach.DataSource = _sachService.GetAllBooks();
                    DataChanged?.Invoke(this, EventArgs.Empty);
            
                    _enable(false);
                    _reset();
                    _them = false;
            
                    gcSach.Focus();
                }
                catch (Exception refreshEx)
                {
                    MessageBox.Show($"Lưu thành công nhưng có lỗi khi refresh dữ liệu:\n\n{refreshEx.Message}", 
                                   "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public void Cancel()
        {
            _them = false;
            
            _enable(false);
        }

        public void RefreshData()
        {
            gcSach.DataSource = _sachService.GetAllBooks();
            ConfigureUnboundColumns(); 
        }

        private void gvSach_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "TrangThai")
            {
                bool status = Convert.ToBoolean(gvSach.GetRowCellValue(e.RowHandle, "TrangThai"));
                if (!status)
                    e.Appearance.BackColor = Color.LightGreen;
                else
                    e.Appearance.BackColor = Color.LightCoral;

            }
        }

        private void FocusToErrorField(string errorMessage)
        {
            if (errorMessage.Contains("Tên sách"))
            {
                txtTenSach.Focus();
                txtTenSach.SelectAll();
            }
            else if (errorMessage.Contains("ISBN"))
            {
                txtISBN.Focus(); 
                txtISBN.SelectAll();
            }
            else if (errorMessage.Contains("Năm xuất bản"))
            {
                numNamXB.Focus();
            }
            else if (errorMessage.Contains("Giá"))
            {
                numGia.Focus();
            }
            else if (errorMessage.Contains("Số lượng"))
            {
                numSoLuong.Focus();
            }
        }

        private void FocusToSqlErrorField(string sqlErrorMessage)
        {
            if (sqlErrorMessage.Contains("CHK_Gia"))
            {
                numGia.Focus();
            }
            else if (sqlErrorMessage.Contains("CHK_NamXuatBan"))
            {
                numNamXB.Focus();
            }
            else if (sqlErrorMessage.Contains("CHK_SoLuong"))
            {
                numSoLuong.Focus();
            }
            else if (sqlErrorMessage.Contains("ISBN"))
            {
                txtISBN.Focus();
                txtISBN.SelectAll();
            }
        }
    }
}
