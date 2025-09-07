using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLyThuVien.DAL.Entities
{
    public partial class TopSachMuon
    {
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public int? SoLanMuon { get; set; }
    }
}
