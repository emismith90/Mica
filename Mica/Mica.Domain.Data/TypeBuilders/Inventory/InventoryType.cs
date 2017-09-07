using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Antares.Essentials.Data.TypeBuilders;
using Mica.Domain.Data.Models.Inventory;

namespace Mica.Domain.Data.TypeBuilders.Inventory
{
    public class InventoryType : EntityTypeConfiguration<InventoryEntity, long>
    {
        public override void Configure(EntityTypeBuilder<InventoryEntity> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.InStock)
                .HasColumnType("decimal(12, 2)")
                .IsRequired();

            builder.HasOne(m => m.Material)
                .WithMany()
                .HasForeignKey(m => m.MaterialId)
                .IsRequired();
            builder
                .HasIndex(b => b.MaterialId)
                .IsUnique();
        }
    }
}
