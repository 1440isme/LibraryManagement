using System;

namespace QuanLyThuVien.UI.Interfaces
{
    public interface IActivatable
    {
        void OnActivated();
        void OnDeactivated();
        bool IsDataLoaded { get; }
    }
}