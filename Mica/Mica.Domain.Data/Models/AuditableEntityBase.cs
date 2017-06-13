using System;
using Mica.Infrastructure.Models.Abstract;

namespace Mica.Domain.Data.Models
{
    public abstract class AuditableEntityBase<T> : EntityBase<T>, IAuditableEntity
    {
        public AuditableEntityBase()
        {
            CreatedOn = DateTime.Now.ToUniversalTime();
        }

        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
