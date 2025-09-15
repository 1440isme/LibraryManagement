using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BLL.Services
{
    public class BanSaoSachService
    {
        private readonly IGenericRepository<BanSaoSach> _repository;
        public BanSaoSachService(IGenericRepository<BanSaoSach> repository)
        {
            _repository = repository;
        }
        public IEnumerable<BanSaoSach> GetAllBanSaoSach()
        {
            var repo = _repository as GenericRepository<BanSaoSach>;
            if (repo != null)
            {
                return repo.GetAllIncluding(
                    bs => bs.MaSachNavigation
                );
            }
            return _repository.GetAll();
        }

        public IEnumerable<BanSaoSach> GetBaoSaoChuaMuon()
        {
            var repo = _repository as GenericRepository<BanSaoSach>;
            if (repo != null)
            {
                return repo.GetAllIncluding(bss => bss.MaSachNavigation)
                .Where(bss => bss.TinhTrang == "Sẵn sàng")
                .ToList();
            }
            return _repository.GetAll();
        }
        public void UpdateBanSaoSach(BanSaoSach bssach)
        {
            var banSao = _repository.GetById(bssach.MaBanSao);
            if (banSao == null)
                throw new ArgumentException("Bản sao sách không tồn tại.");

            banSao.ViTri = bssach.ViTri;
            banSao.GhiChu = bssach.GhiChu;
            banSao.TinhTrang = bssach.TinhTrang;

            _repository.Update(banSao);
            _repository.Save();
        }

        public List<BanSaoSachViewModel> GetAvailableBooksViewModel()
        {
            using (var context = new QuanLyThuVienContext())
            {
                var result = (from bs in context.BanSaoSach
                              join s in context.Sach on bs.MaSach equals s.MaSach
                              where bs.TinhTrang == "Sẵn sàng"
                              select new BanSaoSachViewModel
                              {
                                  Barcode = bs.Barcode,
                                  TenSach = s.TenSach,
                                  TinhTrang = bs.TinhTrang,
                                  MaBanSao = bs.MaBanSao
                              }).ToList();

                return result;
            }
        }
    }
}
