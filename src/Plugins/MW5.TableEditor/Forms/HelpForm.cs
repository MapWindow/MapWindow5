using System.Windows.Forms;

namespace MW5.Plugins.TableEditor.Forms
{
    /// <summary>
    ///  Form-class for showing help
    /// </summary>
    public partial class HelpForm : Form
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