using Microsoft.AspNetCore.Mvc;
using Mica.Application.Services.Inventory;
using Mica.Application.Models.Inventory;

namespace Mica.Presentation.Web.Controllers.Inventory
{
    public class InventoryOperationController : Controller
    {
        private readonly IInventoryOperationService _inventoryService;
        public InventoryOperationController(IInventoryOperationService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public IActionResult Index(string query, int pageNumber = 1, int pageSize = 10)
        {
            var result = this._inventoryService.GetAll(query, pageNumber, pageSize);
            return View(result);
        }

        public IActionResult Edit(long id = 0)
        {
            InventoryOperationModel model;
            if (id == 0)
            {
                model = this._inventoryService.CreateDefaultObject();
            }
            else
            {
                model = this._inventoryService.GetById(id);
            }

            return PartialView(model);
        }

        public IActionResult ConfirmDelete(long id = 0)
        {
            InventoryOperationModel model;
            if (id == 0)
            {
                model = this._inventoryService.CreateDefaultObject();
            }
            else
            {
                model = this._inventoryService.GetById(id);
            }

            return PartialView(model);
        }

        public void Save(InventoryOperationModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    this._inventoryService.Add(model);
                }
                else
                {
                    this._inventoryService.Update(model);
                }
            }
        }

        public void Delete(InventoryOperationModel model)
        {
            this._inventoryService.Remove(model.Id);
        }
    }
}
