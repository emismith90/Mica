using System.Collections.Generic;
using Antares.Essentials.Helpers;
using Antares.Essentials.Application.Services;
using Mica.Application.Models.Inventory;

namespace Mica.Application.Services.Abstract.Inventory
{
    public interface IInventoryOperationService 
          : ICrudService<InventoryOperationModel, long>,
            IContentListingService<InventoryOperationModel>,
            IContentLookupListingService<InventoryOperationModel>,
            IModelCreatorService<InventoryOperationModel>
    {
        IPagedList<InventoryOperationModel> GetAll(long materialId,string query, int pageNumber, int pageSize, string orderBy, string orderDirection);
        IList<InventoryOperationModel> FindByTicket(long ticketId);
    }
}
