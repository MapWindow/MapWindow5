using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.TableEditor.Editor
{
    public class ColumnEventArgs: EventArgs
    {
        public ColumnEventArgs(int columnIndex, Point location)
        {
            ColumnIndex = columnIndex;
            Location = location;
        }

        public int ColumnIndex { get; private set; }

        public Point Location { get; private set; }
    }
}
