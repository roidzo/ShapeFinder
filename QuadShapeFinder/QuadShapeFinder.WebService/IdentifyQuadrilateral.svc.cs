using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Serilog;
using QuadShapeFinder.Services.Infrastructure;
using QuadShapeFinder.Services.Helpers;
using QuadShapeFinder.Services;

namespace QuadShapeFinder.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class IdentifyQuadrilateral : IIdentifyQuadrilateral
    {
        private readonly ILogger _logger;
        private readonly IQuadrilateralShapeService _quadrilateralService;

        public IdentifyQuadrilateral(ILogger logger, IQuadrilateralShapeService quadrilateralService)
        {
            _logger = logger;
            _quadrilateralService = quadrilateralService;
        }


        public string GetQuadrilateralType(double sideA, double sideB, double sideC, double sideD, int angleAB, int angleBC, int angleCD, int angleDA)
        {
            return EnumHelper.GetEnumDescription(_quadrilateralService.GetQuadrilateralType(sideA, sideB, sideC, sideD, angleAB, angleBC, angleCD, angleDA));
        }
    }
}
