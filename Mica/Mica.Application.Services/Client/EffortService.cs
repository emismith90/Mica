using AutoMapper;
using Mica.Domain.Abstract.Repositories;
using Mica.Domain.Abstract.UoW;
using Mica.Application.Services.Abstract.Client;
using Mica.Application.Services.Abstract.Cache;
using Mica.Application.Models.Client;
using Mica.Domain.Data.Models.Client;
using Mica.Domain.Abstract.Repositories.Client;

namespace Mica.Application.Services.Client
{
    public class ClientService : CrudWithSearchServiceBase<long, ClientModel, ClientEntity>, IClientService
    {
        private readonly IGenericRepository<ClientEntity, long> _repository;
        public ClientService(
            IMapper mapper, 
            IUnitOfWork unitOfWork, 
            ITypedCacheService<ClientModel, long> cache,
            IClientRepository repository) 
            : base(mapper, unitOfWork, cache, repository)
        {
            this._repository = repository;
        }
    }
}
