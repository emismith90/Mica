using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Mica.Domain.Abstract.Repositories
{
    public interface IGenericRepository<TEntity, TEntityKey> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(TEntityKey id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntityKey id);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}
