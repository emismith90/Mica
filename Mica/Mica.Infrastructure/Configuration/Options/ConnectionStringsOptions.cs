using System.Runtime.CompilerServices;

namespace Mica.Infrastructure.Configuration.Options
{
    public class ConnectionStringsOptions : OptionsBase
    {
        public ConnectionStringsOptions(IAppSettings appSettings) : base(appSettings)
        {
        }

        public string MicaConnection => GetString();
    }
}
