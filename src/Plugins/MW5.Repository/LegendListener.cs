using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
using MW5.Api.Legend.Abstract;
using MW5.Api.Legend.Events;
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

            plugin.LayerAdded += OnLayerAdded;
            plugin.LayerRemoved += (s, e) => UpdateRepositoryTree();
            plugin.ProjectClosed += (s, e) => UpdateRepositoryTree();
            plugin.MapLocked += (s, e) => UpdateRepositoryTree();
        }

        private void OnLayerAdded(IMuteLegend legend, LayerEventArgs e)
        {
            var layer = _context.Layers.ItemByHandle(e.LayerHandle);
            UpdateRepositoryTree(layer != null ? layer.Handle : -1);
        }

        private void UpdateRepositoryTree(int newLayerHandle = -1)
        {
            if (!_context.Map.IsLocked && !_context.Legend.Locked)
            {
                var list = new List<LayerIdentity>();
                foreach (var layer in _context.Layers)
                {
                    if (layer == null)
                        return;

                    var identity = layer.Identity;

                    if (newLayerHandle == layer.Handle)
                    {
                        identity.ForceRefresh = true;
                    }

                    list.Add(identity);
                }

                var hash = new HashSet<LayerIdentity>(list.Distinct());
                _presenter.View.Tree.UpdateState(hash);
            }
        }
    }
}
