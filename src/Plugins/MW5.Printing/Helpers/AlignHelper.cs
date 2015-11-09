// -------------------------------------------------------------------------------------------
// <copyright file="AlignHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using MW5.Plugins.Printing.Enums;
using MW5.Plugins.Printing.Model.Elements;

namespace MW5.Plugins.Printing.Helpers
{
    internal static class AlignHelper
    {
        /// <summary>
        /// Aligns groups of elements relative to the combined extents.
        /// </summary>
        public static void Align(this IEnumerable<LayoutElement> elements, Alignment side)
        {
            var list = elements.ToList();
            switch (side)
            {
                case Alignment.Left:
                    float leftMost = float.MaxValue;
                    foreach (var le in list)
                    {
                        if (le.LocationF.X < leftMost) leftMost = le.LocationF.X;
                    }
                    foreach (var le in list)
                    {
                        le.LocationF = new PointF(leftMost, le.LocationF.Y);
                    }
                    break;
                case Alignment.Right:
                    float rightMost = float.MinValue;

                    foreach (var le in list)
                    {
                        if (le.LocationF.X + le.SizeF.Width > rightMost) rightMost = le.LocationF.X + le.SizeF.Width;
                    }

                    foreach (var le in list)
                    {
                        le.LocationF = new PointF(rightMost - le.SizeF.Width, le.LocationF.Y);
                    }
                    break;
                case Alignment.Top:
                    float topMost = float.MaxValue;

                    foreach (var le in list)
                    {
                        if (le.LocationF.Y < topMost) topMost = le.LocationF.Y;
                    }

                    foreach (var le in list)
                    {
                        le.LocationF = new PointF(le.LocationF.X, topMost);
                    }
                    break;
                case Alignment.Bottom:
                    float bottomMost = float.MinValue;

                    foreach (var le in list)
                    {
                        if (le.LocationF.Y + le.SizeF.Height > bottomMost) bottomMost = le.LocationF.Y + le.SizeF.Height;
                    }

                    foreach (var le in list)
                    {
                        le.LocationF = new PointF(le.LocationF.X, bottomMost - le.SizeF.Height);
                    }
                    break;
                case Alignment.Horizontal:
                    float centerHor = 0;
                    float widest = 0;

                    foreach (var le in list)
                    {
                        if (le.SizeF.Width > widest)
                        {
                            widest = le.SizeF.Width;
                            centerHor = le.LocationF.X + (widest / 2F);
                        }
                    }

                    foreach (var le in list)
                    {
                        le.LocationF = new PointF(centerHor - (le.SizeF.Width / 2F), le.LocationF.Y);
                    }
                    break;
                case Alignment.Vertical:

                    float centerVer = 0;
                    float tallest = 0;

                    foreach (var le in list)
                    {
                        if (le.SizeF.Height > tallest)
                        {
                            tallest = le.SizeF.Height;
                            centerVer = le.LocationF.Y + (tallest / 2F);
                        }
                    }

                    foreach (var le in list)
                    {
                        le.LocationF = new PointF(le.LocationF.X, centerVer - (le.SizeF.Height / 2F));
                    }
                    break;
            }
        }

        /// <summary>
        /// Align one or more elements relative to the paper bounds.
        /// </summary>
        public static void AlignByPageSide(this IEnumerable<LayoutElement> elements,
            Alignment side,
            int paperWidth,
            int paperHeight)
        {
            switch (side)
            {
                case Alignment.Left:
                    foreach (var le in elements)
                    {
                        le.LocationF = new PointF(0f, le.LocationF.Y);
                    }
                    break;
                case Alignment.Right:
                    foreach (var le in elements)
                    {
                        le.LocationF = new PointF(paperWidth - le.SizeF.Width, le.LocationF.Y);
                    }
                    break;
                case Alignment.Top:
                    foreach (var le in elements)
                    {
                        le.LocationF = new PointF(le.LocationF.X, 0f);
                    }
                    break;
                case Alignment.Bottom:
                    foreach (var le in elements)
                    {
                        le.LocationF = new PointF(le.LocationF.X, paperHeight - le.SizeF.Height);
                    }
                    break;
                case Alignment.Horizontal:
                    float centerHor = paperWidth / 2F;
                    foreach (var le in elements)
                    {
                        le.LocationF = new PointF(centerHor - (le.SizeF.Width / 2F), le.LocationF.Y);
                    }
                    break;
                case Alignment.Vertical:
                    float centerVer = paperHeight / 2F;
                    foreach (var le in elements)
                    {
                        le.LocationF = new PointF(le.LocationF.X, centerVer - (le.SizeF.Height / 2F));
                    }
                    break;
            }
        }

        /// <summary>
        /// Enlarge each element in the group to match the largest one.
        /// </summary>
        public static void MakeSameSize( this List<LayoutElement> elements, Fit axis)
        {
            if (axis == Fit.Width)
            {
                float newWidth = 0;

                foreach (var le in elements)
                {
                    if (le.SizeF.Width > newWidth) newWidth = le.SizeF.Width;
                }

                foreach (var le in elements)
                {
                    le.SizeF = new SizeF(newWidth, le.SizeF.Height);
                }
            }
            else
            {
                float newHeight = 0;

                foreach (var le in elements)
                {
                    if (le.SizeF.Height > newHeight) newHeight = le.SizeF.Height;
                }

                foreach (var le in elements)
                {
                    le.SizeF = new SizeF(le.SizeF.Width, newHeight);
                }
            }
        }

        /// <summary>
        /// Makes all of the input layout elements have the same width or height
        /// </summary>
        public static void FitToPage(this IEnumerable<LayoutElement> elements, Fit axis, Size paperSize)
        {
            if (axis == Fit.Width)
            {
                float newWidth = paperSize.Width;
                foreach (var le in elements)
                {
                    le.SizeF = new SizeF(newWidth, le.SizeF.Height);
                }
            }
            else
            {
                float newHeight = paperSize.Height;
                foreach (var le in elements)
                {
                    le.SizeF = new SizeF(le.SizeF.Width, newHeight);
                }
            }
        }
    }
}