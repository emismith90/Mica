using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMapper;
using Antares.Essentials.Data.UoW;
using Antares.Essentials.Data.Repositories;
using Antares.Essentials.Helpers;
using Mica.Application.Services.Abstract.Ticket;
using Mica.Application.Services.Abstract.Cache;
using Mica.Application.Models.Ticket;
using Mica.Domain.Data.Models.Ticket;

namespace Mica.Application.Services.Ticket
{
    public class TicketStatusService : CrudWithSearchServiceBase<long, TicketStatusModel, TicketStatusEntity>, ITicketStatusService
    {
        public TicketStatusService(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ITypedCacheService<TicketStatusModel, long> cache,
            IGenericRepository<TicketStatusEntity, long> repository)
            : base(mapper, unitOfWork, cache, repository)
        {
        }

        public override IList<TicketStatusModel> GetAll(string query, string orderBy, string orderDirection)
        {
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = "Order";
            }

            return base.GetAll(query, orderBy, orderDirection);
        }

        public override IPagedList<TicketStatusModel> GetAll(string query, int pageNumber, int pageSize, string orderBy, string orderDirection)
        {
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = "Order";
            }

            return base.GetAll(query, pageNumber, pageSize, orderBy, orderDirection);
        }

        public virtual IList<SelectListItem> GetForPickup()
        {
            return Cache.GetOrFetchDependKey("GetForPickup",
                () =>
                {
                    var queryableResult = Repository
                                            .GetAll()
                                            .OrderBy(m => m.Order)
                                            .Select(m => new SelectListItem
                                            {
                                                Text = string.Format("{0} ({1})", m.Name, m.Order),
                                                Value = m.Id.ToString()
                                            });

                    return queryableResult.ToList();
                });
        }
    }
}
