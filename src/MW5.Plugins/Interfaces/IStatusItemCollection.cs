using System.Drawing;
using MW5.Plugins.Concrete;

namespace MW5.Plugins.Interfaces
{
    public interface IStatusItemCollection: IMenuItemCollection
    {
        IMenuItem AddProgressBar(string key, PluginIdentity identity);
        IDropDownMenuItem AddSplitButton(string text, string key, PluginIdentity identity);
    }
}
