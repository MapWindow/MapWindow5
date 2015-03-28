// ********************************************************************************************************
// <copyright file="Main.cs" company="TopX Geo-ICT">
//     Copyright (c) 2012 TopX Geo-ICT. All rights reserved.
// </copyright>
// ********************************************************************************************************
// The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
// you may not use this file except in compliance with the License. You may obtain a copy of the License at 
// http:// www.mozilla.org/MPL/ 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
// ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
// limitations under the License. 
// 
// The Initial Developer of this version is Jeen de Vegt.
// 
// Contributor(s): (Open source contributors should list themselves and their modifications here). 
// Change Log: 
// Date           Changed By      Notes
// 29 March 2012  Jeen de Vegt    Inital coding
// 05 Jan 2013    Paul Meems      Moved toolbar button to existing Layer toolbar
// ********************************************************************************************************

namespace MW5.Plugins.TableEditor.Legacy
{
    /// <summary>
  ///   This is the start of the plug-in. In here all methods of the IPlugin interface can be implemented.
  /// </summary>
  //public class Main : PluginBase
  //{
  //  /// <summary>Change this to your own address</summary>
  //  private const string ReportEmailaddress = "Bontepaarden@gmail.com";

  //  /// <summary>The stack with the toolbuttons</summary>
  //  private readonly Stack<string> addedToolbuttons = new Stack<string>();

  //  /// <summary>The name of your button. This need to be a constant</summary>
  //  private const string MyButton = "Table Editor";

  //  /// <summary>The name of the toolbar</summary>
  //  private string toolbarName;

  //  /// <summary>Reference to the frmTableEditor</summary>
  //  private frmTableEditor tableEditor;

  //  /// <summary>The toolbar button, needed to enable/disable it</summary>
  //  private ToolbarButton tableEditorButton;

  //  /// <summary>lsu: on each reloading of the project a new instance of plug-in object is created.
  //  /// The old instance isn't collected for some reason, so it continues to handle MW events after Terminate event.
  //  /// This flag is a quick fix to prevent handling join events several times. Better solution - to explore
  //  /// lifecycle of plugin instance to ensure that it's destroyed.</summary>
  //  private bool handleEvents;

  //  /// <summary>This event is called when a plugin is loaded or turned on in the MapWindow.</summary>
  //  public override void Initialize()
  //  {
  //    try
  //    {
  //      // Create toolbar:
  //      this.toolbarName = this.Author;
  //      this.CreateToolbar();
  //      this.App.Project.OnUpdateTableJoin += this.Project_OnUpdateTableJoin;
  //      this.handleEvents = true;

  //    }
  //    catch (Exception ex)
  //    {
  //      this.App.ShowErrorDialog(ex, ReportEmailaddress);
  //    }
  //  }

  //  /// <summary>
  //  /// Restores join operation
  //  /// </summary>
  //  /// <param name="filename">Filename of the join source to restore</param>
  //  /// <param name="fieldNames">The name of fieds to be included in table</param>
  //  /// <param name="joinOptions">Options specific for particular data source, like separator for csv or worksheet name for Excel</param>
  //  /// <param name="tableToFill">Table to be filled from source and consumed by ocx</param>
  //  private void Project_OnUpdateTableJoin(string filename, string fieldNames, string joinOptions, Table tableToFill)
  //  {
  //    if (this.handleEvents)
  //    {
  //      BOShapeData.Table_OnUpdateJoin(filename, fieldNames, joinOptions, tableToFill);
  //    }
  //  }

  //  /// <summary>This method is called when a plugin is unloaded. The plugin should remove all toolbars, buttons and menus that it added.</summary>
  //  public override void Terminate()
  //  {
  //    this.handleEvents = false;

  //    // Remove toolbar:
  //    if (this.addedToolbuttons != null)
  //    {
  //      // Unloads the buttons in reverse order
  //      while (this.addedToolbuttons.Count > 0)
  //      {
  //        this.App.Toolbar.RemoveButton(this.addedToolbuttons.Pop());
  //      }

  //      // If all buttons are removed, remove toolbar as well:
  //      if (this.App.Toolbar.NumToolbarButtons(this.toolbarName) == 0)
  //      {
  //        this.App.Toolbar.RemoveToolbar(this.toolbarName);
  //      }
  //    }
  //  }

  //  /// <summary>Occurs when a user clicks on a toolbar button or menu item.</summary>
  //  /// <param name = "itemName">The name of the item clicked on.</param>
  //  /// <param name = "handled">Reference parameter.  Setting Handled to true prevents other plugins from receiving this event.</param>
  //  public override void ItemClicked(string itemName, ref bool handled)
  //  {
  //    try
  //    {
  //      switch (itemName)
  //      {
  //        case MyButton:
  //          handled = true;

  //          if (this.tableEditor == null)
  //          {
  //            BOShapeFile sf = this.CreateBOShapeFile();
  //            if (sf != null)
  //            {
  //              this.tableEditor = new frmTableEditor(sf, new BOMapWindow(App));

  //              this.tableEditor.FormClosing += this.TableEditorFormClosing;

  //              // ParentHandle is used to let the forms not fall behind MapWindow:
  //              this.tableEditor.Show(Control.FromHandle(new IntPtr(this.ParentHandle)));

  //              this.tableEditor.InitForm();
  //            }
  //            else
  //            {
  //              MessageBox.Show(@"Selected layer is not a shapefile.");
  //            }
  //          }

  //          break;
  //      }
  //    }
  //    catch (Exception ex)
  //    {
  //      this.App.ShowErrorDialog(ex, ReportEmailaddress);
  //    }
  //  }

  //  /// <summary>Occurs when the editor-form is closing.</summary>
  //  /// <param name = "sender">The sender of the event.</param>
  //  /// <param name = "e">The arguments.</param>
  //  public void TableEditorFormClosing(object sender, FormClosingEventArgs e)
  //  {
  //    this.tableEditor.Dispose();
  //    this.tableEditor = null;
  //  }

  //  /// <summary>Updates the selected shapes in grid equal to the map.</summary>
  //  /// <param name = "handle">The handle.</param>
  //  /// <param name = "selectInfo">Additional info.</param>
  //  public override void ShapesSelected(int handle, SelectInfo selectInfo)
  //  {
  //    if (this.tableEditor != null)
  //    {
  //      this.tableEditor.SetSelected();
  //    }
  //  }

  //  /// <summary>New layer selected.</summary>
  //  /// <param name = "handle">The handle.</param>
  //  public override void LayerSelected(int handle)
  //  {
  //    this.tableEditorButton.Enabled = this.LayerIsShapefile(handle);

  //    if (this.tableEditor == null)
  //    {
  //      return;
  //    }

  //    this.tableEditor.CheckAndSaveChanges();

  //    if (!this.LayerIsShapefile(handle))
  //    {
  //      this.tableEditor.Close();
  //      return;
  //    }

  //    BOShapeFile boShapeFile = this.CreateBOShapeFile();
  //    if (boShapeFile == null)
  //    {
  //      MessageBox.Show(this.tableEditor, @"Selected layer is not a shapefile");
  //      return;
  //    }

  //    this.ClearSelections();

  //    this.tableEditor.BoShapeFile = boShapeFile;
  //    this.tableEditor.SetDataGrid();
  //  }

  //  /// <summary>All layers are cleared</summary>
  //  public override void LayersCleared()
  //  {
  //    // Disable button:
  //    this.tableEditorButton.Enabled = false;

  //    // Close table editor:
  //    if (this.tableEditor == null)
  //    {
  //      return;
  //    }

  //    this.tableEditor.Close();
  //    this.tableEditor = null;
  //  }

  //  /// <summary>Listen to broadcasted messages</summary>
  //  /// <param name="msg">The message</param>
  //  /// <param name="handled">Handled or not</param>
  //  public override void Message(string msg, ref bool handled)
  //  {
  //    if ("TABLEEDITORSTART".Equals(msg.ToUpper()))
  //    {
  //      // Response to selection in legend context menu:
  //      this.ItemClicked(MyButton, ref handled);
  //    }
  //  }

  //  /// <summary>Is the layer a shapefile</summary>
  //  /// <param name="handle">The layer handle</param>
  //  /// <returns>True if shapefile else false</returns>
  //  internal bool LayerIsShapefile(int handle)
  //  {
  //    if (handle < 0)
  //    {
  //      return false;
  //    }

  //    if (!this.App.Layers.IsValidHandle(handle))
  //    {
  //      return false;
  //    }

  //    var layerType = this.App.Layers[handle].LayerType;
  //    return layerType == eLayerType.LineShapefile || layerType == eLayerType.PointShapefile || layerType == eLayerType.PolygonShapefile;
  //  }

  //  /// <summary>Clears all selections.</summary>
  //  private void ClearSelections()
  //  {
  //    for (int i = 0; i < App.Layers.NumLayers; i++)
  //    {
  //      App.Layers[i].ClearSelection();
  //    }
  //  }

  //  /// <summary>Create the toolbar</summary>
  //  private void CreateToolbar()
  //  {
  //    // Add toolbar with buttons:
  //    var t = this.App.Toolbar;

  //    // Paul Meems: Add toolbar button to layer toolbar:
  //    // t.AddToolbar(this.toolbarName);
  //    t.AddToolbar("tlbLayers");

  //    // Add button:
  //    this.tableEditorButton = t.AddButton(MyButton, "tlbLayers", string.Empty, string.Empty);
  //    this.tableEditorButton.BeginsGroup = true;
  //    this.tableEditorButton.Tooltip = "Table Editor";
  //    this.tableEditorButton.Category = this.toolbarName;
  //    this.tableEditorButton.Text = "Table";
  //    this.tableEditorButton.Picture = Properties.Resources.table_editor;
  //    this.tableEditorButton.Enabled = this.App.Layers.NumLayers > 0;

  //    // Save to remove it easily on terminate:
  //    this.addedToolbuttons.Push(MyButton);
  //  }

  //  /// <summary>Creates the BOShapeFile.</summary>
  //  /// <returns>The BOShapeFile</returns>
  //  private BOShapeFile CreateBOShapeFile()
  //  {
  //    // PM, Possible fix for issue #2266:
  //    if (this.App.Layers.CurrentLayer == -1)
  //    {
  //      return null;
  //    }

  //    BOShapeFile boShapeFile = null;

  //    Shapefile shapeFile = App.Layers[App.Layers.CurrentLayer].GetObject() as Shapefile;
  //    if (shapeFile != null)
  //    {
  //      boShapeFile = new BOShapeFile
  //          {
  //            ShapeFile = shapeFile,
  //            ShapefileName = this.App.Layers[this.App.Layers.CurrentLayer].Name
  //          };
  //    }

  //    return boShapeFile;
  //  }
  //}
}
