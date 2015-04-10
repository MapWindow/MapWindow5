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
using MW5.Plugins.Mvp;

namespace MW5.Plugins.Concrete
{
    public abstract class BasePlugin: IPlugin
    {
        private PluginIdentity _identity = null;
        private FileVersionInfo _fileVersionInfo;
        private bool _applicationPlugin = false;
        private bool _registered = false;

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

        public abstract void RegisterServices(IApplicationContainer container);

        internal void DoRegisterServices(IApplicationContainer container)
        {
            if (!_registered)
            {
                RegisterServices(container);
                _registered = true;
            }
        }

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
        internal EventHandler<ToolboxToolEventArgs> ToolboxToolClicked_;

        // public events
        public event EventHandler<ToolboxToolEventArgs> ToolboxToolClicked
        {
            add { ToolboxToolClicked_ += value; }
            remove { ToolboxToolClicked_ -= value; }
        }

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

        internal LegendEventHandler<LayerEventArgs> LayerStyleClicked_;
        internal LegendEventHandler<LayerEventArgs> LayerDoubleClicked_;
        internal LegendEventHandler<LayerEventArgs> LayerSelected_;
        internal LegendEventHandler<LayerEventArgs> LayerDiagramsClicked_;
        internal LegendEventHandler<LayerEventArgs> LayerLabelsClicked_;
        internal LegendEventHandler<LayerCategoryEventArgs> LayerCategoryClicked_;

        public event LegendEventHandler<LayerCategoryEventArgs> LayerCategoryClicked
        {
            add { LayerCategoryClicked_ += value; }
            remove { LayerCategoryClicked_ -= value; }
        }

        public event LegendEventHandler<LayerEventArgs> LayerLabelsClicked
        {
            add { LayerLabelsClicked_ += value; }
            remove { LayerLabelsClicked_ -= value; }
        }

        public event LegendEventHandler<LayerEventArgs> LayerDiagramsClicked
        {
            add { LayerDiagramsClicked_ += value; }
            remove { LayerDiagramsClicked_ -= value; }
        }

        public event LegendEventHandler<LayerEventArgs> LayerSelected
        {
            add { LayerSelected_ += value; }
            remove { LayerSelected_ -= value; }
        }

        public event LegendEventHandler<LayerEventArgs> LayerDoubleClicked
        {
            add { LayerDoubleClicked_ += value; }
            remove { LayerDoubleClicked_ -= value; }
        }

        public event LegendEventHandler<LayerEventArgs> LayerStyleClicked
        {
            add { LayerStyleClicked_ += value; }
            remove { LayerStyleClicked_ -= value; }
        }

        #endregion

        #region Map events

        // backing fields
        internal MapEventHandler<AfterShapeEditEventArgs> AfterShapeEdit_;
        internal MapEventHandler<BeforeShapeEditEventArgs> BeforeShapeEdit_;
        internal MapEventHandler<BeforeDeleteShapeEventArgs> BeforeDeleteShape_;
        internal MapEventHandler<ChooseLayerEventArgs> ChooseLayer_;
        internal MapEventHandler<EventArgs> ExtentsChanged_;
        internal MapEventHandler<EventArgs> HistoryChanged_;
        internal LegendEventHandler<LayerEventArgs> LayerAdded_;
        internal MapEventHandler<EventArgs> MapCursorChanged_;
        internal MapEventHandler<MouseEventArgs> MouseDown_;
        internal MapEventHandler<MouseEventArgs> MouseMove_;
        internal MapEventHandler<MouseEventArgs> MouseUp_;
        internal MapEventHandler<SelectionChangedEventArgs> SelectionChanged_;
        internal MapEventHandler<ShapeIdentifiedEventArgs> ShapeIdentified_;
        internal MapEventHandler<ShapeValidationFailedEventArgs> ShapeValidationFailed_;
        internal MapEventHandler<ValidateShapeEventArgs> ValidateShape_;

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
        public event LegendEventHandler<LayerEventArgs> LayerAdded
        {
            add { LayerAdded_ += value; }
            remove { LayerAdded_ -= value; }
        }

        public event MapEventHandler<LayerProjectionIsEmptyEventArgs> LayerProjectionIsEmpty;
        public event MapEventHandler<LayerRemovedEventArgs> LayerRemoved;
        public event MapEventHandler<LayerReprojectedEventArgs> LayerReprojected;
        public event MapEventHandler<MeasuringChangedEventArgs> MeasuringChanged;

        public event MapEventHandler<EventArgs> MapCursorChanged
        {
            add { MapCursorChanged_ += value; }
            remove { MapCursorChanged_ -= value; }
        }
        
        public event MapEventHandler<MouseEventArgs> MouseDown
        {
            add { MouseDown_ += value; }
            remove { MouseDown_ -= value; }
        }

        public event MapEventHandler<MouseEventArgs> MouseMove
        {
            add { MouseMove_ += value; }
            remove { MouseMove_ -= value; }
        }

        public event MapEventHandler<MouseEventArgs> MouseUp
        {
            add { MouseUp_ += value; }
            remove { MouseUp_ -= value; }
        }

        public event MapEventHandler<EventArgs> ProjectionChanged;
        public event MapEventHandler<ProjectionMismatchEventArgs> ProjectionMismatch;
        public event MapEventHandler<SelectBoxFinalEventArgs> SelectBoxFinal;
        public event MapEventHandler<SelectionChangedEventArgs> SelectionChanged
        {
            add { SelectionChanged_ += value; }
            remove { SelectionChanged_ -= value; }
        }

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
