using System;

namespace Mica.Domain.Data.Models.Inventory
{
    public class MaterialEntity : EntityBase<long>
    {
        // Empty constructor for EF
        protected MaterialEntity() { }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
