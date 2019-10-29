using MW5.Api.Interfaces;
using System.Collections.Generic;

namespace MW5.Plugins.AdvancedSnapping.Restrictions
{

    public interface IRestriction
    {
        RestrictionType Type { get; }

        void AddDrawingLayer(IMap map);

        void RemoveDrawingLayer(IMap map);

        void RefreshGuideline(IMap map);

        /// <summary>
        /// For circular restrictions this is the center point
        /// For linear restrictions this is the (0,Y) point? - TODO
        /// </summary>
        ICoordinate Anchor { get; }

        /// <summary>
        /// For circular restrictions this is the radius
        /// For linear restrictions this is the slope of the line (or infinity in case of a vertical line)
        /// </summary>
        double Factor { get; }

        /// <summary>
        /// A number used to be able to clear restrictions when the context changed 
        /// (e.g. shape editor added a point)
        /// </summary>
        int Handle { get; }

        ICoordinate GetSnapPoint(ICoordinate original);

        IEnumerable<ICoordinate> GetIntersections(IRestriction other);
    }
}
