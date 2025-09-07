using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLyThuVien.DAL.Entities
{
    public partial class SachQuaHan
    {
        public int MaMuonSach { get; set; }
        public string TenSach { get; set; }
        public string TenThanhVien { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime NgayTraDuKien { get; set; }
        public int? SoNgayQuaHan { get; set; }
    }
}
