// ********************************************************************************************************
// <copyright file="MWLite.Symbology.cs" company="MapWindow.org">
// Copyright (c) MapWindow.org. All rights reserved.
// </copyright>
// The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
// you may not use this file except in compliance with the License. You may obtain a copy of the License at 
// http:// Www.mozilla.org/MPL/ 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
// ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
// limitations under the License. 
// 
// The Initial Developer of this version of the Original Code is Sergei Leschinski
// 
// Contributor(s): (Open source contributors should list themselves and their modifications here). 
// Change Log: 
// Date            Changed By      Notes
// ********************************************************************************************************

using System.Drawing;
using System.Windows.Forms;
using MW5.Api.Legend.Abstract;

namespace MW5.Plugins.Symbology.Forms
{
    partial class frmSymbologyMain
    {
        /// <summary>
        /// Initializes the state of dynamic visibility controls
        /// </summary>
        private void InitVisibilityTab()
        {
            scaleLayer.Locked = true;

            ILegendLayer layer = _layer;
            scaleLayer.MaximumScale = layer.MaxVisibleScale;
            scaleLayer.MinimimScale = layer.MinVisibleScale;
            scaleLayer.UseDynamicVisibility = layer.DynamicVisibility;

            var map = _legend.Map;
            scaleLayer.CurrentScale = map.CurrentScale;
            
            Color color = _shapefile.GeometryType == MW5.Api.GeometryType.Polyline? _shapefile.Style.Line.Color : _shapefile.Style.Fill.Color;
            scaleLayer.FillColor = color;

            scaleLayer.Locked = false;
        }

        /// <summary>
        /// Handles the changes in the dynamic visibility state of the layer
        /// </summary>
        private void scaleLayer_StateChanged()
        {
            if (_noEvents)
                return;

            _layer.MaxVisibleScale = scaleLayer.MaximumScale;
            _layer.MinVisibleScale = scaleLayer.MinimimScale;
            _layer.DynamicVisibility = scaleLayer.UseDynamicVisibility;
            RedrawMap();
            Application.DoEvents();
        }
    }
}
