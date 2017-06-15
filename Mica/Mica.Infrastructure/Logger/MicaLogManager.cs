using Mica.Infrastructure.Configuration.Options;
using Serilog;

namespace Mica.Infrastructure.Logger
{
    public class MicaLogManager : IMicaLogManager
    {
        private readonly ILoggingOptions _loggingOptions;
        public MicaLogManager(ILoggingOptions loggingOptions)
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
