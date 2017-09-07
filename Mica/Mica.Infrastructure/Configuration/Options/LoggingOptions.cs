using System;
using Serilog.Events;
using Antares.Essentials.Configuration;
using Antares.Essentials.Extensions;

namespace Mica.Infrastructure.Configuration.Options
{
    public interface ILoggingOptions 
    {
        string SeqUrl { get; }
        LogEventLevel LogLevel { get; }
    }

    public class LoggingOptions : OptionsBase, ILoggingOptions
    {
        public LoggingOptions(IAppSettings appSettings) : base(appSettings)
        {
        }

        public string SeqUrl => GetString().Default(@"http://localhost:5341");
        public LogEventLevel LogLevel
        {
            get
            {
                var level = GetString().Default("Error");
                if (Enum.TryParse(level, out LogEventLevel logEvent))
                {
                    return logEvent;
                }

                return (LogEventLevel)Enum.ToObject(typeof(LogEventLevel), 4);
            }
        }
    }
}
