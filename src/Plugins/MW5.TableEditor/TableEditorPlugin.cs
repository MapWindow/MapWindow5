using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.TableEditor.BO;
using MW5.Plugins.TableEditor.Forms;
using MW5.Plugins.TableEditor.Menu;


namespace MW5.Plugins.TableEditor
{
    [PluginExport()]
    public class TableEditorPlugin: BasePlugin
    {
        private IAppContext _context;
        private MenuService _menuService;
        private MapListener _mapListener;
        private TableEditorForm _form;

        public TableEditorForm Form
        {
            get { return _form; }
            set { _form = value; }
        }

        public override void Initialize(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            _menuService = _context.Container.GetSingleton<MenuService>();
            _mapListener = _context.Container.GetSingleton<MapListener>();
        }

        public override void Terminate()
        {
            
        }
    }
}
