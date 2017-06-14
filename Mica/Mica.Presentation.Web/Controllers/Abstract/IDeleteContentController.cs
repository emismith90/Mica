using Mica.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mica.Presentation.Web.Controllers.Abstract
{
    public interface IDeleteContentController<TModel, TKey>
        where TModel : ModelBase<TKey>
    {
        bool Delete(TModel model);
        IActionResult DeleteDialog(TKey id);
    }
}
