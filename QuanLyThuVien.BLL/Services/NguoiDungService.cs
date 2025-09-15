using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BLL.Services
{
    public class NguoiDungService
    {
        private readonly IGenericRepository<Users> _repository;
        public NguoiDungService(IGenericRepository<Users> repository)
        {
            _repository = repository;
        }
        public IEnumerable<Users> GetAllUsers()
        {
            return _repository.GetAll();
        }

        public void AddUser(Users user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "Người dùng không được để null");
           
            _repository.Insert(user);
            _repository.Save();
        }
        public void UpdateUser(Users user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "Người dùng không được để null");
            var existingUser = _repository.GetById(user.UserId);
            if (existingUser == null)
                throw new InvalidOperationException("Người dùng không tồn tại");
            existingUser.UserName = user.UserName;
            existingUser.FullName = user.FullName;
            existingUser.PasswordHash = user.PasswordHash;
            existingUser.Email = user.Email;
            existingUser.RoleId = user.RoleId; 
            existingUser.IsActive = user.IsActive;
            _repository.Update(existingUser);
            _repository.Save();
        }
        public void DeleteUser(int userId)
        {
            var existingUser = _repository.GetById(userId);
            if (existingUser == null)
                throw new InvalidOperationException("Người dùng không tồn tại");
            _repository.Delete(userId);
            _repository.Save();
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
