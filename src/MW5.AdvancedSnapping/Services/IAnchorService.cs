using System;
using System.Collections.Generic;
using System.Drawing;
using MW5.Api.Interfaces;

namespace MW5.Plugins.AdvancedSnapping.Services
{
    public interface IAnchorService
    {
        ICoordinate LastUserLocation { get; set; }
        ICoordinate PrimaryAnchor { get; }
        Tuple<ICoordinate, ICoordinate> ReferenceSegment { get; }
        ICoordinate UserAnchorLocation { get; set; }
        IEnumerable<IFeature> FindFeatures(ICoordinate location);
    }
}