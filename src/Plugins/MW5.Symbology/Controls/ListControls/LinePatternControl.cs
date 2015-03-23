// ********************************************************************************************************
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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Xml;
using MW5.Api.Concrete;
using MW5.Plugins.Symbology.Helpers;

namespace MW5.Plugins.Symbology.Controls.ListControls
{
    /// <summary>
    /// A control to show the list of available line pattern styles
    /// </summary>
    [ToolboxItem(true)]
    internal partial class LinePatternControl : ListControl
    {
        private List<CompositeLine> _patterns = new List<CompositeLine>();

        #region Initialization
        /// <summary>
        /// Creates a new instance of the LinePatternControl
        /// </summary>
        public LinePatternControl()
        {
            CellWidth = 64;
            CellHeight = 24;
            OnDrawItem += Control_OnDrawItem;

            AddDefaultPatterns();
        }

        /// <summary>
        /// Adds default patterns to the list
        /// </summary>
        private void AddDefaultPatterns()
        {
            _patterns.Clear();

            var pattern = new CompositeLine();
            pattern.AddLine(Color.Red, 1, DashStyle.Solid);
            _patterns.Add(pattern);

            // TODO: mode patterns can be added

            ItemCount = _patterns.Count;
        }
        
        /// <summary>
        /// Adds pattern to the list
        /// </summary>
        internal void AddPattern(CompositeLine pattern)
        {
            if (pattern != null && pattern.Count > 0)
            {
                _patterns.Add(pattern);
                ItemCount = _patterns.Count;
            }
        }

        /// <summary>
        /// Removes given pattern from the list
        /// </summary>
        internal void RemovePattern(int index)
        {
            if (index >= 0 && index < _patterns.Count)
            {
                _patterns.RemoveAt(index);
                ItemCount = _patterns.Count;
            }
        }

        /// <summary>
        /// Gets the selected pattern or null if there is no one
        /// </summary>
        internal CompositeLine SelectedPattern
        {
            get
            {
                if (ItemCount == 0 || SelectedIndex < 0)
                {
                    return null;
                }
                if (SelectedIndex < ItemCount)
                {
                    return _patterns[SelectedIndex];
                }
                return null;
            }
        }
        #endregion

        #region Serialization
        /// <summary>
        /// Saves list of styles to XML
        /// </summary>
        public bool SaveToXml()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<MapWindow version= '" + "'></MapWindow>");     // TODO: add version
            
            XmlElement xelRoot = xmlDoc.DocumentElement;

            XmlAttribute attr = xmlDoc.CreateAttribute("FileVersion");
            attr.InnerText = "0";
            xelRoot.Attributes.Append(attr);

            attr = xmlDoc.CreateAttribute("FileType");
            attr.InnerText = "LinePatterns";
            xelRoot.Attributes.Append(attr);

            XmlElement xelSchemes = xmlDoc.CreateElement("LinePatters");

            foreach (var pattern in _patterns)
            {
                XmlElement xelPattern = xmlDoc.CreateElement("Pattern");
                xelPattern.InnerText = pattern.Serialize();
                xelSchemes.AppendChild(xelPattern);
            }
            xelRoot.AppendChild(xelSchemes);

            string filename = get_FileName();
            string path = Path.GetDirectoryName(filename);
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception ex)
                {
                    SymbologyPlugin.Msg.Warn("Failed to create directory: " + path + Environment.NewLine + ex.Message);
                    return false;
                }
            }

            if (Directory.Exists(path))
            {
                try
                {
                    xmlDoc.Save(filename);
                }
                catch (Exception ex)
                {
                    SymbologyPlugin.Msg.Warn("Failed to save line patterns: " + path + Environment.NewLine + ex.Message);
                    return false;
                }
            }

            // TEMP
            _patterns.Clear();
            ItemCount = _patterns.Count;

            return true;
        }
        
        /// <summary>
        /// Loads all the icons form the current path
        /// </summary>
        /// <param name="path"></param>
        public void LoadFromXml()
        {
            _patterns.Clear();

            XmlDocument xmlDoc = new XmlDocument();
            string filename = get_FileName();

            // reading from the file
            if (System.IO.File.Exists(filename))
            {
                xmlDoc.Load(filename);

                XmlElement xelSchemes = xmlDoc.DocumentElement["LinePatters"];
                if (xelSchemes != null)
                {
                    foreach (XmlNode nodePatter in xelSchemes.ChildNodes)
                    {
                        var pattern = new CompositeLine();
                        pattern.Deserialize(nodePatter.InnerText);
                        if (pattern.Count > 0)
                        {
                            _patterns.Add(pattern);
                        }
                    }
                }
            }
            
            // load some default ones if none were loaded
            if (_patterns.Count == 0)
            {
                AddDefaultPatterns();
            }

            ItemCount = _patterns.Count;

            if (ItemCount > 0)
            {
                SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Retuns the name of file to serialize patterns in
        /// </summary>
        private string get_FileName()
        {
            string filename = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            return Directory.GetParent(filename).FullName + "\\Styles\\linepatterns.xml";
        }
        #endregion

        #region Drawing
        /// <summary>
        /// Draws the next icon from the list
        /// </summary>
        void Control_OnDrawItem(Graphics graphics, RectangleF rect, int itemIndex, bool selected)
        {
            var pattern = _patterns[itemIndex];
            pattern.Draw(graphics, rect.X + 1.0f, rect.Y + 1.0f, (int)rect.Width - 2, (int)rect.Height - 2, BackColor);
        }
        #endregion
    }
}
