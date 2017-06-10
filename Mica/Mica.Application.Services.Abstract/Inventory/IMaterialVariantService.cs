using Mica.Application.Models.Inventory;
using Mica.Application.Services.Abstract;

namespace Mica.Application.Services.Inventory
{
    public interface IMaterialVariantService : ICrudService<MaterialVariantModel, long>
    {
    }
}
