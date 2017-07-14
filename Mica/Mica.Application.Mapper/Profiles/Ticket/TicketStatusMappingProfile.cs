using AutoMapper;
using Mica.Domain.Data.Models.Ticket;
using Mica.Application.Models.Ticket;

namespace Mica.Application.Mapper.Profiles.Ticket
{
    public class TicketStatusMappingProfile : Profile
    {
        public TicketStatusMappingProfile()
        {
            this.CreateMap<TicketStatusEntity, TicketStatusModel>().ReverseMap();
        }
    }
}
