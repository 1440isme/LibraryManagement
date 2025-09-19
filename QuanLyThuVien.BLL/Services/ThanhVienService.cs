using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BLL.Services
{
    public class ThanhVienService
    {
        private readonly IGenericRepository<ThanhVien> _repository;
        private readonly string _connectionString;

        public ThanhVienService(IGenericRepository<ThanhVien> repository)
        {
            _repository = repository;
            _connectionString = ConnectionStringProvider.GetConnectionString();
        }
        
        public IEnumerable<ThanhVien> GetAllMembers()
        {
            using (var newContext = ContextFactory.CreateContext())
            {
                return newContext.ThanhVien.ToList();
            }
        }

        public void AddMember(int maThanhVien, string tenThanhVien, string email, string soDienThoai = null, 
                             string diaChi = null, string loaiThanhVien = "SinhVien", DateTime? ngayDangKy = null)
        {
            if (maThanhVien <= 0)
                throw new ArgumentException("Mã thành viên phải lớn hơn 0", nameof(maThanhVien));
            if (string.IsNullOrWhiteSpace(tenThanhVien))
                throw new ArgumentException("Tên thành viên không được để trống", nameof(tenThanhVien));
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email không được để trống", nameof(email));
            if (string.IsNullOrWhiteSpace(loaiThanhVien))
                throw new ArgumentException("Loại thành viên không được để trống", nameof(loaiThanhVien));

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("[dbo].[ThemThanhVien]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 60;

                    command.Parameters.Add("@MaThanhVien", SqlDbType.Int).Value = maThanhVien;
                    command.Parameters.Add("@TenThanhVien", SqlDbType.NVarChar, 100).Value = tenThanhVien;
                    command.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = email;
                    command.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar, 20).Value = 
                        string.IsNullOrWhiteSpace(soDienThoai) ? (object)DBNull.Value : soDienThoai;
                    command.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 200).Value = 
                        string.IsNullOrWhiteSpace(diaChi) ? (object)DBNull.Value : diaChi;
                    command.Parameters.Add("@LoaiThanhVien", SqlDbType.NVarChar, 20).Value = loaiThanhVien;
                    command.Parameters.Add("@NgayDangKy", SqlDbType.Date).Value = 
                        ngayDangKy.HasValue ? (object)ngayDangKy.Value : DBNull.Value;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        
        public void UpdateMember(int maThanhVien, string tenThanhVien, string email, string soDienThoai = null, 
                                string diaChi = null, string loaiThanhVien = "SinhVien", DateTime? ngayDangKy = null)
        {
            if (maThanhVien <= 0)
                throw new ArgumentException("Mã thành viên không hợp lệ", nameof(maThanhVien));
            if (string.IsNullOrWhiteSpace(tenThanhVien))
                throw new ArgumentException("Tên thành viên không được để trống", nameof(tenThanhVien));
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email không được để trống", nameof(email));
            if (string.IsNullOrWhiteSpace(loaiThanhVien))
                throw new ArgumentException("Loại thành viên không được để trống", nameof(loaiThanhVien));

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("[dbo].[SuaThanhVien]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 60;

                    command.Parameters.Add("@MaThanhVien", SqlDbType.Int).Value = maThanhVien;
                    command.Parameters.Add("@TenThanhVien", SqlDbType.NVarChar, 100).Value = tenThanhVien;
                    command.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = email;
                    command.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar, 20).Value = 
                        string.IsNullOrWhiteSpace(soDienThoai) ? (object)DBNull.Value : soDienThoai;
                    command.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 200).Value = 
                        string.IsNullOrWhiteSpace(diaChi) ? (object)DBNull.Value : diaChi;
                    command.Parameters.Add("@LoaiThanhVien", SqlDbType.NVarChar, 20).Value = loaiThanhVien;
                    command.Parameters.Add("@NgayDangKy", SqlDbType.Date).Value = 
                        ngayDangKy ?? DateTime.Now;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        
        public void DeleteMember(int maThanhVien)
        {
            if (maThanhVien <= 0)
                throw new ArgumentException("Mã thành viên không hợp lệ", nameof(maThanhVien));

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("[dbo].[XoaThanhVien]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 60;

                    command.Parameters.Add("@MaThanhVien", SqlDbType.Int).Value = maThanhVien;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
