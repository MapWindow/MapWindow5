using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.TableEditor.Properties;

namespace MW5.Plugins.TableEditor.Menu
{
    public class MenuCommands : CommandProviderBase
    {
        public MenuCommands(TableEditorPlugin plugin)
            : base(plugin.Identity)
        {
        }

        public override IEnumerable<MenuCommand> GetCommands()
        {
            return new List<MenuCommand>()
            {
                new MenuCommand("Show attribute table", MenuKeys.ShowTable, Resources.table_editor),
            };
        }
    }
}
