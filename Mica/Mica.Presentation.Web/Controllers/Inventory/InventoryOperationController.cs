using Microsoft.AspNetCore.Mvc;
using Mica.Application.Services.Inventory;
using Mica.Application.Models.Inventory;
using Mica.Presentation.Web.Controllers.Abstract;

namespace Mica.Presentation.Web.Controllers.Inventory
{
    public class InventoryOperationController : BaseCrudController<InventoryOperationModel, long, IInventoryOperationService>
    {
        private readonly IMaterialService _materialService;
        public InventoryOperationController(IInventoryOperationService inventoryService,
            IMaterialService materialService) : base(inventoryService)
        {
            _materialService = materialService;
        }

        public override IActionResult AddEditDialog(long id)
        {
            if (id != 0) // not allow edit
            {
                return new EmptyResult();
            }

            var vm = new InventoryOperationAddEditViewModel
            {
                Model = this.Service.CreateDefaultObject(),
                Materials = this._materialService.GetMaterialsForPickup()
            };

            return PartialView(vm);
        }
    }
}
