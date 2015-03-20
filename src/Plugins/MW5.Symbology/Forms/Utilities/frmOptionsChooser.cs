// ********************************************************************************************************
// <copyright file="MWLite.Symbology.cs" company="MapWindow.org">
// Copyright (c) MapWindow.org. All rights reserved.
// </copyright>
// The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
// you may not use this file except in compliance with the License. You may obtain a copy of the License at 
// http:// Www.mozilla.org/MPL/ 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
// ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
// limitations under the License. 
// 
// The Initial Developer of this version of the Original Code is Sergei Leschinski
// 
// Contributor(s): (Open source contributors should list themselves and their modifications here). 
// Change Log: 
// Date            Changed By      Notes
// ********************************************************************************************************

using System;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Symbology.Helpers;

namespace MW5.Plugins.Symbology.Forms.Utilities
{
    public partial class frmOptionsChooser : Form
    {
        private IMuteLegend m_legend = null;

        // the name of data source to be loaded
        private string m_filename = "";

        // handle of the layer
        private int m_handle = -1;
        
        // no events during the init of the form
        private bool m_NoEvents = false;

        // initial serialized state of the layer
        private string m_initState = "";
        
        /// <summary>
        /// Creates a new instance of the frmOptionsChooser class
        /// </summary>
        public frmOptionsChooser(IMuteLegend legend, string filename, int handle)
        {
            InitializeComponent();
            if (!System.IO.File.Exists(filename))
            {
                throw new Exception("File doesn't exists");
                return;
            }

            m_legend = legend;

            m_filename = filename;
            m_handle = handle;
            
            Globals.FillSymbologyList(listView1, filename, false, ref m_NoEvents);

            m_NoEvents = true;
            LoadLayer();
            m_NoEvents = false;
        }

        /// <summary>
        /// Loads layer from datasource specifed by filename
        /// </summary>
        private void LoadLayer()
        {
            axMap1.Layers.Clear();
            int handle = -1;
            string ext = System.IO.Path.GetExtension(m_filename).ToLower();
            if (ext == ".shp")
            {
                var sf = new FeatureSet(m_filename);
                handle = axMap1.Layers.Add(sf);
                sf.Labels.SavingMode = PersistenceType.None;
                sf.Diagrams.SavingMode = PersistenceType.None;
            }
            else
            {
                var img = BitmapSource.Open(m_filename, false);
                handle = axMap1.Layers.Add(img);
            }

            // serializing initial state to display random options afterwrads
            m_initState = axMap1.Layers.ItemByHandle(handle).Serialize();
        }

        /// <summary>
        /// Applies a given set of options to the layer
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            var map = m_legend.Map;
            if (map != null)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    if (listView1.SelectedItems[0].Index > 0)    // otherwise that's random options
                    {
                        int row = listView1.SelectedItems[0].Index;
                        string name = listView1.SelectedItems[0].Text;
                        SymbologyType type = (SymbologyType)listView1.SelectedItems[0].Tag;

                        if (type == SymbologyType.Default)
                        {
                            name = "";
                        }
                        string description = "";
                        bool res = map.Layers.ItemByHandle(m_handle).LoadOptions(name, ref description);
                    }
                }
            }
        }

        /// <summary>
        /// Cancels layer adding
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // do nothing
        }

        /// <summary>
        /// Closes the form by double clicking on the options
        /// </summary>
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            btnOk_Click(null, null);
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Sets symbology loading behavior to deafult options mode
        /// </summary>
        private void chkDontShow_CheckedChanged(object sender, EventArgs e)
        {
            //m_mapWin.ApplicationInfo.SymbologyLoadingBehavior = MapWindow.Interfaces.SymbologyBehavior.DefaultOptions;
        }

        /// <summary>
        /// Unloading the layer before closing form
        /// </summary>
        private void frmOptionsChooser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (axMap1 != null)
            {
                axMap1.Layers.Clear();
                axMap1 = null;
            }
            GC.Collect();
        }

        /// <summary>
        /// Display selected options in the preview window
        /// </summary>
        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            if (!(listView1.SelectedItems.Count > 0))
                return;

            int row = listView1.SelectedItems[0].Index;
            int handle = axMap1.Layers[0].Handle;
            string name = listView1.SelectedItems[0].Text;
            SymbologyType type = (SymbologyType)listView1.SelectedItems[0].Tag;

            var layer = axMap1.Layers.ItemByHandle(handle);
            if (type == SymbologyType.Random)
            {
                lblDescription.Text = Globals.GetSymbologyDescription(SymbologyType.Random);
                lblDescription.Refresh();
                var sf = layer.FeatureSet;
                if (!layer.Deserialize(m_initState))
                {
                    Globals.Message.Warn("Error while loading options");
                }
                else
                {
                    axMap1.Redraw();
                }
                return;
            }
            else if (type == SymbologyType.Default)
            {
                name = "";
                lblDescription.Text = Globals.GetSymbologyDescription(SymbologyType.Default);
                lblDescription.Refresh();
            }
            

            // previously saved options (.mwsymb or .mwsr file)
            string description = "";
            
            if (!layer.LoadOptions(name, ref description))
            {
                Globals.Message.Warn("Error while loading options");
            }
            else
            {
                if (name != "")
                {
                    lblDescription.Text = description == "Enter description" ? "" :description;
                    lblDescription.Refresh();
                }
                axMap1.Redraw();
            }
        }

        /// <summary>
        /// Loads selected set of options. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnOk_Click(null, null);
            this.DialogResult = DialogResult.OK;
        }
    }
}
