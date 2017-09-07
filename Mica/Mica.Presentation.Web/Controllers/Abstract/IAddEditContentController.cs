using Microsoft.AspNetCore.Mvc;
using Antares.Essentials.Application.Models;

namespace Mica.Presentation.Web.Controllers.Abstract
{
    public interface IAddEditContentController<TModel, TKey> 
       where TModel : ModelBase<TKey>
    {
        StatusCodeResult Save(TModel model);

        IActionResult AddEditView(TKey id);
    }
}
