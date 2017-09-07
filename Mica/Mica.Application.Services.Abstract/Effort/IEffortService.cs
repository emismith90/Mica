using Antares.Essentials.Application.Services;
using Mica.Application.Models.Effort;

namespace Mica.Application.Services.Abstract.Effort
{
    public interface IEffortService : 
        ICrudService<EffortModel, long>, 
        IContentListingService<EffortModel>, 
        IContentLookupListingService<EffortModel>,
        IModelCreatorService<EffortModel>
    {
    }
}
