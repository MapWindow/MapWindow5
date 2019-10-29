using MW5.Api.Map;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MW5.Plugins.AdvancedSnapping.Restrictions
{
    public class MapCapture
    {

        private readonly MapControl Map;
        private Control Wrapper = null;
        private Action<Point> OnClickCallback;
        private Action<Point> OnMoveCallback;

        public MapCapture(MapControl map)
        {
            Map = map ?? throw new ArgumentNullException("map");
        }

        public void Enable(Action<Point> onClickCallback, Action<Point> onMoveCallback)
        {
            if (Wrapper == null) Wrap();

            Map.Enabled = false;

            OnClickCallback = onClickCallback;
            OnMoveCallback = onMoveCallback;
            Wrapper.Capture = true;
            Wrapper.MouseMove += OnWrapperMouseMove;
            Wrapper.MouseUp += OnWrapperMouseUp;
            Wrapper.Click += OnWrapperClick;
        }

        public void Disable()
        {
            if (Wrapper == null) return;
            Wrapper.Capture = false;
            Wrapper.MouseMove -= OnWrapperMouseMove;
            Wrapper.MouseUp -= OnWrapperMouseUp;
            Wrapper.Click -= OnWrapperClick;

            Map.Enabled = true;
        }

        private Control Wrap()
        {
            if (Wrapper == null)
            {
                Wrapper = new ContainerControl();

                if (!(Map.Parent is ContainerControl oldParent))
                    return null;

                // Remove map from parent:
                oldParent.Controls.Remove(Map);

                // Add map to new parent:
                Wrapper.Controls.Add(Map);

                // Add wrapper container to old parent:
                oldParent.Controls.Add(Wrapper);
            }

            return Wrapper;
        }

        private void OnWrapperMouseMove(object sender, MouseEventArgs e)
        {
            OnMoveCallback?.Invoke(e.Location);
        }

        private void OnWrapperClick(object sender, EventArgs e)
        {
            OnClickCallback?.Invoke(MousePoint);
        }

        Point MousePoint;
        private void OnWrapperMouseUp(object sender, MouseEventArgs e)
        {
            MousePoint = e.Location;
        }
    }
}
