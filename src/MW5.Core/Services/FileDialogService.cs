using System.Windows.Forms;
using MW5.Api.Static;
using MW5.Core.Services.Abstract;

namespace MW5.Core.Services
{
    public class FileDialogService : IFileDialogService
    {
        public bool OpenFile(LayerType layerType, Form parent, out string filename)
        {
            filename = string.Empty;
            string[] filenames;
            if (OpenFileCore(layerType, parent, false, out filenames))
            {
                filename = filenames[0];
            }
            return filename != string.Empty;
        }

        public bool OpenFiles(LayerType layerType, Form parent, out string[] filenames)
        {
            return OpenFileCore(layerType, parent, true, out filenames);
        }

        private bool OpenFileCore(LayerType layerType, Form parent, bool multiSelect, out string[] filenames)
        {
            filenames = null;
            using (var dialog = new OpenFileDialog())
            {
                dialog.Multiselect = multiSelect;
                dialog.Filter = GetLayerFilter(layerType);
                if (dialog.ShowDialog(parent) == DialogResult.OK)
                {
                    filenames = dialog.FileNames;
                }
            }
            return filenames != null;
        }

        private static string GetLayerFilter(LayerType layerType)
        {
            switch (layerType)
            {
                case LayerType.All:
                    return GeoSourceManager.FileFilter;
                case LayerType.Raster:
                    return GeoSourceManager.RasterFilter;
                case LayerType.Vector:
                    return GeoSourceManager.VectorFilter;
            }
            return "All files|*.*";
        }
    }
}
