using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins
{
    public enum DataSourceType
    {
        Vector = 0,
        Raster = 1,
        All = 2,
    }

    public enum ProjectState
    {
        NotSaved = 0,
        HasChanges = 1,
        NoChanges = 2,
        Empty = 3,
    }

    public enum DockPanelState
    {
        None = 0,
        Left = 1,
        Right = 2,
        Top = 3,
        Bottom = 4,
        Tabbed = 5,
    }

    public enum DockPanels
    {
        Legend = 0,
        Preview = 1,
    }

    /// <summary>
    /// Defines types of behaviors when a projection for an layer being added is different from project one
    /// </summary>
    public enum ProjectionMismatchBehavior
    {
        IgnoreMismatch = 0,
        Reproject = 1,
        SkipFile = 2,
    }

    /// <summary>
    /// The type of geographic coordinate system
    /// </summary>
    public enum GeographicalCsType
    {
        /// <summary>
        /// Coordinate system used for a single country
        /// </summary>
        Local = 0,

        /// <summary>
        /// Coordinate system used inside certain region
        /// </summary>
        Regional = 1,

        /// <summary>
        /// Coordinate system used around the World
        /// </summary>
        Global = 2,
    }

    /// <summary>
    /// Defines types of behaviors when there is no projection for a layer being added, but the project has one
    /// </summary>
    public enum ProjectionAbsenceBehavior
    {
        AssignFromProject = 0,
        IgnoreAbsence = 1,
        SkipFile = 2,
    }

    /// <summary>
    /// Serach types used by GetCoordinateSystemFunction
    /// </summary>
    public enum ProjectionSearchType
    {
        /// <summary>
        /// Only comparison by name among geographic and projected coordinate systems is made
        /// </summary>
        Standard = 0,

        /// <summary>
        /// Same as standard, but additional after using proj4 export-import operation
        /// </summary>
        Enhanced = 1,

        /// <summary>
        /// The same as enhanced, but dialects are used
        /// </summary>
        UseDialects = 2,
    }
}
