using Antares.Essentials.Data.UoW;
using Mica.Domain.Data.Contexts;

namespace Mica.Domain.EF.UoW
{
    public class MicaUnitOfWork : UnitOfWork
    {
        public MicaUnitOfWork(MicaContext context) : base(context)
        {
        }
    }
}
