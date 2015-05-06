using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuadShapeFinder.Services.BusinessLogic.Enums;

namespace QuadShapeFinder.Services
{
    public interface IQuadrilateralShapeService
    {
        QuadTypeEnum GetQuadrilateralType(double sideA, double sideB, double sideC, double sideD, int angleAB, int angleBC, int angleCD, int angleDA);
    }
}
