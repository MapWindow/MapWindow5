using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Menu
{
    internal static class StatusBarKeys
    {
        public const string ProjectionDropDown = "statusProjectionDropDown";
        public const string ChooseProjection = "statusChooseProjection";
        public const string ProjectionProperties = "statusProjectionProperties";
        public const string ProjectionConfig = "statusProjectionConfig";
        public const string SelectedCount = "statusSelectedCount";
        public const string ModifiedCount = "statusModifiedCount";
        public const string MapUnits = "statusMapUnits";

        public const string TileProvider = "statusTileProvider";
        public const string ProgressMsg = "statusProgressMsg";
        public const string ProgressBar = "statusProgressBar";

        public const string MapScale = "statusMapScale";

        public static string GetStatusItemName(string key)
        {
            switch (key)
            {
                case ProjectionDropDown:
                    return "Coordinate System and Projection";
                case TileProvider:
                    return "Base Layer";
                case MapScale:
                    return "Map Scale";
                case MapUnits:
                    return "Map Units";
            }

            return key;
        }
    }
}
