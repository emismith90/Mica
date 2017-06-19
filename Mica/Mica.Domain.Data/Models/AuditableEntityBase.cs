using System;
using Mica.Infrastructure.Models.Abstract;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Mica.Domain.Data.Models
{
    public abstract class AuditableEntityBase<T> : EntityBase<T>, IAuditableEntity
    {
        public string CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }

        public string ModifiedById { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual IdentityUser CreatedBy { get; set; }
        public virtual IdentityUser ModifiedBy { get; set; }
    }
}
