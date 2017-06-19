using System;
using Mica.Application.Models.Client;

namespace Mica.Application.Models.Ticket
{
    public class TicketModel : AuditableModelBase<long>
    {
        public string Name { get; set; }

        public string SaleById { get; set; }
        public long ClientId { get; set; }
        public long StatusId { get; set; }

        public DateTime Deadline { get; set; }
        public decimal Quantity { get; set; }

        public string Note { get; set; }


        public ClientModel Client { get; set; }
        public string StatusName { get; set; }
        public string SaleByName { get; set; }
    }
}
