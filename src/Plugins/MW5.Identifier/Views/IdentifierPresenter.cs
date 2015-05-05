using System;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Events;
using MW5.Plugins.Identifier.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.Identifier.Views
{
    public class IdentifierPresenter: CommandDispatcher<IIdentifierView, IdentifierCommand>, IDockPanelPresenter
    {
        private readonly IAppContext _context;

        public IdentifierPresenter(IAppContext context, IIdentifierView view): base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            view.ModeChanged += OnIdentifierModeChanged;
        }

        private void OnIdentifierModeChanged()
        {
            switch (View.Mode)
            {
                case IdentifierPluginMode.CurrentLayer:
                    _context.Map.Identifier.Mode = IdentifierMode.SingleLayer;
                    break;
                case IdentifierPluginMode.TopDownStopOnFirst:
                    _context.Map.Identifier.Mode = IdentifierMode.AllLayerStopOnFirst;
                    break;
                case IdentifierPluginMode.AllLayers:
                case IdentifierPluginMode.LayerSelection:
                    _context.Map.Identifier.Mode = IdentifierMode.AllLayers;
                    break;
            }
        }

        public void ShapeIdentified(int layerHandle, int shapeIndex)
        {
            View.UpdateView();
        }

        public override void RunCommand(IdentifierCommand command)
        {
            switch (command)
            {
                case IdentifierCommand.Clear:
                    View.Clear();
                    break;
            }
        }

        public Control GetInternalObject()
        {
            return View as Control;
        }
    }
}
