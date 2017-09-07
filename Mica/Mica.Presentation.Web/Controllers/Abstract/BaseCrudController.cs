using Microsoft.AspNetCore.Mvc;
using Antares.Essentials.Application.Models;
using Antares.Essentials.Application.Services;
using Mica.Application.Services.Abstract;

namespace Mica.Presentation.Web.Controllers.Abstract
{
     public abstract class BaseCrudController<TModel, TKey, TService> : Controller, ICrudController<TModel, TKey>
        where TModel : ModelBase<TKey>
        where TService : IContentLookupListingService<TModel>, ICrudService<TModel, TKey>, IModelCreatorService<TModel>
    {
        protected readonly TService Service;
        public BaseCrudController(TService service)
        {
            Service = service;
        }

        public virtual IActionResult Index(string query, int pageNumber = 1, int pageSize = 10, string orderBy = "", string orderDirection = "")
        {
            var result = this.Service.GetAll(query, pageNumber, pageSize, orderBy, orderDirection);
            return View("Index", result);
        }
        
        public virtual IActionResult AddEditView(TKey id)
        {
            return View("AddEdit", GetAddEditViewModel(id));
        }

        [HttpPost]
        public virtual StatusCodeResult Save(TModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id.Equals(default(TKey)))
                {
                    if (this.Service.Add(model)) return Ok();
                }
                else
                {
                    if (this.Service.Update(model)) return Ok();
                }
            }

            return BadRequest();
        }

        public virtual IActionResult DeleteView(TKey id)
        {
            return View("Delete", GetDeleteViewModel(id));
        }

        [HttpPost]
        public virtual StatusCodeResult Delete(TModel model)
        {
            if (this.Service.Remove(model.Id))
            {
                return Ok();
            }

            return BadRequest();
        }

        protected virtual object GetAddEditViewModel(TKey id)
        {
            if (id.Equals(default(TKey)))
            {
                return this.Service.CreateDefaultObject();
            }
            else
            {
                return this.Service.GetById(id);
            }
        }

        protected virtual object GetDeleteViewModel(TKey id)
        {
            return GetAddEditViewModel(id);
        }
    }
}
