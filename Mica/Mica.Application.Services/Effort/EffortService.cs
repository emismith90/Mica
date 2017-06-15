using AutoMapper;
using Mica.Domain.Abstract.Repositories;
using Mica.Domain.Abstract.UoW;
using Mica.Application.Services.Abstract.Effort;
using Mica.Application.Services.Abstract.Cache;
using Mica.Application.Models.Effort;
using Mica.Domain.Data.Models.Effort;
using Mica.Domain.Abstract.Repositories.Effort;

namespace Mica.Application.Services.Effort
{
    public class EffortService : CrudWithSearchServiceBase<long, EffortModel, EffortEntity>, IEffortService
    {
        private readonly IGenericRepository<EffortEntity, long> _repository;
        public EffortService(
            IMapper mapper, 
            IUnitOfWork unitOfWork, 
            ITypedCacheService<EffortModel, long> cache,
            IEffortRepository repository) 
            : base(mapper, unitOfWork, cache, repository)
        {
            this._repository = repository;
        }
    }
}
