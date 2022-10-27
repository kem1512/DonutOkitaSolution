using Data.DomainClass;
using Microsoft.EntityFrameworkCore;

namespace Data.Extensions
{
    public static class DonutOkitaData
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChucVu>().HasData(
                new ChucVu()
                {
                    Id = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a7"),
                    Ma = "NV1",
                    Ten = "Trần Nam"
                }
            );
            modelBuilder.Entity<CuaHang>().HasData(
                new CuaHang()
                {
                    Id = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a8"),
                    Ma = "CH1",
                    Ten = "Minky Store"
                }
            );
            modelBuilder.Entity<NhanVien>().HasData(
                new NhanVien()
                {
                    Id = Guid.NewGuid(),
                    Ma = "NV1",
                    Ten = "Đăng",
                    Ho = "Nguyễn",
                    TenDem = "Viết Hải",
                    NgaySinh = DateTime.Now,
                    GioiTinh = "Nam",
                    DiaChi = "Hà Nội",
                    MatKhau = "1234",
                    Sdt = "1234",
                    TrangThai = 0,
                    IdCh = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a8"),
                    IdCv = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a7")
                }
            );
            modelBuilder.Entity<DongSp>().HasData(
                new DongSp()
                {
                    Id = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a1"),
                    Ma = "DSP1",
                    Ten = "Iphone"
                }
            );
            modelBuilder.Entity<MauSac>().HasData(
                new MauSac()
                {
                    Id = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a2"),
                    Ma = "MS1",
                    Ten = "Đỏ"
                },
                new MauSac()
                {
                    Id = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a8"),
                    Ma = "MS1",
                    Ten = "Vàng"
                },
                new MauSac()
                {
                    Id = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a9"),
                    Ma = "MS1",
                    Ten = "Tím"
                },
                new MauSac()
                {
                    Id = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a5"),
                    Ma = "MS1",
                    Ten = "Trắng"
                },
                new MauSac()
                {
                    Id = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a6"),
                    Ma = "MS1",
                    Ten = "Đen"
                }
            );
            modelBuilder.Entity<Nsx>().HasData(
                new Nsx()
                {
                    Id = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a3"),
                    Ma = "DSP1",
                    Ten = "Apple"
                }
            );
            modelBuilder.Entity<SanPham>().HasData(
                new SanPham()
                {
                    Id = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a4"),
                    Ma = "SP1",
                    Ten = "Iphone 13 Promax"
                }
            );
            modelBuilder.Entity<ChiTietSp>().HasData(
                new ChiTietSp()
                {
                    Id = Guid.NewGuid(),
                    IdDongSp = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a1"),
                    IdMauSac = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a2"),
                    IdNsx = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a3"),
                    IdSp = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a4"),
                    Anh = "https://cdn.tgdd.vn/Products/Images/42/247364/samsung-galaxy-m53-nau-thumb-600x600.jpg",
                    MoTa = "",
                    SoLuongTon = 50,
                    NamBh = 2002,
                    GiaBan = 200000,
                    GiaNhap = 900000,
                },
                new ChiTietSp()
                {
                    Id = Guid.NewGuid(),
                    IdDongSp = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a1"),
                    IdMauSac = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a8"),
                    IdNsx = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a3"),
                    IdSp = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a4"),
                    Anh = "https://cdn.tgdd.vn/Products/Images/42/230529/TimerThumb/iphone-13-pro-max-(18).jpg",
                    MoTa = "",
                    SoLuongTon = 50,
                    NamBh = 2002,
                    GiaBan = 200000,
                    GiaNhap = 900000,
                },
                new ChiTietSp()
                {
                    Id = Guid.NewGuid(),
                    IdDongSp = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a1"),
                    IdMauSac = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a9"),
                    IdNsx = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a3"),
                    IdSp = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a4"),
                    Anh = "https://cdn.tgdd.vn/Products/Images/42/251703/oppo-a95-4g-bac-2-600x600.jpg",
                    MoTa = "",
                    SoLuongTon = 50,
                    NamBh = 2002,
                    GiaBan = 200000,
                    GiaNhap = 900000,
                },
                new ChiTietSp()
                {
                    Id = Guid.NewGuid(),
                    IdDongSp = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a1"),
                    IdMauSac = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a9"),
                    IdNsx = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a3"),
                    IdSp = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a4"),
                    Anh = "https://cdn.tgdd.vn/Products/Images/42/253402/realme-c21-y-blue-600x600.jpg",
                    MoTa = "",
                    SoLuongTon = 50,
                    NamBh = 2002,
                    GiaBan = 200000,
                    GiaNhap = 900000,
                },
                new ChiTietSp()
                {
                    Id = Guid.NewGuid(),
                    IdDongSp = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a1"),
                    IdMauSac = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a5"),
                    IdNsx = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a3"),
                    IdSp = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a4"),
                    Anh = "https://cdn.tgdd.vn/Products/Images/42/247364/samsung-galaxy-m53-nau-thumb-600x600.jpg",
                    MoTa = "",
                    SoLuongTon = 50,
                    NamBh = 2002,
                    GiaBan = 200000,
                    GiaNhap = 900000,
                },
                new ChiTietSp()
                {
                    Id = Guid.NewGuid(),
                    IdDongSp = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a1"),
                    IdMauSac = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a6"),
                    IdNsx = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a3"),
                    IdSp = Guid.Parse("b29ceea6-16a5-4171-9486-621650b569a4"),
                    Anh = "https://cdn.tgdd.vn/Products/Images/42/247364/samsung-galaxy-m53-nau-thumb-600x600.jpg",
                    MoTa = "",
                    SoLuongTon = 50,
                    NamBh = 2002,
                    GiaBan = 200000,
                    GiaNhap = 900000,
                }
            );
            modelBuilder.Entity<KhachHang>().HasData(
                new KhachHang()
                {
                    Id = Guid.NewGuid(),
                    Ma = "KH1",
                    Ten = "Ánh"
                }
            );
        }
    }
}
