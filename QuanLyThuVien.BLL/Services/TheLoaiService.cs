using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BLL.Services
{
    public class TheLoaiService
    {
        private readonly IGenericRepository<TheLoai> _repository;
        public TheLoaiService(IGenericRepository<TheLoai> repository)
        {
            _repository = repository;
        }
        public IEnumerable<TheLoai> GetAllCategories()
        {
            return _repository.GetAll();
        }
    }
}
