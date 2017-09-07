using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Antares.Essentials.Data.TypeBuilders;
using Mica.Domain.Data.Models.Client;

namespace Mica.Domain.Data.TypeBuilders.Client
{
    public class ClientType : EntityTypeConfiguration<ClientEntity, long>
    {
        public override void Configure(EntityTypeBuilder<ClientEntity> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name)
               .HasColumnType("nvarchar(255)")
               .HasMaxLength(255)
               .IsRequired();

            builder.Property(c => c.Birthday)
               .HasColumnType("datetime");

            builder.Property(c => c.Email)
               .HasColumnType("nvarchar(255)")
               .HasMaxLength(255);
            builder.Property(c => c.SkypeId)
               .HasColumnType("nvarchar(255)")
               .HasMaxLength(255);
            builder.Property(c => c.YahooId)
               .HasColumnType("nvarchar(255)")
               .HasMaxLength(255);
            builder.Property(c => c.PhoneNumber)
               .HasColumnType("nvarchar(255)")
               .HasMaxLength(255);
            builder.Property(c => c.Address)
               .HasColumnType("nvarchar(1000)")
               .HasMaxLength(1000);

            builder.Property(c => c.Company)
               .HasColumnType("nvarchar(255)")
               .HasMaxLength(255);
            builder.Property(c => c.Position)
               .HasColumnType("nvarchar(255)")
               .HasMaxLength(255);
            builder.Property(c => c.CompanyPhone)
               .HasColumnType("nvarchar(255)")
               .HasMaxLength(255);
            builder.Property(c => c.CompanyAddress)
               .HasColumnType("nvarchar(1000)")
               .HasMaxLength(1000);

            builder.Property(c => c.Note)
               .HasColumnType("nvarchar(1000)")
               .HasMaxLength(1000);
        }
    }
}
