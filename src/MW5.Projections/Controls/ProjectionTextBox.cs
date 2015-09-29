// ----------------------------------------------------------------------------
// MapWindow.Controls.Projections: store controls to work with EPSG projections
// database
// Author: Sergei Leschinski
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MW5.Projections.Controls
{
    /// <summary>
    /// Rich text box enhanced with method of formatting OGC WKT projection string
    /// </summary>
    [ToolboxBitmap(typeof(RichTextBox))]
    public class ProjectionTextBox : RichTextBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectionTextBox"/> class.
        /// </summary>
        public ProjectionTextBox()
        {
            Font = new Font(Font.Name, 10.0f);
        }

        /// <summary>
        /// Shows nicely formatted projection string
        /// </summary>
        public void ShowProjection(string projection)
        {
            if (projection.Trim().Length == 0)
            {
                return;
            }

            string s = FormatWkt(projection);
            s = string.IsNullOrWhiteSpace(s) ? projection : s;

            Text = s;

            SelectAll();
            SelectionColor = Color.Black;
            SelectionLength = 0;

            FormatProjection();
        }

        /// <summary>
        /// Formats OGC WKT string in the textbox. Position where projection string located can be specified.
        /// </summary>
        private void FormatProjection(int start = 0)
        {
            // marking parameters
            int position = start;
            string s = Text;

            if (string.IsNullOrWhiteSpace(s))
            {
                return;
            }

            do
            {
                int i = position;
                while (i < s.Length - 1 && s[i] != '[')
                {
                    i++;
                }

                if (s[i] == '[')
                {
                    Select(position, i - position);
                    SelectionColor = Color.DarkGreen;
                }

                position = i;
                position = s.IndexOf("\n", position);
            } 
            while (position != -1);

            // marking text values
            bool started = false;
            position = 0;

            for (int i = position; i < s.Length; i++)
            {
                if (s[i] == '\"')
                {
                    if (!started)
                    {
                        position = i;
                    }
                    else
                    {
                        Select(position + 1, i - position - 1);
                        SelectionColor = Color.Maroon;
                    }
                    started = !started;
                }
            }
        }

        /// <summary>
        /// A structure for FormatWkt function
        /// </summary>
        internal struct Break
        {
            internal int Position;
            internal int Level;

            internal Break(int position, int level)
            {
                Position = position;
                Level = level;
            }
        }

        /// <summary>
        /// Formats WKT string so as each new parameter start with the new line with appropriate indent
        /// </summary>
        /// <param name="s">Unformatted WKT string without newline characters</param>
        private string FormatWkt(string s)
        {
            var list = new List<Break>();

            int level = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '[')
                {
                    int j = i;
                    j--;

                    // skipping spaces between name and [ (if any)
                    while (j >= 0 && s[j] == ' ')
                    {
                        j--;
                    }

                    // skipping name
                    while (j >= 0 && (s[j] != ',' && s[j] != ' '))
                    {
                        j--;
                    }

                    j++;

                    var br = new Break(j, level);
                    list.Add(br);
                    level++;
                }

                if (s[i] == ']')
                {
                    level--;
                }
            }

            // inserting breaks
            string output = "";
            if (list.Count <= 0)
            {
                return output;
            }

            output = s.Substring(0, list[1].Position);

            for (int i = 1; i < list.Count; i++)
            {
                int begin = list[i].Position;
                int end = (i == list.Count - 1) ? s.Length - 1 : list[i + 1].Position;

                output +=  '\n'; //Environment.NewLine;
                output += new string(' ', 4 * list[i].Level);
                output += s.Substring(begin, end - begin).Trim();
            }

            return output;
        }
    }
}
