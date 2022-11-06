using Data.DomainClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class HoaDonConfiguration : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.ToTable("HoaDon");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasDefaultValueSql("(NEWID())");

            builder.Property(c => c.Ma).HasColumnType("VARCHAR(20)");

            builder.Property(c => c.TinhTrang).HasDefaultValue(0);

            builder.Property(c => c.TenNguoiNhan).HasMaxLength(50).HasDefaultValue(null);

            builder.Property(c => c.NgayShip).HasDefaultValue(null);

            builder.Property(c => c.DiaChi).HasMaxLength(100).HasDefaultValue(null);

            builder.Property(c => c.Sdt).HasColumnType("VARCHAR").HasMaxLength(30).HasDefaultValue(null);

            builder.HasOne(c => c.KhachHang).WithMany(c => c.HoaDons).HasForeignKey(c => c.IdKh);

            builder.HasOne(c => c.NhanVien).WithMany(c => c.HoaDons).HasForeignKey(c => c.IdNv);
        }
    }
}
