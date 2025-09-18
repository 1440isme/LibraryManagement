using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BLL.Services
{
    public class SachService
    {
        private readonly IGenericRepository<Sach> _repository;
        private readonly string _connectionString;

        public SachService(IGenericRepository<Sach> repository)
        {
            _repository = repository;
            _connectionString = ConfigurationManager.ConnectionStrings["QuanLyThuVienConnectionString"].ConnectionString;
        }

        public IEnumerable<Sach> GetAllBooks()
        {
            using (var newContext = new QuanLyThuVienContext())
            {
                return newContext.Sach
                    .Include(s => s.MaTacGiaNavigation)
                    .Include(s => s.MaTheLoaiNavigation)
                    .Include(s => s.MaNhaXuatBanNavigation)
                    .ToList();
            }
        }
        
        public void DeleteBook(int maSach)
        {
            if (maSach <= 0)
                throw new ArgumentException("Mã sách không hợp lệ.", nameof(maSach));

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("[dbo].[XoaSach]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 60;

                    command.Parameters.Add("@MaSach", SqlDbType.Int).Value = maSach;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        
        public void AddBook(string tenSach, string isbn, int maTacGia, int maNhaXuatBan, int maTheLoai, 
                           int namXuatBan, decimal gia, int soLuong, bool trangThai = true)
        {
            if (string.IsNullOrWhiteSpace(tenSach))
                throw new ArgumentException("Tên sách không được để trống.", nameof(tenSach));
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("ISBN không được để trống.", nameof(isbn));
            if (maTacGia <= 0)
                throw new ArgumentException("Mã tác giả không hợp lệ.", nameof(maTacGia));
            if (maNhaXuatBan <= 0)
                throw new ArgumentException("Mã nhà xuất bản không hợp lệ.", nameof(maNhaXuatBan));
            if (maTheLoai <= 0)
                throw new ArgumentException("Mã thể loại không hợp lệ.", nameof(maTheLoai));

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("[dbo].[ThemSach]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 60;

                    command.Parameters.Add("@TenSach", SqlDbType.NVarChar, 200).Value = tenSach;
                    command.Parameters.Add("@ISBN", SqlDbType.NVarChar, 13).Value = isbn;
                    command.Parameters.Add("@MaTacGia", SqlDbType.Int).Value = maTacGia;
                    command.Parameters.Add("@MaNhaXuatBan", SqlDbType.Int).Value = maNhaXuatBan;
                    command.Parameters.Add("@MaTheLoai", SqlDbType.Int).Value = maTheLoai;
                    command.Parameters.Add("@NamXuatBan", SqlDbType.Int).Value = namXuatBan;
                    command.Parameters.Add("@Gia", SqlDbType.Decimal).Value = gia;
                    command.Parameters.Add("@SoLuong", SqlDbType.Int).Value = soLuong;
                    command.Parameters.Add("@TrangThai", SqlDbType.Bit).Value = trangThai;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        
        public void UpdateBook(int maSach, string tenSach, string isbn, int maTacGia, int maNhaXuatBan, int maTheLoai, 
                              int namXuatBan, decimal gia, int soLuong, bool trangThai)
        {
            if (maSach <= 0)
                throw new ArgumentException("Mã sách không hợp lệ.", nameof(maSach));
            if (string.IsNullOrWhiteSpace(tenSach))
                throw new ArgumentException("Tên sách không được để trống.", nameof(tenSach));
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("ISBN không được để trống.", nameof(isbn));
            if (maTacGia <= 0)
                throw new ArgumentException("Mã tác giả không hợp lệ.", nameof(maTacGia));
            if (maNhaXuatBan <= 0)
                throw new ArgumentException("Mã nhà xuất bản không hợp lệ.", nameof(maNhaXuatBan));
            if (maTheLoai <= 0)
                throw new ArgumentException("Mã thể loại không hợp lệ.", nameof(maTheLoai));

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("[dbo].[SuaSach]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 60;

                    command.Parameters.Add("@MaSach", SqlDbType.Int).Value = maSach;
                    command.Parameters.Add("@TenSach", SqlDbType.NVarChar, 200).Value = tenSach;
                    command.Parameters.Add("@ISBN", SqlDbType.NVarChar, 13).Value = isbn;
                    command.Parameters.Add("@MaTacGia", SqlDbType.Int).Value = maTacGia;
                    command.Parameters.Add("@MaNhaXuatBan", SqlDbType.Int).Value = maNhaXuatBan;
                    command.Parameters.Add("@MaTheLoai", SqlDbType.Int).Value = maTheLoai;
                    command.Parameters.Add("@NamXuatBan", SqlDbType.Int).Value = namXuatBan;
                    command.Parameters.Add("@Gia", SqlDbType.Decimal).Value = gia;
                    command.Parameters.Add("@SoLuong", SqlDbType.Int).Value = soLuong;
                    command.Parameters.Add("@TrangThai", SqlDbType.Bit).Value = trangThai;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
