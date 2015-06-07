using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Plugins.Concrete;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Plugins.TableEditor.Editor;
using MW5.Plugins.TableEditor.Views;
using MW5.Shared;

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
            plugin.UpdateTableJoin += OnUpdateTableJoin;
        }

        private void OnUpdateTableJoin(object sender, Api.Events.UpdateJoinEventArgs e)
        {
            var table = sender as AttributeTable;
            if (table == null)
            {
                return;
            }

            string path = PathHelper.GetAbsolutePath(e.Filename, table.Filename);
            if (!File.Exists(path))
            {
                Logger.Current.Warn("Joined datasource wasn't found: " + path);
                return;
            }

            var model = new JoinViewModel(table);
            model.OpenDatasource(path);
            model.ReloadExternal(e.TableToFill, e.Options);
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
