using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BLL.Services
{
    public class PhieuMuonService
    {
        private readonly IGenericRepository<PhieuMuon> _repository;
        private readonly MuonSachProcService _muonSachProcService;
        public PhieuMuonService(IGenericRepository<PhieuMuon> repository)
        {
            _repository = repository;
            _muonSachProcService = new MuonSachProcService();
        }
        public IEnumerable<PhieuMuon> GetAllPhieuMuons()
        {
            var repo = _repository as GenericRepository<PhieuMuon>;
            if (repo != null)
            {
                return repo.GetAllIncluding(
                    pm => pm.MaThanhVienNavigation,
                    pm => pm.ChiTietPhieuMuon
                );
            }
            return _repository.GetAll();
        }

        public void DeletePhieuMuon(int maPhieuMuon)
        {
            _repository.Delete(maPhieuMuon);
            _repository.Save();
        }
        public int MuonSach(int maThanhVien, int userId, DateTime ngayTraDuKien, List<int> listMaBanSao, int? maPhieuMuon = null)
        {
            return _muonSachProcService.ExecuteMuonSachProc(maThanhVien, userId, ngayTraDuKien, listMaBanSao, maPhieuMuon);
        }
    }
}
