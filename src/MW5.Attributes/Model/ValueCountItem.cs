using System;
using System.Globalization;
using MW5.Api.Enums;

namespace MW5.Attributes.Model
{
    public class ValueCountItem : IComparable<ValueCountItem>, IEquatable<ValueCountItem>
    {
        private readonly AttributeType _type;
        private readonly string _strValue = string.Empty;
        private readonly double _dblValue = 0.0;
        private readonly int _intValue = 0;
        private readonly bool _blnValue = false;
        private readonly DateTime _dtmValue = DateTime.MinValue;

        public ValueCountItem(string value, int count)
        {
            _strValue = value;
            Count = count;
            _type = AttributeType.String;
        }

        public ValueCountItem(int value, int count)
        {
            _intValue = value;
            Count = count;
            _type = AttributeType.Integer;
        }

        public ValueCountItem(double value, int count)
        {
            _dblValue = value;
            Count = count;
            _type = AttributeType.Double;
        }

        public ValueCountItem(bool value, int count)
        {
            _blnValue = value;
            Count = count;
            _type = AttributeType.Boolean;
        }

        public ValueCountItem(DateTime value, int count)
        {
            _dtmValue = value;
            Count = count;
            _type = AttributeType.Date;
        }


        public int Count { get; private set; }

        public string Value
        {
            get
            {
                switch (_type)
                {
                    case AttributeType.String:
                        return _strValue;
                    case AttributeType.Integer:
                        return _intValue.ToString(CultureInfo.InvariantCulture);
                    case AttributeType.Double:
                        return _dblValue.ToString(CultureInfo.InvariantCulture);
                    case AttributeType.Boolean:
                        return _blnValue.ToString(CultureInfo.InvariantCulture);
                    case AttributeType.Date:
                        return _dtmValue.ToString(CultureInfo.InvariantCulture);
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object. 
        /// </summary>
        public int CompareTo(ValueCountItem other)
        {
            switch (_type)
            {
                case AttributeType.String:
                    return String.Compare(_strValue, other._strValue, StringComparison.CurrentCulture);
                case AttributeType.Integer:
                    return _intValue.CompareTo(other._intValue);
                case AttributeType.Double:
                    return _dblValue.CompareTo(other._dblValue);
                case AttributeType.Boolean:
                    return _blnValue.CompareTo(other._blnValue);
                case AttributeType.Date:
                    return _dtmValue.CompareTo(other._dtmValue);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        public bool Equals(ValueCountItem other)
        {
            switch (_type)
            {
                case AttributeType.String:
                    return _strValue.Equals(other._strValue);
                case AttributeType.Integer:
                    return _intValue.Equals(other._intValue);
                case AttributeType.Double:
                    return _dblValue.Equals(other._dblValue);
                case AttributeType.Boolean:
                    return _blnValue.Equals(other._blnValue);
                case AttributeType.Date:
                    return _dtmValue.Equals(other._dtmValue);
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            var other = obj as ValueCountItem;
            if (other != null)
            {
                return Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            switch (_type)
            {
                case AttributeType.String:
                    return _strValue.GetHashCode();
                case AttributeType.Integer:
                    return _intValue.GetHashCode();
                case AttributeType.Double:
                    return _dblValue.GetHashCode();
                case AttributeType.Boolean:
                    return _blnValue.GetHashCode();
                case AttributeType.Date:
                    return _dtmValue.GetHashCode();
            }

            return _strValue.GetHashCode();
        }
    }
}
