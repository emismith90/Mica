using Antares.Essentials.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mica.Presentation.Web.Controllers.Abstract
{
    public interface IDeleteContentController<TModel, TKey>
        where TModel : ModelBase<TKey>
    {
        StatusCodeResult Delete(TModel model);
        IActionResult DeleteView(TKey id);
    }
}
