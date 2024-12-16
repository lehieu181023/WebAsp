using Microsoft.EntityFrameworkCore;
using WebAsp.Models;

namespace WebAsp.Data
{
    public class WebDbContext : DbContext
    {
        public WebDbContext(DbContextOptions<WebDbContext> options) : base(options) { }
        public DbSet<SinhVien> sinhvien { get; set; } = default!;
        public DbSet<Nganh> nganh { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.ToTable("qlsinhvien");

                entity.Property(e => e.IdSinhVien).HasColumnName("MASV");
                entity.Property(e => e.HoTen).HasColumnName("HOTEN");
                entity.Property(e => e.KhoaHoc).HasColumnName("khoahoc");
                entity.Property(e => e.NgaySinh).HasColumnName("NGAYSINH");
                entity.Property(e => e.GioiTinh).HasColumnName("GIOITINH");
                entity.Property(e => e.TBCHT).HasColumnName("TBCHT");
                entity.Property(e => e.Xeploai).HasColumnName("XEPLOAI");
                entity.Property(e => e.IdNganh).HasColumnName("MAK");

                entity.HasKey(e => e.IdSinhVien);

                entity.Property(e => e.KhoaHoc)
                    .HasMaxLength(20);
                entity.Property(e => e.HoTen)
                    .HasMaxLength(100);
                entity.Property(e => e.GioiTinh)
                    .HasMaxLength(10);
                entity.Property(e => e.Xeploai)
                    .HasMaxLength(20);
            });
            modelBuilder.Entity<Nganh>(entity =>
            {
                entity.ToTable("khoa");

                entity.Property(e => e.IdNganh).HasColumnName("MAK");
                entity.Property(e => e.Name).HasColumnName("TENK");

                entity.HasKey(e => e.IdNganh);

                entity.Property(e => e.Name).HasMaxLength(100);

            });
        }
        public DbSet<WebAsp.Models.qlmonhoc> qlmonhoc { get; set; } = default!;
    }
}
