using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Antares.Essentials.Data.TypeBuilders;
using Mica.Domain.Data.Models.Effort;

namespace Mica.Domain.Data.TypeBuilders.Effort
{
    public class EffortType : EntityTypeConfiguration<EffortEntity, long>
    {
        public override void Configure(EntityTypeBuilder<EffortEntity> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name)
                .HasColumnType("nvarchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.Description)
               .HasColumnType("nvarchar(1000)")
               .HasMaxLength(1000);

            builder.Property(c => c.UnitPrice)
               .HasColumnType("decimal(12, 2)");

            builder.Property(c => c.Active)
               .HasColumnType("bit")
               .IsRequired();
        }
    }
}
