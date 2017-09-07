using Microsoft.AspNetCore.Mvc.Rendering;
using Antares.Essentials.Application.Services;
using Mica.Application.Models.Client;

namespace Mica.Application.Services.Abstract.Client
{
    public interface IClientService : 
        ICrudService<ClientModel, long>, 
        IContentListingService<ClientModel>, 
        IContentLookupListingService<ClientModel>,
        IContentPickupService<SelectListItem>,
        IModelCreatorService<ClientModel>
    {
    }
}
