using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Antares.Essentials.Data.TypeBuilders;
using Mica.Domain.Data.Models.Inventory;

namespace Mica.Domain.Data.TypeBuilders.Inventory
{
    public class MaterialType : EntityTypeConfiguration<MaterialEntity, long>
    {
        public override void Configure(EntityTypeBuilder<MaterialEntity> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Code)
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);
            builder
                .HasIndex(b => b.Code)
                .IsUnique();

            builder.Property(c => c.Name)
                .HasColumnType("nvarchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.Description)
               .HasColumnType("nvarchar(1000)")
               .HasMaxLength(1000);

            builder.Property(c => c.Unit)
               .HasColumnType("nvarchar(255)")
               .HasMaxLength(255)
               .IsRequired();
            builder.Property(c => c.UnitPrice)
               .HasColumnType("decimal(12, 2)");

            builder.Property(c => c.Active)
               .HasColumnType("bit")
               .IsRequired();
        }
    }
}
