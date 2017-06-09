using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mica.Domain.Data.Models;

namespace Mica.Domain.Data.TypeBuilders
{
    public class MaterialType : EntityTypeConfiguration<MaterialEntity, long>
    {
        public override void Configure(EntityTypeBuilder<MaterialEntity> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name)
                .HasColumnType("nvarchar(255)")
                .HasMaxLength(255);
            builder.Property(c => c.Description)
               .HasColumnType("nvarchar(1000)")
               .HasMaxLength(1000);

            builder.Property(c => c.Unit)
               .HasColumnType("nvarchar(255)")
               .HasMaxLength(255);
            builder.Property(c => c.UnitPrice)
               .HasColumnType("decimal(10, 0)");
        }
    }
}
