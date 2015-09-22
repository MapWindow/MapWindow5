// -------------------------------------------------------------------------------------------
// <copyright file="FeatureSetHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Api.Helpers
{
    public static class FeatureSetHelper
    {
        /// <summary>
        /// Gets extents of the selected features.
        /// </summary>
        /// <returns>Null if there are no selected features.</returns>
        public static IEnvelope GetSelectedExtents(this IFeatureSet fs)
        {
            if (fs.NumSelected == 0)
            {
                return null;
            }

            var list = fs.Features.Where(f => f.Selected);

            var box = list.FirstOrDefault().Geometry.Extents;

            foreach (var ft in list)
            {
                box.Union(ft.Geometry.Extents);
            }

            return box;
        }

        /// <summary>
        /// Gets list of features of input dataset to be processed.
        /// </summary>
        public static List<IFeature> GetFeatures(this IFeatureSet fs, bool selectedOnly)
        {
            return selectedOnly ? fs.Features.Where(f => f.Selected).ToList() : fs.Features.ToList();
        }

        /// <summary>
        /// Gets length units for datasource based on its projection.
        /// </summary>
        public static LengthUnits GetLengthUnits(this IFeatureSet fs)
        {
            // TODO: this is a fast and dirty solution; units may also be stored in WKT string explicitly,
            // while ultimatily it may be needed to choose source units explicitly in the UI
            return fs.Projection.IsGeographic ? LengthUnits.DecimalDegrees : LengthUnits.Meters;
        }

        /// <summary>
        /// Gets dictionary with number of features in each categories. Category index is used as a key.
        /// </summary>
        public static Dictionary<int, int> GetCategoryCounts(this IFeatureSet fs)
        {
            var dct = new Dictionary<int, int>();

            foreach (var ft in fs.Features)
            {
                int category = ft.CategoryIndex;
                if (dct.ContainsKey(category))
                {
                    dct[category] += 1;
                }
                else
                {
                    dct.Add(category, 1);
                }
            }

            return dct;
        }

        /// <summary>
        /// Removes categories without any features.
        /// </summary>
        public static void RemoveUnusedCategories(this IFeatureSet fs)
        {
            var dct = fs.GetCategoryCounts();

            var list = new List<IFeatureCategory>();

            foreach (var ct in fs.Categories)
            {
                if (!dct.ContainsKey(ct.Index))
                {
                    list.Add(ct);
                }
            }

            if (list.Any())
            {
                foreach (var ct in list)
                {
                    fs.Categories.Remove(ct);
                }

                // need to reapply since it's likely that indices have changed
                fs.Categories.ApplyExpressions();
            }
        }
    }
}