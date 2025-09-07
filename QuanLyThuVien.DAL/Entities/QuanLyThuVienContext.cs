using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Protocols;

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

        public virtual DbSet<BaoCaoPhat> BaoCaoPhat { get; set; }
        public virtual DbSet<DanhSachSachDangMuon> DanhSachSachDangMuon { get; set; }
        public virtual DbSet<MuonSach> MuonSach { get; set; }
        public virtual DbSet<NhaXuatBan> NhaXuatBan { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<Phat> Phat { get; set; }
        public virtual DbSet<Sach> Sach { get; set; }
        public virtual DbSet<TacGia> TacGia { get; set; }
        public virtual DbSet<ThanhVien> ThanhVien { get; set; }
        public virtual DbSet<TheLoai> TheLoai { get; set; }

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Read connection string from app.config
            var connectionString = ConfigurationManager.ConnectionStrings["QuanLyThuVienConnectionString"].ConnectionString;
        optionsBuilder.UseSqlServer(connectionString);
        }
}

protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<DanhSachSachDangMuon>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DanhSachSachDangMuon");

                entity.Property(e => e.NgayMuon).HasColumnType("date");

                entity.Property(e => e.NgayTraDuKien).HasColumnType("date");

                entity.Property(e => e.TenSach)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.TenThanhVien)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<MuonSach>(entity =>
            {
                entity.HasKey(e => e.MaMuonSach)
                    .HasName("PK__MuonSach__DCE29B5CC23DDAD0");

                entity.HasIndex(e => e.NgayMuon)
                    .HasName("IDX_MuonSach_NgayMuon");

                entity.Property(e => e.NgayMuon)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NgayTraDuKien).HasColumnType("date");

                entity.Property(e => e.NgayTraThucTe).HasColumnType("date");

                entity.Property(e => e.TrangThai)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('DangMuon')");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.MuonSach)
                    .HasForeignKey(d => d.MaNhanVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MuonSach_NhanVien");

                entity.HasOne(d => d.MaSachNavigation)
                    .WithMany(p => p.MuonSach)
                    .HasForeignKey(d => d.MaSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MuonSach_Sach");

                entity.HasOne(d => d.MaThanhVienNavigation)
                    .WithMany(p => p.MuonSach)
                    .HasForeignKey(d => d.MaThanhVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MuonSach_ThanhVien");
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

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien)
                    .HasName("PK__NhanVien__77B2CA475BCCA911");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__NhanVien__A9D10534C644F99C")
                    .IsUnique();

                entity.Property(e => e.ChucVu)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TenNhanVien)
                    .IsRequired()
                    .HasMaxLength(100);
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
                    .HasConstraintName("FK_Phat_MuonSach");
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

                entity.Property(e => e.SoDienThoai).HasMaxLength(20);

                entity.Property(e => e.TenThanhVien)
                    .IsRequired()
                    .HasMaxLength(100);
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
