using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BLL.Services
{
    public class NguoiDungService
    {
        private readonly IGenericRepository<Users> _repository;
        private readonly string _connectionString;
        
        public NguoiDungService(IGenericRepository<Users> repository)
        {
            _repository = repository;
            _connectionString = ConfigurationManager.ConnectionStrings["QuanLyThuVienConnectionString"].ConnectionString;
        }
        
        public IEnumerable<Users> GetAllUsers()
        {
            using (var newContext = new QuanLyThuVienContext())
            {
                var users = newContext.Users.ToList();
                var roles = newContext.Roles.ToList();
                
                foreach (var user in users)
                {
                    if (user.RoleId.HasValue)
                    {
                        user.Role = roles.FirstOrDefault(r => r.RoleId == user.RoleId.Value);
                    }
                }
                
                return users;
            }
        }

        public void AddUser(string userName, string fullName, string passwordHash, string email = null, 
                           int? roleId = null, bool isActive = true, DateTime? createdAt = null)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException("Tên người dùng không được để trống", nameof(userName));
            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("Mật khẩu không được để trống", nameof(passwordHash));

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("[dbo].[ThemUsers]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 60;

                    command.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = userName;
                    command.Parameters.Add("@FullName", SqlDbType.NVarChar, 200).Value = 
                        string.IsNullOrWhiteSpace(fullName) ? (object)DBNull.Value : fullName;
                    command.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 300).Value = passwordHash;
                    command.Parameters.Add("@Email", SqlDbType.NVarChar, 200).Value = 
                        string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email;
                    command.Parameters.Add("@RoleID", SqlDbType.Int).Value = 
                        roleId.HasValue ? (object)roleId.Value : DBNull.Value;
                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = isActive;
                    command.Parameters.Add("@CreatedAt", SqlDbType.DateTime).Value = 
                        createdAt.HasValue ? (object)createdAt.Value : DBNull.Value;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        
        public void UpdateUser(int userId, string userName, string fullName, string passwordHash, string email = null, 
                              int? roleId = null, bool isActive = true)
        {
            if (userId <= 0)
                throw new ArgumentException("ID người dùng không hợp lệ", nameof(userId));
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException("Tên người dùng không được để trống", nameof(userName));
            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("Mật khẩu không được để trống", nameof(passwordHash));

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("[dbo].[SuaUsers]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 60;

                    command.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
                    command.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = userName;
                    command.Parameters.Add("@FullName", SqlDbType.NVarChar, 200).Value = 
                        string.IsNullOrWhiteSpace(fullName) ? (object)DBNull.Value : fullName;
                    command.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 300).Value = passwordHash;
                    command.Parameters.Add("@Email", SqlDbType.NVarChar, 200).Value = 
                        string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email;
                    command.Parameters.Add("@RoleID", SqlDbType.Int).Value = 
                        roleId.HasValue ? (object)roleId.Value : DBNull.Value;
                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = isActive;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        
        public void DeleteUser(int userId)
        {
            if (userId <= 0)
                throw new ArgumentException("ID người dùng không hợp lệ", nameof(userId));

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("[dbo].[XoaUsers]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 60;

                    command.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool checkUserExist(string username)
        {
            var user = _repository.GetAll().FirstOrDefault(u => u.UserName == username);
            return user != null;
        }
        
        public Users GetUserById(int userId)
        {
            return _repository.GetById(userId);
        }
    }
}
