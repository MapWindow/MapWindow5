using System;
using MW5.Core.Concrete;
using MW5.Core.Events;

namespace MW5.Core.Interfaces
{


    interface IMapControl
    {
        LayerCollection Layers { get; }
        MapProjection PROJECTION { get; set; }
        ZoomBarSettings ZoomBar { get;  }
        ScalebarUnits ScalebarUnits { get; set; }
        bool ScalebarVisible { get; set; }
        double CurrentScale { get; set; }
        int CurrentZoom { get; set; }
        ISpatialReference GeoProjection { get; set; }
        KnownExtents KnownExtents { get; set; }
        float Latitude { get; set; }
        float Longitude { get; set; }
        SystemCursor SystemCursor { get; set; }
        MapCursor MapCursor { get; set; }
        TileProvider TileProvider { get; set; }

        IEnvelope Extents { get; set; }
        IEnvelope GeographicExtents { get; }
        // bool SetGeographicExtents(Extents pVal);
        // bool SetGeographicExtents2(double xLongitude, double yLatitude, double widthKilometers);

        void ZoomIn();
        void ZoomOut();
        void ZoomIn(double percent);
        void ZoomOut(double percent);
        void ZoomToLayer(int layerHandle);
        void ZoomToMaxExtents();
        void ZoomToMaxVisibleExtents();
        int ZoomToPrev();
        bool ZoomToSelected(int layerHandle);
        void ZoomToShape(int layerHandle, int shape);
        bool ZoomToTileLevel(int zoom);
        bool ZoomToWorld();

        bool PixelToDegrees(double pixelX, double pixelY, out double degreesLngX, out double degreesLatY);
        void PixelToProj(double pixelX, double pixelY, out double projX, out double projY);
        bool ProjToDegrees(double projX, double projY, out double degreesLngX, out double degreesLatY);
        void ProjToPixel(double projX, double projY, out double pixelX, out double pixelY);
        bool DegreesToPixel(double degreesLngX, double degreesLatY, out double pixelX, out double pixelY);
        bool DegreesToProj(double degreesLngX, double degreesLatY, out double projX, out double projY);

        //ShapeEditor ShapeEditor { get; }
        //Tiles Tiles { get; }
        //  FileManager FileManager { get; }
        //  object GlobalCallback { get; set; }      // should set to global settings
        //  Identifier Identifier { get; }
        //  Measuring Measuring { get; }
        //UndoList UndoList { get; }

        // double PixelsPerDegree { get; }
         //AutoToggle AnimationOnZooming { get; set; }
         //bool DisableWaitCursor { get; set; }
         //int ExtentHistory { get; set; }
         //double ExtentPad { get; set; }
         //bool GrabProjectionFromData { get; set; }
         //AutoToggle InertiaOnPanning { get; set; }
         //bool IsLocked { get; set; }
         //string Tag { get; set; }
         //ResizeBehavior ResizeBehavior { get; set; }
         //UnitsOfMeasure MapUnits { get; set; }
         //IEnvelope MaxExtents { get; }
         //double MouseWheelSpeed { get; set; }
         //bool ReuseTileBuffer { get; set; }
         
         //bool SendMouseDown { get; set; }
         //bool SendMouseMove { get; set; }
         //bool SendMouseUp { get; set; }
         //bool SendOnDrawBackBuffer { get; set; }
         //bool SendSelectBoxDrag { get; set; }
         //bool SendSelectBoxFinal { get; set; }
         
         //tkCoordinatesDisplay ShowCoordinates { get; set; }
         //bool ShowRedrawTime { get; set; }
         //bool ShowVersionNumber { get; set; }
         
         //bool TrapRMouseDown { get; set; }
         //int UDCursorHandle { get; set; }
         
         //bool UseSeamlessPan { get; set; }
         //string VersionNumber { get; }
         
         //tkZoomBehavior ZoomBehavior { get; set; }
         //tkZoomBoxStyle ZoomBoxStyle { get; set; }
         //double ZoomPercent { get; set; }
         
         // void Clear();
         // void ClearDrawing(int drawHandle);
         // void ClearDrawingLabels(int drawHandle);
         // void ClearDrawings();
         
         // bool DeserializeLayer(int layerHandle, string newVal);
         // bool DeserializeMapState(string state, bool loadLayers, string basePath);
         // void DrawBackBuffer(IntPtr hDC, int imageWidth, int imageHeight);
         
         // bool FindSnapPoint(double tolerance, double xScreen, double yScreen, ref double xFound, ref double yFound);
         // double GeodesicArea(Shape polygon);
         // double GeodesicDistance(double projX1, double projY1, double projX2, double projY2);
         // double GeodesicLength(Shape polyline);
         
         // string get_ErrorMsg(int errorCode);
         
         // object GetColorScheme(int layerHandle);
         // Extents GetKnownExtents(tkKnownExtents extents);
         // int HWnd();
         // bool LoadLayerOptions(int layerHandle, string optionsName, ref string description);
         // bool LoadMapState(string filename, object callback);
         // void LoadTilesForSnapshot(Extents extents, int width, string key, tkTileProvider provider);
         // void LockWindow(tkLockMode lockMode);
         
         // void Redraw();
         // void Redraw2(tkRedrawType redrawType);

         // void Resize(int width, int height);
         // bool SaveMapState(string filename, bool relativePaths, bool overwrite);
         // string SerializeMapState(bool relativePaths, string basePath);
         
         // bool SetImageLayerColorScheme(int layerHandle, object colorScheme);
         // void ShowToolTip(string text, int milliseconds);
         // Image SnapShot(object boundBox);
         // Image SnapShot2(int clippingLayerNbr, double zoom, int pWidth);
         // Image SnapShot3(double left, double right, double top, double bottom, int width);
         // bool SnapShotToDC(IntPtr hDC, Extents extents, int width);
         // bool SnapShotToDC2(IntPtr hDC, Extents extents, int width, float offsetX, float offsetY, float clipX, float clipY, float clipWidth, float clipHeight);
         // int TilesAreInCache(Extents extents, int width, tkTileProvider provider);
         // void Undo();

        event EventHandler<ChooseLayerEventArgs> ChooseLayer;

        //event _DMapEvents_SelectBoxDragEventHandler SelectBoxDrag;
        //event _DMapEvents_AfterDrawingEventHandler AfterDrawing;
        //event _DMapEvents_BeforeDrawingEventHandler BeforeDrawing;
        //event _DMapEvents_MapStateEventHandler MapState;
        //event _DMapEvents_OnDrawBackBufferEventHandler OnDrawBackBuffer;
    }
}