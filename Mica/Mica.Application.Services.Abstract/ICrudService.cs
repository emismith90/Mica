using Mica.Application.Models;

namespace Mica.Application.Services.Abstract
{
    public interface ICrudService<TModel, TKey> : IModelCreatorService<TModel>
        where TModel : ModelBase<TKey>
    {
        TModel GetById(TKey id);
        bool Add(TModel todo);
        bool Update(TModel todo);
        bool Remove(TKey id);
    }
}
