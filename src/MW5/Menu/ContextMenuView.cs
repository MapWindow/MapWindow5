using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;

namespace MW5.Menu
{
    public partial class ContextMenuView : UserControl, IMenuProvider
    {
        private readonly IAppContext _context;

        public ContextMenuView(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            _context = context;

            InitializeComponent();

            contextMeasuring.Opening += MeasuringMenuOpening;
        }

        public ContextMenuStrip MeasuringMenu
        {
            get { return contextMeasuring; }
        }

        public ContextMenuStrip ZoomingMenu
        {
            get { return contextZooming; }
        }

        public IEnumerable<ToolStripItemCollection> ToolStrips
        {
            get
            {
                yield return contextMeasuring.Items;
                yield return contextZooming.Items;
            }
        }

        public IEnumerable<Control> Buttons
        {
            get { yield break; }
        }

        private void MeasuringMenuOpening(object sender, CancelEventArgs e)
        {
            var options = _context.Map.Measuring.Options;

            ctxShowBearing.Checked = options.ShowBearing;
            ctxShowLength.Checked = options.ShowLength;
            ctxMetric.Checked = options.LengthUnits == LengthDisplay.Metric;
            ctxAmerican.Checked = options.LengthUnits == LengthDisplay.American;
            ctxDegrees.Checked = options.AngleFormat == AngleFormat.Degrees;
            ctxMinutes.Checked = options.AngleFormat == AngleFormat.Minutes;
            ctxSeconds.Checked = options.AngleFormat == AngleFormat.Seconds;
        }

        private void DisableAll(ContextMenuStrip menu)
        {
            foreach (var item in menu.Items.OfType<ToolStripMenuItem>())
            {
                item.Enabled = false;
            }
        }
    }
}
