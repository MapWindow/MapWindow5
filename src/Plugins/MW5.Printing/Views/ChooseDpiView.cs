using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Printing.Views.Abstract;
using MW5.UI.Forms;

namespace MW5.Plugins.Printing.Views
{
    internal partial class ChooseDpiView : ChooseDpiViewBase, IChooseDpiView
    {
        private static string _lastDpi = string.Empty;

        public ChooseDpiView()
        {
            InitializeComponent();

            cboDpi.TextChanged += OnTextChanged;

            cboDpi.KeyDown += OnDpiKeyDown;
        }

        private void OnDpiKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FireOkClicked();
            }
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            int val;

            if (Int32.TryParse(cboDpi.Text, out val))
            {
                Model.Dpi = val;

                var size = Model.Size;
                lblSize.Text = string.Format("Size: {0} × {1} pixels", size.Width, size.Height);
            }
            else
            {
                Model.Dpi = 0;
                lblSize.Text = @"Size: n/d";
            }
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            cboDpi.Items.Add("96");
            cboDpi.Items.Add("100");
            cboDpi.Items.Add("200");
            cboDpi.Items.Add("300");
            cboDpi.SelectedIndex = 0;

            if (!string.IsNullOrWhiteSpace(_lastDpi))
            {
                cboDpi.Text = _lastDpi;
            }
        }

        public void SaveLastDpi()
        {
            _lastDpi = cboDpi.Text;
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }
    }

    internal class ChooseDpiViewBase : MapWindowView<ChooseDpiModel> { }
}
