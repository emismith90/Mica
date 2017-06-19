using Mica.Application.Models.Inventory;
using Mica.Application.Services.Abstract;
using Mica.Infrastructure.Helpers;

namespace Mica.Application.Services.Abstract.Inventory
{
    public interface IInventoryOperationService 
          : ICrudService<InventoryOperationModel, long>,
            IContentListingService<InventoryOperationModel>,
            IContentLookupListingService<InventoryOperationModel>
    {
        IPagedList<InventoryOperationModel> GetAll(long materialId,string query, int pageNumber, int pageSize, string orderBy, string orderDirection);
    }
}
