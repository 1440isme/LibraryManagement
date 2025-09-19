using Microsoft.EntityFrameworkCore;
using QuanLyThuVien.DAL.Entities;
using System;

namespace QuanLyThuVien.BLL.Services
{
    public static class ContextFactory
    {
        public static QuanLyThuVienContext CreateContext()
        {
            var connectionString = ConnectionStringProvider.GetConnectionString();
            
            var optionsBuilder = new DbContextOptionsBuilder<QuanLyThuVienContext>();
            optionsBuilder.UseSqlServer(connectionString);
            
            return new QuanLyThuVienContext(optionsBuilder.Options);
        }

        public static QuanLyThuVienContext CreateContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<QuanLyThuVienContext>();
            optionsBuilder.UseSqlServer(connectionString);
            
            return new QuanLyThuVienContext(optionsBuilder.Options);
        }
    }
}