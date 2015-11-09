// -------------------------------------------------------------------------------------------
// <copyright file="LayoutScaleHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Drawing;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Map;
using MW5.Plugins.Printing.Enums;
using MW5.Shared;

namespace MW5.Plugins.Printing.Helpers
{
    /// <summary>
    /// Calculates relations between size of map area in the field, map scale and size of map element on the screen.
    /// </summary>
    internal static class LayoutScaleHelper
    {
        /// <summary>
        /// Calculates the size of the map area in meters to be displayed at a given scale and size of screen area.
        /// </summary>
        /// <param name="mapScale">The map scale.</param>
        /// <param name="size">The size.</param>
        /// <returns>Geodesic size of the map area in meters.</returns>
        public static GeoSize CalcMapGeoSize(int mapScale, SizeF size)
        {
            double cf = LengthUnits.Meters.GetConversionFactor();
            double width = size.Width / 100.0f * mapScale / cf;
            double height = size.Height / 100.0f * mapScale / cf;
            return new GeoSize(width, height);
        }

        /// <summary>
        /// Calculates map scale to fit given extents.
        /// </summary>
        /// <param name="geoSize">Geodesic size of mapped area in meters.</param>
        /// <param name="mapSize">Size of the map on the screen (1/100 of inch).</param>
        /// <param name="scaleType">The X and Y scale are often different, this parameter tells how to choose the return value from 2 values available.</param>
        /// <returns>Scale of the map.</returns>
        public static double CalcMapScale(GeoSize geoSize, SizeF mapSize, ScaleType scaleType = ScaleType.Average)
        {
            double cf = LengthUnits.Meters.GetConversionFactor();
            double scaleX = geoSize.Width / (mapSize.Width / 100.0 / cf);
            double scaleY = geoSize.Height / (mapSize.Height / 100.0 / cf);

            switch (scaleType)
            {
                case ScaleType.Average:
                    return (scaleX + scaleY) / 2.0;
                case ScaleType.Smallest:
                    return Math.Max(scaleX, scaleY);
                case ScaleType.Largest:
                    return Math.Min(scaleX, scaleY);
                default:
                    throw new ArgumentOutOfRangeException("scaleType");
            }
        }

        /// <summary>
        /// Calculates the size of the map on screen for a given size of map area and scale.
        /// </summary>
        /// <param name="mapScale">Map scale.</param>
        /// <param name="geoSize">Geodesic size of the map area in meters.</param>
        /// <param name="xyRatio">The X / Y ratio for the extents in original coordinate system.</param>
        /// <returns>Size of the map on the screen in 1/100 of an inch.</returns>
        public static SizeF CalcMapSize(int mapScale, GeoSize geoSize, double xyRatio)
        {
            double cf = LengthUnits.Meters.GetConversionFactor();
            var widthInches = geoSize.Width * cf / mapScale;
            var heightInches = geoSize.Height * cf / mapScale;

            // The distortion introduced be orginal map coordinate system may be different along X and Y axes,
            // so paper size rectangle may no longer have the same X / Y side ratio as original extents.
            // This will result in adjustment of extents in map projection according to this ratio, which is undesirable.
            // Let's instead adjust resulting paper size to orignal X / Y ratio.
            double newRatio = widthInches / heightInches;
            if (!NumericHelper.Equal(newRatio, xyRatio, 1e-6))
            {
                double correction = Math.Sqrt(newRatio / xyRatio);
                heightInches *= correction;
                widthInches /= correction;
            }

            return new SizeF((float)(widthInches * 100.0), (float)(heightInches * 100.0));
        }

        /// <summary>
        /// Calculates new extents of the map given that they must cover certain geo size in meters.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <param name="oldExtents">The extents.</param>
        /// <param name="newSize">The new size.</param>
        /// <param name="paperSize"></param>
        /// <returns>New extents</returns>
        public static IEnvelope CalcNewExtents(IPrintableMap map, IEnvelope oldExtents, GeoSize newSize, SizeF paperSize)
        {
            int depth = 0;
            return CalcNewExtentsCore(map, oldExtents, newSize, paperSize, ref depth);
        }

        /// <summary>
        /// Recursively calculates new extents of the map ot cover a certain geo size in meters.
        /// </summary>
        private static IEnvelope CalcNewExtentsCore(
            IPrintableMap map,
            IEnvelope oldExtents,
            GeoSize newSize,
            SizeF paperSize,
            ref int depth)
        {
            depth++;

            GeoSize oldSize;
            if (map.GetGeodesicSize(oldExtents, out oldSize))
            {
                // TODO: tolerance can be different depending on map units
                const int maxDepth = 5;

                double newScale = CalcMapScale(newSize, paperSize);
                double oldScale = CalcMapScale(oldSize, paperSize);

                if (NumericHelper.Equal(newScale, oldScale, 1e-6) || depth > maxDepth)
                {
                    return oldExtents;
                }

                double ratio = newScale / oldScale - 1;
                double dx = oldExtents.Width * ratio;
                double dy = oldExtents.Height * ratio;
                var extents = oldExtents.Inflate(dx, dy);

                return CalcNewExtentsCore(map, extents, newSize, paperSize, ref depth);
            }

            return null;
        }
    }
}