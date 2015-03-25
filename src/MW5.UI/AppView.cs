using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins;
using MW5.Plugins.Interfaces;
using MW5.UI.Syncfusion;
using Syncfusion.Windows.Forms;

namespace MW5.UI
{
    public class AppView: IAppView
    {
        private readonly IMainView _parent;

        public AppView(IMainView parent)
        {
            if (parent == null) throw new ArgumentNullException("parent");
            _parent = parent;
        }

        public bool ShowDialog(Form form)
        {
            return ShowDialog(form, null);
        }

        public bool ShowDialog(Form form, IWin32Window parent)
        {
            if (form == null)
            {
                throw new ArgumentNullException("parent");
            }

            if (form is MetroForm)
            {
                // TODO: use injection
                var service = new SyncfusionStyleService(ControlStyleSettings.Instance);
                service.ApplyStyle(form as MetroForm);
            }

            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.StartPosition = FormStartPosition.CenterScreen; // TODO: make parameter
            form.ShowInTaskbar = false;

            if (parent == null)
            {
                parent = _parent as IWin32Window;
            }
            return form.ShowDialog(parent) == DialogResult.OK;
        }

        public void Update()
        {
            _parent.UpdateView();
        }

        public IWin32Window MainForm
        {
            get { return _parent as IWin32Window; }
        }
    }
}
