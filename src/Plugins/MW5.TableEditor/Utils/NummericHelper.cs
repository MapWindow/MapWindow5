// ********************************************************************************************************
// <copyright file="NummericHelper.cs" company="TopX Geo-ICT">
//     Copyright (c) 2012 TopX Geo-ICT. All rights reserved.
// </copyright>
// ********************************************************************************************************
// The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
// you may not use this file except in compliance with the License. You may obtain a copy of the License at 
// http:// www.mozilla.org/MPL/ 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
// ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
// limitations under the License. 
// 
// The Initial Developer of this version is Jeen de Vegt.
// 
// Contributor(s): (Open source contributors should list themselves and their modifications here). 
// Change Log: 
// Date           Changed By      Notes
// 29 March 2012  Jeen de Vegt    Inital coding
// ********************************************************************************************************
namespace MW5.Plugins.TableEditor.utils
{
    /// <summary>
    ///  Class for performinc nummeric actions
    /// </summary>
    public class NummericHelper
    {
        /// <summary>Check if a value is nummeric</summary>
        /// <param name = "value">The value to check.</param>
        /// <param name = "style">The NumberStyle</param>
        /// <returns>Status indicating if value is nummeric</returns> 
        public static bool IsNumeric(string value, System.Globalization.NumberStyles style)
        {
            double result;

            return double.TryParse(value, style, System.Globalization.CultureInfo.CurrentCulture, out result);
        }
    }
}
