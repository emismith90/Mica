using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mica.Domain.Data.Models.Inventory;

namespace Mica.Domain.Data.TypeBuilders.Inventory
{
    public class MaterialVariantType : EntityTypeConfiguration<MaterialVariantEntity, long>
    {
        public override void Configure(EntityTypeBuilder<MaterialVariantEntity> builder)
        {
            base.Configure(builder);

            builder.HasOne(m => m.Material)
                .WithMany()
                .HasForeignKey(m => m.MaterialId);

            builder.Property(c => c.Description)
               .HasColumnType("nvarchar(1000)")
               .HasMaxLength(1000);

            builder.Property(c => c.UnitPrice)
                .HasColumnType("decimal(12, 2)"); ;

            builder.Property(c => c.InActive)
               .HasColumnType("bit")
               .IsRequired();
        }
    }
}
