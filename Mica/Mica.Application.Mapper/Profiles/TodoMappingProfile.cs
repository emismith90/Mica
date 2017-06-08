using AutoMapper;
using Mica.Domain.Data.Models;
using Mica.Application.Models;

namespace Mica.Application.Mapper.Profiles
{
    public class TodoMappingProfile : Profile
    {
        public TodoMappingProfile()
        {
            this.CreateMap<TodoEntity, TodoModel>().ReverseMap();
        }
    }
}
