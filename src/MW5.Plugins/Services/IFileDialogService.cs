using MW5.Plugins.Enums;

namespace MW5.Plugins.Services
{
    public interface IFileDialogService
    {
        bool SaveFile(string filter, ref string filename);
        bool Open(string filter, out string filename);
        bool OpenFile(DataSourceType layerType, out string filename);
        bool OpenFiles(DataSourceType layerType, out string[] filenames);
        bool ChooseFolder(string initialPath, out string chosenPath);
    }
}
