using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Plugins.Symbology.Helpers
{
    internal static class ListViewHelper
    {   
        /// <summary>
        /// Build list of available options for the layer (.mwsymb, .mwsr files)
        /// </summary>
        internal static void FillSymbologyList(this ListView listView, string filename, bool manager, ref bool noEvents)
        {
            noEvents = true;
            listView.Items.Clear();

            // always available
            if (!manager)
            {
                ListViewItem item = listView.Items.Add("[random]");
                item.Tag = SymbologyType.Random;
            }

            string path = filename + ".mwsymb";
            if (File.Exists(path))
            {
                ListViewItem item = listView.Items.Add("[default]");
                item.Tag = SymbologyType.Default;
            }

            // cities.shp.default.mwsymb
            path = Path.GetDirectoryName(filename);
            string[] names = Directory.GetFiles(path, Path.GetFileName(filename) + "*");
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].ToLower().EndsWith(".mwsymb"))
                {
                    string name = names[i].Substring(filename.Length);
                    if (name.ToLower() == ".mwsymb")
                    {
                        // was added before
                    }
                    else
                    {
                        name = name.Substring(1, name.Length - 8);
                        ListViewItem item = listView.Items.Add(name);
                        item.Tag = SymbologyType.Custom;
                    }
                }
            }

        if (listView.Items.Count > 0)
        {
            listView.SelectedIndices.Add(0);
        }
        noEvents = false;
        }
    }
}
