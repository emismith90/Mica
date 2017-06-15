using System;
using Mica.Infrastructure.Models.Abstract;

namespace Mica.Domain.Abstract.Repositories
{
    public interface IAuditableRepository<TEntity, TEntityKey> : IGenericRepository<TEntity, TEntityKey>, IDisposable
        where TEntity : class, IEntity<TEntityKey>, IAuditableEntity
    {
    }
}
