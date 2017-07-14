using System;
using System.ComponentModel;

namespace Mica.Application.Models
{
    public abstract class AuditableModelBase<T> : ModelBase<T>
    {
        [DisplayName("Tạo bởi")]
        public string CreatedById { get; set; }
        [DisplayName("Tạo lúc")]
        public DateTime? CreatedOn { get; set; }

        [DisplayName("Sửa cuối bởi")]
        public string ModifiedById { get; set; }
        [DisplayName("Sửa cuối lúc")]
        public DateTime? ModifiedOn { get; set; }
    }
}
