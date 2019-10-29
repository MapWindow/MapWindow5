using MW5.Api.Interfaces;
using MW5.Plugins.AdvancedSnapping.ViewModels;
using MW5.Plugins.AdvancedSnapping.Views;
using MW5.Plugins.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MW5.Plugins.AdvancedSnapping.Context
{
    public class DoubleInputHelper
    {

        private readonly IAppContext _context;

        /// <summary>
        /// The bearing input view
        /// </summary>
        private DoubleInputView _inputView;
        private DoubleInputViewModel _inputVM;

        public DoubleInputHelper(IAppContext context)
        {
            _context = context ?? throw new ArgumentNullException("context");
        }

        public void ShowInputView(string label, double bearing, ICoordinate poi,
            Action<double> onValueChanged, Action<double> onValueEntered, Action<object> onMapAction = null)
        {
            var pxPoi = (poi != null) ? _context.Map.ProjToPixel(poi) : null;

            if (_inputView == null)
                _inputView = new DoubleInputView();
            _inputVM = new DoubleInputViewModel(label, bearing, onValueChanged, onValueEntered, onMapAction);
            _inputView.DataContext = _inputVM;
            _inputView.GetAndSetOwner();
            UpdateInputViewPos(_context.Map as Control, (int) pxPoi?.X, (int) pxPoi?.Y);

            if (onMapAction != null)
                _inputView.Show();
            else
                _inputView.ShowDialog();
        }

        public void ShowInputView(string label, double bearing,
            Action<double> onValueChanged, Action<double> onValueEntered, Action<object> onMapAction = null)
            => ShowInputView(label, bearing, null, onValueChanged, onValueEntered, onMapAction);

        private void UpdateInputViewPos(Control control = null, int? x = null, int? y = null)
        {
            if (control is null)
                _inputView.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            else
            {
                _inputView.WindowStartupLocation = System.Windows.WindowStartupLocation.Manual;

                var scale = GetScalingFactor(control);
                Point tp = x.HasValue && y.HasValue
                    ? control.PointToScreen(new Point(x.Value, y.Value))
                    : control.PointToScreen(new Point((int) (control.Width * 0.5d), control.Height));

                _inputView.Reposition(
                    tp.X / scale,
                    (tp.Y - _inputView.ActualHeight) / scale
                );
            }
        }

        private double GetScalingFactor(Control control)
        {
            double dpiX, dpiY;
            Graphics graphics = control.CreateGraphics();
            dpiX = graphics.DpiX;
            dpiY = graphics.DpiY;
            return dpiX / (double)96;
        }
    }
}
