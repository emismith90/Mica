using AutoMapper;
using Mica.Domain.Abstract.Repositories;
using Mica.Domain.Abstract.UoW;
using Mica.Application.Services.Abstract.Client;
using Mica.Application.Services.Abstract.Cache;
using Mica.Application.Models.Client;
using Mica.Domain.Data.Models.Client;

namespace Mica.Application.Services.Client
{
    public class ClientService : CrudWithSearchServiceBase<long, ClientModel, ClientEntity>, IClientService
    {
        public ClientService(
            IMapper mapper, 
            IUnitOfWork unitOfWork, 
            ITypedCacheService<ClientModel, long> cache,
            IGenericRepository<ClientEntity, long> repository) 
            : base(mapper, unitOfWork, cache, repository)
        {
        }
    }
}
