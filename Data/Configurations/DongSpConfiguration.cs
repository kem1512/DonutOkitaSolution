using Data.DomainClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class DongSpConfiguration : IEntityTypeConfiguration<DongSp>
    {
        public void Configure(EntityTypeBuilder<DongSp> builder)
        {
            builder.ToTable("DongSp");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasDefaultValueSql("(NEWID())");

            builder.Property(c => c.Ma).HasColumnType("VARCHAR(20)");

            builder.Property(c => c.Ten).HasMaxLength(30).HasDefaultValue(null);
        }
    }
}
