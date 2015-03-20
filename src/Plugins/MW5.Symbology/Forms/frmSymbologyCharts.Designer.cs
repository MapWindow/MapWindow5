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
using MW5.Plugins.Symbology.Controls;
using MW5.Plugins.Symbology.Forms.Charts;
using MW5.Plugins.Symbology.Forms.Utilities;
using MW5.Plugins.Symbology.Helpers;

namespace MW5.Plugins.Symbology.Forms
{
    partial class frmSymbologyMain
    {
        /// <summary>
        /// The code for initialization of the charts tab
        /// </summary>
        private void InitChartsTab()
        {

            icbChartColorScheme.ComboStyle = ImageComboStyle.ColorSchemeGraduated;
            //icbChartColorScheme.ColorSchemes = m_plugin.ChartColors;
            if (icbChartColorScheme.Items.Count > 0)
            {
                icbChartColorScheme.SelectedIndex = 0;
            }

            var charts = _shapefile.Diagrams;
            chkChartsVisible.Checked = charts.Visible;
            //cboChartVerticalPosition.SelectedIndex = (int)charts.VerticalPosition;

            optChartBars.Checked = (charts.DiagramType == DiagramType.Bar);
            optChartsPie.Checked = (charts.DiagramType == DiagramType.Pie);
        }

        /// <summary>
        ///  Draws preview on the charts tab
        /// </summary>
        private void DrawChartsPreview()
        {
            Rectangle rect = pctCharts.ClientRectangle;
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            if (_shapefile.Diagrams.Count > 0 && _shapefile.Diagrams.Fields.Any())
            {
                Graphics g = Graphics.FromImage(bmp);
                IntPtr ptr = g.GetHdc();

                int width = rect.Width;
                int height = rect.Height;

                var charts = _shapefile.Diagrams;

                //if (charts.DiagramType == DiagramType.PieChart)
                //    charts.DrawChart(ptr, (width - charts.IconWidth) / 2, (height - charts.IconHeight) / 2, false,  Color.White));
                //else
                //    charts.DrawChart(ptr, (width - charts.IconWidth) / 2, (height - charts.IconHeight) / 2, false,  Color.White));

                g.ReleaseHdc(ptr);
            }
            pctCharts.Image = bmp;
        }


        /// <summary>
        /// Opens form to change chart appearance
        /// </summary>
        private void btnChartAppearance_Click(object sender, EventArgs e)
        {
            ChartStyleForm form = new ChartStyleForm(_legend, _shapefile, false, _layerHandle);
            form.ShowDialog();

            // even if cancel was hit, a user could have applied the options
            bool state = _noEvents;
            _noEvents = true;
            optChartBars.Checked = (_shapefile.Diagrams.DiagramType == DiagramType.Bar);
            optChartsPie.Checked = (_shapefile.Diagrams.DiagramType == DiagramType.Pie);
            _noEvents = state;

            DrawChartsPreview();
            RefreshControlsState(null, null);
            RedrawMap();
        }

        /// <summary>
        /// Removes all chart fields and redraws the map
        /// </summary>
        private void btnClearCharts_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete charts?", "MapWindow_5", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            GUI2Settings(null, null);
            DrawAllPreviews();
        }

        /// <summary>
        /// Updating colors of the charts
        /// </summary>
        private void icbChartColorScheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ColorBlend> schemes = icbChartColorScheme.ColorSchemes.List;
            if (schemes != null && icbChartColorScheme.SelectedIndex >= 0)
            {
                GUI2Settings(null, null);
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
                ColorBlend blend = (ColorBlend)schemes[icbChartColorScheme.SelectedIndex];
                ColorRamp scheme = ColorSchemeProvider.ColorBlend2ColorScheme(blend);
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
            frmColorSchemes form = new frmColorSchemes(ref Globals.ChartColors);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                icbChartColorScheme.ColorSchemes = Globals.ChartColors;
            }
            form.Dispose();
        }
    }
}
