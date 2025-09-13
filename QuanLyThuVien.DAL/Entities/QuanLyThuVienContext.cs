using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLyThuVien.DAL.Entities
{
    public partial class QuanLyThuVienContext : DbContext
    {
        public QuanLyThuVienContext()
        {
        }

        public QuanLyThuVienContext(DbContextOptions<QuanLyThuVienContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuditLog> AuditLog { get; set; }
        public virtual DbSet<BanSaoSach> BanSaoSach { get; set; }
        public virtual DbSet<BaoCaoPhat> BaoCaoPhat { get; set; }
        public virtual DbSet<ChiTietPhieuMuon> ChiTietPhieuMuon { get; set; }
        public virtual DbSet<DanhSachSachDangMuon> DanhSachSachDangMuon { get; set; }
        public virtual DbSet<NhaXuatBan> NhaXuatBan { get; set; }
        public virtual DbSet<PaymentHistory> PaymentHistory { get; set; }
        public virtual DbSet<Phat> Phat { get; set; }
        public virtual DbSet<PhieuMuon> PhieuMuon { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Sach> Sach { get; set; }
        public virtual DbSet<SachQuaHan> SachQuaHan { get; set; }
        public virtual DbSet<TacGia> TacGia { get; set; }
        public virtual DbSet<ThanhVien> ThanhVien { get; set; }
        public virtual DbSet<ThanhVienBiKhoa> ThanhVienBiKhoa { get; set; }
        public virtual DbSet<TheLoai> TheLoai { get; set; }
        public virtual DbSet<TopSachMuon> TopSachMuon { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<ThongTinThanhVienProc> ThongTinThanhVien { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["QuanLyThuVienConnectionString"].ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__AuditLog__5E5499A8FB634555");

                entity.Property(e => e.LogId).HasColumnName("LogID");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EntityId)
                    .HasColumnName("EntityID")
                    .HasMaxLength(100);

                entity.Property(e => e.EntityName).HasMaxLength(100);

                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            modelBuilder.Entity<BanSaoSach>(entity =>
            {
                entity.HasKey(e => e.MaBanSao)
                    .HasName("PK__BanSaoSa__488BCC4231F3E572");

                entity.HasIndex(e => e.Barcode)
                    .HasName("UQ__BanSaoSa__177800D366BA4C4C")
                    .IsUnique();

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.GhiChu).HasMaxLength(500);

                entity.Property(e => e.NgayNhap)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.TinhTrang)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Sẵn sàng')");

                entity.Property(e => e.ViTri).HasMaxLength(100);

                entity.HasOne(d => d.MaSachNavigation)
                    .WithMany(p => p.BanSaoSach)
                    .HasForeignKey(d => d.MaSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BanSaoSach_Sach");
            });

            modelBuilder.Entity<BaoCaoPhat>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("BaoCaoPhat");

                entity.Property(e => e.LyDo)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SoTien).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TenThanhVien)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ChiTietPhieuMuon>(entity =>
            {
                entity.HasKey(e => e.MaChiTiet)
                    .HasName("PK__ChiTietP__CDF0A114C7D002CC");

                entity.HasIndex(e => e.MaBanSao)
                    .HasName("IX_CTPM_MaBanSao");

                entity.HasIndex(e => e.MaPhieuMuon)
                    .HasName("IX_CTPM_MaPhieuMuon");

                entity.Property(e => e.GhiChu).HasMaxLength(400);

                entity.Property(e => e.NgayTraDuKien).HasColumnType("datetime");

                entity.Property(e => e.NgayTraThucTe).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.TrangThai)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Đang mượn')");

                entity.HasOne(d => d.MaBanSaoNavigation)
                    .WithMany(p => p.ChiTietPhieuMuon)
                    .HasForeignKey(d => d.MaBanSao)
                    .HasConstraintName("FK_CTPM_BanSao");

                entity.HasOne(d => d.MaPhieuMuonNavigation)
                    .WithMany(p => p.ChiTietPhieuMuon)
                    .HasForeignKey(d => d.MaPhieuMuon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTPM_PhieuMuon");

                entity.HasOne(d => d.MaSachNavigation)
                    .WithMany(p => p.ChiTietPhieuMuon)
                    .HasForeignKey(d => d.MaSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTPM_Sach");
            });

            modelBuilder.Entity<DanhSachSachDangMuon>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DanhSachSachDangMuon");

                entity.Property(e => e.BarcodeOrSachId)
                    .HasColumnName("BarcodeOrSachID")
                    .HasMaxLength(100);

                entity.Property(e => e.NgayMuon).HasColumnType("datetime");

                entity.Property(e => e.NgayTraDuKien).HasColumnType("datetime");

                entity.Property(e => e.TenSach).HasMaxLength(200);

                entity.Property(e => e.TenThanhVien).HasMaxLength(100);
            });

            modelBuilder.Entity<NhaXuatBan>(entity =>
            {
                entity.HasKey(e => e.MaNhaXuatBan)
                    .HasName("PK__NhaXuatB__1AED0BFA3A64D234");

                entity.HasIndex(e => e.TenNhaXuatBan)
                    .HasName("UQ__NhaXuatB__5D1E72E2B342D5A4")
                    .IsUnique();

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.SoDienThoai).HasMaxLength(20);

                entity.Property(e => e.TenNhaXuatBan)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<PaymentHistory>(entity =>
            {
                entity.HasKey(e => e.MaPayment)
                    .HasName("PK__PaymentH__3622C2E93C8E6F17");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Method).HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.MaPhatNavigation)
                    .WithMany(p => p.PaymentHistory)
                    .HasForeignKey(d => d.MaPhat)
                    .HasConstraintName("FK_Pay_Phatt");

                entity.HasOne(d => d.MaThanhVienNavigation)
                    .WithMany(p => p.PaymentHistory)
                    .HasForeignKey(d => d.MaThanhVien)
                    .HasConstraintName("FK_Pay_ThanhVien");
            });

            modelBuilder.Entity<Phat>(entity =>
            {
                entity.HasKey(e => e.MaPhat)
                    .HasName("PK__Phat__4AC072E29DC0B58D");

                entity.Property(e => e.LyDo)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.NgayPhat)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SoTien).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TrangThai)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('ChuaThanhToan')");

                entity.HasOne(d => d.MaMuonSachNavigation)
                    .WithMany(p => p.Phat)
                    .HasForeignKey(d => d.MaMuonSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Phat_ChiTietPhieuMuon");
            });

            modelBuilder.Entity<PhieuMuon>(entity =>
            {
                entity.HasKey(e => e.MaPhieuMuon)
                    .HasName("PK__PhieuMuo__C4C8222280F89A44");

                entity.Property(e => e.GhiChu).HasMaxLength(400);

                entity.Property(e => e.NgayMuon)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.NgayTraDuKien).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.TrangThai)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Đang mượn')");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.MaThanhVienNavigation)
                    .WithMany(p => p.PhieuMuon)
                    .HasForeignKey(d => d.MaThanhVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhieuMuon_ThanhVien");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PhieuMuon)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhieuMuon_Users");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.MaReservation)
                    .HasName("PK__Reservat__A2929E45B9F29503");

                entity.HasIndex(e => e.MaSach);

                entity.Property(e => e.ExpireDate).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.RequestDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Waiting')");

                entity.HasOne(d => d.MaSachNavigation)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.MaSach)
                    .HasConstraintName("FK_Res_Sach");

                entity.HasOne(d => d.MaThanhVienNavigation)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.MaThanhVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Res_ThanhVien");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__Roles__8AFACE3A9408BDC0");

                entity.HasIndex(e => e.RoleName)
                    .HasName("UQ__Roles__8A2B616035685820")
                    .IsUnique();

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.MaSach)
                    .HasName("PK__Sach__B235742D1F7E95A9");

                entity.HasIndex(e => e.ISBN)
                    .HasName("IDX_Sach_ISBN");

                entity.HasIndex(e => e.TenSach)
                    .HasName("IDX_Sach_TenSach");

                entity.Property(e => e.Gia).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ISBN)
                    .IsRequired()
                    .HasColumnName("ISBN")
                    .HasMaxLength(13);

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.SoLuong).HasDefaultValueSql("((1))");

                entity.Property(e => e.TenSach)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.TrangThai)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.MaNhaXuatBanNavigation)
                    .WithMany(p => p.Sach)
                    .HasForeignKey(d => d.MaNhaXuatBan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sach_NhaXuatBan");

                entity.HasOne(d => d.MaTacGiaNavigation)
                    .WithMany(p => p.Sach)
                    .HasForeignKey(d => d.MaTacGia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sach_TacGia");

                entity.HasOne(d => d.MaTheLoaiNavigation)
                    .WithMany(p => p.Sach)
                    .HasForeignKey(d => d.MaTheLoai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sach_TheLoai");
            });

            modelBuilder.Entity<SachQuaHan>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SachQuaHan");

                entity.Property(e => e.NgayMuon).HasColumnType("datetime");

                entity.Property(e => e.NgayTraDuKien).HasColumnType("datetime");

                entity.Property(e => e.TenSach)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.TenThanhVien)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TacGia>(entity =>
            {
                entity.HasKey(e => e.MaTacGia)
                    .HasName("PK__TacGia__F24E675687133725");

                entity.Property(e => e.QuocTich).HasMaxLength(50);

                entity.Property(e => e.TenTacGia)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ThanhVien>(entity =>
            {
                entity.HasKey(e => e.MaThanhVien)
                    .HasName("PK__ThanhVie__2BE0A0F0D971B573");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__ThanhVie__A9D10534AD39C5D7")
                    .IsUnique();

                entity.Property(e => e.MaThanhVien).ValueGeneratedNever();

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LoaiThanhVien)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('SinhVien')");

                entity.Property(e => e.NgayDangKy)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.SoDienThoai).HasMaxLength(20);

                entity.Property(e => e.TenThanhVien)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ThanhVienBiKhoa>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ThanhVienBiKhoa");

                entity.Property(e => e.TenThanhVien)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TongNo).HasColumnType("decimal(38, 2)");
            });

            modelBuilder.Entity<TheLoai>(entity =>
            {
                entity.HasKey(e => e.MaTheLoai)
                    .HasName("PK__TheLoai__D73FF34AD8E7B3CD");

                entity.HasIndex(e => e.TenTheLoai)
                    .HasName("UQ__TheLoai__327F958FC387A009")
                    .IsUnique();

                entity.Property(e => e.MoTa).HasMaxLength(200);

                entity.Property(e => e.TenTheLoai)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TopSachMuon>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TopSachMuon");

                entity.Property(e => e.TenSach)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CCAC8AF0B8F9");

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__Users__C9F2845651241983")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.FullName).HasMaxLength(200);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Users_Roles");
            });
            modelBuilder.Entity<ThongTinThanhVienProc>().HasNoKey();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
