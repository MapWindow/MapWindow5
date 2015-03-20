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

namespace MW5.Plugins.Symbology.Forms.Utilities
{
    //public partial class frmOptionsManager : Form
    //{
    //    private IMuteLegend m_legend = null;
        
    //    // handle of the layer
    //    private int m_handle = -1;

    //    // layer to set options for
    //    private Layer m_layer = null;

    //    private bool m_noEvents = false;

    //    /// <summary>
    //    /// Creates a new instance of the frmOptionsManager class
    //    /// </summary>
    //    public frmOptionsManager(IMuteLegend legend, int handle)
    //    {
    //        InitializeComponent();

    //        m_handle = handle;
    //        m_noEvents = true;

    //        m_legend = legend;

    //        m_layer = m_legend.GetLayer(m_handle);
    //        if (m_layer == null)
    //        {
    //            throw new NullReferenceException("Invalid layer handle");
    //        }

    //        Globals.FillSymbologyList(listView1, m_layer.Filename, true, ref m_noEvents);

    //        if (listView1.Items.Count > 0)
    //            LoadLayer();

    //        RefreshControlsState();

    //        m_noEvents = false;
    //    }

    //    /// <summary>
    //    /// Removes all layers on closing
    //    /// </summary>
    //    private void frmOptionsManager_FormClosed(object sender, FormClosedEventArgs e)
    //    {
    //        if (axMap1 != null)
    //        {
    //            axMap1.RemoveAllLayers();
    //            axMap1 = null;
    //        }
    //        GC.Collect();
    //    }

    //    /// <summary>
    //    /// Loads layer from datasource specifed by filename
    //    /// </summary>
    //    private void LoadLayer()
    //    {
    //        axMap1.RemoveAllLayers();

    //        int handle = -1;
    //        string ext = System.IO.Path.GetExtension(m_layer.Filename).ToLower();
    //        if (ext == ".shp")
    //        {
    //            MapWinGIS.Shapefile sf = new MapWinGIS.Shapefile();
    //            if (sf.Open(m_layer.Filename , null))
    //            {
    //                handle = axMap1.AddLayer(sf, true);
    //                sf.Labels.SavingMode = MapWinGIS.tkSavingMode.modeNone;
    //                sf.Charts.SavingMode = MapWinGIS.tkSavingMode.modeNone;
    //                //sf.FastMode = true;
    //            }
    //        }
    //        else
    //        {
    //            MapWinGIS.Image img = new MapWinGIS.Image();
    //            if (img.Open(m_layer.Filename, MapWinGIS.ImageType.USE_FILE_EXTENSION, false, null))
    //            {
    //                handle = this.axMap1.AddLayer(img, true);
    //            }
    //        }
    //    }
       
    //    /// <summary>
    //    /// Saves the current state of the layer
    //    /// </summary>
    //    private void btnSave_Click(object sender, EventArgs e)
    //    {
    //        frmAddOptions form = new frmAddOptions();
            
    //        // some values can be set there
    //        form.txtName.Text = "";
    //        form.txtDescription.Text = "";

    //        if (form.ShowDialog(this) == DialogResult.OK)
    //        {
    //            string value = form.txtName.Text;
    //            txtDescription.Text = form.txtDescription.Text;

    //            if (listView1.Items.Count == 0)
    //                this.LoadLayer();

    //            // in case file exists, let's ask the user if we are to overwrite it
    //            string name = m_layer.Filename + "." + value + ".mwsymb";
    //            if (System.IO.File.Exists(name))
    //            {
    //                if (MessageBox.Show("Set of options with such name already exists." + Environment.NewLine +
    //                                "Do you want to rewrite it?", "MapWindow_5", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
    //            }

    //            var map = m_legend.Map; 
    //            map.SaveLayerOptions(m_handle, value, true, txtDescription.Text);

    //            // updating the list
    //            Globals.FillSymbologyList(listView1, m_layer.Filename, true, ref m_noEvents);
    //            dgv_CurrentCellChanged(null, null);

    //            RefreshControlsState();
    //        }
    //        form.Dispose();
    //    }

    //    /// <summary>
    //    /// Renames selected set of options (including file)
    //    /// </summary>
    //    private void btnRename_Click(object sender, EventArgs e)
    //    {
    //        string name; SymbologyType type;
    //        if (!get_CurrentNameAndType(out name, out type))
    //            return;

    //        if (type == SymbologyType.Default)
    //            return;

    //        string newName = name;
            
    //        frmAddOptions form = new frmAddOptions();
    //        form.Text = "Rename options";
    //        form.txtName.Text = newName;
    //        form.txtDescription.Text = this.txtDescription.Text; 

    //        if (form.ShowDialog(this) == DialogResult.OK)
    //        {
    //            newName = form.txtName.Text.Trim();
    //            this.txtDescription.Text = form.txtDescription.Text; 
                
    //            try
    //            {
    //                string oldFileame = m_layer.Filename + "." + name + ".mwsymb";
    //                System.IO.File.Delete(oldFileame);

    //                var map = m_legend.Map;
    //                map.SaveLayerOptions(map.get_LayerHandle(0), newName, true, txtDescription.Text);
    //            }
    //            catch
    //            {
    //                Globals.Message.Warn("Failed to rename file");
    //                return;
    //            }
                
    //            // updating the list
    //            listView1.SelectedItems[0].Text = newName;
    //        }
    //        form.Dispose();
    //    }

    //    /// <summary>
    //    /// Edits name of the current option set
    //    /// </summary>
    //    private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    //    {
    //        btnRename_Click(null, null);
    //    }

    //    /// <summary>
    //    /// Returns name and type of the currently selected row
    //    /// </summary>
    //    private bool get_CurrentNameAndType(out string name, out SymbologyType type)
    //    {
    //        if (listView1.SelectedItems.Count ==  0)
    //        {
    //            name = "";
    //            type = SymbologyType.Custom;
    //            return false;
    //        }
    //        else
    //        {
    //            int row = listView1.SelectedItems[0].Index;
                
    //            name = listView1.SelectedItems[0].Text;
    //            type = (SymbologyType)listView1.SelectedItems[0].Tag;
    //            return true;
    //        }
    //     }

    //    /// <summary>
    //    /// Applies the selected options and closes the form
    //    /// </summary>
    //    private void btnApply_Click(object sender, EventArgs e)
    //    {
    //        string name; SymbologyType type;
    //        if (!get_CurrentNameAndType(out name, out type))
    //            return;

    //        if (type == SymbologyType.Default)
    //        {
    //            name = "";
    //        }

    //        MapWinGIS.Map map = m_legend.Map;
    //        if (map != null)
    //        {
    //            int handle = m_layer.Handle;
    //            string description = "";
    //            if (map.LoadLayerOptions(handle, name, ref description))
    //            {
    //                m_legend.Map.Redraw();
    //                m_legend.Refresh();
    //            }
    //            else
    //            {
    //                Globals.Message.Warn("Error while loading options");
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// Displaying set of options
    //    /// </summary>
    //    private void dgv_CurrentCellChanged(object sender, EventArgs e)
    //    {
    //        if (m_noEvents)
    //            return;

    //        if (listView1.Items.Count == 0)
    //        {
    //            axMap1.RemoveAllLayers();
    //            txtDescription.Text = "";
    //        }
    //        else
    //        {
    //            string name; SymbologyType type;
    //            if (!get_CurrentNameAndType(out name, out type))
    //                return;

    //            if (type == SymbologyType.Default)
    //            {
    //                name = "";
    //                txtDescription.Text = Globals.GetSymbologyDescription(SymbologyType.Default);
    //            }

    //            // previously saved options (.mwsymb or .mwsr file)
    //            int handle = axMap1.get_LayerHandle(0);
    //            string description = "";
    //            if (!axMap1.LoadLayerOptions(handle, name, ref description))
    //            {
    //                Globals.Message.Warn("Error while loading options");
    //            }
    //            else
    //            {
    //                if (name != "")
    //                    this.txtDescription.Text = description;
    //                axMap1.Redraw();
    //            }
    //        }
    //        RefreshControlsState();
    //    }

    //    /// <summary>
    //    /// Saves current sset of options as a default one
    //    /// </summary>
    //    private void btnMakDefault_Click(object sender, EventArgs e)
    //    {
    //        string name; SymbologyType type;
    //        if (!get_CurrentNameAndType(out name, out type))
    //            return;

    //        string filename = m_layer.FileName + "." + name + ".mwsymb";
            
    //        if (type != SymbologyType.Default && System.IO.File.Exists(filename))
    //        {
    //            // let's rename the existing default set
    //            string oldName = m_layer.FileName + ".mwsymb";
    //            if (System.IO.File.Exists(oldName))
    //            {
    //                // seak for unoccupied name
    //                int index = 0;
    //                string newName = m_layer.FileName + ".untitled-" + index + ".mwsymb";
    //                while (System.IO.File.Exists(newName))
    //                {
    //                    index++;
    //                    newName = m_layer.FileName + ".untitled-" + index + ".mwsymb";
    //                }
    //                try
    //                {
    //                    System.IO.File.Move(oldName, newName);
    //                }
    //                catch
    //                {
    //                    Globals.Message.Warn("Failed to rename file");
    //                    return;
    //                }
    //            }

    //            // renaming currnet file
    //            System.IO.File.Move(filename, oldName);
    //            Globals.FillSymbologyList(listView1, m_layer.FileName, true, ref m_noEvents);
    //            dgv_CurrentCellChanged(null, null);
    //        }
    //    }

    //    /// <summary>
    //    /// Removes all the available options for the layer
    //    /// </summary>
    //    private void btnClear_Click(object sender, EventArgs e)
    //    {
    //        if (listView1.Items.Count == 0)
    //            return;

    //        MapWinGIS.Map map = m_legend.Map;
    //        if (map != null)
    //        {
    //            if (MessageBox.Show("Do you want to remove all option sets for the layer?", "MapWindow_5",
    //                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
    //            {
    //                int errorCount = 0;
    //                for (int row = 0; row < listView1.Items.Count; row++)
    //                {
    //                    string name = listView1.Items[row].ToString();
    //                    SymbologyType type = (SymbologyType)listView1.Items[row].Tag;

    //                    if (type == SymbologyType.Default)
    //                        name = "";

    //                    if (!map.RemoveLayerOptions(m_layer.Handle, name))
    //                    {
    //                        errorCount++;
    //                    }
    //                }

    //                // redrawing
    //                Globals.FillSymbologyList(listView1, m_layer.FileName, true, ref m_noEvents);
    //                dgv_CurrentCellChanged(null, null);

    //                if (errorCount > 0)
    //                {
    //                    Globals.Message.Warn("Failed to remove options: " + errorCount + Environment.NewLine + "Reason: " +
    //                                    map.get_ErrorMsg(map.LastErrorCode));
    //                }
    //            }
    //        }
    //        RefreshControlsState();
    //    }

    //    /// <summary>
    //    /// Removes the selected options, either .mwsymb or .mwsr
    //    /// </summary>
    //    private void btnRemove_Click(object sender, EventArgs e)
    //    {
    //        string name; SymbologyType type;
    //        if (!get_CurrentNameAndType(out name, out type))
    //            return;

    //        if (MessageBox.Show("Do you want to remove the following set of options: " + name + "?", "MapWindow_5",
    //                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
    //        {
    //            var map = m_legend.Map;
    //            if (map != null)
    //            {
    //                if (type == SymbologyType.Default)
    //                    name = "";

    //                if (map.RemoveLayerOptions(m_layer.Handle, name))
    //                {
    //                    Globals.FillSymbologyList(listView1, m_layer.FileName, true, ref m_noEvents);
    //                    dgv_CurrentCellChanged(null, null);
    //                }
    //                else
    //                {
    //                    Globals.Message.Warn("Failed to remove options." + Environment.NewLine +
    //                                    "Reason: " + map.get_ErrorMsg(map.LastErrorCode));
    //                }
    //            }
    //        }
    //        RefreshControlsState();
    //    }

    //    /// <summary>
    //    /// Updates enabled property of the controls
    //    /// </summary>
    //    private void RefreshControlsState()
    //    {
    //        bool enabled = listView1.SelectedItems.Count > 0;
    //        btnApply.Enabled = enabled;
    //        //btnClear.Enabled = enabled;
    //        btnMakDefault.Enabled = enabled;
    //        btnRemove.Enabled = enabled;
    //        btnRename.Enabled = enabled;
    //        txtDescription.Enabled = true;
    //    }
        
    //    /// <summary>
    //    /// Shows rename window if applicable
    //    /// </summary>
    //    private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
    //    {
    //        if (listView1.SelectedItems.Count == 1)
    //        {
    //            if ((SymbologyType)listView1.SelectedItems[0].Tag == SymbologyType.Custom)
    //            {
    //                btnRename_Click(null, null);
    //            }
    //        }
    //    }

        
    //}
}
