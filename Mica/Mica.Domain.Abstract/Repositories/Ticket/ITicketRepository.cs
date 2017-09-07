using Antares.Essentials.Data.Repositories;
using Mica.Domain.Data.Models.Ticket;

namespace Mica.Domain.Abstract.Repositories.Ticket
{
    public interface ITicketRepository : IGenericRepository<TicketEntity, long> 
    {
    }
}
