using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Antares.Essentials.Data.TypeBuilders;
using Mica.Domain.Data.Models.Ticket;

namespace Mica.Domain.Data.TypeBuilders.Ticket
{
    public class TicketStatusType : EntityTypeConfiguration<TicketStatusEntity, long>
    {
        public override void Configure(EntityTypeBuilder<TicketStatusEntity> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name)
              .HasColumnType("nvarchar(255)")
              .HasMaxLength(255)
              .IsRequired();

            builder.Property(c => c.Description)
              .HasColumnType("nvarchar(1000)")
              .HasMaxLength(1000);

            builder.Property(c => c.Order)
              .HasColumnType("int")
              .IsRequired();
        }
    }
}
