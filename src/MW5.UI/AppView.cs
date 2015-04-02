using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.UI.Syncfusion;
using Syncfusion.Windows.Forms;

namespace MW5.UI
{
    public class AppView: IAppView
    {
        private readonly IMainView _parent;
        private readonly IStyleService _styleService;

        public AppView(IMainView parent, IStyleService styleService)
        {
            if (parent == null) throw new ArgumentNullException("parent");
            if (styleService == null) throw new ArgumentNullException("styleService");
            _parent = parent;
            _styleService = styleService;
        }

        public bool ShowChildView(Form form, bool modal = true)
        {
            return ShowChildView(form, null, modal);
        }

        public bool ShowChildView(Form form, IWin32Window parent, bool modal = true)
        {
            if (form == null) throw new ArgumentNullException("parent");

            if (form is Office2010Form || form is MetroForm)
            {
                _styleService.ApplyStyle(form);
            }

            if (form is IViewInternal)
            {
                var view = form as IViewInternal;
                var style = view.Style;

                if (style != null)
                {
                    ApplyStyle(form, style);
                    modal = style.Modal;
                }
            }

            if (parent == null)
            {
                parent = _parent as IWin32Window;
            }
            if (modal)
            {
                return form.ShowDialog(parent) == DialogResult.OK;
            }
            
            form.Show(parent);
            return true;
        }

        private void ApplyStyle(Form form, ViewStyle style)
        {
            form.MaximizeBox = style.Sizable;
            form.MinimizeBox = style.Sizable;
            form.FormBorderStyle = style.Sizable ? FormBorderStyle.Sizable : FormBorderStyle.FixedSingle;

            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowInTaskbar = false;
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
