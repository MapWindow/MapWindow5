using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Shared;
using MW5.Shared.Log;

namespace MW5.Api.Concrete
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

        public void Dispose()
        {
            if (_shapefile != null)
            {
                _shapefile.Close();
                _shapefile = null;
            }
        }

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

        public ISpatialReference Projection
        {
            get { return new SpatialReference(_shapefile.GeoProjection); }
        }

        public bool IsEmpty
        {
            // TODO: add Shapefile.IsEmpty property to ocx
            get { return _shapefile.NumShapes == 0; }
        }

        /// <summary>
        /// Gets string with the information on datasource size, i.e. number of features, pixels, etc.
        /// </summary>
        public string SizeInfo 
        {
            get
            {
                return "[" + NumFeatures + " features]";
            } 
        }

        public LayerType LayerType
        {
            get { return LayerType.Shapefile; }
        }

        public string ToolTipText
        {
            get
            {
                string s = "Geometry type: " + GeometryType.EnumToString() + Environment.NewLine;
                s += "Feature count: " + Features.Count + Environment.NewLine;
                s += "Projection: " + Projection.ExportToProj4();
                return s;
            }
        }

        public bool IsVector
        {
            get { return true; }
        }

        public bool IsRaster
        {
            get { return false; }
        }

        public void Close()
        {
            Dispose();
        }

        public string OpenDialogFilter
        {
            get { return "ESRI Shapefiles (*.shp)|*.shp"; }
        }

        /// <summary>
        /// Opens ESRI shapefile datasource, reads it into memory breaks any connection with the source.
        /// </summary>
        public static FeatureSet OpenAsInMemoryDatasource(string filename)
        {
            var sf = new Shapefile();
            sf.CreateNew(string.Empty, ShpfileType.SHP_POLYGON);

            // reading projection
            string prjFilename = PathHelper.GetFullPathWithoutExtension(filename) + ".prj";
            if (File.Exists(prjFilename))
            {
                sf.GeoProjection.ReadFromFile(prjFilename);
            }

            return sf.LoadDataFrom(filename) ? new FeatureSet(sf) : null;
        }

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

        public DiagramsLayer Diagrams
        {
            get { return new DiagramsLayer(_shapefile.Charts); }
        }

        public AttributeFieldList Fields
        {
            get { return Table.Fields; }
        }

        public bool SelectShapes(Envelope boundBox, ref object result, double tolerance = 0, MapSelectionMode selectionMode = MapSelectionMode.Intersection)
        {
            throw new NotImplementedException();
        }

        public CollisionMode CollisionMode
        {
            get { return (CollisionMode)_shapefile.CollisionMode; }
            set { _shapefile.CollisionMode = (tkCollisionMode)value; }
        }

        public bool Snappable
        {
            get { return _shapefile.Snappable; }
            set { _shapefile.Snappable = value; }
        }

        public bool Volatile
        {
            get { return _shapefile.Volatile; }
            set { _shapefile.Volatile = value; }
        }

        public bool Identifiable
        {
            get { return _shapefile.Identifiable; }
            set { _shapefile.Identifiable = value; }
        }

        public string VisibilityExpression
        {
            get { return _shapefile.VisibilityExpression; }
            set { _shapefile.VisibilityExpression = value; }
        }

        public Color SelectionColor
        {
            get { return ColorHelper.UintToColor(_shapefile.SelectionColor); }
            set { _shapefile.SelectionColor = ColorHelper.ColorToUInt(value); }
        }

        public byte SelectionTransparency
        {
            get { return _shapefile.SelectionTransparency; }
            set { _shapefile.SelectionTransparency = value; }
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
        public FeatureCollection Features
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

        public string Serialize()
        {
            return _shapefile.Serialize(true);
        }

        public bool Deserialize(string state)
        {
            _shapefile.Deserialize(true, state);
            return true;
        }

        private IFeatureSet WrapShapefile(Shapefile sf)
        {
            if (sf != null)
            {
                return new FeatureSet(sf);
            }
            return null;
        }

        public IFeatureSet Intersection(bool selectedOnlyOfThis, IFeatureSet featureSet, bool selectedOnly, GeometryType geometryType)
        {
            var sf = featureSet.GetInternal();
            var shpType = GeometryHelper.GeometryType2ShpType(geometryType);
            var result = _shapefile.GetIntersection(selectedOnlyOfThis, sf, selectedOnly, shpType);
            return WrapShapefile(result);
        }

        public void InvertSelection()
        {
            _shapefile.InvertSelection();
        }

        public bool SelectByShapefile(IFeatureSet featureSet, SpatialRelation relation, bool selectedOnly, out int[] result)
        {
            var sf = featureSet.GetInternal();
            object indices = null;
            if (_shapefile.SelectByShapefile(sf, (tkSpatialRelation) relation, selectedOnly, ref indices))
            {
                result = indices as int[];
                return true;
            }

            result = null;
            return false;
        }

        public IFeatureSet Dissolve(int fieldIndex, bool selectedOnly)
        {
            var sf = _shapefile.Dissolve(fieldIndex, selectedOnly);
            return WrapShapefile(sf);
        }

        /// <summary>
        /// Creates featureset with the same projection and set of fields, but differnt geometry type.
        /// </summary>
        public IFeatureSet Clone(GeometryType newType, ZValueType zValue = ZValueType.None)
        {
            var sf = new Shapefile();
            var shapeType = GeometryHelper.GeometryType2ShpType(newType, zValue);
            sf.CreateNew(string.Empty, shapeType);

            sf.GeoProjection.CopyFrom(_shapefile.GeoProjection);

            var fs = new FeatureSet(sf);

            foreach (var fld in Fields)
            {
                fs.Fields.Add(fld.Clone());
            }

            return fs;
        }

        public IFeatureSet Clone()
        {
            var sf = _shapefile.Clone();
            return WrapShapefile(sf);
        }

        public bool Dump(string shapefileName)
        {
            return _shapefile.Dump(shapefileName);
        }

        public bool LoadDataFrom(string shapefileName)
        {
            return _shapefile.LoadDataFrom(shapefileName);
        }

        public bool Save()
        {
            return _shapefile.Save();
        }

        public bool SaveAs(string shapefileName)
        {
            return _shapefile.SaveAs(shapefileName);
        }

        public bool SaveAsEx(string filename, bool stopEditMode, bool unboundFile = false)
        {
            return _shapefile.SaveAsEx(filename, stopEditMode, unboundFile);
        }

        public bool PointOrMultiPoint
        {
            get { return GeometryType == GeometryType.Point || GeometryType == GeometryType.MultiPoint; }
        }

        public bool IsPolyline
        {
            get { return GeometryType == GeometryType.Polyline; }
        }

        public bool IsPolygon
        {
            get { return GeometryType == GeometryType.Polygon; }
        }

        public int NumSelected
        {
            get { return _shapefile.NumSelected; }
        }

        public void SelectAll()
        {
            _shapefile.SelectAll();
        }

        public void ClearSelection()
        {
            _shapefile.SelectNone();
        }

        public IFeatureSet BufferByDistance(double distance, int nSegments, bool selectedOnly, bool mergeResults)
        {
            var sf = _shapefile.BufferByDistance(distance, nSegments, selectedOnly, mergeResults);
            return WrapShapefile(sf);
        }

        public IFeatureSet Difference(bool selectedOnlySubject, IFeatureSet featureSetOverlay, bool selectedOnlyOverlay)
        {
            var sfOverlay = featureSetOverlay.GetInternal();
            var sf = _shapefile.Difference(selectedOnlySubject, sfOverlay, selectedOnlyOverlay);
            return WrapShapefile(sf);
        }

        public IFeatureSet Clip(bool selectedOnlySubject, IFeatureSet featureSetOverlay, bool selectedOnlyOverlay)
        {
            var sfOverlay = featureSetOverlay.GetInternal();
            var sf = _shapefile.Clip(selectedOnlySubject, sfOverlay, selectedOnlyOverlay);
            return WrapShapefile(sf);
        }

        public IFeatureSet SymmDifference(bool selectedOnlySubject, IFeatureSet featureSetOverlay, bool selectedOnlyOverlay)
        {
            var sfOverlay = featureSetOverlay.GetInternal();
            var sf = _shapefile.SymmDifference(selectedOnlySubject, sfOverlay, selectedOnlyOverlay);
            return WrapShapefile(sf);
        }

        public IFeatureSet Union(bool selectedOnlySubject, IFeatureSet featureSetOverlay, bool selectedOnlyOverlay)
        {
            var sfOverlay = featureSetOverlay.GetInternal();
            var sf = _shapefile.Union(selectedOnlySubject, sfOverlay, selectedOnlyOverlay);
            return WrapShapefile(sf);
        }

        public IFeatureSet ExplodeShapes(bool selectedOnly)
        {
            var sf = _shapefile.ExplodeShapes(selectedOnly);
            return WrapShapefile(sf);
        }

        public IFeatureSet AggregateShapes(bool selectedOnly, int fieldIndex = -1)
        {
            var sf = _shapefile.AggregateShapes(selectedOnly, fieldIndex);
            return WrapShapefile(sf);
        }

        public IFeatureSet ExportSelection()
        {
            var sf = _shapefile.ExportSelection();
            return WrapShapefile(sf);
        }

        public IFeatureSet Sort(int fieldIndex, bool @ascending)
        {
            var sf = _shapefile.Sort(fieldIndex, @ascending);
            return WrapShapefile(sf);
        }

        public IFeatureSet Merge(bool selectedOnlyThis, IFeatureSet featureSet, bool selectedOnly)
        {
            var sf = featureSet.GetInternal();
            var result = _shapefile.Merge(selectedOnlyThis, sf, selectedOnly);
            return WrapShapefile(result);
        }

        public IFeatureSet SimplifyLines(double tolerance, bool selectedOnly)
        {
            var result = _shapefile.SimplifyLines(tolerance, selectedOnly);
            return WrapShapefile(result);
        }

        public IFeatureSet Segmentize()
        {
            var result = _shapefile.Segmentize();
            return WrapShapefile(result);
        }

        public bool GetClosestVertex(double x, double y, double maxDistance, out int shapeIndex, out int pointIndex,
                   out double distance)
        {
            return _shapefile.GetClosestVertex(x, y, maxDistance, out shapeIndex, out pointIndex, out distance);
        }

        public IFeatureSet AggregateShapesWithStats(bool selectedOnly, int fieldIndex = -1, FieldOperationList operations = null)
        {
            var result = _shapefile.AggregateShapesWithStats(selectedOnly, fieldIndex, operations.GetInternal());
            return WrapShapefile(result);
        }

        public IFeatureSet DissolveWithStats(int fieldIndex, bool selectedOnly, FieldOperationList operations = null)
        {
            var result = _shapefile.DissolveWithStats(fieldIndex, selectedOnly, operations.GetInternal());
            return WrapShapefile(result);
        }

        public IFeatureSet Reproject(ISpatialReference newProjection, out int reprojectedCount)
        {
            int count = 0;
            
            var sf = _shapefile.Reproject(newProjection.GetInternal(), ref count);

            reprojectedCount = count;

            return WrapShapefile(sf);
        }

        public bool ReprojectInPlace(ISpatialReference newProjection, ref int reprojectedCount)
        {
            return _shapefile.ReprojectInPlace(newProjection.GetInternal(), ref reprojectedCount);
        }

        public bool GetRelatedShapes(int referenceIndex, SpatialRelation relation, ref int[] resultArray)
        {
            object results = null;
            if (_shapefile.GetRelatedShapes(referenceIndex, (tkSpatialRelation) relation, ref results))
            {
                resultArray = results as int[];
                return true;
            }
            return false;
        }

        public bool GetRelatedShapes(IGeometry referenceShape, SpatialRelation relation, ref int[] resultArray)
        {
            object results = null;
            if (_shapefile.GetRelatedShapes2(referenceShape.GetInternal(), (tkSpatialRelation)relation, ref results))
            {
                resultArray = results as int[];
                return true;
            }
            return false;
        }

        public GeometryValidationInfo LastInputValidation
        {
            get { return new GeometryValidationInfo(_shapefile.LastInputValidation); }
        }

        public GeometryValidationInfo LastOutputValidation
        {
            get { return new GeometryValidationInfo(_shapefile.LastOutputValidation); }
        }

        public bool HasInvalidShapes()
        {
            return _shapefile.HasInvalidShapes();
        }

        public void Deserialize(bool loadSelection, string state)
        {
            _shapefile.Deserialize(loadSelection, state);
        }

        public string Serialize(bool saveSelection)
        {
            return _shapefile.Serialize(saveSelection);
        }

        public string Serialize(bool saveSelection, bool serializeCategories)
        {
            return _shapefile.Serialize2(saveSelection, serializeCategories);
        }

        public IStopExecutionCallback StopExecution
        {
            set { _shapefile.StopExecution = new StopExecution(value); }
        }

        public int GenerateEmptyLabels(LabelPosition method, bool largestPartOnly = false)
        {
            return _shapefile.GenerateLabels(-1, (tkLabelPositioning) method, largestPartOnly);
        }

        public IList<int> SelectedIndices
        {
            get
            {
                int numSelected = _shapefile.NumSelected;
                if (numSelected == 0)
                {
                    return new List<int>();
                }

                var list = new List<int> {Capacity = numSelected};
                for (int i = 0; i < _shapefile.NumShapes; i++)
                {
                    if (_shapefile.ShapeSelected[i])
                    {
                        list.Add(i);
                    }
                }
                return list;
            }
        }

        public bool FeatureSelected(int shapeIndex)
        {
            return _shapefile.ShapeSelected[shapeIndex];
        }

        public void FeatureSelected(int shapeIndex, bool value)
        {
            _shapefile.ShapeSelected[shapeIndex] = value;
        }

        public int NumFeatures
        {
            get { return _shapefile.NumShapes; }
        }

        public int MinDrawingSize
        {
            get { return _shapefile.MinDrawingSize; }
            set { _shapefile.MinDrawingSize = value; }
        }

        public string SortField
        {
            get { return _shapefile.SortField; }
            set { _shapefile.SortField = value; }
        }

        public bool SortAscending
        {
            get { return _shapefile.SortAscending; }
            set { _shapefile.SortAscending = value; }
        }

        public void UpdateSortField()
        {
            _shapefile.UpdateSortField();
        }

        public bool StartAppendMode()
        {
            return _shapefile.StartAppendMode();
        }

        public void StopAppendMode()
        {
            _shapefile.StopAppendMode();
        }

        public bool AppendMode
        {
            get { return _shapefile.AppendMode; }
        }

        public IGlobalListener Callback
        {
            get { return NativeCallback.UnWrap(_shapefile.GlobalCallback); }
            set
            {
                var callback = NativeCallback.Wrap(value);
                _shapefile.GlobalCallback = callback;
                _shapefile.StopExecution = callback;
            }
        }

        public IFeatureSet FixUpShapes(bool selectedOnly)
        {
            Shapefile sf;
            bool result = _shapefile.FixUpShapes2(selectedOnly, out sf);
            return WrapShapefile(sf);
        }

        public bool Move(double xOffset, double yOffset)
        {
            return _shapefile.Move(xOffset, yOffset);
        }
    }
}