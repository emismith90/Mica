using AutoMapper;
using Mica.Domain.Data.Models.Inventory;
using Mica.Application.Models.Inventory;

namespace Mica.Application.Mapper.Profiles
{
    public class MaterialVariantMappingProfile : Profile
    {
        public MaterialVariantMappingProfile()
        {
            this.CreateMap<MaterialVariantEntity, MaterialVariantModel>().ReverseMap();
        }
    }
}
