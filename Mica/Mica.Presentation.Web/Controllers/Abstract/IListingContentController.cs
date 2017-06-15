using Microsoft.AspNetCore.Mvc;

namespace Mica.Presentation.Web.Controllers.Abstract
{
    public interface IListingContentController
    {
        IActionResult Index(string query, int pageNumber, int pageSize, string orderBy, string orderDirection);
    }
}
