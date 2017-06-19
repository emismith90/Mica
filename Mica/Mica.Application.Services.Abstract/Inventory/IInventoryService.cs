using Mica.Application.Models.Inventory;
using Mica.Application.Services.Abstract;

namespace Mica.Application.Services.Inventory
{
    public interface IInventoryService : ICrudService<InventoryModel, long>, IContentListingService<InventoryModel>
    {
        void UpdateInventoryStock(long inventoryId, decimal quantity, bool reverse = false);
    }
}
