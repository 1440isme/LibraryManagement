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
    public class MuonSachProcService
    {
        private readonly string _connectionString;

        public MuonSachProcService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["QuanLyThuVienConnectionString"].ConnectionString;
        }

        public int ExecuteMuonSachProc(int maThanhVien, int userId, DateTime ngayTraDuKien, List<int> listMaBanSao, int? maPhieuMuon = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("MuonSachProc", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var listBanSaoTable = new DataTable();
                    listBanSaoTable.Columns.Add("MaBanSao", typeof(int));

                    foreach (var maBanSao in listMaBanSao)
                    {
                        listBanSaoTable.Rows.Add(maBanSao);
                    }

                    command.Parameters.Add("@MaThanhVien", SqlDbType.Int).Value = maThanhVien;
                    command.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
                    command.Parameters.Add("@NgayTraDuKien", SqlDbType.Date).Value = ngayTraDuKien;

                    var tableParam = command.Parameters.AddWithValue("@ListBanSao", listBanSaoTable);
                    tableParam.SqlDbType = SqlDbType.Structured;
                    tableParam.TypeName = "dbo.ListBanSao";

                    if (maPhieuMuon.HasValue)
                    {
                        command.Parameters.Add("@MaPhieuMuon", SqlDbType.Int).Value = maPhieuMuon.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@MaPhieuMuon", SqlDbType.Int).Value = DBNull.Value;
                    }

                    connection.Open();
                    var result = command.ExecuteScalar();

                    return maPhieuMuon ?? Convert.ToInt32(result);
                }
            }
        }
    }
}
