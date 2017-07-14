using Mica.Application.Models.Inventory;
using Mica.Application.Services.Abstract;
using Mica.Infrastructure.Helpers;
using System.Collections.Generic;

namespace Mica.Application.Services.Abstract.Inventory
{
    public interface IInventoryOperationService 
          : ICrudService<InventoryOperationModel, long>,
            IContentListingService<InventoryOperationModel>,
            IContentLookupListingService<InventoryOperationModel>
    {
        IPagedList<InventoryOperationModel> GetAll(long materialId,string query, int pageNumber, int pageSize, string orderBy, string orderDirection);
        IList<InventoryOperationModel> FindByTicket(long ticketId);
    }
}
