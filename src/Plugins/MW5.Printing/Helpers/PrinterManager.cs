// -------------------------------------------------------------------------------------------
// <copyright file="PrinterManager.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Drawing.Printing;
using System.Linq;
using MW5.Plugins.Printing.Enums;

namespace MW5.Plugins.Printing.Helpers
{
    /// <summary>
    /// Opens preview dialog to prepare the printing
    /// </summary>
    public static class PrinterManager
    {
        private static PrinterSettings _printingSettings;
        private static PageSettings _pageSettings;

        public static PageSettings PageSettings
        {
            get
            {
                if (_pageSettings == null)
                {
                    _pageSettings = PrinterSettings.DefaultPageSettings;
                }

                return _pageSettings;
            }
        }

        /// <summary>
        /// A singleton for PrintingSettings
        /// </summary>
        public static PrinterSettings PrinterSettings
        {
            // TODO: don't use singleton
            get
            {
                if (_printingSettings == null)
                {
                    _printingSettings = new PrinterSettings();
                    PaperSizes.AddPaperSizes(_printingSettings);
                }

                return _printingSettings;
            }
        }

        public static void InitPaperSize()
        {
            var ps = PrinterSettings;
            PaperSizes.AddPaperSizes(ps);

            // TODO: improve conversion from PaperFormat to PaperSize
            var paperSizes = PaperSizes.GetPaperSizes(ps);
            var paperSize = paperSizes.FirstOrDefault(p => p.PaperName == PaperFormat.A4.ToString());

            var pgs = PageSettings;
            pgs.PaperSize = paperSize;
        }
    }
}