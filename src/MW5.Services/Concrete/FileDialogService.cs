using System;
using System.Windows.Forms;
using MW5.Api.Static;
using MW5.Plugins;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;

namespace MW5.Services.Concrete
{
    internal class FileDialogService : IFileDialogService
    {
        private readonly IMainView _parent;

        public FileDialogService(IMainView parent)
        {
            if (parent == null) throw new ArgumentNullException("parent");
            _parent = parent;
        }

        public bool SaveFile(string filter, ref string filename)
        {
            var dialog = new SaveFileDialog {Filter = filter, FileName = filename};

            if (!string.IsNullOrWhiteSpace(Title))
            {
                dialog.Title = Title;
            }

            if (dialog.ShowDialog(_parent as IWin32Window) == DialogResult.OK)
            {
                filename = dialog.FileName;
                return true;
            }

            return false;
        }

        public bool Open(string filter, out string filename, int filterIndex = -1)
        {
            filename = string.Empty;
            string[] filenames;

            if (OpenFileCore(filter, false, filterIndex, out filenames))
            {
                filename = filenames[0];
            }

            return filename != string.Empty;
        }

        public bool OpenFile(DataSourceType layerType, out string filename)
        {
            filename = string.Empty;
            string[] filenames;
            if (OpenFileCore(GetLayerFilter(layerType), false, -1, out filenames))
            {
                filename = filenames[0];
            }
            return filename != string.Empty;
        }

        public bool OpenFiles(DataSourceType layerType, out string[] filenames)
        {
            return OpenFileCore(GetLayerFilter(layerType), true, -1, out filenames);
        }

        public bool ChooseFolder(string initialPath, out string chosenPath)
        {
            chosenPath = string.Empty;
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                dialog.SelectedPath = initialPath;

                if (dialog.ShowDialog(_parent as IWin32Window) == DialogResult.OK)
                {
                    chosenPath = dialog.SelectedPath;
                    return true;
                }
            }
            return false;
        }

        public string Title { get; set; }
        
        private bool OpenFileCore(string filter, bool multiSelect, int filterIndex, out string[] filenames)
        {
            filenames = null;

            using (var dialog = new OpenFileDialog())
            {
                dialog.Multiselect = multiSelect;
                dialog.Filter = filter;
                dialog.FilterIndex = filterIndex;

                if (!string.IsNullOrWhiteSpace(Title))
                {
                    dialog.Title = Title;
                }

                if (dialog.ShowDialog(_parent as IWin32Window) == DialogResult.OK)
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
                case DataSourceType.SpatiaLite:
                    return "SpatiaLite databases|*.sqlite";
            }
            return "All files|*.*";
        }
    }
}
