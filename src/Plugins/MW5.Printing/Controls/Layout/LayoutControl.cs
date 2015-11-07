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
    // TODO: consider removing (rename MouseAwareLayoutControl instead)
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
            // TODO: assign page settings explicitly
            if (map == null) throw new ArgumentNullException("map");

            _map = map;

            _initialized = true;

            ZoomFitToScreen();

            UpdateScrollBars();
        }

        protected override void Dispose(bool disposing)
        {
            //_axMap.TilesLoaded -= MapTilesLoaded;

            base.Dispose(disposing);
        }
    }
}