// ----------------------------------------------------------------------------
// MapWindow.Controls.Projections: store controls to work with EPSG projections
// database
// Author: Sergei Leschinski
// ----------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces.Projections;

namespace MW5.Projections.Controls
{
    /// <summary>
    /// A control which encapsulates the loading of World map and drawing the bounds of coordinate systems (projections) on it
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MapControl))]
    public class ProjectionMap : MapControl
    {
        // handle of the layer to display projections
        private int _handleCs = -1;

        // shapefile layer with currently selected bounds
        private int _handleBounds = -1;

        /// <summary>
        /// Delegate for CoordinatesChanged event
        /// </summary>
        public delegate void CoordinatesChangedDelegate(double x, double y, string textX, string textY);
        
        /// <summary>
        /// Event fired when map coordinates are changed
        /// </summary>
        public event CoordinatesChangedDelegate CoordinatesChanged;
        
        /// <summary>
        /// Passes CoordinatesChanged event to all listeners
        /// </summary>
        internal void FireCoordinateChanged(double x, double y, string textX, string textY)
        {
            if (CoordinatesChanged != null)
                CoordinatesChanged(x, y, textX, textY);
        }

        /// <summary>
        /// Creates a new instance of projection map class
        /// </summary>
        public ProjectionMap()
        {
            MouseMove += ProjectionMap_MouseMove;
        }

        void ProjectionMap_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            double x, y;
            PixelToProj(e.X, e.Y, out x, out y);

            const string format = "#.000";
            string sx = (x < -180.000) ? "<180.0" : (x > 180.0) ? ">180.0" : x.ToString(format);
            string sy = (y < -90.0) ? "<90.0" : (y > 90.0) ? ">90.0" : y.ToString(format);
            FireCoordinateChanged(x, y, sx, sy);
        }

        /// <summary>
        /// Loads map state based on relative path, build from executable name.
        /// It's assumed: \EPSG Reference\world.state.
        /// </summary>
        /// <param name="exeName">The filename of executable to build the path to state, MapWindow.exe is expected</param>
        /// <returns></returns>
        public bool LoadStateFromExeName(string exeName)
        {
            string path = Path.GetDirectoryName(exeName) + @"\Projections\";
            string filename = path + @"world.state";
            return LoadStateFromFile(filename);
        }

        /// <summary>
        /// Loads world project
        /// </summary>
        /// <param name="filename">The filename to load map state from</param>
        /// <returns>True on success and false otherwise</returns>
        public bool LoadStateFromFile(string filename)
        {
            if (File.Exists(filename))
            {
                // TODO: implement
                //if (!LoadMapState(filename, null))
                //{
                //    System.Diagnostics.Debug.Print("Failed to load map state: " + filename + Environment.NewLine + "Application is closing...");
                //    return false;
                //}
                
                ZoomToMaxExtents();
                ShowRedrawTime = false;
                ShowVersionNumber = false;
                return true;
            }

            System.Diagnostics.Debug.Print("World state file wasn't found: " + filename + Environment.NewLine + "Application is closing...");
            return false;
        }

        /// <summary>
        /// Draws selected bounds on map
        /// </summary>
        /// <param name="ext">Bounding box to search CS</param>
        public void DrawSelectedBounds(Envelope ext)
        {
            Layers.Remove(_handleBounds);

            var sf = new FeatureSet(GeometryType.Polygon);

            var shp = new Geometry(GeometryType.Polygon);

            InsertPart(shp, ext.MinX, ext.MaxX, ext.MinY, ext.MaxY);

            int index = 0;
            sf.Features.EditInsert(shp, ref index);

            _handleBounds = Layers.Add(sf);

             var style = sf.Style;
            style.Fill.Color = Color.Orange;
            style.Line.Color = Color.Orange;
            style.Line.Width = 3;
            style.Line.DashStyle = DashStyle.Dash;
            style.Fill.Transparency = 100;
        }

        /// <summary>
        /// Zooms map to the bounds of coordinate system
        /// </summary>
        public void ZoomToCoordinateSystem(ITerritory cs)
        {
            if (cs == null)
            {
                return;
            }

            var ext = new Envelope();
            
            double dx = cs.Right - cs.Left;
            double dy = cs.Top - cs.Bottom;

            if (dx >= 0)
            {
                ext.SetBounds(cs.Left - dx / 4.0,  cs.Right + dx / 4.0, cs.Bottom - dy / 4.0, cs.Top + dy / 4.0);
            }
            else
            {
                dx = 360.0;
                ext.SetBounds(-180.0 - dx / 4.0, 180.0 + dx / 4.0, cs.Bottom - dy / 4.0, cs.Top + dy / 4.0);
            }

            Extents = ext;
        }

        /// <summary>
        /// Zooms map to the bounds of coordinate system
        /// </summary>
        public void ZoomToCoordinateSystem()
        {
            var sf = Layers.GetFeatureSet(_handleCs);
            if (sf != null)
            {
                var sfExt = sf.Envelope;
                double dx = sfExt.MaxX - sfExt.MinX;
                double dy = sfExt.MaxY - sfExt.MinY;
                var ext = new Envelope();
                ext.SetBounds(sfExt.MinX - dx / 4.0,  sfExt.MaxM + dx / 4.0, sfExt.MinY - dy / 4.0, sfExt.MaxY + dy / 4.0);
                Extents = ext;
            }
        }

        /// <summary>
        /// Draws coordinate system at map
        /// </summary>
        /// <param name="cs">The territory (coordinate system or country) to draw</param>
        public void DrawCoordinateSystem(ITerritory cs)
        {
            Layers.Remove(_handleCs);

            var sf = new FeatureSet(GeometryType.Polygon);
            var shp = new Geometry(GeometryType.Polygon);

            double xMax = cs.Right;
            double xMin = cs.Left;
            double yMin = cs.Bottom;
            double yMax = cs.Top;

            if (xMax < xMin)
            {
                InsertPart(shp, -180, xMax, yMin, yMax);
                InsertPart(shp, xMin, 180, yMin, yMax);
            }
            else
            {
                InsertPart(shp, xMin, xMax, yMin, yMax);
            }

            
            int shpIndex = sf.Features.Count;
            sf.Features.EditInsert(shp, ref shpIndex);

            _handleCs = Layers.Add(sf);

            var style = sf.Style;
            style.Fill.Color = Color.LightBlue;
            style.Fill.Transparency = 120;
            style.Line.Color = Color.Blue;
            style.Line.DashStyle = DashStyle.Dash;
            style.Line.Width = 2;

            Redraw();
        }

        /// <summary>
        /// Inserts part to polygon based on given rectangle
        /// </summary>
        private void InsertPart(IGeometry shp, double xMin, double xMax, double yMin, double yMax)
        {
            int numParts = shp.Parts.Count;

            // TODO: implement
            //shp.InsertPart(shp.numPoints, ref numParts);

            //// to left
            //int index = shp.numPoints;
            //MapWinGIS.Point pnt = new MapWinGIS.Point();
            //pnt.x = xMin; pnt.y = yMax;
            //shp.InsertPoint(pnt, ref index); index++;

            //pnt = new MapWinGIS.Point();
            //pnt.x = xMax; pnt.y = yMax;
            //shp.InsertPoint(pnt, ref index); index++;

            //pnt = new MapWinGIS.Point();
            //pnt.x = xMax; pnt.y = yMin;
            //shp.InsertPoint(pnt, ref index); index++;

            //pnt = new MapWinGIS.Point();
            //pnt.x = xMin; pnt.y = yMin;
            //shp.InsertPoint(pnt, ref index); index++;

            //pnt = new MapWinGIS.Point();
            //pnt.x = xMin; pnt.y = yMax;
            //shp.InsertPoint(pnt, ref index); index++;

            //if (!shp.get_PartIsClockWise(0))
            //{
            //    bool val = shp.ReversePointsOrder(0);
            //    if (!val)
            //    {
            //        System.Diagnostics.Debug.Print("CCW");
            //    }
            //}

            //if (!shp.get_PartIsClockWise(0))
            //{
            //    System.Diagnostics.Debug.Print("CCW");
            //}
        }

        /// <summary>
        /// Removes layer with coordinate system
        /// </summary>
        public void ClearCoordinateSystem()
        {
            Layers.Remove(_handleCs);
        }

        /// <summary>
        /// Removes layer with bounds
        /// </summary>
        public void ClearBounds()
        {
            Layers.Remove(_handleBounds);
        }
    }
}