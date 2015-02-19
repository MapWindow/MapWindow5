using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MapWinGIS;
using BL.Aggregator;

namespace BL.BusinessLogic
{
   public class ShapefileLogic
    {
       public static int AddLayer(Aggregate aggregator, string filePath)
       {
           int layerHandle = -1;

           // Get extension of file
           string extension = Path.GetExtension(filePath);

           Shapefile sf = new Shapefile();
           sf.GlobalCallback = aggregator;

           // Check if filtype is an shapefile
           if (sf.CdlgFilter.Contains(extension))
           {
               // Try to open the file as shapefile
               if (!sf.Open(filePath, null))
               {
                   throw new Exception(sf.ErrorMsg[sf.LastErrorCode]);
               }
               else
               {
                   // Add layer to ocx
                   layerHandle = aggregator.MapWin.AddLayer(sf, true);
               }
           }

           return layerHandle;
       }
    }
}
