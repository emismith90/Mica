using Serilog;

namespace Mica.Infrastructure.Logger
{
    public interface IMicaLogManager 
    {
        ILogger CreateLogger();
    }
}
