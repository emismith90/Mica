using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mica.Domain.Data.Models;

namespace Mica.Domain.Data.TypeBuilders
{
    public abstract class EntityTypeConfiguration<TEntity, TEntityKey> 
        where TEntity : EntityBase<TEntityKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
        }
    }
}
