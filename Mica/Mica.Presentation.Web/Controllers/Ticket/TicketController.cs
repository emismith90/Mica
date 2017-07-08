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

        protected override object GetAddEditViewModel(long id)
        {
            return new TicketAddEditViewModel
            {
                Model = this.Service.CreateDefaultObject(),

                Clients = this._clientService.GetForPickup(),

                Statuses = this._ticketStatusService.GetForPickup(),

                Sales = this._userService.GetForPickup(),
                PersonInCharges = this._userService.GetForPickup(),

                Materials = this._materialService.GetAll(),
                InventoryOperations = new List<InventoryOperationModel>
                {
                    this._inventoryOperationService.CreateDefaultObject()
                },

                Efforts = this._effortService.GetAll(),
                EffortOperations = new List<EffortOperationModel>
                {
                    this._effortOperationService.CreateDefaultObject()
                }
            };
        }

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
            }

            return Index(null);
        }
    }
}
