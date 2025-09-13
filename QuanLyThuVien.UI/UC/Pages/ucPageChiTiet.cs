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
        public ucPageChiTiet()
        {
            InitializeComponent();
        }

        private void ucPageChiTiet_Load(object sender, EventArgs e)
        {


            var dbContext = new QuanLyThuVienContext();
            var TVRepo = new GenericRepository<ThanhVien>(dbContext);
            _thanhVienService = new ThanhVienService(TVRepo);
            loadThanhVien();
        }

        void loadThanhVien()
        {
            searchThanhVien.Properties.DataSource = _thanhVienService.GetAllMembers();
            searchThanhVien.Properties.DisplayMember = "TenThanhVien";
            searchThanhVien.Properties.ValueMember = "MaThanhVien";
        }
    }
}
