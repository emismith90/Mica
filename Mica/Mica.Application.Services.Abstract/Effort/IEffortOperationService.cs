using Mica.Application.Models.Effort;
using System.Collections.Generic;

namespace Mica.Application.Services.Abstract.Effort
{
    public interface IEffortOperationService : 
        ICrudService<EffortOperationModel, long>, 
        IContentListingService<EffortOperationModel>, 
        IContentLookupListingService<EffortOperationModel>
    {
        IList<EffortOperationModel> FindByTicket(long ticketId);
    }
}
