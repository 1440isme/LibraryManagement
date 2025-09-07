using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLyThuVien.DAL.Entities
{
    public partial class NhaXuatBan
    {
        public NhaXuatBan()
        {
            Sach = new HashSet<Sach>();
        }

        public int MaNhaXuatBan { get; set; }
        public string TenNhaXuatBan { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }

        public virtual ICollection<Sach> Sach { get; set; }
    }
}
