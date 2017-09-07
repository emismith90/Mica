using Autofac;
using Mica.Application.Mapper;
using Mica.Application.Services.Abstract.Cache;
using Mica.Application.Services.Cache;

namespace Mica.Presentation.Web.Autofac.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("Mica.Application.Services.Abstract")), System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("Mica.Application.Services")))
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(TypedCacheService<,>))
                       .As(typeof(ITypedCacheService<,>))
                       .InstancePerDependency();

            //// Add application services.
            //services.AddTransient<IEmailSender, AuthMessageSender>();
            //services.AddTransient<ISmsSender, AuthMessageSender>();

            // automapper
            var mapperConfig = AutoMapperConfig.RegisterMappings();
            builder.RegisterInstance(mapperConfig.CreateMapper());
        }
    }
}
