using Antares.Essentials.Data.Entities;

namespace Mica.Domain.Data.Models.Effort
{
    public class EffortEntity : EntityBase<long>, ISearchableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }

        public bool Active { get; set; }

        public string ToSearchableString()
        {
            return $"{Name} {Description}";
        }
    }
}
