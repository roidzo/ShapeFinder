using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuadShapeFinder.Services.BusinessLogic.Enums;

namespace QuadShapeFinder.Services.BusinessLogic
{
    public interface IQuadrilateral
    {
        Dictionary<QuadSideNamesEnum, double> Sides { get; }
        Dictionary<QuadAngleNamesEnum, int> Angles { get; }
    }
}
