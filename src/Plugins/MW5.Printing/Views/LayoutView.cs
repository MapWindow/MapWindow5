// -------------------------------------------------------------------------------------------
// <copyright file="LayoutView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Printing.Controls.Layout;
using MW5.Plugins.Printing.Helpers;
using MW5.Plugins.Printing.Model.Elements;
using MW5.Plugins.Printing.Properties;
using MW5.Plugins.Printing.Services;
using MW5.Plugins.Printing.Views.Abstract;
using MW5.Plugins.Printing.Views.Panels;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.UI.Docking;
using MW5.UI.Enums;
using MW5.UI.Forms;
using MW5.UI.Helpers;
using MW5.UI.Style;

namespace MW5.Plugins.Printing.Views
{
    internal partial class LayoutView : LayoutViewBase, ILayoutView
    {
        private const string SerializationKey = "_layout";
        private readonly IBroadcasterService _broadcaster;
        private readonly IAppContext _context;
        private readonly ElementsPresenter _elements;
        private readonly PdfExportService _pdfService;
        private readonly PrintingPlugin _plugin;
        private readonly IStyleService _styleService;
        private IDockPanelCollection _dockPanels;
        private LayoutMenuGenerator _menuGenerator;
        private LayoutMenuListener _menuListener;
        private IComboBoxMenuItem _zoomCombo;

        public LayoutView(
            IAppContext context,
            PrintingPlugin plugin,
            IBroadcasterService broadcaster,
            IStyleService styleService,
            ElementsPresenter elements,
            PdfExportService pdfService
            )
        {
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");
            if (broadcaster == null) throw new ArgumentNullException("broadcaster");
            if (styleService == null) throw new ArgumentNullException("styleService");
            if (elements == null) throw new ArgumentNullException("elements");
            if (pdfService == null) throw new ArgumentNullException("pdfService");

            _context = context;
            _plugin = plugin;
            _broadcaster = broadcaster;
            _styleService = styleService;
            _elements = elements;
            _pdfService = pdfService;

            InitializeComponent();

            // there is no way to get it other than in context of some Control
            ScreenHelper.ScreenDpi = layoutControl1.GetScreenDpi();

            InitControls();

            AttachEventHandlers();

            InitDockPanels();

            InitMenus();

            RestorePreviousState();

            FormClosing += LayoutViewFormClosing;
        }

        private void LayoutViewFormClosing(object sender, FormClosingEventArgs e)
        {
            dockingManager1.SaveLayout(SerializationKey, false);
            mainFrameBarManager1.SaveLayout(SerializationKey, false);
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            // initialized in presenter
        }

        public override ViewStyle Style
        {
            get { return new ViewStyle(true); }
        }

        public ButtonBase OkButton
        {
            get { return null; }
        }

        public object MenuManager
        {
            get { return mainFrameBarManager1; }
        }

        public object DockingManager
        {
            get { return dockingManager1; }
        }

        public IDockPanelCollection DockPanels
        {
            get { return _dockPanels; }
        }

        public LayoutControl LayoutControl
        {
            get { return layoutControl1; }
        }

        private void AttachEventHandlers()
        {
            Shown += OnLayoutViewShown;
            layoutControl1.KeyDown += OnKeyDown;
            layoutControl1.ZoomChanged += OnlayoutControlZoomChanged;
            layoutControl1.SelectionChanged += (s, e) => OnSelectionChanged();
            layoutControl1.MouseMove += OnLayoutMouseMove;
            layoutControl1.ElementsChanged += (s, e) => _elements.View.UpdateSelectionFromMap();
            layoutControl1.MouseWheel += OnMouseWheel;
            contextMenuStripEx1.Opening += ContextMenuOpening;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                layoutControl1.Cursor = Cursors.Default;
                layoutControl1.PanMode = false;
                UpdateView();
            }
        }

        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                layoutControl1.ZoomIn();
            }
            else
            {
                layoutControl1.ZoomOut();
            }
        }

        private void UpdateContextMenu(bool enable)
        {
            for (int i = 0; i < contextMenuStripEx1.Items.Count; i++)
            {
                contextMenuStripEx1.Items[i].Enabled = enable;
            }
        }

        private void ContextMenuOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UpdateContextMenu(true);

            int count = layoutControl1.SelectedLayoutElements.Count();
            if (count == 0)
            {
                UpdateContextMenu(false);
            }
            else if (count == 1)
            {
                toolAlign.Enabled = false;
                toolMakeSameSize.Enabled = false;
            }
        }

        private void OnLayoutMouseMove(object sender, MouseEventArgs e)
        {
            var pnt = layoutControl1.ScreenToPaper(e.Location);

            var ratio = ConfigHelper.GetUnitsConversionRatio();
            string units = ConfigHelper.GetUnitShortString();
            int decimals = ConfigHelper.GetDecimalDigitsForUnits();

            string format = "X: {0:f" + decimals + "} {2}; Y: {1:f" + decimals + "} {2}";
            lblPosition.Text = string.Format(format, pnt.X * ratio, pnt.Y * ratio, units);

            // TODO: this also invalidates progress bar for tile loading 
            // thus increasing marquee speed, but I haven't found a way 
            // to refresh a single lblPosition item; ToolStripItem is not Control
            // so doesn't have handle or Refresh method
            statusStripEx1.Refresh();
        }

        private void OnSelectionChanged()
        {
            _elements.View.UpdateSelectionFromMap();

            // enabling disabling map toolbar
            var toolbar = _menuGenerator.Toolbars.FirstOrDefault(t => t.Key == LayoutMenuKeys.MapToolbar);
            if (toolbar != null)
            {
                var map = layoutControl1.SelectedLayoutElements.FirstOrDefault() as LayoutMap;
                toolbar.Enabled = map != null;
            }

            lblSelected.Text = @"Items selected: " + layoutControl1.SelectedLayoutElements.Count();
        }

        private void InitControls()
        {
            layoutPropertyGrid1.LayoutControl = layoutControl1;

            _elements.SetLayoutControl(layoutControl1);

            layoutPropertyGrid1.BorderStyle = BorderStyle.None;

            layoutControl1.PageSettingsChanged += (s, e) => UpdateView();

            layoutControl1.Dock = DockStyle.Fill;
        }

        private void InitDockPanels()
        {
            _dockPanels = new DockPanelCollection(dockingManager1, this, _broadcaster, _styleService);

            var panel = _dockPanels.Add(_elements.GetInternalObject(), "LayoutListBox", _plugin.Identity);
            panel.DockTo(DockPanelState.Right, 300);
            panel.Caption = "Elements";
            panel.SetIcon(Resources.ico_legend24);

            var panel2 = _dockPanels.Add(layoutPropertyGrid1, "PropertiesDockPanel", _plugin.Identity);
            panel2.DockTo(panel, DockPanelState.Bottom, 500);
            panel2.Caption = "Properties";
            panel2.SetIcon(Resources.ico_properties24);
        }

        private void InitMenus()
        {
            // we want the same instance of view in the service, but another 
            // instance on showing presenter the next time, so better not to use DI
            // TODO: try to use singletons instead
            _menuListener = new LayoutMenuListener(_context, this, _pdfService);
            _menuGenerator = new LayoutMenuGenerator(_context, _plugin, this, _menuListener);

            _zoomCombo = _menuGenerator.Toolbars.FindItem(LayoutMenuKeys.ZoomCombo, _plugin.Identity) as IComboBoxMenuItem;
            if (_zoomCombo != null)
            {
                _zoomCombo.ValueChanged += OnZoomComboValueChanged;
            }
        }

        public void RestorePanels()
        {
            dockingManager1.RestoreLayout(SerializationKey, true);

            // there was an occasional glitch on restoring panels 
            // (client dock area not filling the whole available space)
            // not sure if I was able to fix it
            layoutControl1.Refresh();
        }

        public void RestoreToolbars()
        {
            mainFrameBarManager1.RestoreLayout(SerializationKey, true);
            layoutControl1.Refresh();
        }

        public bool TilesLoadingVisible
        {
            get { return toolStripProgressBar1.Visible; }
            set
            {
                Action action = () =>
                    {
                        toolStripProgressBar1.Visible = value;
                        lblLoadingTiles.Visible = value;
                    };

                statusStripEx1.SafeInvoke(action);
            }
        }

        private void RestorePreviousState()
        {
            dockingManager1.TryRestoreLayout(SerializationKey);
            mainFrameBarManager1.TryRestoreLayout(SerializationKey);
        }

        private void OnLayoutViewShown(object sender, EventArgs e)
        {
            // timely update of control may not occur if user moves mouse over layout control 
            // (it triggers immediate update of status bar with Refresh);
            Refresh();
        }

        private void OnZoomComboValueChanged(object sender, StringValueChangedEventArgs e)
        {
            string input = e.NewValue.Replace("%", string.Empty);

            layoutControl1.Zoom = Convert.ToInt32(input) / 100F;

            layoutControl1.Refresh();
        }

        private void OnlayoutControlZoomChanged(object sender, EventArgs e)
        {
            _zoomCombo.Text = String.Format("{0:0}", layoutControl1.Zoom * 100) + "%";
        }

        public override void UpdateView()
        {
            var btn = _menuGenerator.Toolbars.FindItem(LayoutMenuKeys.ShowPageNumbers, _plugin.Identity);
            btn.Checked = layoutControl1.ShowPageNumbers;

            btn = _menuGenerator.Toolbars.FindItem(LayoutMenuKeys.MapPan, _plugin.Identity);
            btn.Checked = layoutControl1.PanMode;

            btn = _menuGenerator.Menu.FindItem(LayoutMenuKeys.ShowPageNumbers, _plugin.Identity);
            btn.Checked = layoutControl1.ShowPageNumbers;

            btn = _menuGenerator.Menu.FindItem(LayoutMenuKeys.ShowMargins, _plugin.Identity);
            btn.Checked = layoutControl1.ShowMargins;

            btn = _menuGenerator.Menu.FindItem(LayoutMenuKeys.ShowRulers, _plugin.Identity);
            btn.Checked = layoutControl1.ShowRulers;

            lblPageSize.Text = "Format: " + layoutControl1.PrinterSettings.DefaultPageSettings.PaperSize.PaperName;
            lblPageCount.Text = string.Format("Number of pages: {0} × {1}", layoutControl1.Pages.PageCountX,
                layoutControl1.Pages.PageCountY);
        }

        public IEnumerable<ToolStripItemCollection> ToolStrips
        {
            get { yield return contextMenuStripEx1.Items; }
        }

        public IEnumerable<Control> Buttons
        {
            get { yield break; }
        }
    }

    internal class LayoutViewBase : MapWindowView<TemplateModel>
    {
    }
}