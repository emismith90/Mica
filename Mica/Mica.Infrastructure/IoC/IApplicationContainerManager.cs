using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Mica.Infrastructure.IoC
{
    public interface IApplicationContainerManager : IDisposable
    {
        IServiceProvider PopulateAndGetServiceProvider(IEnumerable<ServiceDescriptor> descriptors);
    }
}
