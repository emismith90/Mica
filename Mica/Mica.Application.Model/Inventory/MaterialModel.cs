using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mica.Application.Models.Inventory
{
    public class MaterialModel : ModelBase<long>
    {
        [Required(ErrorMessage = "Trường bắt buộc phải điền")]
        [MaxLength(255, ErrorMessage = "Không được dài quá {1} ký tự")]
        [DisplayName("Tên")]
        public string Name { get; set; }

        [MaxLength(1000, ErrorMessage = "Không được dài quá {1} ký tự")]
        [DisplayName("Mô tả")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Trường bắt buộc phải điền")]
        [MaxLength(255, ErrorMessage = "Không được dài quá {1} ký tự")]
        [DisplayName("Đơn vị")]
        public string Unit { get; set; }

        [Range(0, 1000000000, ErrorMessage = "Phải nằm trong khoảng {1} tới {2}")]
        [DisplayName("Giá/Đơn vị")]
        public decimal UnitPrice { get; set; }
    }
}
