using System;
using Antares.Essentials.Data.Entities;

namespace Mica.Domain.Data.Models.Client
{
    public class ClientEntity : EntityBase<long>, ISearchableEntity
    {
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string Email { get; set; }
        public string SkypeId { get; set; }
        public string YahooId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyAddress { get; set; }
        public string Note { get; set; }

        public string ToSearchableString()
        {
            return $"{Name} {PhoneNumber} {Address} {Company}";
        }
    }
}
