using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMapper;
using Antares.Essentials.Data.Repositories;
using Antares.Essentials.Data.UoW;
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

        public virtual IList<SelectListItem> GetForPickup()
        {
            return Cache.GetOrFetchDependKey("GetForPickup",
                () =>
                {
                    var queryableResult = Repository
                                            .GetAll()
                                            .Where(m => m.Active)
                                            .OrderBy(m => m.Name)
                                            .Select(m => new SelectListItem
                                            {
                                                Text = m.Name,
                                                Value = m.Id.ToString()
                                            });

                    return queryableResult.ToList();
                });
        }
    }
}
