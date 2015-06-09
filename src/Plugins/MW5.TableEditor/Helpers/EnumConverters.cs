using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Shared;
using MW5.UI.Helpers;

namespace MW5.Plugins.TableEditor.Helpers
{
    public class AttributeTypeConverter : IEnumConverter<AttributeType>
    {
        public string GetString(AttributeType value)
        {
            switch (value)
            {
                case AttributeType.String:
                    return "String";
                case AttributeType.Integer:
                    return "Integer";
                case AttributeType.Double:
                    return "Double";
            }
            return "Not defined";
        }
    }

    public class CalculatorFunctionConverter : IEnumConverter<CalculatorFunction>
    {
        public string GetString(CalculatorFunction value)
        {
            switch (value)
            {
                case CalculatorFunction.Shapes:
                    return "Shapes";
                case CalculatorFunction.Operators:
                    return "Operators";
                case CalculatorFunction.Booleans:
                    return "Boolean";
                case CalculatorFunction.Maths:
                    return "Math";
                case CalculatorFunction.Angles:
                    return "Angles";
                case CalculatorFunction.Statistics:
                    return "Statistics";
                case CalculatorFunction.Time:
                    return "Time";
                case CalculatorFunction.Other:
                    return "Other";
                case CalculatorFunction.Constants:
                    return "Constants";
            }
            return string.Empty;
        }
    }

    public class SearchDirectionConverter : IEnumConverter<SearchDirection>
    {
        public string GetString(SearchDirection value)
        {
            switch (value)
            {
                case SearchDirection.Down:
                    return "Down";
                case SearchDirection.Up:
                    return "Up";
            }

            return string.Empty;
        }
    }

    public class MatchTypeConverter : IEnumConverter<MatchType>
    {
        public string GetString(MatchType value)
        {
            switch (value)
            {
                case MatchType.Contains:
                    return "Contains";
                case MatchType.Match:
                    return "Whole field";
                case MatchType.Start:
                    return "Start of field";
            }

            return string.Empty;
        }
    }
}
