using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Shared;

namespace MW5.UI.Forms
{
    // Extracted from: http ://www.codeproject.com/Articles/601900/FlexibleMessageBox-A-flexible-replacement-for-the
    // Can server a substitute for the regular message boxes.
    public partial class CustomDialog : MapWindowForm
    {
        public CustomDialog(string text, bool checkedState, string caption = null)
        {
            InitializeComponent();

            richTextBoxMessage.Font = SystemFonts.MessageBoxFont;
            
            richTextBoxMessage.Text = text;
            SetDialogSize(text, caption);
        }

        public static double MAX_WIDTH_FACTOR = 0.7;
        public static double MAX_HEIGHT_FACTOR = 0.9;
        public static Font FONT = SystemFonts.MessageBoxFont;


        private static double GetCorrectedWorkingAreaFactor(double workingAreaFactor)
        {
            const double MIN_FACTOR = 0.2;
            const double MAX_FACTOR = 1.0;

            if (workingAreaFactor < MIN_FACTOR) return MIN_FACTOR;
            if (workingAreaFactor > MAX_FACTOR) return MAX_FACTOR;

            return workingAreaFactor;
        }

        private static void SetDialogStartPosition(Form flexibleMessageBoxForm, IWin32Window owner)
        {
            //If no owner given: Center on current screen
            if (owner == null)
            {
                var screen = Screen.FromPoint(Cursor.Position);
                flexibleMessageBoxForm.StartPosition = FormStartPosition.Manual;
                flexibleMessageBoxForm.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - flexibleMessageBoxForm.Width / 2;
                flexibleMessageBoxForm.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - flexibleMessageBoxForm.Height / 2;
            }
        }

        private static string[] GetStringRows(string message)
        {
            if (string.IsNullOrEmpty(message)) return null;

            var messageRows = message.Split(new char[] { '\n' }, StringSplitOptions.None);
            return messageRows;
        }

        private void SetDialogSize(string text, string caption)
        {
            //First set the bounds for the maximum dialog size
            this.MaximumSize = new Size(Convert.ToInt32(SystemInformation.WorkingArea.Width * GetCorrectedWorkingAreaFactor(MAX_WIDTH_FACTOR)),
                                                          Convert.ToInt32(SystemInformation.WorkingArea.Height * GetCorrectedWorkingAreaFactor(MAX_HEIGHT_FACTOR)));

            //Get rows. Exit if there are no rows to render...
            var stringRows = GetStringRows(text);
            if (stringRows == null) return;

            //Calculate whole text height
            var textHeight = TextRenderer.MeasureText(text, FONT).Height;

            //Calculate width for longest text line
            const int SCROLLBAR_WIDTH_OFFSET = 15;
            var longestTextRowWidth = stringRows.Max(textForRow => TextRenderer.MeasureText(textForRow, FONT).Width);
            var captionWidth = TextRenderer.MeasureText(caption, SystemFonts.CaptionFont).Width;
            var textWidth = Math.Max(longestTextRowWidth + SCROLLBAR_WIDTH_OFFSET, captionWidth);

            //Calculate margins
            var marginWidth = this.Width - this.richTextBoxMessage.Width;
            var marginHeight = this.Height - this.richTextBoxMessage.Height;

            //Set calculated dialog size (if the calculated values exceed the maximums, they were cut by windows forms automatically)
            this.Size = new Size(textWidth + marginWidth,
                                                   textHeight + marginHeight);
        }
    }
}
