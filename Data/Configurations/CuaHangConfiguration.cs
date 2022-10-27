using Data.DomainClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class CuaHangConfiguration : IEntityTypeConfiguration<CuaHang>
    {
        public void Configure(EntityTypeBuilder<CuaHang> builder)
        {
            builder.ToTable("CuaHang");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasDefaultValueSql("(NEWID())");

            builder.Property(c => c.Ma).HasColumnType("VARCHAR(20)").HasMaxLength(20);

            builder.Property(c => c.Ten).HasMaxLength(50).HasDefaultValue(null);

            builder.Property(c => c.DiaChi).HasMaxLength(100).HasDefaultValue(null);

            builder.Property(c => c.ThanhPho).HasMaxLength(50).HasDefaultValue(null);

            builder.Property(c => c.QuocGia).HasMaxLength(50).HasDefaultValue(null);
        }
    }
}
