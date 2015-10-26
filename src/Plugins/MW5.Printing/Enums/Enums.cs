// -------------------------------------------------------------------------------------------
// <copyright file="Enums.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

namespace MW5.Plugins.Printing.Enums
{
    /// <summary>
    /// An enumeration that defines the Mouses current behavior
    /// </summary>
    public enum MouseMode
    {
        /// <summary>
        /// The cursor is currently in default mode
        /// </summary>
        Default,

        /// <summary>
        /// The cursor is currently being used to create a new selection
        /// </summary>
        CreateSelection,

        /// <summary>
        /// The cursor is currently is move selection mode
        /// </summary>
        MoveSelection,

        /// <summary>
        /// The cursor is in resize mode because its over the edge of a selected item
        /// </summary>
        ResizeSelected,

        /// <summary>
        /// When in this mode the user can click on the map select an area and an element is inserted at that spot
        /// </summary>
        InsertNewElement,

        /// <summary>
        /// In this mode a cross hair is shown letting the user create a new Insert rectangle
        /// </summary>
        StartInsertNewElement,

        /// <summary>
        /// Puts the mouse into a mode that allows map panning
        /// </summary>
        StartPanMap,

        /// <summary>
        /// The mouse is actually panning a map
        /// </summary>
        PanMap
    }

    /// <summary>
    /// Enumerates all the possible resize direction
    /// </summary>
    internal enum Edge
    {
        None,

        TopLeft,

        Top,

        TopRight,

        Right,

        BottomRight,

        Bottom,

        BottomLeft,

        Left,
    }

    /// <summary>
    /// Enumarates the different ways that a a LayoutElement can handle resize events
    /// </summary>
    public enum ResizeStyle
    {
        /// <summary>
        /// The resize style is determined automatically
        /// </summary>
        HandledInternally,

        /// <summary>
        /// The element is adjusted to fit the extents even if it is distorted
        /// </summary>
        StretchToFit,

        /// <summary>
        /// No scaling occurs whatsoever, and the element is drawn at its original size
        /// </summary>
        NoScaling
    }

    /// <summary>
    /// An enumeration of alignments used for aligning selected layout elements
    /// </summary>
    public enum Alignment
    {
        /// <summary>
        /// Left
        /// </summary>
        Left,

        /// <summary>
        /// Right
        /// </summary>
        Right,

        /// <summary>
        /// Top
        /// </summary>
        Top,

        /// <summary>
        /// Bottom
        /// </summary>
        Bottom,

        /// <summary>
        /// Horizontal
        /// </summary>
        Horizontal,

        /// <summary>
        /// Vertical
        /// </summary>
        Vertical
    }

    /// <summary>
    /// An enumeration of resizing options used for aligning selected layout elements
    /// </summary>
    public enum Fit
    {
        /// <summary>
        /// Width
        /// </summary>
        Width,

        /// <summary>
        /// Height
        /// </summary>
        Height
    }

    public enum PrintQuality
    {
        High = 2,
        Medium = 1,
        Low = 0
    }

    public enum ElementType
    {
        Map = 0,
        Label = 1,
        Legend = 2,
        NorthArrow = 3,
        Scale = 4,
        Table = 5,
        Bitmap = 6,
        Rectangle = 7
    }

    public enum PrintArea
    {
        WholeMap = 0,
        CurrentScreen = 1,
        Selection = 2,
    }

    public enum PaperFormat
    {
        A0 = 0,
        A1 = 1,
        A2 = 2,
        A3 = 3,
        A4 = 4,
        A5 = 5,
    }

    public enum ElementsCommand
    {
        MoveUp = 0,
        MoveDown = 1,
        Remove = 3
    }

    /// <summary>
    /// An enumeration listing the different built in styles for the north arrow
    /// </summary>
    public enum NorthArrowStyle
    {
        /// <summary>
        /// A four point triangle with a circle in the middle and the letter N
        /// </summary>
        Default,

        /// <summary>
        /// A black arrow pointing north
        /// </summary>
        BlackArrow,

        /// <summary>
        /// Compas Rose style north arrow
        /// </summary>
        CenterStar,

        /// <summary>
        /// A triangle around the letter N
        /// </summary>
        TriangleN,

        /// <summary>
        /// A triangle with a hat-like adornment
        /// </summary>
        TriangleHat,

        /// <summary>
        /// An arrow with the letter N
        /// </summary>
        ArrowN,

        /// <summary>
        /// ArrowNS
        /// </summary>
        ArrowNS,
    }

    public enum ColumnWidthType
    {
        Auto = 0,
        Fixed = 1,
        Relative = 2,
    }
}