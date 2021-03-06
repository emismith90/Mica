﻿using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Mica.Presentation.Web.Autofac.Modules;

namespace Mica.Presentation.Web.IoC.Autofac
{
    public class AutofacIoCManager : IApplicationContainerManager
    {
        public virtual IContainer Container { get; set; }
        public void Dispose()
        {
            if(Container != null)
            {
                Container.Dispose();
            }
        }
        public IServiceProvider PopulateAndGetServiceProvider(IEnumerable<ServiceDescriptor> descriptors)
        {
            var builder = GetContainerBuilder();
            builder.Populate(descriptors);
            Container = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(Container);
        }
        private static ContainerBuilder GetContainerBuilder()
        {
            // Create the container builder.
            var builder = new ContainerBuilder();

            // Register dependencies, populate the services from
            // the collection, and build the container. If you want
            // to dispose of the container at the end of the app,
            // be sure to keep a reference to it as a property or field.
            builder.RegisterModule(new InfrastructureModule());
            builder.RegisterModule(new DomainModule());
            builder.RegisterModule(new ApplicationModule());

            return builder;
        }
    }
}
