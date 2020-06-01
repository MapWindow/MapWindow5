using MW5.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MW5.Plugins.AdvancedSnapping.Services
{
    public class SnapPointCandidateChecker
    {
        public ICoordinate PointToSnap { get; private set; } = null;
        public ICoordinate BestSnapPoint { get; private set; } = null;
        public double DistanceToBestSnapPoint { get; private set; } = double.MaxValue;
        public double Tolerance { get; private set; } = 0.001;

        public SnapPointCandidateChecker(ICoordinate original, double tolerance)
        {
            Tolerance = tolerance;
            PointToSnap = original;
            BestSnapPoint = original;
        }

        private bool IsBetterCandidateWithoutTolerance(ICoordinate newCoordinate, double? newDistance = null)
        {
            newDistance = newDistance ?? PointToSnap.Distance(newCoordinate);
            if (newDistance > DistanceToBestSnapPoint)
                return false;

            BestSnapPoint = newCoordinate;
            DistanceToBestSnapPoint = newDistance.Value;
            return true;

        }

        public bool IsBetterCandidate(ICoordinate newCoordinate)
        {
            double newDistance = PointToSnap.Distance(newCoordinate);
            if (newDistance > Tolerance)
                return false;

            return IsBetterCandidateWithoutTolerance(newCoordinate, newDistance);
        }

        public bool ContainsBetterCandidate(IEnumerable<ICoordinate> newCoordinates)
            => ContainsBetterCandidate(c => newCoordinates);

        public bool ContainsBetterCandidate(Func<ICoordinate, IEnumerable<ICoordinate>> newCoordinatesFunction)
        {
            var newCoordinates = newCoordinatesFunction?.Invoke(PointToSnap) ?? Enumerable.Empty<ICoordinate>();
            var result = false;
            foreach (var coordinate in newCoordinates.Where(coordinate => coordinate != null).ToList())
                result = IsBetterCandidate(coordinate) || result;
            return result;
        }

        public bool ContainsBetterCandidateWithoutTolerance(IEnumerable<ICoordinate> newCoordinates)
            => ContainsBetterCandidateWithoutTolerance(c => newCoordinates);

        public bool ContainsBetterCandidateWithoutTolerance(Func<ICoordinate, IEnumerable<ICoordinate>> newCoordinatesFunction)
        {
            var newCoordinates = newCoordinatesFunction?.Invoke(PointToSnap) ?? Enumerable.Empty<ICoordinate>();
            var result = false;
            foreach (var coordinate in newCoordinates.Where(coordinate => coordinate != null).ToList())
                result = IsBetterCandidateWithoutTolerance(coordinate) || result;
            return result;
        }
    }
}
