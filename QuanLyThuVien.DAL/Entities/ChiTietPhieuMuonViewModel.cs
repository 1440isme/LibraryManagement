using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL.Entities
{
    public class ChiTietPhieuMuonViewModel
    {
        public int MaChiTiet { get; set; }
        public int MaPhieuMuon { get; set; }
        public int MaThanhVien { get; set; }
        public string TenThanhVien { get; set; }
        public string Barcode { get; set; }
        public string TenSach { get; set; }
        public int MaBanSao { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime NgayTraDuKien { get; set; }
        public DateTime? NgayTraThucTe { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }

        public bool CanReturn => NgayTraThucTe == null && TrangThai != "Đã trả";
        public bool IsOverdue => NgayTraThucTe == null && DateTime.Now > NgayTraDuKien;
    }

    public class BanSaoSachViewModel
    {
        public string Barcode { get; set; }
        public string TenSach { get; set; }
        public string TinhTrang { get; set; }
        public int MaBanSao { get; set; }
    }

    public class PhieuMuonViewModel
    {
        public int MaPhieuMuon { get; set; }
        public int MaThanhVien { get; set; }
        public string TenThanhVien { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime? NgayTraDuKien { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
    }
}

