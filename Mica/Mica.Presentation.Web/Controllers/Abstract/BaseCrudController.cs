using Mica.Application.Models;
using Mica.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

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
            return View("Index", result);
        }
        
        public virtual IActionResult AddEditView(TKey id)
        {
            return View("AddEdit", GetAddEditViewModel(id));
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

        public virtual IActionResult DeleteView(TKey id)
        {
            return View("Delete", GetDeleteViewModel(id));
        }
        public virtual bool Delete(TModel model)
        {
            return this.Service.Remove(model.Id);
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
