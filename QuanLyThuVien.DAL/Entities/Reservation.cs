using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLyThuVien.DAL.Entities
{
    public partial class Reservation
    {
        public int MaReservation { get; set; }
        public int? MaBiblio { get; set; }
        public int? MaSach { get; set; }
        public int MaThanhVien { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string Note { get; set; }

        public virtual Sach MaSachNavigation { get; set; }
        public virtual ThanhVien MaThanhVienNavigation { get; set; }
    }
}
