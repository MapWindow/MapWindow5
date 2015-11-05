// -------------------------------------------------------------------------------------------
// <copyright file="LayoutControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Map;
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
        }

        /// <summary>
        /// Adds or removes pages to accomodate all the currently added elements.
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

        /// <summary>
        /// Updates the extents of the map element taking into account its size of screen and scale.
        /// </summary>
        public void UpdateMapElement(IEnvelope extents)
        {
            var maps = LayoutElements.OfType<LayoutMap>().ToList();

            var map = maps.FirstOrDefault(m => m.MainMap);
            if (map != null)
            {
                map.Envelope = extents;
                map.Initialized = true;

                ClearSelection();
                AddToSelection(map);
            }
        }

        protected override void Dispose(bool disposing)
        {
            //_axMap.TilesLoaded -= MapTilesLoaded;

            base.Dispose(disposing);
        }

        public void AddMapElement(int mapScale, IEnvelope extents)
        {
            // TODO: extract to LayoutView

            var mapElement = new LayoutMap();
            mapElement.Initialize(_map);

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
                mapElement.Initialized = true;

                AddToLayout(mapElement);

                AddToSelection(mapElement);
            }
        }

        private void SelectFirstElement()
        {
            ClearSelection();

            var el = LayoutElements.OfType<LayoutMap>().FirstOrDefault() ?? LayoutElements.FirstOrDefault();

            if (el != null)
            {
                AddToSelection(new List<LayoutElement> { el });
            }
        }
    }
}