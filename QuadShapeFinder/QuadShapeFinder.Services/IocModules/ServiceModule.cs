using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using QuadShapeFinder.Services.BusinessLogic;
using Autofac.Integration.Wcf;
using QuadShapeFinder.Services.Infrastructure;

namespace QuadShapeFinder.Services.IocModules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType(typeof(QuadrilateralIdentifier))
              .As(typeof(IQuadrilateralIdentifier))
              ;

            builder.RegisterType(typeof(QuadrilateralShapeService))
               .As(typeof(IQuadrilateralShapeService))
               ;

            builder.RegisterType(typeof(Quadrilateral))
                .As(typeof(IQuadrilateral))
               ;
 
        }
    }
}
