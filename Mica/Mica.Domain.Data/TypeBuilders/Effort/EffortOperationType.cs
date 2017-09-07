using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Antares.Essentials.Data.TypeBuilders;
using Mica.Domain.Data.Models.Effort;

namespace Mica.Domain.Data.TypeBuilders.Effort
{
    public class EffortOperationType : AuditableTypeConfiguration<EffortOperationEntity, long>
    {
        public override void Configure(EntityTypeBuilder<EffortOperationEntity> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Note)
               .HasColumnType("nvarchar(1000)")
               .HasMaxLength(1000);

            builder.Property(c => c.Quantity)
               .HasColumnType("decimal(12, 2)")
               .IsRequired();

            builder.Property(c => c.OperationDate)
              .HasColumnType("datetime")
              .IsRequired();

            builder.HasOne(m => m.Effort)
                .WithMany()
                .HasForeignKey(m => m.EffortId);
            builder.HasOne(m => m.Ticket)
                .WithMany()
                .HasForeignKey(m => m.TicketId);
        }
    }
}
