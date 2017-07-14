using Microsoft.AspNetCore.Mvc;
using Mica.Application.Services.Abstract.Effort;

namespace Mica.Presentation.Web.Controllers.Effort
{
    public class EffortOperationController : Controller
    {
        private readonly IEffortOperationService _service;
        public EffortOperationController(IEffortOperationService service)
        {
            _service = service;
        }

        public virtual IActionResult Index(int pageNumber = 1, int pageSize = 10, string orderBy = "", string orderDirection = "")
        {
            var result = this._service.GetAll(null, pageNumber, pageSize, orderBy, orderDirection);
            return View("Index", result);
        }
    }
}
