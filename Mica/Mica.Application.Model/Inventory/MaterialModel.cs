using System.ComponentModel.DataAnnotations;

namespace Mica.Application.Models.Inventory
{
    public class MaterialModel : ModelBase<long>
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [MaxLength(255)]
        public string Unit { get; set; }

        [Range(0, 1000000000)]
        public decimal UnitPrice { get; set; }
    }
}
