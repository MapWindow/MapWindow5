// -------------------------------------------------------------------------------------------
// <copyright file="FeatureSetStyleHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using MW5.Api.Interfaces;

namespace MW5.Plugins.Symbology.Helpers
{
    public static class FeatureSetStyleHelper
    {
        /// <summary>
        /// Applies the default style to categories, preserving only those properties that are among categories.
        /// </summary>
        public static void ApplyDefaultStyleToCategories(this IFeatureSet fs)
        {
            if (fs == null) throw new ArgumentNullException("fs");

            var categories = fs.Categories;

            if (categories.Count == 0)
            {
                return;
            }

            var style = fs.Style;

            CopyMatchedProperties(categories.Select(ct => ct.Style.Fill), style.Fill);

            CopyMatchedProperties(categories.Select(ct => ct.Style.Line), style.Line);

            CopyMatchedProperties(categories.Select(ct => ct.Style.Vertices), style.Vertices);

            CopyMatchedProperties(categories.Select(ct => ct.Style.Marker), style.Marker);
        }

        /// <summary>
        /// Applies property values of the default item to all items in the list, 
        /// if all these items has the same value of the given property.
        /// </summary>
        private static void CopyMatchedProperties<T>(IEnumerable<T> list, T defaultItem) where T : class
        {
            list = list.ToList();

            var firstItem = list.FirstOrDefault();
            if (firstItem == null || defaultItem == null)
            {
                return;
            }

            var props = typeof(T).GetProperties();

            foreach (var p in props)
            {
                if (!p.PropertyType.IsValueType)
                {
                    continue; // ignore reference types; it's unsafe to copy reference without 
                    // creating underlying objects
                }

                var value = p.GetValue(firstItem);

                bool mismatch = list.Select(ct => p.GetValue(ct)).Any(v => !value.Equals(v));

                if (!mismatch)
                {
                    var defaultValue = p.GetValue(defaultItem);

                    foreach (var item in list)
                    {
                        p.SetValue(item, defaultValue);
                    }
                }
            }
        }
    }
}