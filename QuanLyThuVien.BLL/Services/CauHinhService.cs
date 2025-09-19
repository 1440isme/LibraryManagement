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
    public class CauHinhService
    {
        private readonly IGenericRepository<AuditLog> _repository;
        private readonly string _connectionString;

        public CauHinhService(IGenericRepository<AuditLog> repository)
        {
            _repository = repository;
            _connectionString = ConnectionStringProvider.GetConnectionString();

        }
        public IEnumerable<AuditLog> GetAllLogs()
        {
            return _repository.GetAll();
        }
        public DataTable LoadCauHinh()
        {
           
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("sp_LayDanhSachCauHinh", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;              

                var adapter = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
        public void UpdateCauHinh(string tenCauHinh, decimal giaTri, string moTa)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("sp_CapNhatCauHinhHeThong", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TenCauHinh", tenCauHinh);
                cmd.Parameters.AddWithValue("@GiaTriMoi", giaTri);
                cmd.Parameters.AddWithValue("@MoTa", moTa);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
