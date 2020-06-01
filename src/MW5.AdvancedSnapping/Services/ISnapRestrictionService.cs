using MW5.Api.Events;
using MW5.Api.Interfaces;

namespace MW5.Plugins.AdvancedSnapping.Services
{
    public interface ISnapRestrictionService
    {
        bool HasActiveRestrictions { get; }
        bool AutoClear { get; set; }

        void OnSnapPointRequested(SnapPointRequestedEventArgs e);
        void HandleMapMouseUp();

        void RefreshMap();

        void Clear();
        void SnapBearing(ICoordinate anchor, double offset = 0, int handle = 0);
        void SnapDistance(ICoordinate anchor, int handle = 0);
        void SnapSlope(ICoordinate anchor, double slope, ICoordinate offsetAnchor = null, bool needsUserInput = true, int handle = 0);

        void SnapParallel(ICoordinate anchor, ICoordinate point1, ICoordinate point2, ICoordinate offsetAnchor = null, bool needsUserInput = true, int handle = 0);
        void SnapPerpendicular(ICoordinate anchor, ICoordinate point1, ICoordinate point2, bool needsUserInput = true, int handle = 0);
    }
}