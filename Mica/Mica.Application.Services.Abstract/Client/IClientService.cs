using Mica.Application.Models.Client;

namespace Mica.Application.Services.Abstract.Client
{
    public interface IClientService : 
        ICrudService<ClientModel, long>, 
        IContentListingService<ClientModel>, 
        IContentLookupListingService<ClientModel>
    {
    }
}
