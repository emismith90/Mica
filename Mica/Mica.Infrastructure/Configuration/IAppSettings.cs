using Microsoft.Extensions.Configuration;

namespace Mica.Infrastructure.Configuration
{
    public interface IAppSettings
    {
        string Get(string key);
        IConfigurationSection GetSection(string section);
    }
}
