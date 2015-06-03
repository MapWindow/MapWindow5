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
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.UI.Forms;

namespace MW5.Plugins.Symbology.Forms
{
    public partial class AddLabelsForm : MapWindowForm
    {
        private readonly IFeatureSet _shapefile;
        private LabelAlignment _alignment;
        
        /// <summary>
        /// Creates a new instance of the AddLabelsForm
        /// </summary>
        public AddLabelsForm(IFeatureSet sf, LabelAlignment alignment)
        {
            InitializeComponent();

            if (sf == null)
            {
                throw new Exception("AddLabelsForm: Unexpected null parameter");
            }

            _alignment = alignment;
            _shapefile = sf;
            cboLineOrientation.Enabled = false;
            panel1.Visible = false;

            if (_shapefile.IsPolygon)
            {
                optPosition1.Text = "Center";
                optPosition2.Text = "Centroid";
                optPosition3.Text = "Interior point";
                optPosition4.Visible = false;

                optPosition1.Tag = LabelPosition.Center;
                optPosition2.Tag = LabelPosition.Centroid;
                optPosition3.Tag = LabelPosition.InteriorPoint;

                groupBox5.Height -= 30;
                groupBox4.Top -= 30;
                Height -= 30;

                optPosition2.Checked = true;        // TODO: choose according Labels.Positioning
            }
            else if (_shapefile.IsPolyline)
            {
                optPosition1.Text = "First segment";
                optPosition2.Text = "Last segment";
                optPosition3.Text = "Middle segment";
                optPosition4.Text = "The longest segment";

                optPosition1.Tag = LabelPosition.FirstSegment;
                optPosition2.Tag = LabelPosition.LastSegment;
                optPosition3.Tag = LabelPosition.MiddleSegment;
                optPosition4.Tag = LabelPosition.LongestSegement;

                optPosition4.Checked = true;      // TODO: choose according Labels.Positioning
                cboLineOrientation.Enabled = true;
            }
            else
            {
                panel1.Visible = true;
                optPosition1.Visible = false;
                optPosition2.Visible = false;
                optPosition3.Visible = false;
                optPosition4.Visible = false;
                Height -= 100;
                groupBox4.Visible = false;

                optAlignBottomCenter.Checked = (_alignment == LabelAlignment.BottomCenter);
                optAlignBottomLeft.Checked = (_alignment == LabelAlignment.BottomLeft);
                optAlignBottomRight.Checked = (_alignment == LabelAlignment.BottomRight);
                optAlignCenterLeft.Checked = (_alignment == LabelAlignment.CenterLeft);
                optAlignCenterRight.Checked = (_alignment == LabelAlignment.CenterRight || _alignment == LabelAlignment.Center);
                optAlignTopCenter.Checked = (_alignment == LabelAlignment.TopCenter);
                optAlignTopLeft.Checked = (_alignment == LabelAlignment.TopLeft);
                optAlignTopRight.Checked = (_alignment == LabelAlignment.TopRight);
                
                // Applicable for polyline and polygon shapefiles
                //throw new Exception("AddLabelsForm: invalid shapefile type");
            }

            // line orientation
            cboLineOrientation.Items.Clear();
            cboLineOrientation.Items.Add("Horizontal");
            cboLineOrientation.Items.Add("Parallel");
            cboLineOrientation.Items.Add("Perpendicular");
            cboLineOrientation.SelectedIndex = 1;
        }

        public LabelAlignment Alignment
        {
            get { return _alignment; }
        }

        /// <summary>
        /// Generates labels with specified positions
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            // callback and wait cursor
            Enabled = false;
            Cursor = Cursors.WaitCursor;

            var lb = _shapefile.Labels;
            var positioning = get_LabelPositioning();
            lb.Style.Orientation = (LabelOrientation)cboLineOrientation.SelectedIndex;
            
            try
            {
                // generation
                _shapefile.GenerateEmptyLabels(positioning, !chkLabelEveryPart.Checked);
                _shapefile.Labels.SavingMode = PersistenceType.XmlOverwrite;  // .lbl file should be updated

                if (_shapefile.PointOrMultiPoint)
                {
                    if (optAlignBottomCenter.Checked) _alignment = LabelAlignment.BottomCenter;
                    if (optAlignBottomLeft.Checked) _alignment = LabelAlignment.BottomLeft;
                    if (optAlignBottomRight.Checked) _alignment = LabelAlignment.BottomRight;
                    if (optAlignCenter.Checked) _alignment = LabelAlignment.Center;
                    if (optAlignCenterLeft.Checked) _alignment = LabelAlignment.CenterLeft;
                    if (optAlignCenterRight.Checked) _alignment = LabelAlignment.CenterRight;
                    if (optAlignTopCenter.Checked) _alignment = LabelAlignment.TopCenter;
                    if (optAlignTopLeft.Checked) _alignment = LabelAlignment.TopLeft;
                    if (optAlignTopRight.Checked) _alignment = LabelAlignment.TopRight;
                }

                // updating references to categories
                //if (lb.NumCategories > 0)
                //{
                //    for (int i = 0; i < lb.Count; i++)
                //    {
                //        MapWinGIS.Label label = lb.get_Label(i, 0);
                //        label.Category = m_shapefile.get_ShapeCategory(i);
                //    }
                //}
            }
            finally
            {
                Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        ///  Returns positioning method
        /// </summary>
        private LabelPosition get_LabelPositioning()
        {
            if (!_shapefile.PointOrMultiPoint)
            {
                if (optPosition4.Checked)
                    return (LabelPosition)optPosition4.Tag;
                if (optPosition3.Checked)
                    return (LabelPosition)optPosition3.Tag;
                if (optPosition2.Checked)
                    return (LabelPosition)optPosition2.Tag;
                if (optPosition1.Checked)
                    return (LabelPosition)optPosition1.Tag;
            }

            return LabelPosition.Centroid;
        }
    }
}
