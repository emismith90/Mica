using Antares.Essentials.Application.Services;
using Mica.Application.Models.Inventory;

namespace Mica.Application.Services.Abstract.Inventory
{
    public interface IInventoryService : ICrudService<InventoryModel, long>, IContentListingService<InventoryModel>
    {
        void UpdateInventoryStock(long inventoryId, decimal quantity, bool reverse = false);
    }
}
