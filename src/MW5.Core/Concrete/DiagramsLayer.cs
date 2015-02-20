using System;
using System.Collections.Generic;
using System.Drawing;
using MapWinGIS;
using MW5.Core.Helpers;
using MW5.Core.Interfaces;

namespace MW5.Core.Concrete
{
    public class DiagramsLayer: ISerializableComWrapper
    {
        private readonly Charts _charts;

        public DiagramsLayer(Charts charts)
        {
            _charts = charts;
            if (charts == null)
            {
                throw new NullReferenceException("Internal reference is null");
            }
        }

        public object InternalObject
        {
            get { return _charts; }
        }

        public string LastError
        {
            get { return _charts.ErrorMsg[_charts.LastErrorCode]; }
        }

        public string Tag
        {
            get { return _charts.Key; }
            set { _charts.Key = value; }
        }

        public DiagramFieldCollection Field
        {
            get { return new DiagramFieldCollection(_charts); }
        }

        public bool Generate(LabelPosition position)
        {
            return _charts.Generate((tkLabelPositioning)position);
        }

        public void Clear()
        {
            _charts.Clear();
        }

        public int[] Select(IEnvelope envelope, int tolerance, SelectionMode selectMode)
        {
            object indices = null;
            if (_charts.Select(envelope.GetInternal(), tolerance, (SelectMode) selectMode, ref indices))
            {
                return indices as int[];
            }
            return null;
        }

        public string Serialize()
        {
            return _charts.Serialize();
        }

        public bool Deserialize(string newVal)
        {
            _charts.Deserialize(newVal);
            return true;
        }

        public bool SaveToXml(string filename)
        {
            return _charts.SaveToXML(filename);
        }

        public bool LoadFromXml(string filename)
        {
            return _charts.LoadFromXML(filename);
        }

        public bool Visible
        {
            get { return _charts.Visible; }
            set { _charts.Visible = value; }
        }

        public bool AvoidCollisions
        {
            get { return _charts.AvoidCollisions; }
            set { _charts.AvoidCollisions = value; }
        }

        public DiagramType DiagramType
        {
            get { return (DiagramType)_charts.ChartType; }
            set { _charts.ChartType = (tkChartType)value; }
        }

        public int BarWidth
        {
            get { return _charts.BarWidth; }
            set { _charts.BarWidth = value; }
        }

        public int BarHeight
        {
            get { return _charts.BarHeight; }
            set { _charts.BarHeight = value; }
        }

        public int PieRadius
        {
            get { return _charts.PieRadius; }
            set { _charts.PieRadius = value; }
        }

        public double PieRotation
        {
            get { return _charts.PieRotation; }
            set { _charts.PieRotation = value; }
        }

        public double Tilt
        {
            get { return _charts.Tilt; }
            set { _charts.Tilt = value; }
        }

        public double Thickness
        {
            get { return _charts.Thickness; }
            set { _charts.Thickness = value; }
        }

        public int PieRadius2
        {
            get { return _charts.PieRadius2; }
            set { _charts.PieRadius2 = value; }
        }

        public int SizeField
        {
            get { return _charts.SizeField; }
            set { _charts.SizeField = value; }
        }

        public int NormalizationField
        {
            get { return _charts.NormalizationField; }
            set { _charts.NormalizationField = value; }
        }

        public bool UseVariableRadius
        {
            get { return _charts.UseVariableRadius; }
            set { _charts.UseVariableRadius = value; }
        }

        public bool Use3DMode
        {
            get { return _charts.Use3DMode; }
            set { _charts.Use3DMode = value; }
        }

        public byte AlphaTransparency
        {
            get { return (byte)_charts.Transparency; }
            set { _charts.Transparency = value; }
        }

        public Color LineColor
        {
            get { return ColorHelper.UintToColor(_charts.LineColor); }
            set { _charts.LineColor = ColorHelper.ColorToUInt(value); }
        }

        public VerticalPosition VerticalPosition
        {
            get { return (VerticalPosition)_charts.VerticalPosition; }
            set { _charts.VerticalPosition = (tkVerticalPosition)value; }
        }

        public Diagram this[int index]
        {
            get
            {
                var chart = _charts.Chart[index];
                return chart != null ? new Diagram(chart) : null;
            }
        }

        public int Count
        {
            get { return _charts.Count; }
        }

        public double MaxVisibleScale
        {
            get { return _charts.MaxVisibleScale; }
            set { _charts.MaxVisibleScale = value; }
        }

        public double MinVisibleScale
        {
            get { return _charts.MinVisibleScale; }
            set { _charts.MinVisibleScale = value; }
        }

        public bool DynamicVisibility
        {
            get { return _charts.DynamicVisibility; }
            set { _charts.DynamicVisibility = value; }
        }

        public int IconWidth
        {
            get { return _charts.IconWidth; }
        }

        public int IconHeight
        {
            get { return _charts.IconHeight; }
        }

        public string Caption
        {
            get { return _charts.Caption; }
            set { _charts.Caption = value; }
        }

        public string ValuesFontName
        {
            get { return _charts.ValuesFontName; }
            set { _charts.ValuesFontName = value; }
        }

        public int ValuesFontSize
        {
            get { return _charts.ValuesFontSize; }
            set { _charts.ValuesFontSize = value; }
        }

        public bool ValuesFontItalic
        {
            get { return _charts.ValuesFontItalic; }
            set { _charts.ValuesFontItalic = value; }
        }

        public bool ValuesFontBold
        {
            get { return _charts.ValuesFontBold; }
            set { _charts.ValuesFontBold = value; }
        }

        public Color ValuesFontColor
        {
            get { return ColorHelper.UintToColor(_charts.ValuesFontColor); }
            set { _charts.ValuesFontColor = ColorHelper.ColorToUInt(value); }
        }

        public bool ValuesFrameVisible
        {
            get { return _charts.ValuesFrameVisible; }
            set { _charts.ValuesFrameVisible = value; }
        }

        public Color ValuesFrameColor
        {
            get { return ColorHelper.UintToColor(_charts.ValuesFrameColor); }
            set { _charts.ValuesFrameColor = ColorHelper.ColorToUInt(value); }
        }

        public bool ValuesVisible
        {
            get { return _charts.ValuesVisible; }
            set { _charts.ValuesVisible = value; }
        }

        public DiagramValuesStyle ValuesStyle
        {
            get { return (DiagramValuesStyle)_charts.ValuesStyle; }
            set { _charts.ValuesStyle = (tkChartValuesStyle)value; }
        }

        public string VisibilityExpression
        {
            get { return _charts.VisibilityExpression; }
            set { _charts.VisibilityExpression = value; }
        }

        public int CollisionBuffer
        {
            get { return _charts.CollisionBuffer; }
            set { _charts.CollisionBuffer = value; }
        }

        public int OffsetX
        {
            get { return _charts.OffsetX; }
            set { _charts.OffsetX = value; }
        }

        public int OffsetY
        {
            get { return _charts.OffsetY; }
            set { _charts.OffsetY = value; }
        }

        public PersistenceType SavingMode
        {
            get { return (PersistenceType)_charts.SavingMode; }
            set { _charts.SavingMode = (tkSavingMode)value; }
        }

        #region Not implemented

        //public bool DrawChart(IntPtr hDC, float x, float y, bool hideLabels, uint backColor = 16777215)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion
    }
}
