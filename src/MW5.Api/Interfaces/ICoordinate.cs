// -------------------------------------------------------------------------------------------
// <copyright file="ICoordinate.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

namespace MW5.Api.Interfaces
{
    /// <summary>
    /// Represents X, Y, Z, M coordinates of a single point.
    /// </summary>
    public interface ICoordinate : IComWrapper
    {
        double M { get; set; }

        double X { get; set; }

        double Y { get; set; }

        double Z { get; set; }

        ICoordinate Clone();
    }
}