using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Controls
{
    /// <summary>
    /// Syncfusion's TreeViewAdv with support of icon list and tooltips.
    /// </summary>
    public abstract class TreeViewBase: TreeViewAdv
    {
        private SuperToolTip _lastTooltip = new SuperToolTip();

        public event EventHandler<ToolTipEventArgs> PrepareToolTip;

        protected TreeViewBase()
        {
            AfterSelect += TreeViewBase_AfterSelect;
            LostFocus += (s, e) => HideToolTip();

            IconSize = 16;

            CreateImageList();

            ShowSuperTooltip = true;

            HideSelection = false;

            ApplyStyle = true;
        }

        public bool ApplyStyle { get; set; }

        public bool ShowSuperTooltip { get; set; }

        public int ToolTipDuration { get; set; }

        protected abstract IEnumerable<Bitmap> OnCreateImageList();

        protected int IconSize { get; set; }

        protected void CreateImageList()
        {
            var icons = OnCreateImageList();
            
            var list = new ImageList()
            {
                ColorDepth = ColorDepth.Depth32Bit,
                ImageSize = new Size(IconSize, IconSize)
            };

            foreach (var icon in icons)
            {
                var bmp = new Bitmap(icon, new Size(IconSize, IconSize));
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

                if (!ShowSuperTooltip)
                {
                    return;
                }

                if (SelectedNode == null)
                {
                    return;
                }

                _lastTooltip = new SuperToolTip(this)
                {
                    Style = SuperToolTip.SuperToolTipStyle.Office2013Style, 
                    VisualStyle = SuperToolTip.Appearance.Metro, 
                    MetroColor = Color.White, 
                    UseFading = SuperToolTip.FadingType.System
                };

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
                return;
            }

            args.Cancel = true;
        }
    }
}
