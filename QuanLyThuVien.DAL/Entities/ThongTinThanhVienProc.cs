using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace QuanLyThuVien.DAL.Entities
{ 

    public class ThongTinThanhVienProc
    {
        public int MaThanhVien { get; set; }
        public string TenThanhVien { get; set; }

        public string LoaiThanhVien { get; set; }

        public int SoPhieuDangMuon { get; set; }
        public int SoSachDangMuon { get; set; }
        public decimal TongNoPhat { get; set; }
    }
}
