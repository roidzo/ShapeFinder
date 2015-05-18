using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using System.Collections;
using QuadShapeFinder.Services.BusinessLogic.Enums;
using Autofac;

namespace QuadShapeFinder.Services.BusinessLogic
{
    public class QuadrilateralIdentifier : IQuadrilateralIdentifier
    {
        private readonly ILogger _logger;
        
        public QuadrilateralIdentifier(ILogger logger)
        {
            _logger = logger;
        }


        public virtual QuadTypeEnum GetQuadrilateralType(IQuadrilateral quadrilateral)
        {
            int numberOfPairsOfCongruentAngles = NumberOfPairsOfCongruentAngles(quadrilateral);
            int numberOfPairsOfCongruentSides = NumberOfPairsOfCongruentSides(quadrilateral);
            int numberOfPairsOfCongruentOppositeSides = NumberOfPairsOfCongruentOppositeSides(quadrilateral);
            bool allSidesCongruent = AllSidesCongruent(quadrilateral);
            bool allAnglesCongruent = AllAnglesCongruent(quadrilateral);
            int numberOfParallelSides = NumberOfParallelSides(quadrilateral);

            if (numberOfPairsOfCongruentSides == 0)
            {
                if (numberOfPairsOfCongruentAngles == 0)
                {
                    return QuadTypeEnum.Quadrilateral;
                }
                else if(numberOfParallelSides==2)
                {
                    return QuadTypeEnum.Trapezoid;
                } 
                else
                {
                    return QuadTypeEnum.UnknownOrInvalid;
                }
            }
            else if (allSidesCongruent)
            {
                if (allAnglesCongruent)
                {
                    return QuadTypeEnum.Square;
                }
                else if (numberOfPairsOfCongruentAngles == 2)
                {
                    return QuadTypeEnum.Rhombus;
                }
                else
                {
                    return QuadTypeEnum.UnknownOrInvalid;
                }
            }
            else if (numberOfPairsOfCongruentSides > 1)
            {
                if (allAnglesCongruent)
                {
                    return QuadTypeEnum.Rectangle;
                }
                else if (numberOfPairsOfCongruentAngles == 1)
                {
                    return QuadTypeEnum.Kite;
                }
                else if (numberOfPairsOfCongruentAngles == 2)
                {
                    return QuadTypeEnum.Parallelogram;
                }
                else
                {
                    return QuadTypeEnum.UnknownOrInvalid;
                }
            }
            else
            {
                if (numberOfParallelSides == 2)
                {
                    if (numberOfPairsOfCongruentOppositeSides == 1)
                    {
                        return QuadTypeEnum.IsoscelesTrapezoid;
                    }
                    else
                    {
                        return QuadTypeEnum.Trapezoid;
                    }
                }
                else
                {
                    return QuadTypeEnum.Quadrilateral;
                }
            }

        }


        private int NumberOfParallelSides(IQuadrilateral quadrilateral)
        {
            if (quadrilateral.Sides.Count != 4) throw new ArgumentOutOfRangeException("Number of sides do not equal 4");

            int parallelSidesCount = 0;
            int[] a = quadrilateral.Angles.Select(i => i.Value).ToArray<int>();

            for (int i = 0; i <= 3; i++)
            {
                if (i == 3)
                {
                    if (a[i] + a[0] == 180)
                    {
                        parallelSidesCount++;
                    }
                }
                else
                {
                    if (a[i] + a[i + 1] == 180)
                    {
                        parallelSidesCount++;
                    }
                }
            }

            return parallelSidesCount;
        }


        private int NumberOfPairsOfCongruentAngles(IQuadrilateral quadrilateral)
        {
            int pairsOfCongruentAnglesCount = 0;

            var results = from a in quadrilateral.Angles
                          group a by a.Value into g
                          where g.Count() > 1
                          select g;

            foreach (var group in results)
                foreach (var item in group)
                    pairsOfCongruentAnglesCount += 1;

            double n = pairsOfCongruentAnglesCount / 2;

            return (int)(Math.Floor(n));
        }


        private int NumberOfPairsOfCongruentSides(IQuadrilateral quadrilateral)
        {
            int pairsOfCongruentSidesCount = 0;

            var results = from s in quadrilateral.Sides
                          group s by s.Value into g
                          where g.Count() > 1
                          select g;

            foreach (var group in results)
                foreach (var item in group)
                    pairsOfCongruentSidesCount += 1;

            double n = pairsOfCongruentSidesCount / 2;

            return (int)(Math.Floor(n));
        }


        private int NumberOfPairsOfCongruentOppositeSides(IQuadrilateral quadrilateral)
        {
            if (quadrilateral.Sides.Count != 4) throw new ArgumentOutOfRangeException("Number of sides do not equal 4");

            int pairsOfCongruentSidesCount = 0;
            double[] a = quadrilateral.Sides.Select(i => i.Value).ToArray<double>();

            if (a[0] == a[2])
                pairsOfCongruentSidesCount++;

            if (a[1] == a[3])
                pairsOfCongruentSidesCount++;

            return pairsOfCongruentSidesCount;
        }


        private bool AllAnglesCongruent(IQuadrilateral quadrilateral)
        {
            var results = from a in quadrilateral.Angles
                          group a by a.Value into g
                          where g.Count() == 4
                          select g;

            return results.Count() == 1;
        }


        private bool AllSidesCongruent(IQuadrilateral quadrilateral)
        {
            var results = from a in quadrilateral.Sides
                          group a by a.Value into g
                          where g.Count() == 4
                          select g;

            return results.Count() == 1;
        }

        
    }
}
