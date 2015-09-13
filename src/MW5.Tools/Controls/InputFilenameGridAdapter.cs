using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Tools.Controls
{
    internal class InputFilenameGridAdapter
    {
        public InputFilenameGridAdapter(string filename)
        {
            Filename = filename;
        }

        public string Filename { get; private set;}
    }
}
