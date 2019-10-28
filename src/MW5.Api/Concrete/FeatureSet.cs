using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
            _shapefile = sf ?? throw new NullReferenceException("Shapefile reference is null.");
        }

        /// <summary>
        /// Returns description of last error which occured within this FeatureSet. Check this property
        /// after some method returned false.
        /// </summary>
        public string LastError => _shapefile.ErrorMessage();

        public string Tag
        {
            get => _shapefile.Key;
            set => _shapefile.Key = value;
        }

        public void Dispose()
        {
            if (_shapefile == null) return;

            _shapefile.Close();
            _shapefile = null;
        }

        public object InternalObject => _shapefile;

        public IEnvelope Envelope => new Envelope(_shapefile.Extents);

        public string Name => Path.GetFileNameWithoutExtension(Filename);

        public string Filename => _shapefile.Filename;

        public ISpatialReference Projection => new SpatialReference(_shapefile.GeoProjection);

        /// <inheritdoc />
        /// <summary>
        /// Assigns projection to the layer if the layer doesn't have one.
        /// No need to clone it first.
        /// </summary>
        public void AssignProjection(ISpatialReference proj)
        {
            if (proj == null) throw new ArgumentNullException(nameof(proj));

            _shapefile.GeoProjection = proj.Clone().GetInternal();
        }

        /// <inheritdoc />
        /// <summary>
        /// Does the shapefile has any shapes?
        /// </summary>
        public bool IsEmpty => _shapefile.NumShapes == 0;

        /// <inheritdoc />
        /// <summary>
        /// Gets string with the information on datasource size, i.e. number of features, pixels, etc.
        /// </summary>
        public string SizeInfo => "[" + NumFeatures + " features]";

        public LayerType LayerType => LayerType.Shapefile;

        public string ToolTipText
        {
            get
            {
                var s = "Geometry type: " + GeometryType.EnumToString() + Environment.NewLine;
                s += "Feature count: " + Features.Count + Environment.NewLine;
                // s += "Projection: " + Projection.ExportToProj4();
                s += "Projection: " + Projection.Name;
                return s;
            }
        }

        public bool IsVector => true;

        public bool IsRaster => false;

        public void Close()
        {
            Dispose();
        }

        string IDatasource.OpenDialogFilter => OpenDialogFilter;

        public static string OpenDialogFilter => "ESRI Shapefiles (*.shp)|*.shp";

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
        // ReSharper disable once UnusedMember.Global
        public static IFeatureSet CreateShapefile(string filename, GeometryType geomType,
            ZValueType zValue = ZValueType.None)
        {
            if (geomType == GeometryType.None)
            {
                throw new ArgumentException("Invalid geometry type.");
            }

            var shpType = GeometryHelper.GeometryType2ShpType(geomType, zValue);

            var sf = new Shapefile();
            if (!sf.CreateNewWithShapeID(filename, shpType))
            {
                throw new ApplicationException("Failed to create shapefile: " + sf.ErrorMessage());
            }

            var fs = new FeatureSet(sf);
            return fs;
        }

        /// <summary>
        /// Delete all files associated with the shapefile
        /// </summary>
        /// <param name="filename">The full path of the shapefile</param>
        public static void DeleteShapefile(string filename)
        {
            if (string.IsNullOrEmpty(filename)) return;
            if (!File.Exists(filename)) return;
            var folder = Path.GetDirectoryName(filename);
            if (folder == null) return;

            var filenameBody = Path.GetFileNameWithoutExtension(filename);
            foreach (var f in Directory.EnumerateFiles(folder, filenameBody + ".*"))
            {
                File.Delete(f);
            }
        }

        public GeometryType GeometryType => GeometryHelper.ShapeType2GeometryType(_shapefile.ShapefileType);

        public bool Selectable { get => _shapefile.Selectable; set => _shapefile.Selectable = value; }

        public ZValueType ZValueType => GeometryHelper.ShapeType2ZValueType(_shapefile.ShapefileType);

        public FeatureSourceType SourceType => (FeatureSourceType)_shapefile.SourceType;

        public FeatureSetSpatialIndex SpatialIndex => new FeatureSetSpatialIndex(_shapefile);

        public AttributeTable Table => new AttributeTable(_shapefile.Table);

        public ILabelsLayer Labels => new LabelsLayer(_shapefile.Labels);

        public DiagramsLayer Diagrams => new DiagramsLayer(_shapefile.Charts);

        public AttributeFieldList Fields => Table.Fields;

        public IEnumerable<IFeature> SelectShapes(IEnvelope boundBox, double tolerance = 0, MapSelectionMode selectionMode = MapSelectionMode.Intersection)
        {
            if (boundBox == null) throw new ArgumentNullException(nameof(boundBox));
            
            object result = null;
            if (_shapefile.SelectShapes(boundBox.GetInternal(), tolerance, (SelectMode)selectionMode, ref result))
            {
                if (result is int[] indices)
                {
                    return indices.Select(index => new Feature(_shapefile, index));
                }
            }

            return new List<IFeature>();
        }

        public CollisionMode CollisionMode
        {
            get => (CollisionMode)_shapefile.CollisionMode;
            set => _shapefile.CollisionMode = (tkCollisionMode)value;
        }

        public bool Snappable
        {
            get => _shapefile.Snappable;
            set => _shapefile.Snappable = value;
        }

        public bool Volatile
        {
            get => _shapefile.Volatile;
            set => _shapefile.Volatile = value;
        }

        public bool Identifiable
        {
            get => _shapefile.Identifiable;
            set => _shapefile.Identifiable = value;
        }

        public string VisibilityExpression
        {
            get => _shapefile.VisibilityExpression;
            set => _shapefile.VisibilityExpression = value;
        }

        public Color SelectionColor
        {
            get => ColorHelper.UintToColor(_shapefile.SelectionColor);
            set => _shapefile.SelectionColor = ColorHelper.ColorToUInt(value);
        }

        public byte SelectionTransparency
        {
            get => _shapefile.SelectionTransparency;
            set => _shapefile.SelectionTransparency = value;
        }

        public bool EditingShapes => _shapefile.EditingShapes;

        public bool EditingTable => _shapefile.EditingTable;

        public bool InteractiveEditing
        {
            get => _shapefile.InteractiveEditing;
            set => _shapefile.InteractiveEditing = value;
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
        public FeatureCollection Features => new FeatureCollection(_shapefile);

        /// <summary>
        /// Gets default FeatureStyle used for rendering of the FeatureSet.
        /// </summary>
        public IGeometryStyle Style => new GeometryStyle(_shapefile.DefaultDrawingOptions);

        /// <summary>
        /// Gets list of categories which define additional rendering styles.
        /// </summary>
        public FeatureCategoryList Categories => new FeatureCategoryList(_shapefile.Categories);

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

        public IGeometry GetGeometry(int index)
        {
            var shp = _shapefile.Shape[index];
            return shp != null ? new Geometry(shp) : null;
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

        public bool PointOrMultiPoint => GeometryType == GeometryType.Point || GeometryType == GeometryType.MultiPoint;

        public bool IsPolyline => GeometryType == GeometryType.Polyline;

        public bool IsPolygon => GeometryType == GeometryType.Polygon;

        public int NumSelected => _shapefile.NumSelected;

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

        public IFeatureSet Sort(int fieldIndex, bool ascending)
        {
            var sf = _shapefile.Sort(fieldIndex, ascending);
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
            get
            {
                var val = _shapefile.LastInputValidation;
                return val != null ? new GeometryValidationInfo(_shapefile.LastInputValidation) : null;
            }
        }

        public GeometryValidationInfo LastOutputValidation
        {
            get
            {
                var val = _shapefile.LastOutputValidation;
                return val != null ? new GeometryValidationInfo(_shapefile.LastOutputValidation) : null;
            }
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
            set => _shapefile.StopExecution = new StopExecution(value);
        }

        public int GenerateEmptyLabels(LabelPosition method, bool largestPartOnly = false, int offsetXField = -1, int offsetYField = -1)
        {
            return _shapefile.GenerateLabels(-1, (tkLabelPositioning) method, largestPartOnly, offsetXField, offsetYField);
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

        public int NumFeatures => _shapefile.NumShapes;

        public int MinDrawingSize
        {
            get => _shapefile.MinDrawingSize;
            set => _shapefile.MinDrawingSize = value;
        }

        public string SortField
        {
            get => _shapefile.SortField;
            set => _shapefile.SortField = value;
        }

        public bool SortAscending
        {
            get => _shapefile.SortAscending;
            set => _shapefile.SortAscending = value;
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

        public bool AppendMode => _shapefile.AppendMode;

        public int GenerateLabels(int fieldIndex, LabelPosition position, bool largestPartOnly = false, int offsetXField = -1, int offsetYField = -1)
        {
            return _shapefile.GenerateLabels(fieldIndex, (tkLabelPositioning)position, largestPartOnly, offsetXField, offsetYField);
        }

        public IGlobalListener Callback
        {
            get => NativeCallback.UnWrap(_shapefile.GlobalCallback);
            set
            {
                var callback = NativeCallback.Wrap(value);
                _shapefile.GlobalCallback = callback;
                _shapefile.StopExecution = callback;
            }
        }

        public IFeatureSet FixUpShapes(bool selectedOnly)
        {
            _shapefile.FixUpShapes2(selectedOnly, out var sf);
            return WrapShapefile(sf);
        }

        public bool Move(double xOffset, double yOffset)
        {
            return _shapefile.Move(xOffset, yOffset);
        }
    }
}