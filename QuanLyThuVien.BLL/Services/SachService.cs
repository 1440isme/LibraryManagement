using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BLL.Services
{
    public class SachService
    {
        private readonly IGenericRepository<Sach> _repository;

        public SachService(IGenericRepository<Sach> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Sach> GetAllBooks()
        {
            var repo = _repository as GenericRepository<Sach>;
            if (repo != null)
            {
                return repo.GetAllIncluding(
                    s => s.MaTacGiaNavigation,
                    s => s.MaTheLoaiNavigation,
                    s => s.MaNhaXuatBanNavigation
                );
            }
            return _repository.GetAll();
        }

        public void AddBook(Sach book)
        {
            _repository.Insert(book);
            _repository.Save();
        }
    }
}
