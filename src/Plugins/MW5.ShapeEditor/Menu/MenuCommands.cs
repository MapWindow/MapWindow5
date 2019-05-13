﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.ShapeEditor.Properties;

namespace MW5.Plugins.ShapeEditor.Menu
{
    public class MenuCommands: CommandProviderBase
    {
        public MenuCommands(PluginIdentity identity)
            : base(identity)
        {
        }

        protected override void AssignShortcutKeys()
        {
            // it overrides copy command in panels, Debug window for example
            // so let's comment for the time being
            //Commands[MenuKeys.Copy].ShortcutKeys = Keys.Control | Keys.C;

            Commands[MenuKeys.Paste].ShortcutKeys = Keys.Control | Keys.V;
            Commands[MenuKeys.Cut].ShortcutKeys = Keys.Control | Keys.X;

            // see MapControl.OnMapPreviewKeyDown for details
            Commands[MenuKeys.Undo].ShortcutKeys = Keys.Control | Keys.Z;
        }

        public override IEnumerable<MenuCommand> GetCommands()
        {
            return new List<MenuCommand>()
            {
                new MenuCommand("Create Layer", MenuKeys.CreateLayer, Resources.icon_layer_create,
                "Creates ESRI Shapefile layer of any supported geometry type."),

                new MenuCommand("Edit Layer", MenuKeys.LayerEdit, Resources.icon_layer_edit),
                new MenuCommand("Add Geometry", MenuKeys.GeometryCreate, Resources.icon_geometry_create),
                new MenuCommand("Vertex Editor", MenuKeys.VertexEditor, Resources.icon_vertex_editor),
                new MenuCommand("Move Shapes", MenuKeys.MoveShapes, Resources.icon_geometry_move),
                new MenuCommand("Rotate Shapes", MenuKeys.RotateShapes, Resources.icon_geometry_rotate),
                new MenuCommand("Exlode Shapes", MenuKeys.SplitShapes, Resources.icon_geometry_split),
                new MenuCommand("Merge Shapes", MenuKeys.MergeShapes, Resources.icon_geometry_merge),
                new MenuCommand("Copy", MenuKeys.Copy, Resources.icon_edit_copy),
                new MenuCommand("Paste", MenuKeys.Paste, Resources.icon_edit_paste),
                new MenuCommand("Cut", MenuKeys.Cut, Resources.icon_edit_cut),
                new MenuCommand("Undo", MenuKeys.Undo, Resources.icon_edit_undo),
                new MenuCommand("Redo", MenuKeys.Redo, Resources.icon_edit_redo),

                new MenuCommand("Erase by Polygon", MenuKeys.EraseByPolygon, null),
                new MenuCommand("Clip by Polygon", MenuKeys.ClipByPolygon, null),
                new MenuCommand("Split by Polygon", MenuKeys.SplitByPolygon, null),
                new MenuCommand("Split by Polyline", MenuKeys.SplitByPolyline, Resources.icon_geometry_split_by_polyline),

                new MenuCommand("Delete Selected", MenuKeys.DeleteSelected, Resources.img_delete_selected),

                new MenuCommand("Snap to Active Layer", MenuKeys.SnapToActiveLayer, Resources.img_snap_active_layer),
                new MenuCommand("Snap to All Layers", MenuKeys.SnapToAlLayers, Resources.img_snap_all_layers),

                new MenuCommand("Snap to Vertices", MenuKeys.SnapToVertices, Resources.img_snap_to_vertices),
                new MenuCommand("Snap to Segments", MenuKeys.SnapToSegments, Resources.img_snap_to_segments),
            };
        }
    }
}
