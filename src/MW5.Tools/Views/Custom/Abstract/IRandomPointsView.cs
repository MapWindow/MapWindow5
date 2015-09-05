using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;

namespace MW5.Tools.Views.Custom.Abstract
{
    public interface IRandomPointsView: IView<ToolViewModel>
    {
        int NumPoints { get; }
        ILayerSource Input { get; }
        string OutputName { get; }
    }
}
