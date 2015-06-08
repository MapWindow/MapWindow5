using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.TableEditor.Properties;
using MW5.Plugins.TableEditor.Views;

namespace MW5.Plugins.TableEditor.Services
{
    public class DockPanelService
    {
        public const string TableEditorDockPanelKey = "TableEditorDockPanel";

        public DockPanelService(IAppContext context, TableEditorPresenter presenter, TableEditorPlugin plugin)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (presenter == null) throw new ArgumentNullException("presenter");
            if (plugin == null) throw new ArgumentNullException("plugin");

            var panels = context.DockPanels;

            panels.Lock();
            var panel = panels.Add(presenter.GetInternalObject(), TableEditorDockPanelKey, plugin.Identity);
            panel.Caption = "Table editor";
            panel.SetIcon(Resources.ico_table24);

            panel.DockTo(DockPanelState.Bottom, 300);
            panel.Visible = false;

            panels.Unlock();
        }
    }
}
