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
    public class NXBService
    {
        private readonly IGenericRepository<NhaXuatBan> _repository;
        private readonly string _connectionString;
        
        public NXBService(IGenericRepository<NhaXuatBan> repository)
        {
            _repository = repository;
            _connectionString = ConfigurationManager.ConnectionStrings["QuanLyThuVienConnectionString"].ConnectionString;
        }
        
        public IEnumerable<NhaXuatBan> GetAllPublishers()
        {
            using (var newContext = new QuanLyThuVienContext())
            {
                return newContext.NhaXuatBan.ToList();
            }
        }

        public void DeletePublisher(int maNXB)
        {
            if (maNXB <= 0)
                throw new ArgumentException("Mã nhà xuất bản không hợp lệ.", nameof(maNXB));

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("[dbo].[XoaNhaXuatBan]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 60;

                    command.Parameters.Add("@MaNhaXuatBan", SqlDbType.Int).Value = maNXB;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        
        public void AddPublisher(string tenNhaXuatBan, string diaChi = null, string soDienThoai = null)
        {
            if (string.IsNullOrWhiteSpace(tenNhaXuatBan))
                throw new ArgumentException("Tên nhà xuất bản không được để trống.", nameof(tenNhaXuatBan));

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("[dbo].[ThemNhaXuatBan]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 60;

                    command.Parameters.Add("@TenNhaXuatBan", SqlDbType.NVarChar, 100).Value = tenNhaXuatBan;
                    command.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 200).Value = 
                        string.IsNullOrWhiteSpace(diaChi) ? (object)DBNull.Value : diaChi;
                    command.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar, 20).Value = 
                        string.IsNullOrWhiteSpace(soDienThoai) ? (object)DBNull.Value : soDienThoai;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        
        public void UpdatePublisher(int maNhaXuatBan, string tenNhaXuatBan, string diaChi = null, string soDienThoai = null)
        {
            if (maNhaXuatBan <= 0)
                throw new ArgumentException("Mã nhà xuất bản không hợp lệ.", nameof(maNhaXuatBan));
                
            if (string.IsNullOrWhiteSpace(tenNhaXuatBan))
                throw new ArgumentException("Tên nhà xuất bản không được để trống.", nameof(tenNhaXuatBan));

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("[dbo].[SuaNhaXuatBan]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 60;

                    command.Parameters.Add("@MaNhaXuatBan", SqlDbType.Int).Value = maNhaXuatBan;
                    command.Parameters.Add("@TenNhaXuatBan", SqlDbType.NVarChar, 100).Value = tenNhaXuatBan;
                    command.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 200).Value = 
                        string.IsNullOrWhiteSpace(diaChi) ? (object)DBNull.Value : diaChi;
                    command.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar, 20).Value = 
                        string.IsNullOrWhiteSpace(soDienThoai) ? (object)DBNull.Value : soDienThoai;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
