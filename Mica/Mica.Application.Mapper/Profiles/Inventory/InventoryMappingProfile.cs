using AutoMapper;
using Mica.Domain.Data.Models.Inventory;
using Mica.Application.Models.Inventory;

namespace Mica.Application.Mapper.Profiles.Inventory
{
    public class InventoryMappingProfile : Profile
    {
        public InventoryMappingProfile()
        {
            var map = this.CreateMap<InventoryEntity, InventoryModel>();

            map.ForMember(m => m.MaterialName, opt => opt.MapFrom(e => e.Material.Name));
            map.ForMember(m => m.MaterialCode, opt => opt.MapFrom(e => e.Material.Code));

            this.CreateMap<InventoryModel, InventoryEntity>();
        }
    }
}
