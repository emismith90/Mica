using AutoMapper;
using Mica.Application.Models.Client;
using Mica.Domain.Data.Models.Client;

namespace Mica.Application.Mapper.Profiles.Effort
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            this.CreateMap<ClientEntity, ClientModel>().ReverseMap();
        }
    }
}
