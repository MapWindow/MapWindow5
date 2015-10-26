// -------------------------------------------------------------------------------------------
// <copyright file="LayoutControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Map;
using MW5.Plugins.Printing.Enums;
using MW5.Plugins.Printing.Helpers;
using MW5.Plugins.Printing.Model.Elements;

namespace MW5.Plugins.Printing.Controls.Layout
{
    public class LayoutControl : MouseAwareLayoutControl
    {
        private IPrintableMap _map;

        public LayoutControl()
        {
            if (DesignMode)
            {
                ZoomFitToScreen();
            }
        }

        /// <summary>
        /// Adds map element to the template
        /// </summary>
        public void AddMapElement(int mapScale, IEnvelope extents)
        {
            ClearSelection();

            if (!LayoutElements.OfType<LayoutMap>().Any())
            {
                AddNewMapElement(mapScale, extents);
            }
            else
            {
                UpdateMapElement();

                SelectMap();
            }

            ZoomFitToScreen();
        }

        /// <summary>
        /// Adjusts extent
        /// </summary>
        public double AutoChooseScale(IEnvelope ext)
        {
            // TODO: use for single page layout
            var mapEl = GetElement<LayoutMap>(ElementType.Map);
            if (mapEl != null)
            {
                GeoSize size;
                if (_map.GetGeodesicSize(ext, out size))
                {
                    return LayoutScaleHelper.CalcMapScale(size, mapEl.Size);
                }
            }

            return 0.0;
        }

        public void Initialize(PrinterSettings printerSettings, IPrintableMap map)
        {
            if (map == null) throw new ArgumentNullException("map");
            if (printerSettings == null) throw new ArgumentNullException("printerSettings");

            PrinterSettings = printerSettings;

            _map = map;

            _initialized = true;

            ZoomFitToScreen();

            UpdateScrollBars();

            Invalidate();

            //_templateName = template;

            //axMap.TilesLoaded -= MapTilesLoaded;
            //axMap.TilesLoaded += MapTilesLoaded;

            //var size = PaperSizesCache.PaperSizeByFormatName(paperFormat, _printerSettings);
            //if (size != null)
            //{
            //    _printerSettings.DefaultPageSettings.PaperSize = size;
            //}

            //if (!string.IsNullOrEmpty(_templateName))
            //{
            //    LoadLayout(_templateName, true, false);
            //}
        }

        /// <summary>
        /// Add or removes pages to accomodate all the currently added elements 
        /// </summary>
        public void UpdateLayout()
        {
            float xMax = 0;
            float yMax = 0;

            foreach (var el in LayoutElements)
            {
                if (el.Rectangle.X + el.Rectangle.Width > xMax)
                {
                    xMax = el.Rectangle.X + el.Rectangle.Width;
                }

                if (el.Rectangle.Y + el.Rectangle.Height > yMax)
                {
                    yMax = el.Rectangle.Y + el.Rectangle.Height;
                }
            }

            // set the number of pages
            Pages.PageCountX = (int)Math.Ceiling(xMax / Pages.PageWidth);
            Pages.PageCountY = (int)Math.Ceiling(yMax / Pages.PageHeight);

            ZoomFitToScreen();
        }

        protected override void Dispose(bool disposing)
        {
            //_axMap.TilesLoaded -= MapTilesLoaded;

            base.Dispose(disposing);
        }

        /// <summary>
        /// Loads layout from the specified XML file
        /// </summary>
        protected override void LoadLayout(string fileName, bool loadPaperSettings, bool promptPaperMismatch)
        {
            base.LoadLayout(fileName, loadPaperSettings, promptPaperMismatch);
            UpdateLayout();
        }

        ///// <summary>
        ///// Handles Tiles loaded event
        ///// </summary>
        //private void MapTilesLoaded(object sender, AxMapWinGIS._DMapEvents_TilesLoadedEvent e)
        //{
        //    Debug.Print("Tiles loaded: " + e.key);

        //    if (e.key.EndsWith("print"))
        //    {
        //        Thread.Sleep(50); // make sure that the wait was started
        //        LayoutPrint.autoEvent.Set();
        //    }
        //    else
        //    {
        //        foreach (var el in LayoutElements)
        //        {
        //            var map = (el as LayoutMap);
        //            if (map != null)
        //            {
        //                if (map.Guid == e.key)
        //                {
        //                    (el as LayoutMap).TilesLoaded = true;
        //                    (el as LayoutMap).RefreshElement();
        //                    Invalidate();
        //                    Debug.Print("Tiles loaded. Map update triggered: " + e.key);
        //                    RunQueue(true);
        //                }
        //            }
        //        }
        //        Util.FireEvent(this, TileLoadingEnd, new EventArgs());
        //    }
        //}

        internal static void CancelPrinting()
        {
            LayoutPrint.Cancelled = true;
            LayoutPrint.autoEvent.Set();
        }

        internal void Print()
        {
            LayoutPrint.Print(_pages, _printerSettings, LayoutElements, _pages.PageWidth, _pages.PageHeight);
        }

        private void AddNewMapElement(int mapScale, IEnvelope extents)
        {
            // TODO: extract to LayoutView

            var mapElement = new LayoutMap(_map);

            const int offset = 10;
            mapElement.Location = new Point(offset, offset); // default location
            //mapElement.DrawTiles = AxMap.Tiles.Visible;

            // calc the necessary size in paper coordinates
            GeoSize size;
            if (_map.GetGeodesicSize(extents, out size))
            {
                mapElement.Size = LayoutScaleHelper.CalcMapSize(mapScale, size);

                // set the number of pages
                _pages.PageCountX = (int)Math.Ceiling((mapElement.Size.Width + offset) / _pages.PageWidth);
                _pages.PageCountY = (int)Math.Ceiling((mapElement.Size.Height + offset) / _pages.PageHeight);

                mapElement.Envelope = extents.Clone();
                mapElement.Scale = mapScale;
                mapElement.MarkInitialized();

                AddToLayout(mapElement);
                AddToSelection(new List<LayoutElement> { mapElement });
            }
        }

        /// <summary>
        /// Selects map element.
        /// </summary>
        private void SelectMap()
        {
            var maps = LayoutElements.OfType<LayoutMap>().ToList();
            LayoutElement selectedElement = maps.FirstOrDefault(m => m.MainMap);

            if (!SelectedLayoutElements.Any() && selectedElement == null)
            {
                selectedElement = LayoutElements.OfType<LayoutMap>().Any()
                                      ? LayoutElements.OfType<LayoutMap>().FirstOrDefault()
                                      : LayoutElements.FirstOrDefault();
            }

            if (selectedElement != null)
            {
                AddToSelection(new List<LayoutElement> { selectedElement });
            }
        }

        /// <summary>
        /// Updates the extents of the map element taking into account its size of screen and scale.
        /// </summary>
        private void UpdateMapElement()
        {
            var maps = LayoutElements.OfType<LayoutMap>().ToList();

            // substitute map in template
            var map = maps.FirstOrDefault(m => m.MainMap);
            if (map != null)
            {
                map.Scale = map.Scale;
                map.MarkInitialized();
            }

            // other maps
            //var center = _extents.Center;

            //foreach (var submap in maps.Where(m => !m.MainMap))
            //{
            //    if (submap.UpdateMapArea)
            //    {
            //        int scale = submap.Scale;
            //        var env = submap.Envelope;
            //        env.MoveCenterTo(center.X, center.Y);
            //        submap.Envelope = env;
            //        submap.Scale = scale;
            //    }
            //}
        }
    }
}