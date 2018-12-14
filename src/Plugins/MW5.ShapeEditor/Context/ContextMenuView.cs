using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.ShapeEditor.Services;

namespace MW5.Plugins.ShapeEditor.Context
{
    public partial class ContextMenuView : UserControl, IMenuProvider
    {
        private readonly IAppContext _context;
        private readonly IGeoprocessingService _geoService;

        public ContextMenuView(IAppContext context, IGeoprocessingService geoService)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (geoService == null) throw new ArgumentNullException("geoService");

            _context = context;
            _geoService = geoService;

            InitializeComponent();

            contextDigitizing.Opening += DigitizingMenuOpening;

            contextSelection.Opening += SelectionMenuOpening;

            contextVertex.Opening += VertexMenuOpening;
        }

        public ContextMenuStrip DigitizingMenu
        {
            get { return contextDigitizing; }
        }

        public ContextMenuStrip SelectionMenu
        {
            get { return contextSelection; }
        }

        public ContextMenuStrip VertexMenu
        {
            get { return contextVertex; }
        }

        public IEnumerable<ToolStripItemCollection> ToolStrips
        {
            get
            {
                yield return contextDigitizing.Items;
                yield return contextSelection.Items;
                yield return contextVertex.Items;
            }
        }

        public IEnumerable<Control> Buttons
        {
            get { yield break; }
        }

        private void VertexMenuOpening(object sender, CancelEventArgs e)
        {
            DisableAll(contextVertex);

            var editor = _context.Map.GeometryEditor;

            bool hasShape = !editor.IsEmpty;
            ctxAddPart.Enabled = hasShape;
            ctxRemovePart.Enabled = hasShape;
            ctxSaveShape.Enabled = hasShape;
            ctxClearEditor.Enabled = hasShape;
            ctxUndo.Enabled = hasShape;
            ctxVertexEditor.Enabled = true;
            ctxPartEditor.Enabled = true;
            ctxVertexEditor.Checked = editor.EditorBehavior == EditorBehavior.VertexEditor;
            ctxPartEditor.Checked = editor.EditorBehavior == EditorBehavior.PartEditor;

            SetupSnapping(editor);

            SetupHighlighting(editor);

            bool editing = _context.Map.MapCursor == MapCursor.EditShape;
            ctxPartEditor.Visible = editing;
            ctxVertexEditor.Visible = editing;
            ctxAddPart.Visible = editing;
            ctxRemovePart.Visible = editing;
            editorSeparator1.Visible = editing;
            editorSeparator2.Visible = editing;

            digitizerSeparator.Visible = !editing;
            ctxUndo.Visible = !editing;

            ctxSaveShape.Text = editing ? "Save Shape Changes" : "Finish Operation";

            bool hasChanges = editor.HasChanges;
            if (hasChanges)
            {
                ctxSaveShape.Enabled = true;
                ctxClearEditor.Text = editing ? "Discard Shape Changes" : "Cancel";
            }
            else
            {
                ctxSaveShape.Enabled = false;
                ctxClearEditor.Text = "Stop Editing";
            }
        }

        private void SelectionMenuOpening(object sender, CancelEventArgs e)
        {
            DisableAll(contextSelection);

            var fs = _context.Layers.Current.FeatureSet;

            ctxSelectByRectangle.Enabled = true;
            ctxSelectByRectangle.Checked = _context.Map.MapCursor == MapCursor.Selection;
            ctxMoveShapes.Checked = _context.Map.MapCursor == MapCursor.MoveShapes;
            ctxRotateShapes.Checked = _context.Map.MapCursor == MapCursor.RotateShapes;
            ctxUndo.Enabled = _context.Map.History.UndoCount > 0;

            if (fs != null && fs.InteractiveEditing)
            {
                int selectedCount = fs.NumSelected;
                ctxMergeShapes.Enabled = selectedCount > 1;
                ctxSplitShapes.Enabled = selectedCount > 0;
                ctxMoveShapes.Enabled = selectedCount > 0;
                ctxRemoveShapes.Enabled = selectedCount > 0;
                ctxRotateShapes.Enabled = selectedCount > 0;
                ctxClearSelection.Enabled = selectedCount > 0;
            }

            if (fs != null)
            {
                ctxCopy.Enabled = fs.NumSelected > 0;
                ctxCut.Enabled = fs.NumSelected > 0 && fs.InteractiveEditing;
                ctxPaste.Enabled = !_geoService.BufferIsEmpty && fs.InteractiveEditing;
            }
        }

        private void DigitizingMenuOpening(object sender, CancelEventArgs e)
        {
            var editor = _context.Map.GeometryEditor;

            bool notEmpty = !editor.IsEmpty;
            ctxCancelShape.Enabled = notEmpty;
            ctxFinishShape.Enabled = notEmpty;
            ctxUndoPoint.Enabled = notEmpty;

            SetupSnapping(editor);

            SetupHighlighting(editor);
        }

        private void SetupSnapping(IGeometryEditor editor)
        {
            ctxSnapAll.Checked = editor.SnapBehavior == LayerSelectionMode.AllLayers;
            ctxSnapNone.Checked = editor.SnapBehavior == LayerSelectionMode.NoLayer;
            ctxSnapCurrent.Checked = editor.SnapBehavior == LayerSelectionMode.ActiveLayer;

            ctxSnapToLines.Checked = editor.SnapMode == SnapMode.VerticesAndLines;
            ctxSnapToVertices.Checked = editor.SnapMode == SnapMode.Vertices;
            ctxSnapToLines.Checked = editor.SnapMode == SnapMode.Lines;

            ctxSnapping.Enabled = true;
        }

        private void SetupHighlighting(IGeometryEditor editor)
        {
            mnuHighlightCurrent.Checked = editor.HighlightVertices == LayerSelectionMode.ActiveLayer;
            mnuHighlightAll.Checked = editor.HighlightVertices == LayerSelectionMode.AllLayers;
            mnuHighlightNone.Checked = editor.HighlightVertices == LayerSelectionMode.NoLayer;

            ctxHighlighting.Enabled = true;
        }

        private void DisableAll(ContextMenuStrip menu)
        {
            foreach (var item in menu.Items.OfType<ToolStripMenuItem>())
            {
                item.Enabled = false;
            }
        }
    }
}
