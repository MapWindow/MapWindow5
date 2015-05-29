using System;
using System.Globalization;

namespace MW5.Shared
{
    /// <summary>
    ///  Class for performinc nummeric actions
    /// </summary>
    public static class NumericHelper
    {
        private const double Tolerance = 1e-10;

        /// <summary>Check if a value is nummeric</summary>
        /// <param name = "value">The value to check.</param>
        /// <param name = "style">The NumberStyle</param>
        /// <returns>Status indicating if value is nummeric</returns> 
        public static bool IsNumeric(string value, NumberStyles style)
        {
            double result;

            return double.TryParse(value, style, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Returns true if to values are equal within tolerance.
        /// </summary>
        /// <param name="val1">The val1.</param>
        /// <param name="val2">The val2.</param>
        /// <returns></returns>
        public static bool Equal(double val1, double val2)
        {
            return Math.Abs(val2 - val1) <= Tolerance;
        }

        public static double Parse(string value, double defaultValue)
        {
            double result;
            return  double.TryParse(value, out result) ? result : defaultValue;
        }
    }
}