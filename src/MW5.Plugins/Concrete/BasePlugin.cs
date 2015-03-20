using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Events;
using MW5.Api.Legend;
using MW5.Api.Legend.Events;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Concrete
{
    public abstract class BasePlugin: IPlugin
    {
        private PluginIdentity _identity = null;
        private FileVersionInfo _fileVersionInfo;
        private bool _applicationPlugin = false;

        public bool IsApplicationPlugin
        {
            get { return _applicationPlugin; }
        }

        public virtual string Description
        {
            get
            {
                return ReferenceFile.Comments;
            }
        }

        public PluginIdentity Identity
        {
            get
            {
                if (_identity == null)
                {
                    throw new ApplicationException("Can't access plugin identity before it was initialized");
                }
                return _identity;
            }
            internal set
            {
                if (_identity != null)
                {
                    throw new ApplicationException("Plugin identity may be set only once.");
                }
                _identity = value;
            }
        }

        private FileVersionInfo ReferenceFile
        {
            get { return _fileVersionInfo ?? (_fileVersionInfo = FileVersionInfo.GetVersionInfo(ReferenceAssembly.Location)); }
        }

        private Assembly ReferenceAssembly
        {
            get { return GetType().Assembly; }
        }

        public abstract void Initialize(IAppContext context);

        public abstract void Terminate();

        internal void SetApplicationPlugin(bool value)
        {
            _applicationPlugin = value;
        }

#pragma warning disable 67
        #region Plugin events

        // backing fields
        internal EventHandler<MenuItemEventArgs> ItemClicked_;
        internal EventHandler<CancelEventArgs> ProjectClosing_;
        internal EventHandler<LayerRemoveEventArgs> BeforeRemoveLayer_;
        internal EventHandler<EventArgs> ViewUpdating_;

        // public events
        public event EventHandler<LayerRemoveEventArgs> BeforeRemoveLayer
        {
            add { BeforeRemoveLayer_ += value; }
            remove { BeforeRemoveLayer_ -= value; }
        }

        public event EventHandler<EventArgs> ViewUpdating
        {
            add { ViewUpdating_ += value; }
            remove { ViewUpdating_ -= value; }
        }

        public event EventHandler<MenuItemEventArgs> ItemClicked
        {
            add { ItemClicked_ += value; }
            remove { ItemClicked_ -= value; }
        }

        public event EventHandler<CancelEventArgs> ProjectClosing
        {
            add { ProjectClosing_ += value; }
            remove { ProjectClosing_ -= value; }
        }

        #endregion

        #region Legend events

        internal LegendEventHandler<LayerEventArgs> LegendLayerStyleClicked_;
        internal LegendEventHandler<LayerEventArgs> LegendLayerDoubleClicked_;
        internal LegendEventHandler<LayerEventArgs> LayerSelected_;
        internal LegendEventHandler<LayerEventArgs> LegendLayerDiagramsClicked_;
        internal LegendEventHandler<LayerEventArgs> LegendLayerLabelsClicked_;
        internal LegendEventHandler<LayerCategoryEventArgs> LegendLayerCategoryClicked_;

        public event LegendEventHandler<LayerCategoryEventArgs> LegendLayerCategoryClicked
        {
            add { LegendLayerCategoryClicked_ += value; }
            remove { LegendLayerCategoryClicked_ -= value; }
        }

        public event LegendEventHandler<LayerEventArgs> LegendLayerLabelsClicked
        {
            add { LegendLayerLabelsClicked_ += value; }
            remove { LegendLayerLabelsClicked_ -= value; }
        }

        public event LegendEventHandler<LayerEventArgs> LegendLayerDiagramsClicked
        {
            add { LegendLayerDiagramsClicked_ += value; }
            remove { LegendLayerDiagramsClicked_ -= value; }
        }

        public event LegendEventHandler<LayerEventArgs> LayerSelected
        {
            add { LayerSelected_ += value; }
            remove { LayerSelected_ -= value; }
        }

        public event LegendEventHandler<LayerEventArgs> LegendLayerDoubleClicked
        {
            add { LegendLayerDoubleClicked_ += value; }
            remove { LegendLayerDoubleClicked_ -= value; }
        }

        public event LegendEventHandler<LayerEventArgs> LegendLayerStyleClicked
        {
            add { LegendLayerStyleClicked_ += value; }
            remove { LegendLayerStyleClicked_ -= value; }
        }

        #endregion

        #region Map events

        // backing fields
        internal MapEventHandler<AfterShapeEditEventArgs> AfterShapeEdit_;
        internal MapEventHandler<BeforeShapeEditEventArgs> BeforeShapeEdit_;
        internal MapEventHandler<BeforeDeleteShapeEventArgs> BeforeDeleteShape_;
        internal MapEventHandler<ChooseLayerEventArgs> ChooseLayer_;
        internal MapEventHandler<EventArgs> ExtentsChanged_;
        internal MapEventHandler<EventArgs> MapCursorChanged_;
        internal MapEventHandler<MouseEventArgs> MouseUp_;
        internal MapEventHandler<ShapeValidationFailedEventArgs> ShapeValidationFailed_;
        internal MapEventHandler<EventArgs> HistoryChanged_;
        internal MapEventHandler<ValidateShapeEventArgs> ValidateShape_;
        internal MapEventHandler<ShapeIdentifiedEventArgs> ShapeIdentified_;

        // public events
        public event MapEventHandler<AfterShapeEditEventArgs> AfterShapeEdit
        {
            add { AfterShapeEdit_ += value; }
            remove { AfterShapeEdit_ -= value; }
        }

        public event MapEventHandler<BackgroundLoadingFinishedEventArgs> BackgroundLoadingFinished;

        public event MapEventHandler<BackgroundLoadingStartedEventArgs> BackgroundLoadingStarted;

        public event MapEventHandler<BeforeDeleteShapeEventArgs> BeforeDeleteShape
        {
            add { BeforeDeleteShape_ += value; }
            remove { BeforeDeleteShape_ -= value; }
        }

        public event MapEventHandler<BeforeShapeEditEventArgs> BeforeShapeEdit
        {
            add { BeforeShapeEdit_ += value; }
            remove { BeforeShapeEdit_ -= value; }
        }

        public event MapEventHandler<ChooseLayerEventArgs> ChooseLayer
        {
            add { ChooseLayer_ += value; }
            remove { ChooseLayer_ -= value; }
        }

        public event MapEventHandler<EventArgs> ExtentsChanged
        {
            add { ExtentsChanged_ += value; }
            remove { ExtentsChanged_ -= value; }
        }

        public event MapEventHandler<FileDroppedEventArgs> FileDropped;
        public event MapEventHandler<GridOpenedEventArgs> GridOpened;
        public event MapEventHandler<LayerAddedEventArgs> LayerAdded;
        public event MapEventHandler<LayerProjectionIsEmptyEventArgs> LayerProjectionIsEmpty;
        public event MapEventHandler<LayerRemovedEventArgs> LayerRemoved;
        public event MapEventHandler<LayerReprojectedEventArgs> LayerReprojected;
        public event MapEventHandler<MeasuringChangedEventArgs> MeasuringChanged;

        public event MapEventHandler<EventArgs> MapCursorChanged
        {
            add { MapCursorChanged_ += value; }
            remove { MapCursorChanged_ -= value; }
        }
        
        public event MapEventHandler<MouseEventArgs> MouseDown;
        public event MapEventHandler<MouseEventArgs> MouseMove;

        public event MapEventHandler<MouseEventArgs> MouseUp
        {
            add { MouseUp_ += value; }
            remove { MouseUp_ -= value; }
        }

        public event MapEventHandler<EventArgs> ProjectionChanged;
        public event MapEventHandler<ProjectionMismatchEventArgs> ProjectionMismatch;
        public event MapEventHandler<SelectBoxFinalEventArgs> SelectBoxFinal;
        public event MapEventHandler<SelectionChangedEventArgs> SelectionChanged;
        public event MapEventHandler<ShapeHightlightedEventArgs> ShapeHighlighted;
        public event MapEventHandler<ShapeIdentifiedEventArgs> ShapeIdentified
        {
            add { ShapeIdentified_ += value; }
            remove { ShapeIdentified_ -= value; }
        }

        public event MapEventHandler<ShapeValidationFailedEventArgs> ShapeValidationFailed
        {
            add { ShapeValidationFailed_ += value; }
            remove { ShapeValidationFailed_ -= value; }
        }

        public event MapEventHandler<TilesLoadedEventArgs> TilesLoaded;

        public event MapEventHandler<EventArgs> HistoryChanged
        {
            add { HistoryChanged_ += value; }
            remove { HistoryChanged_ -= value; }
        }

        public event MapEventHandler<ValidateShapeEventArgs> ValidateShape
        {
            add { ValidateShape_ += value; }
            remove { ValidateShape_ -= value; }
        }
        #endregion

        #region DockPanel events

        internal EventHandler<DockPanelCancelEventArgs> DockPanelOpening_;
        internal EventHandler<DockPanelCancelEventArgs> DockPanelClosing_;
        internal EventHandler<DockPanelEventArgs> DockPanelOpened_;
        internal EventHandler<DockPanelEventArgs> DockPanelClosed_;

        public event EventHandler<DockPanelCancelEventArgs> DockPanelOpening
        {
            add { DockPanelOpening_ += value; }
            remove { DockPanelOpening_ -= value; }
        }

        public event EventHandler<DockPanelCancelEventArgs> DockPanelClosing
        {
            add { DockPanelClosing_ += value; }
            remove { DockPanelClosing_ -= value; }
        }

        public event EventHandler<DockPanelEventArgs> DockPanelClosed
        {
            add { DockPanelClosed_ += value; }
            remove { DockPanelClosed_ -= value; }
        }

        public event EventHandler<DockPanelEventArgs> DockPanelOpened
        {
            add { DockPanelOpened_ += value; }
            remove { DockPanelOpened_ -= value; }
        }

        #endregion

#pragma warning restore 67
    }
}
