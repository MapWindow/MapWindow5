using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;

namespace MW5.UI.Menu.Classic
{
    internal class MenuStripSeparator : MenuItemBase, IMenuItem
    {
        private readonly ToolStripItem _item;

        public MenuStripSeparator(ToolStripItem item)
        {
            if (item == null) throw new ArgumentNullException("item");
            _item = item;

            Text = string.Empty;
            Icon = null;
            Category = string.Empty;
            Checked = false;
            Enabled = false;
            Visible = true;
        }

        /// <summary>
        /// Gets/Sets the Text shown for the MenuItem
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets/Sets the icon for the menu item
        /// </summary>
        public IMenuIcon Icon { get; set; }

        /// <summary>
        /// Gets/Sets the category for this item (used when the user customizes the menu)
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets/Sets the checked state of the item
        /// </summary>
        public bool Checked { get; set; }

        /// <summary>
        ///	Gets/Sets the enabled state of this item
        /// </summary>
        public bool Enabled { get; set; }

        public override bool HasKey
        {
            get { return false; }
        }

        /// <summary>
        /// Gets/Sets the visibility state of this item
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Gets the internal object.
        /// </summary>
        public object GetInternalObject()
        {
            return _item;
        }

        public event EventHandler<MenuItemEventArgs> ItemClicked
        {
            add
            {
                // just ignore it
            }
            remove
            {
                // just ignore it
            }
        }

        /// <summary>
        /// Gets a value indicating whether the item should be skipped during processing (e.g. separator).
        /// </summary>
        public bool Skip
        {
            get { return true; }
        }

        /// <summary>
        /// Gets or sets the shortcut keys.
        /// </summary>
        public Keys ShortcutKeys { get; set; }

        protected override MenuItemMetadata Metadata
        {
            get { return null; }
        }
    }
}
