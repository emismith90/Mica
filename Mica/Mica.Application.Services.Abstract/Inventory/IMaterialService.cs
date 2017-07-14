using Mica.Application.Models.Inventory;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mica.Application.Services.Abstract.Inventory
{
    public interface IMaterialService 
          : ICrudService<MaterialModel, long>, 
            IContentListingService<MaterialModel>,
            IContentLookupListingService<MaterialModel>,
            IContentPickupService<SelectListItem>
    {
    }   
}
