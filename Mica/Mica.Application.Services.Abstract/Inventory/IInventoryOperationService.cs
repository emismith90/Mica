using Mica.Application.Models.Inventory;
using Mica.Application.Services.Abstract;

namespace Mica.Application.Services.Inventory
{
    public interface IInventoryOperationService 
          : ICrudService<InventoryOperationModel, long>,
            IContentListingService<InventoryOperationModel>,
            IContentLookupListingService<InventoryOperationModel>
    {
    }
}
