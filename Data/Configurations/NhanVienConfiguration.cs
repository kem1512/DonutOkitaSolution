using Data.DomainClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class NhanVienConfiguration : IEntityTypeConfiguration<NhanVien>
    {
        public void Configure(EntityTypeBuilder<NhanVien> builder)
        {
            builder.ToTable("NhanVien");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasDefaultValueSql("(NEWID())");

            builder.Property(c => c.Ma).HasColumnType("VARCHAR(20)");

            builder.Property(c => c.Ten).HasMaxLength(30).HasDefaultValue(null);

            builder.Property(c => c.TenDem).HasMaxLength(30).HasDefaultValue(null);

            builder.Property(c => c.Ho).HasMaxLength(30).HasDefaultValue(null);

            builder.Property(c => c.GioiTinh).HasMaxLength(10).HasDefaultValue(null);

            builder.Property(c => c.NgaySinh).HasColumnType("DATE").HasDefaultValue(null);

            builder.Property(c => c.DiaChi).HasMaxLength(100).HasDefaultValue(null);

            builder.Property(c => c.Sdt).HasColumnType("VARCHAR").HasMaxLength(30).HasDefaultValue(null);

            builder.Property(c => c.MatKhau).HasColumnType("VARCHAR(MAX)").HasDefaultValue(null);

            builder.Property(c => c.TrangThai).HasDefaultValue(0);

            builder.HasOne(c => c.CuaHang).WithMany(c => c.NhanViens).HasForeignKey(c => c.IdCh);

            builder.HasOne(c => c.ChucVu).WithMany(c => c.NhanViens).HasForeignKey(c => c.IdCv);

            builder.HasOne(c => c.Nhan_Vien).WithMany(c => c.NhanViens).HasForeignKey(c => c.IdGuiBc);
        }
    }
}
