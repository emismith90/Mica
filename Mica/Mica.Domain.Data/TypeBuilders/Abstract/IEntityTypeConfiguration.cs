using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mica.Domain.Data.Models;

namespace Mica.Domain.Data.TypeBuilders.Abstract
{
    public interface IEntityTypeConfiguration<TEntity, TEntityKey>
        where TEntity : EntityBase<TEntityKey>
    {
        void Configure(EntityTypeBuilder<TEntity> builder);
    }
}
