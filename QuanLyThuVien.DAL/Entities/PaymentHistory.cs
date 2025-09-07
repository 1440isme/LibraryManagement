using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLyThuVien.DAL.Entities
{
    public partial class PaymentHistory
    {
        public int MaPayment { get; set; }
        public int? MaPhat { get; set; }
        public int? MaThanhVien { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Method { get; set; }
        public string Note { get; set; }

        public virtual Phat MaPhatNavigation { get; set; }
        public virtual ThanhVien MaThanhVienNavigation { get; set; }
    }
}
