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
using System.Drawing;
using System.Windows.Forms;
using MW5.Api.Enums;

namespace MW5.Plugins.Symbology.Forms.Layer
{
    partial class LayerStyleForm
    {
        /// <summary>
        /// Sets the state of controls on the general tab on loading
        /// </summary>
        private void InitModeTab()
        {
            if (_shapefile.GeometryType == GeometryType.Point)
            {
                cboCollisionMode.Enabled = true;
                cboCollisionMode.Items.Clear();
                cboCollisionMode.Items.Add("Allow collisions");
                cboCollisionMode.Items.Add("Avoid point vs point collisions");
                cboCollisionMode.Items.Add("Avoid point vs label collisions");
                cboCollisionMode.SelectedIndex = (int)_shapefile.CollisionMode;
            }
            else
            {
                cboCollisionMode.Enabled = false;
            }

            // TODO: restore
            //chkFastMode.Checked = _shapefile.FastMode;
            //chkSpatialIndex.Checked = _shapefile.UseSpatialIndex && _shapefile.IsSpatialIndexValid();
            //chkInMemory.Checked = _shapefile.EditingShapes;
            //chkEditMode.Checked = _shapefile.InteractiveEditing;
            //udMinDrawingSize.SetValue((double)_shapefile.MinDrawingSize);
            //udMinLabelingSize.SetValue((double)_shapefile.Labels.MinDrawingSize);

            // displaying help string default help
            chkFastMode_Enter(chkFastMode, null);
        }
        
        /// <summary>
        /// Toggles fast edit mode for the shapefile
        /// </summary>
        private void chkFastEditingMode_CheckedChanged(object sender, EventArgs e)
        {
            if (_noEvents)
            {
                return;
            }

            //MapWinGIS.ICallback oldCallback = null;

            //if (chkFastMode.Checked)
            //{
            //    Enabled = false;
            //    Cursor = Cursors.WaitCursor;
            //    oldCallback = _shapefile.GlobalCallback;
            //    CallbackLocal callback = new CallbackLocal(progressBar1);
            //    _shapefile.GlobalCallback = callback;
            //    progressBar1.Visible = true;
            //    //groupModeDescription.Height = 267;
            //}

            //_shapefile.FastMode = chkFastMode.Checked;

            //if (chkFastMode.Checked)
            //{
            //    Cursor = Cursors.Default;
            //    Enabled = true;
            //    _shapefile.GlobalCallback = oldCallback;
            //    progressBar1.Visible = false;
            //    //groupModeDescription.Height = 293;
            //}

            RedrawMap();
        }

        /// <summary>
        /// Start and stops the edit mode for the shapefile
        /// </summary>
        private void chkEditMode_CheckedChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Creates spatial index for the shapefile. Toggles it's usage.
        /// </summary>
        private void chkSpatialIndex_CheckedChanged(object sender, EventArgs e)
        {
            if (_noEvents)
            {
                return;
            }

            if (chkSpatialIndex.Checked)
            {
                if (!_shapefile.SpatialIndex.DiskIndexExists)
                {
                    Enabled = false;
                    Cursor = Cursors.WaitCursor;
                    if (_shapefile.SpatialIndex.CreateDiskIndex())
                    {
                        SymbologyPlugin.Msg.Info("Spatial index was successfully created");
                    }
                    Enabled = true;
                    Cursor = Cursors.Default;
                }
                else
                {
                    _shapefile.SpatialIndex.UseDiskIndex = true;
                }
            }
            else
            {
                _shapefile.SpatialIndex.UseDiskIndex = false;
            }

            RedrawMap();
        }

        /// <summary>
        /// Changes the minimum size of object in pixels to be drawn
        /// </summary>
        private void udMinDrawingSize_ValueChanged(object sender, EventArgs e)
        {
            //_shapefile.MinDrawingSize = (int)udMinDrawingSize.Value;
            RedrawMap();
        }

        /// <summary>
        /// Changes the minimum size of the object to label
        /// </summary>
        private void udMinLabelingSize_ValueChanged(object sender, EventArgs e)
        {
            //_shapefile.Labels.MinDrawingSize = (int)udMinLabelingSize.Value;
            RedrawMap();
        }

        private void chkRedrawMap_CheckedChanged(object sender, EventArgs e)
        {
            //if (_noEvents) return;

            if (!chkRedrawMap.Checked)
            {
                //m_mapWin.View.LockMap();
                //Globals.Legend.Lock();
            }
            else
            {
                //m_mapWin.View.UnlockMap();
                //Globals.Legend.Unlock();
            }

            //_redrawModeIsChanging = true;
            //Ui2Settings(null, null);
            //RedrawMap();
            //_redrawModeIsChanging = false;
        }

        private void chkFastMode_MouseMove(object sender, MouseEventArgs e)
        {
            chkFastMode_Enter(sender, null);
        }

        private void chkFastMode_Enter(object sender, EventArgs e)
        {
            string s = string.Empty;
            if ((Control)sender == (Control)chkInMemory)
            {
                s += "In memory: shapefile data is current loaded into RAM.";
            }
            else if ((Control) sender == (Control) chkEditMode)
            {
                s += "Editing mode: starts or stops the editing session for the shapefile. The changes can be saved or discarded while closing.";
            }
            else if ((Control)sender == (Control)chkFastMode)
            {
                s += "Fast mode: loads shape data in the memory for faster drawing. There are certain limitations when using it coupled with editing mode.";
            }
            else if ((Control)sender == (Control)chkSpatialIndex)
            {
                s += "Spatial index: creates R-tree for faster search. Affects drawing and selection at close scales. Creates 2 files with .mwd and .mwx extentions in the shapefile folder. Isn't used for editing mode.";
            }
            else if ((Control)sender == (Control)udMinDrawingSize)
            {
                s += "Minimal drawing size: if the size polyline or polygon at current scale in pixels is less than this value, it will be drawn as a single dot.";
            }
            else if ((Control)sender == (Control)udMinLabelingSize)
            {
                s += "Minimal labeling size: a polygon or polyline will be labeled only if it's size in pixels greater than this value.";
            }
            else if ((Control)sender == (Control)cboCollisionMode)
            {
                s += "Collision mode: detemines whether point symbols can be drawn one above the another. Also if the collisions of points with labels are allowed.";
            }   
            else
            {
                // nothing
            }

            txtModeDescription.Text = s;

            Font font = new Font("Arial", 10.0f);
            txtModeDescription.SelectAll();
            txtModeDescription.SelectionFont = font;

            string[] str = { "Fast mode:", "Editing mode:", "In memory:", "Spatial index:", "Minimal drawing size: ", "Minimal labeling size:", "GDI mode for labels:", "Collision mode" };
            font = new Font("Arial", 10.0f, FontStyle.Bold);

            for (int i = 0; i < str.Length; i++)
            {
                int position = txtModeDescription.Text.IndexOf(str[i]);
                if (position >= 0)
                {
                    txtModeDescription.Select(position, str[i].Length);
                    txtModeDescription.SelectionFont = font;
                }
            }
        }
    }
}
