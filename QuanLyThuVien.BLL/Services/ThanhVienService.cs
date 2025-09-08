using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BLL.Services
{
    public class ThanhVienService
    {
        private readonly IGenericRepository<ThanhVien> _repository;

        public ThanhVienService(IGenericRepository<ThanhVien> repository)
        {
            _repository = repository;
        }
        public IEnumerable<ThanhVien> GetAllMembers()
        {
            return _repository.GetAll();
        }

        public void AddMember(ThanhVien member)
        {
            if (member == null)
                throw new ArgumentNullException(nameof(member), "Thành viên không được để null");
            if (string.IsNullOrWhiteSpace(member.TenThanhVien))
                throw new ArgumentException("Tên thành viên không được để trống", nameof(member.TenThanhVien));
            if (string.IsNullOrWhiteSpace(member.Email))
                throw new ArgumentException("Email không được để trống", nameof(member.Email));
            if (string.IsNullOrWhiteSpace(member.LoaiThanhVien))
                throw new ArgumentException("Loại thành viên không được để trống", nameof(member.LoaiThanhVien));
          
            _repository.Insert(member);
            _repository.Save();
        }
        public void UpdateMember(ThanhVien member)
        {
            if (member == null)
                throw new ArgumentNullException(nameof(member), "Thành viên không được để null");
            if (string.IsNullOrWhiteSpace(member.TenThanhVien))
                throw new ArgumentException("Tên thành viên không được để trống", nameof(member.TenThanhVien));
            if (string.IsNullOrWhiteSpace(member.Email))
                throw new ArgumentException("Email không được để trống", nameof(member.Email));
            if (string.IsNullOrWhiteSpace(member.LoaiThanhVien))
                throw new ArgumentException("Loại thành viên không được để trống", nameof(member.LoaiThanhVien));

            var exist = _repository.GetById(member.MaThanhVien);
            if (exist == null)
                throw new ArgumentException("Thành viên không tồn tại", nameof(member.MaThanhVien));
            exist.TenThanhVien = member.TenThanhVien;
            exist.Email = member.Email;
            exist.SoDienThoai = member.SoDienThoai;
            exist.DiaChi = member.DiaChi;
            exist.LoaiThanhVien = member.LoaiThanhVien;
            exist.NgayDangKy = member.NgayDangKy;
            _repository.Update(member);
            _repository.Save();
        }
        public void DeleteMember(int maThanhVien)
        {
            var exist = _repository.GetById(maThanhVien);
            if (exist == null)
                throw new ArgumentException("Thành viên không tồn tại", nameof(maThanhVien));
            _repository.Delete(maThanhVien);
            _repository.Save();
        }
    }
}
