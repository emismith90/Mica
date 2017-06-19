using System;
using Mica.Infrastructure.Models.Abstract;

namespace Mica.Domain.Data.Models.Ticket
{
    public class TicketStatusEntity : EntityBase<long>, ISearchableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int Order { get; set; }

        public string ToSearchableString()
        {
            return $"{Name} {Description}";
        }
    }
}
