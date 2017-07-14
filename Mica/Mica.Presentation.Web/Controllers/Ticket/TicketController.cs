using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Mica.Presentation.Web.Controllers.Abstract;
using Mica.Application.Services.Abstract.Client;
using Mica.Application.Services.Abstract.Effort;
using Mica.Application.Services.Abstract.Inventory;
using Mica.Application.Services.Abstract.Ticket;
using Mica.Application.Services.Abstract.User;
using Mica.Application.Models.Ticket;
using Mica.Application.Models.Inventory;
using Mica.Application.Models.Effort;

namespace Mica.Presentation.Web.Controllers.Ticket
{
    public class TicketController : BaseCrudController<TicketModel, long, ITicketService>
    {
        private readonly IClientService _clientService;
        private readonly IUserService _userService;
        private readonly ITicketStatusService _ticketStatusService;
        private readonly IMaterialService _materialService;
        private readonly IEffortService _effortService;
        private readonly IInventoryOperationService _inventoryOperationService;
        private readonly IEffortOperationService _effortOperationService;

        public TicketController(
            ITicketService ticketService,
            IClientService clientService,
            IUserService userService,
            ITicketStatusService ticketStatusService,
            IMaterialService materialService,
            IInventoryOperationService inventoryOperationService,
            IEffortService effortService,
            IEffortOperationService effortOperationService) : base(ticketService)
        {
            _clientService = clientService;
            _userService = userService;
            _ticketStatusService = ticketStatusService;
            _materialService = materialService;
            _inventoryOperationService = inventoryOperationService;
            _effortService = effortService;
            _effortOperationService = effortOperationService;
        }

        public IActionResult EditView(long id)
        {
            return PartialView("EditingDialog", new TicketAddEditViewModel(Service.GetById(id))
            {
                Clients = this._clientService.GetForPickup(),

                Statuses = this._ticketStatusService.GetForPickup(),

                Sales = this._userService.GetForPickup(),
                PersonInCharges = this._userService.GetForPickup()
            });
        }

        public IActionResult ReadonlyView(long id)
        {
            return PartialView("ViewDialog", GetReadOnlyViewModel(id));
        }

        public override IActionResult DeleteView(long id)
        {
            return PartialView("DeleteDialog", GetReadOnlyViewModel(id));
        }

        [HttpPost]
        public override StatusCodeResult Save([FromBody]TicketModel ticket)
        {
            if (ModelState.IsValid)
            {
                if (ticket.Id == 0)
                {
                    if (this.Service.Add(ticket)) return Ok();
                }
            }

            return BadRequest();
        }

        public StatusCodeResult Update(TicketModel ticket)
        {
            if (ModelState.IsValid)
            {
                if (ticket.Id != 0)
                {
                    if (this.Service.Update(ticket)) return Ok();
                }
            }

            return BadRequest();
        }

        protected override object GetAddEditViewModel(long id)
        {
            return new TicketAddEditViewModel(this.Service.CreateDefaultObject())
            {
                Clients = this._clientService.GetForPickup(),

                Statuses = this._ticketStatusService.GetForPickup(),

                Sales = this._userService.GetForPickup(),
                PersonInCharges = this._userService.GetForPickup(),

                Materials = this._materialService.GetAll(),
                Efforts = this._effortService.GetAll(),
            };
        }

        protected object GetReadOnlyViewModel(long id)
        {
            return new TicketAddEditViewModel(Service.GetById(id));
        }
    }
}
