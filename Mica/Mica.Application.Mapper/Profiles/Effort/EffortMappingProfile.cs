using AutoMapper;
using Mica.Application.Models.Effort;
using Mica.Domain.Data.Models.Effort;

namespace Mica.Application.Mapper.Profiles.Effort
{
    public class EffortMappingProfile : Profile
    {
        public EffortMappingProfile()
        {
            this.CreateMap<EffortEntity, EffortModel>().ReverseMap();
        }
    }
}
