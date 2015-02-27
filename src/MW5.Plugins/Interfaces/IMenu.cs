using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Interfaces
{
    public interface IMenu
    {
        IMenuItemCollection Items { get; }

        IDropDownMenuItem Plugins { get; }

        /// <summary>
        /// Removes a MenuItem
        /// </summary>
        /// <param name="name">Name of the item to remove</param>
        /// <returns>true on success, false otherwise</returns>
        //bool Remove(string name);

        ///// <summary>
        ///// Adds a menu with the specified name
        ///// </summary>
        //IMenuItem AddMenu(string name);

        ///// <summary>
        ///// Adds a menu with the specified name and icon
        ///// </summary>
        //IMenuItem AddMenu(string name, IMenuIcon picture);

        ///// <summary>
        ///// Adds a menu with the specified name, icon and text
        ///// </summary>
        //IMenuItem AddMenu(string name, IMenuIcon picture, string text);

        ///// <summary>
        ///// Adds a menu with the specified name to the menu indicated by ParentMenu
        ///// </summary>
        //IMenuItem AddMenu(string name, string parentMenu);

        ///// <summary>
        ///// Adds a menu with the specified name and icon to the menu indicated by ParentMenu
        ///// </summary>
        //IMenuItem AddMenu(string name, string parentMenu, IMenuIcon picture);

        ///// <summary>
        ///// Adds a menu with the specified name, icon and text to the specified ParentMenu
        ///// </summary>
        //IMenuItem AddMenu(string name, string parentMenu, IMenuIcon picture, string text);

        ///// <summary>
        ///// Adds a menu with the specified name, icon and text to the specified ParentMenu and after the specifed item
        ///// </summary>
        //IMenuItem AddMenu(string name, string parentMenu, IMenuIcon picture, string text, string relative,
        //    bool after = true);
        
        //// <summary>
        //// Gets a MenuItem by its name
        //// </summary>
        //IMenuItem this[string menuName] { get; }
       
    }
}
