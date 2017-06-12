using Mica.Application.Models;
using Mica.Infrastructure.Helpers;

namespace Mica.Application.Services.Abstract
{
    public interface ICrudWithSeachService<TModel, TKey> : ICrudService<TModel, TKey>
        where TModel : ModelBase<TKey>
    {
        IPagedList<TModel> GetAll(string query, int pageNumber, int pageSize);
    }
}
