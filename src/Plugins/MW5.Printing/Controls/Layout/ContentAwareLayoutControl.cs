// -------------------------------------------------------------------------------------------
// <copyright file="ContentAwareLayoutControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Printing.Helpers;
using MW5.Plugins.Printing.Legacy;
using MW5.Plugins.Printing.Model;
using MW5.Plugins.Printing.Model.Elements;
using MW5.Plugins.Printing.Properties;
using MW5.Plugins.Printing.Services;
using MW5.Plugins.Services;
using MW5.Shared;

namespace MW5.Plugins.Printing.Controls.Layout
{
    public class ContentAwareLayoutControl : ScreenAwareLayoutControl
    {
        private string _filename;
        protected bool _suppressElementInvalidation;

        public ContentAwareLayoutControl()
        {
            _filename = string.Empty;
            _suppressElementInvalidation = false;
        }

        /// <summary>
        /// This fires after a element if added or removed
        /// </summary>
        public event EventHandler ElementsChanged;

        /// <summary>
        /// This fires when the projects file name is changed
        /// </summary>
        public event EventHandler FilenameChanged;

        /// <summary>
        /// Fires when new element is added to the control by user.
        /// </summary>
        public event EventHandler<LayoutElementEventArgs> NewElement;

        /// <summary>
        /// This fires after the selection has changed
        /// </summary>
        public event EventHandler SelectionChanged;

        /// <summary>
        /// Gets or sets the fileName of the current project
        /// </summary>
        public string Filename
        {
            get { return _filename; }
            set
            {
                _filename = value;
                OnFilenameChanged(null);
            }
        }

        /// <summary>
        /// Gets the list of layoutElements currently selected in the project
        /// </summary>
        internal List<LayoutElement> SelectedLayoutElements
        {
            get { return _selectedLayoutElements; }
        }

        /// <summary>
        /// Adds a layout element to the layout
        /// </summary>
        public bool AddToLayout(LayoutElement le)
        {
            SetUniqueElementName(le);

            var args = new LayoutElementEventArgs(le) { Cancel = false };
            DelegateHelper.FireEvent(this, NewElement, args);

            if (args.Cancel)
            {
                return false;
            }

            _layoutElements.Insert(0, le);

            FireElementsChanged();

            le.Invalidated += LeInvalidated;
            Invalidate(new Region(PaperToScreen(le.Rectangle)));

            return true;
        }

        /// <summary>
        /// Converts all of the selected layout elements to bitmaps
        /// </summary>
        public virtual void ConvertSelectedToBitmap()
        {
            // TODO: extact from control
            foreach (var le in _selectedLayoutElements.ToArray())
            {
                if (le is LayoutBitmap) continue;

                string filename = FileDialogHelper.GetBitmapFilename(le.Name, this);
                if (!string.IsNullOrWhiteSpace(filename))
                {
                    ConvertElementToBitmap(le, filename);
                }
            }
        }

        /// <summary>
        /// Deletes all of the selected elements from the model
        /// </summary>
        public void DeleteSelected()
        {
            // TODO: extract prompt from control
            if (MessageService.Current.Ask("Remove selected elements: " + _selectedLayoutElements.Count + "?"))
            {
                foreach (var le in _selectedLayoutElements.ToArray())
                {
                    RemoveFromLayout(le);
                }

                Invalidate();
                OnSelectionChanged(null);
            }
        }

        /// <summary>
        /// Inverts the selection
        /// </summary>
        public void InvertSelection()
        {
            var unselected = _layoutElements.FindAll(o => !_selectedLayoutElements.Contains(o));
            _selectedLayoutElements.Clear();
            _selectedLayoutElements.InsertRange(0, unselected);
            OnSelectionChanged(null);
            Invalidate();
        }

        /// <summary>
        /// Moves the selection down by one
        /// </summary>
        public void MoveSelectionDown()
        {
            if (_selectedLayoutElements.Count < 1) return;

            int index = 0;
            var indexArray = new int[_selectedLayoutElements.Count];

            for (int i = 0; i < _selectedLayoutElements.Count; i++)
            {
                indexArray[i] = _layoutElements.IndexOf(_selectedLayoutElements[i]);
                if (index < indexArray[i]) index = indexArray[i];
            }

            if (index == _layoutElements.Count - 1) return;

            for (int i = 0; i < _selectedLayoutElements.Count; i++)
            {
                _layoutElements.Remove(_selectedLayoutElements[i]);
            }

            for (int i = 0; i < _selectedLayoutElements.Count; i++)
            {
                _layoutElements.Insert(indexArray[i] + 1, _selectedLayoutElements[i]);
            }

            OnSelectionChanged(null);
            Invalidate();
        }

        /// <summary>
        /// Moves the selection up by one
        /// </summary>
        public void MoveSelectionUp()
        {
            if (_selectedLayoutElements.Count < 1) return;
            int index = _layoutElements.Count - 1;

            foreach (var le in _selectedLayoutElements)
            {
                if (index > _layoutElements.IndexOf(le)) index = _layoutElements.IndexOf(le);
            }

            if (index == 0) return;

            foreach (var le in _selectedLayoutElements)
            {
                index = _layoutElements.IndexOf(le);
                _layoutElements.Remove(le);
                _layoutElements.Insert(index - 1, le);
            }

            OnSelectionChanged(null);
            Invalidate();
        }

        /// <summary>
        /// Refreshes all of the elements in the layout
        /// </summary>
        public void RefreshElements()
        {
            _suppressElementInvalidation = true;

            foreach (var le in _layoutElements)
            {
                le.RefreshElement();
            }

            _suppressElementInvalidation = false;

            Invalidate();
        }

        /// <summary>
        /// Selects All the elements in the layout
        /// </summary>
        public void SelectAll()
        {
            _selectedLayoutElements.Clear();
            _selectedLayoutElements.InsertRange(0, _layoutElements);

            OnSelectionChanged(null);
            Invalidate();
        }

        /// <summary>
        /// Converts a selected layout element into a bitmap and saves it a the specified 
        /// location removing the old element and replacing it
        /// </summary>
        protected virtual void ConvertElementToBitmap(LayoutElement le, string fileName)
        {
            var newLb = LayoutHelper.ConvertElementToBitmap(le, fileName);
            if (newLb == null) return;

            _layoutElements.Insert(_layoutElements.IndexOf(le), newLb);
            _layoutElements.Remove(le);

            _selectedLayoutElements.Insert(_selectedLayoutElements.IndexOf(le), newLb);
            _selectedLayoutElements.Remove(le);

            OnSelectionChanged(null);
            Invalidate();
        }

        /// <summary>
        /// Call this to indicate elements were added or removed
        /// </summary>
        protected void FireElementsChanged()
        {
            var handler = ElementsChanged;
            if (handler != null)
            {
                ElementsChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Call this to indicate the selection has changed
        /// </summary>
        /// <param name="e"></param>
        protected void OnSelectionChanged(EventArgs e)
        {
            // TODO: implement

            //if (_layoutMapToolStrip != null)
            //{
            //    if (_selectedLayoutElements.Count == 1 && _selectedLayoutElements[0] is LayoutMap)
            //    {
            //        _layoutMapToolStrip.Enabled = true;
            //    }
            //    else
            //    {
            //        _layoutMapToolStrip.Enabled = false;

            //        if (_mouseMode == MouseMode.StartPanMap || _mouseMode == MouseMode.PanMap)
            //        {
            //            _mouseMode = MouseMode.Default;
            //        }
            //    }
            //}

            //_layoutListBox.UpdateSelectionFromMap();

            if (SelectionChanged != null) SelectionChanged(this, e);
        }

        /// <summary>
        /// Adds the specified LayoutElement le to the selection
        /// </summary>
        internal void AddToSelection(LayoutElement le)
        {
            _selectedLayoutElements.Add(le);
            Invalidate(new Region(PaperToScreen(le.Rectangle)));
            OnSelectionChanged(null);
        }

        /// <summary>
        /// Adds the specified LayoutElement le to the selection
        /// </summary>
        internal void AddToSelection(List<LayoutElement> le)
        {
            _selectedLayoutElements.AddRange(le);
            Invalidate();
            OnSelectionChanged(null);
        }

        /// <summary>
        /// Clears the the layout of all layoutElements
        /// </summary>
        internal void ClearLayout()
        {
            DisposeElements();
            _selectedLayoutElements.Clear();
            OnSelectionChanged(null);
            _layoutElements.Clear();
            FireElementsChanged();
            Invalidate();
        }

        /// <summary>
        /// Clears the current selection
        /// </summary>
        internal void ClearSelection()
        {
            _selectedLayoutElements.Clear();
            Invalidate();
            OnSelectionChanged(null);
        }

        internal void ExportToBitmap()
        {
            LayoutPrint.ExportToBitmap(_pages, _pages.PageWidth, _pages.PageHeight, LayoutElements);
        }

        /// <summary>
        /// This gets fired when one of the layoutElements gets invalidated
        /// </summary>
        internal void LeInvalidated(object sender, EventArgs e)
        {
            if (_suppressElementInvalidation) return;
            Invalidate();
        }

        /// <summary>
        /// Removes the specified layoutElement from the selection
        /// </summary>
        internal void RemoveFromSelection(LayoutElement le)
        {
            _selectedLayoutElements.Remove(le);
            Invalidate(new Region(PaperToScreen(le.Rectangle)));
            OnSelectionChanged(null);
        }

        private void DisposeElements()
        {
            foreach (var el in _layoutElements.OfType<LayoutBitmap>())
            {
                el.Dispose();
            }
        }

        /// <summary>
        /// Calls this to indicate the fileName has been changed
        /// </summary>
        /// <param name="e"></param>
        private void OnFilenameChanged(EventArgs e)
        {
            if (FilenameChanged != null) FilenameChanged(this, e);
        }

        /// <summary>
        /// Removes the specified layoutElement from the layout
        /// </summary>
        /// <param name="le"></param>
        private void RemoveFromLayout(LayoutElement le)
        {
            _selectedLayoutElements.Remove(le);
            OnSelectionChanged(null);
            _layoutElements.Remove(le);
            FireElementsChanged();
            Invalidate(new Region(PaperToScreen(le.Rectangle)));
        }

        private void SetUniqueElementName(LayoutElement le)
        {
            // TODO: extract
            string leName = le.Name + " 1";
            int i = 2;

            while (_layoutElements.FindAll(o => o.Name == leName).Count > 0)
            {
                leName = le.Name + " " + i;
                i++;
            }

            le.Name = leName;
        }
    }
}