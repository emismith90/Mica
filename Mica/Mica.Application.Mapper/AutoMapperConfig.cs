using AutoMapper;
using Mica.Application.Mapper.Profiles;
using Mica.Application.Mapper.Profiles.Effort;
using Mica.Application.Mapper.Profiles.Inventory;

namespace Mica.Application.Mapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InventoryMappingProfile());
                cfg.AddProfile(new InventoryOperationMappingProfile());
                cfg.AddProfile(new MaterialMappingProfile());

                cfg.AddProfile(new EffortMappingProfile());

                cfg.AddProfile(new TicketMappingProfile());
            });
        }
    }
}
