using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLyThuVien.DAL.Entities
{
    public partial class Sach
    {
        public Sach()
        {
            BanSaoSach = new HashSet<BanSaoSach>();
            MuonSach = new HashSet<MuonSach>();
            Reservation = new HashSet<Reservation>();
        }

        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public string ISBN { get; set; }
        public int MaTacGia { get; set; }
        public int MaNhaXuatBan { get; set; }
        public int MaTheLoai { get; set; }
        public int NamXuatBan { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public bool? TrangThai { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual NhaXuatBan MaNhaXuatBanNavigation { get; set; }
        public virtual TacGia MaTacGiaNavigation { get; set; }
        public virtual TheLoai MaTheLoaiNavigation { get; set; }
        public virtual ICollection<BanSaoSach> BanSaoSach { get; set; }
        public virtual ICollection<MuonSach> MuonSach { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
