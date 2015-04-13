using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Views.Abstract;

namespace MW5.Views
{
    public class SetProjectionPresenter : BasePresenter<ISetProjectionView>
    {
        private readonly ISetProjectionView _view;
        private readonly IMuteMap _map;

        public SetProjectionPresenter(ISetProjectionView view, IMuteMap map)
            : base(view)
        {
            _view = view;
            _map = map;
        }

        public override bool ViewOkClicked()
        {
            if (_map.Layers.Count > 0)
            {
                MessageService.Current.Info("Can't change projection when there are layers on the map.");
                return false;
            }

            var sr = new SpatialReference();

            if (_view.Projection == SetProjectionView.ProjectionType.Custom)
            {
                if (string.IsNullOrWhiteSpace(_view.CustomProjection))
                {
                    MessageService.Current.Info("ProjectionType string is empty.");
                    return false;
                }

                if (!sr.ImportFromAutoDetect(_view.CustomProjection))
                {
                    MessageService.Current.Info("Failed to identify projection.");
                    return false;
                }
            }

            if (_view.Projection == SetProjectionView.ProjectionType.Default)
            {
                if (_view.DefaultProjectionIndex == 0)
                {
                    sr.SetWgs84();
                }

                if (_view.DefaultProjectionIndex == 1)
                {
                    sr.SetGoogleMercator();
                }
            }

            _map.Projection = sr;
            _map.Redraw();
            return true;
        }
    }
}
