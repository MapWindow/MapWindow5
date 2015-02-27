using System.Collections.Generic;
using MW5.Api.Concrete;

namespace MW5.Api.Interfaces
{
    public interface IFeatureCategoryList : IList<IFeatureCategory>, ISerializableComWrapper
    {
        int IndexByName(string categoryName);

        string Caption { get; set; }

        string ClassificationField { get; set; }

        bool AddRange(int fieldIndex, Classification classification, int numClasses, object minValue, object maxValue);

        void ApplyColorRamp(ColorRampType type, ColorRamp colorScheme);

        void ApplyColorRamp(ColorRampType type, ColorRamp colorScheme, StyleElement shapeElement);

        void ApplyColorRamp(ColorRampType type, ColorRamp colorScheme, StyleElement shapeElement,
                                int categoryStartIndex, int categoryEndIndex);

        void ApplyExpression(int categoryIndex);

        void ApplyExpressions();

        bool Generate(int fieldIndex, Classification classification, int numClasses);

        bool Generate(string fieldName, Classification classification, int numClasses);

        bool GenerateUniqueValues(string fieldName);

        bool GenerateUniqueValues(int fieldIndex);

        bool GeneratePolygonColors(ColorRamp scheme = null);

        bool MoveDown(int index);

        bool MoveUp(int index);
    }
}
