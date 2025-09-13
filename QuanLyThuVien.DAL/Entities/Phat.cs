using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLyThuVien.DAL.Entities
{
    public partial class Phat
    {
        public Phat()
        {
            PaymentHistory = new HashSet<PaymentHistory>();
        }

        public int MaPhat { get; set; }
        public int MaMuonSach { get; set; }
        public decimal SoTien { get; set; }
        public string LyDo { get; set; }
        public DateTime NgayPhat { get; set; }
        public string TrangThai { get; set; }

        public virtual ChiTietPhieuMuon MaMuonSachNavigation { get; set; }
        public virtual ICollection<PaymentHistory> PaymentHistory { get; set; }
    }
}
