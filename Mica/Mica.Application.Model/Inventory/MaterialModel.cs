using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mica.Application.Models.Inventory
{
    public class MaterialModel : ModelBase<long>
    {
        [Required]
        [MaxLength(255)]
        [DisplayName("Tên")]
        public string Name { get; set; }

        [MaxLength(1000)]
        [DisplayName("Mô tả")]
        public string Description { get; set; }

        [Required]
        [MaxLength(255)]
        [DisplayName("Đơn vị")]
        public string Unit { get; set; }

        [Range(0, 1000000000)]
        [DisplayName("Giá/Đơn vị")]
        public decimal UnitPrice { get; set; }
    }
}
