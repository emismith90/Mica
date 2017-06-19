using AutoMapper;
using Mica.Application.Models.Effort;
using Mica.Domain.Data.Models.Effort;

namespace Mica.Application.Mapper.Profiles.Effort
{
    public class EffortOperationMappingProfile : Profile
    {
        public EffortOperationMappingProfile()
        {
            this.CreateMap<EffortOperationEntity, EffortOperationModel>().ReverseMap();
        }
    }
}
