using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.UI.Properties;
using Syncfusion.Windows.Forms;

namespace MW5.UI
{
    public partial class MapWindowView : MetroForm
    {
        protected readonly IAppContext _context;

        protected MapWindowView()
        {
            InitializeComponent();
            Icon = Resources.MapWindow;
        }

        protected MapWindowView(IAppContext context)
        {
            InitializeComponent();

            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            _context = context;

            Icon = Resources.MapWindow;
        }

        protected void Invoke(Action action)
        {
            if (action != null)
            {
                action();
            }
        }

        public virtual void ShowView(bool dialog = true)
        {
            if (!Visible)
            {
                _context.View.ShowDialog(this, dialog);
            }
        }
    }
}
