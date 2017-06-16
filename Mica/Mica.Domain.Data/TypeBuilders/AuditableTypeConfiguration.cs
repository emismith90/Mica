using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mica.Domain.Data.TypeBuilders.Abstract;
using Mica.Domain.Data.Models;

namespace Mica.Domain.Data.TypeBuilders
{
    public abstract class AuditableTypeConfiguration<TEntity, TEntityKey> : IAuditableTypeConfiguration<TEntity, TEntityKey>
        where TEntity : AuditableEntityBase<TEntityKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(c => c.CreatedBy)
                .HasColumnName("CreatedBy");

            builder.Property(c => c.CreatedOn)
               .HasColumnName("CreatedOn")
               .HasColumnType("datetime")
               .ValueGeneratedOnAdd();

            builder.Property(c => c.ModifiedBy)
                .HasColumnName("ModifiedBy");

            builder.Property(c => c.ModifiedOn)
               .HasColumnName("ModifiedOn")
               .HasColumnType("datetime")
               .ValueGeneratedOnAddOrUpdate();
        }
    }
}
