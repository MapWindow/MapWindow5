using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.AdvancedSnapping.Services;

namespace MW5.AdvancedSnapping.Test
{
    [TestClass]
    public class SnapPointCandidateCheckerTests
    {
        [TestMethod]
        public void When_MultiplePointsAreGenerated_BestPointIsReturned()
        {
            var testCoordinate = new Coordinate(0, 0);
            var tolerance = 0.05;
            var checker = new SnapPointCandidateChecker(testCoordinate, tolerance);

            var bestPoint = new Coordinate(tolerance / 4.0, 0);
            var secondBestPoint = new Coordinate(tolerance / 3.0, 0);
            var thirdBestPoint = new Coordinate(tolerance / 2.0, 0);

            checker.ContainsBetterCandidate((c) => new[] {
                bestPoint,
                secondBestPoint,
                thirdBestPoint
            });

            Assert.AreEqual(bestPoint, checker.BestSnapPoint);
        }

        [TestMethod]
        public void When_MultiplePointsAreGenerated_OnlyPointsWithinToleranceAreUsed()
        {
            var testCoordinate = new Coordinate(0, 0);
            var tolerance = 0.05;
            var checker = new SnapPointCandidateChecker(testCoordinate, tolerance);

            var bestPoint = new Coordinate(tolerance * 1.1, 0);
            var secondBestPoint = new Coordinate(tolerance * 1.2, 0);
            var thirdBestPoint = new Coordinate(tolerance * 1.3, 0);

            checker.ContainsBetterCandidate((c) => new[] {
                bestPoint,
                secondBestPoint,
                thirdBestPoint
            });

            Assert.AreNotEqual(bestPoint, checker.BestSnapPoint);
            Assert.AreNotEqual(secondBestPoint, checker.BestSnapPoint);
            Assert.AreNotEqual(thirdBestPoint, checker.BestSnapPoint);
        }

        [TestMethod]
        public void When_UsingWithoutToleranceMethods_ToleranceIsIgnored()
        {
            var testCoordinate = new Coordinate(0, 0);
            var tolerance = 0.05;
            var checker = new SnapPointCandidateChecker(testCoordinate, tolerance);

            var bestPoint = new Coordinate(tolerance * 1.1, 0);
            var secondBestPoint = new Coordinate(tolerance * 1.2, 0);
            var thirdBestPoint = new Coordinate(tolerance * 1.3, 0);

            checker.ContainsBetterCandidateWithoutTolerance((c) => new[] {
                bestPoint,
                secondBestPoint,
                thirdBestPoint
            });

            Assert.AreEqual(bestPoint, checker.BestSnapPoint);
            Assert.AreNotEqual(secondBestPoint, checker.BestSnapPoint);
            Assert.AreNotEqual(thirdBestPoint, checker.BestSnapPoint);
        }
    }
}
