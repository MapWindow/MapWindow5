using System.Windows.Forms;

namespace MW5.Services.Abstract
{
    public interface IFileDialogService
    {
        bool OpenFile(LayerType layerType, IWin32Window parent, out string filename);
        bool OpenFiles(LayerType layerType, IWin32Window parent, out string[] filenames);
    }
}
