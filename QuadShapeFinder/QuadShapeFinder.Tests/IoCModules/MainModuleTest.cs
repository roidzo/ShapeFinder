using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Serilog;
using QuadShapeFinder.Services.Infrastructure;
using Moq;

namespace QuadShapeFinder.Tests.IoCModules
{
   public class MainModuleTest : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var logFilePath = new ConfigSettingProvider().LogFilePath;

            var mockConfigSettingProvider = new Mock<IConfigSettingProvider>();
            mockConfigSettingProvider.Setup(m => m.EnforceValidationQuadilateralIsClosedShape).Returns(true);
            var configSettingProvider = mockConfigSettingProvider.Object;

            builder.RegisterInstance(configSettingProvider).As<IConfigSettingProvider>();

            var mockLogger = new Mock<ILogger>().Object;
            builder.RegisterInstance(mockLogger).As<ILogger>();

        }
    }
}
