using Mica.Application.Services.Inventory;
using Mica.Application.Models.Inventory;
using Mica.Presentation.Web.Controllers.Abstract;

namespace Mica.Presentation.Web.Controllers.Inventory
{
    public class InventoryOperationController : BaseCrudController<InventoryOperationModel, long, IInventoryOperationService>
    {
        public InventoryOperationController(IInventoryOperationService inventoryService) : base(inventoryService)
        {
        }
    }
}
