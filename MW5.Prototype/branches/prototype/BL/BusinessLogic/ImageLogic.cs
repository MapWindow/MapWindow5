using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MapWinGIS;
using BL.Aggregator;

namespace BL.BusinessLogic
{
    public class ImageLogic
    {
        public static int AddLayer(Aggregate aggregator, string filePath)
        {
            int layerHandle = -1;

            // Get extension of file
            string extension = Path.GetExtension(filePath);

            Image img = new Image();

            // Set global callback
            img.GlobalCallback = aggregator;

            // Check if filtype is an image
            if (img.CdlgFilter.Contains(extension))
            {
                // Try to open the file as image
                if (!img.Open(filePath, ImageType.USE_FILE_EXTENSION, false, null))
                {
                    throw new Exception(img.ErrorMsg[img.LastErrorCode]);
                }
                else
                {
                    // Add layer to ocx
                    layerHandle = aggregator.MapWin.AddLayer(img, true);
                }
            }

            return layerHandle;
        }
    }
}
