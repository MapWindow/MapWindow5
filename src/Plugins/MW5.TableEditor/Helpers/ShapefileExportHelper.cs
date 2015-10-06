using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Plugins.Services;

namespace MW5.Plugins.TableEditor.Helpers
{
    internal static class ShapefileExportHelper
    {
        public static void ExportSelected(this IFeatureSet fs, IFileDialogService dialogService, ILayerService layerService)
        {
            if (fs == null) throw new ArgumentNullException("fs");
            if (dialogService == null) throw new ArgumentNullException("dialogService");
            if (layerService == null) throw new ArgumentNullException("layerService");

            if (fs.NumSelected == 0)
            {
                MessageService.Current.Info("No shapes are selected.");
                return;
            }

            string filename = string.Empty;

            dialogService.Title = "Select shapefile name to export selected shapes into";
            if (!dialogService.SaveFile(@"Shapefiles (*.shp)|*.shp", ref filename))
            {
                return;
            }

            var fsNew = fs.ExportSelection();
            if (fsNew != null)
            {
                if (!fsNew.SaveAsEx(filename, true))
                {
                    MessageService.Current.Warn("Failed to save shapefile: " + filename + ".");
                    return;
                }

                fsNew.Dispose();
            }
            else
            {
                MessageService.Current.Warn("Failed to export selection.");
                return;
            }

            if (MessageService.Current.Ask("Do you want to load the new shapefile?"))
            {
                bool result = layerService.AddLayersFromFilename(filename);
                if (!result)
                {
                    MessageService.Current.Warn("Failed to open exported shapefile: " + filename + ".");
                }
            }
        }
    }
}
