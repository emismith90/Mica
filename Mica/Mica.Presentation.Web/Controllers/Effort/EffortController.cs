using Mica.Presentation.Web.Controllers.Abstract;
using Mica.Application.Models.Effort;
using Mica.Application.Services.Abstract.Effort;

namespace Mica.Presentation.Web.Controllers.Inventory
{
    public class EffortController : BaseCrudController<EffortModel, long, IEffortService>
    {
        public EffortController(IEffortService effortService) : base(effortService) { }
    }
}
