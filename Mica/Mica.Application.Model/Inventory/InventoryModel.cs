using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mica.Application.Models.Inventory
{
    public class InventoryModel : ModelBase<long>
    {
        [Range(0, 1000000000, ErrorMessage = "Phải nằm trong khoảng {1} tới {2}")]
        [DisplayName("Số lượng")]
        public decimal InStock { get; set; }

        [DisplayName("Mã vật tư")]
        public string MaterialCode { get; set; }
        [DisplayName("Tên vật tư")]
        public string MaterialName { get; set; }
    }
}
