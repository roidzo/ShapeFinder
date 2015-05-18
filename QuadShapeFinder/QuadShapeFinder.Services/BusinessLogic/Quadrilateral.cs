using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuadShapeFinder.Services.BusinessLogic.Enums;
using System.Drawing;
using QuadShapeFinder.Services.Infrastructure;
using Autofac;
using Autofac.Integration.Wcf;

namespace QuadShapeFinder.Services.BusinessLogic
{
    public class Quadrilateral : IQuadrilateral
    {
        public Dictionary<QuadSideNamesEnum, double> Sides { get; private set; }
        public Dictionary<QuadAngleNamesEnum, int> Angles { get; private set; }
        private int _totalAngle;

        private readonly IConfigSettingProvider _configSettingProvider;

        public Quadrilateral(IConfigSettingProvider configSettingProvider)
        {
            _configSettingProvider = configSettingProvider;
        }


        public void Load(double sideA, double sideB, double sideC, double sideD, int angleAB, int angleBC, int angleCD, int angleDA)
        {
            Sides = new Dictionary<QuadSideNamesEnum, double>();
            Sides.Add(QuadSideNamesEnum.A, sideA);
            Sides.Add(QuadSideNamesEnum.B, sideB);
            Sides.Add(QuadSideNamesEnum.C, sideC);
            Sides.Add(QuadSideNamesEnum.D, sideD);

            Angles = new Dictionary<QuadAngleNamesEnum, int>();
            Angles.Add(QuadAngleNamesEnum.AB, angleAB);
            Angles.Add(QuadAngleNamesEnum.BC, angleBC);
            Angles.Add(QuadAngleNamesEnum.CD, angleCD);
            Angles.Add(QuadAngleNamesEnum.DA, angleDA);

            Validate();
        }


        private void Validate()
        {

                if (Sides.Count != 4)
                {
                    throw new ArgumentException("Number of sides is not 4");
                }

                if (Angles.Count != 4)
                {
                    throw new ArgumentException("Number of angles is not 4");
                }

                if (Sides.Where(i => i.Value <= 0).Count() > 0)
                {
                    throw new ArgumentOutOfRangeException("One or more sides have zero length");
                }

                if (Angles.Sum(i => i.Value) != 360)
                {
                    throw new ArgumentException("The sum of all angles is not 360");
                }

                if (Angles.Where(i => i.Value == 90).Count() == 4 && ((Sides[QuadSideNamesEnum.A] != Sides[QuadSideNamesEnum.C]) || (Sides[QuadSideNamesEnum.B] != Sides[QuadSideNamesEnum.D])))
                {
                    throw new ArgumentException("Angles are all 90 degrees but length of opposing sides differ");
                }

                if (_configSettingProvider.EnforceValidationQuadilateralIsClosedShape)
                {
                    if (!FormsAValidClosedQuadrilateral())
                    {
                        throw new ArgumentException("Sides and angles do not form a valid quadrilateral");
                    }
                }
           
        }


        private bool FormsAValidClosedQuadrilateral()
        {
            _totalAngle = 0;
            var p = new PointF(0, 0);
            p = (GetEndPoint(p, Sides[QuadSideNamesEnum.A], Angles[QuadAngleNamesEnum.AB]));
            p = (GetEndPoint(p, Sides[QuadSideNamesEnum.B], Angles[QuadAngleNamesEnum.BC]));
            p = (GetEndPoint(p, Sides[QuadSideNamesEnum.C], Angles[QuadAngleNamesEnum.CD]));
            p = (GetEndPoint(p, Sides[QuadSideNamesEnum.D], Angles[QuadAngleNamesEnum.DA]));
            
            decimal x = Math.Round((Decimal)p.X, 2, MidpointRounding.AwayFromZero);
            decimal y = Math.Round((Decimal)p.Y, 2, MidpointRounding.AwayFromZero);

            if (x == 0 && y == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
   

        private PointF GetEndPoint(PointF startPoint, double length, int angle)
        {
            _totalAngle += 180 - angle;
            float x = startPoint.X + (float)(length * Math.Cos((_totalAngle + angle) * (Math.PI / 180.0)));
            float y = startPoint.Y + (float)(length * Math.Sin((_totalAngle + angle) * (Math.PI / 180.0)));
            return new PointF(x, y);
        }

    }
}
