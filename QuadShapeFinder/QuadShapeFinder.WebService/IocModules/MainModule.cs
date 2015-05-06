using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;


namespace QuadShapeFinder.WebService.IocModules
{
    public class MainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<QuadShapeFinder.WebService.IdentifyQuadrilateral>();

            builder.RegisterType(typeof(IdentifyQuadrilateral))
                .As(typeof(IIdentifyQuadrilateral))
                .SingleInstance()
                ;
        }
    }
}
