using System;

namespace QuanLyThuVien.BLL.Services
{
    public interface IConnectionStringProvider
    {
        string GetConnectionString();
        string GetIntegratedConnectionString();
    }
}