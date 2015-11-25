using System.Collections.Generic;
using MW5.Api.Interfaces;

namespace MW5.Plugins.Toolbox.Services
{
    internal class GaussEliminationSolver : ILeastSquaresSolver
    {
        /// <summary>
        /// Calculates coefficents for the affine tranformation of the source to target coordinates
        /// </summary>
        /// <remarks>
        /// X' = A + B*X + C*Y
        /// Y' = D + E*X + F*Y
        /// X,Y - source; X',Y' - target; A,B,C,D,E,F - result
        /// </remarks>
        public double[] Calculate(IList<ICoordinate> source, IList<ICoordinate> target)
        {
            if (source.Count != target.Count)
            {
                return null;
            }

            double sx, sy, sx2, sy2, sxy, sxX, syX, sxY, syY, sX, sY;
            double n = sx = sy = sx2 = sy2 = sxy = sxX = syX = sxY = syY = sX = sY = 0.0;

            for (int i = 0; i < source.Count; i++)
            {
                n++;
                sx += source[i].X;
                sy += source[i].Y;
                sX += target[i].X;
                sY += target[i].Y;
                sxy += source[i].X * source[i].Y;
                sx2 += source[i].X * source[i].X;
                sy2 += source[i].Y * source[i].Y;
                sxX += source[i].X * target[i].X;
                sxY += source[i].X * target[i].Y;
                syX += source[i].Y * target[i].X;
                syY += source[i].Y * target[i].Y;
            }

            var A = new double[6, 7];

            A[0, 0] = n;
            A[0, 1] = sx;
            A[0, 2] = sy;

            A[1, 0] = sx;
            A[1, 1] = sx2;
            A[1, 2] = sxy;

            A[2, 0] = sy;
            A[2, 1] = sxy;
            A[2, 2] = sy2;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    A[i, 3 + j] = 0.0;
                    A[i + 3, j] = 0.0;
                    A[i + 3, j + 3] = A[i, j];
                }
            }

            A[0, 6] = sX;
            A[1, 6] = sxX;
            A[2, 6] = syX;
            A[3, 6] = sY;
            A[4, 6] = sxY;
            A[5, 6] = syY;

            return GaussElimination(6, A);
        }

        /// <summary> Implements a Gaussian elimination on the given matrix. The matrix
        /// <code>a</code> should be n rows by n+1 columns. Column <code>n+1</code> being the Right Hand Side values.
        /// </summary>
        /// <param name="n">the number of rows in the matrix.</param>
        /// <param name="a">the matrix to be solved.</param>
        private double[] GaussElimination(int n, double[,] a)
        {
            // Forward elimination
            for (int k = 0; k < n - 1; k++)
            {
                for (int i = k + 1; i < n; i++)
                {
                    double qt = a[i, k] / a[k, k];
                    for (int j = k + 1; j < n + 1; j++)
                        a[i, j] -= qt * a[k, j];

                    a[i, k] = 0.0;
                }
            }

            var x = new double[n];

            // Back-substitution
            x[n - 1] = a[n - 1, n] / a[n - 1, n - 1];
            for (int k = n - 2; k >= 0; k--)
            {
                double sum = 0.0;
                for (int j = k + 1; j < n; j++)
                    sum += a[k, j] * x[j];

                x[k] = (a[k, n] - sum) / a[k, k];
            }
            return x;
        }
    }
}
