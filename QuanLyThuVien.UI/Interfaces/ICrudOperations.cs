using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.UI.Interfaces
{
    public interface ICrudOperations
    {
        void Add();
        void Edit();
        void Delete();
        void Save();
        void Cancel();
        void RefreshData();

    }
}
