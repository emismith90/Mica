using Mica.Domain.Abstract.Repositories.Client;
using Mica.Domain.Data.Contexts;
using Mica.Domain.Data.Models.Client;

namespace Mica.Domain.EF.Repositories.Client
{
    public class ClientRepository : GenericRepository<ClientEntity, long>, IClientRepository
    {
        public ClientRepository(MicaContext context) : base(context)
        {
        }

        public override ClientEntity CreateDefaultObject()
        {
            return new ClientEntity();
        }
    }
}
