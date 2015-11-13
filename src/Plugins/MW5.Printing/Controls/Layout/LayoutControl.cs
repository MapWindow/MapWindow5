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
using MW5.Plugins.Printing.Services;

namespace MW5.Plugins.Printing.Controls.Layout
{
    // TODO: consider removing (rename MouseAwareLayoutControl instead)
    public class LayoutControl : MouseAwareLayoutControl
    {
        private IPrintableMap _map;
        private TileLoadingService _loadingService;

        public LayoutControl()
        {
            if (DesignMode)
            {
                ZoomFitToScreen();
            }
        }

        public TileLoadingService TileLoader
        {
            get { return _loadingService; }
        }

        public void Initialize(IPrintableMap map, TileLoadingService loadingService)
        {
            // TODO: assign page settings explicitly
            if (map == null) throw new ArgumentNullException("map");
            if (loadingService == null) throw new ArgumentNullException("loadingService");

            _map = map;
            _loadingService = loadingService;
            _loadingService.Initialize(_map, this);

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