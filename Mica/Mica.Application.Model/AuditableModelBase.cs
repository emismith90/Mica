using System;
using System.ComponentModel;

namespace Mica.Application.Models
{
    public abstract class AuditableModelBase<T> : ModelBase<T>
    {
        [DisplayName("Tạo bởi")]
        public Guid? CreatedBy { get; set; }
        [DisplayName("Tạo lúc")]
        public DateTime? CreatedOn { get; set; }

        [DisplayName("Sửa cuối bởi")]
        public Guid? ModifiedBy { get; set; }
        [DisplayName("Sửa cuối lúc")]
        public DateTime? ModifiedOn { get; set; }
    }
}
