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

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace MW5.Plugins.Symbology.Controls.ListControls
{
    [ToolboxItem(false)]
    internal partial class CharacterControl : ListControl
    {
        /// <summary>
        /// Creates a new instance of CharacterControl class
        /// </summary>
        public CharacterControl()
        {
            ItemCount = 224;
            OnDrawItem += new OnDrawItemDelegate(CharacterControl_OnDrawItem);
        }

        /// <summary>
        /// Gets and sets the ANSI code of selected item
        /// </summary>
        public byte SelectedCharacterCode
        {
            get 
            {
                return IndexToCharacterCode(SelectedIndex);
            }
            set
            {
                SelectedIndex = CharacterCodeToIndex(value);
            }
        }

        /// <summary>
        /// Sets the font of the characters
        /// </summary>
        /// <param name="fontName"></param>
        public void SetFontName(string fontName)
        {
            Font fnt = null;
            try
            {
                fnt = new Font(fontName, 10f);
            }
            catch
            {
                // nothing
            }
            if (fnt != null)
            {
                base.Font = fnt;
                Redraw();
            }
        }

        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                base.Redraw();
            }
        }

        #region Drawing
        /// <summary>
        /// Draws a single item 
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="itemIndex"></param>
        /// <param name="selected"></param>
        void CharacterControl_OnDrawItem(Graphics graphics, RectangleF rect, int itemIndex, bool selected)
        {
            Font smallFont = new Font(Font.FontFamily, CellWidth * .7F, GraphicsUnit.Pixel);

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            SolidBrush brush = new SolidBrush(base.ForeColor);

            // getting string with the given character
            byte[] bytes = new byte[] { IndexToCharacterCode(itemIndex) };  // 32 - the first character to show
            string text = Encoding.Default.GetChars(bytes)[0].ToString();
            GraphicsPath path = new GraphicsPath();
            path.AddString(text, smallFont.FontFamily, (int)smallFont.Style, (float)smallFont.Size, rect, format);
            graphics.FillPath(new SolidBrush(ForeColor), path);
            graphics.DrawPath(Pens.Black, path);

            //graphics.DrawString(text, smallFont, brush, rect, format);
        }
        #endregion

        #region AnsiConversion
        /// <summary>
        /// Converts ANSI character code to the index in the control
        /// </summary>
        private int CharacterCodeToIndex(int Character)
        {
            if (Character >= 32 && Character <= 255)
            {
                return Character - 32;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Converts the index of character in the control to the ANSI character code
        /// </summary>
        private byte IndexToCharacterCode(int Index)
        {
            if (Index >= 0 && Index < base.ItemCount)
            {
                return (byte)(Index + 32);
            }
            else
            {
                return (byte)0;
            }
        }
        #endregion

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // CharacterControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(34F, 36F);
            Font = new System.Drawing.Font("Webdings", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            Margin = new System.Windows.Forms.Padding(17, 8, 17, 8);
            Name = "CharacterControl";
            Size = new System.Drawing.Size(1173, 665);
            ResumeLayout(false);

        }
    }
}
