using System;

namespace Mica.Infrastructure.Models.Abstract
{
    public interface IAuditableEntity
    {
        string CreatedById { get; set; }
        DateTime? CreatedOn { get; set; }

        string ModifiedById { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}
