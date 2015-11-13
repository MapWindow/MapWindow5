// -------------------------------------------------------------------------------------------
// <copyright file="PrintingConstants.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

namespace MW5.Plugins.Printing.Helpers
{
    internal static class PrintingConstants
    {
        public const string BitmapFilter =
            "Images (*.png)|*.png|Images (*.tif)|*.tif|Images (*.jpg)|*.jpg|Images (*.bmp)|*.bmp|All image formats|*.png;*.tif;*.gif;*.jpg;*.bmp";

        public const string TemplateFilter = "*.xml|*.xml";

        public const int DefaultMapOffset = 5;  // default location in paper coordinates 

        public  const int MaxSizeInches = 75; // maximum size of layout (either width or height) in inches
    }
}