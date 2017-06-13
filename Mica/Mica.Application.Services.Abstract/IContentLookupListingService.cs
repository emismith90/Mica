using System.Collections.Generic;
using Mica.Infrastructure.Helpers;

namespace Mica.Application.Services.Abstract
{
    public interface IContentLookupListingService<TModel> : IContentListingService<TModel>
    {
        IList<TModel> GetAll(string query);
        IPagedList<TModel> GetAll(string query, int pageNumber, int pageSize);
    }
}
