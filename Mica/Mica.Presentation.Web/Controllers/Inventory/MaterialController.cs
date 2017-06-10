using Microsoft.AspNetCore.Mvc;
using Mica.Application.Services.Inventory;
using Mica.Infrastructure.Extensions;
using Mica.Infrastructure.Helpers;
using Mica.Application.Models.Inventory;

namespace Mica.Presentation.Web.Controllers.Inventory
{
    public class MaterialController : Controller
    {
        private readonly IMaterialService _materialService;
        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        public IActionResult Index(int pageNumber, int pageSize)
        {
            var result = this._materialService.GetAll(pageNumber, pageSize);
            return View(result);
        }

        public IActionResult Edit(long id = 0)
        {
            MaterialModel model;
            if (id == 0)
            {
                model = new MaterialModel();
            }
            else
            {
                model = this._materialService.GetById(id);
            }

            return View(model);
        }

        public IActionResult ConfirmDelete(long id = 0)
        {
            MaterialModel model;
            if (id == 0)
            {
                return DefaultView();
            }
            else
            {
                model = this._materialService.GetById(id);
            }

            return View(model);
        }

        public IActionResult Save(MaterialModel model)
        {
            if (ModelState.IsValid)
            {
                bool success;
                if (model.Id == 0)
                {
                    success = this._materialService.Add(model);
                }
                else
                {
                    success = this._materialService.Update(model);
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

            return View("Edit", model);
        }

        public IActionResult Delete(MaterialModel model)
        {
            if (!this._materialService.Remove(model.Id))
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
