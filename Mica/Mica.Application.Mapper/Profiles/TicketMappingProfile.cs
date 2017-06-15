using AutoMapper;
using Mica.Domain.Data.Models;
using Mica.Application.Models;

namespace Mica.Application.Mapper.Profiles
{
    public class TicketMappingProfile : Profile
    {
        public TicketMappingProfile()
        {
            this.CreateMap<TicketEntity, TicketModel>().ReverseMap();
        }
    }
}
