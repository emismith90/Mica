using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mica.Domain.Data.Models.Inventory;

namespace Mica.Domain.Data.TypeBuilders.Inventory
{
    public class InventoryType : EntityTypeConfiguration<InventoryEntity, long>
    {
        public override void Configure(EntityTypeBuilder<InventoryEntity> builder)
        {
            base.Configure(builder);

            builder.HasOne(m => m.MaterialVariant)
              .WithMany()
              .HasForeignKey(m => m.Id);

            builder.Property(c => c.InStock)
               .HasColumnType("bigint");
        }
    }
}
