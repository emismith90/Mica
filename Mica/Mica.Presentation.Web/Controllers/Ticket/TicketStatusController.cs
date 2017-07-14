using Mica.Application.Models.Ticket;
using Mica.Application.Services.Abstract.Ticket;
using Mica.Presentation.Web.Controllers.Abstract;

namespace Mica.Presentation.Web.Controllers.Ticket
{
    public class TicketStatusController : BaseDialogCrudController<TicketStatusModel, long, ITicketStatusService>
    {
        public TicketStatusController(ITicketStatusService ticketStatusService) : base(ticketStatusService) { }
    }
}
