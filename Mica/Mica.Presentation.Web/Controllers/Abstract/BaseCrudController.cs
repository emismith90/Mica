using Microsoft.AspNetCore.Mvc;
using Mica.Application.Models;
using Mica.Application.Services.Abstract;

namespace Mica.Presentation.Web.Controllers.Abstract
{
    public abstract class BaseCrudController<TModel, TKey, TService> : Controller, ICrudController<TModel, TKey>
        where TModel : ModelBase<TKey>
        where TService : IContentLookupListingService<TModel>, ICrudService<TModel, TKey>
    {
        protected readonly TService Service;
        public BaseCrudController(TService service)
        {
            Service = service;
        }

        public virtual IActionResult Index(string query, int pageNumber = 1, int pageSize = 10, string orderBy = "", string orderDirection = "")
        {
            var result = this.Service.GetAll(query, pageNumber, pageSize, orderBy, orderDirection);
            return View(result);
        }

        public virtual IActionResult AddEditDialog(TKey id)
        {
            TModel model;
            if (id.Equals(default(TKey)))
            {
                model = this.Service.CreateDefaultObject();
            }
            else
            {
                model = this.Service.GetById(id);
            }

            return PartialView(model);
        }
        public virtual bool Save(TModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id.Equals(default(TKey)))
                {
                    return this.Service.Add(model);
                }
                else
                {
                    return this.Service.Update(model);
                }
            }

            return false;
        }

        public virtual IActionResult DeleteDialog(TKey id)
        {
            TModel model;
            if (id.Equals(default(TKey)))
            {
                model = this.Service.CreateDefaultObject();
            }
            else
            {
                model = this.Service.GetById(id);
            }

            return PartialView(model);
        }
        public virtual bool Delete(TModel model)
        {
            return this.Service.Remove(model.Id);
        }
    }
}
