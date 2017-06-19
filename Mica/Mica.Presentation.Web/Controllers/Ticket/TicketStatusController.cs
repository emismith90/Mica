using Mica.Presentation.Web.Controllers.Abstract;
using Mica.Application.Models.Ticket;
using Mica.Application.Services.Abstract.Ticket;

namespace Mica.Presentation.Web.Controllers.Ticket
{
    public class TicketStatusController : BaseCrudController<TicketStatusModel, long, ITicketStatusService>
    {
        public TicketStatusController(ITicketStatusService ticketStatusService) : base(ticketStatusService) { }
    }
}
