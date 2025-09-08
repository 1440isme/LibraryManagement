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
    }
}
