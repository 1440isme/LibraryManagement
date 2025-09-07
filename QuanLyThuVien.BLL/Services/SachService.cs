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
        public void DeleteBook(int maSach)
        {
            _repository.Delete(maSach);
            _repository.Save();
        }
        public void AddBook(Sach sach)
        {
            if (sach == null)
                throw new ArgumentNullException(nameof(sach), "Sách không được để null.");

            // Có thể kiểm tra các trường bắt buộc ở đây nếu cần
            if (string.IsNullOrWhiteSpace(sach.TenSach))
                throw new ArgumentException("Tên sách không được để trống.", nameof(sach.TenSach));
            if (string.IsNullOrWhiteSpace(sach.ISBN))
                throw new ArgumentException("ISBN không được để trống.", nameof(sach.ISBN));
            if (sach.MaTacGia <= 0)
                throw new ArgumentException("Mã tác giả không hợp lệ.", nameof(sach.MaTacGia));
            if (sach.MaNhaXuatBan <= 0)
                throw new ArgumentException("Mã nhà xuất bản không hợp lệ.", nameof(sach.MaNhaXuatBan));
            if (sach.MaTheLoai <= 0)
                throw new ArgumentException("Mã thể loại không hợp lệ.", nameof(sach.MaTheLoai));

            _repository.Insert(sach);
            _repository.Save();
        }
        public void UpdateBook(Sach sach)
        {
            if (sach == null)
                throw new ArgumentNullException(nameof(sach), "Sách không được để null.");

            if (sach.MaSach <= 0)
                throw new ArgumentException("Mã sách không hợp lệ.", nameof(sach.MaSach));
            if (string.IsNullOrWhiteSpace(sach.TenSach))
                throw new ArgumentException("Tên sách không được để trống.", nameof(sach.TenSach));
            if (string.IsNullOrWhiteSpace(sach.ISBN))
                throw new ArgumentException("ISBN không được để trống.", nameof(sach.ISBN));
            if (sach.MaTacGia <= 0)
                throw new ArgumentException("Mã tác giả không hợp lệ.", nameof(sach.MaTacGia));
            if (sach.MaNhaXuatBan <= 0)
                throw new ArgumentException("Mã nhà xuất bản không hợp lệ.", nameof(sach.MaNhaXuatBan));
            if (sach.MaTheLoai <= 0)
                throw new ArgumentException("Mã thể loại không hợp lệ.", nameof(sach.MaTheLoai));

            var existing = _repository.GetById(sach.MaSach);
            if (existing == null)
                throw new InvalidOperationException("Không tìm thấy sách để cập nhật.");

            existing.TenSach = sach.TenSach;
            existing.ISBN = sach.ISBN;
            existing.MaTacGia = sach.MaTacGia;
            existing.MaNhaXuatBan = sach.MaNhaXuatBan;
            existing.MaTheLoai = sach.MaTheLoai;
            existing.NamXuatBan = sach.NamXuatBan;
            existing.Gia = sach.Gia;
            existing.SoLuong = sach.SoLuong;
            existing.TrangThai = sach.TrangThai;

            _repository.Update(existing);
            _repository.Save();
        }

        
    }
}
