using Autofac;
using Mica.Domain.Data.Contexts;
using Mica.Domain.EF.Repositories;
using Mica.Domain.EF.UoW;
using Mica.Domain.Abstract.Repositories;
using Mica.Domain.Abstract.UoW;

namespace Mica.Infrastructure.IoC.Autofac.Modules
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

            builder.RegisterGeneric(typeof(AuditableRepository<,>))
                      .As(typeof(IAuditableRepository<,>))
                      .InstancePerDependency();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>();
            builder.RegisterType(typeof(MicaContext))
                .InstancePerLifetimeScope();
        }
    }
}
