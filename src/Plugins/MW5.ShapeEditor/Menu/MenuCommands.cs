using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public override IEnumerable<MenuCommand> GetCommands()
        {
            return new List<MenuCommand>()
            {
                new MenuCommand("Create Layer", MenuKeys.CreateLayer, Resources.icon_layer_create,
                "Creates ESRI Shapefile layer of any supported geometry type."),

                new MenuCommand("Edit layer", MenuKeys.LayerEdit, Resources.icon_layer_edit),
                new MenuCommand("Add geometry", MenuKeys.GeometryCreate, Resources.icon_geometry_create),
                new MenuCommand("Vertex editor", MenuKeys.VertexEditor, Resources.icon_vertex_editor),
                new MenuCommand("Move shapes", MenuKeys.MoveShapes, Resources.icon_geometry_move),
                new MenuCommand("Rotate shapes", MenuKeys.RotateShapes, Resources.icon_geometry_rotate),
                new MenuCommand("Split shapes", MenuKeys.SplitShapes, Resources.icon_geometry_split),
                new MenuCommand("Merge shapes", MenuKeys.MergeShapes, Resources.icon_geometry_merge),
                new MenuCommand("Copy", MenuKeys.Copy, Resources.icon_edit_copy),
                new MenuCommand("Paste", MenuKeys.Paste, Resources.icon_edit_paste),
                new MenuCommand("Cut", MenuKeys.Cut, Resources.icon_edit_cut),
                new MenuCommand("Undo", MenuKeys.Undo, Resources.icon_edit_undo),
                new MenuCommand("Redo", MenuKeys.Redo, Resources.icon_edit_redo),

                new MenuCommand("Erase by polygon", MenuKeys.EraseByPolygon, null),
                new MenuCommand("Clip by polygon", MenuKeys.ClipByPolygon, null),
                new MenuCommand("Split by polygon", MenuKeys.SplitByPolygon, null),
                new MenuCommand("Split by polyline", MenuKeys.SplitByPolyline, Resources.icon_geometry_split_by_polyline),

                new MenuCommand("Delete selected", MenuKeys.DeleteSelected, Resources.img_delete_selected),
            };
        }
    }
}
