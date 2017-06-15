namespace Mica.Application.Services.Abstract
{
    public interface IModelCreatorService<TModel>
    {
        TModel CreateDefaultObject();
    }
}
