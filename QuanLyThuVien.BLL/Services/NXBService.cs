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

        public void DeletePublisher(int maNXB)
        {
            _repository.Delete(maNXB);
            _repository.Save();
        }
        public void AddPublisher(NhaXuatBan nxb)
        {
            if (nxb == null)
                throw new ArgumentNullException(nameof(nxb), "Nhà xuất bản không được để null.");
            if (string.IsNullOrWhiteSpace(nxb.TenNhaXuatBan))
                throw new ArgumentException("Tên nhà xuất bản không được để trống.", nameof(nxb.TenNhaXuatBan));
           
            _repository.Insert(nxb);
            _repository.Save();
        }
        public void UpdatePublisher(NhaXuatBan nxb)
        {
            if (nxb == null)
                throw new ArgumentNullException(nameof(nxb), "Nhà xuất bản không được để null.");
            if (string.IsNullOrWhiteSpace(nxb.TenNhaXuatBan))
                throw new ArgumentException("Tên nhà xuất bản không được để trống.", nameof(nxb.TenNhaXuatBan));
            
            var existing = _repository.GetById(nxb.MaNhaXuatBan);
            if (existing == null)
                throw new InvalidOperationException("Không tìm thấy nhà xuất bản để cập nhật.");
            existing.TenNhaXuatBan = nxb.TenNhaXuatBan;
            existing.DiaChi = nxb.DiaChi;
            existing.SoDienThoai = nxb.SoDienThoai;
            _repository.Update(nxb);
            _repository.Save();
        }
    }
}
