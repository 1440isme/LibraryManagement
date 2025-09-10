using Microsoft.EntityFrameworkCore;
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
    public partial class ucPageTacGia : UserControl, ICrudOperations
    {
        //private Size originalFormSize;
        //private Dictionary<Control, Rectangle> controlBounds = new Dictionary<Control, Rectangle>();

        private TacGiaService _tacGiaService;

        public ucPageTacGia()
        {
            InitializeComponent();
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
            //      ControlStyles.AllPaintingInWmPaint |
            //      ControlStyles.UserPaint, true);
            //this.UpdateStyles();
            var dbContext = new QuanLyThuVienContext();
            var tacGiaRepo = new GenericRepository<TacGia>(dbContext);
            _tacGiaService = new TacGiaService(tacGiaRepo);
        }

        bool _them;

        private void ucPageTacGia_Load(object sender, EventArgs e)
        {
            //originalFormSize = this.Size;
            //StoreControlBounds(this);

            
            gcTacGia.DataSource = _tacGiaService.GetAllAuthors().ToList();
                  

            _enable(false);
            _reset();
        }
        //private void StoreControlBounds(Control parent)
        //{
        //    foreach (Control ctrl in parent.Controls)
        //    {
        //        if (!controlBounds.ContainsKey(ctrl))
        //        {
        //            controlBounds[ctrl] = ctrl.Bounds;
        //        }
        //        if (ctrl.HasChildren)
        //        {
        //            StoreControlBounds(ctrl);
        //        }
        //    }
        //}
        //private void ucPageTacGia_Resize(object sender, EventArgs e)
        //{

        //    if (originalFormSize.Width == 0 || originalFormSize.Height == 0)
        //        return;

        //    float xRatio = (float)this.Width / originalFormSize.Width;
        //    float yRatio = (float)this.Height / originalFormSize.Height;

        //    this.SuspendLayout();
        //    ResizeControls(this, xRatio, yRatio);
        //    this.ResumeLayout();
        //}
        //private void ResizeControls(Control parent, float xRatio, float yRatio)
        //{
        //    parent.SuspendLayout();
        //    foreach (Control ctrl in parent.Controls)
        //    {
        //        if (controlBounds.TryGetValue(ctrl, out Rectangle originalBounds))
        //        {
        //            int newX = (int)(originalBounds.X * xRatio);
        //            int newY = (int)(originalBounds.Y * yRatio);
        //            int newWidth = (int)(originalBounds.Width * xRatio);
        //            int newHeight = (int)(originalBounds.Height * yRatio);

        //            // Chỉ set Bounds nếu thực sự thay đổi
        //            if (ctrl.Bounds != new Rectangle(newX, newY, newWidth, newHeight))
        //                ctrl.Bounds = new Rectangle(newX, newY, newWidth, newHeight);
        //        }
        //        if (ctrl.HasChildren)
        //        {
        //            ResizeControls(ctrl, xRatio, yRatio);
        //        }
        //    }
        //    parent.ResumeLayout();
        //}

        void _enable(bool t)
        {
            txtTenTacGia.Enabled = t;
            txtQuocTich.Enabled = t;
            txtNamSinh.Enabled = t;
        }
        void _reset()
        {
            txtTenTacGia.Text = "";
            txtQuocTich.Text = "";
            txtNamSinh.Text = "";
        }

        private void gvTacGia_Click(object sender, EventArgs e)
        {
            if (gvTacGia.RowCount>0)
            {
                var tacGia = gvTacGia.GetFocusedRow() as TacGia;
                if (tacGia != null)
                {
                    txtTenTacGia.Text = tacGia.TenTacGia;
                    txtQuocTich.Text = tacGia.QuocTich;
                    txtNamSinh.Text = tacGia.NamSinh.ToString() ?? "";
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
                if (gvTacGia.RowCount > 0)
                {
                    var sach = gvTacGia.GetFocusedRow() as Sach;
                    if (sach != null)
                    {
                        if (MessageBox.Show("Bạn có chắc chắn muốn xóa tác giả này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _tacGiaService.DeleteAuthor(sach.MaSach);
                            gcTacGia.DataSource = _tacGiaService.GetAllAuthors();
                            MessageBox.Show("Xóa tác giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa tác giả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Save()
        {
            if (txtTenTacGia.Text == null)
            {
                MessageBox.Show("Tên tác giả không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (_them)
                {
                    var tacGia = new TacGia
                    {
                        TenTacGia = txtTenTacGia.Text,
                        QuocTich = txtQuocTich.Text,
                        NamSinh = int.Parse(txtNamSinh.Text)
                    };
                    _tacGiaService.AddAuthor(tacGia);
                    gcTacGia.DataSource = _tacGiaService.GetAllAuthors();
                    MessageBox.Show("Thêm tác giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _enable(false);
                }
                else
                {
                    var tacGia = gvTacGia.GetFocusedRow() as TacGia;
                    if (tacGia.MaTacGia == 0) 
                    {
                        MessageBox.Show("Vui lòng chọn tác giả để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (tacGia != null)
                    {
                        tacGia.TenTacGia = txtTenTacGia.Text;
                        tacGia.QuocTich = txtQuocTich.Text;
                        tacGia.NamSinh = int.Parse(txtNamSinh.Text);
                        _tacGiaService.UpdateAuthor(tacGia);
                        
                    }
                    gcTacGia.DataSource = _tacGiaService.GetAllAuthors();
                    MessageBox.Show("Cập nhật tác giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _enable(false);
                }
            }
            catch (Exception ex)
            {
                string message = SqlErrorTranslator.ToFriendlyMessage(ex);
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        public void Cancel()
        {
            _them = false;
            _enable(false);
        }

        public void RefreshData()
        {
            throw new NotImplementedException();
        }
    }
}
