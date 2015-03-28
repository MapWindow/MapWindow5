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
        private readonly IMessageService _messageService;

        public SetProjectionPresenter(ISetProjectionView view, IMuteMap map, IMessageService messageService)
            : base(view)
        {
            _view = view;
            _map = map;
            _messageService = messageService;
        }

        public override bool ViewOkClicked()
        {
            if (_map.Layers.Count > 0)
            {
                _messageService.Info("Can't change projection when there are layers on the map.");
                return false;
            }

            var sr = new SpatialReference();

            if (_view.Projection == SetProjectionView.ProjectionType.Custom)
            {
                if (string.IsNullOrWhiteSpace(_view.CustomProjection))
                {
                    _messageService.Info("ProjectionType string is empty.");
                    return false;
                }

                if (!sr.ImportFromAutoDetect(_view.CustomProjection))
                {
                    _messageService.Info("Failed to identify projection.");
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

            _map.GeoProjection = sr;
            _map.Redraw();
            return true;
        }
    }
}
