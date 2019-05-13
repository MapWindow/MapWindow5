﻿// -------------------------------------------------------------------------------------------
// <copyright file="BasePlugin.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using MW5.Api.Events;
using MW5.Api.Legend;
using MW5.Api.Legend.Events;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Shared.Log;
using LayerCancelEventArgs = MW5.Plugins.Events.LayerCancelEventArgs;

namespace MW5.Plugins.Concrete
{
    public abstract class BasePlugin : IPlugin
    {
        private FileVersionInfo _fileVersionInfo;
        private PluginIdentity _identity;
        private bool _registered;

        public virtual IEnumerable<IConfigPage> ConfigPages
        {
            get { yield break; }
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

        public bool IsApplicationPlugin { get; private set; }

        private Assembly ReferenceAssembly
        {
            get { return GetType().Assembly; }
        }

        private FileVersionInfo ReferenceFile
        {
            get
            {
                return _fileVersionInfo ??
                       (_fileVersionInfo = FileVersionInfo.GetVersionInfo(ReferenceAssembly.Location));
            }
        }

        public virtual string Description
        {
            get { return ReferenceFile.Comments; }
        }

        public abstract void Initialize(IAppContext context);

        public virtual void Terminate()
        {
            // do nothing
        }

        protected abstract void RegisterServices(IApplicationContainer container);

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
            IsApplicationPlugin = value;
        }

#pragma warning disable 67

        #region Plugin events

        // backing fields
        internal EventHandler<LayerEventArgs> LayerFeatureCountChanged_;
        internal EventHandler<LogEventArgs> LogEntryAdded_;
        internal EventHandler<MenuItemEventArgs> ItemClicked_;
        internal EventHandler<CancelEventArgs> ProjectClosing_;
        internal EventHandler<EventArgs> ProjectClosed_;
        internal EventHandler<CancelEventArgs> ProjectSaving_;
        internal EventHandler<EventArgs> ProjectSaved_;
        internal EventHandler<LayerCancelEventArgs> BeforeLayerEditingChanged_;
        internal EventHandler<LayerEventArgs> LayerEditingChanged_;
        internal EventHandler<LayerCancelEventArgs> BeforeRemoveLayer_;
        internal EventHandler<EventArgs> ViewUpdating_;
        internal EventHandler<ToolboxToolEventArgs> ToolboxToolClicked_;
        internal EventHandler<UpdateJoinEventArgs> UpdateTableJoin_;
        internal EventHandler<PluginMessageEventArgs> MessageBroadcasted_;

        // public events
        public event EventHandler<UpdateJoinEventArgs> UpdateTableJoin
        {
            add { UpdateTableJoin_ += value; }
            remove { UpdateTableJoin_ -= value; }
        }

        public event EventHandler<LogEventArgs> LogEntryAdded
        {
            add { LogEntryAdded_ += value; }
            remove { LogEntryAdded_ -= value; }
        }

        public event EventHandler<ToolboxToolEventArgs> ToolboxToolClicked
        {
            add { ToolboxToolClicked_ += value; }
            remove { ToolboxToolClicked_ -= value; }
        }

        /// <summary>
        /// Occurs when Shape editor plug-in starts or stops editing of a layer.
        /// </summary>
        public event EventHandler<LayerEventArgs> LayerEditingChanged
        {
            add { LayerEditingChanged_ += value; }
            remove { LayerEditingChanged_ -= value; }
        }

        public event EventHandler<LayerCancelEventArgs> BeforeLayerEditingChanged
        {
            add { BeforeLayerEditingChanged_ += value; }
            remove { BeforeLayerEditingChanged_ -= value; }
        }

        public event EventHandler<LayerEventArgs> LayerFeatureCountChanged
        {
            add { LayerFeatureCountChanged_ += value; }
            remove { LayerFeatureCountChanged_ -= value; }
        }

        public event EventHandler<LayerCancelEventArgs> BeforeRemoveLayer
        {
            add { BeforeRemoveLayer_ += value; }
            remove { BeforeRemoveLayer_ -= value; }
        }

        public event EventHandler<EventArgs> ViewUpdating
        {
            add { ViewUpdating_ += value; }
            remove { ViewUpdating_ -= value; }
        }

        public event EventHandler<PluginMessageEventArgs> MessageBroadcasted
        {
            add { MessageBroadcasted_ += value; }
            remove { MessageBroadcasted_ -= value; }
        }

        public event EventHandler<MenuItemEventArgs> ItemClicked
        {
            add { ItemClicked_ += value; }
            remove { ItemClicked_ -= value; }
        }

        public event EventHandler<CancelEventArgs> ProjectSaving
        {
            add { ProjectSaving_ += value; }
            remove { ProjectSaving_ -= value; }
        }

        public event EventHandler<EventArgs> ProjectSaved
        {
            add { ProjectSaved_ += value; }
            remove { ProjectSaved_ -= value; }
        }

        public event EventHandler<CancelEventArgs> ProjectClosing
        {
            add { ProjectClosing_ += value; }
            remove { ProjectClosing_ -= value; }
        }

        public event EventHandler<EventArgs> ProjectClosed
        {
            add { ProjectClosed_ += value; }
            remove { ProjectClosed_ -= value; }
        }

        #endregion

        #region Legend events

        internal LegendEventHandler<LayerEventArgs> LayerStyleClicked_;
        internal LegendEventHandler<LayerEventArgs> LayerDoubleClicked_;
        internal LegendEventHandler<LayerEventArgs> LayerSelected_;
        internal LegendEventHandler<LayerEventArgs> LayerDiagramsClicked_;
        internal LegendEventHandler<LayerEventArgs> LayerLabelsClicked_;
        internal LegendEventHandler<LayerCategoryEventArgs> LayerCategoryClicked_;
        internal LegendEventHandler<LayerEventArgs> LayerAdded_;
        internal LegendEventHandler<LayerEventArgs> LayerRemoved_;
        internal LegendEventHandler<GroupEventArgs> GroupDoubleClick_;
        internal LegendEventHandler<GroupEventArgs> GroupAdded_;
        internal LegendEventHandler<GroupEventArgs> GroupRemoved_;

        public event LegendEventHandler<GroupEventArgs> GroupAdded
        {
            add { GroupAdded_ += value; }
            remove { GroupAdded_ -= value; }
        }

        public event LegendEventHandler<GroupEventArgs> GroupDoubleClick
        {
            add { GroupDoubleClick_ += value; }
            remove { GroupDoubleClick_ -= value; }
        }

        public event LegendEventHandler<GroupEventArgs> GroupRemoved
        {
            add { GroupRemoved_ += value; }
            remove { GroupRemoved_ -= value; }
        }

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

        public event LegendEventHandler<LayerEventArgs> LayerAdded
        {
            add { LayerAdded_ += value; }
            remove { LayerAdded_ -= value; }
        }

        public event LegendEventHandler<LayerEventArgs> LayerRemoved
        {
            add { LayerRemoved_ += value; }
            remove { LayerRemoved_ -= value; }
        }

        #endregion

        #region Map events

        // backing fields
        internal MapEventHandler<AfterShapeEditEventArgs> AfterShapeEdit_;
        internal MapEventHandler<DatasourceCancelEventArgs> BeforeLayerAdded_;
        internal MapEventHandler<BeforeShapeEditEventArgs> BeforeShapeEdit_;
        internal MapEventHandler<BeforeDeleteShapeEventArgs> BeforeDeleteShape_;
        internal MapEventHandler<ChooseLayerEventArgs> ChooseLayer_;
        internal MapEventHandler<EventArgs> ExtentsChanged_;
        internal MapEventHandler<EventArgs> HistoryChanged_;
        internal MapEventHandler<EventArgs> MapCursorChanged_;
        internal MapEventHandler<MouseEventArgs> MouseDown_;
        internal MapEventHandler<MouseEventArgs> MouseMove_;
        internal MapEventHandler<MouseEventArgs> MouseUp_;
        internal MapEventHandler<EventArgs> MouseDoubleClick_;
        internal MapEventHandler<SelectionChangedEventArgs> SelectionChanged_;
        internal MapEventHandler<ShapeIdentifiedEventArgs> ShapeIdentified_;
        internal MapEventHandler<ShapeValidationFailedEventArgs> ShapeValidationFailed_;
        internal MapEventHandler<ValidateShapeEventArgs> ValidateShape_;
        internal MapEventHandler<LockedEventArgs> MapLocked_;
        internal MapEventHandler<SelectBoxFinalEventArgs> SelectBoxFinal_;
        internal MapEventHandler<EventArgs> TmsProviderChanged_;

        // public events
        public event MapEventHandler<AfterShapeEditEventArgs> AfterShapeEdit
        {
            add { AfterShapeEdit_ += value; }
            remove { AfterShapeEdit_ -= value; }
        }

        public event MapEventHandler<BeforeDeleteShapeEventArgs> BeforeDeleteShape
        {
            add { BeforeDeleteShape_ += value; }
            remove { BeforeDeleteShape_ -= value; }
        }

        public event MapEventHandler<DatasourceCancelEventArgs> BeforeLayerAdded
        {
            add { BeforeLayerAdded_ += value; }
            remove { BeforeLayerAdded_ -= value; }
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

        public event MapEventHandler<EventArgs> MapCursorChanged
        {
            add { MapCursorChanged_ += value; }
            remove { MapCursorChanged_ -= value; }
        }

        public event MapEventHandler<LockedEventArgs> MapLocked
        {
            add { MapLocked_ += value; }
            remove { MapLocked_ -= value; }
        }

        public event MapEventHandler<EventArgs> MouseDoubleClick
        {
            add { MouseDoubleClick_ += value; }
            remove { MouseDoubleClick_ -= value; }
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

        /// <summary>
        /// Occurs when MapControl.MapCursor set to MapCursor.Selection, MapControl.CustomCursor is not null and
        /// user selects a rectangle on map.
        /// </summary>
        public event MapEventHandler<SelectBoxFinalEventArgs> SelectBoxFinal
        {
            add { SelectBoxFinal_ += value; }
            remove { SelectBoxFinal_ -= value; }
        }

        public event MapEventHandler<SelectionChangedEventArgs> SelectionChanged
        {
            add { SelectionChanged_ += value; }
            remove { SelectionChanged_ -= value; }
        }

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

        public event MapEventHandler<EventArgs> TmsProviderChanged
        {
            add { TmsProviderChanged_ += value; }
            remove { TmsProviderChanged_ -= value; }
        }

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

        #region Unimplemented map events (add to plugin interface if they are actually needed)

        //public event MapEventHandler<FileDroppedEventArgs> FileDropped;
        //public event MapEventHandler<GridOpenedEventArgs> GridOpened;
        //public event MapEventHandler<LayerProjectionIsEmptyEventArgs> LayerProjectionIsEmpty;
        //public event MapEventHandler<LayerReprojectedEventArgs> LayerReprojected;
        //public event MapEventHandler<MeasuringChangedEventArgs> MeasuringChanged;
        //public event MapEventHandler<EventArgs> ProjectionChanged;
        //public event MapEventHandler<ProjectionMismatchEventArgs> ProjectionMismatch;
        //public event MapEventHandler<SelectBoxFinalEventArgs> SelectBoxFinal;
        //public event MapEventHandler<ShapeHightlightedEventArgs> ShapeHighlighted;
        //public event MapEventHandler<TilesLoadedEventArgs> TilesLoaded;
        //public event MapEventHandler<BackgroundLoadingFinishedEventArgs> BackgroundLoadingFinished;
        //public event MapEventHandler<BackgroundLoadingStartedEventArgs> BackgroundLoadingStarted;

        #endregion

        #region DockPanel events

        internal EventHandler<DockPanelCancelEventArgs> DockPanelOpening_;
        internal EventHandler<DockPanelCancelEventArgs> DockPanelClosing_;
        internal EventHandler<DockPanelEventArgs> DockPanelOpened_;
        internal EventHandler<DockPanelEventArgs> DockPanelClosed_;

        public BasePlugin()
        {
            IsApplicationPlugin = false;
        }

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