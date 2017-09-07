using Antares.Essentials.Data.Repositories;
using Mica.Domain.Data.Models.Inventory;

namespace Mica.Domain.Abstract.Repositories.Inventory
{
    public interface IInventoryOperationRepository : IGenericRepository<InventoryOperationEntity, long> 
    {
    }
}
