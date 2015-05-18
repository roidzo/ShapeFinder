using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using QuadShapeFinder.WebService.IocModules;
using QuadShapeFinder.Services.IocModules;
using Autofac.Integration.Wcf;
using QuadShapeFinder.Tests.IoCModules;

namespace QuadShapeFinder.Tests.Infrastructure
{
    public static class IoCTest
    {
        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<QuadShapeFinder.WebService.IocModules.MainModule>();
            builder.RegisterModule<MainModuleTest>();
            builder.RegisterModule<QuadShapeFinder.Services.IocModules.ServiceModule>();

            var container = builder.Build();
            AutofacHostFactory.Container = container;

            return container;
        }
    }
}
