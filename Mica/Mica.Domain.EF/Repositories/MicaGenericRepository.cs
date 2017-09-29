using Antares.Essentials.Data.Entities;
using Antares.Essentials.Data.Repositories;
using Mica.Domain.Data.Contexts;

namespace Mica.Domain.EF.Repositories
{
    public class MicaGenericRepository<TEntity> : GenericRepository<TEntity> 
        where TEntity : class, IEntity
    {
        public MicaGenericRepository(MicaContext context) : base(context) { }
    }

    public class MicaGenericRepository<TEntity, TEntityKey> : GenericRepository<TEntity, TEntityKey>
    where TEntity : class, IEntity<TEntityKey>
    {
        public MicaGenericRepository(MicaContext context) : base(context)
        {
        }
    }
}
