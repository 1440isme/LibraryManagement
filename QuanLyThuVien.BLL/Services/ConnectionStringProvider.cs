using System;
using System.Configuration;

namespace QuanLyThuVien.BLL.Services
{
    public static class ConnectionStringProvider
    {
        private static string _currentConnectionString;

        public static void SetConnectionString(string connectionString)
        {
            _currentConnectionString = connectionString;
        }

        public static string GetConnectionString()
        {
            if (!string.IsNullOrEmpty(_currentConnectionString))
            {
                return _currentConnectionString;
            }

            return GetIntegratedConnectionString() ?? GetDefaultConnectionString();
        }

        public static string GetIntegratedConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["QuanLyThuVien_Integrated"]?.ConnectionString;
        }

        public static string GetDefaultConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["QuanLyThuVienConnectionString"]?.ConnectionString;
        }

        public static void Clear()
        {
            _currentConnectionString = null;
        }
    }
}
