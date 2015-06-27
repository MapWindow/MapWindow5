using System;
using System.Collections.Generic;
using System.Drawing;
using MW5.Api.Concrete;
using MW5.Api.Enums;

namespace MW5.Api.Interfaces
{
    public interface IFeatureSet: ILayerSource
    {
        FeatureCollection Features { get; }
        IGeometryStyle Style { get; }
        FeatureCategoryList Categories { get; }
        GeometryType GeometryType { get; }
        ZValueType ZValueType { get; }
        FeatureSourceType SourceType { get; }
        FeatureSetSpatialIndex SpatialIndex { get; }
        AttributeTable Table { get; }
        ILabelsLayer Labels { get; }
        DiagramsLayer Diagrams { get; }
        AttributeFieldList Fields { get; }

        IFeatureSet Clone();
        bool Dump(string shapefileName);
        bool LoadDataFrom(string shapefileName);
        bool Save();
        bool SaveAs(string shapefileName);
        bool PointOrMultiPoint { get; }
        bool IsPolyline { get; }
        bool IsPolygon { get; }

        int NumSelected { get; }
        void SelectAll();
        void ClearSelection();
        void InvertSelection();
        bool SelectByShapefile(IFeatureSet sf, SpatialRelation relation, bool selectedOnly, ref int[] result);
        bool SelectShapes(Envelope boundBox, ref object result, double tolerance = 0, MapSelectionMode selectionMode = MapSelectionMode.Intersection);

        CollisionMode CollisionMode { get; set; }
        bool Snappable { get; set; }
        bool Volatile { get; set; }
        bool Identifiable { get; set; }
        string VisibilityExpression { get; set; }
        Color SelectionColor { get; set; }
        byte SelectionTransparency { get; set; }

        bool EditingShapes { get; }
        bool EditingTable { get; }
        bool InteractiveEditing { get; set; }
        bool StartEditingShapes(bool startEditTable = true);
        bool StartEditingTable();
        bool StopEditingShapes(bool applyChanges = true, bool stopEditTable = true);
        bool StopEditingTable(bool applyChanges = true);

        IFeatureSet Difference(bool selectedOnlySubject, IFeatureSet sfOverlay, bool selectedOnlyOverlay);
        IFeatureSet Dissolve(int fieldIndex, bool selectedOnly);
        IFeatureSet AggregateShapes(bool selectedOnly, int fieldIndex = -1);
        IFeatureSet AggregateShapesWithStats(bool selectedOnly, int fieldIndex = -1, FieldOperationList statOperations = null);
        IFeatureSet BufferByDistance(double distance, int nSegments, bool selectedOnly, bool mergeResults);
        IFeatureSet Clip(bool selectedOnlySubject, IFeatureSet sfOverlay, bool selectedOnlyOverlay);
        IFeatureSet DissolveWithStats(int fieldIndex, bool selectedOnly, FieldOperationList statOperations = null);
        IFeatureSet ExplodeShapes(bool selectedOnly);
        IFeatureSet ExportSelection();
        IFeatureSet Segmentize();
        IFeatureSet SimplifyLines(double tolerance, bool selectedOnly);
        IFeatureSet Sort(int fieldIndex, bool ascending);
        IFeatureSet SymmDifference(bool selectedOnlySubject, IFeatureSet sfOverlay, bool selectedOnlyOverlay);
        IFeatureSet Union(bool selectedOnlySubject, IFeatureSet sfOverlay, bool selectedOnlyOverlay);
        IFeatureSet Merge(bool selectedOnlyThis, IFeatureSet sf, bool selectedOnly);
        IFeatureSet Intersection(bool selectedOnlyOfThis, IFeatureSet sf, bool selectedOnly, GeometryType geometryType);
        IFeatureSet Reproject(ISpatialReference newProjection, ref int reprojectedCount);
        bool FixUpShapes(out IFeatureSet retVal);
        bool Move(double xOffset, double yOffset);
        bool GetClosestVertex(double x, double y, double maxDistance, out int shapeIndex, out int pointIndex, out double distance);
        bool ReprojectInPlace(ISpatialReference newProjection, ref int reprojectedCount);
        bool GetRelatedShapes(int referenceIndex, SpatialRelation relation, ref int[] resultArray);
        bool GetRelatedShapes(IGeometry referenceShape, SpatialRelation relation, ref int[] resultArray);

        GeometryValidationInfo LastInputValidation { get; }
        GeometryValidationInfo LastOutputValidation { get; }
        bool HasInvalidShapes();
        void Deserialize(bool loadSelection, string state);
        string Serialize(bool saveSelection);
        string Serialize(bool saveSelection, bool serializeCategories);
        IStopExecutionCallback StopExecution { set; }
        
        // TODO: better to have it in labels class (make changes in ocx); 
        int GenerateEmptyLabels(LabelPosition method, bool largestPartOnly = false);

        IList<int> SelectedIndices { get; }

        bool FeatureSelected(int shapeIndex);
        void FeatureSelected(int shapeIndex, bool value);

        int NumFeatures { get; }

        int MinDrawingSize { get; set; }

        #region Not implemented

        //int get_numPoints(int ShapeIndex);
        //int GenerateLabels(int FieldIndex, tkLabelPositioning Method, bool LargestPartOnly = false);
        //tkGeometryEngine GeometryEngine { get; set; }
        //tkSelectionAppearance SelectionAppearance { get; set; }
        //ShapeDrawingOptions SelectionDrawingOptions { get; set; }
        // bool Resource(string newShpPath);

        #endregion
    }
}