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
                new MenuCommand("Query builder", MenuKeys.QueryBuilder, Resources.img_sql),
                new MenuCommand("Categories", MenuKeys.Categories, Resources.layer_vector_thematic_add),
                new MenuCommand("Label mover", MenuKeys.LabelMover, Resources.label_mover)
            };
        }
    }
}
