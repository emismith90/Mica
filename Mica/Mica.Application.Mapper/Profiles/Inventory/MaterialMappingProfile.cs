using AutoMapper;
using Mica.Domain.Data.Models.Inventory;
using Mica.Application.Models.Inventory;

namespace Mica.Application.Mapper.Profiles.Inventory
{
    public class MaterialMappingProfile : Profile
    {
        public MaterialMappingProfile()
        {
            this.CreateMap<MaterialEntity, MaterialModel>().ReverseMap();
        }
    }
}
