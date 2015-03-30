using System;
using MapWinGIS;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class GridSource: ILayerSource
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

        public string Filename
        {
            get { return _grid.Filename; }
        }

        public GridColorRamp RasterColorTableColoringScheme
        {
            get
            {
                var scheme = _grid.RasterColorTableColoringScheme;
                return scheme != null ? new GridColorRamp(scheme) : null;
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
            return _grid.Save(filename, (GridFileType) format, null);
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

        public IImageSource OpenAsImage(GridColorRamp scheme, GridProxyMode proxyMode = GridProxyMode.Auto)
        {
            var img = _grid.OpenAsImage(scheme.GetInternal(), (tkGridProxyMode)proxyMode);
            if (img != null)
            {
                return BitmapSource.Wrap(img);
            }
            return null;
        }

        public GridColorRamp RetrieveColorScheme(GridSchemeRetrieval method)
        {
            var scheme = _grid.RetrieveColorScheme((tkGridSchemeRetrieval)method);
            if (scheme != null)
            {
                return new GridColorRamp(scheme);
            }
            return null;
        }

        public GridColorRamp GenerateColorScheme(GridSchemeGeneration method, PredefinedColors colors)
        {
            var scheme = _grid.GenerateColorScheme((tkGridSchemeGeneration) method, (PredefinedColorScheme) colors);
            if (scheme != null)
            {
                return new GridColorRamp(scheme);
            }
            return null;
        }

        public bool RemoveImageProxy()
        {
            return _grid.RemoveImageProxy();
        }

        public IImageSource CreateImageProxy(GridColorRamp colorScheme)
        {
            var img = _grid.CreateImageProxy(colorScheme.GetInternal());
            if (img != null)
            {
                return BitmapSource.Wrap(img);
            }
            return null;
        }

        public GridColorRamp RetrieveOrGenerateColorScheme(GridSchemeRetrieval retrievalMethod = GridSchemeRetrieval.Auto,
            GridSchemeGeneration generateMethod = GridSchemeGeneration.Gradient, PredefinedColors colors = PredefinedColors.FallLeaves)
        {
            var scheme = _grid.RetrieveOrGenerateColorScheme((tkGridSchemeRetrieval)retrievalMethod, 
            (tkGridSchemeGeneration)generateMethod, (PredefinedColorScheme)colors);
            if (scheme != null)
            {
                return new GridColorRamp(scheme);
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

        public bool IsEmpty
        {
            get { return _grid.SourceType == tkGridSourceType.gstUninitialized; }
        }

        public LayerType LayerType
        {
            get { return LayerType.Grid; }
        }

        public void Dispose()
        {
            _grid.Close();
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
