// -------------------------------------------------------------------------------------------
// <copyright file="LayoutMenuListener.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Map;
using MW5.Plugins.Concrete;
using MW5.Plugins.Events;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Printing.Controls.Layout;
using MW5.Plugins.Printing.Enums;
using MW5.Plugins.Printing.Helpers;
using MW5.Plugins.Printing.Model.Elements;
using MW5.Plugins.Printing.Services;
using MW5.Plugins.Printing.Views.Abstract;
using MW5.Plugins.Services;
using MW5.Shared;
using Syncfusion.Pdf;
using Syncfusion.XPS;

namespace MW5.Plugins.Printing.Views
{
    internal class LayoutMenuListener
    {
        private readonly IAppContext _context;
        private readonly LayoutControl _layoutControl;
        private readonly IPrintableMap _map;
        private readonly ILayoutView _view;
        private readonly PdfExportService _pdfService;

        public LayoutMenuListener(IAppContext context, ILayoutView view, PdfExportService pdfService)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (view == null) throw new ArgumentNullException("view");
            if (pdfService == null) throw new ArgumentNullException("pdfService");

            _context = context;
            _view = view;
            _pdfService = pdfService;
            _map = context.Map;
            _layoutControl = view.LayoutControl;
        }

        private LayoutMap SelectedMapElement
        {
            get { return _layoutControl.SelectedLayoutElements.FirstOrDefault() as LayoutMap; }
        }

        public void OnItemClicked(object sender, MenuItemEventArgs e)
        {
            _layoutControl.PanMode = false;

            switch (e.ItemKey)
            {
                case LayoutMenuKeys.RestoreToolbars:
                    _view.RestoreToolbars();
                    break;
                case LayoutMenuKeys.RestorePanels:
                    _view.RestorePanels();
                    break;
                case LayoutMenuKeys.ShowRulers:
                    _layoutControl.ShowRulers = !_layoutControl.ShowRulers;
                    break;
                case LayoutMenuKeys.AdjustPages:
                    _layoutControl.UpdateLayout();
                    break;
                case LayoutMenuKeys.SelectAll:
                    _layoutControl.SelectAll();
                    break;
                case LayoutMenuKeys.SelectNone:
                    _layoutControl.ClearSelection();
                    break;
                case LayoutMenuKeys.InvertSelection:
                    _layoutControl.InvertSelection();
                    break;
                case LayoutMenuKeys.ConvertToBitmap:
                    ConvertElementToBitmap();
                    break;
                case LayoutMenuKeys.MoveUp:
                    _layoutControl.MoveSelectionUp();
                    break;
                case LayoutMenuKeys.MoveDown:
                    _layoutControl.MoveSelectionDown();
                    break;
                case LayoutMenuKeys.DeleteElement:
                    _layoutControl.DeleteSelected();
                    break;
                case LayoutMenuKeys.ShowMargins:
                    _layoutControl.ShowMargins = !_layoutControl.ShowMargins;
                    break;
                case LayoutMenuKeys.ShowPageNumbers:
                    _layoutControl.ShowPageNumbers = !_layoutControl.ShowPageNumbers;
                    break;
                case LayoutMenuKeys.NewLayout:
                    if (PromptSaveExistingLayout())
                    {
                        _layoutControl.Filename = string.Empty;
                        _layoutControl.ClearLayout();
                    }
                    break;
                case LayoutMenuKeys.SaveLayout:
                    SaveLayout(false);
                    break;
                case LayoutMenuKeys.SaveLayoutAs:
                    SaveLayout(true);
                    break;
                case LayoutMenuKeys.LoadLayout:
                    var ls = new LayoutSerializer();
                    ls.LoadNewLayout(_layoutControl, _context, _view.Model.Extents, _view as IWin32Window);
                    break;
                case LayoutMenuKeys.Print:
                    {
                        var service = new PrintingService();
                        service.Print(_layoutControl.Pages, _layoutControl.PrinterSettings,
                            _layoutControl.LayoutElements);
                    }
                    break;
                case LayoutMenuKeys.PrinterSetup:
                    RunPrinterSetup();
                    break;
                case LayoutMenuKeys.PageSetup:
                    RunPageSetup();
                    break;
                case LayoutMenuKeys.ExportToPdf:
                    _pdfService.ExportToPdf(_layoutControl, ParentView);
                    break;
                case LayoutMenuKeys.ExportToBitmap:
                    ExportToBitmap();
                    break;
                case LayoutMenuKeys.ZoomIn:
                    _layoutControl.ZoomIn();
                    break;
                case LayoutMenuKeys.ZoomOut:
                    _layoutControl.ZoomOut();
                    break;
                case LayoutMenuKeys.ZoomFitScreen:
                    _layoutControl.ZoomFitToScreen();
                    break;
                case LayoutMenuKeys.ZoomOriginal:
                    _layoutControl.Zoom = 1;
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
                case LayoutMenuKeys.ZoomToMaximum:
                    {
                        var map = SelectedMapElement;
                        if (map != null)
                        {
                            map.ZoomToMaxExtents();
                        }
                    }
                    break;
                case LayoutMenuKeys.ZoomToOriginalExtents:
                    {
                        var map = SelectedMapElement;
                        if (map != null)
                        {
                            map.ZooomToOriginalExtents();
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
                    }
                    break;
            }

            _view.UpdateView();
        }

        private void SaveLayout(bool saveAs)
        {
            var ls = new LayoutSerializer();
            ls.SaveLayout(_layoutControl, saveAs, _view as IWin32Window);
        }

        private void RunPrinterSetup()
        {
            using (var pd = new PrintDialog { PrinterSettings = _layoutControl.PrinterSettings })
            {
                if (pd.ShowDialog(ParentView) == DialogResult.OK)
                {
                    _layoutControl.Invalidate();
                }
            }
        }

        private void RunPageSetup()
        {
            var model = _layoutControl.PrinterSettings;
            if (_context.Container.Run<PageSetupPresenter, PrinterSettings>(model))
            {
                _layoutControl.UpdatePageSettings();
                _layoutControl.UpdateLayout();
                _layoutControl.Invalidate();
            }
        }

        private void ExportToBitmap()
        {
            var exportService = new ExportService();
            
            var paperSize = new Size(_layoutControl.Pages.TotalWidth, _layoutControl.Pages.TotalHeight);

            var bitmapSize = exportService.GetBitmapSize(paperSize, 96);

            var model = new ChooseDpiModel(bitmapSize);

            if (!_context.Container.Run<ChooseDpiPresenter, ChooseDpiModel>(model))
            {
                return;
            }

            exportService.ExportToBitmap(paperSize, _layoutControl.LayoutElements, model.Dpi);
        }

        private void ConvertElementToBitmap()
        {
            var el = _layoutControl.SelectedLayoutElements.FirstOrDefault();

            if (el == null)
            {
                MessageService.Current.Info("No elements are selected.");
                return;
            }

            if (el is LayoutBitmap)
            {
                MessageService.Current.Info("Selected element is bitmap. No conersion is needed.");
                return;
            }

            string filename = FileDialogHelper.GetBitmapFilename(el.Name, ParentView);

            if (!string.IsNullOrWhiteSpace(filename))
            {
                _layoutControl.ConvertElementToBitmap(el, filename);
            }
        }

        private bool PromptSaveExistingLayout()
        {
            var ls = new LayoutSerializer();
            return ls.PromptToSaveChanges(_layoutControl, _view as IWin32Window);
        }

        private void AddBitmap()
        {
            var ofd = new OpenFileDialog
                          {
                              Filter = PrintingConstants.BitmapFilter,
                              FilterIndex = 1,
                              CheckFileExists = true
                          };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var newBitmap = new LayoutBitmap { SizeF = new SizeF(100, 100), Filename = ofd.FileName };
                _layoutControl.AddElementWithMouse(newBitmap);
            }
        }

        private void AddLegend()
        {
            var legend = new LayoutLegend();
            legend.Initialize(_layoutControl, _context.Legend);

            var map = _layoutControl.LayoutElements.FirstOrDefault(o => (o is LayoutMap));
            
            legend.Map = map as LayoutMap;

            _layoutControl.AddElementWithMouse(legend);
        }

        private void AddMap()
        {
            var map = new LayoutMap();

            map.Initialize(_map, _layoutControl);
            map.Envelope = _view.Model.Extents;
            map.TileProvider = _context.Map.TileProvider;

            _layoutControl.AddElementWithMouse(map);
        }

        private bool IsMetricUnits()
        {
            switch (ConfigHelper.GetUnits())
            {
                case LayoutUnit.Inch:
                    return false;
                default:
                    return true;
            }
        }

        private void AddScaleBar()
        {
            var scaleBar = new LayoutScaleBar();

            var map = _layoutControl.LayoutElements.FirstOrDefault(o => o is LayoutMap) as LayoutMap;

            if (map != null)
            {
                scaleBar.Map = map;

                if (IsMetricUnits())
                {
                    bool km = map.Envelope.Width > 3000;
                    scaleBar.Unit = km ? LengthUnits.Kilometers : LengthUnits.Meters;
                }
                else
                {
                    bool km = map.Envelope.Width > 5000;
                    scaleBar.Unit = km ? LengthUnits.Miles : LengthUnits.Feet;
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

        private IWin32Window ParentView
        {
            get { return _view as IWin32Window; }
        }
    }
}