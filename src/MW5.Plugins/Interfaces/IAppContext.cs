using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.Interfaces
{
    public interface IAppContext
    {
        IMuteMap Map { get; }
        IMuteLegend Legend { get; }
        IMenu Menu { get; }
        IToolbarCollection Toolbars { get; }
        LegendLayerCollection<ILayer> Layers { get; }
        bool Initialized { get; }
        void Init(IMainForm form);
        IApplicationContainer Container { get; }
        DialogResult ShowDialog(Form form);
        IView View { get; }
    }
}
