using Autofac;
using Mica.Application.Mapper;

namespace Mica.Infrastructure.IoC.Autofac.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("Mica.Application.Services.Abstract")), System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("Mica.Application.Services")))
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            //// Add application services.
            //services.AddTransient<IEmailSender, AuthMessageSender>();
            //services.AddTransient<ISmsSender, AuthMessageSender>();

            // automapper
            var mapperConfig = AutoMapperConfig.RegisterMappings();
            builder.RegisterInstance(mapperConfig.CreateMapper());
        }
    }
}
