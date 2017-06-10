using AutoMapper;
using Mica.Domain.Data.Models.Inventory;
using Mica.Application.Models.Inventory;

namespace Mica.Application.Mapper.Profiles
{
    public class InventoryMappingProfile : Profile
    {
        public InventoryMappingProfile()
        {
            this.CreateMap<InventoryEntity, InventoryModel>().ReverseMap();
        }
    }
}
