using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLyThuVien.DAL.Entities
{
    public partial class PhieuMuon
    {
        public PhieuMuon()
        {
            ChiTietPhieuMuon = new HashSet<ChiTietPhieuMuon>();
        }

        public int MaPhieuMuon { get; set; }
        public int MaThanhVien { get; set; }
        public int UserId { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime? NgayTraDuKien { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual ThanhVien MaThanhVienNavigation { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<ChiTietPhieuMuon> ChiTietPhieuMuon { get; set; }
    }
}
