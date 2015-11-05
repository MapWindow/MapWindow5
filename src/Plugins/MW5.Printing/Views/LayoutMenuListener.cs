// -------------------------------------------------------------------------------------------
// <copyright file="LayoutMenuListener.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Map;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Printing.Controls.Layout;
using MW5.Plugins.Printing.Helpers;
using MW5.Plugins.Printing.Model.Elements;
using MW5.Plugins.Printing.Services;
using MW5.Plugins.Printing.Views.Abstract;
using MW5.Plugins.Services;

namespace MW5.Plugins.Printing.Views
{
    internal class LayoutMenuListener
    {
        private readonly IAppContext _context;
        private readonly LayoutControl _layoutControl;
        private readonly IPrintableMap _map;
        private readonly ILayoutView _view;

        public LayoutMenuListener(IAppContext context, ILayoutView view)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (view == null) throw new ArgumentNullException("view");

            _context = context;
            _view = view;
            _map = context.Map;
            _layoutControl = view.LayoutControl;
        }

        private LayoutMap SelectedMapElement
        {
            get { return _layoutControl.SelectedLayoutElements.FirstOrDefault() as LayoutMap; }
        }

        public void OnItemClicked(object sender, MenuItemEventArgs e)
        {
            switch (e.ItemKey)
            {
                case LayoutMenuKeys.ShowMargins:
                    _layoutControl.ShowMargins = !_layoutControl.ShowMargins;
                    break;
                case LayoutMenuKeys.ShowPageNumbers:
                    _layoutControl.ShowPageNumbers = !_layoutControl.ShowPageNumbers;
                    break;
                case LayoutMenuKeys.NewLayout:
                    // TODO: ask about saving of previous layout
                    _layoutControl.Filename = string.Empty;
                    _layoutControl.ClearLayout();
                    break;
                case LayoutMenuKeys.SaveLayout:
                    SaveLayout(false);
                    break;
                case LayoutMenuKeys.SaveLayoutAs:
                    SaveLayout(true);
                    break;
                case LayoutMenuKeys.LoadLayout:
                    LoadLayout();
                    break;
                case LayoutMenuKeys.Print:
                    _layoutControl.Print();
                    break;
                case LayoutMenuKeys.PrinterSetup:
                    using (var pd = new PrintDialog { PrinterSettings = _layoutControl.PrinterSettings })
                    {
                        if (pd.ShowDialog(_view as IWin32Window) == DialogResult.OK)
                        {
                            _layoutControl.Invalidate();
                        }
                    }
                    break;
                case LayoutMenuKeys.PageSetup:
                    var model = _layoutControl.PrinterSettings;
                    if (_context.Container.Run<PageSetupPresenter, PrinterSettings>(model))
                    {
                        _layoutControl.Pages.MarkPageSizeDirty();
                        _layoutControl.UpdateLayout();

                        // TODO: trigger in some other way
                        _layoutControl.PrinterSettings = model;
                        _layoutControl.Invalidate();
                    }
                    break;
                case LayoutMenuKeys.ExportToBitmap:
                    _layoutControl.ExportToBitmap();
                    break;
                case LayoutMenuKeys.ZoomIn:
                    _layoutControl.ZoomIn();
                    break;
                case LayoutMenuKeys.ZoomOut:
                    _layoutControl.ZoomOut();
                    break;
                case LayoutMenuKeys.ZoomMax:
                    _layoutControl.ZoomFitToScreen();
                    break;
                case LayoutMenuKeys.AddMap:
                    AddMap();
                    break;
                case LayoutMenuKeys.AddLegend:
                    AddLegend();
                    break;
                case LayoutMenuKeys.AddScaleBar:
                    AddScaleBar();
                    break;
                case LayoutMenuKeys.AddNorthArrow:
                    _layoutControl.AddElementWithMouse(new LayoutNorthArrow());
                    break;
                case LayoutMenuKeys.AddTable:
                    AddTable();
                    break;
                case LayoutMenuKeys.AddLabel:
                    _layoutControl.AddElementWithMouse(new LayoutText());
                    break;
                case LayoutMenuKeys.AddRectangle:
                    _layoutControl.AddElementWithMouse(new LayoutRectangle());
                    break;
                case LayoutMenuKeys.AddBitmap:
                    AddBitmap();
                    break;
                case LayoutMenuKeys.MapZoomMax:
                    {
                        var map = SelectedMapElement;
                        if (map != null)
                        {
                            _layoutControl.ZoomFullExtentMap(map);
                            //LayoutControl.ZoomFullViewExtentMap(map);
                        }
                    }
                    break;
                case LayoutMenuKeys.MapZoomIn:
                    {
                        var map = SelectedMapElement;
                        if (map != null)
                        {
                            _layoutControl.ZoomInMap(map);
                        }
                    }
                    break;
                case LayoutMenuKeys.MapZoomOut:
                    {
                        var map = SelectedMapElement;
                        if (map != null)
                        {
                            _layoutControl.ZoomOutMap(map);
                        }
                    }
                    break;
                case LayoutMenuKeys.MapPan:
                    {
                        _layoutControl.PanMode = true;
                        //_btnPan.Checked = true;
                    }
                    break;
            }
        }

        private void LoadLayout()
        {
            string filename = GetLoadFilename();
            if (string.IsNullOrWhiteSpace(filename)) return;

            var serializer = new LayoutSerializer();
            if (serializer.LoadLayout(_layoutControl, filename))
            {
                InitializeElements();

                MessageService.Current.Info("Layout was loaded successfully.");
            }
        }

        private void InitializeElements()
        {
            // TODO: choose particular map element
            var mapEl = _layoutControl.LayoutElements.OfType<LayoutMap>().FirstOrDefault();

            foreach (var el in _layoutControl.LayoutElements)
            {
                switch (el.Type)
                {
                    case Enums.ElementType.Map:
                        var map = el as LayoutMap;
                        if (map != null)
                        {
                            map.Initialize(_context.Map);
                        }
                        break;
                    case Enums.ElementType.Legend:
                        var legend = el as LayoutLegend;
                        if (legend != null)
                        {
                            legend.Initialize(_layoutControl, _context.Legend);
                            legend.Map = mapEl;
                        }
                        break;

                    case Enums.ElementType.ScaleBar:
                        var scaleBar = el as LayoutScaleBar;
                        if (scaleBar != null)
                        {
                            scaleBar.LayoutControl = _layoutControl;
                            scaleBar.Map = mapEl;
                        }
                        break;
                }
            }

            foreach (var el in _layoutControl.LayoutElements)
            {
                el.Initialized = true;
            }
        }

        private void SaveLayout(bool saveAs)
        {
            string filename = _layoutControl.Filename;

            if (saveAs || string.IsNullOrWhiteSpace(filename))
            {
                filename = GetSaveFilename();
            }

            if (string.IsNullOrWhiteSpace(filename))
            {
                return;
            }
            
            var serializer = new LayoutSerializer();
            if (serializer.SaveLayout(_layoutControl, _layoutControl.PrinterSettings, filename))
            {
                MessageService.Current.Info("Layout was saved successfully.");
            }
        }

        private string GetLoadFilename()
        {
            using (var dlg = new OpenFileDialog { Filter = @"*.xml|*.xml" })
            {
                if (dlg.ShowDialog(_view as IWin32Window) == DialogResult.OK)
                {
                    return dlg.FileName;
                }
            }

            return string.Empty;
        }

        private string GetSaveFilename()
        {
            // TODO: use service
            using (var dlg = new SaveFileDialog { Filter = @"*.xml|*.xml" })
            {
                if (dlg.ShowDialog(_view as IWin32Window) == DialogResult.OK)
                {
                    return dlg.FileName;
                }
            }

            return string.Empty;
        }

        private void AddBitmap()
        {
            // TODO: use service
            var ofd = new OpenFileDialog
                          {
                              Filter =
                                  "Images (*.png, *.jpg, *.bmp, *.gif, *.tif)|*.png;*.jpg;*.bmp;*.gif;*.tif",
                              FilterIndex = 1,
                              CheckFileExists = true
                          };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var newBitmap = new LayoutBitmap { Size = new SizeF(100, 100), Filename = ofd.FileName };
                _layoutControl.AddElementWithMouse(newBitmap);
            }
        }

        private void AddLegend()
        {
            var legend = new LayoutLegend();
            legend.Initialize(_layoutControl, _context.Legend);

            var mapElements = _layoutControl.LayoutElements.FindAll(o => (o is LayoutMap));
            if (mapElements.Count > 0)
            {
                legend.Map = mapElements[0] as LayoutMap;
            }

            _layoutControl.AddElementWithMouse(legend);
        }

        private void AddMap()
        {
            var map = new LayoutMap();

            map.Initialize(_map);
            map.Envelope = _view.Model.Extents;

            _layoutControl.AddElementWithMouse(map);
        }

        private void AddScaleBar()
        {
            var scaleBar = new LayoutScaleBar();

            var mapElements = _layoutControl.LayoutElements.FindAll(o => o is LayoutMap);

            if (mapElements.Count > 0)
            {
                var map = mapElements[0] as LayoutMap;
                if (map != null)
                {
                    scaleBar.Map = map;
                    bool km = map.Envelope.Width > 3000;
                    scaleBar.Unit = km ? LengthUnits.Kilometers : LengthUnits.Meters;
                        //TODO: allow American units as well
                }
            }

            scaleBar.LayoutControl = _layoutControl;
            _layoutControl.AddElementWithMouse(scaleBar);
        }

        private void AddTable()
        {
            var tbl = new LayoutTable();
            _layoutControl.AddElementWithMouse(tbl);
        }
    }
}