using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuadShapeFinder.Services.BusinessLogic.Enums;
using QuadShapeFinder.Services.BusinessLogic;

namespace QuadShapeFinder.Tests.Core
{
    public class QuadrilateralBuilder
    {
        //private readonly QuadTypeEnum quadrilateralType;

        public QuadrilateralBuilder()
        {
            //quadrilateralType = quadrilateralType;
        }

        public IQuadrilateral Build(QuadTypeEnum quadrilateralType)
        {
            IQuadrilateral q;

            switch (quadrilateralType)
            {
                case QuadTypeEnum.UnknownOrInvalid:
                    q = new Quadrilateral(11, 1, 1, 1, 190, 90, 90, 90); //TODO: Cannot create an unknown type without error.
                    break;
                case QuadTypeEnum.Parallelogram:
                    q = new Quadrilateral(2, 3, 2, 3, 45, 135, 45, 135);
                    break;
                case QuadTypeEnum.Rectangle:
                    q = new Quadrilateral(4, 2, 4, 2, 90, 90, 90, 90);
                    break;
                case QuadTypeEnum.Rhombus:
                    q = new Quadrilateral(2, 2, 2, 2, 45, 135, 45, 135);
                    break;
                case QuadTypeEnum.Square:
                    q = new Quadrilateral(2, 2, 2, 2, 90, 90, 90, 90);
                    break;
                case QuadTypeEnum.Kite:
                    q = new Quadrilateral(1, 1, 3, 3, 30, 140, 50, 140);
                    break;
                case QuadTypeEnum.Trapezoid:
                    q = new Quadrilateral(5, 4, 4, 6, 120, 60, 90, 90);
                    break;
                case QuadTypeEnum.IsoscelesTrapezoid:
                    q = new Quadrilateral(2, 3, 4, 3, 45, 135, 135, 45);
                    break;
                case QuadTypeEnum.Quadrilateral:
                    q = new Quadrilateral(4, 4, 7, 5, 160, 30, 70, 100);
                    break;
                default:
                    q = new Quadrilateral(4, 4, 7, 5, 160, 30, 70, 100);
                    break;
            }

            return q;
        }

        public IQuadrilateral BuildInvalidAngle(QuadTypeEnum quadrilateralType)
        {
            IQuadrilateral q;
            q = new Quadrilateral(1, 1, 1, 1, 90, 90, 90, 90);

            return q;
        }

        public IQuadrilateral BuildInvalidLength(QuadTypeEnum quadrilateralType)
        {
            IQuadrilateral q;
            
            switch (quadrilateralType)
            {
                case QuadTypeEnum.UnknownOrInvalid:
                    q = new Quadrilateral(11, 0, -11, 1, 190, 90, 90, 90); 
                    break;
                case QuadTypeEnum.Parallelogram:
                    q = new Quadrilateral(2, 3, 3, 3, 45, 135, 45, 135);
                    break;
                case QuadTypeEnum.Rectangle:
                    q = new Quadrilateral(4, 2, 5, 2, 90, 90, 90, 90);
                    break;
                case QuadTypeEnum.Rhombus:
                    q = new Quadrilateral(2, 2, 3, 2, 45, 135, 45, 135);
                    break;
                case QuadTypeEnum.Square:
                    q = new Quadrilateral(2, 2, 1, 2, 90, 90, 90, 90);
                    break;
                case QuadTypeEnum.Kite:
                    q = new Quadrilateral(2, 1, 3, 3, 30, 140, 50, 140);
                    break;
                case QuadTypeEnum.Trapezoid:
                    q = new Quadrilateral(4, 4, 4, 6, 120, 60, 90, 90);
                    break;
                case QuadTypeEnum.IsoscelesTrapezoid:
                    q = new Quadrilateral(3.1, 3, 4, 3, 45, 135, 135, 45);
                    break;
                case QuadTypeEnum.Quadrilateral:
                    q = new Quadrilateral(0, 4, 7, 5, 160, 30, 70, 100);
                    break;
                default:
                    q = new Quadrilateral(0, 4, 7, 5, 160, 30, 70, 100);
                    break;
            }

            return q;
        }

    }
}
