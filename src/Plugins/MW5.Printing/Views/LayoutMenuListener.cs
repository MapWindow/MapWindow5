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
using MW5.Plugins.Printing.Model.Elements;
using MW5.Plugins.Printing.Views.Abstract;

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
                    _layoutControl.NewLayout(true);
                    break;
                case LayoutMenuKeys.SaveLayout:
                    _layoutControl.SaveLayout(false);
                    break;
                case LayoutMenuKeys.SaveLayoutAs:
                    _layoutControl.SaveLayout(true);
                    break;
                case LayoutMenuKeys.LoadLayout:
                    _layoutControl.LoadLayout(true, true, true);
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
            var lsb = new LayoutLegend(_layoutControl, _context.Legend);

            var mapElements = _layoutControl.LayoutElements.FindAll(o => (o is LayoutMap));
            if (mapElements.Count > 0)
            {
                lsb.Map = mapElements[0] as LayoutMap;
            }

            _layoutControl.AddElementWithMouse(lsb);
        }

        private void AddMap()
        {
            var map = new LayoutMap(_map) { Envelope = _view.Model.Extents };
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