// ********************************************************************************************************
// <copyright file="BOMapWindow.cs" company="TopX Geo-ICT">
//     Copyright (c) 2012 TopX Geo-ICT. All rights reserved.
// </copyright>
// ********************************************************************************************************
// The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
// you may not use this file except in compliance with the License. You may obtain a copy of the License at 
// http:// www.mozilla.org/MPL/ 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
// ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
// limitations under the License. 
// 
// The Initial Developer of this version is Jeen de Vegt.
// 
// Contributor(s): (Open source contributors should list themselves and their modifications here). 
// Change Log: 
// Date           Changed By      Notes
// 29 March 2012  Jeen de Vegt    Inital coding
// ********************************************************************************************************

using System;
using System.Windows.Forms;
using MapWinGIS;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.TableEditor.BO
{
    /// <summary>
    ///   Takes care of the communication with the MapWindow-object
    /// </summary>
    public class AppContextWrapper
    {
        /// <summary>The MapWindow-object</summary>
        private IAppContext _context;

        /// <summary>Initializes a new instance of the BOMapWindow class</summary>
        /// <param name = "app">The name of ImapWin.</param>
        public AppContextWrapper(IAppContext app)
        {
           _context = app;
        }

        /// <summary>Updates the map with the actual selection</summary>
        /// <param name = "indices">A list of indices.</param>
        public void UpdateMap(int[] indices)
        {
          //if (indices.Length > 0)
          //{
          // _context.View.UpdateSelection(this._context.Layers.CurrentLayer, ref indices, SelectionOperation.SelectNew);
          //  //this.mapWin.View.Redraw();
          // _context.Refresh();
          //}
        }

        /// <summary>Moves to the selected shape(s)</summary>
        /// <param name = "selectedRows">A collection of th selected rows.</param>
        /// <param name = "shapeFile">The current shapefile.</param>
        public void MoveToSelected(DataGridViewSelectedRowCollection selectedRows, Shapefile shapeFile)
        {
            // TODO: Check if this is the most optimal method. Perhaps the SF objects has some better solutions
            //try
            //{
            //    MapWinGIS.Extents currentEx =_context.View.Extents;

            //    // Get the current center of the view
            //    double mpX = (currentEx.xMax - currentEx.xMin) / 2;
            //    double mpY = (currentEx.yMax - currentEx.yMin) / 2;

            //    // Determine the center point of the selected shapes
            //    double centroidX = shapeFile.get_Shape(Convert.ToInt32(selectedRows[0].Cells[0].Value)).Center.x;
            //    double centroidY = shapeFile.get_Shape(Convert.ToInt32(selectedRows[0].Cells[0].Value)).Center.y;

            //    // Check if the new centroid is calculated OK
            //    if (centroidX * centroidY != 0)
            //    {
            //        // Create new extents
            //        MapWinGIS.Extents newEx = new MapWinGIS.Extents();

            //        // Set new extents
            //        newEx.SetBounds((centroidX - mpX), (centroidY - mpY), 0, (centroidX + mpX), (centroidY + mpY), 0);

            //       _context.View.Extents = newEx;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(string.Format("Error in MoveToSelected: {0}", ex.Message));
            //}
        }

        /// <summary>Zoom to the selected shape(s)</summary>
        /// <param name = "selectedRows">A collection of the selected rows.</param>
        /// <param name = "shapeFile">The current shapefile.</param>
        public void ZoomToSelected(DataGridViewSelectedRowCollection selectedRows, Shapefile shapeFile)
        {
            //try
            //{
            //    double maxX = double.MinValue;
            //    double maxY = double.MinValue;
            //    double minX = double.MaxValue;
            //    double minY = double.MaxValue;

            //   _context.Layers[this._context.Layers.CurrentLayer].Visible = true;

            //    foreach (DataGridViewRow row in selectedRows)
            //    {
            //        MapWinGIS.Extents ext = shapeFile.QuickExtents(Convert.ToInt32(row.Cells[0].Value));

            //        maxX = ext.xMax > maxX ? ext.xMax : maxX;
            //        maxY = ext.yMax > maxY ? ext.yMax : maxY;
            //        minX = ext.xMin < minX ? ext.xMin : minX;
            //        minY = ext.yMin < minY ? ext.yMin : minY;
            //    }

            //    // Pad extents now
            //    double dx =PadExtentsSelected(maxX, minX);
            //    maxX = maxX + dx;
            //    minX = minX - dx;

            //    double dy =PadExtentsSelected(maxY, minY);
            //    maxY = maxY + dy;
            //    minY = minY - dy;

            //    MapWinGIS.Extents exts = new Extents();

            //    if (this._context.View.SelectedShapes.NumSelected == 1 
            //      &&_context.Layers[this._context.Layers.CurrentLayer].LayerType == eLayerType.PointShapefile)
            //    {
            //        MapWinGIS.Shapefile sf =_context.Layers[this._context.Layers.CurrentLayer] as Shapefile;

            //        double xpad = (1 / 100) * (sf.Extents.xMax - sf.Extents.xMin);
            //        double ypad = (1 / 100) * (sf.Extents.yMax - sf.Extents.yMin);

            //        exts.SetBounds(minX + xpad, minY - ypad, 0, maxX - xpad, maxY + ypad, 0);
            //    }
            //    else
            //    {
            //        exts.SetBounds(minX, minY, 0, maxX, maxY, 0);
            //    }

            //   _context.View.Extents = exts;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(string.Format("Error in ZoomToSelected: {0}", ex.Message));
            //}
        }

        /// <summary>Zoom to the shape dat is currently selected/edited</summary>
        /// <param name = "shapeId">Id of the selected shape.</param>
        /// <param name = "shapeFile">The current shapefile.</param>
        public void ZoomToEdit(int shapeId, Shapefile shapeFile)
        {
            //try
            //{
            //    MapWinGIS.Shape shape = shapeFile.get_Shape(shapeId);

            //    double maxX = shape.Extents.xMax;
            //    double maxY = shape.Extents.yMax;
            //    double minX = shape.Extents.xMin;
            //    double minY = shape.Extents.yMin;

            //   _context.Layers[this._context.Layers.CurrentLayer].Visible = true;

            //    // Pad extents now
            //    double dx =PadExtentsEdit(maxX, minX);
            //    maxX += dx;
            //    minX -= dx;

            //    double dy =PadExtentsEdit(maxY, minY);
            //    maxY += dy;
            //    minY -= dy;

            //    MapWinGIS.Extents exts = new MapWinGIS.Extents();
            //    exts.SetBounds(minX, minY, 0, maxX, maxY, 0);

            //   _context.View.Extents = exts;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(string.Format("Error: {0}", ex.Message));
            //}
        }

        /// <summary>Save shapfileData to a shapefile</summary>
        /// <param name = "shapeFile">The current shapefile.</param>
        public void ExportShapes(Shapefile shapeFile)
        {
            //if (this._context.Layers.NumLayers == 0)
            //{
            //    MessageBox.Show("No layer selected.");
            //    return;
            //}

            //if (shapeFile.NumSelected == 0)
            //{
            //    MessageBox.Show("No shapes selected.");
            //    return;
            //}

            //SaveFileDialog saveFileDialog = new SaveFileDialog
            //    {
            //        Filter = @"Shapefiles (*.shp)|*.shp", 
            //        FilterIndex = 2, 
            //        RestoreDirectory = true
            //    };

            //if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    bool loadShapeFile = MessageBox.Show(@"Do you want to load the new shapefile?", @"TableEditor", MessageBoxButtons.YesNo) == DialogResult.Yes;

            //    // TODO: Use new export method of SF object:
            //    MapWinGeoProc.Selection.ExportSelectedMWViewShapes(this._context, saveFileDialog.FileName, loadShapeFile);
            //}
        }

        /// <summary>
        /// Marks that project is changed and is to be saved anew (after join operation, for example)
        /// </summary>
        public void MarkProjectModified()
        {
           //_context.Project.Modified = true;
        }

        /// <summary>Set Exent for selected</summary>
        /// <param name = "max">Max value.</param>
        /// <param name = "min">Min value.</param>
        /// <returns>The result extent</returns>
        private double PadExtentsSelected(double max, double min)
        {
            double dx = max - min;

            dx /= 8;

            return dx == 0 ? 1 : dx;
        }

        /// <summary>Set Exent for edit</summary>
        /// <param name = "max">Max value.</param>
        /// <param name = "min">Min value.</param>
        /// <returns>The result extent</returns>
        private double PadExtentsEdit(double max, double min)
        {
            double dx = max - min;

//            dx *= _context.View.ExtentPad;

            return dx == 0 ? 1 : dx;
        }
    }
}
