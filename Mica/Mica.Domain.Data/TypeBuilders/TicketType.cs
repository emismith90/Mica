using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Mica.Domain.Data.Models;

namespace Mica.Domain.Data.TypeBuilders
{
    public class TicketType : AuditableTypeConfiguration<TicketEntity, long>
    {
        public override void Configure(EntityTypeBuilder<TicketEntity> builder)
        {
            base.Configure(builder);
        }
    }
}
