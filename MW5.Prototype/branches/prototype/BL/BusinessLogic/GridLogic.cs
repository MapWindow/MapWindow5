using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapWinGIS;
using System.IO;
using BL.Aggregator;

namespace BL.BusinessLogic
{
    public class GridLogic
    {
        public static int AddLayer(Aggregate aggregator, string filePath)
        {
            int layerHandle = -1;

            // Get extension of file
            string extension = Path.GetExtension(filePath);

            Grid grd = new Grid();

            // Check if filtype is a grid
            if (grd.CdlgFilter.Contains(extension))
            {
                // Try to open the file as grid
                if (!grd.Open(filePath, GridDataType.UnknownDataType, true, GridFileType.UseExtension, null))
                {
                    throw new Exception(grd.ErrorMsg[grd.LastErrorCode]);
                }
                else
                {
                    // Add layer to ocx
                    layerHandle = aggregator.MapWin.AddLayer(grd, true);
                }
            }

            return layerHandle;
        }
    }
}
