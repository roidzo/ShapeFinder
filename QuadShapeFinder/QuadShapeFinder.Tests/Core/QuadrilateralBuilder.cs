using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuadShapeFinder.Services.BusinessLogic.Enums;
using QuadShapeFinder.Services.BusinessLogic;
using QuadShapeFinder.Services.Infrastructure;

namespace QuadShapeFinder.Tests.Core
{
    public class QuadrilateralBuilder
    {
        private readonly IConfigSettingProvider _configSettingProvider;

        public QuadrilateralBuilder(IConfigSettingProvider configSettingProvider)
        {
            _configSettingProvider = configSettingProvider;
        }

        public IQuadrilateral Build(QuadTypeEnum quadrilateralType)
        {
            var quad = new Quadrilateral(_configSettingProvider);

            switch (quadrilateralType)
            {
                case QuadTypeEnum.UnknownOrInvalid:
                    quad.Load(11, 1, 1, 1, 190, 90, 90, 90); 
                    break;
                case QuadTypeEnum.Parallelogram:
                    quad.Load(2, 3, 2, 3, 45, 135, 45, 135);
                    break;
                case QuadTypeEnum.Rectangle:
                    quad.Load(4, 2, 4, 2, 90, 90, 90, 90);
                    break;
                case QuadTypeEnum.Rhombus:
                    quad.Load(2, 2, 2, 2, 50, 130, 50, 130);
                    break;
                case QuadTypeEnum.Square:
                    quad.Load(2, 2, 2, 2, 90, 90, 90, 90);
                    break;
                case QuadTypeEnum.Kite:
                    quad.Load(30, 30, 42.4264068, 42.4264068, 90, 105, 60, 105);
                    break;
                case QuadTypeEnum.Trapezoid:
                    quad.Load(34.64, 12.68, 30, 30, 120, 90, 90, 60);
                    break;
                case QuadTypeEnum.IsoscelesTrapezoid:
                    quad.Load(30, 30, 68.57, 30, 130, 50, 50, 130);
                    break;
                case QuadTypeEnum.Quadrilateral:
                    quad.Load(50, 50, 34.47, 11.68, 45, 85, 100, 130);
                    break;
                default:
                    quad.Load(4, 4, 7, 5, 160, 30, 70, 100);
                    break;
            }

            return quad;
        }


        public IQuadrilateral BuildInvalidLength(QuadTypeEnum quadrilateralType)
        {
            var quad = new Quadrilateral(_configSettingProvider);
            
            switch (quadrilateralType)
            {
                case QuadTypeEnum.UnknownOrInvalid:
                    quad.Load(11, 0, -11, 1, 190, 90, 90, 90); 
                    break;
                case QuadTypeEnum.Parallelogram:
                    quad.Load(2, 3, 3, 3, 45, 135, 45, 135);
                    break;
                case QuadTypeEnum.Rectangle:
                    quad.Load(4, 2, 5, 2, 90, 90, 90, 90);
                    break;
                case QuadTypeEnum.Rhombus:
                    quad.Load(2, 2, 3, 2, 45, 135, 45, 135);
                    break;
                case QuadTypeEnum.Square:
                    quad.Load(2, 2, 1, 2, 90, 90, 90, 90);
                    break;
                case QuadTypeEnum.Kite:
                    quad.Load(2, 1, 3, 3, 30, 140, 50, 140);
                    break;
                case QuadTypeEnum.Trapezoid:
                    quad.Load(4, 4, 4, 6, 120, 60, 90, 90);
                    break;
                case QuadTypeEnum.IsoscelesTrapezoid:
                    quad.Load(3.1, 3, 4, 3, 45, 135, 135, 45);
                    break;
                case QuadTypeEnum.Quadrilateral:
                    quad.Load(0, 4, 7, 5, 160, 30, 70, 100);
                    break;
                default:
                    quad.Load(0, 4, 7, 5, 160, 30, 70, 100);
                    break;
            }

            return quad;
        }

    }
}
