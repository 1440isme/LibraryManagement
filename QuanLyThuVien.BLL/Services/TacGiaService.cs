using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BLL.Services
{
    public class TacGiaService
    {
        private readonly IGenericRepository<TacGia> _repository;
        public TacGiaService(IGenericRepository<TacGia> repository)
        {
            _repository = repository;
        }
        public IEnumerable<TacGia> GetAllAuthors()
        {
            return _repository.GetAll();
        }
       
    }
}
