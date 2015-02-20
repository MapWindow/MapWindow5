using System;
using System.IO;
using MapWinGIS;
using MW5.Core.Helpers;
using MW5.Core.Interfaces;

namespace MW5.Core.Concrete
{
    /// <summary>
    /// Represents feature bound to particular datasource or unbound, i.e. in-memory one.
    /// </summary>
    public class FeatureSet : IFeatureSet
    {
        private Shapefile _shapefile;

        /// <summary>
        /// Creates a new in-memory FeatureSet not bound to any datasource.
        /// </summary>
        public FeatureSet(GeometryType geomType, ZValueType zValue = ZValueType.None, bool addShapeIdField = true)
        {
            if (geomType == GeometryType.None)
            {
                throw new ArgumentException("Invalid geometry type.");
            }

            var shpType = GeometryHelper.GeometryType2ShpType(geomType, zValue);

            _shapefile = new Shapefile();

            if (!addShapeIdField)
            {
                _shapefile.CreateNew("", shpType);
            }
            else
            {
                _shapefile.CreateNewWithShapeID("", shpType);
            }
        }

        /// <summary>
        /// Creates a new instance of FeatureSet by opening disk-based shapefile.
        /// </summary>
        /// <param name="filename">Filename of shapefile to open (.shp extension).</param>
        public FeatureSet(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException("File not found: " + filename);
            }

            _shapefile = new Shapefile();
            if (!_shapefile.Open(filename))
            {
                throw new ApplicationException("Failed to open shapefile: " + _shapefile.ErrorMessage());
            }
        }

        /// <summary>
        /// Creates a new instance of FeatureSet by injecting already opened Shapefile.
        /// </summary>
        internal FeatureSet(Shapefile sf)
        {
            if (sf == null)
            {
                throw new NullReferenceException("Shapefile reference is null.");
            }
            _shapefile = sf;
        }

        /// <summary>
        /// Returns description of last error which occured within this FeatureSet. Check this property
        /// after some method returned false.
        /// </summary>
        public string LastError
        {
            get { return _shapefile.ErrorMessage(); }
        }

        public string Tag
        {
            get { return _shapefile.Key; }
            set { _shapefile.Key = value; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (_shapefile != null)
            {
                _shapefile.Close();
                _shapefile = null;
            }
        }

        #endregion

        #region ILayerSource Members

        public object InternalObject
        {
            get { return _shapefile; }
        }

        public IEnvelope Envelope
        {
            get { return new Envelope(_shapefile.Extents); }
        }

        public string Filename
        {
            get { return _shapefile.Filename; }
        }

        public ISpatialReference SpatialReference
        {
            get { return new SpatialReference(_shapefile.GeoProjection); }
        }

        public bool IsEmpty
        {
            // TODO: add Shapefile.IsEmpty property to ocx
            get { return _shapefile.NumShapes == 0; }
        }

        public void Close()
        {
            Dispose();
        }

        public string OpenDialogFilter
        {
            get { return "ESRI Shapefiles (*.shp)|*.shp"; }
        }

        #endregion

        /// <summary>
        /// Creates a new disk-based shapefile and open it as new feature set.
        /// </summary>
        /// <returns>Feature set for newly created shapefile.</returns>
        public static IFeatureSet CreateShapefile(string filename, GeometryType geomType,
            ZValueType zValue = ZValueType.None)
        {
            if (geomType == GeometryType.None)
            {
                throw new ArgumentException("Invalid geometry type.");
            }

            var shpType = GeometryHelper.GeometryType2ShpType(geomType, zValue);

            var sf = new Shapefile();
            if (!sf.CreateNew(filename, shpType))
            {
                throw new ApplicationException("Failed to create shapefile: " + sf.ErrorMessage());
            }

            var fs = new FeatureSet(sf);
            return fs;
        }

        /// <summary>
        /// Saves FeatureSet as a new disk based Shapefile.
        /// </summary>
        /// <param name="filename">New filename (.shp extension).</param>
        /// <returns>True on success.</returns>
        public bool SaveAsShapefile(string filename)
        {
            return _shapefile.SaveAs(filename);
        }

        #region IFeatureSet Members

        public GeometryType GeometryType
        {
            get { return GeometryHelper.ShapeType2GeometryType(_shapefile.ShapefileType); }
        }

        public ZValueType ZValueType
        {
            get { return GeometryHelper.ShapeType2ZValueType(_shapefile.ShapefileType); }
        }

        public FeatureSourceType SourceType
        {
            get { return (FeatureSourceType)_shapefile.SourceType; }
        }

        public FeatureSetSpatialIndex SpatialIndex
        {
            get { return new FeatureSetSpatialIndex(_shapefile); }
        }

        public AttributeTable Table
        {
            get { return new AttributeTable(_shapefile.Table); }
        }

        public ILabelsLayer Labels
        {
            get { return new LabelsLayer(_shapefile.Labels); }
        }

        public bool EditingShapes
        {
            get { return _shapefile.EditingShapes; }
        }

        public bool EditingTable
        {
            get { return _shapefile.EditingTable; }
        }

        public bool InteractiveEditing
        {
            get { return _shapefile.InteractiveEditing; }
            set { _shapefile.InteractiveEditing = value; }
        }

        public bool StartEditingShapes(bool startEditTable = true)
        {
            return _shapefile.StartEditingShapes(startEditTable);
        }

        public bool StartEditingTable()
        {
            return _shapefile.StartEditingTable();
        }

        public bool StopEditingShapes(bool applyChanges = true, bool stopEditTable = true)
        {
            return _shapefile.StopEditingShapes(applyChanges, stopEditTable);
        }

        public bool StopEditingTable(bool applyChanges = true)
        {
            return _shapefile.StopEditingTable(applyChanges);
        }

        /// <summary>
        /// Gets underlying feature collection. Collection may additionally implement IFeatureList interface.
        /// </summary>
        public IFeatureCollection Features
        {
            get { return new FeatureCollection(_shapefile); }
        }

        /// <summary>
        /// Gets default FeatureStyle used for rendering of the FeatureSet.
        /// </summary>
        public IGeometryStyle Style
        {
            get { return new GeometryStyle(_shapefile.DefaultDrawingOptions); }
        }

        /// <summary>
        /// Gets list of categories which define additional rendering styles.
        /// </summary>
        public FeatureCategoryList Categories
        {
            get { return new FeatureCategoryList(_shapefile.Categories); }
        }

        #endregion

        public string Serialize()
        {
            return _shapefile.Serialize(true);
        }

        public bool Deserialize(string state)
        {
            _shapefile.Deserialize(true, state);
            return true;
        }
    }
}