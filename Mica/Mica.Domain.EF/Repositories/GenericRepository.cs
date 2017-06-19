using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Mica.Domain.Data.Contexts;
using Mica.Domain.Abstract.Repositories;
using Mica.Infrastructure.Models.Abstract;

namespace Mica.Domain.EF.Repositories
{
    public class GenericRepository<TEntity, TEntityKey> : IGenericRepository<TEntity, TEntityKey> 
        where TEntity : class, IEntity<TEntityKey>
    {
        protected MicaContext Db;
        protected DbSet<TEntity> DbSet;

        public GenericRepository(MicaContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity GetById(TEntityKey id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet.AsNoTracking();
        }

        public virtual TEntityKey Add(TEntity obj)
        {
            DbSet.Add(obj);
            return obj.Id;
        }

        public virtual TEntityKey Update(TEntity obj)
        {
            DbSet.Update(obj);
            return obj.Id;
        }

        public virtual void Remove(TEntityKey id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public virtual int SaveChanges()
        {
            return Db.SaveChanges();
        }
        
        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
