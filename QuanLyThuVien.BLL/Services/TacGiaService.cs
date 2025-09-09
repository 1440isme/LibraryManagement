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
        public void DeleteAuthor(int maTacGia)
        {
            _repository.Delete(maTacGia);
            _repository.Save();
        }
        public void AddAuthor(TacGia tacGia)
        {
            if (tacGia == null)
                throw new ArgumentNullException(nameof(tacGia), "Tác giả không được để null.");
            if (string.IsNullOrWhiteSpace(tacGia.TenTacGia))
                throw new ArgumentException("Tên tác giả không được để trống.", nameof(tacGia.TenTacGia));
            if (string.IsNullOrWhiteSpace(tacGia.QuocTich))
                throw new ArgumentException("Quốc tịch không được để trống.", nameof(tacGia.QuocTich));
            if (tacGia.NamSinh < 0 || tacGia.NamSinh > DateTime.Now.Year)
                throw new ArgumentException("Năm sinh không hợp lệ.", nameof(tacGia.NamSinh));
            _repository.Insert(tacGia);
            _repository.Save();
        }
        public void UpdateAuthor(TacGia tacGia)
        {
            if (tacGia == null)
                throw new ArgumentNullException(nameof(tacGia), "Tác giả không được để null.");
            if (string.IsNullOrWhiteSpace(tacGia.TenTacGia))
                throw new ArgumentException("Tên tác giả không được để trống.", nameof(tacGia.TenTacGia));
            if (string.IsNullOrWhiteSpace(tacGia.QuocTich))
                throw new ArgumentException("Quốc tịch không được để trống.", nameof(tacGia.QuocTich));
            if (tacGia.NamSinh < 0 || tacGia.NamSinh > DateTime.Now.Year)
                throw new ArgumentException("Năm sinh không hợp lệ.", nameof(tacGia.NamSinh));

            var existing = _repository.GetById(tacGia.MaTacGia);
            if (existing == null)
                throw new InvalidOperationException("Không tìm thấy tác giả để cập nhật.");
            existing.TenTacGia = tacGia.TenTacGia;
            existing.QuocTich = tacGia.QuocTich;
            existing.NamSinh = tacGia.NamSinh;
            _repository.Update(tacGia);
            _repository.Save();
        }

    }
}
