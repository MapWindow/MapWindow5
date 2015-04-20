namespace MW5.Api.Legend
{
    internal class Constants
    {
        public const int ItemHeight = 18;
        public const int ItemPad = 4;
        public const int ItemRightPad = 5;
        // TEXT
        public const int TextHeight = 14;
        public const int TextTopPad = 3;
        public const int TextLeftPad = 30;
        public const int TextRightPad = 25;
        public const int TextRightPadNoIcon = 8;
        // CHECK BOX
        public const int CheckTopPad = 4;
        public const int CheckBoxSize = 12;
        // EXPANSION BOX
        public const int ExpandBoxTopPad = 5;
        public const int ExpandBoxLeftPad = 3;
        public const int ExpandBoxSize = 8;
        // LIST ITEMS
        public const int ListItemIndent = 18;
        public const int IconRightPad = 25;
        public const int IconTopPad = 3;
        public const int IconSize = 13;
        public const int VertLineGrpTopOffset = 14;
        // COLOR SCHEME CONSTANTS
        public const int CsItemHeight = 14;
        public const int CsTopPad = 1;
        public const int CsPatchHeight = 12;
        public const int CsTextTopPad = 3;
        // SCROLLBAR
        public const int ScrollWidth = 15;
        // MISC
        // DROP_TOLERANCE 4
        public const int InvalidIndex = -1;
        // constants for the new symbology
        public const int IconWidth = 24;
        public const int IconHeight = 13;
        // Visual Basic Related constants
        public const int VbShiftButton = 1;
        public const int VbLeftButton = 1;
        public const int VbRightButton = 2;
        public const int CheckLeftPad = 15;
        // GROUP
        public const int GrpIndent = 3;
        // CONNECTION LINES FROM GROUPS TO SUB ITEMS
        public const int VertLineIndent = GrpIndent + 7;
        public const int CsPatchWidth = 15;
        public const int CsPatchLeftIndent = CheckLeftPad;
        public const int CsTextLeftIndent = CsPatchLeftIndent + CsPatchWidth + 3;

        public const int VerticalPad = 2;

        public static int ItemHeightAndPad()
        {
            return ItemHeight + VerticalPad;
        }

        public static int CsItemHeightAndPad()
        {
            return CsItemHeight + VerticalPad;
        }
    }
}