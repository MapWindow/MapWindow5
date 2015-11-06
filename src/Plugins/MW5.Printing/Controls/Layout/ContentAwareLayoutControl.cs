// -------------------------------------------------------------------------------------------
// <copyright file="ContentAwareLayoutControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    [ToolboxItem(false)]
    public class ContentAwareLayoutControl : ScreenAwareLayoutControl
    {
        private string _filename;
        protected bool _suppressElementInvalidation;

        protected ContentAwareLayoutControl()
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
        protected bool AddToLayout(LayoutElement le)
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
        /// Deletes all of the selected elements from the model
        /// </summary>
        public void DeleteSelected()
        {
            if (MessageService.Current.Ask("Remove selected elements: " + _selectedLayoutElements.Count + "?"))
            {
                foreach (var le in _selectedLayoutElements.ToArray())
                {
                    RemoveFromLayout(le);
                }

                Invalidate();
                FireSelectionChanged();
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
            FireSelectionChanged();
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

            FireSelectionChanged();
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

            FireSelectionChanged();
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

            FireSelectionChanged();
            Invalidate();
        }

        /// <summary>
        /// Converts a selected layout element into a bitmap and saves it a the specified 
        /// location removing the old element and replacing it
        /// </summary>
        public void ConvertElementToBitmap(LayoutElement le, string fileName)
        {
            var newLb = LayoutHelper.ConvertElementToBitmap(le, fileName);
            if (newLb == null) return;

            _layoutElements.Insert(_layoutElements.IndexOf(le), newLb);
            _layoutElements.Remove(le);

            _selectedLayoutElements.Insert(_selectedLayoutElements.IndexOf(le), newLb);
            _selectedLayoutElements.Remove(le);

            FireSelectionChanged();
            Invalidate();
        }

        /// <summary>
        /// Call this to indicate elements were added or removed
        /// </summary>
        protected void FireElementsChanged()
        {
            DelegateHelper.FireEvent(this, ElementsChanged);
        }

        protected void FireSelectionChanged()
        {
            DelegateHelper.FireEvent(this, SelectionChanged);
        }

        /// <summary>
        /// Adds the specified LayoutElement le to the selection
        /// </summary>
        internal void AddToSelection(LayoutElement le)
        {
            _selectedLayoutElements.Add(le);
            Invalidate(new Region(PaperToScreen(le.Rectangle)));
            FireSelectionChanged();
        }

        /// <summary>
        /// Adds the specified LayoutElement le to the selection
        /// </summary>
        internal void AddToSelection(List<LayoutElement> le)
        {
            _selectedLayoutElements.AddRange(le);
            Invalidate();
            FireSelectionChanged();
        }

        /// <summary>
        /// Clears the the layout of all layoutElements
        /// </summary>
        internal void ClearLayout()
        {
            DisposeElements();
            _selectedLayoutElements.Clear();
            FireSelectionChanged();
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
            FireSelectionChanged();
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
            FireSelectionChanged();
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
            FireSelectionChanged();
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