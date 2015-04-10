using System;
using System.Windows.Forms;
using AxMapWinGIS;
using MapWinGIS;
using MW5.Api;
using MW5.Api.Enums;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.TableEditor.Legacy
{
    /// <summary>
    /// Takes care of the communication with the main app.
    /// </summary>
    public class AppContextWrapper
    {
        private readonly IAppContext _context;

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
            if (indices.Length > 0)
            {
                _context.Layers.Current.UpdateSelection(indices, SelectionOperation.New);
                _context.Map.Redraw();
                _context.View.Update();
            }
        }

        private AxMap Map
        {
            get
            {
                var map = _context.Map.InternalObject as AxMap;
                if (map == null)
                {
                    throw new NullReferenceException("Can't access AxMap.");
                }
                return map;
            }
        }

        /// <summary>Moves to the selected shape(s)</summary>
        /// <param name = "selectedRows">A collection of th selected rows.</param>
        /// <param name = "shapefile">The current shapefile.</param>
        public void MoveToSelected(DataGridViewSelectedRowCollection selectedRows, Shapefile shapefile)
        {
            // TODO: Check if this is the most optimal method. Perhaps the SF objects has some better solutions
            try
            {
                var map = Map;
                var currentEx = map.Extents as Extents;
                if (currentEx == null)
                {
                    throw new NullReferenceException("Can't access map extents.");
                }

                // Get the current center of the view
                double mpX = (currentEx.xMax - currentEx.xMin) / 2;
                double mpY = (currentEx.yMax - currentEx.yMin) / 2;

                // Determine the center point of the selected shapes
                double centroidX = shapefile.Shape[Convert.ToInt32(selectedRows[0].Cells[0].Value)].Center.x;
                double centroidY = shapefile.Shape[Convert.ToInt32(selectedRows[0].Cells[0].Value)].Center.y;

                // Check if the new centroid is calculated OK
                if (centroidX * centroidY != 0)
                {
                    // Create new extents
                    var newEx = new Extents();

                    // Set new extents
                    newEx.SetBounds((centroidX - mpX), (centroidY - mpY), 0, (centroidX + mpX), (centroidY + mpY), 0);

                    map.Extents = newEx;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error in MoveToSelected: {0}", ex.Message));
            }
        }

        /// <summary>Zoom to the selected shape(s)</summary>
        /// <param name = "selectedRows">A collection of the selected rows.</param>
        /// <param name = "shapeFile">The current shapefile.</param>
        public void ZoomToSelected(DataGridViewSelectedRowCollection selectedRows, Shapefile shapeFile)
        {
            try
            {
                double maxX = double.MinValue;
                double maxY = double.MinValue;
                double minX = double.MaxValue;
                double minY = double.MaxValue;
                
                var layer = _context.Layers.Current;
                if (layer == null || layer.FeatureSet == null)
                {
                    return;
                }

                layer.Visible = true;

                foreach (DataGridViewRow row in selectedRows)
                {
                    var ext = shapeFile.QuickExtents(Convert.ToInt32(row.Cells[0].Value));

                    maxX = ext.xMax > maxX ? ext.xMax : maxX;
                    maxY = ext.yMax > maxY ? ext.yMax : maxY;
                    minX = ext.xMin < minX ? ext.xMin : minX;
                    minY = ext.yMin < minY ? ext.yMin : minY;
                }

                // Pad extents now
                double dx = PadExtentsSelected(maxX, minX);
                maxX = maxX + dx;
                minX = minX - dx;

                double dy = PadExtentsSelected(maxY, minY);
                maxY = maxY + dy;
                minY = minY - dy;

                var exts = new Extents();

                if (layer.FeatureSet.NumSelected == 1 && layer.FeatureSet.PointOrMultiPoint)
                {
                    var sf = layer.FeatureSet.InternalObject as Shapefile;
                    if (sf != null)
                    {
                        double xpad = (1/100)*(sf.Extents.xMax - sf.Extents.xMin);
                        double ypad = (1/100)*(sf.Extents.yMax - sf.Extents.yMin);

                        exts.SetBounds(minX + xpad, minY - ypad, 0, maxX - xpad, maxY + ypad, 0);
                    }
                }
                else
                {
                    exts.SetBounds(minX, minY, 0, maxX, maxY, 0);
                }

                var map = Map;
                map.Extents = exts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error in ZoomToSelected: {0}", ex.Message));
            }
        }

        /// <summary>Zoom to the shape dat is currently selected/edited</summary>
        /// <param name = "shapeId">Id of the selected shape.</param>
        /// <param name = "shapefile">The current shapefile.</param>
        public void ZoomToEdit(int shapeId, Shapefile shapefile)
        {
            try
            {
                var shape = shapefile.Shape[shapeId];

                double maxX = shape.Extents.xMax;
                double maxY = shape.Extents.yMax;
                double minX = shape.Extents.xMin;
                double minY = shape.Extents.yMin;

                _context.Layers.Current.Visible = true;

                // Pad extents now
                double dx = PadExtentsEdit(maxX, minX);
                maxX += dx;
                minX -= dx;

                double dy = PadExtentsEdit(maxY, minY);
                maxY += dy;
                minY -= dy;

                var exts = new Extents();
                exts.SetBounds(minX, minY, 0, maxX, maxY, 0);

                Map.Extents = exts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>Save shapfileData to a shapefile</summary>
        /// <param name = "shapeFile">The current shapefile.</param>
        public void ExportShapes(Shapefile shapeFile)
        {
            if (_context.Layers.Count == 0)
            {
                MessageBox.Show("No layer selected.");
                return;
            }

            if (shapeFile.NumSelected == 0)
            {
                MessageBox.Show("No shapes selected.");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = @"Shapefiles (*.shp)|*.shp",
                    FilterIndex = 2,
                    RestoreDirectory = true
                };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                bool loadShapeFile = MessageBox.Show(@"Do you want to load the new shapefile?", @"TableEditor", MessageBoxButtons.YesNo) == DialogResult.Yes;

                // TODO: Use new export method of SF object:
                //MapWinGeoProc.Selection.ExportSelectedMWViewShapes(_context, saveFileDialog.FileName, loadShapeFile);
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Marks that project is changed and is to be saved anew (after join operation, for example)
        /// </summary>
        public void MarkProjectModified()
        {
            _context.Project.SetModified();
        }

        /// <summary>Set Exent for selected</summary>
        /// <param name = "max">Max value.</param>
        /// <param name = "min">Min value.</param>
        /// <returns>The result extent</returns>
        private double PadExtentsSelected(double max, double min)
        {
            var dx = max - min;

            dx /= 8;

            return dx == 0 ? 1 : dx;
        }

        /// <summary>Set Exent for edit</summary>
        /// <param name = "max">Max value.</param>
        /// <param name = "min">Min value.</param>
        /// <returns>The result extent</returns>
        private double PadExtentsEdit(double max, double min)
        {
            var dx = max - min;

            dx *= _context.Map.ExtentPad;

            return dx == 0 ? 1 : dx;
        }
    }
}