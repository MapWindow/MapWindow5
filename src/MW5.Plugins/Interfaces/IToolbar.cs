using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Interfaces
{
    public interface IToolbar
    {
        /// <summary>
        /// Adds a new toolbar
        /// </summary>
        /// <param name="name">The name o the toolbar</param>
        /// <returns>True on success.</returns>
        bool AddToolbar(string name);

        /// <summary>
        /// Adds a button to a specified to the default Toolbar
        /// </summary>
        /// <param name="name">The name to give to the new ToolbarButton</param>
        IMenuItem AddButton(string name);

        ///// <summary>
        ///// Adds a button to a specified to the default Toolbar
        ///// </summary>
        ///// <param name="name">The name to give to the new ToolbarButton</param>
        ///// <param name="isDropDown">Should this button support drop-down items?</param>
        //IMenuItem AddButton(string name, bool isDropDown);

        ///// <summary>
        ///// Adds a button to a specified to the default Toolbar
        ///// </summary>
        ///// <param name="name">The name to give to the new ToolbarButton</param>
        ///// /// <param name="toolbar">The name of the Toolbar to which this ToolbarButton should belong (if null or empty, then the default Toolbar will be used</param>
        ///// <param name="isDropDown">Should this button support drop-down items?</param>
        //IMenuItem AddButton(string name, string toolbar, bool isDropDown);

        ///// <summary>
        ///// Adds a separator to a toolstrip dropdown button.
        ///// </summary>
        ///// <param name="name">The name to give to the new separator.</param>
        ///// <param name="parentButton">The name of the ToolbarButton to which this new separator should be added as a subitem</param>
        ///// <param name="toolbar">The name of the Toolbar to which this separator should belong (if null or empty, then the default Toolbar will be used</param>
        //void AddButtonDropDownSeparator(string name, string toolbar, string parentButton);

        ///// <summary>
        ///// Adds a button to a specified to the default Toolbar
        ///// </summary>
        ///// <param name="name">The name to give to the new ToolbarButton</param>
        ///// <param name="picture">The Icon/Bitmap to use as a picture on the ToolbarButton face</param>
        //IMenuItem AddButton(string name, object picture);

        ///// <summary>
        ///// Adds a button to a specified to the default Toolbar
        ///// </summary>
        ///// <param name="name">The name to give to the new ToolbarButton</param>
        ///// <param name="picture">The Icon/Bitmap to use as a picture on the ToolbarButton face</param>
        ///// <param name="text">The text name for the ToolbarButton.  This is the text the user will see if customizing the Toolbar</param>
        //IMenuItem AddButton(string name, object picture, string text);

        ///// <summary>
        ///// Adds a button to a specified to the specified Toolbar
        ///// </summary>
        ///// <param name="name">The name to give to the new ToolbarButton</param>
        ///// <param name="after">The name of the ToolbarButton after which this new ToolbarButton should be added</param>
        ///// <param name="parentButton">The name of the ToolbarButton to which this new ToolbarButton should be added as a subitem</param>
        ///// <param name="toolbar">The name of the Toolbar to which this ToolbarButton should belong (if null or empty, then the default Toolbar will be used</param>
        //IMenuItem AddButton(string name, string toolbar, string parentButton, string after);

        ///// <summary>
        ///// Adds a ComboBoxItem to a specified to the default Toolbar
        ///// </summary>
        ///// <param name="name">The name to give to the new ComboBoxItem</param>
        ///// <param name="after">The name of the ToolbarButton/ComboBoxItem afterwhich this new item should be added</param>
        ///// <param name="toolbar">The name of the Toolbar to which this ToolbarButton should belong</param>
        //IComboBoxItem AddComboBox(string name, string toolbar, string after);

        ///// <summary>
        ///// returns the specified ToolbarButton (null on failure)
        ///// </summary>
        ///// <param name="name">The name of the ToolbarButton to retrieve</param>
        //IMenuItem ButtonItem(string name);

        ///// <summary>
        ///// returns the specified ComboBoxItem
        ///// </summary>
        ///// <param name="name">Name of the item to retrieve</param>
        //IComboBoxItem ComboBoxItem(string name);

        ///// <summary>
        ///// Removes the specified Toolbar and any ToolbarButton/ComboBoxItems contained within the control
        ///// </summary>
        ///// <param name="name">The name of the Toolbar to be removed</param>
        ///// <returns>true on success, false on failure</returns>
        //bool RemoveToolbar(string name);

        ///// <summary>
        ///// Removes all currently loaded toolbars
        ///// </summary>
        ///// <returns>true on success, false on failure</returns>
        ///// <remarks>Added by Paul Meems on May 4, 2011</remarks>
        //bool RemoveAllToolbars();

        ///// <summary>
        ///// Get the currently loaded toolbar names
        ///// </summary>
        ///// <returns>A list of the names</returns>
        ///// <remarks>Added by Paul Meems on May 4, 2011</remarks>
        //IList<string> ToolbarNames();

        ///// <summary>
        ///// Removes the specified ToolbarButton item
        ///// </summary>
        ///// <param name="name">The name of the ToolbarButton to be removed</param>
        ///// <returns>true on success, false on failure</returns>
        //bool RemoveButton(string name);

        ///// <summary>
        ///// Removes the specified ComboBoxItem
        ///// </summary>
        ///// <param name="name">The name of the ComboBoxItem to be removed</param>
        ///// <returns>true on success, false on failure</returns>
        //bool RemoveComboBox(string name);

        ///// <summary>
        ///// Returns the number of buttons on the specified toolbar, or 0 if the toolbar can't be found.
        ///// </summary>
        ///// <param name="toolbarName">The name of the toolbar.</param>
        ///// <returns>The number of buttons on the toolbar.</returns>
        //int NumToolbarButtons(string toolbarName);

        ///// <summary>
        ///// Presses the specified ToolBar button (if it's enabled) as if a user
        ///// had pressed it.
        ///// </summary>
        ///// <param name="name">The name of the toolbar button to press.</param>
        ///// <returns>true on success, false on failure (i.e. bad toolbar button name)</returns>
        //bool PressToolbarButton(string name);

        //// Start Paul Meems, June 1, 2010

        ///// <summary>
        ///// Presses the specified ToolBar button (if it's enabled) as if a user
        ///// had pressed it.
        ///// </summary>
        ///// <param name="toolbarName">The name of the toolbar the button is on.</param>
        ///// <param name="buttonName">The name of the toolbar button to press.</param>
        ///// <returns>true on success, false on failure (i.e. bad toolbar button name)</returns>
        //bool PressToolbarButton(string toolbarName, string buttonName);
    }
}
