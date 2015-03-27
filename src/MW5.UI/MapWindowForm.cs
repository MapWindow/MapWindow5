using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.UI.Properties;
using Syncfusion.Windows.Forms;

namespace MW5.UI
{
    public class MapWindowForm: MetroForm
    {
        protected readonly IAppContext _context;

        public MapWindowForm()
        {
            Icon = Resources.MapWindow;
        }

        public MapWindowForm(IAppContext context)
        {
            Icon = Resources.MapWindow;
            _context = context;
        }
    }
}
