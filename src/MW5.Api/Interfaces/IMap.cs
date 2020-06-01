using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Events;

namespace MW5.Api.Interfaces
{
    public interface IMap : IMuteMap
    {
        event EventHandler<EventArgs> MapCursorChanged;
        event EventHandler<AfterShapeEditEventArgs> AfterShapeEdit;
        event EventHandler<BeforeVertexDigitizedEventArgs> BeforeVertexDigitized;
        event EventHandler<BackgroundLoadingFinishedEventArgs> BackgroundLoadingFinished;
        event EventHandler<BackgroundLoadingStartedEventArgs> BackgroundLoadingStarted;
        event EventHandler<BeforeDeleteShapeEventArgs> BeforeDeleteShape;
        event EventHandler<BeforeShapeEditEventArgs> BeforeShapeEdit;
        event EventHandler<ChooseLayerEventArgs> ChooseLayer;
        event EventHandler<EventArgs> ExtentsChanged;
        event EventHandler<FileDroppedEventArgs> FileDropped;
        event EventHandler<GridOpenedEventArgs> GridOpened;
        event EventHandler<LayerProjectionIsEmptyEventArgs> LayerProjectionIsEmpty;
        event EventHandler<LayerReprojectedEventArgs> LayerReprojected;
        event EventHandler<MeasuringChangedEventArgs> MeasuringChanged;
        event EventHandler<LockedEventArgs> MapLocked;
        event EventHandler<EventArgs> MouseDoubleClick;
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
        event EventHandler<EventArgs> HistoryChanged;
        event EventHandler<ValidateShapeEventArgs> ValidateShape;
        event EventHandler<EventArgs> TmsProviderChanged;
        event EventHandler<SnapPointRequestedEventArgs> SnapPointRequested;
        event EventHandler<SnapPointFoundEventArgs> SnapPointFound;
    }
}
