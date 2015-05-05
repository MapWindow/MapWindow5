using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Shared;

namespace MW5.Api.Concrete
{
    public class EditorSettings: IMeasuringSettings
    {
        private readonly IShapeEditor _editor;

        internal EditorSettings(IShapeEditor editor)
        {
            if (editor == null) throw new ArgumentNullException("editor");
            _editor = editor;
        }

        public bool ShowBearing
        {
            get { return _editor.ShowBearing; }
            set { _editor.ShowBearing = value; }
        }

        public BearingType BearingType
        {
            get { return (BearingType)_editor.BearingType; }
            set { _editor.BearingType = (tkBearingType)value; }
        }

        public bool ShowLength
        {
            get { return _editor.ShowLength; }
            set { _editor.ShowLength = value; }
        }

        public LengthDisplay LengthUnits
        {
            get { return (LengthDisplay)_editor.LengthDisplayMode; }
            set { _editor.LengthDisplayMode = (tkLengthDisplayMode)value; }
        }

        public AreaDisplay AreaUnits
        {
            get { return (AreaDisplay)_editor.LengthDisplayMode; }
            set { _editor.AreaDisplayMode = (tkAreaDisplayMode)value; }
        }

        public AngleFormat AngleFormat
        {
            get { return (AngleFormat)_editor.AngleFormat; }
            set { _editor.AngleFormat = (tkAngleFormat)value; }
        }

        public int AnglePrecision
        {
            get { return _editor.AnglePrecision; }
            set { _editor.AnglePrecision = value; }
        }

        public int AreaPrecision
        {
            get { return _editor.AnglePrecision; }
            set { _editor.AnglePrecision = value; }
        }

        public int LengthPrecision
        {
            get { return _editor.LengthPrecision; }
            set { _editor.LengthPrecision = value; }
        }

        public bool PointsVisible
        {
            get { return _editor.VerticesVisible; }
            set { _editor.VerticesVisible = value; }
        }

        public Color LineColor
        {
            get { return ColorHelper.UintToColor(_editor.LineColor); }
            set { _editor.LineColor = ColorHelper.ColorToUInt(value); }
        }

        public Color FillColor
        {
            get { return ColorHelper.UintToColor(_editor.FillColor); }
            set { _editor.FillColor = ColorHelper.ColorToUInt(value); }
        }

        public byte FillTransparency
        {
            get { return _editor.FillTransparency; }
            set { _editor.FillTransparency = value; }
        }

        public float LineWidth
        {
            get { return _editor.LineWidth; }
            set { _editor.LineWidth = value; }
        }

        // not implemented by underlying class
        public DashStyle LineStyle
        {
            get { return DashStyle.Solid; }
            set { ; }
        }

        public bool PointLabelsVisible
        {
            get { return _editor.IndicesVisible; }
            set { _editor.IndicesVisible = value; }
        }

        // not implemented by underlying class
        public bool ShowTotalLength
        {
            get { return false; }
            set { ; }
        }
    }
}
