using Mica.Presentation.Web.Controllers.Abstract;
using Mica.Application.Models.Client;
using Mica.Application.Services.Abstract.Client;

namespace Mica.Presentation.Web.Controllers.Client
{
    public class ClientController : BaseDialogCrudController<ClientModel, long, IClientService>
    {
        public ClientController(IClientService clientService) : base(clientService) { }
    }
}
