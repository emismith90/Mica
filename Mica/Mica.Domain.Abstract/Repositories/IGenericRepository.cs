using System;
using System.Linq;
using System.Linq.Expressions;
using Mica.Infrastructure.Models.Abstract;

namespace Mica.Domain.Abstract.Repositories
{
    public interface IGenericRepository<TEntity, TEntityKey> : IDisposable
        where TEntity : class, IEntity<TEntityKey>
    {
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity GetById(TEntityKey id);
        IQueryable<TEntity> GetAll();

        TEntityKey Add(TEntity obj);
        TEntityKey Update(TEntity obj);
        void Remove(TEntityKey id);

        int SaveChanges();
    }
}
