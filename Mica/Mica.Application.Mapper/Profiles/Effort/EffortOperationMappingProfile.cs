using AutoMapper;
using Mica.Application.Models.Effort;
using Mica.Domain.Data.Models.Effort;

namespace Mica.Application.Mapper.Profiles.Effort
{
    public class EffortOperationMappingProfile : Profile
    {
        public EffortOperationMappingProfile()
        {
            var map = this.CreateMap<EffortOperationEntity, EffortOperationModel>();

            map.ForMember(m => m.TicketName, opt => opt.MapFrom(e => e.Ticket.Name));
            map.ForMember(m => m.EffortName, opt => opt.MapFrom(e => e.Effort.Name));
            map.ForMember(m => m.EffortUnitPrice, opt => opt.MapFrom(e => e.Effort.UnitPrice));

            this.CreateMap<EffortOperationModel, EffortOperationEntity>();
        }
    }
}
