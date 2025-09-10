using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLyThuVien.DAL.Entities
{
    public partial class Users
    {
        public Users()
        {
            MuonSach = new HashSet<MuonSach>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? MaNhanVien { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<MuonSach> MuonSach { get; set; }
    }
}
