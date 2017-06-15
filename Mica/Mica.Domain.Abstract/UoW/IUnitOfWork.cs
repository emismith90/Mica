using System;

namespace Mica.Domain.Abstract.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IUnitOfWork Commit();
        IUnitOfWork BeginTransaction();
        bool EndTransaction();
        void RollBack();
    }
}
