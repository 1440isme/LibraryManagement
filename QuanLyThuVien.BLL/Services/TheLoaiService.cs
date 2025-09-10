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
        public void DeleteTheLoai(int maTheLoai)
        {
            _repository.Delete(maTheLoai);
            _repository.Save();
        }
        public void AddTheLoai(TheLoai theLoai)
        {
            if (theLoai == null)
                throw new ArgumentNullException(nameof(theLoai), "Thể loại không được để null.");
            _repository.Insert(theLoai);
            _repository.Save();

        }

        public void UpdateTheLoai(TheLoai theLoai)
        {
            if (theLoai == null)
                throw new ArgumentNullException(nameof(theLoai), "Thể loại không được để null.");
            var exist = _repository.GetById(theLoai.MaTheLoai);
            if (exist == null)
                throw new InvalidOperationException("Không tìm thấy nhà xuất bản để cập nhật.");
            exist.TenTheLoai = theLoai.TenTheLoai;
            exist.MoTa = theLoai.MoTa;
            _repository.Update(theLoai);
            _repository.Save();
        }
    }
}
