using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLyThuVien.DAL.Entities
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            MuonSach = new HashSet<MuonSach>();
        }

        public int MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string ChucVu { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }

        public virtual ICollection<MuonSach> MuonSach { get; set; }
    }
}
