using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLyThuVien.DAL.Entities
{
    public partial class TheLoai
    {
        public TheLoai()
        {
            Sach = new HashSet<Sach>();
        }

        public int MaTheLoai { get; set; }
        public string TenTheLoai { get; set; }
        public string MoTa { get; set; }

        public virtual ICollection<Sach> Sach { get; set; }
    }
}
