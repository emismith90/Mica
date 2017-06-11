using Microsoft.AspNetCore.Mvc;
using Mica.Application.Services.Inventory;
using Mica.Application.Models.Inventory;

namespace Mica.Presentation.Web.Controllers.Inventory
{
    public class MaterialVariantController : Controller
    {
        private readonly IMaterialVariantService _materialVariantService;
        public MaterialVariantController(IMaterialVariantService materialVariantService)
        {
            _materialVariantService = materialVariantService;
        }

        public IActionResult Index(long materialId, int pageNumber = 1, int pageSize = 10)
        {
            var result = this._materialVariantService.GetAll(pageNumber, pageSize);
            return PartialView(result);
        }

        public IActionResult Edit(long id = 0)
        {
            MaterialVariantModel model;
            if (id == 0)
            {
                model = new MaterialVariantModel();
            }
            else
            {
                model = this._materialVariantService.GetById(id);
            }

            return PartialView(model);
        }

        public IActionResult ConfirmDelete(long id = 0)
        {
            MaterialVariantModel model;
            if (id == 0)
            {
                return DefaultView();
            }
            else
            {
                model = this._materialVariantService.GetById(id);
            }

            return PartialView(model);
        }

        public IActionResult Save(MaterialVariantModel model)
        {
            if (ModelState.IsValid)
            {
                bool success;
                if (model.Id == 0)
                {
                    success = this._materialVariantService.Add(model);
                }
                else
                {
                    success = this._materialVariantService.Update(model);
                }

                if (success)
                {
                    return DefaultView();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Có lỗi trong quá trình lưu.");
                }
                    
            }

            return PartialView("Edit", model);
        }

        public IActionResult Delete(MaterialVariantModel model)
        {
            if (!this._materialVariantService.Remove(model.Id))
            {
                ModelState.AddModelError(string.Empty, "Có lỗi trong quá trình xóa.");
                return View("ConfirmDelete", model);
            }

            return DefaultView();
        }

        private IActionResult DefaultView()
        {
            return RedirectToAction("Index");
        }
    }
}
