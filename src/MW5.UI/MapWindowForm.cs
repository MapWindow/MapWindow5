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
#if STYLE2010
    public partial class MapWindowForm : Office2010Form
#else
    public partial class MapWindowForm : MetroForm
#endif
    {
        protected readonly IAppContext _context;

        public MapWindowForm()
        {
            Icon = Resources.MapWindow;
#if STYLE2010
            ApplyAeroTheme = false;
            UseOffice2010SchemeBackColor = true;
#endif
        }

        public MapWindowForm(IAppContext context)
            : this()
        {
            _context = context;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MapWindowForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "MapWindowForm";
            this.ResumeLayout(false);
        }
    }
}
