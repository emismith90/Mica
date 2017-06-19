using AutoMapper;
using Mica.Domain.Abstract.Repositories;
using Mica.Domain.Abstract.UoW;
using Mica.Application.Services.Abstract.Effort;
using Mica.Application.Services.Abstract.Cache;
using Mica.Application.Models.Effort;
using Mica.Domain.Data.Models.Effort;

namespace Mica.Application.Services.Effort
{
    public class EffortService : CrudWithSearchServiceBase<long, EffortModel, EffortEntity>, IEffortService
    {
        private readonly IGenericRepository<EffortEntity, long> _repository;
        public EffortService(
            IMapper mapper, 
            IUnitOfWork unitOfWork, 
            ITypedCacheService<EffortModel, long> cache,
            IGenericRepository<EffortEntity, long> repository) 
            : base(mapper, unitOfWork, cache, repository)
        {
            this._repository = repository;
        }

        public override EffortModel CreateDefaultObject()
        {
            return new EffortModel
            {
                Active = true
            };
        }
    }
}
