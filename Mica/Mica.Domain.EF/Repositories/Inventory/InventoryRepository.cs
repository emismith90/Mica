using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mica.Domain.Data.Contexts;
using Mica.Domain.Data.Models.Inventory;
using Mica.Domain.Abstract.Repositories.Inventory;

namespace Mica.Domain.EF.Repositories.Inventory
{
    public class InventoryRepository : MicaGenericRepository<InventoryEntity, long>, IInventoryRepository
    {
        public InventoryRepository(MicaContext context) : base(context) { }

        public override InventoryEntity GetById(long id)
        {
            return DbSet.Where(i => i.Id == id)
                .Include(i => i.Material)
                .SingleOrDefault();
        }

        public override IQueryable<InventoryEntity> GetAll()
        {
            return base.GetAll().Include(i => i.Material);
        }
    }
}
