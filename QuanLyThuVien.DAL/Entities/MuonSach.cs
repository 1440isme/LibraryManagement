using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLyThuVien.DAL.Entities
{
    public partial class MuonSach
    {
        public MuonSach()
        {
            Phat = new HashSet<Phat>();
        }

        public int MaMuonSach { get; set; }
        public int MaSach { get; set; }
        public int MaThanhVien { get; set; }
        public int MaNhanVien { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime NgayTraDuKien { get; set; }
        public DateTime? NgayTraThucTe { get; set; }
        public string TrangThai { get; set; }
        public int? MaBanSao { get; set; }

        public virtual BanSaoSach MaBanSaoNavigation { get; set; }
        public virtual NhanVien MaNhanVienNavigation { get; set; }
        public virtual Sach MaSachNavigation { get; set; }
        public virtual ThanhVien MaThanhVienNavigation { get; set; }
        public virtual ICollection<Phat> Phat { get; set; }
    }
}
