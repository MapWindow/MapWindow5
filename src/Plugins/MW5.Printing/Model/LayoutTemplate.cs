using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Plugins.Printing.Model
{
    public class LayoutTemplate
    {
        public LayoutTemplate(string filename)
        {
            Filename = filename;

            // TODO: load from template
            Orientation = Orientation.Vertical;
            PaperFormat = "A4";
            Pages = "1 × 1";
        }

        public string Filename { get; private set; }

        public string Name
        {
            get { return Path.GetFileNameWithoutExtension(Filename); }
        }

        public string PaperFormat { get; set; }

        public Orientation Orientation { get; private set; }

        public string Pages { get; private set; }
    }
}
