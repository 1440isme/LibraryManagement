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
    public class TacGiaService
    {
        private readonly IGenericRepository<TacGia> _repository;
        private readonly string _connectionString;
        
        public TacGiaService(IGenericRepository<TacGia> repository)
        {
            _repository = repository;
            _connectionString = ConnectionStringProvider.GetConnectionString();
        }
        
        public IEnumerable<TacGia> GetAllAuthors()
        {
            using (var newContext = ContextFactory.CreateContext())
            {
                return newContext.TacGia.ToList();
            }
        }
        
        public void DeleteAuthor(int maTacGia)
        {
            if (maTacGia <= 0)
                throw new ArgumentException("Mã tác giả không hợp lệ.", nameof(maTacGia));

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("[dbo].[XoaTacGia]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 60;

                    command.Parameters.Add("@MaTacGia", SqlDbType.Int).Value = maTacGia;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        
        public void AddAuthor(string tenTacGia, string quocTich = null, int? namSinh = null)
        {
            if (string.IsNullOrWhiteSpace(tenTacGia))
                throw new ArgumentException("Tên tác giả không được để trống.", nameof(tenTacGia));

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("[dbo].[ThemTacGia]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 60;

                    command.Parameters.Add("@TenTacGia", SqlDbType.NVarChar, 100).Value = tenTacGia;
                    command.Parameters.Add("@QuocTich", SqlDbType.NVarChar, 50).Value = 
                        string.IsNullOrWhiteSpace(quocTich) ? (object)DBNull.Value : quocTich;
                    command.Parameters.Add("@NamSinh", SqlDbType.Int).Value = 
                        namSinh.HasValue ? (object)namSinh.Value : DBNull.Value;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        
        public void UpdateAuthor(int maTacGia, string tenTacGia, string quocTich = null, int? namSinh = null)
        {
            if (maTacGia <= 0)
                throw new ArgumentException("Mã tác giả không hợp lệ.", nameof(maTacGia));
                
            if (string.IsNullOrWhiteSpace(tenTacGia))
                throw new ArgumentException("Tên tác giả không được để trống.", nameof(tenTacGia));

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("[dbo].[SuaTacGia]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 60;

                    command.Parameters.Add("@MaTacGia", SqlDbType.Int).Value = maTacGia;
                    command.Parameters.Add("@TenTacGia", SqlDbType.NVarChar, 100).Value = tenTacGia;
                    command.Parameters.Add("@QuocTich", SqlDbType.NVarChar, 50).Value = 
                        string.IsNullOrWhiteSpace(quocTich) ? (object)DBNull.Value : quocTich;
                    command.Parameters.Add("@NamSinh", SqlDbType.Int).Value = 
                        namSinh.HasValue ? (object)namSinh.Value : DBNull.Value;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
