using System;

namespace Mica.Infrastructure.Models.Abstract
{
    public interface IAuditableEntity
    {
        Guid? CreatedBy { get; }
        DateTime? CreatedOn { get; }

        Guid? ModifiedBy { get; }
        DateTime? ModifiedOn { get; }
    }
}
