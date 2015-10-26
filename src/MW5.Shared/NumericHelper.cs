using System;
using System.Globalization;
using System.IO;

namespace MW5.Shared
{
    /// <summary>
    ///  Class for performinc nummeric actions
    /// </summary>
    public static class NumericHelper
    {
        private const double Tolerance = 1e-10;

        public static string ToInvariantString(this double value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        public static bool ParseDoubleInvariant(this string s, out double result)
        {
            double val;
            return double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
        }

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
            return Equal(val1, val2, Tolerance);
        }

        /// <summary>
        /// Returns true if to values are equal within tolerance.
        /// </summary>
        /// <param name="val1">The val1.</param>
        /// <param name="val2">The val2.</param>
        /// <param name="tolerance">Tolerance.</param>
        /// <returns></returns>
        public static bool Equal(double val1, double val2, double tolerance)
        {
            return Math.Abs(val2 - val1) <= tolerance;
        }

        public static double Parse(string value, double defaultValue)
        {
            double result;
            return double.TryParse(value, out result) ? result : defaultValue;
        }

        public static string FormatFileSize(double size)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            
            int order = 0;
            while (size >= 1024 && order + 1 < sizes.Length)
            {
                order++;
                size = size / 1024;
            }

            // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
            // show a single decimal place, and no space.
            return String.Format("{0:0.##} {1}", size, sizes[order]);
        }
    }
}