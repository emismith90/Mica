using System;

namespace Mica.Domain.Data.Models.Abstract
{
    interface IAuditableEntity
    {
        Guid? CreatedBy { get; }
        DateTime? CreatedOn { get; }

        Guid? ModifiedBy { get; }
        DateTime? ModifiedOn { get; }
    }
}
