using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BLL.Services
{
    public class PhatService
    {
        private readonly IGenericRepository<Phat> _repository;
        private readonly IGenericRepository<ChiTietPhieuMuon> _chiTietRepository;
        private readonly string _connectionString = ConnectionStringProvider.GetConnectionString();


        public PhatService(IGenericRepository<Phat> repository)
        {
            _repository = repository;
        }

        public PhatService(IGenericRepository<Phat> repository, IGenericRepository<ChiTietPhieuMuon> chiTietRepository)
        {
            _repository = repository;
            _chiTietRepository = chiTietRepository;
        }

        public IEnumerable<Phat> GetAllPhat()
        {
            return _repository.GetAll();
        }

        public IEnumerable<PhatWithDetailInfo> GetAllPhatWithDetails()
        {
            if (_chiTietRepository == null)
                throw new InvalidOperationException("ChiTietPhieuMuon repository is required for this operation. Use the appropriate constructor.");

            var phatList = GetAllPhat().ToList();
            var chiTietRepo = _chiTietRepository as GenericRepository<ChiTietPhieuMuon>;
            
            IEnumerable<ChiTietPhieuMuon> chiTietList;
            if (chiTietRepo != null)
            {
                chiTietList = chiTietRepo.GetAllIncluding(
                    ctp => ctp.MaPhieuMuonNavigation,
                    ctp => ctp.MaPhieuMuonNavigation.MaThanhVienNavigation,
                    ctp => ctp.MaSachNavigation,
                    ctp => ctp.MaBanSaoNavigation
                );
            }
            else
            {
                chiTietList = _chiTietRepository.GetAll();
            }

            return phatList.Select(phat => new PhatWithDetailInfo
            {
                MaPhat = phat.MaPhat,
                MaMuonSach = phat.MaMuonSach,
                SoTien = phat.SoTien,
                LyDo = phat.LyDo,
                NgayPhat = phat.NgayPhat,
                TrangThai = phat.TrangThai,
                Barcode = GetBarcodeByMaMuonSach(phat.MaMuonSach, chiTietList),
                TenSach = GetTenSachByMaMuonSach(phat.MaMuonSach, chiTietList),
                MaThanhVien = GetMaThanhVienByMaMuonSach(phat.MaMuonSach, chiTietList),
                TenThanhVien = GetTenThanhVienByMaMuonSach(phat.MaMuonSach, chiTietList)
            });
        }

        public string GetBarcodeByMaMuonSach(int maMuonSach)
        {
            if (_chiTietRepository == null)
                throw new InvalidOperationException("ChiTietPhieuMuon repository is required for this operation.");

            try
            {
                var chiTietRepo = _chiTietRepository as GenericRepository<ChiTietPhieuMuon>;
                IEnumerable<ChiTietPhieuMuon> chiTietList;
                
                if (chiTietRepo != null)
                {
                    chiTietList = chiTietRepo.GetAllIncluding(ctp => ctp.MaBanSaoNavigation);
                }
                else
                {
                    chiTietList = _chiTietRepository.GetAll();
                }

                var chiTiet = chiTietList.FirstOrDefault(ct => ct.MaChiTiet == maMuonSach);
                return chiTiet?.MaBanSaoNavigation?.Barcode ?? "N/A";
            }
            catch
            {
                return "N/A";
            }
        }

        public string GetTenSachByMaMuonSach(int maMuonSach)
        {
            if (_chiTietRepository == null)
                throw new InvalidOperationException("ChiTietPhieuMuon repository is required for this operation.");

            try
            {
                var chiTietRepo = _chiTietRepository as GenericRepository<ChiTietPhieuMuon>;
                IEnumerable<ChiTietPhieuMuon> chiTietList;
                
                if (chiTietRepo != null)
                {
                    chiTietList = chiTietRepo.GetAllIncluding(ctp => ctp.MaSachNavigation);
                }
                else
                {
                    chiTietList = _chiTietRepository.GetAll();
                }

                var chiTiet = chiTietList.FirstOrDefault(ct => ct.MaChiTiet == maMuonSach);
                return chiTiet?.MaSachNavigation?.TenSach ?? "N/A";
            }
            catch
            {
                return "N/A";
            }
        }

        public int GetMaThanhVienByMaMuonSach(int maMuonSach)
        {
            if (_chiTietRepository == null)
                throw new InvalidOperationException("ChiTietPhieuMuon repository is required for this operation.");

            try
            {
                var chiTietRepo = _chiTietRepository as GenericRepository<ChiTietPhieuMuon>;
                IEnumerable<ChiTietPhieuMuon> chiTietList;
                
                if (chiTietRepo != null)
                {
                    chiTietList = chiTietRepo.GetAllIncluding(ctp => ctp.MaPhieuMuonNavigation);
                }
                else
                {
                    chiTietList = _chiTietRepository.GetAll();
                }

                var chiTiet = chiTietList.FirstOrDefault(ct => ct.MaChiTiet == maMuonSach);
                return chiTiet?.MaPhieuMuonNavigation?.MaThanhVien ?? 0;
            }
            catch
            {
                return 0;
            }
        }

        public string GetTenThanhVienByMaMuonSach(int maMuonSach)
        {
            if (_chiTietRepository == null)
                throw new InvalidOperationException("ChiTietPhieuMuon repository is required for this operation.");

            try
            {
                var chiTietRepo = _chiTietRepository as GenericRepository<ChiTietPhieuMuon>;
                IEnumerable<ChiTietPhieuMuon> chiTietList;
                
                if (chiTietRepo != null)
                {
                    chiTietList = chiTietRepo.GetAllIncluding(
                        ctp => ctp.MaPhieuMuonNavigation,
                        ctp => ctp.MaPhieuMuonNavigation.MaThanhVienNavigation
                    );
                }
                else
                {
                    chiTietList = _chiTietRepository.GetAll();
                }

                var chiTiet = chiTietList.FirstOrDefault(ct => ct.MaChiTiet == maMuonSach);
                return chiTiet?.MaPhieuMuonNavigation?.MaThanhVienNavigation?.TenThanhVien ?? "N/A";
            }
            catch
            {
                return "N/A";
            }
        }

        public PhatDetailInfo GetPhatDetailInfo(int maMuonSach)
        {
            if (_chiTietRepository == null)
                throw new InvalidOperationException("ChiTietPhieuMuon repository is required for this operation.");

            try
            {
                var chiTietRepo = _chiTietRepository as GenericRepository<ChiTietPhieuMuon>;
                IEnumerable<ChiTietPhieuMuon> chiTietList;
                
                if (chiTietRepo != null)
                {
                    chiTietList = chiTietRepo.GetAllIncluding(
                        ctp => ctp.MaPhieuMuonNavigation,
                        ctp => ctp.MaPhieuMuonNavigation.MaThanhVienNavigation,
                        ctp => ctp.MaSachNavigation,
                        ctp => ctp.MaBanSaoNavigation
                    );
                }
                else
                {
                    chiTietList = _chiTietRepository.GetAll();
                }

                var chiTiet = chiTietList.FirstOrDefault(ct => ct.MaChiTiet == maMuonSach);

                if (chiTiet != null)
                {
                    return new PhatDetailInfo
                    {
                        Barcode = chiTiet.MaBanSaoNavigation?.Barcode ?? "N/A",
                        TenSach = chiTiet.MaSachNavigation?.TenSach ?? "N/A",
                        MaThanhVien = chiTiet.MaPhieuMuonNavigation?.MaThanhVien ?? 0,
                        TenThanhVien = chiTiet.MaPhieuMuonNavigation?.MaThanhVienNavigation?.TenThanhVien ?? "N/A"
                    };
                }
            }
            catch
            {
            }

            return new PhatDetailInfo
            {
                Barcode = "N/A",
                TenSach = "N/A",
                MaThanhVien = 0,
                TenThanhVien = "N/A"
            };
        }

        private string GetBarcodeByMaMuonSach(int maMuonSach, IEnumerable<ChiTietPhieuMuon> chiTietList)
        {
            try
            {
                var chiTiet = chiTietList.FirstOrDefault(ct => ct.MaChiTiet == maMuonSach);
                return chiTiet?.MaBanSaoNavigation?.Barcode ?? "N/A";
            }
            catch
            {
                return "N/A";
            }
        }

        private string GetTenSachByMaMuonSach(int maMuonSach, IEnumerable<ChiTietPhieuMuon> chiTietList)
        {
            try
            {
                var chiTiet = chiTietList.FirstOrDefault(ct => ct.MaChiTiet == maMuonSach);
                return chiTiet?.MaSachNavigation?.TenSach ?? "N/A";
            }
            catch
            {
                return "N/A";
            }
        }

        private int GetMaThanhVienByMaMuonSach(int maMuonSach, IEnumerable<ChiTietPhieuMuon> chiTietList)
        {
            try
            {
                var chiTiet = chiTietList.FirstOrDefault(ct => ct.MaChiTiet == maMuonSach);
                return chiTiet?.MaPhieuMuonNavigation?.MaThanhVien ?? 0;
            }
            catch
            {
                return 0;
            }
        }

        private string GetTenThanhVienByMaMuonSach(int maMuonSach, IEnumerable<ChiTietPhieuMuon> chiTietList)
        {
            try
            {
                var chiTiet = chiTietList.FirstOrDefault(ct => ct.MaChiTiet == maMuonSach);
                return chiTiet?.MaPhieuMuonNavigation?.MaThanhVienNavigation?.TenThanhVien ?? "N/A";
            }
            catch
            {
                return "N/A";
            }
        }
    }

    public class PhatDetailInfo
    {
        public string Barcode { get; set; }
        public string TenSach { get; set; }
        public int MaThanhVien { get; set; }
        public string TenThanhVien { get; set; }
    }

    public class PhatWithDetailInfo
    {
        public int MaPhat { get; set; }
        public int MaMuonSach { get; set; }
        public decimal SoTien { get; set; }
        public string LyDo { get; set; }
        public DateTime NgayPhat { get; set; }
        public string TrangThai { get; set; }
        public string Barcode { get; set; }
        public string TenSach { get; set; }
        public int MaThanhVien { get; set; }
        public string TenThanhVien { get; set; }
    }
}
