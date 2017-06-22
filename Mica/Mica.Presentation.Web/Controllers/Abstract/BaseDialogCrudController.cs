using Microsoft.AspNetCore.Mvc;
using Mica.Application.Models;
using Mica.Application.Services.Abstract;

namespace Mica.Presentation.Web.Controllers.Abstract
{
    public abstract class BaseDialogCrudController<TModel, TKey, TService> : BaseCrudController<TModel, TKey, TService>
        where TModel : ModelBase<TKey>
        where TService : IContentLookupListingService<TModel>, ICrudService<TModel, TKey>
    {
        public BaseDialogCrudController(TService service) : base(service) { }

        public override IActionResult AddEditView(TKey id)
        {
            return PartialView("AddEditDialog", GetAddEditViewModel(id));
        }
      
        public override IActionResult DeleteView(TKey id)
        {
            return PartialView("DeleteDialog", GetDeleteViewModel(id));
        }
    }
}
