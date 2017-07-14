using AutoMapper;
using Mica.Domain.Data.Models.Ticket;
using Mica.Application.Models.Ticket;

namespace Mica.Application.Mapper.Profiles.Ticket
{
    public class TicketMappingProfile : Profile
    {
        public TicketMappingProfile()
        {
            var map = this.CreateMap<TicketEntity, TicketModel>();

            map.ForMember(m => m.Client, opt => opt.MapFrom(e => e.Client));
            map.ForMember(m => m.SaleByName, opt => opt.MapFrom(e => e.SaleBy.UserName));
            map.ForMember(m => m.StatusName, opt => opt.MapFrom(e => e.Status.Name));
            map.ForMember(m => m.PersonInChargeName, opt => opt.MapFrom(e => e.PersonInCharge.UserName));

            this.CreateMap<TicketModel, TicketEntity>();
        }
    }
}
