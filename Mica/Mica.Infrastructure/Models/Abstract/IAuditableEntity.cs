using System;

namespace Mica.Infrastructure.Models.Abstract
{
    public interface IAuditableEntity
    {
        Guid? CreatedBy { get; set; }
        DateTime? CreatedOn { get; set; }

        Guid? ModifiedBy { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}
