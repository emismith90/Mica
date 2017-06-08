using System;
using System.Collections.Generic;
using Mica.Application.Models;

namespace Mica.Application.Services.Abstract.Sample
{
    public interface ITodoService
    {
        TodoModel GetById(Guid id);
        IList<TodoModel> GetAll();
        void Add(TodoModel todo);
        void Update(TodoModel todo);
        void Remove(Guid id);
        void SetStatus(Guid id, bool isActive);
    }
}
