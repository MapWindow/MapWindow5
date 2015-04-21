using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using MW5.Data.Enums;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Data.Repository
{
    internal class FolderItem : MetadataItem<FolderItemMetadata>, IFolderItem
    {
        private const string VectorFormats = "shp|kml|dgn|dxf|gml|mif|tab";
        private const string ImageFormats = "tif|png";
        private const string GridFormats = "asc";
        private const string SearchRegex = @"$(?<=\.({0}))";
        
        private static readonly Regex VectorRegex = new Regex(GetSearchRegex(FormatType.Vector), RegexOptions.IgnoreCase);
        private static readonly Regex ImageRegex = new Regex(GetSearchRegex(FormatType.Raster), RegexOptions.IgnoreCase);
        private static readonly Regex GridRegex = new Regex(GetSearchRegex(FormatType.Grid), RegexOptions.IgnoreCase);


        public FolderItem(TreeNodeAdv node) : base(node)
        {
            
        }

        public string GetPath()
        {
            return Metadata.Path;
        }

        public bool Root
        {
            get { return Metadata.Root; }
        }

        public override void Expand()
        {
            if (_node.ExpandedOnce) return;
            
            string root = GetPath();
            var items = SubItems;
            
            foreach (var path in Directory.EnumerateDirectories(root))
            {
                items.AddFolder(path, false);
            }

            var pattern = new Regex(GetSearchRegex(FormatType.All), RegexOptions.IgnoreCase);
            var files = Directory.EnumerateFiles(root).Where(f => pattern.IsMatch(f));

            foreach (var f in files)
            {
                if (VectorRegex.IsMatch(f))
                {
                    items.AddFileVector(f);
                    continue;
                }

                if (ImageRegex.IsMatch(f) || GridRegex.IsMatch(f))
                {
                    items.AddFileImage(f);
                    continue;
                }
            }

            _node.ExpandedOnce = true;
        }

        private static string GetSearchRegex(FormatType format)
        {
            switch (format)
            {
                case FormatType.All:
                    return string.Format(SearchRegex, VectorFormats + "|" + ImageFormats + "|" + GridFormats);
                case FormatType.Vector:
                    return string.Format(SearchRegex, VectorFormats);
                case FormatType.Raster:
                    return string.Format(SearchRegex, ImageFormats);
                case FormatType.Grid:
                    return string.Format(SearchRegex, GridFormats);
                default:
                    throw new ArgumentOutOfRangeException("format");
            }
        }

        public bool ExpandedOnce
        {
            get { return _node.ExpandedOnce; }
        }
    }
}
