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
using System.IO;
using System.Linq;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Helpers;
using MW5.Shared;

namespace MW5.Plugins.Symbology.Controls.ListControls
{
    [ToolboxItem(true)]
    internal partial class IconControl : ListControl
    {
        private string _path = string.Empty;
        private bool _textures = false;
        private readonly List<IconInfo> _icons = new List<IconInfo>();

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
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the path to the folder
        /// </summary>
        public string FilePath
        {
            get 
            { 
                return _path;
            }
            set 
            { 
                _path = value;
                LoadFromPath(value);
                Invalidate();
            }
        }

        /// <summary>
        /// Returns the file with the icon selected
        /// </summary>
        public string SelectedPath
        {
            get 
            {
                int index = SelectedIndex;
                if (index >= 0 && index < _icons.Count)
                {
                    return _icons[index].Filename;
                }

                return string.Empty;
            }

            set
            {
                for (int i = 0; i < _icons.Count; i++)
                {
                    if (_icons[i].Filename.EqualsIgnoreCase(value))
                    {
                        SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IconControl"/> class.
        /// </summary>
        public IconControl()
        {
            InitializeComponent();
            CellWidth = 32;
            CellHeight = 32;

            OnDrawItem += IconControl_OnDrawItem;
        }

        /// <summary>
        /// Loads all the icons form the current path
        /// </summary>
        public void LoadFromPath(string path)
        {
            if (!Directory.Exists(path)) return;

            _icons.Clear();
            string[] files = Directory.GetFiles(path);

            for (int i = 0; i < files.Length; i++)
            {
                var extension = Path.GetExtension(files[i]);
                if (extension != null)
                {
                    string ext = extension.ToLower();
                    if (ext == ".png")          //ext == ".bmp" || 
                    {
                        Bitmap bmp = new Bitmap(files[i]);
                        IconInfo icon = new IconInfo(bmp, files[i]);
                        _icons.Add(icon);
                    }
                }
            }

            ItemCount = _icons.Count;
        }

        /// <summary>
        /// Draws the next icon from the list
        /// </summary>
        private void IconControl_OnDrawItem(Graphics graphics, RectangleF rect, int itemIndex, bool selected)
        {
            var img = _icons[itemIndex].Image;
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

        /// <summary>
        /// Sets CellWidth, CellHeight properties based on the size of the first png icon found at the specified path.
        /// </summary>
        public  void ChooseIconCellSize(string path)
        {
            if (!Directory.Exists(path))
            {
                return;
            }

            CellWidth = 32;
            CellHeight = 32;

            // let's try to determine real size by first file
            try
            {
                string[] files = Directory.GetFiles(path);
                foreach (string filename in files)
                {
                    string ext = Path.GetExtension(filename);

                    if (ext.EqualsIgnoreCase(".png"))
                    {
                        var size = GdiPlusHelper.GetIconSize(filename);
                        if (size != default(Size))
                        {
                            CellWidth = size.Width;
                            CellHeight = size.Height;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageService.Current.Info("Failed to load icon: " + ex.Message);
            }
        }
    }
}
