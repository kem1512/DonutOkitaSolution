using Data.DomainClass;
using Data.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Data.Context
{
    public class DonutOkitaContext : DbContext
    {
        public DonutOkitaContext(DbContextOptions<DonutOkitaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.SeedData();
        }

        public DbSet<ChucVu>? ChucVu { get; set; }

        public DbSet<CuaHang>? CuaHang { get; set; }

        public DbSet<NhanVien>? NhanVien { get; set; }

        public DbSet<KhachHang>? KhachHang { get; set; }

        public DbSet<HoaDon>? HoaDon { get; set; }

        public DbSet<GioHang>? GioHang { get; set; }

        public DbSet<SanPham>? SanPham { get; set; }

        public DbSet<Nsx>? Nsx { get; set; }

        public DbSet<MauSac>? MauSac { get; set; }

        public DbSet<DongSp>? DongSp { get; set; }

        public DbSet<ChiTietSp>? ChiTietSp { get; set; }

        public DbSet<HoaDonChiTiet>? HoaDonChiTiet { get; set; }

        public DbSet<GioHangChiTiet>? GioHangChiTiet { get; set; }
    }
}
