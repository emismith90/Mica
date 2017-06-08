using System;
using Mica.Domain.Data.Contexts;
using Mica.Domain.Abstract.UoW;

namespace Mica.Domain.EF.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MicaContext _context;

        public UnitOfWork(MicaContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
