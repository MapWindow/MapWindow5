using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MapWinGIS;
using MW5.Core.Concrete;
using MW5.Core.Events;
using MW5.Core.Helpers;
using MW5.Core.Interfaces;

namespace MW5.Core
{
    //MW5.CoreApi.
    //internal class ResFinder { }
    // https ://social.msdn.microsoft.com/Forums/en-US/4bd5a9cd-4730-41f6-a123-cb49b9ea420b/toolboxbitmap-problem?forum=Vsexpressvcs

    [ToolboxBitmap(typeof (MapControl), "Resources.Map.bmp")]
    public partial class MapControl : UserControl, IMapControl
    {
        private LayerCollection _layers;

        public MapControl()
        {
            InitializeComponent();
            AttachHandlers();
        }

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
        public event EventHandler<EventArgs> UndoListChanged;
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

        #region IMapControl Members

        public HistoryList UndoList
        {
            get { return new HistoryList(_axMap1.UndoList); }
        }

        public GeoMeasurer Measuring
        {
            get { return new GeoMeasurer(_axMap1.Measuring); }
        }

        public IdentifierSettings Identifier
        {
            get { return new IdentifierSettings(_axMap1.Identifier); }
        }

        [Browsable(false)]
        public LayerCollection Layers
        {
            get { return _layers = _layers ?? new LayerCollection(_axMap1); }
        }

        public MapProjection PROJECTION
        {
            get { return (MapProjection) _axMap1.Projection; }
            set { _axMap1.Projection = (tkMapProjection) value; }
        }

        public ZoomBarSettings ZoomBar
        {
            get { return new ZoomBarSettings(_axMap1); }
        }

        public ScalebarUnits ScalebarUnits
        {
            get { return (ScalebarUnits) _axMap1.ScalebarUnits; }
            set { _axMap1.ScalebarUnits = (tkScalebarUnits) value; }
        }

        public bool ScalebarVisible
        {
            get { return _axMap1.ScalebarVisible; }
            set { _axMap1.ScalebarVisible = value; }
        }

        public double CurrentScale
        {
            get { return _axMap1.CurrentScale; }
            set { _axMap1.CurrentScale = value; }
        }

        public int CurrentZoom
        {
            get { return _axMap1.CurrentZoom; }
            set { _axMap1.CurrentZoom = value; }
        }

        [Browsable(false)]
        public IEnvelope Extents
        {
            get { return new Envelope(_axMap1.Extents as Extents); }
            set { _axMap1.Extents = value.GetInternal(); }
        }

        [Browsable(false)]
        public IEnvelope GeographicExtents
        {
            get { return new Envelope(_axMap1.GeographicExtents); }
        }

        [Browsable(false)]
        public ISpatialReference GeoProjection
        {
            get { return new SpatialReference(_axMap1.GeoProjection); }
            set { _axMap1.GeoProjection = value.GetInternal(); }
        }

        public KnownExtents KnownExtents
        {
            get { return (KnownExtents) _axMap1.KnownExtents; }
            set { _axMap1.KnownExtents = (tkKnownExtents) value; }
        }

        public float Latitude
        {
            get { return _axMap1.Latitude; }
            set { _axMap1.Latitude = value; }
        }

        public float Longitude
        {
            get { return _axMap1.Longitude; }
            set { _axMap1.Longitude = value; }
        }

        [Browsable(false)]
        public SystemCursor SystemCursor
        {
            get { return (SystemCursor) _axMap1.MapCursor; }
            set { _axMap1.MapCursor = (tkCursor) value; }
        }

        public MapCursor MapCursor
        {
            get { return (MapCursor) _axMap1.CursorMode; }
            set { _axMap1.CursorMode = (tkCursorMode) value; }
        }

        public TileProvider TileProvider
        {
            get { return (TileProvider) _axMap1.TileProvider; }
            set { _axMap1.TileProvider = (tkTileProvider) value; }
        }

        public void ZoomIn()
        {
            _axMap1.ZoomIn(0.3);
        }

        public void ZoomOut()
        {
            _axMap1.ZoomOut(0.3);
        }

        public void ZoomIn(double percent)
        {
            _axMap1.ZoomIn(percent);
        }

        public void ZoomOut(double percent)
        {
            _axMap1.ZoomOut(percent);
        }

        public void ZoomToLayer(int layerHandle)
        {
            _axMap1.ZoomToLayer(layerHandle);
        }

        public void ZoomToMaxExtents()
        {
            _axMap1.ZoomToMaxExtents();
        }

        public void ZoomToMaxVisibleExtents()
        {
            _axMap1.ZoomToMaxVisibleExtents();
        }

        public int ZoomToPrev()
        {
            return _axMap1.ZoomToPrev();
        }

        public bool ZoomToSelected(int layerHandle)
        {
            return _axMap1.ZoomToSelected(layerHandle);
        }

        public void ZoomToShape(int layerHandle, int shape)
        {
            _axMap1.ZoomToShape(layerHandle, shape);
        }

        public bool ZoomToTileLevel(int zoom)
        {
            return _axMap1.ZoomToTileLevel(zoom);
        }

        public bool ZoomToWorld()
        {
            return _axMap1.ZoomToWorld();
        }

        public bool PixelToDegrees(double pixelX, double pixelY, out double degreesLngX, out double degreesLatY)
        {
            degreesLngX = degreesLatY = 0.0;
            return _axMap1.PixelToDegrees(pixelX, pixelY, ref degreesLngX, ref degreesLatY);
        }

        public void PixelToProj(double pixelX, double pixelY, out double projX, out double projY)
        {
            projX = projY = 0.0;
            _axMap1.PixelToProj(pixelX, pixelY, ref projX, ref projY);
        }

        public bool ProjToDegrees(double projX, double projY, out double degreesLngX, out double degreesLatY)
        {
            degreesLngX = degreesLatY = 0.0;
            return _axMap1.ProjToDegrees(projX, projY, ref degreesLngX, ref degreesLatY);
        }

        public void ProjToPixel(double projX, double projY, out double pixelX, out double pixelY)
        {
            pixelX = pixelY = 0.0;
            _axMap1.ProjToPixel(projX, projY, ref pixelX, ref pixelY);
        }

        public bool DegreesToPixel(double degreesLngX, double degreesLatY, out double pixelX, out double pixelY)
        {
            pixelX = pixelY = 0.0;
            return _axMap1.DegreesToPixel(degreesLngX, degreesLatY, ref pixelX, ref pixelY);
        }

        public bool DegreesToProj(double degreesLngX, double degreesLatY, out double projX, out double projY)
        {
            projX = projY = 0.0;
            return _axMap1.DegreesToProj(degreesLngX, degreesLatY, ref projX, ref projY);
        }

        public IGeometryEditor GeometryEditor
        {
            get { return new GeometryEditor(_axMap1.ShapeEditor); }
        }

        public TileManager Tiles
        {
            get { return new TileManager(_axMap1.Tiles); }
        }

        #endregion

    }
}

