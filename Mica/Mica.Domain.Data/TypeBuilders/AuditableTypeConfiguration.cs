using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mica.Domain.Data.Models;

namespace Mica.Domain.Data.TypeBuilders
{
    public abstract class AuditableTypeConfiguration<TEntity, TEntityKey>
        where TEntity : AuditableEntityBase<TEntityKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(c => c.CreatedById)
                .HasColumnName("CreatedById");

            builder.Property(c => c.CreatedOn)
               .HasColumnName("CreatedOn")
               .HasColumnType("datetime")
               .ValueGeneratedOnAdd();

            builder.Property(c => c.ModifiedById)
                .HasColumnName("ModifiedById");

            builder.Property(c => c.ModifiedOn)
               .HasColumnName("ModifiedOn")
               .HasColumnType("datetime")
               .ValueGeneratedOnAddOrUpdate();

            builder.HasOne(m => m.CreatedBy)
            .WithMany()
            .HasForeignKey(m => m.CreatedById);
            builder.HasOne(m => m.ModifiedBy)
            .WithMany()
            .HasForeignKey(m => m.ModifiedById);
        }
    }
}
