using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mica.Domain.Data.Models.Inventory;

namespace Mica.Domain.Data.TypeBuilders.Inventory
{
    public class InventoryOperationType : AuditableTypeConfiguration<InventoryOperationEntity, long>
    {
        public override void Configure(EntityTypeBuilder<InventoryOperationEntity> builder)
        {
            base.Configure(builder);

            builder.HasOne(m => m.Inventory)
                .WithMany()
                .HasForeignKey(m => m.InventoryId);

            builder.HasOne(m => m.Ticket)
                .WithMany()
                .HasForeignKey(m => m.TicketId);

            builder.Property(c => c.Description)
               .HasColumnType("nvarchar(1000)")
               .HasMaxLength(1000);

            builder.Property(c => c.Quantity)
               .HasColumnType("bigint");
        }
    }
}
