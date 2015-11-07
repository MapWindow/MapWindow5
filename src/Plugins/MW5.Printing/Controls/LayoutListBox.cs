// -------------------------------------------------------------------------------------------
// <copyright file="LayoutListBox.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Printing.Controls.Layout;
using MW5.Plugins.Printing.Model.Elements;

namespace MW5.Plugins.Printing.Controls
{
    /// <summary>
    /// Representes UI for a list of layout elements.
    /// </summary>
    [ToolboxItem(true)]
    public partial class LayoutListBox : UserControl
    {
        private readonly Brush _highlightBrush;
        private LayoutControl _layoutControl; // better to wrap it in some way
        private bool _suppressSelectionChange;

        /// <summary>
        /// Creates a new instance of the Collection Control
        /// </summary>
        public LayoutListBox()
        {
            InitializeComponent();

            _highlightBrush = new SolidBrush(Color.FromArgb(64, 51, 153, 255));

            _listbox.DrawItem += ListboxDrawItem;
            _listbox.KeyUp += LayoutListBoxKeyUp;
        }

        /// <summary>
        /// Gets or sets the ZoomableLayoutControl
        /// </summary>
        [Browsable(false)]
        public LayoutControl LayoutControl
        {
            get { return _layoutControl; }
            set
            {
                if (value != null)
                {
                    _layoutControl = value;
                    RefreshList();
                }
            }
        }

        /// <summary>
        /// Refreshes the items in the list to accuratly reflect the current collection
        /// </summary>
        private void RefreshList()
        {
            _listbox.SuspendLayout();

            _listbox.Items.Clear();

            foreach (var le in _layoutControl.LayoutElements.ToArray())
            {
                _listbox.Items.Add(le);

                // the handler is removed on removing the element from layout control
                le.ThumbnailChanged += LeThumbnailChanged;
            }

            foreach (var le in _layoutControl.SelectedLayoutElements.ToArray())
            {
                _listbox.SelectedItems.Add(le);
            }

            _listbox.ResumeLayout();
        }

        public void UpdateSelectionFromMap()
        {
            if (_suppressSelectionChange) return;

            _suppressSelectionChange = true;

            RefreshList();

            _suppressSelectionChange = false;
        }

        private void LayoutListBoxKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    _layoutControl.DeleteSelected();
                    break;
                case Keys.F5:
                    _layoutControl.RefreshElements();
                    break;
            }
        }

        private void LeThumbnailChanged(object sender, EventArgs e)
        {
            _listbox.Invalidate();
        }

        private void ListboxDrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;

            var outer = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            Brush textBrush;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(_highlightBrush, outer);
                textBrush = Brushes.Black;
            }
            else
            {
                textBrush = Brushes.Black;
                e.Graphics.FillRectangle(Brushes.White, outer);
            }

            var thumbRect = new Rectangle(outer.X + 3, outer.Y + 3, 32, 32);
            e.Graphics.FillRectangle(Brushes.White, thumbRect);

            var element = _listbox.Items[e.Index] as LayoutElement;
            if (element != null && element.Thumbnail != null)
            {
                e.Graphics.DrawImage(element.Thumbnail, thumbRect);
            }

            thumbRect.X--;
            thumbRect.Y--;
            thumbRect.Width++;
            thumbRect.Height++;

            e.Graphics.DrawRectangle(Pens.Gray, thumbRect);
            var textRectangle = new Rectangle(outer.X + 40, outer.Y, outer.Width - 40, outer.Height);

            using (var drawFormat = new StringFormat())
            {
                drawFormat.Alignment = StringAlignment.Near;
                drawFormat.FormatFlags = StringFormatFlags.NoWrap;
                drawFormat.LineAlignment = StringAlignment.Center;
                drawFormat.Trimming = StringTrimming.EllipsisCharacter;

                if (element != null)
                {
                    string s = element.Name;
                    e.Graphics.DrawString(s, Font, textBrush, textRectangle, drawFormat);
                }
            }
        }

        private void OnListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressSelectionChange) return;

            _suppressSelectionChange = true;

            _layoutControl.SuspendLayout();
            _layoutControl.ClearSelection();
            _layoutControl.AddToSelection(new List<LayoutElement>(_listbox.SelectedItems.OfType<LayoutElement>()));
            _layoutControl.ResumeLayout();

            _suppressSelectionChange = false;
        }
    }
}