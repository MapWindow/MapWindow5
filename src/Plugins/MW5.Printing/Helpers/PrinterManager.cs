// -------------------------------------------------------------------------------------------
// <copyright file="PrinterManager.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Drawing.Printing;

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
            get
            {
                if (_printingSettings == null)
                {
                    _printingSettings = new PrinterSettings();
                    PaperSizes.AddPaperSizes(_printingSettings);

                    // TODO: optimization, consider restoring
                    //var tempForm = new PageSetupForm(_printingSettings);
                    //tempForm.OkButtonClick(null, null);
                }

                return _printingSettings;
            }
        }
    }
}