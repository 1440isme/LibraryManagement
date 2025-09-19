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
    public partial class ucPageNXB : UserControl, ICrudOperations
    {
        private NXBService _nxbService;
        public ucPageNXB()
        {
            InitializeComponent();
            var dbContext = ContextFactory.CreateContext(); 
            var nxbRepo = new GenericRepository<NhaXuatBan>(dbContext);
            _nxbService = new NXBService(nxbRepo);
        }
        bool _them;
        private void ucPageNXB_Load(object sender, EventArgs e)
        {
            gcNXB.DataSource = _nxbService.GetAllPublishers();

            _enable(false);
            _reset();
        }

        void _enable(bool t)
        {
            txtTenNXB.Enabled = t;
            txtDiaChi.Enabled = t;
            txtSDT.Enabled = t;
         }
        
        void _reset()
        {
            txtTenNXB.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }

        private void gvNXB_Click(object sender, EventArgs e)
        {
            if (gvNXB.RowCount > 0)
            {
                var nxb = gvNXB.GetFocusedRow() as NhaXuatBan;
                if (nxb != null)
                {
                    txtTenNXB.Text = nxb.TenNhaXuatBan;
                    txtDiaChi.Text = nxb.DiaChi;
                    txtSDT.Text = nxb.SoDienThoai;
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
                if (gvNXB.RowCount > 0)
                {
                    var nxb = gvNXB.GetFocusedRow() as NhaXuatBan;
                    if (nxb != null)
                    {
                        if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhà xuất bản này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _nxbService.DeletePublisher(nxb.MaNhaXuatBan);
                            gcNXB.DataSource = _nxbService.GetAllPublishers();
                            EventBus.Publish("NXBChanged");
                            MessageBox.Show("Xóa nhà xuất bản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhà xuất bản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void Save()
        {
            if(txtTenNXB == null)
            {
                MessageBox.Show("Tên nhà xuất bản không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (_them)
                {
                    
                    _nxbService.AddPublisher(txtTenNXB.Text, txtDiaChi.Text, txtSDT.Text);
                    gcNXB.DataSource = _nxbService.GetAllPublishers();
                    EventBus.Publish("NXBChanged");
                    MessageBox.Show("Thêm nhà xuất bản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _enable(false);
                }
                else
                {
                    var nxb = gvNXB.GetFocusedRow() as NhaXuatBan;
                    if (nxb.MaNhaXuatBan == 0)
                    {
                        MessageBox.Show("Vui lòng chọn nhà xuất bản để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (nxb != null)
                    {
                       
                        _nxbService.UpdatePublisher(nxb.MaNhaXuatBan,txtTenNXB.Text, txtDiaChi.Text, txtSDT.Text);
                    }
                    gcNXB.DataSource = _nxbService.GetAllPublishers();
                    EventBus.Publish("NXBChanged");
                    MessageBox.Show("Cập nhật nhà xuất bản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _enable(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu nhà xuất bản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                gcNXB.DataSource = _nxbService.GetAllPublishers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu nhà xuất bản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
