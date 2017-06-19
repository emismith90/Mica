using Mica.Application.Models.Inventory;
using Mica.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Mica.Application.Services.Abstract.Inventory
{
    public interface IMaterialService 
          : ICrudService<MaterialModel, long>, 
            IContentListingService<MaterialModel>,
            IContentLookupListingService<MaterialModel>
    {
        IList<SelectListItem> GetMaterialsForPickup();
    }   
}
