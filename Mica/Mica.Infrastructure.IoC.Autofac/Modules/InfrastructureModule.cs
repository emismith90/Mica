﻿using Microsoft.Extensions.Caching.Memory;
using Autofac;
using Mica.Infrastructure.Caching.Abstract;
using Mica.Infrastructure.Caching.Memory;
using Mica.Infrastructure.Configuration;
using Mica.Infrastructure.Configuration.Options;
using Mica.Infrastructure.Logger;

namespace Mica.Infrastructure.IoC.Autofac.Modules
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
            builder.RegisterType<CachingOptions>()
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

            builder.RegisterType<MicaMemoryCache>()
               .As<IMicaCache>()
               .SingleInstance();
        }
    }
}