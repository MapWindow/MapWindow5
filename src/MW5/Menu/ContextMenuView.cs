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

            ctxScale.Tag = 0;   // to avoid automatic handler
            ctxZoomToLayer.Tag = 0;  // to avoid automatic handler

            contextMeasuring.Opening += MeasuringMenuOpening;

            contextZooming.Opening += ZoomingMenuOpening;
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

        private void ZoomingMenuOpening(object sender, CancelEventArgs e)
        {
            InitScaleMenu();

            InitLayersMenu();
        }

        private void InitLayersMenu()
        {
            
            ctxZoomToLayer.DropDownItems.Clear();

            foreach (var layer in _context.Map.Layers.Where(l => l.Visible))
            {
                var item = ctxZoomToLayer.DropDownItems.Add(layer.Name);
                item.Tag = layer.Handle;
                item.Click += OnZoomToLayerClick;
            }
        }

        private void InitScaleMenu()
        {
            ctxScale.DropDownItems.Clear();

            ctxScale.DropDownItems.Add("1: " + _context.Map.CurrentScale.ToString("0.0"));
            ctxScale.DropDownItems.Add(new ToolStripSeparator());

            int[] scales = {
                100,
                1000,
                5000,
                10000,
                25000,
                50000,
                100000,
                250000,
                500000,
                1000000,
                5000000,
                1000000,
            };

            foreach (var scale in scales)
            {
                var item = ctxScale.DropDownItems.Add("1: " + scale);
                item.Tag = scale;
                item.Click += OnSetScale;
            }
        }

        private void OnZoomToLayerClick(object sender, EventArgs e)
        {
            var item = sender as ToolStripItem;
            if (item != null)
            {
                int layerHandle = (int)item.Tag;
                _context.Map.ZoomToLayer(layerHandle);
            }
        }

        private void OnSetScale(object sender, EventArgs e)
        {
            var item = sender as ToolStripItem;
            if (item != null)
            {
                _context.Map.CurrentScale = (int) item.Tag;
            }
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
    }
}
