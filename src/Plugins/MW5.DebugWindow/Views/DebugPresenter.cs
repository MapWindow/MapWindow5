using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.DebugWindow.Views.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Shared;

namespace MW5.Plugins.DebugWindow.Views
{
    public class DebugPresenter: CommandDispatcher<IDebugView, DebugCommand>, IDockPanelPresenter
    {
        private readonly DebugDockView _debugDockView;

        public DebugPresenter(DebugDockView debugDockView)
            :base(debugDockView)
        {
            if (debugDockView == null) throw new ArgumentNullException("debugDockView");
            _debugDockView = debugDockView;
        }

        public Control GetInternalObject()
        {
            return _debugDockView;
        }

        public override void RunCommand(DebugCommand command)
        {
            switch (command)
            {
                case DebugCommand.ClearLog:
                    View.Clear();
                    break;
                case DebugCommand.ClearFilter:
                    MessageService.Current.Info("Not implemented");
                    break;
            }
        }
    }
}
