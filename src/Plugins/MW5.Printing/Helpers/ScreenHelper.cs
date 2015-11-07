// -------------------------------------------------------------------------------------------
// <copyright file="ScreenHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

namespace MW5.Plugins.Printing.Helpers
{
    internal static class ScreenHelper
    {
        private static float _screenDpi = 96f;

        public static float LogicDpi
        {
            get { return 100f; }
        }

        public static float ScreenDpi
        {
            get { return _screenDpi; }
            set { _screenDpi = value; }
        }

        public static float LogicTo96Dpi
        {
            get { return 96 / LogicDpi; }
        }

        public static float LogicToScreenDpi
        {
            get { return ScreenDpi / LogicDpi; }
        }

        public static float ScreenToLogicDpi
        {
            get { return LogicDpi / ScreenDpi; }
        }
    }
}