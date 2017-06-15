using Mica.Domain.Data.Models.Inventory;

namespace Mica.Domain.Abstract.Repositories.Inventory
{
    public interface IInventoryOperationRepository : IAuditableRepository<InventoryOperationEntity, long> 
    {
    }
}
