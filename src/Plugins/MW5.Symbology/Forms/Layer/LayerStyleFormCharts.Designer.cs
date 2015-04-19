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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Controls.ImageCombo;
using MW5.Plugins.Symbology.Forms.Style;
using MW5.Plugins.Symbology.Helpers;

namespace MW5.Plugins.Symbology.Forms.Layer
{
    partial class LayerStyleForm
    {
        /// <summary>
        /// The code for initialization of the charts tab
        /// </summary>
        private void InitChartsTab()
        {
            icbChartColorScheme.ComboStyle = SchemeType.Graduated;
            icbChartColorScheme.SchemeTarget = SchemeTarget.Charts;
            if (icbChartColorScheme.Items.Count > 0)
            {
                icbChartColorScheme.SelectedIndex = 0;
            }

            var charts = _shapefile.Diagrams;
            chkChartsVisible.Checked = charts.Visible;

            optChartBars.Checked = (charts.DiagramType == DiagramType.Bar);
            optChartsPie.Checked = (charts.DiagramType == DiagramType.Pie);
        }

        /// <summary>
        ///  Draws preview on the charts tab
        /// </summary>
        private void DrawChartsPreview()
        {
            var rect = pctCharts.ClientRectangle;
            var bmp = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            var charts = _shapefile.Diagrams;
            if (charts.Count > 0 && charts.Fields.Any())
            {
                var g = Graphics.FromImage(bmp);
                _shapefile.Diagrams.DrawChart(g, (rect.Width - charts.IconWidth) / 2, (rect.Height - charts.IconHeight) / 2, false, Color.White);
            }
            pctCharts.Image = bmp;
        }

        /// <summary>
        /// Opens form to change chart appearance
        /// </summary>
        private void btnChartAppearance_Click(object sender, EventArgs e)
        {
            using (var form = new ChartStyleForm(_context, _layer))
            {
                _context.View.ShowChildView(form, this);
            }

            // even if cancel was hit, a user could have applied the options
            bool state = LockUpdate;
            LockUpdate = true;
            optChartBars.Checked = _shapefile.Diagrams.DiagramType == DiagramType.Bar;
            optChartsPie.Checked = _shapefile.Diagrams.DiagramType == DiagramType.Pie;
            LockUpdate = state;

            DrawChartsPreview();
            RefreshControlsState(null, null);
            RedrawMap();
        }

        /// <summary>
        /// Removes all chart fields and redraws the map
        /// </summary>
        private void btnClearCharts_Click(object sender, EventArgs e)
        {
            if (MessageService.Current.Ask("Do you want to delete charts?"))
            {
                _shapefile.Diagrams.Fields.Clear();
                _shapefile.Diagrams.Clear();
                RefreshControlsState(null, null);
                DrawChartsPreview();
                RedrawMap();
            }
        }

        /// <summary>
        /// Updating preview for charts
        /// </summary>
        private void optChartBars_CheckedChanged(object sender, EventArgs e)
        {
            Ui2Settings(null, null);
            DrawAllPreviews();
        }

        /// <summary>
        /// Updating colors of the charts
        /// </summary>
        private void icbChartColorScheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            var schemes = icbChartColorScheme.ColorSchemes.List;
            if (schemes != null && icbChartColorScheme.SelectedIndex >= 0)
            {
                Ui2Settings(null, null);
                DrawChartsPreview();
                RedrawMap();
            }
        }

        /// <summary>
        /// Sets the properties of the labels based upon user input
        /// </summary>
        private void UpdateCharts()
        {
            var charts = _shapefile.Diagrams;
            charts.Visible = chkChartsVisible.Checked;
            charts.DiagramType = optChartBars.Checked ? DiagramType.Bar : DiagramType.Pie;
            this.UpdateFieldColors();
            DrawChartsPreview();
        }

        private void UpdateFieldColors()
        {
            var schemes = icbChartColorScheme.ColorSchemes.List;
            if (schemes != null && icbChartColorScheme.SelectedIndex >= 0)
            {
                var blend = (ColorBlend)schemes[icbChartColorScheme.SelectedIndex];
                var scheme = blend.ToColorScheme();
                if (scheme != null)
                {
                    int fieldCount = _shapefile.Diagrams.Fields.Count;
                    for (int i = 0; i < fieldCount; i++)
                    {
                        var field = _shapefile.Diagrams.Fields[i];
                        double value = (double)(i) / (double)(fieldCount - 1);
                        field.Color = scheme.GetGraduatedColor(value);
                    }
                }
            }
        }

        /// <summary>
        /// Opens editor of color schemes
        /// </summary>
        private void btnChartsEditColorScheme_Click(object sender, EventArgs e)
        {
            using (var form = new ColorSchemesForm(_context, icbChartColorScheme.ColorSchemes))
            {
                _context.View.ShowChildView(form, this);
            }
        }
    }
}
