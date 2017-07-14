using AutoMapper;
using Mica.Application.Mapper.Profiles;
using Mica.Application.Mapper.Profiles.Effort;
using Mica.Application.Mapper.Profiles.Inventory;
using Mica.Application.Mapper.Profiles.Ticket;

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
                cfg.AddProfile(new EffortOperationMappingProfile());

                cfg.AddProfile(new ClientMappingProfile());

                cfg.AddProfile(new TicketMappingProfile());
                cfg.AddProfile(new TicketStatusMappingProfile());
            });
        }
    }
}
