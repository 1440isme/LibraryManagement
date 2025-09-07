using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BLL.Services
{
    public class NXBService
    {
        private readonly IGenericRepository<NhaXuatBan> _repository;
        public NXBService(IGenericRepository<NhaXuatBan> repository)
        {
            _repository = repository;
        }
        public IEnumerable<NhaXuatBan> GetAllPublishers()
        {
            return _repository.GetAll();
        }
    }
}
