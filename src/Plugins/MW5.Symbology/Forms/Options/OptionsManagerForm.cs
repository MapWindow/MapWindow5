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
using System.IO;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Symbology.Helpers;
using MW5.Shared;
using MW5.UI;
using MW5.UI.Helpers;

namespace MW5.Plugins.Symbology.Forms.Options
{
    public partial class OptionsManagerForm : MapWindowForm
    {
        private readonly IMuteLegend _legend;
        private readonly int _handle;
        private readonly ILayer _layer;
        private bool _noEvents;

        /// <summary>
        /// Creates a new instance of the frmOptionsManager class
        /// </summary>
        public OptionsManagerForm(IMuteLegend legend, int handle)
        {
            InitializeComponent();

            _noEvents = true;
            _handle = handle;
            _legend = legend;
            _layer = _legend.Map.GetLayer(_handle);

            if (_layer == null)
            {
                throw new NullReferenceException("Invalid layer handle");
            }

            listView1.FillSymbologyList(_layer.Filename, true, ref _noEvents);

            if (listView1.Items.Count > 0)
            {
                LoadLayer();
            }

            RefreshControlsState();

            _noEvents = false;
        }

        /// <summary>
        /// Removes all layers on closing
        /// </summary>
        private void frmOptionsManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (axMap1 != null)
            {
                axMap1.Layers.Clear();
                axMap1 = null;
            }
            GC.Collect();
        }

        /// <summary>
        /// Loads layer from datasource specifed by filename
        /// </summary>
        private void LoadLayer()
        {
            axMap1.Layers.Clear();

            var extension = Path.GetExtension(_layer.Filename);
            if (extension != null)
            {
                string ext = extension.ToLower();
                if (ext == ".shp")
                {
                    var sf = new FeatureSet(_layer.Filename);
                    axMap1.Layers.Add(sf);
                    sf.Labels.SavingMode = PersistenceType.None;
                    sf.Diagrams.SavingMode = PersistenceType.None;
                }
                else
                {
                    var img = BitmapSource.Open(_layer.Filename, false);
                    axMap1.Layers.Add(img);
                }
            }
        }

        /// <summary>
        /// Saves the current state of the layer
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            var form = new AddOptionsForm {txtName = {Text = ""}, txtDescription = {Text = ""}};

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                string value = form.txtName.Text;
                txtDescription.Text = form.txtDescription.Text;

                if (listView1.Items.Count == 0)
                {
                    LoadLayer();
                }

                // in case file exists, let's ask the user if we are to overwrite it
                string name = _layer.Filename + "." + value + ".mwsymb";
                if (File.Exists(name))
                {
                    if (!SymbologyPlugin.Msg.Ask("Set of options with such name already exists." + Environment.NewLine + "Do you want to rewrite it?"))
                    {
                        return;
                    }
                }

                var map = _legend.Map;
                map.GetLayer(_handle).SaveOptions(value, true, txtDescription.Text);

                // updating the list
                listView1.FillSymbologyList(_layer.Filename, true, ref _noEvents);
                dgv_CurrentCellChanged(null, null);

                RefreshControlsState();
            }
            form.Dispose();
        }

        /// <summary>
        /// Renames selected set of options (including file)
        /// </summary>
        private void btnRename_Click(object sender, EventArgs e)
        {
            string name; SymbologyType type;
            if (!get_CurrentNameAndType(out name, out type))
                return;

            if (type == SymbologyType.Default)
                return;

            string newName = name;

            var form = new AddOptionsForm
            {
                Text = "Rename options",
                txtName = {Text = newName},
                txtDescription = {Text = txtDescription.Text}
            };

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                newName = form.txtName.Text.Trim();
                txtDescription.Text = form.txtDescription.Text;

                try
                {
                    string oldFileame = _layer.Filename + "." + name + ".mwsymb";
                    File.Delete(oldFileame);

                    var map = _legend.Map;
                    map.Layers[0].SaveOptions(newName, true, txtDescription.Text);
                }
                catch
                {
                    SymbologyPlugin.Msg.Warn("Failed to rename file");
                    return;
                }

                // updating the list
                listView1.SelectedItems[0].Text = newName;
            }
            form.Dispose();
        }

        /// <summary>
        /// Edits name of the current option set
        /// </summary>
        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnRename_Click(null, null);
        }

        /// <summary>
        /// Returns name and type of the currently selected row
        /// </summary>
        private bool get_CurrentNameAndType(out string name, out SymbologyType type)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                name = "";
                type = SymbologyType.Custom;
                return false;
            }

            name = listView1.SelectedItems[0].Text;
            type = (SymbologyType)listView1.SelectedItems[0].Tag;
            return true;
        }

        /// <summary>
        /// Applies the selected options and closes the form
        /// </summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            string name; SymbologyType type;
            if (!get_CurrentNameAndType(out name, out type))
                return;

            if (type == SymbologyType.Default)
            {
                name = "";
            }

            var map = _legend.Map;
            if (map != null)
            {
                int handle = _layer.Handle;
                string description = "";
                if (map.GetLayer(handle).LoadOptions(name, ref description))
                {
                    _legend.Redraw(LegendRedraw.LegendAndMap);
                }
                else
                {
                    SymbologyPlugin.Msg.Warn("Error while loading options");
                }
            }
        }

        /// <summary>
        /// Displaying set of options
        /// </summary>
        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            if (_noEvents)
                return;

            if (listView1.Items.Count == 0)
            {
                axMap1.Layers.Clear();
                txtDescription.Text = "";
            }
            else
            {
                string name; SymbologyType type;
                if (!get_CurrentNameAndType(out name, out type))
                    return;

                if (type == SymbologyType.Default)
                {
                    name = "";
                    txtDescription.Text = SymbologyType.Default.EnumToString();
                }

                // previously saved options (.mwsymb or .mwsr file)
                int handle = axMap1.Layers[0].Handle;
                string description = "";
                if (!axMap1.Layers.ItemByHandle(handle).LoadOptions(name, ref description))
                {
                    SymbologyPlugin.Msg.Warn("Error while loading options");
                }
                else
                {
                    if (name != "")
                    {
                        txtDescription.Text = description;
                    }
                    axMap1.Redraw();
                }
            }
            RefreshControlsState();
        }

        /// <summary>
        /// Saves current sset of options as a default one
        /// </summary>
        private void btnMakDefault_Click(object sender, EventArgs e)
        {
            string name; SymbologyType type;
            if (!get_CurrentNameAndType(out name, out type))
                return;

            string filename = _layer.Filename + "." + name + ".mwsymb";

            if (type != SymbologyType.Default && System.IO.File.Exists(filename))
            {
                // let's rename the existing default set
                string oldName = _layer.Filename + ".mwsymb";
                if (File.Exists(oldName))
                {
                    // seak for unoccupied name
                    int index = 0;
                    string newName = _layer.Filename + ".untitled-" + index + ".mwsymb";
                    while (File.Exists(newName))
                    {
                        index++;
                        newName = _layer.Filename + ".untitled-" + index + ".mwsymb";
                    }
                    try
                    {
                        File.Move(oldName, newName);
                    }
                    catch
                    {
                        SymbologyPlugin.Msg.Warn("Failed to rename file");
                        return;
                    }
                }

                // renaming currnet file
                File.Move(filename, oldName);
                listView1.FillSymbologyList(_layer.Filename, true, ref _noEvents);
                dgv_CurrentCellChanged(null, null);
            }
        }

        /// <summary>
        /// Removes all the available options for the layer
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                return;
            }

            var map = _legend.Map;
            if (map != null)
            {
                if (SymbologyPlugin.Msg.Ask("Do you want to remove all option sets for the layer?"))
                {
                    int errorCount = 0;
                    for (int row = 0; row < listView1.Items.Count; row++)
                    {
                        string name = listView1.Items[row].ToString();
                        SymbologyType type = (SymbologyType)listView1.Items[row].Tag;

                        if (type == SymbologyType.Default)
                            name = "";

                        if (!map.GetLayer(_layer.Handle).RemoveOptions(name))
                        {
                            errorCount++;
                        }
                    }

                    // redrawing
                    listView1.FillSymbologyList(_layer.Filename, true, ref _noEvents);
                    dgv_CurrentCellChanged(null, null);

                    if (errorCount > 0)
                    {
                        SymbologyPlugin.Msg.Warn("Failed to remove options: " + errorCount + Environment.NewLine + 
                                        "Reason: " + map.LastError);
                    }
                }
            }
            RefreshControlsState();
        }

        /// <summary>
        /// Removes the selected options, either .mwsymb or .mwsr
        /// </summary>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            string name; SymbologyType type;
            if (!get_CurrentNameAndType(out name, out type))
                return;

            if (SymbologyPlugin.Msg.Ask("Do you want to remove the following set of options: " + name + "?"))
            {
                var map = _legend.Map;
                if (map != null)
                {
                    if (type == SymbologyType.Default)
                    {
                        name = "";
                    }

                    if (_layer.RemoveOptions(name))
                    {
                        listView1.FillSymbologyList(_layer.Filename, true, ref _noEvents);
                        dgv_CurrentCellChanged(null, null);
                    }
                    else
                    {
                        SymbologyPlugin.Msg.Warn("Failed to remove options." + Environment.NewLine + "Reason: " + map.LastError);
                    }
                }
            }
            RefreshControlsState();
        }

        /// <summary>
        /// Updates enabled property of the controls
        /// </summary>
        private void RefreshControlsState()
        {
            bool enabled = listView1.SelectedItems.Count > 0;
            btnApply.Enabled = enabled;
            //btnClear.Enabled = enabled;
            btnMakDefault.Enabled = enabled;
            btnRemove.Enabled = enabled;
            btnRename.Enabled = enabled;
            txtDescription.Enabled = true;
        }

        /// <summary>
        /// Shows rename window if applicable
        /// </summary>
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                if ((SymbologyType)listView1.SelectedItems[0].Tag == SymbologyType.Custom)
                {
                    btnRename_Click(null, null);
                }
            }
        }
    }
}
