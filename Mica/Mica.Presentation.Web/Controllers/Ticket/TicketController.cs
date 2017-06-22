using Mica.Application.Models.Ticket;
using Mica.Application.Services.Abstract.Ticket;
using Mica.Presentation.Web.Controllers.Abstract;

namespace Mica.Presentation.Web.Controllers.Ticket
{
    public class TicketController : BaseCrudController<TicketModel, long, ITicketService>
    {
        public TicketController(ITicketService ticketService) : base(ticketService) { }
    }
}
