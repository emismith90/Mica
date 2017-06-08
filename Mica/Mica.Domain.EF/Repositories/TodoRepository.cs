using System;
using Mica.Domain.Data.Contexts;
using Mica.Domain.Abstract.Repositories;
using Mica.Domain.Data.Models;

namespace Mica.Domain.EF.Repositories
{
    public class TodoRepository : GenericRepository<TodoEntity, Guid>, ITodoRepository
    {
        public TodoRepository(MicaContext context) : base(context)
        {
        }

        public void SetStatus(Guid id, bool isActive)
        {
            var todoItem = this.GetById(id);
            todoItem.IsActive = isActive;

            this.Update(todoItem);
        }
    }
}
