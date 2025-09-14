using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            if (listMaBanSao == null || listMaBanSao.Count == 0)
                throw new ArgumentException("listMaBanSao is empty.");

            var tinhTrang = (tinhTrangSach ?? "BinhThuong").Trim();

            using (var connection = new SqlConnection(_connectionString))
            {
                var errors = new StringBuilder();
                var successCount = 0;

                connection.InfoMessage += (s, e) => { /* e.Message available if you add PRINTs inside proc */ };

                connection.Open();

                foreach (var maBanSao in listMaBanSao)
                {
                    try
                    {
                        using (var command = new SqlCommand("[dbo].[TraSachProc]", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandTimeout = 60;

                            command.Parameters.Add("@MaBanSao", SqlDbType.Int).Value = maBanSao;
                            command.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
                            command.Parameters.Add("@TinhTrangSach", SqlDbType.NVarChar, 20).Value = tinhTrang;
                            command.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 255).Value =
                                string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu.Trim();

                            command.ExecuteNonQuery();
                            successCount++;
                        }
                    }
                    catch (Exception ex)
                    {
                        errors.AppendLine($"Error processing MaBanSao={maBanSao}: {ex.Message}");
                    }
                }

                if (errors.Length > 0)
                {
                    if (successCount == 0)
                        throw new Exception($"Failed to process any books. Errors: {errors}");

                    throw new Exception($"Processed {successCount}/{listMaBanSao.Count}. Errors: {errors}");
                }
            }
        }
    }
}