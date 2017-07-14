using Mica.Application.Services.Abstract.Inventory;
using Mica.Application.Models.Inventory;
using Mica.Presentation.Web.Controllers.Abstract;

namespace Mica.Presentation.Web.Controllers.Inventory
{
    public class MaterialController : BaseDialogCrudController<MaterialModel, long, IMaterialService>
    {
        public MaterialController(IMaterialService materialService) : base(materialService) { }
    }
}
