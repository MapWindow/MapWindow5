using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;

namespace MW5.Plugins.Interfaces
{
    public interface IMenuItem
    {
        /// <summary>
        /// Gets/Sets the Text shown for the MenuItem
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// Gets/Sets the icon for the menu item
        /// </summary>
        IMenuIcon Picture { get; set; }

        /// <summary>
        /// Gets/Sets the category for this item (used when the user customizes the menu)
        /// </summary>
        string Category { get; set; }

        /// <summary>
        /// Gets/Sets the checked state of the item
        /// </summary>
        bool Checked { get; set; }

        /// <summary>
        /// Gets/Sets the tool tip text that will pop up for the item when a mouse over event occurs
        /// </summary>
        string Tooltip { get; set; }

        /// <summary>
        /// Gets/Sets the description of this menu item, used in customization of menu by the user
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets/Sets the Displayed state of this item
        /// </summary>
        bool Displayed { get; set; }

        /// <summary>
        ///	Gets/Sets the enabled state of this item
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        /// Gets the Name of this item
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets/Sets the visibility state of this item
        /// </summary>
        bool Visible { get; set; }

        object Tag { get; set; }

        // TODO: hide from plugins
        event EventHandler Click;

        object GetInternalObject();
    }
}
