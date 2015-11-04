// -------------------------------------------------------------------------------------------
// <copyright file="LayoutSerializerOld.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Globalization;
using System.Xml;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Plugins.Printing.Controls.Layout;
using MW5.Plugins.Printing.Enums;
using MW5.Plugins.Printing.Model.Elements;
using MW5.Plugins.Services;

namespace MW5.Plugins.Printing.Legacy
{
    public static class LayoutSerializerOld
    {
        /// <summary>
        /// Loads the selected layoutfile
        /// </summary>
        /// <param name="fileName">The layout file to load</param>
        /// <param name="loadPaperSettings">Loads the paper settings (size, margins, orientation) from the layout</param>
        /// <param name="promptPaperMismatch">Warn the user if the paper size stored in the file doesn't exist in current printer and ask them if they want to load it anyways</param>
        /// <param name="layoutControl"></param>
        /// <param name="_printerSettings"></param>
        public static List<LayoutElement> LoadLayout(
            string fileName,
            bool loadPaperSettings,
            bool promptPaperMismatch,
            LayoutControl layoutControl,
            PrinterSettings _printerSettings)
        {
            //Open the model xml document
            var layoutXmlDoc = new XmlDocument();
            layoutXmlDoc.Load(fileName);
            var root = layoutXmlDoc.DocumentElement;

            //Temporarily stores all the elements and settings until the whole XML file is parsed
            var loadList = new List<LayoutElement>();
            bool paperSizeSupported = false;
            PaperSize savedPaperSize = null;
            bool savedLandscape = true;
            Margins savedMargins = null;

            //Makes sure we are really loading a DotSpatial layout file
            if (root != null && root.Name == "DotSpatialLayout")
            {
                //This creates instances of all the elements
                var child = root.LastChild;
                while (child != null)
                {
                    if (child.Name == "Element")
                    {
                        LayoutElement newLe = null;
                        switch (child.ChildNodes[0].Name)
                        {
                            case "Bitmap":
                                newLe = new LayoutBitmap();
                                break;
                            case "Legend":
                                // TODO: implement
                                //newLe = new LayoutLegend();
                                break;
                            case "Map":
                                // TODO: implement
                                //newLe = new LayoutMap();
                                break;
                            case "NorthArrow":
                                newLe = new LayoutNorthArrow();
                                break;
                            case "Rectangle":
                                newLe = new LayoutRectangle();
                                break;
                            case "ScaleBar":
                                newLe = new LayoutScaleBar();
                                break;
                            case "Text":
                                newLe = new LayoutText();
                                break;
                            case "Table":
                                newLe = new LayoutTable();
                                break;
                                //case "GeometryTable":
                                //    newLe = new LayoutGeometryTable();
                                //    break;
                        }

                        if (newLe != null)
                        {
                            //var attr = child.Attributes["Type"];
                            //if (attr != null)  newLe.Type = (Type) Enum.Parse(typeof(Type), attr.Value);

                            var attr = child.Attributes["Visible"];
                            if (attr != null) newLe.Visible = Convert.ToBoolean(attr.Value);

                            newLe.Name = child.Attributes["Name"].Value;
                            newLe.Invalidated += layoutControl.LeInvalidated;
                            newLe.Rectangle =
                                new RectangleF(
                                    float.Parse(child.Attributes["RectangleX"].Value, CultureInfo.InvariantCulture),
                                    float.Parse(child.Attributes["RectangleY"].Value, CultureInfo.InvariantCulture),
                                    float.Parse(child.Attributes["RectangleWidth"].Value, CultureInfo.InvariantCulture),
                                    float.Parse(child.Attributes["RectangleHeight"].Value, CultureInfo.InvariantCulture));
                            newLe.ResizeStyle =
                                (ResizeStyle)Enum.Parse(typeof(ResizeStyle), child.Attributes["ResizeStyle"].Value);
                            //if (child.Attributes["Background"] != null)
                            //    newLe.Background = backDeserializer.Deserialize<PolygonSymbolizer>(child.Attributes["Background"].Value);     // TODO: restore
                            loadList.Insert(0, newLe);
                        }
                    }
                    else if (child.Name == "Paper" && loadPaperSettings)
                    {
                        //Loads printer paper size
                        //gets the name of the paper size
                        string paperName = child.Attributes["Name"].Value;

                        //Find out if it supports the paper size in the layout file
                        var availableSizes = _printerSettings.PaperSizes;
                        foreach (PaperSize testSize in availableSizes)
                        {
                            if (testSize.PaperName == paperName)
                            {
                                savedPaperSize = testSize;
                                paperSizeSupported = true;
                                break;
                            }
                        }

                        //If needed prompt the user due to a paper size mismatch
                        if (!paperSizeSupported && promptPaperMismatch)
                        {
                            string msg = "The selected printer \"" + _printerSettings.PrinterName +
                                         "\"\ndoes not support paper format \"" + paperName +
                                         "\" set in the layout.\n\nLoad layout with parameters of the current printer?";

                            if (!MessageService.Current.Ask(msg))
                            {
                                return loadList;
                            }
                        }
                        else
                        {
                            savedLandscape =
                                (bool)
                                TypeDescriptor.GetConverter(typeof(bool))
                                    .ConvertFromInvariantString(child.Attributes["Landscape"].Value);
                            savedMargins =
                                (Margins)
                                TypeDescriptor.GetConverter(typeof(Margins))
                                    .ConvertFromInvariantString(child.Attributes["Margins"].Value);
                        }
                    }
                    child = child.PreviousSibling;
                }

                //Since some of the elements may be dependant on elements already being added we add their other properties after we add them all
                child = root.LastChild;
                for (int i = loadList.Count - 1; i >= 0; i--)
                {
                    if (child != null)
                    {
                        var innerChild = child.ChildNodes[0];
                        if (loadList[i] is LayoutBitmap)
                        {
                            var lb = loadList[i] as LayoutBitmap;
                            if (lb != null)
                            {
                                lb.Filename = innerChild.Attributes["Filename"].Value;
                                lb.PreserveAspectRatio =
                                    Convert.ToBoolean(innerChild.Attributes["PreserveAspectRatio"].Value);
                                lb.Draft = Convert.ToBoolean(innerChild.Attributes["Draft"].Value);
                                if (innerChild.Attributes["Brightness"] != null)
                                    lb.Brightness =
                                        (int)
                                        TypeDescriptor.GetConverter(typeof(int))
                                            .ConvertFromInvariantString(innerChild.Attributes["Brightness"].Value);
                                if (innerChild.Attributes["Contrast"] != null)
                                    lb.Contrast =
                                        (int)
                                        TypeDescriptor.GetConverter(typeof(int))
                                            .ConvertFromInvariantString(innerChild.Attributes["Contrast"].Value);
                            }
                        }
                        else if (loadList[i] is LayoutLegend)
                        {
                            var ll = loadList[i] as LayoutLegend;
                            if (ll != null)
                            {
                                ll.LayoutControl = layoutControl;
                                ll.TextHint =
                                    (TextRenderingHint)
                                    Enum.Parse(typeof(TextRenderingHint), innerChild.Attributes["TextHint"].Value);
                                ll.Color =
                                    (Color)
                                    TypeDescriptor.GetConverter(typeof(Color))
                                        .ConvertFromInvariantString(innerChild.Attributes["Color"].Value);
                                ll.Font =
                                    (Font)
                                    TypeDescriptor.GetConverter(typeof(Font))
                                        .ConvertFromInvariantString(innerChild.Attributes["Font"].Value);
                            }
                            int mapIndex = Convert.ToInt32(innerChild.Attributes["Map"].Value);
                            if (mapIndex >= 0) if (ll != null) ll.Map = loadList[mapIndex] as LayoutMap;
                            string layStr = innerChild.Attributes["Layers"].Value;
                            var layers = new List<int>();
                            while (layStr.EndsWith("|"))
                            {
                                layStr = layStr.TrimEnd("|".ToCharArray());
                                layers.Add(
                                    (int)
                                    TypeDescriptor.GetConverter(typeof(int))
                                        .ConvertFromInvariantString(layStr.Substring(layStr.LastIndexOf("|") + 1)));
                                layStr = layStr.Substring(0, layStr.LastIndexOf("|") + 1);
                            }
                            if (ll != null)
                            {
                                ll.NumColumns =
                                    (int)
                                    TypeDescriptor.GetConverter(typeof(int))
                                        .ConvertFromInvariantString(innerChild.Attributes["NumColumns"].Value);
                                ll.Layers = layers;
                            }
                        }
                        else if (loadList[i] is LayoutMap)
                        {
                            var lm = loadList[i] as LayoutMap;
                            var env = new Envelope();

                            double minX =
                                (double)
                                TypeDescriptor.GetConverter(typeof(double))
                                    .ConvertFromInvariantString(innerChild.Attributes["EnvelopeXmin"].Value);
                            double minY =
                                (double)
                                TypeDescriptor.GetConverter(typeof(double))
                                    .ConvertFromInvariantString(innerChild.Attributes["EnvelopeYmin"].Value);
                            double maxX =
                                (double)
                                TypeDescriptor.GetConverter(typeof(double))
                                    .ConvertFromInvariantString(innerChild.Attributes["EnvelopeXmax"].Value);
                            double maxY =
                                (double)
                                TypeDescriptor.GetConverter(typeof(double))
                                    .ConvertFromInvariantString(innerChild.Attributes["EnvelopeYmax"].Value);

                            if (lm != null) lm.Envelope = env;
                            var attr = innerChild.Attributes["DrawTiles"];
                            if (attr != null)
                                lm.DrawTiles =
                                    (bool)
                                    TypeDescriptor.GetConverter(typeof(bool)).ConvertFromInvariantString(attr.Value);

                            attr = innerChild.Attributes["UpdateMapArea"];
                            if (attr != null)
                                lm.UpdateMapArea =
                                    (bool)
                                    TypeDescriptor.GetConverter(typeof(bool)).ConvertFromInvariantString(attr.Value);

                            attr = innerChild.Attributes["MainMap"];
                            if (attr != null)
                                lm.MainMap =
                                    (bool)
                                    TypeDescriptor.GetConverter(typeof(bool)).ConvertFromInvariantString(attr.Value);

                            lm.MarkInitialized();
                        }
                        else if (loadList[i] is LayoutNorthArrow)
                        {
                            var na = loadList[i] as LayoutNorthArrow;
                            if (na != null)
                            {
                                na.Color =
                                    (Color)
                                    TypeDescriptor.GetConverter(typeof(Color))
                                        .ConvertFromInvariantString(innerChild.Attributes["Color"].Value);
                                na.NorthArrowStyle =
                                    (NorthArrowStyle)
                                    Enum.Parse(typeof(NorthArrowStyle), innerChild.Attributes["Style"].Value);
                                if (innerChild.Attributes["Rotation"] != null)
                                    na.Rotation =
                                        (float)
                                        TypeDescriptor.GetConverter(typeof(float))
                                            .ConvertFromInvariantString(innerChild.Attributes["Rotation"].Value);
                            }
                        }
                        else if (loadList[i] is LayoutRectangle)
                        {
                            var lr = loadList[i] as LayoutRectangle;
                            if (lr != null)
                            {
                                //This code is to load legacy layouts that had properties for the color/outline of rectangles
                                if (innerChild.Attributes["Color"] != null && innerChild.Attributes["BackColor"] != null &&
                                    innerChild.Attributes["OutlineWidth"] != null)
                                {
                                    var tempOutlineColor =
                                        (Color)
                                        TypeDescriptor.GetConverter(typeof(Color))
                                            .ConvertFromInvariantString(innerChild.Attributes["Color"].Value);
                                    var tempBackColor =
                                        (Color)
                                        TypeDescriptor.GetConverter(typeof(Color))
                                            .ConvertFromInvariantString(innerChild.Attributes["BackColor"].Value);
                                    int tempOutlineWidth =
                                        (int)
                                        TypeDescriptor.GetConverter(typeof(int))
                                            .ConvertFromInvariantString(innerChild.Attributes["OutlineWidth"].Value);
                                    //lr.Background = new PolygonSymbolizer(tempBackColor, tempOutlineColor, tempOutlineWidth);
                                }
                            }
                        }
                        else if (loadList[i] is LayoutScaleBar)
                        {
                            var lsc = loadList[i] as LayoutScaleBar;
                            if (lsc != null)
                            {
                                lsc.LayoutControl = layoutControl;
                                lsc.TextHint =
                                    (TextRenderingHint)
                                    Enum.Parse(typeof(TextRenderingHint), innerChild.Attributes["TextHint"].Value);
                                lsc.Color =
                                    (Color)
                                    TypeDescriptor.GetConverter(typeof(Color))
                                        .ConvertFromInvariantString(innerChild.Attributes["Color"].Value);
                                lsc.Font =
                                    (Font)
                                    TypeDescriptor.GetConverter(typeof(Font))
                                        .ConvertFromInvariantString(innerChild.Attributes["Font"].Value);
                                lsc.BreakBeforeZero = Convert.ToBoolean(innerChild.Attributes["BreakBeforeZero"].Value);
                                lsc.NumberOfBreaks =
                                    (int)
                                    TypeDescriptor.GetConverter(typeof(int))
                                        .ConvertFromInvariantString(innerChild.Attributes["NumberOfBreaks"].Value);
                                lsc.Unit =
                                    (LengthUnits)Enum.Parse(typeof(LengthUnits), innerChild.Attributes["Unit"].Value);
                                lsc.UnitText = innerChild.Attributes["UnitText"].Value;
                            }
                            int mapIndex = Convert.ToInt32(innerChild.Attributes["Map"].Value);
                            if (mapIndex >= 0) if (lsc != null) lsc.Map = loadList[mapIndex] as LayoutMap;
                        }
                        else if (loadList[i] is LayoutText)
                        {
                            var lt = loadList[i] as LayoutText;
                            if (lt != null)
                            {
                                lt.TextHint =
                                    (TextRenderingHint)
                                    Enum.Parse(typeof(TextRenderingHint), innerChild.Attributes["TextHint"].Value);
                                lt.Color =
                                    (Color)
                                    TypeDescriptor.GetConverter(typeof(Color))
                                        .ConvertFromInvariantString(innerChild.Attributes["Color"].Value);
                                lt.Font =
                                    (Font)
                                    TypeDescriptor.GetConverter(typeof(Font))
                                        .ConvertFromInvariantString(innerChild.Attributes["Font"].Value);
                                lt.ContentAlignment =
                                    (ContentAlignment)
                                    TypeDescriptor.GetConverter(typeof(ContentAlignment))
                                        .ConvertFromString(innerChild.Attributes["ContentAlignment"].Value);
                                lt.Text = innerChild.Attributes["Text"].Value;
                            }
                        }
                        else if (loadList[i] is LayoutTable)
                        {
                            var lt = loadList[i] as LayoutTable;

                            lt.DisplayHeader = Convert.ToBoolean(innerChild.Attributes["DisplayHeader"].Value);
                            lt.Font =
                                (Font)
                                TypeDescriptor.GetConverter(typeof(Font))
                                    .ConvertFromInvariantString(innerChild.Attributes["Font"].Value);
                            lt.HeaderFont =
                                (Font)
                                TypeDescriptor.GetConverter(typeof(Font))
                                    .ConvertFromInvariantString(innerChild.Attributes["HeaderFont"].Value);
                            lt.HorizontalPadding =
                                (int)
                                TypeDescriptor.GetConverter(typeof(int))
                                    .ConvertFromInvariantString(innerChild.Attributes["HorizontalPadding"].Value);
                            lt.MinRowHeight =
                                (int)
                                TypeDescriptor.GetConverter(typeof(int))
                                    .ConvertFromInvariantString(innerChild.Attributes["MinRowHeight"].Value);
                            lt.Data.DeserializeData(innerChild.Attributes["Data"].Value);
                            lt.Data.DeserializeColumns(innerChild.Attributes["Columns"].Value);

                            //var gt = loadList[i] as LayoutGeometryTable;
                            //if (gt != null)
                            //{
                            //    int val = (int) TypeDescriptor.GetConverter(typeof(int))
                            //           .ConvertFromInvariantString(innerChild.Attributes["Arrangement"].Value);
                            //    gt.TableArrangement = (TableArrangement)val;
                            //}
                        }
                    }
                    if (child != null) child = child.PreviousSibling;
                }

                //Loads the papersize if supported and needed
                if (paperSizeSupported)
                {
                    _printerSettings.DefaultPageSettings.PaperSize = savedPaperSize;
                    _printerSettings.DefaultPageSettings.Landscape = savedLandscape;
                    _printerSettings.DefaultPageSettings.Margins = savedMargins;
                }
            }
            return loadList;
        }

        /// <summary>
        /// Saves the layout to the specified fileName
        /// </summary>
        public static bool SaveLayout(
            string fileName,
            PrinterSettings printerSettings,
            List<LayoutElement> layoutElements)
        {
            //Creates the model xml document
            var layoutXmlDoc = new XmlDocument();
            var root = layoutXmlDoc.CreateElement("DotSpatialLayout");
            layoutXmlDoc.AppendChild(root);

            //Saves the printer paper settings
            var paperElement = layoutXmlDoc.CreateElement("Paper");
            paperElement.SetAttribute("Name", printerSettings.DefaultPageSettings.PaperSize.PaperName);

            paperElement.SetAttribute("Landscape",
                TypeDescriptor.GetConverter(typeof(bool))
                    .ConvertToInvariantString(printerSettings.DefaultPageSettings.Landscape));
            paperElement.SetAttribute("Margins",
                TypeDescriptor.GetConverter(typeof(Margins))
                    .ConvertToInvariantString(printerSettings.DefaultPageSettings.Margins));
            root.AppendChild(paperElement);

            //Saves the Tools and their output configuration to the model
            foreach (var le in layoutElements)
            {
                var element = layoutXmlDoc.CreateElement("Element");
                element.SetAttribute("Name", le.Name);
                element.SetAttribute("Visible", le.Visible.ToString());

                if (le is LayoutBitmap)
                {
                    var lb = le as LayoutBitmap;
                    var bitmap = layoutXmlDoc.CreateElement("Bitmap");
                    bitmap.SetAttribute("Filename", lb.Filename);
                    bitmap.SetAttribute("PreserveAspectRatio", lb.PreserveAspectRatio.ToString());
                    bitmap.SetAttribute("Draft", lb.Draft.ToString());
                    bitmap.SetAttribute("Brightness",
                        TypeDescriptor.GetConverter(typeof(int)).ConvertToInvariantString(lb.Brightness));
                    bitmap.SetAttribute("Contrast",
                        TypeDescriptor.GetConverter(typeof(int)).ConvertToInvariantString(lb.Contrast));
                    element.AppendChild(bitmap);
                }
                else if (le is LayoutTable)
                {
                    var lt = le as LayoutTable;
                    const string name = "Table";
                    var table = layoutXmlDoc.CreateElement(name);
                    table.SetAttribute("DisplayHeader", lt.DisplayHeader.ToString());
                    table.SetAttribute("Font",
                        TypeDescriptor.GetConverter(typeof(Font)).ConvertToInvariantString(lt.Font));
                    table.SetAttribute("HeaderFont",
                        TypeDescriptor.GetConverter(typeof(Font)).ConvertToInvariantString(lt.HeaderFont));
                    table.SetAttribute("HorizontalPadding",
                        TypeDescriptor.GetConverter(typeof(int)).ConvertToInvariantString(lt.HorizontalPadding));
                    table.SetAttribute("MinRowHeight",
                        TypeDescriptor.GetConverter(typeof(int)).ConvertToInvariantString(lt.MinRowHeight));
                    table.SetAttribute("Data", lt.Data.SerializeData());
                    table.SetAttribute("Columns", lt.Data.SerializeColumns());

                    element.AppendChild(table);
                }
                else if (le is LayoutLegend)
                {
                    var ll = le as LayoutLegend;
                    var legend = layoutXmlDoc.CreateElement("Legend");
                    legend.SetAttribute("TextHint", ll.TextHint.ToString());
                    legend.SetAttribute("Color",
                        TypeDescriptor.GetConverter(typeof(Color)).ConvertToInvariantString(ll.Color));
                    legend.SetAttribute("Font",
                        TypeDescriptor.GetConverter(typeof(Font)).ConvertToInvariantString(ll.Font));
                    legend.SetAttribute("GroupFont",
                        TypeDescriptor.GetConverter(typeof(Font)).ConvertToInvariantString(ll.GroupFont));
                    legend.SetAttribute("Map", layoutElements.IndexOf(ll.Map).ToString());
                    string layerString = string.Empty;
                    foreach (int i in ll.Layers)
                    {
                        layerString = layerString + TypeDescriptor.GetConverter(typeof(int)).ConvertToInvariantString(i) +
                                      "|";
                    }
                    legend.SetAttribute("Layers", layerString);
                    legend.SetAttribute("NumColumns",
                        TypeDescriptor.GetConverter(typeof(int)).ConvertToInvariantString(ll.NumColumns));
                    element.AppendChild(legend);
                }
                else if (le is LayoutMap)
                {
                    var lm = le as LayoutMap;
                    var map = layoutXmlDoc.CreateElement("Map");
                    map.SetAttribute("EnvelopeXmin",
                        TypeDescriptor.GetConverter(typeof(double)).ConvertToInvariantString(lm.Envelope.MinX));
                    map.SetAttribute("EnvelopeYmin",
                        TypeDescriptor.GetConverter(typeof(double)).ConvertToInvariantString(lm.Envelope.MinY));
                    map.SetAttribute("EnvelopeXmax",
                        TypeDescriptor.GetConverter(typeof(double)).ConvertToInvariantString(lm.Envelope.MaxX));
                    map.SetAttribute("EnvelopeYmax",
                        TypeDescriptor.GetConverter(typeof(double)).ConvertToInvariantString(lm.Envelope.MaxY));
                    map.SetAttribute("DrawTiles",
                        TypeDescriptor.GetConverter(typeof(bool)).ConvertToInvariantString(lm.DrawTiles));
                    map.SetAttribute("MainMap",
                        TypeDescriptor.GetConverter(typeof(bool)).ConvertToInvariantString(lm.MainMap));
                    map.SetAttribute("UpdateMapArea",
                        TypeDescriptor.GetConverter(typeof(bool)).ConvertToInvariantString(lm.UpdateMapArea));
                    element.AppendChild(map);
                }
                else if (le is LayoutNorthArrow)
                {
                    var na = le as LayoutNorthArrow;
                    var northArrow = layoutXmlDoc.CreateElement("NorthArrow");
                    northArrow.SetAttribute("Color",
                        TypeDescriptor.GetConverter(typeof(Color)).ConvertToInvariantString(na.Color));
                    northArrow.SetAttribute("Style", na.NorthArrowStyle.ToString());
                    northArrow.SetAttribute("Rotation",
                        TypeDescriptor.GetConverter(typeof(float)).ConvertToInvariantString(na.Rotation));
                    element.AppendChild(northArrow);
                }
                else if (le is LayoutRectangle)
                {
                    // is this missing a few SetAttribute commands?
                    //LayoutRectangle lr = le as LayoutRectangle;
                    var rectangle = layoutXmlDoc.CreateElement("Rectangle");
                    element.AppendChild(rectangle);
                }
                else if (le is LayoutScaleBar)
                {
                    var lsc = le as LayoutScaleBar;
                    var scaleBar = layoutXmlDoc.CreateElement("ScaleBar");
                    scaleBar.SetAttribute("TextHint", lsc.TextHint.ToString());
                    scaleBar.SetAttribute("Color",
                        TypeDescriptor.GetConverter(typeof(Color)).ConvertToInvariantString(lsc.Color));
                    scaleBar.SetAttribute("Font",
                        TypeDescriptor.GetConverter(typeof(Font)).ConvertToInvariantString(lsc.Font));
                    scaleBar.SetAttribute("BreakBeforeZero", lsc.BreakBeforeZero.ToString());
                    scaleBar.SetAttribute("NumberOfBreaks", lsc.NumberOfBreaks.ToString());
                    scaleBar.SetAttribute("Unit", lsc.Unit.ToString());
                    scaleBar.SetAttribute("UnitText", lsc.UnitText);
                    scaleBar.SetAttribute("Map", layoutElements.IndexOf(lsc.Map).ToString());
                    element.AppendChild(scaleBar);
                }
                else if (le is LayoutText)
                {
                    var lt = le as LayoutText;
                    var layoutText = layoutXmlDoc.CreateElement("Text");
                    layoutText.SetAttribute("TextHint", lt.TextHint.ToString());
                    layoutText.SetAttribute("Color",
                        TypeDescriptor.GetConverter(typeof(Color)).ConvertToInvariantString(lt.Color));
                    layoutText.SetAttribute("Font",
                        TypeDescriptor.GetConverter(typeof(Font)).ConvertToInvariantString(lt.Font));
                    layoutText.SetAttribute("ContentAlignment", lt.ContentAlignment.ToString());
                    layoutText.SetAttribute("Text", lt.Text);
                    element.AppendChild(layoutText);
                }

                element.SetAttribute("RectangleX",
                    TypeDescriptor.GetConverter(typeof(float)).ConvertToInvariantString(le.Rectangle.X));
                element.SetAttribute("RectangleY",
                    TypeDescriptor.GetConverter(typeof(float)).ConvertToInvariantString(le.Rectangle.Y));
                element.SetAttribute("RectangleWidth",
                    TypeDescriptor.GetConverter(typeof(float)).ConvertToInvariantString(le.Rectangle.Width));
                element.SetAttribute("RectangleHeight",
                    TypeDescriptor.GetConverter(typeof(float)).ConvertToInvariantString(le.Rectangle.Height));
                //element.SetAttribute("Background", backSerializer.Serialize(le.Background));          // TODO: restore
                element.SetAttribute("ResizeStyle", le.ResizeStyle.ToString());
                root.AppendChild(element);
            }

            layoutXmlDoc.Save(fileName);
            return true;
        }
    }
}