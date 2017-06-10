using Mica.Infrastructure.Extensions;

namespace Mica.Infrastructure.Configuration.Options
{
    public interface ICachingOptions 
    {
        int ExpiredInMinute { get; }
        int SlidingInMinute { get; }
        int RetryInSecond { get; }
    }

    public class CachingOptions : OptionsBase, ICachingOptions
    {
        public CachingOptions(IAppSettings appSettings) : base(appSettings)
        {
        }

        public int ExpiredInMinute => GetInt().Default(5);
        public int SlidingInMinute => GetInt().Default(1);

        public int RetryInSecond => GetInt().Default(10);
    }
}
