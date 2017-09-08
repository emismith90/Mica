using Microsoft.AspNetCore.Mvc;

namespace Mica.Presentation.Web.Controllers.Abstract
{
    [Controller]
    public abstract class ApiController : ControllerBase
    {
        [ActionContext]
        public ActionContext ActionContext { get; set; }
    }
}
