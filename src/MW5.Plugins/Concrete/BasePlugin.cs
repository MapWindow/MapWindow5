using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Events;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Concrete
{
    public abstract class BasePlugin: IPlugin
    {
        private PluginIdentity _identity = null;

        public abstract string Description { get; }
        public abstract void Initialize(IAppContext context);
        public abstract void Terminate();

        internal PluginIdentity Identity
        {
            get
            {
                if (_identity == null)
                {
                    throw new ApplicationException("Can't access plugin identity before it was initialized");
                }
                return _identity;
            }
            set
            {
                if (_identity != null)
                {
                    throw new ApplicationException("Plugin identity may be set only once.");
                }
                _identity = value;
            }
        }

        #region Backing fields for events (shold be used to attach handlers externally)

        internal MapEventHandler<AfterShapeEditEventArgs> AfterShapeEdit_;
        internal MapEventHandler<BeforeShapeEditEventArgs> BeforeShapeEdit_;
        internal MapEventHandler<BeforeDeleteShapeEventArgs> BeforeDeleteShape_;
        internal MapEventHandler<EventArgs> ExtentsChanged_;
        internal MapEventHandler<MouseEventArgs> MouseUp_;
        internal MapEventHandler<ShapeValidationFailedEventArgs> ShapeValidationFailed_;
        internal MapEventHandler<EventArgs> UndoListChanged_;
        internal MapEventHandler<ValidateShapeEventArgs> ValidateShape_;

        #endregion

        #region Events

        public event MapEventHandler<AfterShapeEditEventArgs> AfterShapeEdit
        {
            add { AfterShapeEdit_ += value; }
            remove { AfterShapeEdit_ -= value; }
        }

        public event EventHandler<BackgroundLoadingFinishedEventArgs> BackgroundLoadingFinished;
        public event EventHandler<BackgroundLoadingStartedEventArgs> BackgroundLoadingStarted;

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

        public event EventHandler<ChooseLayerEventArgs> ChooseLayer;

        public event MapEventHandler<EventArgs> ExtentsChanged
        {
            add { ExtentsChanged_ += value; }
            remove { ExtentsChanged_ -= value; }
        }

        public event EventHandler<FileDroppedEventArgs> FileDropped;
        public event EventHandler<GridOpenedEventArgs> GridOpened;
        public event EventHandler<LayerAddedEventArgs> LayerAdded;
        public event EventHandler<LayerProjectionIsEmptyEventArgs> LayerProjectionIsEmpty;
        public event EventHandler<LayerRemovedEventArgs> LayerRemoved;
        public event EventHandler<LayerReprojectedEventArgs> LayerReprojected;
        public event EventHandler<MeasuringChangedEventArgs> MeasuringChanged;
        public event EventHandler<MouseEventArgs> MouseDown;
        public event EventHandler<MouseEventArgs> MouseMove;

        public event MapEventHandler<MouseEventArgs> MouseUp
        {
            add { MouseUp_ += value; }
            remove { MouseUp_ -= value; }
        }

        public event EventHandler<EventArgs> ProjectionChanged;
        public event EventHandler<ProjectionMismatchEventArgs> ProjectionMismatch;
        public event EventHandler<SelectBoxFinalEventArgs> SelectBoxFinal;
        public event EventHandler<SelectionChangedEventArgs> SelectionChanged;
        public event EventHandler<ShapeHightlightedEventArgs> ShapeHighlighted;
        public event EventHandler<ShapeIdentifiedEventArgs> ShapeIdentified;

        public event MapEventHandler<ShapeValidationFailedEventArgs> ShapeValidationFailed
        {
            add { ShapeValidationFailed_ += value; }
            remove { ShapeValidationFailed_ -= value; }
        }

        public event EventHandler<TilesLoadedEventArgs> TilesLoaded;

        public event MapEventHandler<EventArgs> UndoListChanged
        {
            add { UndoListChanged_ += value; }
            remove { UndoListChanged_ -= value; }
        }

        public event MapEventHandler<ValidateShapeEventArgs> ValidateShape
        {
            add { ValidateShape_ += value; }
            remove { ValidateShape_ -= value; }
        }
        #endregion
    }
}
