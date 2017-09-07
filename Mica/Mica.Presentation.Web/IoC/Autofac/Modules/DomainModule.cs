using Antares.Essentials.Data.Repositories;
using Antares.Essentials.Data.UoW;
using Autofac;
using Mica.Domain.Data.Contexts;

namespace Mica.Presentation.Web.Autofac.Modules
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("Mica.Domain.Abstract")), System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("Mica.Domain.EF")))
                 .Where(t => t.Name.EndsWith("Repository"))
                 .AsImplementedInterfaces()
                 .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(GenericRepository<,>))
                        .As(typeof(IGenericRepository<,>))
                        .InstancePerDependency();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>();
            builder.RegisterType(typeof(MicaContext))
                .InstancePerLifetimeScope();
        }
    }
}
