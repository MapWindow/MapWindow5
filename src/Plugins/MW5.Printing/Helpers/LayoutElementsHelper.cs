// -------------------------------------------------------------------------------------------
// <copyright file="LayoutElementsHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using MW5.Plugins.Printing.Enums;
using MW5.Plugins.Printing.Model.Elements;

namespace MW5.Plugins.Printing.Helpers
{
    internal static class LayoutElementsHelper
    {
        /// <summary>
        /// Aligns elements with each other or with the margins
        /// </summary>
        public static void AlignElements(
            this List<LayoutElement> elements,
            Alignment side,
            bool margin,
            PrinterSettings printerSettings,
            int paperWidth,
            int paperHeight)
        {
            switch (side)
            {
                case Alignment.Left:
                    if (margin)
                    {
                        foreach (var le in elements)
                        {
                            le.LocationF = new PointF(printerSettings.DefaultPageSettings.Margins.Left, le.LocationF.Y);
                        }
                    }
                    else
                    {
                        float leftMost = float.MaxValue;
                        foreach (var le in elements)
                        {
                            if (le.LocationF.X < leftMost) leftMost = le.LocationF.X;
                        }
                        foreach (var le in elements)
                        {
                            le.LocationF = new PointF(leftMost, le.LocationF.Y);
                        }
                    }
                    break;
                case Alignment.Right:
                    if (margin)
                    {
                        float rightMost = paperWidth - printerSettings.DefaultPageSettings.Margins.Right;
                        foreach (var le in elements)
                        {
                            le.LocationF = new PointF(rightMost - le.Size.Width, le.LocationF.Y);
                        }
                    }
                    else
                    {
                        float rightMost = float.MinValue;
                        foreach (var le in elements)
                        {
                            if (le.LocationF.X + le.Size.Width > rightMost) rightMost = le.LocationF.X + le.Size.Width;
                        }
                        foreach (var le in elements)
                        {
                            le.LocationF = new PointF(rightMost - le.Size.Width, le.LocationF.Y);
                        }
                    }
                    break;
                case Alignment.Top:
                    if (margin)
                    {
                        foreach (var le in elements)
                        {
                            le.LocationF = new PointF(le.LocationF.X, printerSettings.DefaultPageSettings.Margins.Top);
                        }
                    }
                    else
                    {
                        float topMost = float.MaxValue;
                        foreach (var le in elements)
                        {
                            if (le.LocationF.Y < topMost) topMost = le.LocationF.Y;
                        }
                        foreach (var le in elements)
                        {
                            le.LocationF = new PointF(le.LocationF.X, topMost);
                        }
                    }
                    break;
                case Alignment.Bottom:
                    if (margin)
                    {
                        float bottomMost = paperHeight - printerSettings.DefaultPageSettings.Margins.Bottom;
                        foreach (var le in elements)
                        {
                            le.LocationF = new PointF(le.LocationF.X, bottomMost - le.Size.Height);
                        }
                    }
                    else
                    {
                        float bottomMost = float.MinValue;
                        foreach (var le in elements)
                        {
                            if (le.LocationF.Y + le.Size.Height > bottomMost) bottomMost = le.LocationF.Y + le.Size.Height;
                        }
                        foreach (var le in elements)
                        {
                            le.LocationF = new PointF(le.LocationF.X, bottomMost - le.Size.Height);
                        }
                    }
                    break;

                case Alignment.Horizontal:
                    if (margin)
                    {
                        float centerHor = paperWidth / 2F;
                        foreach (var le in elements)
                        {
                            le.LocationF = new PointF(centerHor - (le.Size.Width / 2F), le.LocationF.Y);
                        }
                    }
                    else
                    {
                        float centerHor = 0;
                        float widest = 0;
                        foreach (var le in elements)
                        {
                            if (le.Size.Width > widest)
                            {
                                widest = le.Size.Width;
                                centerHor = le.LocationF.X + (widest / 2F);
                            }
                        }
                        foreach (var le in elements)
                        {
                            le.LocationF = new PointF(centerHor - (le.Size.Width / 2F), le.LocationF.Y);
                        }
                    }
                    break;
                case Alignment.Vertical:
                    if (margin)
                    {
                        float centerVer = paperHeight / 2F;
                        foreach (var le in elements)
                        {
                            le.LocationF = new PointF(le.LocationF.X, centerVer - (le.Size.Height / 2F));
                        }
                    }
                    else
                    {
                        float centerVer = 0;
                        float tallest = 0;
                        foreach (var le in elements)
                        {
                            if (le.Size.Height > tallest)
                            {
                                tallest = le.Size.Height;
                                centerVer = le.LocationF.Y + (tallest / 2F);
                            }
                        }
                        foreach (var le in elements)
                        {
                            le.LocationF = new PointF(le.LocationF.X, centerVer - (le.Size.Height / 2F));
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Makes all of the input layout elements have the same width or height
        /// </summary>
        public static void MatchElementsSize(
            this List<LayoutElement> elements,
            Fit axis,
            bool margin,
            PrinterSettings printerSettings,
            int paperWidth,
            int paperHeight)
        {
            if (axis == Fit.Width)
            {
                if (margin)
                {
                    float newWidth = paperWidth - printerSettings.DefaultPageSettings.Margins.Left -
                                     printerSettings.DefaultPageSettings.Margins.Right;
                    foreach (var le in elements)
                    {
                        le.Size = new SizeF(newWidth, le.Size.Height);
                    }
                }
                else
                {
                    float newWidth = 0;
                    foreach (var le in elements)
                    {
                        if (le.Size.Width > newWidth) newWidth = le.Size.Width;
                    }
                    foreach (var le in elements)
                    {
                        le.Size = new SizeF(newWidth, le.Size.Height);
                    }
                }
            }
            else
            {
                if (margin)
                {
                    float newHeight = paperHeight - printerSettings.DefaultPageSettings.Margins.Top -
                                      printerSettings.DefaultPageSettings.Margins.Bottom;
                    foreach (var le in elements)
                    {
                        le.Size = new SizeF(le.Size.Width, newHeight);
                    }
                }
                else
                {
                    float newHeight = 0;
                    foreach (var le in elements)
                    {
                        if (le.Size.Height > newHeight) newHeight = le.Size.Height;
                    }
                    foreach (var le in elements)
                    {
                        le.Size = new SizeF(le.Size.Width, newHeight);
                    }
                }
            }
        }
    }
}