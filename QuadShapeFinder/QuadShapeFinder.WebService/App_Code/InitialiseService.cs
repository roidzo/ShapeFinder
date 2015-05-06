using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using QuadShapeFinder.WebService.Infrastructure;
using Autofac.Integration.Wcf;

namespace QuadShapeFinder.WebService.App_Code
{
    public class InitialiseService
    {
        /// <summary>
        /// Application initialisation method where we register our IOC container.
        /// </summary>
        public static void AppInitialize()
        {
            var container = IoC.CreateContainer();
            AutofacHostFactory.Container = container;
        }
    }
}
