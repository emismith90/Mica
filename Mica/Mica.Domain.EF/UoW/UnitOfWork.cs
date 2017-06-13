using System;
using Mica.Domain.Data.Contexts;
using Mica.Domain.Abstract.UoW;
using Microsoft.EntityFrameworkCore.Storage;

namespace Mica.Domain.EF.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MicaContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(MicaContext context)
        {
            _context = context;
        }
        public IUnitOfWork BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
            return this;
        }

        public IUnitOfWork Commit()
        {
            _context.SaveChanges();
            return this;
        }

        public bool EndTransaction()
        {
            _context.SaveChanges();
            _transaction.Commit();
            
            return true;
        }

        public void RollBack()
        {
            _transaction.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
