using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
            using (var context = ContextFactory.CreateContext())
            {
                return context.PhieuMuon
                    .Include(pm => pm.MaThanhVienNavigation)
                    .Include(pm => pm.User)
                    .Include(pm => pm.ChiTietPhieuMuon)
                        .ThenInclude(ct => ct.MaSachNavigation)
                    .Include(pm => pm.ChiTietPhieuMuon)
                        .ThenInclude(ct => ct.MaBanSaoNavigation)
                    .ToList();
            }
        }

        public void DeletePhieuMuon(int maPhieuMuon)
        {
            _repository.Delete(maPhieuMuon);
            _repository.Save();
        }
        
        public int MuonSach(int maThanhVien, int userId, DateTime ngayTraDuKien, List<int> listMaBanSao, string ghichu, int? maPhieuMuon = null)
        {
            return _muonSachProcService.ExecuteMuonSachProc(maThanhVien, userId, ngayTraDuKien, listMaBanSao, ghichu, maPhieuMuon);
        }

        public void UpdatePhieuMuon(PhieuMuon phieuMuon)
        {
            var existing = _repository.GetById(phieuMuon.MaPhieuMuon);
            if (existing == null)
                throw new ArgumentException("Phiếu mượn không tồn tại.");
            
            existing.NgayMuon = phieuMuon.NgayMuon;
            existing.NgayTraDuKien = phieuMuon.NgayTraDuKien;
            existing.GhiChu = phieuMuon.GhiChu;
            _repository.Update(existing);
            _repository.Save();
        }
    }
}
