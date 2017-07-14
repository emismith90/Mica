using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mica.Application.Models.Effort;
using Mica.Application.Models.Inventory;

namespace Mica.Application.Models.Ticket
{
    public class TicketAddEditViewModel
    {
        public TicketAddEditViewModel(TicketModel ticket)
        {
            Model = ticket;
        }

        public TicketModel Model { get; set; }

        public IList<SelectListItem> Sales { get; set; }
        public IList<SelectListItem> PersonInCharges { get; set; }
        public IList<SelectListItem> Clients { get; set; }
        public IList<SelectListItem> Statuses { get; set; }

        #region for inventory
        public IList<MaterialModel> Materials { get; set; }
        #endregion

        #region for efforts
        public IList<EffortModel> Efforts { get; set; }
        #endregion
    }
}
