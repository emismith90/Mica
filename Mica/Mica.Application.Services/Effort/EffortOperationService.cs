using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using Antares.Essentials.Helpers;
using Antares.Essentials.Data.UoW;
using Mica.Application.Models.Effort;
using Mica.Domain.Data.Models.Effort;
using Mica.Application.Services.Abstract.Cache;
using Mica.Domain.Abstract.Repositories.Effort;
using Mica.Application.Services.Abstract.Effort;

namespace Mica.Application.Services.Effort
{
    public class EffortOperationService
        : CrudWithSearchServiceBase<long, EffortOperationModel, EffortOperationEntity>, IEffortOperationService
    {
        public EffortOperationService(IMapper mapper,
            IUnitOfWork unitOfWork,
            ITypedCacheService<EffortOperationModel, long> cache,
            IEffortOperationRepository repository)
            : base(mapper, unitOfWork, cache, repository)
        {
        }

        public override IList<EffortOperationModel> GetAll(string query, string orderBy, string orderDirection)
        {
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = "OperationDate";
                orderDirection = "desc";
            }

            return base.GetAll(query, orderBy, orderDirection);
        }

        public override IPagedList<EffortOperationModel> GetAll(string query, int pageNumber, int pageSize, string orderBy, string orderDirection)
        {
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = "OperationDate";
                orderDirection = "desc";
            }

            return base.GetAll(query, pageNumber, pageSize, orderBy, orderDirection);
        }

        public override EffortOperationModel CreateDefaultObject()
        {
            return new EffortOperationModel
            {
                OperationDate = DateTime.Now
            };
        }

        public IList<EffortOperationModel> FindByTicket(long ticketId)
        {
            var cacheKey = $"{Cache.GenericCollectionKey}[ticketid:{ticketId}]";
            return Cache.GetOrFetchDependKey(cacheKey,
                () =>
                {
                    var queryableResult = Repository
                                       .GetAll()
                                       .Where(io => io.TicketId.HasValue && io.TicketId.Value == ticketId);

                    return Mapper
                            .Map<IList<EffortOperationModel>>(queryableResult.ToList());
                });
        }
    }
}
