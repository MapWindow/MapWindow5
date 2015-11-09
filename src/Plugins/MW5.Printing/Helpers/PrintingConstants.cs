// -------------------------------------------------------------------------------------------
// <copyright file="PrintingConstants.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

namespace MW5.Plugins.Printing.Helpers
{
    internal static class PrintingConstants
    {
        public const string EXPORT_FILTER =
            "Images (*.png)|*.png|Images (*.tif)|*.tif|Images (*.jpg)|*.jpg|Images (*.bmp)|*.bmp";

        public const int DEADLOCK_TIMEOUT_MILLISECONDS = 60000; //  60 seconds;

        public static bool UseElementClipping = false;

        public const float EXPORT_BASE_DPI = 100f;

        public const int DefaultMapOffset = 5;  // default location in paper coordinates 

        public  const int MaxSizeInches = 75; // maximum size of layout (either width or height) in inches
    }
}