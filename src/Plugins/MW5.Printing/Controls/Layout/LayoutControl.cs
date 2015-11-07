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

        public void Initialize(IPrintableMap map)
        {
            if (map == null) throw new ArgumentNullException("map");

            _map = map;

            _initialized = true;

            ZoomFitToScreen();

            UpdateScrollBars();
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