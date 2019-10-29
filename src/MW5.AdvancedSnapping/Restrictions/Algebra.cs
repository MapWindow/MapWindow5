using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.AdvancedSnapping.Restrictions
{
    public static class Algebra
    {
        /// <summary>
        /// line Ax + By + C = 0
        /// circle at origin with radius r
        /// </summary>
        public static IEnumerable<ICoordinate> GetIntersectionForCircleAtOriginWithLines(double r, double a, double b, double c)
        {
            double x0 = -a * c / (a * a + b * b), y0 = -b * c / (a * a + b * b);
            if (c * c > r * r * (a * a + b * b) + double.Epsilon)
                yield break; // no points
            else if (Math.Abs(c * c - r * r * (a * a + b * b)) < double.Epsilon)
            {
                yield return new Coordinate(x0, y0);
            }
            else
            {
                double d = r * r - c * c / (a * a + b * b);
                double mult = Math.Sqrt(d / (a * a + b * b));
                double ax, ay, bx, by;
                ax = x0 + b * mult;
                bx = x0 - b * mult;
                ay = y0 - a * mult;
                by = y0 + a * mult;
                yield return new Coordinate(ax, ay);
                yield return new Coordinate(bx, by);
            }
            yield break;
        }

        public static double CalculateSlope(ICoordinate original, ICoordinate anchor)
        {
            if (Math.Abs(original.X - anchor.X) < double.Epsilon)
                return double.PositiveInfinity;
            else
                return (original.Y - anchor.Y) / (original.X - anchor.X);
        }

        public static double CalculateNormalSlope(ICoordinate original, ICoordinate anchor)
        {
            if (Math.Abs(original.Y - anchor.Y) < double.Epsilon)
                return double.PositiveInfinity;
            else
            {
                return -(original.X - anchor.X) / (original.Y - anchor.Y);
            }
        }


        public static ICoordinate PointBetweenPoints(ICoordinate coordinateA, ICoordinate coordinateB, double offset = 0.5)
        {
            return new Coordinate(
                coordinateA.X + offset * (coordinateB.X - coordinateA.X),
                coordinateA.Y + offset * (coordinateB.Y - coordinateA.Y)
            );
        }

        internal static double CalculateBearing(ICoordinate anchor, ICoordinate anchor2)
        {
            if (Math.Abs(anchor2.X - anchor.X) < double.Epsilon)
                return anchor2.Y >= anchor.Y ? 0 : Math.PI;
            else
                return Math.PI * 0.5 - Math.Atan((anchor2.Y - anchor.Y) / (anchor2.X - anchor.X));
        }

        internal static ICoordinate OffsetCoordinate(ICoordinate anchor, double angle, double offset)
        {
            return new Coordinate(anchor.X + Math.Cos(angle) * offset, anchor.Y + Math.Sin(angle) * offset);
        }
    }
}
