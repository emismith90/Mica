using Mica.Application.Models.Inventory;
using Mica.Application.Services.Abstract;

namespace Mica.Application.Services.Inventory
{
    public interface IInventoryService : ICrudService<InventoryModel, long>, IModelCreatorService<InventoryModel>
    {
    }
}
