using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.ShapeEditor.Properties;

namespace MW5.Plugins.ShapeEditor.Menu
{
    public class CommandProvider: CommandProviderBase
    {
        public CommandProvider(PluginIdentity identity)
            : base(identity)
        {
        }

        public override List<MenuCommand> GetCommands()
        {
            return new List<MenuCommand>()
            {
                new MenuCommand("Edit layer", MenuKeys.LayerEdit, Resources.layer_edit),
                new MenuCommand("Create new layer", MenuKeys.LayerCreate, Resources.layer_create),
                new MenuCommand("Add geometry", MenuKeys.GeometryCreate, Resources.geometry_create),
                new MenuCommand("Vertex editor", MenuKeys.VertexEditor, Resources.vertex_editor),
                new MenuCommand("Move shapes", MenuKeys.MoveShapes, Resources.geometry_move),
                new MenuCommand("Rotate shapes", MenuKeys.RotateShapes, Resources.geometry_rotate),
                new MenuCommand("Split shapes", MenuKeys.SplitShapes, Resources.geometry_split),
                new MenuCommand("Merge shapes", MenuKeys.MergeShapes, Resources.geometry_merge),
                new MenuCommand("Copy", MenuKeys.Copy, Resources.edit_copy),
                new MenuCommand("Paste", MenuKeys.Paste, Resources.edit_paste),
                new MenuCommand("Cut", MenuKeys.Cut, Resources.edit_cut),
                new MenuCommand("Undo", MenuKeys.Undo, Resources.edit_undo),
                new MenuCommand("Redo", MenuKeys.Redo, Resources.edit_redo),
            };
        }
    }
}
