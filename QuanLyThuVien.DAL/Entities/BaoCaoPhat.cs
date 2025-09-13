using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLyThuVien.DAL.Entities
{
    public partial class BaoCaoPhat
    {
        public int MaPhat { get; set; }
        public int MaChiTiet { get; set; }
        public string TenThanhVien { get; set; }
        public decimal SoTien { get; set; }
        public string LyDo { get; set; }
    }
}
