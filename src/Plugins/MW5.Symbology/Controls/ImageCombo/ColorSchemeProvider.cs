// ********************************************************************************************************
/// ********************************************************************************************************
// <copyright file="MWLite.Symbology.cs" company="MapWindow.org">
// Copyright (c) MapWindow.org. All rights reserved.
// </copyright>
// The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
// you may not use this file except in compliance with the License. You may obtain a copy of the License at 
// http:// Www.mozilla.org/MPL/ 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
// ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
// limitations under the License. 
// 
// The Initial Developer of this version of the Original Code is Sergei Leschinski
// 
// Contributor(s): (Open source contributors should list themselves and their modifications here). 
// Change Log: 
// Date            Changed By      Notes
// ********************************************************************************************************

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Xml;
using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Helpers;
using MW5.Shared;

namespace MW5.Plugins.Symbology.Controls.ImageCombo
{
    /// <summary>
    /// This class is wrapper for a list of color schemes associated with layer, labels or charts
    /// </summary>
    internal static class ColorSchemeProvider
    {
        private static Dictionary<SchemeTarget, ColorSchemeCollection> _dict = new Dictionary<SchemeTarget, ColorSchemeCollection>();

        internal static void Load()
        {
            var values = Enum.GetValues(typeof (SchemeTarget));

            foreach (SchemeTarget val in values)
            {
                try
                {
                    _dict[val] = new ColorSchemeCollection(val, GetFilename(val));
                }
                catch (Exception ex)
                {
                    Logger.Current.Warn("Failed to load color schemes:", ex);
                }
            }
        }

        public static ColorSchemeCollection GetList(SchemeTarget type)
        {
            if (_dict.ContainsKey(type))
            {
                return _dict[type];
            }
            return null;
        }

        /// <summary>
        /// Returns the path to the specified style file, in case the file doesn't exist - creates it.
        /// </summary>
        private static string GetFilename(SchemeTarget type)
        {
            string path = ResourceHelper.GetStylesPath();
            switch (type)
            {
                case SchemeTarget.Vector:
                    return path + "colorschemes.xml";
                case SchemeTarget.Charts:
                    return path + "chartcolorsxml";
            }
            return string.Empty;
        }

        internal static void SetFirstColorScheme(SchemeTarget type, Color color)
        {
            GetList(type).SetFirstColorScheme(color);
        }

        internal static void SetFirstColorScheme(SchemeTarget type, IFeatureSet fs)
        {
            GetList(type).SetFirstColorScheme(fs);
        }
    }
}
