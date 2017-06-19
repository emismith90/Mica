using Mica.Application.Models.Effort;

namespace Mica.Application.Services.Abstract.Effort
{
    public interface IEffortOperationService : 
        ICrudService<EffortOperationModel, long>, 
        IContentListingService<EffortOperationModel>, 
        IContentLookupListingService<EffortOperationModel>
    {
    }
}
