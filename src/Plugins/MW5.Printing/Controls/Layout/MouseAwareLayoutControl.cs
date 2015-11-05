// -------------------------------------------------------------------------------------------
// <copyright file="MouseAwareLayoutControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Printing.Enums;
using MW5.Plugins.Printing.Helpers;
using MW5.Plugins.Printing.Model;
using MW5.Plugins.Printing.Model.Elements;
using MW5.Plugins.Printing.Properties;
using MW5.Shared;

namespace MW5.Plugins.Printing.Controls.Layout
{
    [ToolboxItem(false)]
    public class MouseAwareLayoutControl : ContentAwareLayoutControl
    {
        private const float _inflate = 5F;
        private LayoutElement _elementToAddWithMouse;
        private PointF _lastMousePoint;
        private LayoutPage _lastPage;
        private PointF _mouseStartPoint;
        private Edge _resizeSelectedEdge;

        protected MouseAwareLayoutControl()
        {
            MouseDoubleClick += LayoutControlMouseDoubleClick;
            MouseDown += LayoutControlMouseDown;
            MouseMove += LayoutControlMouseMove;
            MouseUp += LayoutControlMouseUp;
            KeyUp += LayoutControlKeyUp;
        }

        /// <summary>
        /// Occurs when an element is double clicked.
        /// </summary>
        public event EventHandler<LayoutElementEventArgs> ElementDoubleClicked;

        /// <summary>
        /// Gets or sets the map pan mode
        /// </summary>
        [Browsable(false)]
        public bool PanMode
        {
            get { return _mouseMode == MouseMode.PanMap || _mouseMode == MouseMode.StartPanMap; }
            set { _mouseMode = value ? MouseMode.StartPanMap : MouseMode.Default; }
        }

        public override bool ShowPageNumbers
        {
            get { return base.ShowPageNumbers; }
            set
            {
                _lastPage = null;
                base.ShowPageNumbers = value;
            }
        }

        /// <summary>
        /// Allows the user to click on the layout and drag a rectangle where they want to insert an element
        /// </summary>
        public void AddElementWithMouse(LayoutElement le)
        {
            _elementToAddWithMouse = le;
            ClearSelection();
            _mouseMode = MouseMode.StartInsertNewElement;
            Cursor = Cursors.Cross;
        }

        private void LayoutControlKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    DeleteSelected();
                    break;
                case Keys.F5:
                    RefreshElements();
                    break;
            }
        }

        private void LayoutControlMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (DesignMode) return;

            var pnt = ScreenToPaper(e.Location);

            foreach (var el in LayoutElements)
            {
                if (el.ClickWithin((int)pnt.X, (int)pnt.Y))
                {
                    var args = new LayoutElementEventArgs(el) { Cancel = false };

                    DelegateHelper.FireEvent(this, ElementDoubleClicked, args);

                    if (!args.Cancel)
                    {
                        Invalidate();
                    }

                    break;
                }
            }
        }

        private void LayoutControlMouseDown(object sender, MouseEventArgs e)
        {
            if (DesignMode) return;

            //When the user clicks down we start tracking the mouses location
            _mouseStartPoint = new PointF(e.X, e.Y);
            _lastMousePoint = new PointF(e.X, e.Y);
            var mousePointPaper = ScreenToPaper(_mouseStartPoint);

            if (e.Button == MouseButtons.Left)
            {
                if (_showPageNumbers)
                {
                    var page = PageByClick(e.X, e.Y);
                    if (page != null)
                    {
                        if (ModifierKeys == Keys.Shift && _lastPage != null)
                        {
                            int startX = Math.Min(_lastPage.X, page.X);
                            int endX = Math.Max(_lastPage.X, page.X);
                            int startY = Math.Min(_lastPage.Y, page.Y);
                            int endY = Math.Max(_lastPage.Y, page.Y);
                            for (int x = startX; x <= endX; x++)
                            {
                                for (int y = startY; y <= endY; y++)
                                {
                                    var p = _pages.GetPage(x, y);
                                    if (p != null)
                                    {
                                        p.Selected = _lastPage.Selected;
                                    }
                                }
                            }
                            _lastPage = null;
                        }
                        else
                        {
                            page.Selected = !page.Selected;
                            _lastPage = page; // save the page for group selection
                        }

                        FirePageSelectionChanged();
                        Invalidate();
                    }
                }
                else
                {
                    switch (_mouseMode)
                    {
                        case MouseMode.Default:

                            //Handles resizing stuff
                            if (_resizeSelectedEdge != Edge.None)
                            {
                                _mouseMode = MouseMode.ResizeSelected;
                                if (_selectedLayoutElements.Count > 0)
                                {
                                    _selectedLayoutElements[0].Resizing = true;
                                    if (_selectedLayoutElements[0].ResizeStyle != ResizeStyle.HandledInternally)
                                    {
                                        var selecteScreenRect = PaperToScreen(_selectedLayoutElements[0].Rectangle);
                                        _resizeTempBitmap = new Bitmap(Convert.ToInt32(selecteScreenRect.Width),
                                            Convert.ToInt32(selecteScreenRect.Height), PixelFormat.Format32bppArgb);

                                        using (var graph = Graphics.FromImage(_resizeTempBitmap))
                                        {
                                            graph.SmoothingMode = DrawingQuality;
                                            graph.ScaleTransform(ScreenHelper.LogicToScreenDpi * _zoom,
                                                ScreenHelper.LogicToScreenDpi * _zoom);
                                            graph.TranslateTransform(-_selectedLayoutElements[0].Rectangle.X,
                                                -_selectedLayoutElements[0].Rectangle.Y);
                                            _selectedLayoutElements[0].DrawElement(graph, false, false);
                                        }
                                    }
                                }
                                return;
                            }

                            //Starts moving selected elements
                            if (ModifierKeys != Keys.Control)
                            {
                                if (_selectedLayoutElements.Any(le => le.IntersectsWith(mousePointPaper)))
                                {
                                    _mouseMode = MouseMode.MoveSelection;
                                    Cursor = Cursors.SizeAll;
                                    return;
                                }
                            }

                            //Starts the selection code.
                            _mouseMode = MouseMode.CreateSelection;
                            _mouseBox = new RectangleF(e.X, e.Y, 0F, 0F);
                            break;

                            //Start drag rectangle insert new element
                        case MouseMode.StartInsertNewElement:
                            _mouseMode = MouseMode.InsertNewElement;
                            _mouseBox = new RectangleF(e.X, e.Y, 0F, 0F);
                            break;

                            //Starts the pan mode for the map
                        case MouseMode.StartPanMap:
                            _mouseMode = MouseMode.PanMap;
                            _mouseBox = new RectangleF(e.X, e.Y, 0F, 0F);
                            break;
                    }
                }
            }

            //Deals with right button clicks
            if (e.Button == MouseButtons.Right)
            {
                switch (_mouseMode)
                {
                        //If the user was in insert mode we cancel it
                    case (MouseMode.StartInsertNewElement):
                        _mouseMode = MouseMode.Default;
                        _elementToAddWithMouse = null;
                        Cursor = Cursors.Default;
                        break;
                }
            }
        }

        private void LayoutControlMouseMove(object sender, MouseEventArgs e)
        {
            if (DesignMode) return;

            // the amount the mouse moved since the last time
            float deltaX = _lastMousePoint.X - e.X;
            float deltaY = _lastMousePoint.Y - e.Y;

            _lastMousePoint = e.Location;

            //Handles various different mouse modes
            switch (_mouseMode)
            {
                case MouseMode.InsertNewElement:
                case MouseMode.CreateSelection:
                    Invalidate(new Region(_mouseBox));
                    _mouseBox.Width = Math.Abs(_mouseStartPoint.X - e.X);
                    _mouseBox.Height = Math.Abs(_mouseStartPoint.Y - e.Y);
                    _mouseBox.X = Math.Min(_mouseStartPoint.X, e.X);
                    _mouseBox.Y = Math.Min(_mouseStartPoint.Y, e.Y);
                    Invalidate(new Region(_mouseBox));
                    break;

                    //Deals with moving the selection
                case MouseMode.MoveSelection:
                    _suppressElementInvalidation = true;
                    foreach (var le in _selectedLayoutElements)
                    {
                        var invalRect = PaperToScreen(le.Rectangle);
                        invalRect.Inflate(_inflate, _inflate);
                        Invalidate(new Region(invalRect));
                        var elementLocScreen = PaperToScreen(le.LocationF);
                        le.LocationF = ScreenToPaper(elementLocScreen.X - deltaX, elementLocScreen.Y - deltaY);
                        invalRect = PaperToScreen(le.Rectangle);
                        invalRect.Inflate(_inflate, _inflate);
                        Invalidate(new Region(invalRect));
                        Update();
                    }
                    _suppressElementInvalidation = false;
                    break;

                    //This handle mouse movement when in resize mode
                case MouseMode.ResizeSelected:
                    ResizeSelected(deltaX, deltaY);
                    break;

                case MouseMode.StartPanMap:
                    if (_selectedLayoutElements.Count == 1 && _selectedLayoutElements[0] is LayoutMap)
                    {
                        bool mouseWithinMap =
                            _selectedLayoutElements[0].IntersectsWith(ScreenToPaper(e.X * 1F, e.Y * 1F));
                        Cursor = mouseWithinMap ? new Cursor(Resources.ico_pan16.Handle) : Cursors.Default;
                    }
                    break;

                case MouseMode.PanMap:
                    _mouseBox.Width = e.X - _mouseStartPoint.X;
                    _mouseBox.Height = e.Y - _mouseStartPoint.Y;
                    Invalidate(new Region(PaperToScreen(_selectedLayoutElements[0].Rectangle)));
                    break;

                case MouseMode.Default:

                    //If theres only one element selected and were on its edge change the cursor to the resize cursor
                    if (_selectedLayoutElements.Count == 1)
                    {
                        var edge = LayoutHelper.IntersectElementEdge(
                            PaperToScreen(_selectedLayoutElements[0].Rectangle), new PointF(e.X, e.Y), 3F);

                        if ((edge == Edge.Bottom || edge == Edge.Top) &&
                            (_selectedLayoutElements[0] is LayoutTable || _selectedLayoutElements[0] is LayoutLegend)) // don't allow to change vertical size
                            return;

                        _resizeSelectedEdge = edge;

                        switch (_resizeSelectedEdge)
                        {
                            case Edge.TopLeft:
                            case Edge.BottomRight:
                                Cursor = Cursors.SizeNWSE;
                                break;
                            case Edge.Top:
                            case Edge.Bottom:
                                Cursor = Cursors.SizeNS;
                                break;
                            case Edge.TopRight:
                            case Edge.BottomLeft:
                                Cursor = Cursors.SizeNESW;
                                break;
                            case Edge.Left:
                            case Edge.Right:
                                Cursor = Cursors.SizeWE;
                                break;
                            case Edge.None:
                                Cursor = Cursors.Default;
                                break;
                        }
                    }
                    break;
            }
        }

        private void LayoutControlMouseUp(object sender, MouseEventArgs e)
        {
            if (DesignMode) return;

            if (e.Button == MouseButtons.Left)
            {
                //Handles various different mouse modes
                switch (_mouseMode)
                {
                        //If we are dealing with a selection we look here
                    case MouseMode.CreateSelection:
                        var selectBoxTL = ScreenToPaper(_mouseBox.Location);
                        var selectBoxBR = ScreenToPaper(_mouseBox.Location.X + _mouseBox.Width,
                            _mouseBox.Location.Y + _mouseBox.Height);
                        var selectBoxPaper = new RectangleF(selectBoxTL.X, selectBoxTL.Y, selectBoxBR.X - selectBoxTL.X,
                            selectBoxBR.Y - selectBoxTL.Y);

                        var elements = _layoutElements.Where(el => el.Visible);

                        if (ModifierKeys == Keys.Control)
                        {
                            foreach (var le in elements)
                            {
                                if (le.IntersectsWith(selectBoxPaper))
                                {
                                    if (_selectedLayoutElements.Contains(le)) _selectedLayoutElements.Remove(le);
                                    else _selectedLayoutElements.Add(le);
                                    //If the box is just a point only select the top most
                                    if (_mouseBox.Width <= 1 && _mouseBox.Height <= 1) break;
                                }
                            }
                        }
                        else
                        {
                            _selectedLayoutElements.Clear();
                            foreach (var le in elements)
                            {
                                if (le.IntersectsWith(selectBoxPaper))
                                {
                                    _selectedLayoutElements.Add(le);
                                    //If the box is just a point only select the top most
                                    if (_mouseBox.Width <= 1 && _mouseBox.Height <= 1) break;
                                }
                            }
                        }
                        OnSelectionChanged(null);
                        _mouseMode = MouseMode.Default;
                        Invalidate();
                        break;

                        //Stops moving the selection
                    case MouseMode.MoveSelection:
                        _mouseMode = MouseMode.Default;
                        Cursor = Cursors.Default;
                        break;

                        //Turns of resize
                    case MouseMode.ResizeSelected:
                        if (_resizeTempBitmap != null) _resizeTempBitmap.Dispose();
                        _resizeTempBitmap = null;
                        _mouseMode = MouseMode.Default;
                        Cursor = Cursors.Default;
                        if (_selectedLayoutElements.Count > 0)
                        {
                            _selectedLayoutElements[0].Resizing = false;
                            _selectedLayoutElements[0].Size = _selectedLayoutElements[0].Size;
                            Invalidate(new Region(PaperToScreen(_selectedLayoutElements[0].Rectangle)));
                        }
                        break;

                    case MouseMode.InsertNewElement:
                        if (_mouseBox.Width <= 0) _mouseBox.Width = 200;
                        if (_mouseBox.Height <= 0) _mouseBox.Height = 100;

                        if (_mouseBox.Width < 0)
                        {
                            _mouseBox.X = _mouseBox.X + _mouseBox.Width;
                            _mouseBox.Width = -_mouseBox.Width;
                        }

                        if (_mouseBox.Height < 0)
                        {
                            _mouseBox.Y = _mouseBox.Y + _mouseBox.Height;
                            _mouseBox.Height = -_mouseBox.Height;
                        }

                        _elementToAddWithMouse.Rectangle = ScreenToPaper(_mouseBox);

                        if (AddToLayout(_elementToAddWithMouse))
                        {
                            AddToSelection(_elementToAddWithMouse);
                        }

                        _elementToAddWithMouse = null;
                        _mouseMode = MouseMode.Default;
                        Invalidate();
                        break;

                    case MouseMode.PanMap:
                        _mouseMode = MouseMode.StartPanMap;
                        Cursor = Cursors.Default;
                        PanMap(_selectedLayoutElements[0] as LayoutMap, -_mouseBox.Width, -_mouseBox.Height);
                        break;

                    case MouseMode.Default:
                        break;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                switch (_mouseMode)
                {
                    case MouseMode.Default:
                        if (_selectedLayoutElements.Count < 1)
                        {
                            for (int i = 0; i < _contextMenuRight.MenuItems.Count; i++)
                            {
                                _contextMenuRight.MenuItems[i].Enabled = false;
                            }
                        }
                        else if (_selectedLayoutElements.Count == 1)
                        {
                            _cMnuSelAli.Enabled = false;
                            _cMnuSelFit.Enabled = false;
                        }

                        _contextMenuRight.Show(this, e.Location);

                        for (int i = 0; i < _contextMenuRight.MenuItems.Count; i++)
                        {
                            _contextMenuRight.MenuItems[i].Enabled = true;
                        }
                        break;
                }
            }
        }

        private void ResizeSelected(float deltaX, float deltaY)
        {
            _suppressElementInvalidation = true;

            var oldScreenRect = PaperToScreen(_selectedLayoutElements[0].Rectangle);
            oldScreenRect.Inflate(_inflate, _inflate);

            Invalidate(new Region(oldScreenRect));

            oldScreenRect = PaperToScreen(_selectedLayoutElements[0].Rectangle);

            switch (_resizeSelectedEdge)
            {
                case Edge.TopLeft:
                    oldScreenRect.X = oldScreenRect.X - deltaX;
                    oldScreenRect.Y = oldScreenRect.Y - deltaY;
                    oldScreenRect.Width = oldScreenRect.Width + deltaX;
                    oldScreenRect.Height = oldScreenRect.Height + deltaY;
                    break;
                case Edge.Top:
                    oldScreenRect.Y = oldScreenRect.Y - deltaY;
                    oldScreenRect.Height = oldScreenRect.Height + deltaY;
                    break;
                case Edge.TopRight:
                    oldScreenRect.Y = oldScreenRect.Y - deltaY;
                    oldScreenRect.Height = oldScreenRect.Height + deltaY;
                    oldScreenRect.Width = oldScreenRect.Width - deltaX;
                    break;
                case Edge.Right:
                    oldScreenRect.Width = oldScreenRect.Width - deltaX;
                    break;
                case Edge.BottomRight:
                    oldScreenRect.Width = oldScreenRect.Width - deltaX;
                    oldScreenRect.Height = oldScreenRect.Height - deltaY;
                    break;
                case Edge.Bottom:
                    oldScreenRect.Height = oldScreenRect.Height - deltaY;
                    break;
                case Edge.BottomLeft:
                    oldScreenRect.X = oldScreenRect.X - deltaX;
                    oldScreenRect.Width = oldScreenRect.Width + deltaX;
                    oldScreenRect.Height = oldScreenRect.Height - deltaY;
                    break;
                case Edge.Left:
                    oldScreenRect.X = oldScreenRect.X - deltaX;
                    oldScreenRect.Width = oldScreenRect.Width + deltaX;
                    break;
            }
            _selectedLayoutElements[0].Rectangle = ScreenToPaper(oldScreenRect);
            oldScreenRect.Inflate(_inflate, _inflate);

            Invalidate(new Region(oldScreenRect));

            Update();

            _suppressElementInvalidation = false;
        }
    }
}