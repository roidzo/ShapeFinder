using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using QuadShapeFinder.Services.IocModules;

namespace QuadShapeFinder.Services.Infrastructure
{
    public static class IoC
    {
        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<MainModule>();
            builder.RegisterModule<ServiceModule>();
            var container = builder.Build();
            return container;
        }
    }
}
