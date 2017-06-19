using AutoMapper;
using Mica.Domain.Abstract.Repositories;
using Mica.Domain.Abstract.UoW;
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
    }
}
