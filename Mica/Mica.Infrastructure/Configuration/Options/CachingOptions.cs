using Antares.Essentials.Configuration;

namespace Mica.Infrastructure.Configuration.Options
{
    public class CachingOptions : Antares.Essentials.Caching.Configurations.CachingOptions
    {
        public CachingOptions(IAppSettings scope) : base(scope)
        {
        }
    }
}
