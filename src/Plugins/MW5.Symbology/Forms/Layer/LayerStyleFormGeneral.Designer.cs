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

using System;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Static;

namespace MW5.Plugins.Symbology.Forms.Layer
{
    partial class LayerStyleForm
    {
        /// <summary>
        /// Sets the state of controls on the general tab on loading
        /// </summary>
        private void InitGeneralTab()
        {
            chkLayerVisible.Checked = _layer.Visible;
            chkLayerPreview.Checked = _metadata.ShowLayerPreview;

            txtLayerName.Text = _layer.Name;

            txtLayerSource.Text = GetLayerDescription();
        }

        private string GetLayerDescription()
        {
            string s = "";

            var map = _context.Map;
            txtComments.Text = _layer.Description;

            var ext = _shapefile.Envelope;
            //string units = Globals.get_MapUnits();
            string units = "";
            string type = _shapefile.GeometryType.ToString();

            var ogr = _layer.VectorLayer;
            if (ogr != null)
            {
                s += "Datasource type: OGR layer" + Environment.NewLine;
                s += "Driver name: " + ogr.DriverName + Environment.NewLine;
                s += "Connection string: " + ogr.ConnectionString + Environment.NewLine;
                s += "Layer type: " + ogr.SourceType.ToString() + Environment.NewLine;
                s += "Name or query: " + ogr.SourceQuery + Environment.NewLine;
                s += "Support editing: " + ogr.get_SupportsEditing(SaveType.SaveAll) + Environment.NewLine;
                s += "Dynamic loading: " + ogr.DynamicLoading + "\n";
            }
            else
            {
                s += "Datasource type: ESRI Shapefile" + Environment.NewLine;
            }

            s += "Type: " + type + Environment.NewLine +
                        "Number of shapes: " + _shapefile.Features.Count + Environment.NewLine +
                        "Selected: " + _shapefile.NumSelected + Environment.NewLine +
                        "Source: " + _shapefile.Filename + Environment.NewLine +
                        "Bounds X: " + String.Format("{0:F2}", ext.MaxX) + " to " + String.Format("{0:F2}", ext.MaxX) + units + Environment.NewLine +
                        "Bounds Y: " + String.Format("{0:F2}", ext.MinY) + " to " + String.Format("{0:F2}", ext.MaxY) + units + Environment.NewLine +
                        "Projection: " + _shapefile.Projection.ExportToProj4();
            return s;
        }

        /// <summary>
        /// Saves layer name from user input
        /// </summary>
        private void txtLayerName_Validated(object sender, EventArgs e)
        {
            _layer.Name = txtLayerName.Text;
            MarkStateChanged();
            RedrawLegend();
        }

        /// <summary>
        /// Saves layer name from user input
        /// </summary>
        private void txtLayerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                _layer.Name = txtLayerName.Text;
                MarkStateChanged();
                RedrawLegend();
            }
        }

        /// <summary>
        /// Saves layer name from user input
        /// </summary>
        private void txtComments_Validated(object sender, EventArgs e)
        {
            _layer.Description = txtComments.Text;
            MarkStateChanged();
        }

        /// <summary>
        /// Saves layer name from user input
        /// </summary>
        private void txtComments_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                _layer.Description = txtComments.Text;
                MarkStateChanged();
            }
        }

        /// <summary>
        /// Updates the state of the layer preview
        /// </summary>
        private void chkLayerPreview_CheckedChanged(object sender, EventArgs e)
        {
            if (axMap1.Layers.Count == 0 && chkLayerPreview.Checked)
            {
                ShowLayerPreview();
            }
            axMap1.Visible = chkLayerPreview.Checked;

        }

        /// <summary>
        /// Refreshes the layer preview
        /// </summary>
        private void ShowLayerPreview()
        {
            bool val = Config.LoadSymbologyOnAddLayer;
            Config.LoadSymbologyOnAddLayer = false;

            axMap1.ShowCoordinates = CoordinatesDisplay.None;
            axMap1.ScalebarVisible = false;
            axMap1.Visible = true;
            axMap1.ZoomBar.Visible = false;
            axMap1.TileProvider = TileProvider.None;
            axMap1.MapCursor = MapCursor.None;
            axMap1.MouseWheelSpeed = 1.0;
            axMap1.ZoomBehavior = ZoomBehavior.Default;
            int handle = axMap1.Layers.Add(_shapefile, true);
            axMap1.ZoomToLayer(handle);

            Config.LoadSymbologyOnAddLayer = val;
        }
    }
}
