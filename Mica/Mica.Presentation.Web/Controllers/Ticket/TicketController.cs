using Mica.Application.Models.Ticket;
using Mica.Application.Services.Abstract.Ticket;
using Mica.Presentation.Web.Controllers.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Mica.Presentation.Web.Controllers.Ticket
{
    public class TicketController : BaseCrudController<TicketModel, long, ITicketService>
    {
        public TicketController(ITicketService ticketService) : base(ticketService) { }

        public override IActionResult DeleteView(long id)
        {
            return PartialView("DeleteDialog", GetDeleteViewModel(id));
        }

        public virtual IActionResult SaveAndRedirect(TicketModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    this.Service.Add(model);
                }
                else
                {
                    this.Service.Update(model);
                }
            }

            return Index(null);
        }
    }
}
