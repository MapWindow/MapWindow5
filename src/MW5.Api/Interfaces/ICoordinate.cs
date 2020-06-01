// -------------------------------------------------------------------------------------------
// <copyright file="ICoordinate.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;

namespace MW5.Api.Interfaces
{
    /// <summary>
    /// Represents X, Y, Z, M coordinates of a single point.
    /// </summary>
    public interface ICoordinate : IComWrapper
    {
        double M { get; }

        double X { get; }

        double Y { get;}

        double Z { get; }

        ICoordinate Clone();
    }

    public static class ICoordinateExtensions
    {
        public static double Distance(this ICoordinate coordinate, ICoordinate other, bool includeZ = false, bool includeM = false)
        {
            return Math.Sqrt(
                Math.Pow(coordinate.X - other.X, 2) +
                Math.Pow(coordinate.Y - other.Y, 2) +
                (includeZ ? Math.Pow(coordinate.Z - other.Z, 2) : 0) +
                (includeM ? Math.Pow(coordinate.M - other.M, 2) : 0)
            );
        }
    }
}