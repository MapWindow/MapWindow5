using System.Windows.Forms;

namespace MW5.Gdal.Helpers
{
    /// <summary>
    /// Static method for GDAL tools.
    /// </summary>
    internal static class GdalToolHelper
    {
        /// <summary>
        /// Check which values are set and create options string
        /// </summary>
        /// <param name="commandTextbox"> The command Textbox. </param>
        /// <param name="optionsControls"> The options Groupbox. </param>
        internal static void UpdateCommandTextbox(TextBox commandTextbox, Control.ControlCollection optionsControls)
        {
            commandTextbox.Text = string.Empty;

            foreach (Control control in optionsControls)
            {
                if (control is CheckBox)
                {
                    if ((control as CheckBox).Checked)
                    {
                        if ((control as CheckBox).Tag == null)
                        {
                            commandTextbox.Text += (control as CheckBox).Text.Trim() + @" ";
                        }
                        else
                        {
                            commandTextbox.Text += (control as CheckBox).Tag.ToString().Trim() + @" ";
                        }
                    }
                }

                if (control is ComboBox)
                {
                    if ((control as ComboBox).SelectedItem == null)
                    {
                        continue;
                    }

                    if ((control as ComboBox).SelectedItem.ToString() != string.Empty)
                    {
                        var tag = control.Tag.ToString().Trim();
                        if (!tag.EndsWith("="))
                        {
                            tag += @" ";
                        }

                        var txt = (control as ComboBox).SelectedItem.ToString().Trim();
                        if (txt.Contains(" "))
                        {
                            txt = "\"" + txt + "\"";
                        }

                        commandTextbox.Text += tag + txt + @" ";
                    }
                }

                if (control is TrackBar)
                {
                    var tag = control.Tag.ToString().Trim();
                    if (tag != string.Empty)
                    {
                        if (!tag.EndsWith("="))
                        {
                            tag += @" ";
                        }

                        commandTextbox.Text += tag + (control as TrackBar).Value + @" ";
                    }
                }

                if (control is TextBox)
                {
                    if ((control as TextBox).Text.Trim() != string.Empty)
                    {
                        var tag = control.Tag.ToString().Trim();
                        if (!tag.EndsWith("="))
                        {
                            tag += @" ";
                        }

                        var txt = (control as TextBox).Text.Trim();
                        if (txt.Contains(" "))
                        {
                            txt = "\"" + txt + "\"";
                        }

                        commandTextbox.Text += tag + txt + @" ";
                    }
                }
            }
        }
    }
}
