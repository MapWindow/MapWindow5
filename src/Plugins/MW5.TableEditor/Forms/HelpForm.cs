using System.Windows.Forms;
using MW5.UI;

namespace MW5.Plugins.TableEditor.Forms
{
    /// <summary>
    ///  Form-class for showing help
    /// </summary>
    public partial class HelpForm : MapWindowForm
    {
        /// <summary>Initializes a new instance of the frmHelp class</summary>
        /// <param name = "text">The help-text.</param>
        public HelpForm(string text)
        {
            InitializeComponent();

            help_tb.Text = text;
            help_tb.Select(help_tb.Text.Length, 0);
        }
    }
}