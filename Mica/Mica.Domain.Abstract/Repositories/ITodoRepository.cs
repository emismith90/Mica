using System;
using Mica.Domain.Data.Models;

namespace Mica.Domain.Abstract.Repositories
{
    public interface ITodoRepository : IGenericRepository<TodoEntity, Guid> 
    {
        void SetStatus(Guid id, bool isActive);
    }
}
