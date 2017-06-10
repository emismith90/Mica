using AutoMapper;
using Mica.Domain.Data.Models.Inventory;
using Mica.Application.Models.Inventory;

namespace Mica.Application.Mapper.Profiles
{
    public class InventoryOperationMappingProfile : Profile
    {
        public InventoryOperationMappingProfile()
        {
            this.CreateMap<InventoryOperationEntity, InventoryOperationModel>().ReverseMap();
        }
    }
}
