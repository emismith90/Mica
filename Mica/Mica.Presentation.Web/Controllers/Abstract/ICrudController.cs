using Antares.Essentials.Application.Models;
using Mica.Application.Models;

namespace Mica.Presentation.Web.Controllers.Abstract
{
    public interface ICrudController<TModel, TKey> : IListingContentController, IAddEditContentController<TModel, TKey>, IDeleteContentController<TModel, TKey>
       where TModel : ModelBase<TKey>
    {

    }
}
