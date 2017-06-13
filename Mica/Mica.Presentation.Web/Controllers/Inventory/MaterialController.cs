using Microsoft.AspNetCore.Mvc;
using Mica.Application.Services.Inventory;
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

        public IActionResult Index(string query, int pageNumber = 1, int pageSize = 10, string orderBy = "", string orderDirection = "")
        {
            var result = this._materialService.GetAll(query, pageNumber, pageSize, orderBy, orderDirection);
            return View(result);
        }

        public IActionResult Edit(long id = 0)
        {
            MaterialModel model;
            if (id == 0)
            {
                model = this._materialService.CreateDefaultObject();
            }
            else
            {
                model = this._materialService.GetById(id);
            }

            return PartialView(model);
        }

        public IActionResult ConfirmDelete(long id = 0)
        {
            MaterialModel model;
            if (id == 0)
            {
                model = this._materialService.CreateDefaultObject();
            }
            else
            {
                model = this._materialService.GetById(id);
            }

            return PartialView(model);
        }

        public void Save(MaterialModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    this._materialService.Add(model);
                }
                else
                {
                    this._materialService.Update(model);
                }
            }
        }

        public void Delete(MaterialModel model)
        {
            this._materialService.Remove(model.Id);
        }
    }
}
