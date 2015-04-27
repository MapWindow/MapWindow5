using System;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.UI.Properties;
using Syncfusion.Windows.Forms;

namespace MW5.UI.Forms
{
#if STYLE2010
    public partial class MapWindowView : Office2010Form, IViewInternal
#else
    public partial class MapWindowView : MetroForm, IViewInternal
#endif
    {
        public event Action OkClicked;

        protected MapWindowView()
        {
            InitializeComponent();
            Icon = Resources.MapWindow;
#if STYLE2010
            ApplyAeroTheme = false;
            UseOffice2010SchemeBackColor = true;
#endif
        }

        protected void Invoke(Action action)
        {
            if (action != null)
            {
                action();
            }
        }

        public virtual void ShowView(IWin32Window parent = null)
        {
            if (!Visible)
            {
                AppViewFactory.Instance.ShowChildView(this, parent);
            }
        }

        public virtual ViewStyle Style
        {
            get
            {
                return new ViewStyle()
                {
                    Modal = true,
                    Sizable = false,
                };
            }
        }

        public virtual void BeforeClose()
        {
            // default implementation; can be overriden in child classes
        }

        public virtual void UpdateView()
        {
            // default implementation; can be overriden in child classes
        }

        protected void FireOkClicked()
        {
            Invoke(OkClicked);
        }
    }
}
