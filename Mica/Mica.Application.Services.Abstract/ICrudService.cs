using Mica.Application.Models;
using Mica.Infrastructure.Helpers;

namespace Mica.Application.Services.Abstract
{
    public interface ICrudService<TModel, TKey> where TModel : ModelBase<TKey>
    {
        TModel GetById(TKey id);
        IPagedList<TModel> GetAll(int pageNumber, int pageSize);
        bool Add(TModel todo);
        bool Update(TModel todo);
        bool Remove(TKey id);
    }
}
