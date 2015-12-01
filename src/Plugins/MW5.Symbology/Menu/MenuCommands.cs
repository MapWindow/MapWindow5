using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Symbology.Properties;

namespace MW5.Plugins.Symbology.Menu
{
    public class MenuCommands : CommandProviderBase
    {
        public MenuCommands(PluginIdentity identity) : base(identity)
        {
        }

        public override IEnumerable<MenuCommand> GetCommands()
        {
            return new List<MenuCommand>()
            {
                new MenuCommand("Query Builder", MenuKeys.QueryBuilder, Resources.img_sql),
                new MenuCommand("Categories", MenuKeys.Categories, Resources.layer_vector_thematic_add),
                new MenuCommand("Label Mover", MenuKeys.LabelMover, Resources.label_mover),
                new MenuCommand("Labels", MenuKeys.Labels, Resources.img_label24),
                new MenuCommand("Charts", MenuKeys.Charts, Resources.img_chart24),
                new MenuCommand("Layer Properties", MenuKeys.LayerProperties, Resources.img_properties24),
            };
        }
    }
}
