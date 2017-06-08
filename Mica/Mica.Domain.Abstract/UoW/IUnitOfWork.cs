using System;

namespace Mica.Domain.Abstract.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
