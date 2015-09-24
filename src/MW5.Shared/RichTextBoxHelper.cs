using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Shared
{
    /// <summary>
    /// Extension methods for RichTextBox control.
    /// </summary>
    public static class RichTextBoxHelper
    {
        /// <summary>
        /// Sets text box content and makes the first line bold.
        /// </summary>
        public static void SetDescription(this RichTextBox box, string description)
        {
            box.Clear();
            box.Text = description;
            box.MakeFirstLineBold();
        }

        /// <summary>
        /// Clears any previous styles and sets text box content.
        /// </summary>
        /// <param name="box">The box.</param>
        /// <param name="text">The text.</param>
        public static void SetText(this RichTextBox box, string text)
        {
            box.Clear();
            box.Text = text;
        }

        /// <summary>
        /// Makes the first line bold.
        /// </summary>
        public static void MakeFirstLineBold(this RichTextBox box)
        {
            var text = box.Text;
            int pos = text.IndexOf("\n", StringComparison.Ordinal);

            if (pos != -1)
            {
                box.Select(0, pos + 1);
                box.SelectionFont = new Font(box.Font, FontStyle.Bold);
            }
        }
        
        /// <summary>
        /// Initializes the dock panel footer.
        /// </summary>
        public static void InitDockPanelFooter(this RichTextBox textbox)
        {
            textbox.BorderStyle = BorderStyle.None;
            textbox.Dock = DockStyle.Fill;
            textbox.ScrollBars = RichTextBoxScrollBars.None;
            textbox.BackColor = Color.FromKnownColor(KnownColor.Control);
            textbox.ReadOnly = true;
        }
    }
}
