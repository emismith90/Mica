using Microsoft.AspNetCore.Mvc;
using Mica.Application.Services.Abstract.Inventory;

namespace Mica.Presentation.Web.Controllers.Inventory
{
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            var result = this._inventoryService.GetAll(pageNumber, pageSize);
            return View(result);
        }
    }
}
