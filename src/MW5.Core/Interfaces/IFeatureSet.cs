using System.Collections.Generic;
using MW5.Core.Concrete;

namespace MW5.Core.Interfaces
{
    public interface IFeatureSet: ILayerSource
    {
        IFeatureCollection Features { get; }
        IGeometryStyle Style { get; }
        FeatureCategoryList Categories { get; }
        GeometryType GeometryType { get; }
        ZValueType ZValueType { get; }
        FeatureSourceType SourceType { get; }
        FeatureSetSpatialIndex SpatialIndex { get; }
        AttributeTable Table { get; }
        ILabelsLayer Labels { get; }

        // Table Table { get; }
        //Charts Charts { get; set; }
        // Labels Labels { get; set; }
        //ShapeValidationInfo LastInputValidation { get; }
        //ShapeValidationInfo LastOutputValidation { get; }
        //int GenerateLabels(int FieldIndex, tkLabelPositioning Method, bool LargestPartOnly = false);

        //tkCollisionMode CollisionMode { get; set; }
        //ShapeDrawingOptions DefaultDrawingOptions { get; set; }
        
        //bool EditingShapes { get; }
        //bool EditingTable { get; }
        //bool InteractiveEditing { get; set; }
        //bool Snappable { get; set; }
        //bool Volatile { get; set; }
        //bool StartEditingShapes(bool StartEditTable = true, ICallback cBack = null);
        //bool StartEditingTable(ICallback cBack = null);
        //bool StopEditingShapes(bool ApplyChanges = true, bool StopEditTable = true, ICallback cBack = null);
        //bool StopEditingTable(bool ApplyChanges = true, ICallback cBack = null);
        //bool HasInvalidShapes();

        //bool Identifiable { get; set; }
        //tkGeometryEngine GeometryEngine { get; set; }


        //int MinDrawingSize { get; set; }
        //IStopExecution StopExecution { set; }
        //string VisibilityExpression { get; set; }
        
        //tkSelectionAppearance SelectionAppearance { get; set; }
        //uint SelectionColor { get; set; }
        //ShapeDrawingOptions SelectionDrawingOptions { get; set; }
        //byte SelectionTransparency { get; set; }
        
        //Shapefile Difference(bool SelectedOnlySubject, Shapefile sfOverlay, bool SelectedOnlyOverlay);
        //Shapefile Dissolve(int FieldIndex, bool SelectedOnly);
        //Shapefile AggregateShapes(bool SelectedOnly, int FieldIndex = -1);
        //Shapefile AggregateShapesWithStats(bool SelectedOnly, int FieldIndex = -1, FieldStatOperations statOperations = null);
        //Shapefile BufferByDistance(double Distance, int nSegments, bool SelectedOnly, bool MergeResults);
        //Shapefile Clip(bool SelectedOnlySubject, Shapefile sfOverlay, bool SelectedOnlyOverlay);
        //Shapefile DissolveWithStats(int FieldIndex, bool SelectedOnly, FieldStatOperations statOperations = null);
        //Shapefile ExplodeShapes(bool SelectedOnly);
        //bool FixUpShapes(out Shapefile retVal);
        //Shapefile ExportSelection();
        //Shapefile Reproject(GeoProjection newProjection, ref int reprojectedCount);
        //bool ReprojectInPlace(GeoProjection newProjection, ref int reprojectedCount);
        //Shapefile Segmentize();
        //Shapefile SimplifyLines(double Tolerance, bool SelectedOnly);
        //Shapefile Sort(int FieldIndex, bool Ascending);
        //Shapefile SymmDifference(bool SelectedOnlySubject, Shapefile sfOverlay, bool SelectedOnlyOverlay);
        //Shapefile Union(bool SelectedOnlySubject, Shapefile sfOverlay, bool SelectedOnlyOverlay);
        //Shapefile Merge(bool SelectedOnlyThis, Shapefile sf, bool SelectedOnly);
        //bool Move(double xOffset, double yOffset);
        //bool GetClosestVertex(double x, double y, double maxDistance, out int ShapeIndex, out int pointIndex, out double Distance);
        //Shapefile GetIntersection(bool SelectedOnlyOfThis, Shapefile sf, bool SelectedOnly, ShpfileType FileType, ICallback cBack = null);
        //bool GetRelatedShapes(int referenceIndex, tkSpatialRelation Relation, ref object resultArray);
        //bool GetRelatedShapes2(Shape referenceShape, tkSpatialRelation Relation, ref object resultArray);

        //Shapefile Clone();
        //bool Close();
        //bool Dump(string ShapefileName, ICallback cBack = null);
        //bool LoadDataFrom(string ShapefileName, ICallback cBack = null);
        //bool Resource(string newShpPath);
        //bool Save(ICallback cBack = null);
        //bool SaveAs(string ShapefileName, ICallback cBack = null);
        
        //int EditAddField(string Name, FieldType Type, int Precision, int Width);
        //int EditAddShape(Shape Shape);
        //bool EditCellValue(int FieldIndex, int ShapeIndex, object newVal);
        //bool EditClear();
        //bool EditDeleteField(int FieldIndex, ICallback cBack = null);
        //bool EditDeleteShape(int ShapeIndex);
        //bool EditInsertField(Field NewField, ref int FieldIndex, ICallback cBack = null);
        //bool EditInsertShape(Shape Shape, ref int ShapeIndex);
        //bool EditUpdateShape(int ShapeIndex, Shape shpNew);
        //object get_CellValue(int FieldIndex, int ShapeIndex);
        //Field get_Field(int FieldIndex);
        //Field get_FieldByName(string FieldName);
        //int get_FieldIndexByName(string FieldName);
        //int get_numPoints(int ShapeIndex);
        //Shape get_Shape(int ShapeIndex);
        // int NumSelected { get; }

        //bool SelectByShapefile(Shapefile sf, tkSpatialRelation Relation, bool SelectedOnly, ref object result, ICallback cBack = null);
        //void SelectAll();
        //void SelectNone();
        //bool SelectShapes(Extents BoundBox, double Tolerance = 0, SelectMode SelectMode = SelectMode.INTERSECTION, ref object result = Type.Missing);
        //void InvertSelection();
        
        //void Deserialize(bool LoadSelection, string newVal);
        //string Serialize(bool SaveSelection);
        //string Serialize2(bool SaveSelection, bool SerializeCategories);
    }

    public interface IFeatureCollection : IEnumerable<IFeature>
    {
    }

    public interface IFeatureList : IList<IFeature>
    {
    }
}