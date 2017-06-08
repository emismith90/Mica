using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mica.Domain.Data.Models;
using Mica.Domain.Data.TypeBuilders.Abstract;

namespace Mica.Domain.Data.TypeBuilders
{
    public abstract class EntityTypeConfiguration<TEntity, TEntityKey> : IEntityTypeConfiguration<TEntity, TEntityKey>
        where TEntity : EntityBase<TEntityKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");
        }
    }
}
