using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Repository.Views;

namespace MW5.Plugins.Repository
{
    public class LegendListener
    {
        private readonly IAppContext _context;
        private readonly RepositoryPlugin _plugin;
        private readonly RepositoryPresenter _presenter;

        public LegendListener(IAppContext context, RepositoryPlugin plugin, RepositoryPresenter presenter)
        {
            if (plugin == null) throw new ArgumentNullException("plugin");
            if (presenter == null) throw new ArgumentNullException("presenter");

            _context = context;
            _plugin = plugin;
            _presenter = presenter;

            plugin.LayerAdded += (s, e) => UpdateRepositoryTree();
            plugin.LayerRemoved += (s, e) => UpdateRepositoryTree();
            plugin.ProjectClosed += (s, e) => UpdateRepositoryTree();
            plugin.MapLocked += (s, e) => UpdateRepositoryTree();

        }

        private void UpdateRepositoryTree()
        {
            if (!_context.Map.IsLocked)
            {
                var list = new HashSet<LayerIdentity>(_context.Map.GetFilenames().Distinct());
                _presenter.View.Tree.UpdateState(list);
            }
        }
    }
}
