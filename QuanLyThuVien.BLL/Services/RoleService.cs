using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BLL.Services
{
    public class RoleService
    {
        private readonly IGenericRepository<Roles> _repository;
        
        public RoleService(IGenericRepository<Roles> repository)
        {
            _repository = repository;
        }
        
        public IEnumerable<Roles> GetAllRoles()
        {
            using (var newContext = ContextFactory.CreateContext())
            {
                return newContext.Roles.ToList();
            }
        }
    }
}
