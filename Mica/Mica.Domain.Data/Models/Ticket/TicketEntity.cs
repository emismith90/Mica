using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Antares.Essentials.Data.Entities;
using Mica.Domain.Data.Models.Client;

namespace Mica.Domain.Data.Models.Ticket
{
    public class TicketEntity : AuditableEntityBase<long>, ISearchableEntity
    {
        public string Name { get; set; }

        public string SaleById { get; set; }
        public long ClientId { get; set; }

        public long StatusId { get; set; }
        public string PersonInChargeId { get; set; }

        public DateTime OperationDate { get; set; }
        public DateTime Deadline { get; set; }
        public decimal Quantity { get; set; }

        public string Note { get; set; }

        public virtual ClientEntity Client { get; set; }
        public virtual TicketStatusEntity Status { get; set; }
        public virtual IdentityUser SaleBy { get; set; }
        public virtual IdentityUser PersonInCharge { get; set; }

        public string ToSearchableString()
        {
            return $"{Name} {Note} {Client.Name} {SaleBy?.UserName} {Status.Name}";
        }
    }
}
