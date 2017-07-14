using Microsoft.AspNetCore.Mvc;
using Mica.Application.Models.Inventory;
using Mica.Presentation.Web.Controllers.Abstract;
using Mica.Application.Services.Abstract.Inventory;

namespace Mica.Presentation.Web.Controllers.Inventory
{
    public class InventoryOperationController : BaseDialogCrudController<InventoryOperationModel, long, IInventoryOperationService>
    {
        private readonly IMaterialService _materialService;
        public InventoryOperationController(IInventoryOperationService inventoryOperationService,
            IMaterialService materialService) : base(inventoryOperationService)
        { 
            _materialService = materialService;
        }
        public IActionResult Filter(string materialId, string query, int pageNumber = 1, int pageSize = 10, string orderBy = "", string orderDirection = "")
        {
            long id;
            if(long.TryParse(materialId, out id))
            {
                var result = this.Service.GetAll(id, query, pageNumber, pageSize, orderBy, orderDirection);
                return View("Index", result);
            }

            return Index(query, pageNumber, pageSize, orderBy, orderDirection);
        }

        public override IActionResult AddEditView(long id)
        {
            if (id != 0) // not allow edit
            {
                return new EmptyResult();
            }

            var vm = new InventoryOperationAddEditViewModel
            {
                Model = this.Service.CreateDefaultObject(),
                Materials = this._materialService.GetForPickup()
            };

            return PartialView("AddEditDialog", vm);
        }
    }
}
