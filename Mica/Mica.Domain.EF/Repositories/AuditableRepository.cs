using System;
using Mica.Domain.Data.Contexts;
using Mica.Domain.Abstract.Repositories;
using Mica.Infrastructure.Models.Abstract;

namespace Mica.Domain.EF.Repositories
{
    public class AuditableRepository<TEntity, TEntityKey> : GenericRepository<TEntity, TEntityKey>, IAuditableRepository<TEntity, TEntityKey> 
        where TEntity : class, IEntity<TEntityKey>, IAuditableEntity
    {
        public AuditableRepository(MicaContext context) : base(context)
        {
        }

        public override void Add(TEntity obj)
        {
            obj.CreatedOn = DateTime.Now;
            DbSet.Add(obj);
        }
        public override void Update(TEntity obj)
        {
            obj.ModifiedOn = DateTime.Now;
            DbSet.Update(obj);
        }
    }
}
