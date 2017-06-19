using System;
using System.Collections.Generic;
using Mica.Application.Models.Client;
using Mica.Application.Models.Effort;
using Mica.Application.Models.Inventory;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mica.Application.Models.Ticket
{
    public class TicketModel : AuditableModelBase<long>
    {
        [MaxLength(255, ErrorMessage = "Không được dài quá {1} ký tự")]
        [DisplayName("Tên")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Kinh doanh")]
        public string SaleById { get; set; }

        [DisplayName("Khách hàng")]
        [Required]
        public long ClientId { get; set; }

        [DisplayName("Trạng thái")]
        [Required]
        public long StatusId { get; set; }

        [DisplayName("Thời hạn hoàn thành")]
        [Required]
        public DateTime Deadline { get; set; }

        [Required(ErrorMessage = "Trường bắt buộc phải điền")]
        [Range(0, 1000000000, ErrorMessage = "Phải nằm trong khoảng {1} tới {2}")]
        [DisplayName("Số lượng")]
        public decimal Quantity { get; set; }

        [MaxLength(1000, ErrorMessage = "Không được dài quá {1} ký tự")]
        [DisplayName("Ghi chú")]
        public string Note { get; set; }

        public IList<EffortOperationModel> EffortOperations { get; set; }
        public IList<InventoryOperationModel> InventoryOperations { get; set; }

        public ClientModel Client { get; set; }

        [DisplayName("Trạng thái")]
        public string StatusName { get; set; }

        [DisplayName("Kinh doanh")]
        public string SaleByName { get; set; }
    }
}
