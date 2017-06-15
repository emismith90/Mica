using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mica.Application.Models.Inventory
{
    public class InventoryOperationModel : AuditableModelBase<long>
    {
        [Required(ErrorMessage = "Trường bắt buộc phải điền")]
        [DisplayName("Vật tư #")]
        public long MaterialId { get; set; }

        [DisplayName("Mã lệnh")]
        public long? TicketId { get; set; }

        [Required(ErrorMessage = "Trường bắt buộc phải điền")]
        [Range(0, 1000000000, ErrorMessage = "Phải nằm trong khoảng {1} tới {2}")]
        [DisplayName("Số lượng")]
        public decimal Quantity { get; set; }

        [MaxLength(1000, ErrorMessage = "Không được dài quá {1} ký tự")]
        [DisplayName("Mô tả")]
        public string Description { get; set; }

        [DisplayName("Mã vật tư")]
        public string MaterialCode { get; set; }
        [DisplayName("Tên vật tư")]
        public string MaterialName { get; set; }
    }
}
