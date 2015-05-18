using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Serilog;
using QuadShapeFinder.Services.Infrastructure;
using QuadShapeFinder.Services.Helpers;
using QuadShapeFinder.Services;
using Autofac;
using Autofac.Integration.Wcf;

namespace QuadShapeFinder.WebService
{
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
