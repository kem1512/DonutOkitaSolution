using Data.DomainClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ChiTietSpConfiguration : IEntityTypeConfiguration<ChiTietSp>
    {
        public void Configure(EntityTypeBuilder<ChiTietSp> builder)
        {
            builder.ToTable("ChiTietSp");

            builder.HasKey(t => t.Id);

            builder.Property(c => c.Id).HasDefaultValueSql("(NEWID())");

            builder.Property(c => c.MoTa).HasMaxLength(50);

            builder.Property(c => c.GiaNhap).HasDefaultValue(0);

            builder.Property(c => c.GiaBan).HasDefaultValue(0);

            builder.Property(c => c.NamBh).HasDefaultValue(null);

            builder.Property(c => c.MoTa).HasMaxLength(50).HasDefaultValue(null);

            builder.Property(c => c.GiaNhap).HasColumnType("DECIMAL(20,0)").HasDefaultValue(0);

            builder.Property(c => c.GiaBan).HasColumnType("DECIMAL(20,0)").HasDefaultValue(0);

            builder.HasOne(c => c.SanPham).WithMany(c => c.ChiTietSps).HasForeignKey(c => c.IdSp);

            builder.HasOne(c => c.Nsx).WithMany(c => c.ChiTietSps).HasForeignKey(c => c.IdNsx);

            builder.HasOne(c => c.MauSac).WithMany(c => c.ChiTietSps).HasForeignKey(c => c.IdMauSac);

            builder.HasOne(c => c.DongSp).WithMany(c => c.ChiTietSps).HasForeignKey(c => c.IdDongSp);
        }
    }
}
