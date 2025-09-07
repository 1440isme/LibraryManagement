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

namespace QuanLyThuVien.UI.UI
{
    public partial class ucSach : UserControl
    {
        private Size originalFormSize;
        private Dictionary<Control, Rectangle> controlBounds = new Dictionary<Control, Rectangle>();
        private SachService _sachService;
        private TheLoaiService _theLoaiService;
        private NXBService _nxbService;
        private TacGiaService _tacGiaService;
        public ucSach()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.AllPaintingInWmPaint |
                  ControlStyles.UserPaint, true);
            gvSach.CustomUnboundColumnData += GvSach_CustomUnboundColumnData;
            this.UpdateStyles();
            var dbContext = new QuanLyThuVienContext();
            var sachRepo = new GenericRepository<Sach>(dbContext);
            _sachService = new SachService(sachRepo);

            var tacGiaRepo = new GenericRepository<TacGia>(dbContext);
            _tacGiaService = new TacGiaService(tacGiaRepo);

            var theLoaiRepo = new GenericRepository<TheLoai>(dbContext);
            _theLoaiService = new TheLoaiService(theLoaiRepo);

            var nxbRepo = new GenericRepository<NhaXuatBan>(dbContext);
            _nxbService = new NXBService(nxbRepo);
        }

        int _right;
        bool _them;
        private void ucSach_Load(object sender, EventArgs e)
        {
            originalFormSize = this.Size;
            StoreControlBounds(this);
            var danhSachSach = _sachService.GetAllBooks();
            gcSach.DataSource = danhSachSach;
            LoadTacGia();
            LoadTheLoai();
            LoadNXB();
            showHideControl(true);
            _enable(false);
            _reset();
        }
        void LoadTacGia()
        {
            cboTacGia.DataSource = _tacGiaService.GetAllAuthors();
            cboTacGia.DisplayMember = "TenTacGia";
            cboTacGia.ValueMember = "MaTacGia";
        }
        void LoadTheLoai()
        {
            cboTheLoai.DataSource = _theLoaiService.GetAllCategories();
            cboTheLoai.DisplayMember = "TenTheLoai";
            cboTheLoai.ValueMember = "MaTheLoai";
        }
        void LoadNXB()
        {
            cboNXB.DataSource = _nxbService.GetAllPublishers();
            cboNXB.DisplayMember = "TenNhaXuatBan";
            cboNXB.ValueMember = "MaNhaXuatBan";
        }
        private void StoreControlBounds(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (!controlBounds.ContainsKey(ctrl))
                {
                    controlBounds[ctrl] = ctrl.Bounds;
                }
                if (ctrl.HasChildren)
                {
                    StoreControlBounds(ctrl);
                }
            }
        }

        private void ucSach_Resize(object sender, EventArgs e)
        {
            if (originalFormSize.Width == 0 || originalFormSize.Height == 0)
                return;

            float xRatio = (float)this.Width / originalFormSize.Width;
            float yRatio = (float)this.Height / originalFormSize.Height;

            this.SuspendLayout();
            ResizeControls(this, xRatio, yRatio);
            this.ResumeLayout();
        }
        private void ResizeControls(Control parent, float xRatio, float yRatio)
        {
            parent.SuspendLayout();
            foreach (Control ctrl in parent.Controls)
            {
                if (controlBounds.TryGetValue(ctrl, out Rectangle originalBounds))
                {
                    int newX = (int)(originalBounds.X * xRatio);
                    int newY = (int)(originalBounds.Y * yRatio);
                    int newWidth = (int)(originalBounds.Width * xRatio);
                    int newHeight = (int)(originalBounds.Height * yRatio);

                    // Chỉ set Bounds nếu thực sự thay đổi
                    if (ctrl.Bounds != new Rectangle(newX, newY, newWidth, newHeight))
                        ctrl.Bounds = new Rectangle(newX, newY, newWidth, newHeight);
                }
                if (ctrl.HasChildren)
                {
                    ResizeControls(ctrl, xRatio, yRatio);
                }
            }
            parent.ResumeLayout();
        }
        private void GvSach_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                var sach = e.Row as Sach;
                if (sach != null)
                {

                    if (e.Column.FieldName == "TenTacGia")
                        e.Value = sach.MaTacGiaNavigation?.TenTacGia ?? "";
                    else if (e.Column.FieldName == "TenTheLoai")
                        e.Value = sach.MaTheLoaiNavigation?.TenTheLoai ?? "";
                    else if (e.Column.FieldName == "TenNhaXuatBan")
                        e.Value = sach.MaNhaXuatBanNavigation?.TenNhaXuatBan ?? "";
                }
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
            cboTacGia.SelectedIndex = -1;
            cboNXB.SelectedIndex = -1;
            cboTheLoai.SelectedIndex = -1;
            numNamXB.Value = 0;
            numGia.Value = 0;
            numSoLuong.Value = 0;
            chkTrangThai.Checked = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true;
            showHideControl(false);
            _enable(true);
            _reset();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _enable(true);

            showHideControl(false);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cboTacGia.SelectedValue == null || cboNXB.SelectedValue == null || cboTheLoai.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Tác giả, NXB và Thể loại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (_them)
                {
                    var sach = new Sach
                    {
                        TenSach = txtTenSach.Text,
                        ISBN = txtISBN.Text,
                        MaTacGia = Convert.ToInt32(cboTacGia.SelectedValue),
                        MaNhaXuatBan = Convert.ToInt32(cboNXB.SelectedValue),
                        MaTheLoai = Convert.ToInt32(cboTheLoai.SelectedValue),
                        NamXuatBan = (int)numNamXB.Value,
                        Gia = numGia.Value,
                        SoLuong = (int)numSoLuong.Value,
                        TrangThai = chkTrangThai.Checked
                    };
                    _sachService.AddBook(sach);
                    gcSach.DataSource = _sachService.GetAllBooks();
                    MessageBox.Show("Thêm sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showHideControl(true);
                    _enable(false);
                }
                else
                {
                    var sach = gvSach.GetFocusedRow() as Sach;
                    if (sach.MaSach == 0)
                    {
                        MessageBox.Show("Vui lòng chọn sách để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (sach != null)
                    {
                        sach.TenSach = txtTenSach.Text;
                        sach.ISBN = txtISBN.Text;
                        sach.MaTacGia = (int)cboTacGia.SelectedValue;
                        sach.MaNhaXuatBan = (int)cboNXB.SelectedValue;
                        sach.MaTheLoai = (int)cboTheLoai.SelectedValue;
                        sach.NamXuatBan = (int)numNamXB.Value;
                        sach.Gia = numGia.Value;
                        sach.SoLuong = (int)numSoLuong.Value;
                        sach.TrangThai = chkTrangThai.Checked;
                        _sachService.UpdateBook(sach);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnBoQua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            showHideControl(true);
            _enable(false);
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
    }
}
