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
        /// <returns>Scale of the map.</returns>
        public static double CalcMapScale(GeoSize geoSize, SizeF mapSize)
        {
            double cf = LengthUnits.Meters.GetConversionFactor();
            double scaleX = geoSize.Width / (mapSize.Width / 100.0 / cf);
            double scaleY = geoSize.Height / (mapSize.Height / 100.0 / cf);
            return Math.Max(scaleX, scaleY);
        }

        /// <summary>
        /// Calculates the size of the map on screen for a given size of map area and scale.
        /// </summary>
        /// <param name="mapScale">Map scale.</param>
        /// <param name="geoSize">Geodesic size of the map area in meters.</param>
        /// <returns>Size of the map on the screen in 1/100 of an inch.</returns>
        public static SizeF CalcMapSize(int mapScale, GeoSize geoSize)
        {
            double cf = LengthUnits.Meters.GetConversionFactor();
            var widthInches = (float)(geoSize.Width * cf / mapScale);
            var heightInches = (float)(geoSize.Height * cf / mapScale);
            return new SizeF(widthInches * 100f, heightInches * 100f);
        }

        /// <summary>
        /// Calculates new extents of the map given that they must cover certain geo size in meters.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <param name="oldExtents">The extents.</param>
        /// <param name="newSize">The new size.</param>
        /// <returns>New extents</returns>
        public static IEnvelope CalcNewExtents(IPrintableMap map, IEnvelope oldExtents, GeoSize newSize)
        {
            int depth = 0;
            return CalcNewExtentsCore(map, oldExtents, newSize, ref depth);
        }

        /// <summary>
        /// Recursively calculates new extents of the map ot cover a certain geo size in meters.
        /// </summary>
        private static IEnvelope CalcNewExtentsCore(
            IPrintableMap map,
            IEnvelope oldExtents,
            GeoSize newSize,
            ref int depth)
        {
            depth++;

            GeoSize oldSize;
            if (map.GetGeodesicSize(oldExtents, out oldSize))
            {
                // TODO: tolerance can be different depending on map units
                const int maxDepth = 5;
                if (NumericHelper.Equal(newSize.Product, oldSize.Product, 1e-6) || depth > maxDepth)
                {
                    return oldExtents;
                }

                double ratio = Math.Sqrt(newSize.Product / oldSize.Product) - 1;
                double dx = oldExtents.Width * ratio;
                double dy = oldExtents.Height * ratio;
                var extents = oldExtents.Inflate(dx, dy);

                return CalcNewExtentsCore(map, extents, newSize, ref depth);
            }

            return null;
        }
    }
}