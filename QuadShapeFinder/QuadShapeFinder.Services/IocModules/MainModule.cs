using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Serilog;
using System.Configuration;
using QuadShapeFinder.Services.Infrastructure;
using Autofac.Integration.Wcf;
using QuadShapeFinder.Services.BusinessLogic;

namespace QuadShapeFinder.Services.IocModules
{
    public class MainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var logFilePath = new ConfigSettingProvider().LogFilePath;

            builder.Register(o => new ConfigSettingProvider()).As<IConfigSettingProvider>();

            builder.Register(c => new LoggerConfiguration()
                //.WriteTo.ColoredConsole()
                .WriteTo.File(logFilePath)
                .CreateLogger()).
                As<ILogger>().SingleInstance();

        }
    }
}
