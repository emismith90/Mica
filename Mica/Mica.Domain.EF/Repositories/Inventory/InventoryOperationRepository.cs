using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mica.Domain.Data.Contexts;
using Mica.Domain.Data.Models.Inventory;
using Mica.Domain.Abstract.Repositories.Inventory;

namespace Mica.Domain.EF.Repositories.Inventory
{
    public class InventoryOperationRepository : MicaGenericRepository<InventoryOperationEntity, long>, IInventoryOperationRepository
    {
        public InventoryOperationRepository(MicaContext context) : base(context) { }

        public override InventoryOperationEntity GetById(long id)
        {
            return DbSet.Where(i => i.Id == id)
                .Include(i => i.Material)
                .SingleOrDefault();
        }

        public override IQueryable<InventoryOperationEntity> GetAll()
        {
            return base.GetAll().Include(i => i.Material);
        }
    }
}
