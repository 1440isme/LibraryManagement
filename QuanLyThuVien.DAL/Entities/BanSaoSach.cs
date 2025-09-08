using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLyThuVien.DAL.Entities
{
    public partial class BanSaoSach
    {
        public BanSaoSach()
        {
            MuonSach = new HashSet<MuonSach>();
        }

        public int MaBanSao { get; set; }
        public int MaSach { get; set; }
        public string Barcode { get; set; }
        public string ViTri { get; set; }
        public string TinhTrang { get; set; }
        public DateTime NgayNhap { get; set; }
        public string GhiChu { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual Sach MaSachNavigation { get; set; }
        public virtual ICollection<MuonSach> MuonSach { get; set; }
    }
}
