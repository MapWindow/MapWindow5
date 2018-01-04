using System;
using System.IO;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Shared.Log;

namespace MW5.Api.Concrete
{
    /// <summary>
    /// Represents grid datasource, providing operations to read and write the data. 
    /// Isn't used for rendering (use IRasterSource instead).
    /// </summary>
    public class GridSource : IGridSource
    {
        private readonly Grid _grid;

        internal GridSource(Grid grid)
        {
            _grid = grid;
            if (grid == null)
            {
                throw new NullReferenceException("Internal reference is null");
            }
        }

        public GridSource(string filename, DataType dataType = DataType.UnknownDataType, bool inRam = true,
                          GridFormat format = GridFormat.UseExtension)
        {
            _grid = new Grid();
            if (!_grid.Open(filename, (GridDataType) dataType, inRam, (GridFileType) format))
            {
                throw new ApplicationException("Failed to open grid source: " + _grid.ErrorMsg[_grid.LastErrorCode]);
            }
        }

        public static GridSource CreateNew(string filename, GridSourceHeader header, DataType dataType,
            object initialValue, bool inRam = true, GridFormat format = GridFormat.UseExtension)
        {
            var grid = new Grid();
            if (!grid.CreateNew(filename, header.GetInternal(), (GridDataType) dataType, initialValue, inRam,
                (GridFileType) format))
            {
                grid.Close();
                return null;
            }
            return new GridSource(grid);
        }

        public object InternalObject
        {
            get { return _grid; }
        }

        public string LastError
        {
            get { return _grid.ErrorMsg[_grid.LastErrorCode]; }
        }

        public string Tag
        {
            get { return _grid.Key; }
            set { _grid.Key = value; }
        }

        public string Serialize()
        {
            throw new NotSupportedException();
        }

        public bool Deserialize(string state)
        {
            throw new NotSupportedException();
        }

        public DataType DataType
        {
            get { return (DataType)_grid.DataType; }
        }

        public string Name
        {
            get { return Path.GetFileNameWithoutExtension(Filename); }
        }
        
        public string Filename
        {
            get { return _grid.Filename; }
        }

        public RasterColorScheme RasterColorTableColoringScheme
        {
            get
            {
                var scheme = _grid.RasterColorTableColoringScheme;
                return scheme != null ? new RasterColorScheme(scheme) : null;
            }
        }

        public int NumBands
        {
            get { return _grid.NumBands; }
        }

        public int ActiveBandIndex
        {
            get { return _grid.ActiveBandIndex; }
        }

        public GridSourceType SourceType
        {
            get { return (GridSourceType)_grid.SourceType; }
        }

        public IEnvelope Extents
        {
            get { return new Envelope(_grid.Extents); }
        }

        public GridProxyMode PreferedDisplayMode
        {
            get { return (GridProxyMode)_grid.PreferedDisplayMode; }
            set { _grid.PreferedDisplayMode = (tkGridProxyMode)value; }
        }

        public bool HasValidImageProxy
        {
            get { return _grid.HasValidImageProxy; }
        }

        public bool Save(string filename, GridFormat format = GridFormat.UseExtension)
        {
            return _grid.Save(filename, (GridFileType) format);
        }

        public bool Clear(object clearValue)
        {
            return _grid.Clear(clearValue);
        }

        public void ProjToCell(double x, double y, out int column, out int row)
        {
            _grid.ProjToCell(x, y, out column, out row);
        }

        public void CellToProj(int column, int row, out double x, out double y)
        {
            _grid.CellToProj(column, row, out x, out y);
        }

        public bool SetInvalidValuesToNodata(double minThresholdValue, double maxThresholdValue)
        {
            return _grid.SetInvalidValuesToNodata(minThresholdValue, maxThresholdValue);
        }

        public bool OpenBand(int bandIndex)
        {
            return _grid.OpenBand(bandIndex);
        }

        public IImageSource OpenAsImage(RasterColorScheme scheme, GridProxyMode proxyMode = GridProxyMode.Auto)
        {
            var img = _grid.OpenAsImage(scheme.GetInternal(), (tkGridProxyMode)proxyMode);
            if (img != null)
            {
                return BitmapSource.Wrap(img);
            }
            return null;
        }

        public RasterColorScheme RetrieveColorScheme(GridSchemeRetrieval method)
        {
            var scheme = _grid.RetrieveColorScheme((tkGridSchemeRetrieval)method);
            if (scheme != null)
            {
                return new RasterColorScheme(scheme);
            }
            return null;
        }

        public RasterColorScheme GenerateColorScheme(GridSchemeGeneration method, PredefinedColors colors)
        {
            var scheme = _grid.GenerateColorScheme((tkGridSchemeGeneration) method, (PredefinedColorScheme) colors);
            if (scheme != null)
            {
                return new RasterColorScheme(scheme);
            }
            return null;
        }

        public bool RemoveImageProxy()
        {
            return _grid.RemoveImageProxy();
        }

        public IImageSource CreateImageProxy(RasterColorScheme colorScheme)
        {
            var img = _grid.CreateImageProxy(colorScheme.GetInternal());
            if (img != null)
            {
                return BitmapSource.Wrap(img);
            }
            return null;
        }

        public RasterColorScheme RetrieveOrGenerateColorScheme(GridSchemeRetrieval retrievalMethod = GridSchemeRetrieval.Auto,
            GridSchemeGeneration generateMethod = GridSchemeGeneration.Gradient, PredefinedColors colors = PredefinedColors.FallLeaves)
        {
            var scheme = _grid.RetrieveOrGenerateColorScheme((tkGridSchemeRetrieval)retrievalMethod, 
            (tkGridSchemeGeneration)generateMethod, (PredefinedColorScheme)colors);
            if (scheme != null)
            {
                return new RasterColorScheme(scheme);
            }
            return null;
        }

        public GridSourceHeader Header
        {
            get { return new GridSourceHeader(_grid.Header); }
        }

        public object get_Value(int column, int row)
        {
            return _grid.Value[column, row];
        }

        public void set_Value(int column, int row, object value)
        {
            _grid.Value[column, row] = value;
        }

        public bool InRam
        {
            get { return _grid.InRam; }
        }

        public object Maximum
        {
            get { return _grid.Maximum; }
        }

        public object Minimum
        {
            get { return _grid.Minimum; }
        }

        public void Close()
        {
            _grid.Close();
        }

        public string OpenDialogFilter
        {
            get { return _grid.CdlgFilter; }
        }

        public IEnvelope Envelope
        {
            get { return new Envelope(_grid.Extents); }
        }

        public ISpatialReference Projection
        {
            get { return new SpatialReference(_grid.Header.GeoProjection); }
        }

        /// <summary>
        /// Assigns projection to the layer if the layer doesn't have one.
        /// </summary>
        public void AssignProjection(ISpatialReference proj)
        {
            if (proj == null) throw new ArgumentNullException("proj");

            _grid.Header.GeoProjection = proj.Clone().GetInternal();
        }

        public bool IsEmpty
        {
            get { return _grid.SourceType == tkGridSourceType.gstUninitialized; }
        }

        /// <summary>
        /// Gets string with the information on datasource size, i.e. number of features, pixels, etc.
        /// </summary>
        public string SizeInfo
        {
            get
            {
                var header = _grid.Header;
                return string.Format("[{0}×{1} pixels]", header.NumberCols, header.NumberRows);
            }
        }

        public LayerType LayerType
        {
            get { return LayerType.Grid; }
        }

        public string ToolTipText
        {
            get
            {
                // TODO: return more
                var header = _grid.Header;
                string s = string.Format("Size: {0}×{1}", header.NumberCols, header.NumberRows);
                return s;
            }
        }

        public bool IsVector
        {
            get { return false; }
        }

        public bool IsRaster
        {
            get  { return true; }
        }

        public IGlobalListener Callback
        {
            get { return NativeCallback.UnWrap(_grid.GlobalCallback); }
            set { _grid.GlobalCallback = NativeCallback.Wrap(value); }
        }

        public void Dispose()
        {
            _grid.Close();
        }

        public IRasterBandCollection Bands
        {
            get { return new GridBandCollection(_grid); }
        }

        public RasterBand ActiveBand
        {
            get { return Bands[_grid.ActiveBandIndex]; }
        }

        #region Batch reading of values
        // TODO: test if it's working

        public bool GetRow(int row, ref float vals)
        {
            return _grid.GetRow(row, ref vals);
        }

        public bool PutRow(int row, ref float vals)
        {
            return _grid.PutRow(row, ref vals);
        }

        public bool GetValues(int startRow, int endRow, int startCol, int endCol, ref float vals)
        {
            return _grid.GetFloatWindow(startRow, endRow, startCol, endCol, ref vals);
        }

        public bool PutFloatWindow(int startRow, int endRow, int startCol, int endCol, ref float vals)
        {
            return _grid.PutFloatWindow(startRow, endRow, startCol, endCol, ref vals);
        }

        public bool GetValues(int startRow, int endRow, int startCol, int endCol, ref double vals)
        {
            return _grid.GetFloatWindow2(startRow, endRow, startCol, endCol, ref vals);
        }

        public bool PutValues(int startRow, int endRow, int startCol, int endCol, ref double vals)
        {
            return _grid.PutFloatWindow2(startRow, endRow, startCol, endCol, ref vals);
        }

        public bool PutRow(int row, ref double vals)
        {
            return _grid.PutRow2(row, ref vals);
        }

        public bool GetRow2(int row, ref double vals)
        {
            return _grid.GetRow2(row, ref vals);
        }

        #endregion

        #region Not implemented

        //public bool AssignNewProjection(string projection)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Resource(string newSrcPath)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion
    }
}
