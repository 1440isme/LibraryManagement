using Microsoft.EntityFrameworkCore;
using QuanLyThuVien.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BLL.Services
{
    public class ThongTinThanhVienService
    {
        public List<ThongTinThanhVienProc> GetThongTinThanhVien(int maThanhVien)
        {
            using (QuanLyThuVienContext context = new QuanLyThuVienContext())
            {
                var result = context.ThongTinThanhVien
                    .FromSqlInterpolated($"EXEC sp_GetThongTinThanhVienMuonTra @MaThanhVien = {maThanhVien}")
                    .ToList();
                return result;
            }
        }
    }
}
