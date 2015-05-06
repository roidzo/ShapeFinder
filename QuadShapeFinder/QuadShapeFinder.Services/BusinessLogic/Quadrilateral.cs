using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuadShapeFinder.Services.BusinessLogic.Enums;

namespace QuadShapeFinder.Services.BusinessLogic
{
    public class Quadrilateral : IQuadrilateral
    {
        public Dictionary<QuadSideNamesEnum, double> Sides { get; private set; }
        public Dictionary<QuadAngleNamesEnum, int> Angles { get; private set; }

        public Quadrilateral(double sideA, double sideB, double sideC, double sideD, int angleAB, int angleBC, int angleCD, int angleDA)
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


        public void Validate()
        {
            if (Sides.Count != 4)
            {
                throw new ArgumentException("Number of sides are not 4");
            }

            if (Angles.Count != 4)
            {
                throw new ArgumentException("Number of angles are not 4");
            }

            if (Sides.Where(i => i.Value <= 0).Count() > 0)
            {
                throw new ArgumentOutOfRangeException("One or more sides have zero length");
            }

            if (Angles.Sum(i => i.Value) != 360)
            {
                throw new ArgumentException("The sum of all angles is not 360");
            }

            if (Angles.Where(i => i.Value == 90).Count()==4 && ((Sides[QuadSideNamesEnum.A] != Sides[QuadSideNamesEnum.C]) || (Sides[QuadSideNamesEnum.B] != Sides[QuadSideNamesEnum.D])))
            {
                throw new ArgumentException("Angles are all 90 degrees but length of opposing sides differ");
            }

        }
    }
}
