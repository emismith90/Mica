using Microsoft.Extensions.Configuration;
using System.IO;

namespace Mica.Infrastructure.Configuration
{
    public class AppSettings : IAppSettings
    {
        protected IConfiguration Configuration;
        public AppSettings()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            builder.AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public string Get(string key)
        {
            return Configuration[key];
        }

        public IConfigurationSection GetSection(string section)
        {
            return Configuration.GetSection(section);
        }
    }
}
