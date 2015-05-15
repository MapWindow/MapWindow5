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
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Symbology.Services;

namespace MW5.Plugins.Symbology.Helpers
{
    internal class LabelHelper
    {
        /// <summary>
        /// Retunrns label string formed by the first record of attribute table
        /// </summary>
        internal static string get_LabelText(IFeatureSet sf, string expression, bool byClassificationField = false)
        {
            if (expression.ToLower() == "<no expression>")
            {
                if (sf.Labels.Items.Count > 0)
                {
                    return sf.Labels.Items[0].Text;
                }
                return "";
            }

            if (byClassificationField)
            {
                int index = sf.Labels.ClassificationField;
                var val = sf.Table.CellValue(index, 0);
                if (val != null)
                {
                    return val.ToString();
                }
            }
            else
            {
                object obj; string err;
                expression = FixExpression(expression);
                if (sf.Table.Calculate(expression, 0, out obj, out err))
                {
                    return obj.ToString();
                }
            }
            return "";
        }

        /// <summary>
        /// Draws preview based on the category options and expression stored in the Labels class
        /// </summary>
        internal static void DrawPreview(ILabelStyle category, IFeatureSet sf, System.Windows.Forms.PictureBox canvas, bool forceDrawing)
        {
            string expression = (sf.Labels.Expression == "" && sf.Labels.Items.Count != 0) ? "<no expression>" : sf.Labels.Expression;
            DrawPreview(category, sf, canvas, expression, forceDrawing);
        }

        /// <summary>
        /// Renders a grid under label preview.
        /// </summary>
        private static void RenderGrid(Bitmap img, Graphics g)
        {
            const int count = 50;
            var gridPen = new Pen(Color.LightGray);
            float step = (float)img.Height / count;

            for (int i = 0; i < count; i++)
            {
                g.DrawLine(gridPen, 0.0f, step * i, img.Width, step * i);
            }

            step = (float)img.Width / count;
            for (int j = 0; j < count; j++)
            {
                g.DrawLine(gridPen, step * j, 0.0f, step * j, img.Height);
            }
        }

        /// <summary>
        /// Draws preview based on the specified expression string
        /// </summary>
        internal static void DrawPreview(ILabelStyle category, IFeatureSet sf, PictureBox canvas, 
            string expression, bool forceDrawing, bool renderGrid = false, bool basePoint = false)
        {
            string s = get_LabelText(sf, expression);
            if (s.Trim() == string.Empty)
            {
                s = "";
            }

            Bitmap img = new Bitmap(canvas.ClientRectangle.Width, canvas.ClientRectangle.Height);
            Graphics g = Graphics.FromImage(img);

            if (renderGrid)
            {
                RenderGrid(img, g);
            }

            Point pntOrigin = new Point((canvas.ClientRectangle.Right + canvas.ClientRectangle.Left) / 2,
                                                                      (canvas.ClientRectangle.Bottom + canvas.ClientRectangle.Top) / 2);

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;

            // drawing the label
            var style = new LabelStyleRenderer(category);
            if (sf.Labels.Items.Count > 0 || forceDrawing)
            {
                // drawing base point
                if (basePoint)
                {
                    Pen pen = new Pen(Color.Black, 2);
                    var rect = new Rectangle(pntOrigin.X, pntOrigin.Y, 2, 2);
                    g.DrawEllipse(pen, rect);
                    pen.Dispose();
                }

                style.Draw(g, pntOrigin, s, true, 0);
            }

            if (canvas.Image != null)
            {
                canvas.Image.Dispose();
            }

            canvas.Image = img;
        }

        /// <summary>
        /// Returns the expression which complies with the ocx parser rules.
        /// The new line characters should be placed in quotes.
        /// </summary>
        internal static string FixExpression(string s)
        {
            string res = "";
            int count = 0;
            
            foreach (char t in s)
            {
                if (t == '\"')
                {
                    count++;
                }

                // there is new line character outside any brackets
                if (t == '\n' && count % 2 == 0)
                {
                    res += "\"\n\"+";
                }
                else
                {
                    res += t;
                }
            }
            return res;
        }

        /// <summary>
        /// Returns the string without quotes around new line
        /// </summary>
        internal static string StripNewLineQuotes(string s)
        {
            string res = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (i < s.Length - 3)
                {
                    if (s.Substring(i, 4) == "\"\n\"+")
                    {
                        res += "\n";
                        i = i + 3;
                    }
                    else
                        res += s[i];
                }
                else
                    res += s[i];
            }
            return res;
        }

        /// <summary>
        /// Generate label categories for the given set of shapefile categories
        /// </summary>
        internal static void GenerateCategories(IMuteLegend legend, int layerHandle)
        {
            var lyr = legend.Layers.ItemByHandle(layerHandle);
            var sf = lyr.FeatureSet;
            var lb = sf.Labels;

            //sf.Labels.ClearCategories();
            //for (int i = 0; i < sf.Categories.Count; i++)
            //{
            //    ShapefileCategory cat = sf.Categories.get_Item(i);
            //    LabelCategory labelCat = lb.AddCategory(cat.Name);
            //    labelCat.Expression = cat.Expression;
            //}

            //SymbologySettings settings = Globals.get_LayerSettings(layerHandle);
            //ColorBlend blend = (ColorBlend)settings.LabelsScheme;

            //if (blend != null)
            //{
            //    ColorScheme scheme = ColorSchemes.ColorBlend2ColorScheme(blend);
            //    if (settings.LabelsRandomColors)
            //    {
            //        lb.ApplyColorScheme(tkColorSchemeType.ctSchemeRandom, scheme);
            //    }
            //    else
            //    {
            //        lb.ApplyColorScheme(tkColorSchemeType.ctSchemeGraduated, scheme);
            //    }
            //}

            //if (settings.LabelsVariableSize)
            //{
            //    for (int i = 0; i < lb.NumCategories; i++)
            //    {
            //        lb.get_Category(i).FontSize = (int)((double)sf.Labels.FontSize +
            //        (double)settings.LabelsSizeRange / ((double)lb.NumCategories - 1) * (double)i);
            //    }
            //}

            //// Expressions aren't supported by labels yet, therefore we need to copy indices from the symbology
            //for (int i = 0; i < lb.Count; i++)
            //{
            //    MapWinGIS.Label label = lb.get_Label(i, 0);
            //    label.Category = sf.get_ShapeCategory(i);
            //}
        }
    }
}
