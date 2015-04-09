using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Controls
{
    public abstract class TreeViewBase: TreeViewAdv
    {
        private SuperToolTip _lastTooltip = new SuperToolTip();

        public event EventHandler<ToolTipEventArgs> PrepareToolTip;

        protected TreeViewBase()
        {
            AfterSelect += TreeViewBase_AfterSelect;
            LostFocus += (s, e) => HideToolTip();

            CreateImageList();
        }

        public int ToolTipDuration { get; set; }

        protected abstract IEnumerable<Bitmap> OnCreateImageList();

        private void CreateImageList()
        {
            var icons = OnCreateImageList();
            
            var list = new ImageList() { ColorDepth = ColorDepth.Depth32Bit };

            const int size = 16;
            foreach (var icon in icons)
            {
                var bmp = new Bitmap(icon, new Size(size, size));
                list.Images.Add(bmp);
            }

            LeftImageList = list;
        }

        private void TreeViewBase_AfterSelect(object sender, EventArgs e)
        {
            if (MouseButtons != MouseButtons.Right)
            {
                DisplayTooltip();
            }
        }

        private void DisplayTooltip()
        {
            lock (_lastTooltip)
            {
                _lastTooltip.Hide();
                _lastTooltip = new SuperToolTip(this);

                var rect = SelectedNode.TextBounds;
                var pnt = new Point(rect.X + rect.Width + 20, rect.Y + rect.Height);
                pnt = PointToScreen(pnt);

                var info = new ToolTipInfo();
                var args = new ToolTipEventArgs(info);
                FirePrepareTooltip(args);
                if (args.Cancel)
                {
                    _lastTooltip.Hide();
                    return;
                }

                info.Header.Font = new Font(info.Header.Font, FontStyle.Bold);
                _lastTooltip.MaxWidth = 450;
                _lastTooltip.Show(info, pnt, ToolTipDuration);
            }
        }

        public void HideToolTip()
        {
            _lastTooltip.Hide();
        }

        private void FirePrepareTooltip(ToolTipEventArgs args)
        {
            var handler = PrepareToolTip;
            if (handler != null)
            {
                handler(this, args);
            }
        }
    }
}
