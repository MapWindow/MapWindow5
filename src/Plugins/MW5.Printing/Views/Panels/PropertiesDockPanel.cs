// -------------------------------------------------------------------------------------------
// <copyright file="PropertiesDockPanel.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Windows.Forms;
using MW5.Plugins.Printing.Controls.Layout;
using MW5.Shared;

namespace MW5.Plugins.Printing.Views.Panels
{
    /// <summary>
    /// This is a control that allows users to easilly modify the various aspects of many different layout components
    /// </summary>
    [ToolboxItem(true)]
    public partial class PropertiesDockPanel : UserControl
    {
        /// <summary>
        /// Creates a new instance of the Layout Property Grid
        /// </summary>
        public PropertiesDockPanel()
        {
            InitializeComponent();

            _propertyGrid.PropertySort = PropertySort.CategorizedAlphabetical;

            RefreshControls();
        }

        /// <summary>
        /// Gets or sets the layout control associated with this property grid
        /// </summary>
        [Browsable(false)]
        public LayoutControl LayoutControl
        {
            get { return _layoutControl; }
            set
            {
                _layoutControl = value;
                if (_layoutControl != null)
                {
                    _layoutControl.SelectionChanged += LayoutControlSelectionChanged;
                }
            }
        }

        /// <summary>
        /// If the selection changes this event is called
        /// </summary>
        private void LayoutControlSelectionChanged(object sender, EventArgs e)
        {
            foreach (var selecteElement in _layoutControl.LayoutElements)
            {
                selecteElement.Invalidated -= SelecteElementInvalidated;
            }

            foreach (var selecteElement in _layoutControl.SelectedLayoutElements)
            {
                selecteElement.Invalidated += SelecteElementInvalidated;
            }

            //If there is no selection get the layoutControls properties otherwise show the selected elements properties
            object[] objects = _layoutControl.SelectedLayoutElements.ToArray();
            _propertyGrid.SelectedObjects = _layoutControl.SelectedLayoutElements.Count > 0 ? objects : null;
        }

        private void LayoutPropertyGridKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    _layoutControl.DeleteSelected();
                    break;
                case Keys.F5:
                    _layoutControl.RefreshElements();
                    break;
                default:
                    break;
            }
        }

        private void OnGroupClick(object sender, EventArgs e)
        {
            bool categorized = _propertyGrid.PropertySort == PropertySort.CategorizedAlphabetical;
            _propertyGrid.PropertySort = categorized ? PropertySort.Alphabetical : PropertySort.CategorizedAlphabetical;

            RefreshControls();
        }

        private void RefreshControls()
        {
            bool categorized = _propertyGrid.PropertySort == PropertySort.CategorizedAlphabetical;
            toolGroup.Checked = categorized;
        }

        private void SelecteElementInvalidated(object sender, EventArgs e)
        {
            //If there is no selection get the layoutControls properties otherwise show the selected elements properties
            _propertyGrid.SafeInvoke(() => _propertyGrid.Refresh());
        }
    }
}