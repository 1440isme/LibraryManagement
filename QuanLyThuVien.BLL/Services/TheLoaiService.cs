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
    public class TheLoaiService
    {
        private readonly IGenericRepository<TheLoai> _repository;
        private readonly string _connectionString;
        public TheLoaiService(IGenericRepository<TheLoai> repository)
        {
            _repository = repository;
            _connectionString = ConfigurationManager.ConnectionStrings["QuanLyThuVienConnectionString"].ConnectionString;

        }
        public IEnumerable<TheLoai> GetAllCategories()
        {
            using (var newContext = new QuanLyThuVienContext())
            {
                return newContext.TheLoai.ToList();
            }
        }
        public void DeleteTheLoai(int maTheLoai)
        {
            if (maTheLoai <= 0)
                throw new ArgumentException("Mã thể loại không hợp lệ.", nameof(maTheLoai));

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("[dbo].[XoaTheLoai]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 60;

                    command.Parameters.Add("@MaTheLoai", SqlDbType.Int).Value = maTheLoai;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void AddTheLoai(string tenTheLoai, string moTa = null)
        {
            if (string.IsNullOrWhiteSpace(tenTheLoai))
                throw new ArgumentException("Tên thể loại không được để trống.", nameof(tenTheLoai));

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("[dbo].[ThemTheLoai]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 60;

                    command.Parameters.Add("@TenTheLoai", SqlDbType.NVarChar, 50).Value = tenTheLoai;
                    command.Parameters.Add("@MoTa", SqlDbType.NVarChar, 200).Value =
                        string.IsNullOrWhiteSpace(moTa) ? (object)DBNull.Value : moTa;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }

        public void UpdateTheLoai(int maTheLoai, string tenTheLoai, string moTa = null)
        {
            if (maTheLoai <= 0)
                throw new ArgumentException("Mã thể loại không hợp lệ.", nameof(maTheLoai));

            if (string.IsNullOrWhiteSpace(tenTheLoai))
                throw new ArgumentException("Tên thể loại không được để trống.", nameof(tenTheLoai));

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("[dbo].[SuaTheLoai]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 60;

                    command.Parameters.Add("@MaTheLoai", SqlDbType.Int).Value = maTheLoai;
                    command.Parameters.Add("@TenTheLoai", SqlDbType.NVarChar, 50).Value = tenTheLoai;
                    command.Parameters.Add("@MoTa", SqlDbType.NVarChar, 200).Value =
                        string.IsNullOrWhiteSpace(moTa) ? (object)DBNull.Value : moTa;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
