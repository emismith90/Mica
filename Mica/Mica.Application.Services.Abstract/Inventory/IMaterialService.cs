using Microsoft.AspNetCore.Mvc.Rendering;
using Antares.Essentials.Application.Services;
using Mica.Application.Models.Inventory;

namespace Mica.Application.Services.Abstract.Inventory
{
    public interface IMaterialService 
          : ICrudService<MaterialModel, long>, 
            IContentListingService<MaterialModel>,
            IContentLookupListingService<MaterialModel>,
            IContentPickupService<SelectListItem>,
            IModelCreatorService<MaterialModel>
    {
    }   
}
