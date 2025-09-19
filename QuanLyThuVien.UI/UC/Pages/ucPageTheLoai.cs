using DevExpress.Data.Filtering;
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
    public partial class ucPageTheLoai : UserControl, ICrudOperations
    {
        private TheLoaiService _theLoaiService;
        public ucPageTheLoai()
        {
            InitializeComponent();
            var dbContext = ContextFactory.CreateContext(); 
            var theLoaiRepo = new GenericRepository<TheLoai>(dbContext);
            _theLoaiService = new TheLoaiService(theLoaiRepo);
        }
        bool _them;
        private void ucPageTheLoai_Load(object sender, EventArgs e)
        {
            gcTheLoai.DataSource = _theLoaiService.GetAllCategories();

            _enable(false);
            _reset();
        }

        void _enable(bool t)
        {
            txtTenTheLoai.Enabled = t;
            txtMoTa.Enabled = t;
        }

        void _reset()
        {
            txtTenTheLoai.Text = "";
            txtMoTa.Text = "";
        }

        private void gvTheLoai_Click(object sender, EventArgs e)
        {
            if (gvTheLoai.RowCount > 0)
            {
                var theLoai = gvTheLoai.GetFocusedRow() as TheLoai;
                if (theLoai != null)
                {
                    txtTenTheLoai.Text = theLoai.TenTheLoai;
                    txtMoTa.Text = theLoai.MoTa;
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
                if (gvTheLoai.RowCount > 0)
                {
                    var theLoai = gvTheLoai.GetFocusedRow() as TheLoai;
                    if (theLoai != null)
                    {
                        if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhà xuất bản này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _theLoaiService.DeleteTheLoai(theLoai.MaTheLoai);
                            gcTheLoai.DataSource = _theLoaiService.GetAllCategories();
                            EventBus.Publish("TheLoaiChanged");
                            MessageBox.Show("Xóa thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa thể loại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void Save()
        {
            if (txtTenTheLoai == null)
            {
                MessageBox.Show("Tên thể loại không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (_them)
                {
                    
                    _theLoaiService.AddTheLoai(txtTenTheLoai.Text, txtMoTa.Text);
                    gcTheLoai.DataSource= _theLoaiService.GetAllCategories();
                    EventBus.Publish("TheLoaiChanged");
                    MessageBox.Show("Thêm thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _enable(false);
                }
                else
                {
                    var theLoai = gvTheLoai.GetFocusedRow() as TheLoai;
                    if (theLoai.MaTheLoai == 0)
                    {
                        MessageBox.Show("Vui lòng chọn thể loại để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (theLoai != null)
                    {                       
                        _theLoaiService.UpdateTheLoai(theLoai.MaTheLoai, txtTenTheLoai.Text, txtMoTa.Text);
                        gcTheLoai.DataSource = _theLoaiService.GetAllCategories();
                    }
                    
                    EventBus.Publish("TheLoaiChanged");
                    MessageBox.Show("Cập nhật thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _enable(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu thể loại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                gcTheLoai.DataSource = _theLoaiService.GetAllCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu thể loại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
