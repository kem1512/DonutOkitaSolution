using Data.DomainClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class HoaDonChiTietConfiguration : IEntityTypeConfiguration<HoaDonChiTiet>
    {
        public void Configure(EntityTypeBuilder<HoaDonChiTiet> builder)
        {
            builder.ToTable("HoaDonChiTiet");

            builder.HasKey(c => new { c.IdHoaDon, c.IdChiTietSp });

            builder.Property(c => c.DonGia).HasColumnType("DECIMAL(20,0)").HasDefaultValue(0);

            builder.HasOne(c => c.HoaDon).WithMany(c => c.HoaDonChiTiets).HasForeignKey(c => c.IdHoaDon);

            builder.HasOne(c => c.ChiTietSp).WithMany(c => c.HoaDonChiTiets).HasForeignKey(c => c.IdChiTietSp);
        }
    }
}
