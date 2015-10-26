// -------------------------------------------------------------------------------------------
// <copyright file="PrintingConstants.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

namespace MW5.Plugins.Printing.Helpers
{
    internal static class PrintingConstants
    {
        internal const string EXPORT_FILTER =
            "Images (*.png)|*.png|Images (*.tif)|*.tif|Images (*.jpg)|*.jpg|Images (*.bmp)|*.bmp";

        internal const int DEADLOCK_TIMEOUT_MILLISECONDS = 60000; //  60 seconds;
        internal const bool ELEMENT_CLIPPING = false;
        internal const float EXPORT_BASE_DPI = 100f;
    }
}