using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Plugins.TableEditor.Editor;
using MW5.Plugins.TableEditor.Views;

namespace MW5.Plugins.TableEditor
{
    public class ProjectListener
    {
        private readonly IAppContext _context;
        private readonly TableEditorPresenter _presenter;

        public ProjectListener(IAppContext context, TableEditorPlugin plugin, TableEditorPresenter presenter)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");
            if (presenter == null) throw new ArgumentNullException("presenter");

            _context = context;
            _presenter = presenter;

            plugin.BeforeRemoveLayer += BeforeRemoveLayer;
        }

        private void BeforeRemoveLayer(object sender, LayerRemoveEventArgs e)
        {
            if (!_presenter.HasLayer(e.LayerHandle))
            {
                return;
            }

            if (!_presenter.CheckAndSaveChanges(true))
            {
                e.Cancel = true;
            }
        }
    }
}
