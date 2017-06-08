using Mica.Infrastructure.Extensions;

namespace Mica.Infrastructure.Configuration.Options
{
    public class CachingOptions : OptionsBase
    {
        public CachingOptions(IAppSettings appSettings) : base(appSettings)
        {
        }

        public int ExpiredInMinute => GetInt().Default(5);
        public int SlidingInMinute => GetInt().Default(1);

        public int RetryInSecond => GetInt().Default(10);
    }
}
