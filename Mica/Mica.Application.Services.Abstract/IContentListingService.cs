using System.Collections.Generic;
using Mica.Infrastructure.Helpers;

namespace Mica.Application.Services.Abstract
{
    public interface IContentListingService<TModel>
    {
        IList<TModel> GetAll();
        IPagedList<TModel> GetAll(int pageNumber, int pageSize);
    }
}
