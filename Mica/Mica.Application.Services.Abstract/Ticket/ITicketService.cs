using Mica.Application.Models.Ticket;

namespace Mica.Application.Services.Abstract.Ticket
{
    public interface ITicketService : 
        ICrudService<TicketModel, long>, 
        IContentListingService<TicketModel>, 
        IContentLookupListingService<TicketModel>
    {
    }
}
