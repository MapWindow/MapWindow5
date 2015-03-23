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

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace MW5.Plugins.Symbology.Controls.ListControls
{
    [ToolboxItem(true)]
    internal partial class IconControl : ListControl
    {
        // The path to load icons from
        string _path = string.Empty;
        bool _textures = false;
        
        // Holds the information about the icon
        internal struct IconInfo
        {
            internal Bitmap img;
            internal string name;

            internal IconInfo(Bitmap image, string filename)
            {
                img = image;
                name = filename;
            }
        };

        // The list of icons
        List<IconInfo> _icons = new List<IconInfo>();

        /// <summary>
        /// Gets or sets the path to the folder
        /// </summary>
        public bool Textures
        {
            get
            {
                return _textures;
            }
            set
            {
                _textures = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the path to the folder
        /// </summary>
        public string FilePath
        {
            get 
            { 
                return _path ;
            }
            set 
            { 
                _path = value;
                LoadFromPath(value);
                this.Invalidate();
            }
        }

        /// <summary>
        /// Returns the file with the icon selected
        /// </summary>
        public string SelectedName
        {
            get 
            {
                int index = base.SelectedIndex;
                if (index >= 0 && index < _icons.Count)
                {
                    return _icons[index].name;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        // Creates a new instance of the IconControl
        public IconControl()
        {
            InitializeComponent();
            this.CellWidth = 32;
            this.CellHeight = 32;
            //LoadFromPath(@"f:\ico\");

            this.OnDrawItem += new OnDrawItemDelegate(IconControl_OnDrawItem);
        }

        /// <summary>
        /// Loads all the icons form the current path
        /// </summary>
        /// <param name="path"></param>
        public void LoadFromPath(string path)
        {
            if (!Directory.Exists(path))
            {
                return;
                //throw new Exception("There is no icon folder in the default location: " + Environment.NewLine + path);
            }
            else
            {
                _icons.Clear();
                string[] files = Directory.GetFiles(path);

                for (int i = 0; i < files.Length; i++)
                {
                    string ext = System.IO.Path.GetExtension(files[i]).ToLower();
                    if (ext == ".png")          //ext == ".bmp" || 
                    {
                        Bitmap bmp = new Bitmap(files[i]);
                        IconInfo icon = new IconInfo(bmp, files[i]);
                        _icons.Add(icon);
                    }
                }
            }
            this.ItemCount = _icons.Count;
        }

        /// <summary>
        /// Draws the next icon from the list
        /// </summary>
        void IconControl_OnDrawItem(Graphics graphics, RectangleF rect, int itemIndex, bool selected)
        {
            Image img = _icons[itemIndex].img;
            if (img != null)
            {
                RectangleF r = new RectangleF();
                if (!_textures)
                {
                    r.X = rect.X + 8; //rect.Width * 0.15f;
                    r.Y = rect.Y + 8; //rect.Height * 0.15f;
                    r.Width = rect.Width - 16; //* 0.7f;
                    r.Height = rect.Height - 16; //* 0.7f;
                    
                    graphics.DrawImage(img, r);
                }
                else
                {
                    
                    r.X = rect.X + rect.Width * 0.1f;
                    r.Y = rect.Y + rect.Height * 0.1f;
                    r.Width = rect.Width * 0.8f;
                    r.Height = rect.Height * 0.8f;
                    TextureBrush brush = new TextureBrush(img);
                    graphics.FillRectangle(brush, r);
                }
            }
        }
    }
}
