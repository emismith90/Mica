using System.Collections.Generic;
using Antares.Essentials.Application.Services;
using Mica.Application.Models.Effort;

namespace Mica.Application.Services.Abstract.Effort
{
    public interface IEffortOperationService : 
        ICrudService<EffortOperationModel, long>, 
        IContentListingService<EffortOperationModel>, 
        IContentLookupListingService<EffortOperationModel>,
        IModelCreatorService<EffortOperationModel>
    {
        IList<EffortOperationModel> FindByTicket(long ticketId);
    }
}
