using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BLL.Services
{
    public class ChiTietPhieuMuonService
    {
        private readonly IGenericRepository<ChiTietPhieuMuon> _repository;

        public ChiTietPhieuMuonService(IGenericRepository<ChiTietPhieuMuon> repository)
        {
            _repository = repository;
        }

        public IEnumerable<ChiTietPhieuMuon> GetAllChiTietPhieuMuons()
        {
            var repo = _repository as GenericRepository<ChiTietPhieuMuon>;
            if (repo != null)
            {
                return repo.GetAllIncluding(
                    ctp => ctp.MaPhieuMuonNavigation,
                    ctp => ctp.MaSachNavigation,
                    ctp => ctp.MaBanSaoNavigation
                );
            }
            return _repository.GetAll();
        }

        public List<ChiTietPhieuMuon> GetAllByPhieuMuon(int MaPhieuMuon)
        {
            return _repository.GetAll()
                .Where(ctpm => ctpm.MaPhieuMuon == MaPhieuMuon)
                .ToList();
        }

        public void DeleteChiTietPhieuMuon(int maChiTiet)
        {
            _repository.Delete(maChiTiet);
            _repository.Save();
        }

        public void UpdateChiTietPhieuMuon(ChiTietPhieuMuon chiTietPhieuMuon)
        {
            try
            {
                var existing = _repository.GetById(chiTietPhieuMuon.MaChiTiet);
                if (existing == null)
                    throw new ArgumentException("Chi tiết phiếu mượn không tồn tại.");

               

                existing.NgayTraDuKien = chiTietPhieuMuon.NgayTraDuKien;
                existing.NgayTraThucTe = chiTietPhieuMuon.NgayTraThucTe;
                existing.TrangThai = chiTietPhieuMuon.TrangThai;
                existing.GhiChu = chiTietPhieuMuon.GhiChu;

                _repository.Update(existing);
                _repository.Save();
                
                System.Diagnostics.Debug.WriteLine("Update completed successfully");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in UpdateChiTietPhieuMuon: {ex.Message}");
                throw;
            }
        }

        public ChiTietPhieuMuon GetById(int maChiTiet)
        {
            return _repository.GetById(maChiTiet);
        }

        public List<ChiTietPhieuMuonViewModel> GetChiTietPhieuMuonViewModels(int maPhieuMuon)
        {
            using (var context = new QuanLyThuVienContext())
            {
                var result = (from ct in context.ChiTietPhieuMuon
                              join pm in context.PhieuMuon on ct.MaPhieuMuon equals pm.MaPhieuMuon
                              join tv in context.ThanhVien on pm.MaThanhVien equals tv.MaThanhVien
                              join bs in context.BanSaoSach on ct.MaBanSao equals bs.MaBanSao
                              join s in context.Sach on ct.MaSach equals s.MaSach
                              where ct.MaPhieuMuon == maPhieuMuon
                              select new ChiTietPhieuMuonViewModel
                              {
                                  MaChiTiet = ct.MaChiTiet,
                                  MaPhieuMuon = ct.MaPhieuMuon,
                                  MaThanhVien = pm.MaThanhVien,
                                  TenThanhVien = tv.TenThanhVien,
                                  Barcode = bs.Barcode,
                                  TenSach = s.TenSach,
                                  MaBanSao = ct.MaBanSao ?? 0,
                                  NgayMuon = pm.NgayMuon,
                                  NgayTraDuKien = ct.NgayTraDuKien ?? DateTime.Now,
                                  NgayTraThucTe = ct.NgayTraThucTe,
                                  TrangThai = ct.TrangThai ?? "N/A",
                                  GhiChu = ct.GhiChu ?? ""
                              }).ToList();

                return result;
            }
        }

        public List<ChiTietPhieuMuonViewModel> GetUnreturnedBooksFromPhieuMuon(int maPhieuMuon)
        {
            return GetChiTietPhieuMuonViewModels(maPhieuMuon)
                .Where(x => x.CanReturn)
                .ToList();
        }
    }
}
