using Mica.Domain.Data.Models.Client;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace Mica.Domain.Data.Models.Ticket
{
    public class TicketEntity : AuditableEntityBase<long>
    {
        public string Name { get; set; }

        public string SaleById { get; set; }
        public long ClientId { get; set; }
        public long StatusId { get; set; }

        public DateTime Deadline { get; set; }
        public decimal Quantity { get; set; }

        public string Note { get; set; }


        public virtual ClientEntity Client { get; set; }
        public virtual TicketStatusEntity Status { get; set; }
        public virtual IdentityUser SaleBy { get; set; }
    }
}
