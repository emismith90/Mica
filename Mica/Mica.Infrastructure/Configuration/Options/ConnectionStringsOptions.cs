using Antares.Essentials.Configuration;

namespace Mica.Infrastructure.Configuration.Options
{
    public interface IConnectionStringsOptions 
    {
        string MicaConnection { get; }
    }

    public class ConnectionStringsOptions : OptionsBase, IConnectionStringsOptions
    {
        public ConnectionStringsOptions(IAppSettings appSettings) : base(appSettings)
        {
        }

        public string MicaConnection => GetString();
    }
}
