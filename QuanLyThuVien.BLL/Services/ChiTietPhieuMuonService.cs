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
    }
}
