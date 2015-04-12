// ----------------------------------------------------------------------------
// MapWindow.Controls.LayersControl: 
// Author: Sergei Leschinski
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Plugins.Interfaces;

namespace MW5.UI.Legacy
{
    /// <summary>
    /// Provides functionality to choose layers from project or from open file dialog
    /// </summary>
    public partial class LayersDialog : Form
    {
        IAppContext _context = null;
        
        /// <summary>
        /// Creates a new instance of LayersDialog class, with no selected layers passed
        /// </summary>
        /// <param name="mapWin">Reference to MapWindow 4</param>
        /// <param name="geomTypes">Layer types to be included in the list</param>
        public LayersDialog(IAppContext mapWin, GeometryType[] geomTypes)
            : this(mapWin, geomTypes, null)
        {
        }

        /// <summary>
        /// Creates new instance of LayersDialog class
        /// </summary>
        /// <param name="context">Reference to MapWindow 4</param>
        /// <param name="geomTypes">Layer types to be included in the list</param>
        /// <param name="selection">List of filesnames to be checked</param>
        public LayersDialog(IAppContext context, GeometryType[] geomTypes, IEnumerable<string> selection)
        {
            InitializeComponent();

            if (context == null) throw new NullReferenceException();
            _context = context;

            listView1.Items.Clear();

            foreach(var layer1 in context.Layers)
            {
                var layer = (Layer) layer1;

                foreach (var geomType in geomTypes)
                {
                    var fs = layer.FeatureSet;
                    if (fs == null)
                    {
                        continue;
                    }

                    if (fs.GeometryType == geomType)
                    {
                        var item = new ListViewItem(layer.Name) {Tag = layer};

                        if (selection != null && selection.Contains(layer.Filename))
                        {
                            item.Checked = true;
                        }

                        listView1.Items.Add(item);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Selects/deselects all layers
        /// </summary>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                item.Checked = checkBox1.Checked;
            }
        }

        /// <summary>
        /// Gets the list of selected layers (null if no layers were selected)
        /// </summary>
        public IList<Layer> SelectedLayers
        {
            get 
            {
                IEnumerable<ListViewItem> items = listView1.Items.Cast<ListViewItem>().Where(item => item.Checked).ToList();

                if (items.Any())
                {
                    return items.Select(item => (Layer) item.Tag).ToList();
                }

                return null;
            }
        }

        /// <summary>
        /// Returns list of non-selected layers
        /// </summary>
        public IList<Layer> NonSelectedLayers
        {
            get
            {
                var items = listView1.Items.Cast<ListViewItem>().Where(item => !item.Checked).ToList();

                if (items.Any())
                {
                    return items.Select(item => (Layer) item.Tag).ToList();
                }

                return null;
            }
        }

        /// <summary>
        /// Closes the dialog, returns list of layers
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            //if (listView1.Items.Cast<ListViewItem>().Where(item => item.Checked).Count() == 0)
            //{
            //    MessageBox.Show("No layers were selected", m_mapWin.ApplicationInfo.ApplicationName,
            //                     MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.DialogResult = DialogResult.None;
            //}
        }
    }
}
