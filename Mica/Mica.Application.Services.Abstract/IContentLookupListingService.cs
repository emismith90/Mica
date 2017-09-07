using System.Collections.Generic;
using Antares.Essentials.Application.Services;
using Antares.Essentials.Helpers;

namespace Mica.Application.Services.Abstract
{
    public interface IContentLookupListingService<TModel> : IContentListingService<TModel>
    {
        IList<TModel> GetAll(string query, string orderBy, string orderDirection);
        IPagedList<TModel> GetAll(string query, int pageNumber, int pageSize, string orderBy, string orderDirection);
    }
}
