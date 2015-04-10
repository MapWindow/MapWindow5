using System.Drawing;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI.Helpers
{
    internal static class CommandBarHelper
    {
        public static void InitMenuColors()
        {
            MenuColors.CommandBarBackColor = Color.White;
            MenuColors.MainMenuBackColor = Color.White;
            MenuColors.StatusBarBackColor = Color.White;
        }

        // unfortunately there is no easy way to do it with generics
        // http ://journal.stuffwithstuff.com/2008/03/05/checking-flags-in-c-enums/
        public static bool FlagIsSet(BarStyle style, BarStyle flag)
        {
            return (style & flag) == flag;
        }
    }
}
