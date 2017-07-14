using Microsoft.AspNetCore.Mvc.Rendering;
using Mica.Application.Models.Ticket;

namespace Mica.Application.Services.Abstract.Ticket
{
    public interface ITicketStatusService : 
        ICrudService<TicketStatusModel, long>, 
        IContentListingService<TicketStatusModel>, 
        IContentLookupListingService<TicketStatusModel>,
        IContentPickupService<SelectListItem>
    {
    }
}
