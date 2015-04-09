using System;
using System.Windows.Forms;
using MW5.Api.Static;
using MW5.Plugins;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;

namespace MW5.Services.Concrete
{
    internal class FileDialogService : IFileDialogService
    {
        private readonly IWin32Window _parent;

        public FileDialogService(IMainView parent)
        {
            if (parent == null) throw new ArgumentNullException("parent");
            _parent = parent as IWin32Window;
        }

        public bool SaveFile(string filter, ref string filename)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = filter;
            dialog.FileName = filename;
            if (dialog.ShowDialog(_parent) == DialogResult.OK)
            {
                filename = dialog.FileName;
                return true;
            }
            return false;
        }

        public bool Open(string filter, out string filename)
        {
           filename = string.Empty;
            string[] filenames;
            if (OpenFileCore(filter, false, out filenames))
            {
                filename = filenames[0];
            }
            return filename != string.Empty;
        }

        public bool OpenFile(DataSourceType layerType, out string filename)
        {
            filename = string.Empty;
            string[] filenames;
            if (OpenFileCore(GetLayerFilter(layerType), false, out filenames))
            {
                filename = filenames[0];
            }
            return filename != string.Empty;
        }

        public bool OpenFiles(DataSourceType layerType, out string[] filenames)
        {
            return OpenFileCore(GetLayerFilter(layerType), true, out filenames);
        }

        public bool ChooseFolder(string initialPath, out string chosenPath)
        {
            chosenPath = string.Empty;
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                dialog.SelectedPath = initialPath;
                if (dialog.ShowDialog(_parent) == DialogResult.OK)
                {
                    chosenPath = dialog.SelectedPath;
                    return true;
                }
            }
            return false;
        }

        private bool OpenFileCore(string filter, bool multiSelect, out string[] filenames)
        {
            filenames = null;
            using (var dialog = new OpenFileDialog())
            {
                dialog.Multiselect = multiSelect;
                dialog.Filter = filter;
                if (dialog.ShowDialog(_parent) == DialogResult.OK)
                {
                    filenames = dialog.FileNames;
                }
            }
            return filenames != null;
        }

        private static string GetLayerFilter(DataSourceType layerType)
        {
            switch (layerType)
            {
                case DataSourceType.All:
                    return GeoSource.FileFilter;
                case DataSourceType.Raster:
                    return GeoSource.RasterFilter;
                case DataSourceType.Vector:
                    return GeoSource.VectorFilter;
            }
            return "All files|*.*";
        }
    }
}
