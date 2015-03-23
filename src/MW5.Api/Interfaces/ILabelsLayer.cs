using System.Drawing.Text;
using MW5.Api.Concrete;

namespace MW5.Api.Interfaces
{
    public interface ILabelsLayer: ISerializableComWrapper
    {
        bool Empty { get; }

        ILabelStyle Style { get; set;  }
        
        LabelStyleList Styles { get; }

        int Generate(string expression, LabelPosition position, bool largestPartOnly = true);

        LabelCollection Items { get; }

        bool AutoOffset { get; set; }

        bool AvoidCollisions { get; set; }

        double BasicScale { get; set; }

        int ClassificationField { get; set; }

        int CollisionBuffer { get; set; }

        bool DynamicVisibility { get; set; }

        string Expression { get; set; }

        string FloatNumberFormat { get; set; }

        double MaxVisibleScale { get; set; }

        double MinVisibleScale { get; set; }

        double OffsetX { get; set; }
        
        double OffsetY { get; set; }

        LabelPosition Positioning { get; set; }

        bool RemoveDuplicates { get; set; }

        PersistenceType SavingMode { get; set; }

        bool ScaleLabels { get; set; }

        bool Synchronized { get; set; }

        TextRenderingHint TextRenderingHint { get; set; }

        VerticalPosition VerticalPosition { get; set; }

        string VisibilityExpression { get; set; }

        bool Visible { get; set; }

        //IList<LabelInfo> Select(IEnvelope envelope, int tolerance = 0, SelectMode selectMode = SelectMode.INTERSECTION);

        //void ForceRecalculateExpression();

        //bool LoadFromDbf(bool loadText = false, bool loadCategory = false);

        //bool LoadFromDbf2(string xField = "_LabelX", string yField = "_LabelY", string angleField = "_LabelAngle", string textField = "_LabelText", string categoryField = "_LabelCtg", bool loadText = false, bool loadCategory = false);

        //bool LoadFromXML(string Filename);

        //bool SaveToDbf(bool saveText = false, bool saveCategory = false);

        //bool SaveToDbf2(string xField = "_LabelX", string yField = "_LabelY", string angleField = "_LabelAngle", string textField = "_LabelText", string categoryField = "_LabelCtg", bool saveText = false, bool saveCategory = false);

        //bool SaveToXML(string Filename);
    }
}
