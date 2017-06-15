﻿using System;
using System.Linq;
using System.Linq.Expressions;
using Mica.Infrastructure.Models.Abstract;

namespace Mica.Domain.Abstract.Repositories
{
    public interface IGenericRepository<TEntity, TEntityKey> : IDisposable
        where TEntity : class, IEntity<TEntityKey>
    {
        TEntity CreateDefaultObject();

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity GetById(TEntityKey id);
        IQueryable<TEntity> GetAll();

        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntityKey id);

        int SaveChanges();
    }
}
