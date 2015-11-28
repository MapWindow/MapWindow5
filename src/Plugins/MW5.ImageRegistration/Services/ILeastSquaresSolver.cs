using System.Collections.Generic;
using MW5.Api.Interfaces;

namespace MW5.Plugins.ImageRegistration.Services
{
    internal interface ILeastSquaresSolver
    {
        /// <summary>
        /// Calculates coefficents for the affine tranformation of the source to target coordinates
        /// </summary>
        /// <remarks>
        /// X' = A + B*X + C*Y
        /// Y' = D + E*X + F*Y
        /// X,Y - source; X',Y' - target; A,B,C,D,E,F - result
        /// </remarks>
        double[] Calculate(IList<ICoordinate> source, IList<ICoordinate> target);
    }
}
