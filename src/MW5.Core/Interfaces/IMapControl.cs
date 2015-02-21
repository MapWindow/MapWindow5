using System;
using System.Windows.Forms;
using MapWinGIS;
using MW5.Core.Concrete;
using MW5.Core.Events;

namespace MW5.Core.Interfaces
{
    interface IMapControl: IComWrapper
    {
        LayerCollection Layers { get; }
        MapProjection Projection { get; set; }
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
        bool SetGeographicExtents(IEnvelope pVal);
        bool SetGeographicExtents2(double xLongitude, double yLatitude, double widthKilometers);

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

        IGeometryEditor GeometryEditor { get; }
        TileManager Tiles { get; }
        IdentifierSettings Identifier { get; }
        GeoMeasurer Measuring { get; }
        HistoryList UndoList { get; }
        DrawingLayers Drawing { get; }

        AutoToggle AnimationOnZooming { get; set; }
        int ExtentHistory { get; set; }
        double ExtentPad { get; set; }
        bool GrabProjectionFromData { get; set; }
        AutoToggle InertiaOnPanning { get; set; }
        bool IsLocked { get; }
        ResizeBehavior ResizeBehavior { get; set; }
        UnitsOfMeasure MapUnits { get; set; }
        IEnvelope MaxExtents { get; }
        double MouseWheelSpeed { get; set; }
        bool ReuseTileBuffer { get; set; }
        ZoomBehavior ZoomBehavior { get; set; }
        
        double ZoomPercent { get; set; }
        CoordinatesDisplay ShowCoordinates { get; set; }
        bool ShowRedrawTime { get; set; }
        bool ShowVersionNumber { get; set; }
        int UdCursorHandle { get; set; }
        bool UseSeamlessPan { get; set; }
        string VersionNumber { get; }
        IEnvelope GetKnownExtents(KnownExtents extents);

        void LockWindow(bool doLock);
        void Redraw(RedrawType redrawType = RedrawType.All);
        void Clear();
        void Undo();
        bool FindSnapPoint(double tolerance, double xScreen, double yScreen, ref double xFound, ref double yFound);

        double GeodesicArea(IGeometry polygon);
        double GeodesicDistance(double projX1, double projY1, double projX2, double projY2);
        double GeodesicLength(IGeometry polyline);

        IImageSource SnapShot(IEnvelope boundBox);
        IImageSource SnapShot(int clippingLayerHandle, double zoom, int width);
        IImageSource SnapShot(double left, double right, double top, double bottom, int width);

         event EventHandler<AfterShapeEditEventArgs> AfterShapeEdit;
         event EventHandler<BackgroundLoadingFinishedEventArgs> BackgroundLoadingFinished;
         event EventHandler<BackgroundLoadingStartedEventArgs> BackgroundLoadingStarted;
         event EventHandler<BeforeDeleteShapeEventArgs> BeforeDeleteShape;
         event EventHandler<BeforeShapeEditEventArgs> BeforeShapeEdit;
         event EventHandler<ChooseLayerEventArgs> ChooseLayer;
         event EventHandler<EventArgs> ExtentsChanged;
         event EventHandler<FileDroppedEventArgs> FileDropped;
         event EventHandler<GridOpenedEventArgs> GridOpened;
         event EventHandler<LayerAddedEventArgs> LayerAdded;
         event EventHandler<LayerProjectionIsEmptyEventArgs> LayerProjectionIsEmpty;
         event EventHandler<LayerRemovedEventArgs> LayerRemoved;
         event EventHandler<LayerReprojectedEventArgs> LayerReprojected;
         event EventHandler<MeasuringChangedEventArgs> MeasuringChanged;
         event EventHandler<MouseEventArgs> MouseDown;
         event EventHandler<MouseEventArgs> MouseMove;
         event EventHandler<MouseEventArgs> MouseUp;
         event EventHandler<EventArgs> ProjectionChanged;
         event EventHandler<ProjectionMismatchEventArgs> ProjectionMismatch;
         event EventHandler<SelectBoxFinalEventArgs> SelectBoxFinal;
         event EventHandler<SelectionChangedEventArgs> SelectionChanged;
         event EventHandler<ShapeHightlightedEventArgs> ShapeHighlighted;
         event EventHandler<ShapeIdentifiedEventArgs> ShapeIdentified;
         event EventHandler<ShapeValidationFailedEventArgs> ShapeValidationFailed;
         event EventHandler<TilesLoadedEventArgs> TilesLoaded;
         event EventHandler<EventArgs> UndoListChanged;
         event EventHandler<ValidateShapeEventArgs> ValidateShape;

         #region Not implemented

        //event _DMapEvents_SelectBoxDragEventHandler SelectBoxDrag;
        //event _DMapEvents_AfterDrawingEventHandler AfterDrawing;
        //event _DMapEvents_BeforeDrawingEventHandler BeforeDrawing;
        //event _DMapEvents_MapStateEventHandler MapState;
        //event _DMapEvents_OnDrawBackBufferEventHandler OnDrawBackBuffer;

        //bool SendMouseDown { get; set; }
        //bool SendMouseMove { get; set; }
        //bool SendMouseUp { get; set; }
        //bool SendOnDrawBackBuffer { get; set; }
        //bool SendSelectBoxDrag { get; set; }
        //bool SendSelectBoxFinal { get; set; }

        // bool SetImageLayerColorScheme(int layerHandle, object colorScheme);
        // void DrawBackBuffer(IntPtr hDC, int imageWidth, int imageHeight);
        // double PixelsPerDegree { get; }
        //bool DisableWaitCursor { get; set; }
        // object GetColorScheme(int layerHandle);
        // int HWnd();
        // void Resize(int width, int height);
        // bool SaveMapState(string filename, bool relativePaths, bool overwrite);
        // string SerializeMapState(bool relativePaths, string basePath);
        // void ShowToolTip(string text, int milliseconds);
        //  FileManager FileManager { get; }
        // bool DeserializeMapState(string state, bool loadLayers, string basePath);
        // bool LoadMapState(string filename, object callback);
        //bool TrapRMouseDown { get; set; }
        // bool SnapShotToDC(IntPtr hDC, Extents extents, int width);
        // bool SnapShotToDC2(IntPtr hDC, Extents extents, int width, float offsetX, float offsetY, float clipX, float clipY, float clipWidth, float clipHeight);
        //tkZoomBoxStyle ZoomBoxStyle { get; set; }
        #endregion
    }
}