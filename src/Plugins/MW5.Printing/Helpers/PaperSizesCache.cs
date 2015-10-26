// -------------------------------------------------------------------------------------------
// <copyright file="PaperSizesCache.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;

namespace MW5.Plugins.Printing.Helpers
{
    /// <summary>
    /// Stores the paper sizes for each of the printers. 
    /// </summary>
    /// <remarks>PrinterSettings.PaperSizes executes lengthy enumeration. Caching speed up things.</remarks>
    public static class PaperSizes
    {
        private static readonly Dictionary<string, List<PaperSize>> _printers =
            new Dictionary<string, List<PaperSize>>();

        public static void AddPaperSizes(PrinterSettings settings)
        {
            if (!_printers.ContainsKey(settings.PrinterName))
            {
                var list = settings.PaperSizes.Cast<PaperSize>().ToList();
                _printers.Add(settings.PrinterName, list);
            }
        }

        public static List<PaperSize> GetPaperSizes(PrinterSettings settings)
        {
            if (!_printers.ContainsKey(settings.PrinterName))
            {
                AddPaperSizes(settings);
            }

            return _printers[settings.PrinterName];
        }

        public static PaperSize PaperSizeByFormatName(string formatName, PrinterSettings settings)
        {
            if (!_printers.ContainsKey(settings.PrinterName))
            {
                AddPaperSizes(settings);
            }

            var list = _printers[settings.PrinterName];
            var result = list.FirstOrDefault(size => size.PaperName.ToUpper() == formatName.ToUpper());

            return result;
        }
    }
}