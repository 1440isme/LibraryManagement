using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLyThuVien.DAL.Entities
{
    public partial class TacGia
    {
        public TacGia()
        {
            Sach = new HashSet<Sach>();
        }

        public int MaTacGia { get; set; }
        public string TenTacGia { get; set; }
        public string QuocTich { get; set; }
        public int? NamSinh { get; set; }

        public virtual ICollection<Sach> Sach { get; set; }
    }
}
