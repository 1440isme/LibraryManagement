using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLyThuVien.DAL.Entities
{
    public partial class ChiTietPhieuMuon
    {
        public ChiTietPhieuMuon()
        {
            Phat = new HashSet<Phat>();
        }

        public int MaChiTiet { get; set; }
        public int MaPhieuMuon { get; set; }
        public int MaSach { get; set; }
        public int? MaBanSao { get; set; }
        public DateTime? NgayTraDuKien { get; set; }
        public DateTime? NgayTraThucTe { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual BanSaoSach MaBanSaoNavigation { get; set; }
        public virtual PhieuMuon MaPhieuMuonNavigation { get; set; }
        public virtual Sach MaSachNavigation { get; set; }
        public virtual ICollection<Phat> Phat { get; set; }
    }
}
