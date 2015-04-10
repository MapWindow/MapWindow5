using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MapWinGIS;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Events;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;

namespace MW5.Api.Map
{
    //MW5.CoreApi.
    //internal class ResFinder { }
    // https ://social.msdn.microsoft.com/Forums/en-US/4bd5a9cd-4730-41f6-a123-cb49b9ea420b/toolboxbitmap-problem?forum=Vsexpressvcs

    [ToolboxBitmap(typeof (MapControl), "Resources.Map.bmp")]
    public partial class MapControl : UserControl
    {
        public MapControl()
        {
            InitializeComponent();

            _map.SendSelectBoxFinal = true;
            _map.SendMouseDown = true;
            _map.SendMouseUp = true;
            _map.SendMouseMove = true;

            AllowDrop = true;

            DragEnter += MapControl_DragEnter;
            DragDrop += MapControl_DragDrop;

            AttachHandlers();
        }

        public event EventHandler<EventArgs> MapCursorChanged;
        public event EventHandler<AfterShapeEditEventArgs> AfterShapeEdit;
        public event EventHandler<BackgroundLoadingFinishedEventArgs> BackgroundLoadingFinished;
        public event EventHandler<BackgroundLoadingStartedEventArgs> BackgroundLoadingStarted;
        public event EventHandler<BeforeDeleteShapeEventArgs> BeforeDeleteShape;
        public event EventHandler<BeforeShapeEditEventArgs> BeforeShapeEdit;
        public event EventHandler<ChooseLayerEventArgs> ChooseLayer;
        public event EventHandler<EventArgs> ExtentsChanged;
        public event EventHandler<FileDroppedEventArgs> FileDropped;
        public event EventHandler<GridOpenedEventArgs> GridOpened;
        public event EventHandler<LayerAddedEventArgs> LayerAdded;
        public event EventHandler<LayerProjectionIsEmptyEventArgs> LayerProjectionIsEmpty;
        public event EventHandler<LayerRemovedEventArgs> LayerRemoved;
        public event EventHandler<LayerReprojectedEventArgs> LayerReprojected;
        public event EventHandler<MeasuringChangedEventArgs> MeasuringChanged;

        // TODO: check if these events events override default handlers of UserControl
        public new event EventHandler<MouseEventArgs> MouseDown;
        public new event EventHandler<MouseEventArgs> MouseMove;
        public new event EventHandler<MouseEventArgs> MouseUp;

        public event EventHandler<EventArgs> ProjectionChanged;
        public event EventHandler<ProjectionMismatchEventArgs> ProjectionMismatch;
        public event EventHandler<SelectBoxFinalEventArgs> SelectBoxFinal;
        public event EventHandler<SelectionChangedEventArgs> SelectionChanged;
        public event EventHandler<ShapeHightlightedEventArgs> ShapeHighlighted;
        public event EventHandler<ShapeIdentifiedEventArgs> ShapeIdentified;
        public event EventHandler<ShapeValidationFailedEventArgs> ShapeValidationFailed;
        public event EventHandler<TilesLoadedEventArgs> TilesLoaded;
        public event EventHandler<EventArgs> HistoryChanged;
        public event EventHandler<ValidateShapeEventArgs> ValidateShape;

        #region Hiding Properties from PropertyGrid

        [Browsable(false)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        [Browsable(false)]
        public override System.Drawing.Image BackgroundImage
        {
            get { return base.BackgroundImage; }
            set { base.BackgroundImage = value; }
        }

        [Browsable(false)]
        public override ImageLayout BackgroundImageLayout
        {
            get { return base.BackgroundImageLayout; }
            set { base.BackgroundImageLayout = value; }
        }

        [Browsable(false)]
        public override bool AutoScroll
        {
            get { return base.AutoScroll; }
            set { base.AutoScroll = value; }
        }

        [Browsable(false)]
        public override bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }

        [Browsable(false)]
        public override Cursor Cursor
        {
            get { return base.Cursor; }
            set { base.Cursor = value; }
        }

        [Browsable(false)]
        public override RightToLeft RightToLeft
        {
            get { return base.RightToLeft; }
            set { base.RightToLeft = value; }
        }

        #endregion

        #region IMuteMap Members

        [Browsable(false)]
        public IShapesList IdentifiedShapes
        {
            get { return new ShapesList(_map.IdentifiedShapes); }
        }

        [Browsable(false)]
        public HistoryList History
        {
            get { return new HistoryList(_map.UndoList); }
        }

        [Browsable(false)]
        public DrawingLayers Drawing
        {
            get { return new DrawingLayers(_map); }
        }

        public AutoToggle AnimationOnZooming
        {
            get { return (AutoToggle) _map.AnimationOnZooming; }
            set { _map.AnimationOnZooming = (tkCustomState) value; }
        }

        public int ExtentHistory
        {
            get { return _map.ExtentHistory; }
            set { _map.ExtentHistory = value; }
        }

        public double ExtentPad
        {
            get { return _map.ExtentPad; }
            set { _map.ExtentPad = value; }
        }

        public bool GrabProjectionFromData
        {
            get { return _map.GrabProjectionFromData; }
            set { _map.GrabProjectionFromData = value; }
        }

        public AutoToggle InertiaOnPanning
        {
            get { return (AutoToggle) _map.InertiaOnPanning; }
            set { _map.InertiaOnPanning = (tkCustomState) value; }
        }

        public bool IsLocked
        {
            get { return _map.IsLocked == tkLockMode.lmLock; }
        }

        public ResizeBehavior ResizeBehavior
        {
            get { return (ResizeBehavior) _map.MapResizeBehavior; }
            set { _map.MapResizeBehavior = (tkResizeBehavior) value; }
        }

        public UnitsOfMeasure MapUnits
        {
            get { return (UnitsOfMeasure) _map.MapUnits; }
            set { _map.MapUnits = (tkUnitsOfMeasure) value; }
        }

        [Browsable(false)]
        public IEnvelope MaxExtents
        {
            get { return new Envelope(_map.MaxExtents); }
        }

        public double MouseWheelSpeed
        {
            get { return _map.MouseWheelSpeed; }
            set { _map.MouseWheelSpeed = value; }
        }

        public bool ReuseTileBuffer
        {
            get { return _map.ReuseTileBuffer; }
            set { _map.ReuseTileBuffer = value; }
        }

        public ZoomBehavior ZoomBehavior
        {
            get { return (ZoomBehavior) _map.ZoomBehavior; }
            set { _map.ZoomBehavior = (tkZoomBehavior) value; }
        }

        public double ZoomPercent
        {
            get { return _map.ZoomPercent; }
            set { _map.ZoomPercent = value; }
        }

        public CoordinatesDisplay ShowCoordinates
        {
            get { return (CoordinatesDisplay) _map.ShowCoordinates; }
            set { _map.ShowCoordinates = (tkCoordinatesDisplay) value; }
        }

        public bool ShowRedrawTime
        {
            get { return _map.ShowRedrawTime; }
            set { _map.ShowRedrawTime = value; }
        }

        public bool ShowVersionNumber
        {
            get { return _map.ShowVersionNumber; }
            set { _map.ShowVersionNumber = value; }
        }

        public int UdCursorHandle
        {
            get { return _map.UDCursorHandle; }
            set { _map.UDCursorHandle = value; }
        }

        public bool UseSeamlessPan
        {
            get { return _map.UseSeamlessPan; }
            set { _map.UseSeamlessPan = value; }
        }

        public string VersionNumber
        {
            get { return _map.VersionNumber; }
        }

        public IEnvelope GetKnownExtents(KnownExtents extents)
        {
            return new Envelope(_map.GetKnownExtents((tkKnownExtents) extents));
        }

        public void Lock()
        {
            _map.LockWindow(tkLockMode.lmLock);
        }

        public bool Unlock()
        {
            _map.LockWindow(tkLockMode.lmUnlock);
            return _map.IsLocked == tkLockMode.lmLock;
        }

        public void Redraw(RedrawType redrawType = RedrawType.All)
        {
            _map.Redraw2((tkRedrawType) redrawType);
        }

        public void Clear()
        {
            _map.Clear();
        }

        public void Undo()
        {
            _map.Undo();
        }

        public bool FindSnapPoint(double tolerance, double xScreen, double yScreen, ref double xFound, ref double yFound)
        {
            return _map.FindSnapPoint(tolerance, xScreen, yScreen, ref xFound, ref yFound);
        }

        public double GeodesicArea(IGeometry polygon)
        {
            return _map.GeodesicArea(polygon.GetInternal());
        }

        public double GeodesicDistance(double projX1, double projY1, double projX2, double projY2)
        {
            return _map.GeodesicDistance(projX1, projY1, projX2, projY2);
        }

        public double GeodesicLength(IGeometry polyline)
        {
            return _map.GeodesicLength(polyline.GetInternal());
        }

        public IImageSource SnapShot(IEnvelope boundBox)
        {
            var img = _map.SnapShot(boundBox.GetInternal());
            return BitmapSource.Wrap(img);
        }

        public IImageSource SnapShot(IEnvelope boundBox, int width)
        {
            if (boundBox == null)
            {
                throw new ArgumentNullException("boundBox");
            }

            var img = _map.SnapShot3(boundBox.MinX, boundBox.MaxX, boundBox.MaxY, boundBox.MinY, width);
            return BitmapSource.Wrap(img);
        }

        public IImageSource SnapShot(int clippingLayerHandle, double zoom, int width)
        {
            var img = _map.SnapShot2(clippingLayerHandle, zoom, width);
            return BitmapSource.Wrap(img);
        }

        [Browsable(false)]
        public GeoMeasurer Measuring
        {
            get { return new GeoMeasurer(_map.Measuring); }
        }

        [Browsable(false)]
        public IdentifierSettings Identifier
        {
            get { return new IdentifierSettings(_map.Identifier); }
        }

        [Browsable(false)]
        public ILayerCollection<ILayer> Layers
        {
            get { return new LayerCollection(this); }
        }

        public MapProjection MapProjection
        {
            get { return (MapProjection) _map.Projection; }
            set { _map.Projection = (tkMapProjection) value; }
        }

        public ZoomBarSettings ZoomBar
        {
            get { return new ZoomBarSettings(_map); }
        }

        public ScalebarUnits ScalebarUnits
        {
            get { return (ScalebarUnits) _map.ScalebarUnits; }
            set { _map.ScalebarUnits = (tkScalebarUnits) value; }
        }

        public bool ScalebarVisible
        {
            get { return _map.ScalebarVisible; }
            set { _map.ScalebarVisible = value; }
        }

        public double CurrentScale
        {
            get { return _map.CurrentScale; }
            set { _map.CurrentScale = value; }
        }

        public int CurrentZoom
        {
            get { return _map.CurrentZoom; }
            set { _map.CurrentZoom = value; }
        }

        [Browsable(false)]
        public IEnvelope Extents
        {
            get { return new Envelope(_map.Extents as Extents); }
            set { _map.Extents = value.GetInternal(); }
        }

        [Browsable(false)]
        public IEnvelope GeographicExtents
        {
            get { return new Envelope(_map.GeographicExtents); }
        }

        public bool SetGeographicExtents(IEnvelope boundingBox)
        {
            return _map.SetGeographicExtents(boundingBox.GetInternal());
        }

        public bool SetGeographicExtents2(double xLongitude, double yLatitude, double widthKilometers)
        {
            return _map.SetGeographicExtents2(xLongitude, yLatitude, widthKilometers);
        }

        [Browsable(false)]
        public ISpatialReference Projection
        {
            get { return new SpatialReference(_map.GeoProjection); }
            set { _map.GeoProjection = value.GetInternal(); }
        }

        public KnownExtents KnownExtents
        {
            get { return (KnownExtents) _map.KnownExtents; }
            set { _map.KnownExtents = (tkKnownExtents) value; }
        }

        public float Latitude
        {
            get { return _map.Latitude; }
            set { _map.Latitude = value; }
        }

        public float Longitude
        {
            get { return _map.Longitude; }
            set { _map.Longitude = value; }
        }

        [Browsable(false)]
        public SystemCursor SystemCursor
        {
            get { return (SystemCursor) _map.MapCursor; }
            set { _map.MapCursor = (tkCursor) value; }
        }

        public MapCursor MapCursor
        {
            get { return (MapCursor) _map.CursorMode; }
            set
            {
                _map.CursorMode = (tkCursorMode) value;
                // TODO: perhaps fire it from within MapWinGIS                
                FireMapCursorChanged(this, new EventArgs());
            }
        }

        public TileProvider TileProvider
        {
            get { return (TileProvider) _map.TileProvider; }
            set { _map.TileProvider = (tkTileProvider) value; }
        }

        public void ZoomIn()
        {
            _map.ZoomIn(0.3);
        }

        public void ZoomOut()
        {
            _map.ZoomOut(0.3);
        }

        public void ZoomIn(double percent)
        {
            _map.ZoomIn(percent);
        }

        public void ZoomOut(double percent)
        {
            _map.ZoomOut(percent);
        }

        public void ZoomToLayer(int layerHandle)
        {
            _map.ZoomToLayer(layerHandle);
        }

        public void ZoomToMaxExtents()
        {
            _map.ZoomToMaxExtents();
        }

        public void ZoomToMaxVisibleExtents()
        {
            _map.ZoomToMaxVisibleExtents();
        }

        public int ZoomToPrev()
        {
            return _map.ZoomToPrev();
        }

        public bool ZoomToSelected(int layerHandle)
        {
            return _map.ZoomToSelected(layerHandle);
        }

        public void ZoomToShape(int layerHandle, int shape)
        {
            _map.ZoomToShape(layerHandle, shape);
        }

        public bool ZoomToTileLevel(int zoom)
        {
            return _map.ZoomToTileLevel(zoom);
        }

        public bool ZoomToWorld()
        {
            return _map.ZoomToWorld();
        }

        public bool PixelToDegrees(double pixelX, double pixelY, out double degreesLngX, out double degreesLatY)
        {
            degreesLngX = degreesLatY = 0.0;
            return _map.PixelToDegrees(pixelX, pixelY, ref degreesLngX, ref degreesLatY);
        }

        public void PixelToProj(double pixelX, double pixelY, out double projX, out double projY)
        {
            projX = projY = 0.0;
            _map.PixelToProj(pixelX, pixelY, ref projX, ref projY);
        }

        public bool ProjToDegrees(double projX, double projY, out double degreesLngX, out double degreesLatY)
        {
            degreesLngX = degreesLatY = 0.0;
            return _map.ProjToDegrees(projX, projY, ref degreesLngX, ref degreesLatY);
        }

        public void ProjToPixel(double projX, double projY, out double pixelX, out double pixelY)
        {
            pixelX = pixelY = 0.0;
            _map.ProjToPixel(projX, projY, ref pixelX, ref pixelY);
        }

        public bool DegreesToPixel(double degreesLngX, double degreesLatY, out double pixelX, out double pixelY)
        {
            pixelX = pixelY = 0.0;
            return _map.DegreesToPixel(degreesLngX, degreesLatY, ref pixelX, ref pixelY);
        }

        public bool DegreesToProj(double degreesLngX, double degreesLatY, out double projX, out double projY)
        {
            projX = projY = 0.0;
            return _map.DegreesToProj(degreesLngX, degreesLatY, ref projX, ref projY);
        }

        [Browsable(false)]
        public IGeometryEditor GeometryEditor
        {
            get { return new GeometryEditor(_map.ShapeEditor); }
        }

        [Browsable(false)]
        public TileManager Tiles
        {
            get { return new TileManager(_map.Tiles); }
        }

        #endregion

        [Browsable(false)]
        public object InternalObject
        {
            get { return _map; }
        }

        public string LastError
        {
            get { return _map.get_ErrorMsg(_map.LastErrorCode); }
        }

        // TODO: fix it
        public new string Tag
        {
            get { return ""; //_map.Tag.ToString(); 
            }
            set
            {
                //_map.Tag = value;
            }
        }

        public void SetDefaultExtents()
        {
            _map.Projection = tkMapProjection.PROJECTION_NONE;
            var ext = new Extents();
            ext.SetBounds(0.0, 0.0, 0.0, 100.0, 100.0, 0.0);
            _map.Extents = ext;
        }

        public new IntPtr Handle
        {
            get { return _map.Handle; }
        }

        public DecorationRectangle FocusRectangle
        {
            get { return new DecorationRectangle(_map.FocusRectangle); }
        }

        public bool LoadMapState(string filename)
        {
            return _map.LoadMapState(filename, null);
        }

        private void MapControl_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = (GetFilename(e) != null) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void MapControl_DragDrop(object sender, DragEventArgs e)
        {
            string filename = GetFilename(e);
            var handler = FileDropped;
            if (handler != null)
            {
                handler(sender, new FileDroppedEventArgs(filename));
            }
        }

        private string GetFilename(DragEventArgs e)
        {
            var filename = e.Data.GetData(DataFormats.StringFormat) as string;
            if (!string.IsNullOrWhiteSpace(filename) && File.Exists(filename))
            {
                return filename;
            }
            return null;
        }
    }
}

