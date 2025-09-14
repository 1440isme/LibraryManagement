using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace QuanLyThuVien.BLL.Services
{
    public class TraSachProcService
    {
        private readonly string _connectionString;

        public TraSachProcService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["QuanLyThuVienConnectionString"].ConnectionString;
        }

        public void ExecuteTraNhieuSachProc(List<int> listMaBanSao, int userId, string tinhTrangSach, string ghiChu = null)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                
                var errors = new StringBuilder();
                var successCount = 0;

                foreach (var maBanSao in listMaBanSao)
                {
                    try
                    {
                        using (var transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                using (var command = new SqlCommand("TraSachProc", connection, transaction))
                                {
                                    command.CommandType = CommandType.StoredProcedure;
                                    
                                    command.Parameters.Add("@MaBanSao", SqlDbType.Int).Value = maBanSao;
                                    command.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
                                    command.Parameters.Add("@TinhTrangSach", SqlDbType.NVarChar, 20).Value = tinhTrangSach;
                                    command.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 255).Value = 
                                        string.IsNullOrEmpty(ghiChu) ? (object)DBNull.Value : ghiChu;

                                    command.ExecuteNonQuery();
                                    
                                    
                                    transaction.Commit();
                                    successCount++;
                                }
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                errors.AppendLine($"Error processing book with MaBanSao: {maBanSao}. Error: {ex.Message}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        errors.AppendLine($"Transaction error for book with MaBanSao: {maBanSao}. Error: {ex.Message}");
                    }
                }

                if (errors.Length > 0)
                {
                    if (successCount == 0)
                    {
                        throw new Exception($"Failed to process any books. Errors: {errors}");
                    }
                    
                }
                
            }
        }
    }
}