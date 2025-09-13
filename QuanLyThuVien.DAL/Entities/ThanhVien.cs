using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLyThuVien.DAL.Entities
{
    public partial class ThanhVien
    {
        public ThanhVien()
        {
            PaymentHistory = new HashSet<PaymentHistory>();
            PhieuMuon = new HashSet<PhieuMuon>();
            Reservation = new HashSet<Reservation>();
        }

        public int MaThanhVien { get; set; }
        public string TenThanhVien { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string LoaiThanhVien { get; set; }
        public DateTime NgayDangKy { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual ICollection<PaymentHistory> PaymentHistory { get; set; }
        public virtual ICollection<PhieuMuon> PhieuMuon { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
