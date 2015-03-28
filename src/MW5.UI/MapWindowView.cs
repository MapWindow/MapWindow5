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
    public partial class MapWindowView : MetroForm, IViewInternal
    {
        private readonly IAppView _appView;
        public event Action OkClicked;

        protected MapWindowView()
        {
            InitializeComponent();
            Icon = Resources.MapWindow;
        }

        protected MapWindowView(IAppView appView)
        {
            if (appView == null) throw new ArgumentNullException("appView");
            _appView = appView;

            InitializeComponent();

            Icon = Resources.MapWindow;
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
                _appView.ShowChildView(this, parent);
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

        protected void FireOkClicked()
        {
            Invoke(OkClicked);
        }
    }
}
