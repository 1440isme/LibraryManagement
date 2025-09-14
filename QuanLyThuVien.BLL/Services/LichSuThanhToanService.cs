using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BLL.Services
{
    public class LichSuThanhToanService
    {
        private readonly IGenericRepository<PaymentHistory> _repository;

        public LichSuThanhToanService(IGenericRepository<PaymentHistory> repository)
        {
            _repository = repository;
        }
        public IEnumerable<PaymentHistory> GetAllPaymentHistories()
        {
            return _repository.GetAll();
        }
    }
}
