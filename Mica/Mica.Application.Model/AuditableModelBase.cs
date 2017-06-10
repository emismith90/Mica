using System;

namespace Mica.Application.Models
{
    public abstract class AuditableModelBase<T> : ModelBase<T>
    {
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
