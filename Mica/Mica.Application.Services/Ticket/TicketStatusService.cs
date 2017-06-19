﻿using System.Collections.Generic;
using AutoMapper;
using Mica.Domain.Abstract.Repositories;
using Mica.Domain.Abstract.UoW;
using Mica.Application.Services.Abstract.Ticket;
using Mica.Application.Services.Abstract.Cache;
using Mica.Application.Models.Ticket;
using Mica.Domain.Data.Models.Ticket;
using Mica.Infrastructure.Helpers;

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
    }
}
