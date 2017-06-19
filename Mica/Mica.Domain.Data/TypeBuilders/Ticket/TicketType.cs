using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mica.Domain.Data.Models.Ticket;

namespace Mica.Domain.Data.TypeBuilders.Ticket
{
    public class TicketType : AuditableTypeConfiguration<TicketEntity, long>
    {
        public override void Configure(EntityTypeBuilder<TicketEntity> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name)
                .HasColumnType("nvarchar(255)")
                .HasMaxLength(255);

            builder.Property(c => c.SaleById)
                .HasColumnName("SaleById");
            builder.HasOne(m => m.Client)
                .WithMany()
                .HasForeignKey(m => m.ClientId)
                .IsRequired();
            builder.HasOne(m => m.Status)
                .WithMany()
                .HasForeignKey(m => m.StatusId)
                .IsRequired();

            builder.Property(c => c.Deadline)
                .HasColumnType("datetime");
            builder.Property(c => c.Quantity)
                .HasColumnType("decimal(12, 2)")
                .IsRequired();

            builder.Property(c => c.Note)
                .HasColumnType("nvarchar(1000)")
                .HasMaxLength(1000);
        }
    }
}
