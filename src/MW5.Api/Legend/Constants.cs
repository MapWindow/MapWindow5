using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Api.Legend
{
    internal class Constants
    {
        public static int ITEM_HEIGHT = 18;
        public static int ITEM_PAD = 4;
        public static int ITEM_RIGHT_PAD = 5;
        //  TEXT
        public static int TEXT_HEIGHT = 14;
        public static int TEXT_TOP_PAD = 3;
        public static int TEXT_LEFT_PAD = 30;
        public static int TEXT_RIGHT_PAD = 25;
        public static int TEXT_RIGHT_PAD_NO_ICON = 8;
        //  CHECK BOX
        public static int CHECK_TOP_PAD = 4;
        public static int CHECK_LEFT_PAD = 15;
        public static int CHECK_BOX_SIZE = 12;
        //  EXPANSION BOX
        public static int EXPAND_BOX_TOP_PAD = 5;
        public static int EXPAND_BOX_LEFT_PAD = 3;
        public static int EXPAND_BOX_SIZE = 8;
        //  GROUP
        public static int GRP_INDENT = 3;
        //	LIST ITEMS
        public static int LIST_ITEM_INDENT = 18;
        public static int ICON_RIGHT_PAD = 25;
        public static int ICON_TOP_PAD = 3;
        public static int ICON_SIZE = 13;

        //	CONNECTION LINES FROM GROUPS TO SUB ITEMS
        public static int VERT_LINE_INDENT = (GRP_INDENT + 7);
        public static int VERT_LINE_GRP_TOP_OFFSET = 14;
        //	COLOR SCHEME CONSTANTS
        public static int CS_ITEM_HEIGHT = 14;
        public static int CS_TOP_PAD = 1;
        public static int CS_PATCH_WIDTH = 15;
        public static int CS_PATCH_HEIGHT = 12;
        public static int CS_PATCH_LEFT_INDENT = (CHECK_LEFT_PAD);
        public static int CS_TEXT_LEFT_INDENT = (CS_PATCH_LEFT_INDENT + CS_PATCH_WIDTH + 3);
        public static int CS_TEXT_TOP_PAD = 3;
        //	SCROLLBAR
        public static int SCROLL_WIDTH = 15;
        //	MISC
        // DROP_TOLERANCE 4

        public static int INVALID_INDEX = -1;

        // constants for the new symbology
        public static int ICON_WIDTH = 24;
        public static int ICON_HEIGHT = 13;

        //*******************************************************
        //Visual Basic Related constants
        //*******************************************************
        public static int VB_SHIFT_BUTTON = 1;
        public static int VB_LEFT_BUTTON = 1;
        public static int VB_RIGHT_BUTTON = 2;
    }
}
