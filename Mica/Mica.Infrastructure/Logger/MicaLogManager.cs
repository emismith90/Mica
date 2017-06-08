using Mica.Infrastructure.Configuration.Options;
using Serilog;

namespace Mica.Infrastructure.Logger
{
    public class MicaLogManager : IMicaLogManager
    {
        private readonly LoggingOptions _loggingOptions;
        public MicaLogManager(LoggingOptions loggingOptions)
        {
            this._loggingOptions = loggingOptions;
        }

        public ILogger CreateLogger()
        {
            return new LoggerConfiguration()
                    .Enrich.FromLogContext()
                    .MinimumLevel.Is(this._loggingOptions.LogLevel)
                    .WriteTo.Seq(this._loggingOptions.SeqUrl)
                    .CreateLogger();
        }
    }
}
