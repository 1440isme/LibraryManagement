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
       
        private TacGiaService _tacGiaService;

        public ucPageTacGia()
        {
            InitializeComponent();
        
            var dbContext = new QuanLyThuVienContext();
            var tacGiaRepo = new GenericRepository<TacGia>(dbContext);
            _tacGiaService = new TacGiaService(tacGiaRepo);
        }

        bool _them;

        private void ucPageTacGia_Load(object sender, EventArgs e)
        {            
            gcTacGia.DataSource = _tacGiaService.GetAllAuthors().ToList();                 

            _enable(false);
            _reset();
        }
   
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
                    var tacGia = gvTacGia.GetFocusedRow() as TacGia; 
                    if (tacGia != null)
                    {
                        if (MessageBox.Show("Bạn có chắc chắn muốn xóa tác giả này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _tacGiaService.DeleteAuthor(tacGia.MaTacGia); 
                            gcTacGia.DataSource = _tacGiaService.GetAllAuthors();
                            EventBus.Publish("TacGiaChanged");
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
                    
                    _tacGiaService.AddAuthor(txtTenTacGia.Text, txtQuocTich.Text, int.Parse(txtNamSinh.Text));
                    gcTacGia.DataSource = _tacGiaService.GetAllAuthors();
                    EventBus.Publish("TacGiaChanged"); 
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
                       
                        _tacGiaService.UpdateAuthor(tacGia.MaTacGia, txtTenTacGia.Text, txtQuocTich.Text, int.Parse(txtNamSinh.Text));

                    }
                    gcTacGia.DataSource = _tacGiaService.GetAllAuthors();
                    EventBus.Publish("TacGiaChanged");
                    MessageBox.Show("Cập nhật tác giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _enable(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu tác giả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Cancel()
        {
            _them = false;
            _enable(false);
        }

        public void RefreshData()
        {
            try
            {
                gcTacGia.DataSource = _tacGiaService.GetAllAuthors();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu tác giả: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
