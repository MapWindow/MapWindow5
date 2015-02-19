using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using MapWinGIS;
using MW5.Core.Helpers;
using MW5.Core.Interfaces;

namespace MW5.Core.Concrete
{
    public class LabelsLayer: ILabelsLayer
    {
        private readonly Labels _labels;

        internal LabelsLayer(Labels labels)
        {
            _labels = labels;
            if (labels == null)
            {
                throw new NullReferenceException("Internal reference is null");
            }
        }

        public ILabelStyle Style
        {
            get { return new LabelStyle(_labels.Options); }
        }

        public LabelStyleList Styles
        {
            get { return new LabelStyleList(_labels); }
        }

        public int Generate(string expression, LabelPosition position, bool largestPartOnly = true)
        {
            return _labels.Generate(expression, (tkLabelPositioning) position, largestPartOnly);
        }

        public LabelCollection Items
        {
            get { return new LabelCollection(_labels); }
        }

        public bool AutoOffset
        {
            get { return _labels.AutoOffset; }
            set { _labels.AutoOffset = value; }
        }

        public bool AvoidCollisions
        {
            get { return _labels.AvoidCollisions; }
            set { _labels.AvoidCollisions = value; }
        }

        public double BasicScale
        {
            get { return _labels.BasicScale; }
            set { _labels.BasicScale = value; }
        }

        public int ClassificationField
        {
            get { return _labels.ClassificationField; }
            set { _labels.ClassificationField = value; }
        }

        public int CollisionBuffer
        {
            get { return _labels.CollisionBuffer; }
            set { _labels.CollisionBuffer = value; }
        }

        public bool DynamicVisibility
        {
            get { return _labels.DynamicVisibility; }
            set { _labels.DynamicVisibility = value; }
        }

        public string Expression
        {
            get { return _labels.Expression; }
            set { _labels.Expression = value; }
        }

        public string FloatNumberFormat
        {
            get { return _labels.FloatNumberFormat; }
            set { _labels.FloatNumberFormat = value; }
        }

        public double MaxVisibleScale
        {
            get { return _labels.MaxVisibleScale; }
            set { _labels.MaxVisibleScale = value; }
        }

        public double MinVisibleScale
        {
            get { return _labels.MinVisibleScale; }
            set { _labels.MinVisibleScale = value; }
        }

        public double OffsetX
        {
            get { return _labels.OffsetX; }
            set { _labels.OffsetX = value; }
        }

        public double OffsetY
        {
            get { return _labels.OffsetY; }
            set { _labels.OffsetY = value; }
        }

        public LabelPosition Positioning
        {
            get { return (LabelPosition)_labels.Positioning; }
            set { _labels.Positioning = (tkLabelPositioning)value; }
        }

        public bool RemoveDuplicates
        {
            get { return _labels.RemoveDuplicates; }
            set { _labels.RemoveDuplicates = value; }
        }

        public LabelPersistence SavingMode
        {
            get { return (LabelPersistence)_labels.SavingMode; }
            set { _labels.SavingMode = (tkSavingMode)value; }
        }

        public bool ScaleLabels
        {
            get { return _labels.ScaleLabels; }
            set { _labels.ScaleLabels = value; }
        }

        public bool Synchronized
        {
            get { return _labels.Synchronized; }
            set { _labels.Synchronized = value; }
        }

        public TextRenderingHint TextRenderingHint
        {
            get { return (TextRenderingHint)_labels.TextRenderingHint; }
            set { _labels.TextRenderingHint = (tkTextRenderingHint)value; }
        }

        public VerticalPosition VerticalPosition
        {
            get { return (VerticalPosition)_labels.VerticalPosition; }
            set { _labels.VerticalPosition = (tkVerticalPosition)value; }
        }

        public string VisibilityExpression
        {
            get { return _labels.VisibilityExpression; }
            set { _labels.VisibilityExpression = value; }
        }

        public bool Visible
        {
            get { return _labels.Visible; }
            set { _labels.Visible = value; }
        }

        public IList<LabelInfo> Select(IEnvelope envelope, int tolerance = 0, SelectMode selectMode = SelectMode.INTERSECTION)
        {
            var extents = envelope.GetInternal();
            object indices = null, parts = null;
            if (_labels.Select(extents, tolerance, selectMode, ref indices, ref parts))
            {
                var list = from index in indices as int[]
                    from part in parts as int[]
                    select new LabelInfo
                    {
                        LabelIndex = index,
                        PartIndex = part
                    };
                return list.ToList();
            }
            return new List<LabelInfo>();
        }
    }
}
