using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;
using MW5.UI.Properties;
using Syncfusion.Windows.Forms;

namespace MW5.UI
{
    public class MapWindowForm: MetroForm
    {
        private readonly IAppContext _context;

        public MapWindowForm()
        {
            
        }

        public MapWindowForm(IAppContext context)
        {
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

        public void ShowView()
        {
            _context.View.ShowDialog(this);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MapWindowForm
            // 
            this.ClientSize = new System.Drawing.Size(288, 264);
            this.Name = "MapWindowForm";
            this.ResumeLayout(false);

        }
    }
}
