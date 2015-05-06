using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuadShapeFinder.Services.IocModules;
using QuadShapeFinder.WebService.IocModules;
using Autofac;

namespace QuadShapeFinder.WebService.Infrastructure
{
    public class IoC
    {
        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<QuadShapeFinder.WebService.IocModules.MainModule>();
            builder.RegisterModule<QuadShapeFinder.Services.IocModules.MainModule>();
            builder.RegisterModule<QuadShapeFinder.Services.IocModules.ServiceModule>();

            var container = builder.Build();
            return container;
        }
    }
}
