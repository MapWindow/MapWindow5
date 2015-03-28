using MW5.Plugins.Mvp;

namespace MW5.Views.Abstract
{
    public interface ISetProjectionView : IView
    {
        SetProjectionView.ProjectionType Projection { get; }
        string CustomProjection { get; }
        int DefaultProjectionIndex { get; }
    }
}
