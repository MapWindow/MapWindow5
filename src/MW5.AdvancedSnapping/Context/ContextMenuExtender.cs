using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.AdvancedSnapping.Services;
using MW5.Api.Interfaces;

namespace MW5.Plugins.AdvancedSnapping.Context
{
    public class ContextMenuExtender : CommandDispatcher<ShapeEditor.Context.ContextMenuView, AdvancedSnappingCommand>
    {
        private readonly IAppContext _context;
        private readonly AdvancedSnappingPlugin _plugin;
        private readonly ShapeEditor.Context.ContextMenuPresenter _shapeEditorContextMenuPresenter;
        private readonly ISnapRestrictionService _snapRestrictionService;
        private readonly IAnchorService _anchorService;

        public bool IsOpen
        {
            get => _shapeEditorContextMenuPresenter.VertexMenu.Visible;
        }

        public ContextMenuExtender(IAppContext context, 
            AdvancedSnappingPlugin plugin,
            ShapeEditor.Context.ContextMenuView view,
            ISnapRestrictionService snapRestrictionService,
            IAnchorService anchorService,
            ShapeEditor.Context.ContextMenuPresenter shapeEditorContextMenuPresenter) : base(view)
        {
            _context = context ?? throw new ArgumentNullException("context");
            _plugin = plugin ?? throw new ArgumentNullException("plugin");
            _shapeEditorContextMenuPresenter = shapeEditorContextMenuPresenter ?? throw new ArgumentNullException("shapeEditorContextMenuPresenter");
            _snapRestrictionService = snapRestrictionService ?? throw new ArgumentNullException("snapRestrictionService");
            _anchorService = anchorService ?? throw new ArgumentNullException("anchorService");

            AddItems();
        }

        public void UpdateStates()
        {
            foreach (var item in items)
                item.Visible = false;

            var layer = _context.Map.Layers.Current;
            if (!layer?.FeatureSet?.InteractiveEditing ?? true)
                return;

            foreach (var item in items)
            {
                item.Enabled = false;
                switch (item.Name)
                {
                    case "ctxSnapBearing":
                        item.Enabled = _plugin.CanSnapBearing;
                        item.Visible = item.Enabled;
                        break;
                    case "ctxSnapDistance":
                        item.Enabled = _plugin.CanSnapDistance;
                        item.Visible = item.Enabled;
                        break;
                    case "ctxSnapParallel":
                        item.Enabled = _plugin.CanSnapParallel;
                        item.Visible = item.Enabled;
                        break;
                    case "ctxSnapPerpendicular":
                        item.Enabled = _plugin.CanSnapPerpendicular;
                        item.Visible = item.Enabled;
                        break;
                    case "ctxClearSnapLines":
                        item.Enabled = _plugin.HasActiveSnapLines;
                        item.Visible = item.Enabled;
                        break;
                    case "ctxAutoClearSnapLines":
                        item.Checked = _plugin.AutoClearSnapLines;
                        item.Enabled = item.Visible = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Adds context menu items to the shape editor
        /// </summary>
        private void AddItems()
        {
            // Keep track of items
            items = new List<ToolStripMenuItem>();

            // Add them to the existing context menu
            var index = _shapeEditorContextMenuPresenter.VertexMenu.Items.IndexOfKey("ctxSnapping");
            index = AddItem(index, "ctxSnapParallel", "Parallel to this", "S", MW5.Plugins.AdvancedSnapping.Properties.Resources.parallel);
            index = AddItem(index, "ctxSnapPerpendicular", "Perpendicular to this", "F", MW5.Plugins.AdvancedSnapping.Properties.Resources.perpendicular);
            index = AddItem(index, "ctxSnapDistance", "Distance from this", "D", MW5.Plugins.AdvancedSnapping.Properties.Resources.distance);
            index = AddItem(index, "ctxSnapBearing", "Bearing from this", "G", MW5.Plugins.AdvancedSnapping.Properties.Resources.bearing);

            // Put this one at the bottom
            index = _shapeEditorContextMenuPresenter.VertexMenu.Items.IndexOfKey("ctxClearEditor");
            index = AddItem(index, "ctxClearSnapLines", "Clear snap lines", "", null);

            var options = _shapeEditorContextMenuPresenter.VertexMenu.Items["ctxSnapping"] as ToolStripMenuItem;
            var ctxAutoClearSnapLines = new ToolStripMenuItem {
                Name = "ctxAutoClearSnapLines",
                Text = "Auto-clear snap lines"
            };
            options.DropDownItems.Add(ctxAutoClearSnapLines);
            items.Add(ctxAutoClearSnapLines);

            // Call this to hook up event handlers:
            InitMenu(new ToolStripItemCollection(_shapeEditorContextMenuPresenter.VertexMenu, items.ToArray()));
        }

        private IList<ToolStripMenuItem> items;

        private int AddItem(int index, string name, string text, string shortCutKey, Bitmap image)
        {
            var item = new ToolStripMenuItem();
            item.Name = name;
            item.Text = text;
            item.ShortcutKeyDisplayString = shortCutKey;
            if (image != null) item.Image = image;
            _shapeEditorContextMenuPresenter.VertexMenu.Items.Insert(index++, item);
            items.Add(item);
            return index;
        }

        public override void RunCommand(AdvancedSnappingCommand command)
        {

            var anchor = _anchorService.PrimaryAnchor;
            var userAnchorLocation = _anchorService.UserAnchorLocation;
            var segment = _anchorService.ReferenceSegment;

            var map = _context.Map;
            switch (command)
            {
                case AdvancedSnappingCommand.ClearSnapLines:
                    _snapRestrictionService.Clear();
                    break;
                case AdvancedSnappingCommand.SnapDistance:
                    _snapRestrictionService.SnapDistance(anchor, handle: map.GeometryEditor.NumPoints);
                    break;
                case AdvancedSnappingCommand.SnapBearing:
                    _snapRestrictionService.SnapBearing(anchor, handle: map.GeometryEditor.NumPoints);
                    break;
                case AdvancedSnappingCommand.SnapParallel:
                    if (segment != null)
                    {
                        // If we're snapping parallel, ask user how far if he's not yet digitizing
                        //bool needsUserInput = (anchor == _anchorFeatureService.LastUserLocation);
                        _snapRestrictionService.SnapParallel(
                            _context.Map.GeometryEditor.NumPoints > 0 ? anchor : segment.Item1, 
                            segment.Item1, segment.Item2, 
                            offsetAnchor: _context.Map.GeometryEditor.NumPoints > 0 ? segment.Item1 : null, 
                            handle: map.GeometryEditor.NumPoints
                        );
                    }
                    break;
                case AdvancedSnappingCommand.SnapPerpendicular:
                    if (segment != null)
                    {
                        // If we're snapping parallel, ask user how far if he's not yet digitizing
                        //bool needsUserInput = (anchor == _anchorService.LastUserLocation);
                        _snapRestrictionService.SnapPerpendicular(
                            anchor, 
                            segment.Item1, segment.Item2, 
                            handle: map.GeometryEditor.NumPoints
                        );
                    }
                    break;
                case AdvancedSnappingCommand.AutoClearSnapLines:
                    _snapRestrictionService.AutoClear = !_snapRestrictionService.AutoClear;
                    UpdateStates();
                    break;
            }

            _context.View.Update();
            _context.Map.Redraw(RedrawType.SkipDataLayers);
        }
    }
}
