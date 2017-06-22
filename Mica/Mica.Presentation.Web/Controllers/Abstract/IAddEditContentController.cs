using Microsoft.AspNetCore.Mvc;
using Mica.Application.Models;

namespace Mica.Presentation.Web.Controllers.Abstract
{
    public interface IAddEditContentController<TModel, TKey> 
       where TModel : ModelBase<TKey>
    {
        bool Save(TModel model);

        IActionResult AddEditView(TKey id);
    }
}
