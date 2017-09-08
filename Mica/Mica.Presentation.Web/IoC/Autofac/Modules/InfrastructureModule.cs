using Microsoft.Extensions.Caching.Memory;
using Autofac;
using Antares.Essentials.Caching.Configurations;
using Antares.Essentials.Configuration;
using Mica.Infrastructure.Configuration.Options;
using Mica.Infrastructure.Logger;

namespace Mica.Presentation.Web.Autofac.Modules
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Configuration
            builder.RegisterType<AppSettings>()
               .As<IAppSettings>()
               .SingleInstance();

            builder.RegisterType<ConnectionStringsOptions>()
                 .As<IConnectionStringsOptions>()
                .SingleInstance();
            builder.RegisterType<LoggingOptions>()
                .As<ILoggingOptions>()
                .SingleInstance();
            builder.RegisterType<Mica.Infrastructure.Configuration.Options.CachingOptions>()
                .As<ICachingOptions>()
                .SingleInstance();

            // Logging
            builder.RegisterType<MicaLogManager>()
                 .As<IMicaLogManager>()
                 .SingleInstance();
            
            // Caching
            builder.RegisterType<MemoryCache>()
               .As<IMemoryCache>()
               .SingleInstance();

            builder.RegisterType<Antares.Essentials.Caching.MemoryCache>()
               .As<Antares.Essentials.Caching.ICache>()
               .SingleInstance();
        }
    }
}
