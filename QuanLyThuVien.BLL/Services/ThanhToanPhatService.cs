using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyThuVien.BLL.Services
{
    public class ThanhToanPhatService
    {
        private readonly string _connectionString;

        public ThanhToanPhatService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["QuanLyThuVienConnectionString"].ConnectionString;
        }

        public void ExecuteThanhToanPhatProc(int maPhat, string note, string method = "Tiền mặt")
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("ThanhToanPhat", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 60;

                    command.Parameters.Add("@MaPhat", SqlDbType.Int).Value = maPhat;
                    command.Parameters.Add("@Method", SqlDbType.NVarChar, 50).Value = method ?? "Tiền mặt";
                    command.Parameters.Add("@Note", SqlDbType.NVarChar, 200).Value = note ?? (object)DBNull.Value;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}