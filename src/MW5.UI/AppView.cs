using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public DialogResult ShowDialog(Form form)
        {
            if (form == null)
            {
                throw new ArgumentNullException("form");
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
            form.StartPosition = FormStartPosition.CenterScreen;        // TODO: make parameter
            form.ShowInTaskbar = false;
            return form.ShowDialog(_parent as IWin32Window);
        }

        public void Update()
        {
            _parent.UpdateView();
        }
    }
}
